using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class PaymentDetails : Form
    {
        private int _paymentId;
        private string _paymentStatus;
        private string _paymentMethod;
        private decimal _amount;
        private DateTime _dueDate;
        private int _memberId;
        private string _memberName;
        private string _membershipType;
        private string _paymentPeriod;
        private string _connectionString;

        // Visual constants for dark background
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        public PaymentDetails(int paymentId, string paymentStatus, string paymentMethod, decimal amount, DateTime dueDate, string connectionString)
        {
            InitializeComponent();
            _paymentId = paymentId;
            _paymentStatus = paymentStatus;
            _paymentMethod = paymentMethod;
            _amount = amount;
            _dueDate = dueDate;
            _connectionString = connectionString;

            this.BackgroundImage = null;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            LoadPaymentDetails();
            LoadMemberInfo();
        }

        private async void LoadMemberInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT m.MemberID, m.FirstName + ' ' + m.LastName AS MemberName, 
                                            m.MembershipType, p.PaymentPeriod
                                    FROM Payments p
                                    INNER JOIN Members m ON p.MemberID = m.MemberID
                                    WHERE p.PaymentID = @PaymentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentID", _paymentId);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                _memberId = Convert.ToInt32(reader["MemberID"]);
                                _memberName = reader["MemberName"].ToString();
                                _membershipType = reader["MembershipType"].ToString();
                                _paymentPeriod = reader["PaymentPeriod"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading member info: {ex.Message}");
            }
        }

        private void LoadPaymentDetails()
        {
            lblPaymentIDValue.Text = $"PAY-{_paymentId:D8}";

            lblStatusValue.Text = _paymentStatus;
            switch (_paymentStatus)
            {
                case "Paid":
                    lblStatusValue.ForeColor = Color.FromArgb(76, 175, 80);
                    break;
                case "Pending":
                    lblStatusValue.ForeColor = Color.FromArgb(255, 193, 7);
                    break;
                case "Overdue":
                    lblStatusValue.ForeColor = Color.FromArgb(244, 67, 54);
                    break;
                default:
                    lblStatusValue.ForeColor = Color.FromArgb(220, 220, 230);
                    break;
            }

            lblMethodValue.Text = _paymentMethod;
            lblAmountValue.Text = $"₱{_amount:N2}";
            lblDueDateValue.Text = _dueDate.ToString("MM/dd/yyyy");
            UpdateRemainingTime();
        }

        private void UpdateRemainingTime()
        {
            TimeSpan timeRemaining = _dueDate - DateTime.Now;

            if (timeRemaining.TotalDays > 0)
            {
                int days = (int)timeRemaining.TotalDays;
                int hours = timeRemaining.Hours;
                int minutes = timeRemaining.Minutes;

                if (days > 0)
                {
                    lblRemainingValue.Text = $"{days} day(s), {hours} hour(s), {minutes} minute(s)";
                }
                else if (hours > 0)
                {
                    lblRemainingValue.Text = $"{hours} hour(s), {minutes} minute(s)";
                }
                else if (minutes > 0)
                {
                    lblRemainingValue.Text = $"{minutes} minute(s)";
                }
                else
                {
                    lblRemainingValue.Text = "Less than a minute";
                }

                if (days <= 3 && days > 0)
                {
                    lblRemainingValue.ForeColor = Color.FromArgb(255, 193, 7);
                }
                else
                {
                    lblRemainingValue.ForeColor = Color.FromArgb(76, 175, 80);
                }
            }
            else if (timeRemaining.TotalDays == 0)
            {
                lblRemainingValue.Text = "Due today!";
                lblRemainingValue.ForeColor = Color.FromArgb(255, 193, 7);
            }
            else
            {
                lblRemainingValue.Text = "EXPIRED";
                lblRemainingValue.ForeColor = Color.FromArgb(244, 67, 54);
            }
        }

        private async void btnRenew_Click(object sender, EventArgs e)
        {
            // Check if renewal is allowed based on payment status and due date
            bool canRenew = (_paymentStatus == "Paid" && _dueDate.Date <= DateTime.Now.Date);

            string disclaimerMessage;
            DialogResult result;

            if (canRenew)
            {
                // Full disclaimer for eligible renewal
                disclaimerMessage =
                    "⚠️ SUBSCRIPTION RENEWAL ⚠️\n\n" +
                    $"Member: {_memberName}\n" +
                    $"Membership Type: {_membershipType}\n" +
                    $"Payment Period: {_paymentPeriod}\n" +
                    $"Current Due Date: {_dueDate:MM/dd/yyyy}\n\n" +
                    "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                    "📋 RENEWAL TERMS AND CONDITIONS:\n\n" +
                    "1. Membership type CANNOT be changed upon renewal\n" +
                    "2. Payment period CANNOT be changed upon renewal\n" +
                    "3. New due date will be calculated based on the current period\n" +
                    "4. This action will create a new payment record\n" +
                    "5. Renewal fees are non-refundable\n\n" +
                    "Do you agree to these terms and wish to proceed with renewal?";

                result = MessageBox.Show(disclaimerMessage, "Renewal Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ProcessRenewal();
                }
            }
            else
            {
                // Warning message for early renewal attempt
                string reason = _paymentStatus != "Paid" ?
                    "This payment has not been completed yet." :
                    $"Your subscription is still active until {_dueDate:MM/dd/yyyy}.\nRenewal can only be processed after the due date has passed.";

                disclaimerMessage =
                    "⚠️ RENEWAL NOT AVAILABLE ⚠️\n\n" +
                    $"Member: {_memberName}\n" +
                    $"Membership Type: {_membershipType}\n" +
                    $"Current Due Date: {_dueDate:MM/dd/yyyy}\n\n" +
                    "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                    $"❌ Cannot process renewal because:\n{reason}\n\n" +
                    "📋 RENEWAL POLICY:\n" +
                    "• Renewal is only allowed AFTER the current due date has passed\n" +
                    "• Membership type and payment period cannot be changed\n" +
                    "• You will be able to renew once your subscription expires\n\n" +
                    "Do you still want to see renewal terms?";

                result = MessageBox.Show(disclaimerMessage, "Renewal Not Available",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    // Show the terms even if they can't renew yet
                    MessageBox.Show(
                        "📋 RENEWAL INFORMATION:\n\n" +
                        "When your subscription expires, you can renew with these terms:\n\n" +
                        "• Membership type can now be upgraded\n" +
                        "• Payment period can also be upgraged\n" +
                        "• New due date will be calculated from the current due date\n" +
                        "• A new payment receipt will be generated\n\n" +
                        "Please wait until your current subscription ends to renew.",
                        "Renewal Terms",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private async Task ProcessRenewal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    DateTime newDueDate = _dueDate;
                    if (_paymentPeriod == "Monthly")
                        newDueDate = _dueDate.AddMonths(1);
                    else if (_paymentPeriod == "Quarterly")
                        newDueDate = _dueDate.AddMonths(3);
                    else if (_paymentPeriod == "Annual")
                        newDueDate = _dueDate.AddYears(1);

                    string receiptNumber = GenerateReceiptNumber();

                    string insertQuery = @"INSERT INTO Payments 
                            (MemberID, Amount, PaymentDate, DueDate, PaymentMethod, 
                             PaymentStatus, ReceiptNumber, PaymentFor, 
                             PaymentPeriod, ProcessedBy, CreatedAt)
                            VALUES 
                            (@MemberID, @Amount, GETDATE(), @DueDate, @PaymentMethod,
                             'Paid', @ReceiptNumber, @PaymentFor,
                             @PaymentPeriod, @ProcessedBy, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", _memberId);
                        cmd.Parameters.AddWithValue("@Amount", _amount);
                        cmd.Parameters.AddWithValue("@DueDate", newDueDate);
                        cmd.Parameters.AddWithValue("@PaymentMethod", _paymentMethod);
                        cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);
                        cmd.Parameters.AddWithValue("@PaymentFor", _membershipType);
                        cmd.Parameters.AddWithValue("@PaymentPeriod", _paymentPeriod);
                        cmd.Parameters.AddWithValue("@ProcessedBy", "Admin");

                        await cmd.ExecuteNonQueryAsync();
                    }

                    MessageBox.Show(
                        $"✅ SUBSCRIPTION RENEWED SUCCESSFULLY!\n\n" +
                        $"Member: {_memberName}\n" +
                        $"Membership: {_membershipType}\n" +
                        $"Period: {_paymentPeriod}\n" +
                        $"Previous Due Date: {_dueDate:MM/dd/yyyy}\n" +
                        $"New Due Date: {newDueDate:MM/dd/yyyy}\n\n" +
                        $"Receipt Number: {receiptNumber}",
                        "Renewal Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing renewal: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateReceiptNumber()
        {
            return $"RCP-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
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