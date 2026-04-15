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
        private DataTable membersTable;
        private bool isLoading = false;

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

            // Subscribe to CellFormatting event to maintain colors after sorting
            this.dgvAttendance.CellFormatting += DgvAttendance_CellFormatting;
        }

        private async void Attendance_Load(object sender, EventArgs e)
        {
            CenterControls();
            await LoadAllMembers();
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

            // Search Client row
            int startY = 100;
            lblSearchClient.Location = new Point(centerX - 300, startY);
            lblSearchClient.Size = new Size(150, 35);
            txtSearchClient.Location = new Point(centerX - 140, startY);
            txtSearchClient.Size = new Size(350, 36);

            // Status row
            int statusY = startY + 55;
            lblStatusLabel.Location = new Point(centerX - 200, statusY);
            lblStatusLabel.Size = new Size(80, 35);
            lblStatusValue.Location = new Point(centerX - 110, statusY);
            lblStatusValue.Size = new Size(450, 35);

            // DataGridView
            int gridY = statusY + 55;
            int gridWidth = 1100;
            int gridHeight = 400;
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

        // Get the current attendance day (based on 5 AM cutoff)
        private DateTime GetCurrentAttendanceDay()
        {
            DateTime now = DateTime.Now;
            DateTime today5AM = new DateTime(now.Year, now.Month, now.Day, 5, 0, 0);

            if (now < today5AM)
            {
                // Before 5 AM, use yesterday's date
                return now.Date.AddDays(-1);
            }
            else
            {
                // After 5 AM, use today's date
                return now.Date;
            }
        }

        // Convert TimeSpan to AM/PM format
        private string FormatTimeToAMPM(TimeSpan time)
        {
            DateTime dt = DateTime.Today.Add(time);
            return dt.ToString("hh:mm tt");
        }

        private async Task LoadAllMembers()
        {
            try
            {
                if (isLoading) return;
                isLoading = true;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    DateTime attendanceDay = GetCurrentAttendanceDay();

                    string query = @"
                        SELECT 
                            m.MemberID,
                            m.FirstName + ' ' + m.LastName AS MemberName,
                            FORMAT(m.JoinDate, 'MM/dd/yyyy') AS DateJoined,
                            FORMAT(p.DueDate, 'MM/dd/yyyy') AS DueDate,
                            CASE 
                                WHEN a.IsPresent = 1 THEN 'Present'
                                ELSE 'Absent'
                            END AS Status,
                            a.CheckInTime
                        FROM Members m
                        LEFT JOIN Attendance a ON m.MemberID = a.MemberID AND a.AttendanceDate = @AttendanceDay
                        LEFT JOIN (
                            SELECT MemberID, DueDate,
                                   ROW_NUMBER() OVER (PARTITION BY MemberID ORDER BY DueDate DESC) as rn
                            FROM Payments
                        ) p ON m.MemberID = p.MemberID AND p.rn = 1
                        ORDER BY MemberName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AttendanceDay", attendanceDay);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    membersTable = dt;

                    if (dgvAttendance.InvokeRequired)
                    {
                        dgvAttendance.Invoke(new Action(() =>
                        {
                            // Clear existing columns and prevent auto-generation
                            dgvAttendance.Columns.Clear();
                            dgvAttendance.AutoGenerateColumns = false;

                            // Add columns manually
                            dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "MemberName", HeaderText = "Member Name", DataPropertyName = "MemberName", Width = 250 });
                            dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateJoined", HeaderText = "Date Joined", DataPropertyName = "DateJoined", Width = 120 });
                            dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "DueDate", HeaderText = "Due Date", DataPropertyName = "DueDate", Width = 120 });
                            dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status Today", DataPropertyName = "Status", Width = 100 });
                            dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "CheckInTime", HeaderText = "Check In Time", DataPropertyName = "CheckInTime", Width = 120 });

                            dgvAttendance.DataSource = dt;

                            // Store MemberID and DueDate in each row's Tag property
                            for (int i = 0; i < dgvAttendance.Rows.Count; i++)
                            {
                                DataRowView rowView = (DataRowView)dgvAttendance.Rows[i].DataBoundItem;
                                object memberIdObj = rowView["MemberID"];
                                object dueDateObj = rowView["DueDate"];

                                dgvAttendance.Rows[i].Tag = new
                                {
                                    MemberID = memberIdObj != DBNull.Value ? Convert.ToInt32(memberIdObj) : 0,
                                    DueDate = dueDateObj != DBNull.Value ? dueDateObj.ToString() : null
                                };
                            }

                            FormatAttendanceGrid();
                        }));
                    }
                    else
                    {
                        // Clear existing columns and prevent auto-generation
                        dgvAttendance.Columns.Clear();
                        dgvAttendance.AutoGenerateColumns = false;

                        // Add columns manually
                        dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "MemberName", HeaderText = "Member Name", DataPropertyName = "MemberName", Width = 250 });
                        dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateJoined", HeaderText = "Date Joined", DataPropertyName = "DateJoined", Width = 120 });
                        dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "DueDate", HeaderText = "Due Date", DataPropertyName = "DueDate", Width = 120 });
                        dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status Today", DataPropertyName = "Status", Width = 100 });
                        dgvAttendance.Columns.Add(new DataGridViewTextBoxColumn { Name = "CheckInTime", HeaderText = "Check In Time", DataPropertyName = "CheckInTime", Width = 120 });

                        dgvAttendance.DataSource = dt;

                        // Store MemberID and DueDate in each row's Tag property
                        for (int i = 0; i < dgvAttendance.Rows.Count; i++)
                        {
                            DataRowView rowView = (DataRowView)dgvAttendance.Rows[i].DataBoundItem;
                            object memberIdObj = rowView["MemberID"];
                            object dueDateObj = rowView["DueDate"];

                            dgvAttendance.Rows[i].Tag = new
                            {
                                MemberID = memberIdObj != DBNull.Value ? Convert.ToInt32(memberIdObj) : 0,
                                DueDate = dueDateObj != DBNull.Value ? dueDateObj.ToString() : null
                            };
                        }

                        FormatAttendanceGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void FormatAttendanceGrid()
        {
            if (dgvAttendance.Columns.Count == 0) return;

            // Center align all columns except Member Name
            foreach (DataGridViewColumn col in dgvAttendance.Columns)
            {
                if (col.Name != "MemberName")
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void DgvAttendance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if this is the Status column
            if (dgvAttendance.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Present")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(76, 175, 80);
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else if (status == "Absent")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(244, 67, 54);
                }
            }

            // Format CheckInTime to AM/PM
            if (dgvAttendance.Columns[e.ColumnIndex].Name == "CheckInTime" && e.Value != null && e.Value != DBNull.Value)
            {
                string status = dgvAttendance.Rows[e.RowIndex].Cells["Status"].Value?.ToString() ?? "";
                if (status == "Present")
                {
                    TimeSpan time = (TimeSpan)e.Value;
                    DateTime dt = DateTime.Today.Add(time);
                    e.Value = dt.ToString("hh:mm tt");
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void txtSearchClient_TextChanged(object sender, EventArgs e)
        {
            if (membersTable != null)
            {
                string searchTerm = txtSearchClient.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    membersTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    membersTable.DefaultView.RowFilter = $"MemberName LIKE '%{searchTerm}%'";
                }
            }
        }

        private void dgvAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAttendance.Rows[e.RowIndex];

                // Get MemberID and DueDate from the row's Tag property
                if (row.Tag != null)
                {
                    dynamic tagData = row.Tag;
                    selectedMemberId = tagData.MemberID;
                    selectedMemberName = row.Cells["MemberName"].Value?.ToString() ?? "";

                    // Get DueDate from tag
                    string dueDateStr = tagData.DueDate;
                    if (!string.IsNullOrEmpty(dueDateStr))
                    {
                        DateTime dueDate = Convert.ToDateTime(dueDateStr);
                        UpdateDueDateStatus(dueDate);
                    }
                    else
                    {
                        // If no due date, try to get from database
                        GetDueDateFromDatabase(selectedMemberId);
                    }
                }
            }
        }

        private async void GetDueDateFromDatabase(int memberId)
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
                        cmd.Parameters.AddWithValue("@MemberID", memberId);
                        object result = await cmd.ExecuteScalarAsync();

                        if (result != null && result != DBNull.Value)
                        {
                            DateTime dueDate = Convert.ToDateTime(result);
                            UpdateDueDateStatus(dueDate);
                        }
                        else
                        {
                            lblStatusValue.Text = "No records found";
                            lblStatusValue.ForeColor = Color.OrangeRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting due date: {ex.Message}");
                lblStatusValue.Text = "Unable to retrieve due date";
            }
        }

        private void UpdateDueDateStatus(DateTime dueDate)
        {
            DateTime today = DateTime.Now.Date;
            int daysUntilDue = (dueDate.Date - today).Days;

            if (daysUntilDue < 0)
            {
                lblStatusValue.Text = $"EXPIRED (Expired on {dueDate:MM/dd/yyyy})";
                lblStatusValue.ForeColor = Color.FromArgb(244, 67, 54);
            }
            else if (daysUntilDue == 0)
            {
                lblStatusValue.Text = "DUE TODAY!";
                lblStatusValue.ForeColor = Color.FromArgb(255, 193, 7);
            }
            else
            {
                lblStatusValue.Text = $"{daysUntilDue} days until due date";
                lblStatusValue.ForeColor = daysUntilDue <= 7 ? Color.FromArgb(255, 193, 7) : Color.FromArgb(76, 175, 80);
            }
        }

        private async void btnMarkPresent_Click(object sender, EventArgs e)
        {
            if (selectedMemberId == 0)
            {
                MessageBox.Show("Please select a member first by clicking on a row.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime attendanceDay = GetCurrentAttendanceDay();
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
                        checkCmd.Parameters.AddWithValue("@Date", attendanceDay);
                        int count = (int)await checkCmd.ExecuteScalarAsync();

                        if (count == 0)
                        {
                            string insertQuery = @"INSERT INTO Attendance (MemberID, AttendanceDate, IsPresent, CheckInTime, CreatedAt)
                                                  VALUES (@MemberID, @Date, 1, @CheckInTime, GETDATE())";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@MemberID", selectedMemberId);
                                insertCmd.Parameters.AddWithValue("@Date", attendanceDay);
                                insertCmd.Parameters.AddWithValue("@CheckInTime", currentTime.ToString());
                                await insertCmd.ExecuteNonQueryAsync();
                            }

                            MessageBox.Show($"✓ {selectedMemberName} has been marked as PRESENT for today at {FormatTimeToAMPM(currentTime)}!",
                                "Attendance Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            await LoadAllMembers();
                        }
                        else
                        {
                            MessageBox.Show($"ℹ️ {selectedMemberName} has already been marked as present today.",
                                "Already Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking attendance: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadAllMembers();
            MessageBox.Show("Attendance data refreshed!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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