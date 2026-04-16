using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class AddPaymentForm : Form
    {
        private string connectionString;
        private string currentUser;
        private int preSelectedMemberId = 0;
        private string preSelectedMemberName = "";
        private string preSelectedMembershipType = "";
        private AddMember _addMemberForm;

        // Visual constants
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        // Original constructor for manual member selection (for standalone use)
        public AddPaymentForm(string connString, string user)
        {
            connectionString = connString;
            currentUser = user;
            InitializeComponent();
            this.BackgroundImage = null;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            this.Load += (s, e) =>
            {
                CenterControls();
            };
            this.Resize += (s, e) => { CenterControls(); this.Invalidate(); };

            LoadMembers();
            LoadMembershipPlans();
            AttachEvents();

            // Set default payment method
            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;
        }

        // Constructor for auto-selecting a member (from AddMember)
        public AddPaymentForm(string connString, string user, int memberId, string memberName, string membershipType, AddMember addMemberForm = null)
        {
            connectionString = connString;
            currentUser = user;
            preSelectedMemberId = memberId;
            preSelectedMemberName = memberName;
            preSelectedMembershipType = membershipType;
            _addMemberForm = addMemberForm;
            InitializeComponent();
            this.BackgroundImage = null;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            this.Load += (s, e) =>
            {
                CenterControls();
            };
            this.Resize += (s, e) => { CenterControls(); this.Invalidate(); };

            LoadMembershipPlans();
            AttachEvents();

            // Set default payment method
            if (cmbPaymentMethod.Items.Count > 0)
                cmbPaymentMethod.SelectedIndex = 0;

            // Auto-select the member and lock membership type
            AutoSelectMemberAndLockMembership();
        }

        private void AttachEvents()
        {
            cmbMembershipType.SelectedIndexChanged += async (s, e) => await UpdateAmount();
            cmbPaymentPeriod.SelectedIndexChanged += async (s, e) => await UpdateAmount();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
            btnBack.Click += BtnBack_Click;
        }

        private void CenterControls()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int centerX = formWidth / 2;

            // Title at top
            int topOffset = 100;
            lblTitle.Location = new Point(centerX - 600, topOffset);
            lblTitle.Size = new Size(1200, 100);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Calculate vertical center for form fields
            int panelHeight = 480;
            int panelTop = (formHeight - panelHeight) / 2 + 50;
            int currentY = panelTop;
            int fieldSpacing = 14;
            int labelWidth = 180;
            int fieldWidth = 400;
            int startX = centerX - (labelWidth + fieldWidth + 15) / 2;

            // Member
            lblMember.Location = new Point(startX, currentY);
            lblMember.Size = new Size(labelWidth, 35);
            cmbMember.Location = new Point(startX + labelWidth + 15, currentY);
            cmbMember.Size = new Size(fieldWidth, 38);
            currentY += fieldSpacing + 51;

            // Membership Type
            lblMembershipType.Location = new Point(startX, currentY);
            lblMembershipType.Size = new Size(labelWidth, 35);
            cmbMembershipType.Location = new Point(startX + labelWidth + 15, currentY);
            cmbMembershipType.Size = new Size(fieldWidth, 38);
            currentY += fieldSpacing + 51;

            // Payment Period
            lblPaymentPeriod.Location = new Point(startX, currentY);
            lblPaymentPeriod.Size = new Size(labelWidth, 35);
            cmbPaymentPeriod.Location = new Point(startX + labelWidth + 15, currentY);
            cmbPaymentPeriod.Size = new Size(fieldWidth, 38);
            currentY += fieldSpacing + 51;

            // Amount
            lblAmount.Location = new Point(startX, currentY);
            lblAmount.Size = new Size(labelWidth, 35);
            nudAmount.Location = new Point(startX + labelWidth + 15, currentY);
            nudAmount.Size = new Size(fieldWidth, 42);
            currentY += fieldSpacing + 51;

            // Payment Method
            lblPaymentMethod.Location = new Point(startX, currentY);
            lblPaymentMethod.Size = new Size(labelWidth, 35);
            cmbPaymentMethod.Location = new Point(startX + labelWidth + 15, currentY);
            cmbPaymentMethod.Size = new Size(fieldWidth, 38);
            currentY += fieldSpacing + 51;

            // Payment Date
            lblPaymentDate.Location = new Point(startX, currentY);
            lblPaymentDate.Size = new Size(labelWidth, 35);
            dtpPaymentDate.Location = new Point(startX + labelWidth + 15, currentY);
            dtpPaymentDate.Size = new Size(fieldWidth, 38);
            currentY += fieldSpacing + 51;

            // Due Date
            lblDueDate.Location = new Point(startX, currentY);
            lblDueDate.Size = new Size(labelWidth, 35);
            dtpDueDate.Location = new Point(startX + labelWidth + 15, currentY);
            dtpDueDate.Size = new Size(fieldWidth, 38);
            currentY += fieldSpacing + 56;

            // Buttons
            int buttonWidth = 180;
            int buttonSpacing = 30;
            int totalButtonsWidth = buttonWidth * 2 + buttonSpacing;
            int buttonStartX = centerX - totalButtonsWidth / 2;

            btnSave.Location = new Point(buttonStartX, currentY);
            btnSave.Size = new Size(buttonWidth, 50);
            btnCancel.Location = new Point(buttonStartX + buttonWidth + buttonSpacing, currentY);
            btnCancel.Size = new Size(buttonWidth, 50);

            // BACK button at bottom right
            btnBack.Location = new Point(formWidth - 160, formHeight - 100);
            btnBack.Size = new Size(140, 45);
        }

        private async void LoadMembers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT MemberID, FirstName + ' ' + LastName AS MemberName FROM Members WHERE IsActive = 1 ORDER BY MemberName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbMember.DisplayMember = "MemberName";
                        cmbMember.ValueMember = "MemberID";
                        cmbMember.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No active members found. Please add members first.",
                            "No Members", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AutoSelectMemberAndLockMembership()
        {
            LoadMembers();

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += async (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                await Task.Delay(50);

                if (cmbMember.Items.Count > 0 && preSelectedMemberId > 0)
                {
                    for (int i = 0; i < cmbMember.Items.Count; i++)
                    {
                        DataRowView drv = cmbMember.Items[i] as DataRowView;
                        if (drv != null && Convert.ToInt32(drv["MemberID"]) == preSelectedMemberId)
                        {
                            cmbMember.SelectedIndex = i;
                            break;
                        }
                    }
                    cmbMember.Enabled = false;
                }

                if (!string.IsNullOrEmpty(preSelectedMembershipType) && cmbMembershipType.Items.Count > 0)
                {
                    for (int i = 0; i < cmbMembershipType.Items.Count; i++)
                    {
                        if (cmbMembershipType.Items[i].ToString().ToUpper() == preSelectedMembershipType.ToUpper())
                        {
                            cmbMembershipType.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else if (cmbMembershipType.Items.Count > 0)
                {
                    cmbMembershipType.SelectedIndex = 0;
                }

                cmbMembershipType.Enabled = false;
            };
            timer.Start();
        }

        private async void LoadMembershipPlans()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT PlanName FROM MembershipPlans WHERE IsActive = 1 ORDER BY PlanName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbMembershipType.Items.Clear();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            cmbMembershipType.Items.Add(row["PlanName"].ToString());
                        }
                    }
                    else
                    {
                        // Fallback to default plans if table is empty
                        cmbMembershipType.Items.Add("BASIC");
                        cmbMembershipType.Items.Add("PREMIUM");
                        MessageBox.Show("Membership plans loaded from defaults. Please run SQL to insert plans.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (cmbMembershipType.Items.Count > 0)
                    {
                        cmbMembershipType.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading membership plans: {ex.Message}\nUsing default plans.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback to default plans
                cmbMembershipType.Items.Clear();
                cmbMembershipType.Items.Add("BASIC");
                cmbMembershipType.Items.Add("PREMIUM");
                if (cmbMembershipType.Items.Count > 0)
                    cmbMembershipType.SelectedIndex = 0;
            }
        }

        private async Task<decimal> GetPriceFromDatabase(string membership, string period)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT 
                                        CASE @Period 
                                            WHEN 'Monthly' THEN MonthlyPrice
                                            WHEN 'Quarterly' THEN QuarterlyPrice
                                            WHEN 'Annual' THEN AnnualPrice
                                        END AS Price
                                    FROM MembershipPlans 
                                    WHERE UPPER(PlanName) = UPPER(@Membership) AND IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Membership", membership);
                        cmd.Parameters.AddWithValue("@Period", period);
                        object result = await cmd.ExecuteScalarAsync();
                        return result != null ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch
            {
                // Fallback prices
                if (membership.ToUpper() == "BASIC")
                {
                    if (period == "Monthly") return 1050.00m;
                    if (period == "Quarterly") return 3150.00m;
                    if (period == "Annual") return 12775.00m;
                }
                else if (membership.ToUpper() == "PREMIUM")
                {
                    if (period == "Monthly") return 1400.00m;
                    if (period == "Quarterly") return 4000.00m;
                    if (period == "Annual") return 15000.00m;
                }
                return 0;
            }
        }

        private async Task UpdateAmount()
        {
            if (cmbMembershipType.SelectedItem != null && cmbPaymentPeriod.SelectedItem != null)
            {
                string membership = cmbMembershipType.SelectedItem.ToString();
                string period = cmbPaymentPeriod.SelectedItem.ToString();
                decimal amount = await GetPriceFromDatabase(membership, period);

                nudAmount.Value = amount;

                if (period == "Monthly")
                    dtpDueDate.Value = DateTime.Now.AddMonths(1);
                else if (period == "Quarterly")
                    dtpDueDate.Value = DateTime.Now.AddMonths(3);
                else if (period == "Annual")
                    dtpDueDate.Value = DateTime.Now.AddYears(1);
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            int selectedMemberId;

            if (preSelectedMemberId > 0)
            {
                selectedMemberId = preSelectedMemberId;
            }
            else if (cmbMember.SelectedValue != null)
            {
                selectedMemberId = (int)cmbMember.SelectedValue;
            }
            else
            {
                MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Please select membership and period to calculate amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string receiptNumber = GenerateReceiptNumber();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string paymentFor = cmbMembershipType.SelectedItem.ToString();
                    string paymentPeriod = cmbPaymentPeriod.SelectedItem.ToString();
                    string paymentStatus = "Paid";

                    string query = @"INSERT INTO Payments 
                    (MemberID, Amount, PaymentDate, DueDate, PaymentMethod, 
                     PaymentStatus, ReceiptNumber, PaymentFor, 
                     PaymentPeriod, ProcessedBy, CreatedAt)
                    VALUES 
                    (@MemberID, @Amount, @PaymentDate, @DueDate, @PaymentMethod,
                     @PaymentStatus, @ReceiptNumber, @PaymentFor,
                     @PaymentPeriod, @ProcessedBy, @CreatedAt)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", selectedMemberId);
                        cmd.Parameters.AddWithValue("@Amount", nudAmount.Value);
                        cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                        cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                        cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                        cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);
                        cmd.Parameters.AddWithValue("@PaymentFor", paymentFor.ToUpper());
                        cmd.Parameters.AddWithValue("@PaymentPeriod", paymentPeriod);
                        cmd.Parameters.AddWithValue("@ProcessedBy", currentUser);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                MessageBox.Show($"Payment recorded successfully!\nReceipt Number: {receiptNumber}\nAmount: ₱{nudAmount.Value:N2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private string GenerateReceiptNumber()
        {
            return $"RCP-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
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