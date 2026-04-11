using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class Attendance : Form
    {
        private string connectionString;
        private int selectedMemberId = 0;
        private string selectedMemberName = "";
        private System.Windows.Forms.Timer flashTimer;
        private bool isFlashing = false;

        // Visual constants
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        public Attendance(string connString)
        {
            connectionString = connString;
            InitializeComponent();
            this.BackgroundImage = null;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            flashTimer = new System.Windows.Forms.Timer();
            flashTimer.Interval = 500;
            flashTimer.Tick += FlashTimer_Tick;
        }

        private async void Attendance_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
            CenterControls();
        }

        private void Attendance_Resize(object sender, EventArgs e)
        {
            CenterControls();
            this.Invalidate();
        }

        private void CenterControls()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int centerX = formWidth / 2;

            // Title - Top Left
            lblTitle.Location = new Point(0, 0);
            lblTitle.Size = new Size(formWidth, 65);

            // Draw border line at bottom of title
            lblTitle.Paint += (s, pe) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    pe.Graphics.DrawLine(pen, 0, lblTitle.Height - 1, lblTitle.Width, lblTitle.Height - 1);
                }
            };

            // Select Customer row
            int startY = 100;
            lblSelectCustomer.Location = new Point(centerX - 300, startY);
            lblSelectCustomer.Size = new Size(180, 32);
            cmbCustomer.Location = new Point(centerX - 110, startY - 2);
            cmbCustomer.Size = new Size(350, 36);

            // Status row
            int statusY = startY + 55;
            lblStatusLabel.Location = new Point(centerX - 300, statusY);
            lblStatusValue.Location = new Point(centerX - 220, statusY);
            lblStatusValue.Size = new Size(350, 32);

            // Due Alert
            int dueY = statusY + 40;
            lblDueAlert.Location = new Point(centerX - 300, dueY);
            lblDueAlert.Size = new Size(600, 25);

            // Week Range
            int weekY = dueY + 30;
            lblWeekRange.Location = new Point(centerX - 300, weekY);

            // DataGridView
            int gridY = weekY + 40;
            int gridWidth = 1000;
            int gridHeight = 350;
            dgvAttendance.Location = new Point(centerX - gridWidth / 2, gridY);
            dgvAttendance.Size = new Size(gridWidth, gridHeight);

            // Buttons
            int buttonY = gridY + gridHeight + 30;
            int buttonWidth = 160;
            int spacing = 20;
            int totalWidth = buttonWidth * 3 + spacing * 2;
            int buttonStartX = centerX - totalWidth / 2;

            btnMarkPresent.Location = new Point(buttonStartX, buttonY);
            btnMarkPresent.Size = new Size(buttonWidth, 45);

            btnRefresh.Location = new Point(buttonStartX + buttonWidth + spacing, buttonY);
            btnRefresh.Size = new Size(buttonWidth, 45);

            btnClose.Location = new Point(buttonStartX + (buttonWidth + spacing) * 2, buttonY);
            btnClose.Size = new Size(buttonWidth, 45);
        }

        private async Task LoadCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT MemberID, FirstName + ' ' + LastName AS MemberName FROM Members ORDER BY MemberName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbCustomer.DisplayMember = "MemberName";
                    cmbCustomer.ValueMember = "MemberID";
                    cmbCustomer.DataSource = dt;

                    if (cmbCustomer.Items.Count > 0)
                    {
                        cmbCustomer.SelectedIndex = 0;
                    }
                    else
                    {
                        dgvAttendance.Rows.Clear();
                        dgvAttendance.Rows.Add("No members found", "Add members first", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue != null)
            {
                selectedMemberId = (int)cmbCustomer.SelectedValue;
                selectedMemberName = cmbCustomer.Text;
                await LoadAttendanceData();
                await CheckMemberStatus();
                await CheckDueDateAlert();
            }
        }

        private async Task LoadAttendanceData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Clear existing rows
                    dgvAttendance.Rows.Clear();

                    // Get attendance data for last 7 days
                    string query = @"
                        SELECT 
                            FORMAT(AttendanceDate, 'MM/dd/yyyy') AS Date,
                            DATENAME(dw, AttendanceDate) AS Day,
                            CASE WHEN IsPresent = 1 THEN 'Present' ELSE 'Absent' END AS Status,
                            LEFT(CAST(CheckInTime AS VARCHAR), 5) AS CheckIn,
                            LEFT(CAST(CheckOutTime AS VARCHAR), 5) AS CheckOut
                        FROM Attendance 
                        WHERE MemberID = @MemberID 
                        AND AttendanceDate >= DATEADD(day, -7, CAST(GETDATE() AS DATE))
                        ORDER BY AttendanceDate DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", selectedMemberId);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string status = reader["Status"].ToString();
                            int rowIndex = dgvAttendance.Rows.Add(
                                reader["Date"].ToString(),
                                reader["Day"].ToString(),
                                status,
                                reader["CheckIn"].ToString(),
                                reader["CheckOut"].ToString()
                            );

                            // Color the status cell
                            if (status == "Present")
                            {
                                dgvAttendance.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.FromArgb(76, 175, 80);
                                dgvAttendance.Rows[rowIndex].Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                            }
                            else if (status == "Absent")
                            {
                                dgvAttendance.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.FromArgb(244, 67, 54);
                            }
                        }
                    }

                    // If no rows, show message
                    if (dgvAttendance.Rows.Count == 0)
                    {
                        dgvAttendance.Rows.Add("No records for last 7 days", "Click 'MARK PRESENT' to add today", "", "", "");
                        dgvAttendance.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
                        dgvAttendance.Rows[0].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading attendance: {ex.Message}");
                dgvAttendance.Rows.Clear();
                dgvAttendance.Rows.Add("Error loading data", ex.Message, "", "", "");
            }
        }

        private async Task CheckMemberStatus()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT 
                                        COUNT(CASE WHEN IsPresent = 1 THEN 1 END) AS PresentCount,
                                        COUNT(*) AS TotalDays
                                    FROM Attendance 
                                    WHERE MemberID = @MemberID 
                                    AND AttendanceDate >= DATEADD(day, -7, CAST(GETDATE() AS DATE))";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", selectedMemberId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int presentCount = reader["PresentCount"] != DBNull.Value ? Convert.ToInt32(reader["PresentCount"]) : 0;
                                int totalDays = reader["TotalDays"] != DBNull.Value ? Convert.ToInt32(reader["TotalDays"]) : 0;

                                if (totalDays == 0)
                                {
                                    lblStatusValue.Text = "⚠️ No attendance records this week";
                                    lblStatusValue.ForeColor = Color.FromArgb(255, 193, 7);
                                }
                                else if (totalDays == 7 && presentCount == 7)
                                {
                                    lblStatusValue.Text = "✅ ACTIVE (Perfect Attendance!)";
                                    lblStatusValue.ForeColor = Color.FromArgb(76, 175, 80);
                                }
                                else if (presentCount >= 5)
                                {
                                    lblStatusValue.Text = "✅ ACTIVE (Good Attendance)";
                                    lblStatusValue.ForeColor = Color.FromArgb(76, 175, 80);
                                }
                                else if (presentCount >= 3)
                                {
                                    lblStatusValue.Text = "⚠️ WARNING (Low Attendance)";
                                    lblStatusValue.ForeColor = Color.FromArgb(255, 193, 7);
                                }
                                else if (presentCount > 0)
                                {
                                    lblStatusValue.Text = "❌ INACTIVE (Poor attendance)";
                                    lblStatusValue.ForeColor = Color.FromArgb(244, 67, 54);
                                }
                                else
                                {
                                    lblStatusValue.Text = "❌ INACTIVE (No attendance)";
                                    lblStatusValue.ForeColor = Color.FromArgb(244, 67, 54);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking status: {ex.Message}");
                lblStatusValue.Text = "Unable to check status";
            }
        }

        private async Task CheckDueDateAlert()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT TOP 1 DueDate FROM Payments 
                                    WHERE MemberID = @MemberID 
                                    ORDER BY DueDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", selectedMemberId);
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null)
                        {
                            DateTime dueDate = Convert.ToDateTime(result);
                            DateTime today = DateTime.Now.Date;
                            int daysUntilDue = (dueDate - today).Days;

                            if (daysUntilDue <= 7 && daysUntilDue > 0)
                            {
                                lblDueAlert.Text = $"⚠️ DUE DATE ALERT: Membership expires in {daysUntilDue} day(s)! Please renew soon!";
                                lblDueAlert.ForeColor = Color.FromArgb(255, 193, 7);
                                StartFlashing();
                            }
                            else if (daysUntilDue <= 0)
                            {
                                lblDueAlert.Text = $"❌ EXPIRED: Membership expired on {dueDate:MM/dd/yyyy}. Please renew immediately!";
                                lblDueAlert.ForeColor = Color.FromArgb(244, 67, 54);
                                StartFlashing();
                            }
                            else
                            {
                                lblDueAlert.Text = $"✅ Membership valid until {dueDate:MM/dd/yyyy}";
                                lblDueAlert.ForeColor = Color.FromArgb(76, 175, 80);
                                StopFlashing();
                            }
                        }
                        else
                        {
                            lblDueAlert.Text = "ℹ️ No payment records found";
                            lblDueAlert.ForeColor = Color.FromArgb(100, 100, 110);
                            StopFlashing();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking due date: {ex.Message}");
                lblDueAlert.Text = "Unable to check due date";
            }
        }

        private void StartFlashing()
        {
            isFlashing = true;
            flashTimer.Start();
        }

        private void StopFlashing()
        {
            isFlashing = false;
            flashTimer.Stop();
            lblDueAlert.BackColor = Color.Transparent;
        }

        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            if (isFlashing)
            {
                if (lblDueAlert.BackColor == Color.Transparent)
                    lblDueAlert.BackColor = Color.FromArgb(255, 200, 150);
                else
                    lblDueAlert.BackColor = Color.Transparent;
            }
        }

        private async void btnMarkPresent_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Please select a customer first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime today = DateTime.Now.Date;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Check if attendance already exists for today
                    string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE MemberID = @MemberID AND AttendanceDate = @Date";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MemberID", selectedMemberId);
                        checkCmd.Parameters.AddWithValue("@Date", today);
                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count == 0)
                        {
                            string insertQuery = @"INSERT INTO Attendance (MemberID, AttendanceDate, IsPresent, CheckInTime, CreatedAt)
                                                  VALUES (@MemberID, @Date, 1, @CheckInTime, GETDATE())";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MemberID", selectedMemberId);
                                insertCmd.Parameters.AddWithValue("@Date", today);
                                insertCmd.Parameters.AddWithValue("@CheckInTime", currentTime.ToString());
                                await insertCmd.ExecuteNonQueryAsync();
                            }

                            MessageBox.Show($"✓ {selectedMemberName} has been marked as PRESENT for today at {currentTime.ToString(@"hh\:mm")}!",
                                "Attendance Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"ℹ️ {selectedMemberName} has already been marked as present today.",
                                "Already Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                await LoadAttendanceData();
                await CheckMemberStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking attendance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadAttendanceData();
            await CheckMemberStatus();
            await CheckDueDateAlert();
            MessageBox.Show("Attendance data refreshed!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StopFlashing();
            flashTimer?.Dispose();
            this.Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            if (_backgroundImage != null)
            {
                var img = _backgroundImage;
                float ratio = Math.Max((float)rect.Width / img.Width, (float)rect.Height / img.Height);
                int drawW = (int)Math.Ceiling(img.Width * ratio);
                int drawH = (int)Math.Ceiling(img.Height * ratio);
                int drawX = rect.X + (rect.Width - drawW) / 2;
                int drawY = rect.Y + (rect.Height - drawH) / 2;
                g.DrawImage(img, new Rectangle(drawX, drawY, drawW, drawH));
            }

            using (var overlay = new SolidBrush(Color.FromArgb(OverlayAlpha, 0, 0, 0)))
                g.FillRectangle(overlay, rect);

            using (var path = new GraphicsPath())
            {
                float inflateW = rect.Width * 0.5f;
                float inflateH = rect.Height * 0.5f;
                path.AddEllipse(rect.X - inflateW / 2, rect.Y - inflateH / 2, rect.Width + inflateW, rect.Height + inflateH);
                using (var pgb = new PathGradientBrush(path))
                {
                    pgb.CenterColor = Color.FromArgb(0, 0, 0, 0);
                    pgb.SurroundColors = new[] { Color.FromArgb(VignetteAlpha, 0, 0, 0) };
                    pgb.FocusScales = new PointF(VignetteFocus, VignetteFocus);
                    g.FillRectangle(pgb, rect);
                }
            }

            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(GradientAlpha, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), 90f))
                g.FillRectangle(lg, rect);
        }
    }
}