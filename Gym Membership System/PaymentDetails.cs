using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Gym_Membership_System
{
    public partial class PaymentDetails : Form
    {
        private int _paymentId;
        private string _paymentStatus;
        private string _paymentMethod;
        private decimal _amount;
        private DateTime _dueDate;
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

            // Setup dark background
            this.BackgroundImage = null;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            LoadPaymentDetails();
        }

        private void LoadPaymentDetails()
        {
            // Payment ID
            lblPaymentIDValue.Text = $"PAY-{_paymentId:D8}";

            // Payment Status with color
            lblStatusValue.Text = _paymentStatus;
            switch (_paymentStatus)
            {
                case "Paid":
                    lblStatusValue.ForeColor = Color.FromArgb(76, 175, 80);  // Green
                    break;
                case "Pending":
                    lblStatusValue.ForeColor = Color.FromArgb(255, 193, 7);   // Yellow
                    break;
                case "Overdue":
                    lblStatusValue.ForeColor = Color.FromArgb(244, 67, 54);    // Red
                    break;
                default:
                    lblStatusValue.ForeColor = Color.FromArgb(220, 220, 230);
                    break;
            }

            // Payment Method
            lblMethodValue.Text = _paymentMethod;

            // Amount
            lblAmountValue.Text = $"₱{_amount:N2}";

            // Due Date
            lblDueDateValue.Text = _dueDate.ToString("MM/dd/yyyy");

            // Calculate and display remaining time
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

                // Color based on urgency
                if (days <= 3 && days > 0)
                {
                    lblRemainingValue.ForeColor = Color.FromArgb(255, 193, 7);  // Yellow warning
                }
                else
                {
                    lblRemainingValue.ForeColor = Color.FromArgb(76, 175, 80);   // Green
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