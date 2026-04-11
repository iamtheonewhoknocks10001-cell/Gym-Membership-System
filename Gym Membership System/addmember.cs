using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class AddMember : BaseForm
    {
        private string connectionString = "Server=DESKTOP-PMQJTOJ;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Visual constants
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        private bool _isValidating = false;
        private int _newMemberId = 0;
        private string _newMemberName = "";

        // All quotes
        private string[] quotes = {
            "\"WHERE MUSCLE MEETS TECHNOLOGY\"",
            "\"NO EXCUSES. JUST RESULTS.\"",
            "\"Your body can stand almost anything. It's your mind that you have to convince.\"",
            "\"The only bad workout is the one that didn't happen.\"",
            "\"PROGRESS, NOT PERFECTION\"",
            "\"Success starts with self-discipline.\"",
            "\"TRAIN HARD. STAY STRONG.\"",
            "\"Your health is an investment, not an expense.\"",
            "\"MAKE YOURSELF PROUD\"",
            "\"The pain you feel today will be the strength you feel tomorrow.\"",
            "\"EARN YOUR BODY\"",
            "\"Strive for progress, not perfection.\"",
            "\"NO PAIN. NO GAIN. NO EXCUSES.\"",
            "\"You are stronger than you think.\"",
            "\"FIND YOUR STRENGTH\""
        };
        private int currentQuoteIndex = 0;
        private System.Windows.Forms.Timer quoteTimer;

        public AddMember()
        {
            InitializeComponent();
            SetupForm();
            this.Opacity = 0;
        }

        private void SetupForm()
        {
            this.BackgroundImage = null;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.Text = "Add Member - FitWare";

            quoteTimer = new System.Windows.Forms.Timer();
            quoteTimer.Interval = 5000;
            quoteTimer.Tick += QuoteTimer_Tick;
            quoteTimer.Start();

            lblQuote.Text = quotes[0];
            currentQuoteIndex = 0;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            this.Load += (s, e) => CenterControls();
            this.Resize += (s, e) => { CenterControls(); this.Invalidate(); };
            this.Shown += (s, e) => FadeIn();

            SetupEventHandlers();
        }

        private void QuoteTimer_Tick(object sender, EventArgs e)
        {
            currentQuoteIndex = (currentQuoteIndex + 1) % quotes.Length;
            lblQuote.Text = quotes[currentQuoteIndex];
        }

        private void FadeIn()
        {
            System.Windows.Forms.Timer fadeIn = new System.Windows.Forms.Timer();
            fadeIn.Interval = 15;
            fadeIn.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.05;
                }
                else
                {
                    fadeIn.Stop();
                    fadeIn.Dispose();
                }
            };
            fadeIn.Start();
        }

        private void SetupEventHandlers()
        {
            // Remove existing handlers first to prevent duplicates
            btnNext.Click -= BtnNext_Click;
            btnNext.Click += BtnNext_Click;

            btnClear.Click -= BtnClear_Click;
            btnClear.Click += BtnClear_Click;

            btnBack.Click -= BtnBack_Click;
            btnBack.Click += BtnBack_Click;

            lblQuote.Click -= LblQuote_Click;
            lblQuote.Click += LblQuote_Click;
        }

        private void LblQuote_Click(object sender, EventArgs e)
        {
            currentQuoteIndex = (currentQuoteIndex + 1) % quotes.Length;
            lblQuote.Text = quotes[currentQuoteIndex];
            quoteTimer.Stop();
            quoteTimer.Start();
        }

        private void CenterControls()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int centerX = formWidth / 2;

            int topOffset = 100;
            lblLogo.Location = new Point(centerX - 600, topOffset);
            lblLogo.Size = new Size(1200, 100);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            lblQuote.Location = new Point(centerX - 500, lblLogo.Bottom + 20);
            lblQuote.Size = new Size(1000, 40);
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;

            int panelHeight = 350;
            int panelTop = (formHeight - panelHeight) / 2 + 50;
            int currentY = panelTop;
            int fieldSpacing = 12;

            lblFirstName.Location = new Point(centerX - 200, currentY);
            txtFirstName.Location = new Point(centerX - 200, lblFirstName.Bottom + 5);
            currentY = txtFirstName.Bottom + fieldSpacing;

            lblLastName.Location = new Point(centerX - 200, currentY);
            txtLastName.Location = new Point(centerX - 200, lblLastName.Bottom + 5);
            currentY = txtLastName.Bottom + fieldSpacing;

            lblEmail.Location = new Point(centerX - 200, currentY);
            txtEmail.Location = new Point(centerX - 200, lblEmail.Bottom + 5);
            currentY = txtEmail.Bottom + fieldSpacing;

            lblPhone.Location = new Point(centerX - 200, currentY);
            txtPhone.Location = new Point(centerX - 200, lblPhone.Bottom + 5);
            currentY = txtPhone.Bottom + fieldSpacing;

            lblMembershipType.Location = new Point(centerX - 200, currentY);
            cmbMembershipType.Location = new Point(centerX - 200, lblMembershipType.Bottom + 5);
            currentY = cmbMembershipType.Bottom + 25;

            btnNext.Location = new Point(centerX - 200, currentY);
            btnClear.Location = new Point(centerX + 20, currentY);
            btnBack.Location = new Point(formWidth - 160, formHeight - 100);
        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            // Prevent multiple validation calls
            if (_isValidating) return;
            _isValidating = true;

            // Disable the button immediately
            btnNext.Enabled = false;

            try
            {
                // Validate First Name
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("First Name is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }

                // Validate Last Name
                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Last Name is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLastName.Focus();
                    return;
                }

                // Validate Email
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Email is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Validate Phone
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Phone number is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                // Check if email already exists in database
                bool emailExists = await CheckEmailExists(txtEmail.Text);

                if (emailExists)
                {
                    MessageBox.Show("A member with this email already exists.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                // Save member to database
                Member newMember = new Member
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    MembershipType = cmbMembershipType.SelectedItem?.ToString() ?? "Basic",
                    JoinDate = DateTime.Now,
                    IsActive = true
                };

                int newMemberId = await SaveMemberToDatabase(newMember);

                if (newMemberId > 0)
                {
                    _newMemberId = newMemberId;
                    _newMemberName = $"{newMember.FirstName} {newMember.LastName}";

                    ClearForm();

                    // Open payment form
                    AddPaymentForm paymentForm = new AddPaymentForm(connectionString, "Admin", _newMemberId, _newMemberName, newMember.MembershipType);
                    DialogResult paymentResult = paymentForm.ShowDialog();

                    // ONLY go to Form1 if payment was actually saved (DialogResult.OK)
                    if (paymentResult == DialogResult.OK)
                    {
                        Form1 dashboard = Application.OpenForms.OfType<Form1>().FirstOrDefault();

                        if (dashboard != null && !dashboard.IsDisposed)
                        {
                            dashboard.Show();
                            dashboard.BringToFront();
                            dashboard.WindowState = FormWindowState.Maximized;
                            await dashboard.RefreshMembers();
                        }
                        else
                        {
                            Form1 mainForm = new Form1("", "", "");
                            mainForm.Show();
                        }

                        // Close AddMember only after successful payment
                        this.Close();
                    }
                    // If payment was cancelled (DialogResult.Cancel), just stay on AddMember
                }
            }
            finally
            {
                _isValidating = false;
                // Only re-enable button if the form is still open
                if (!this.IsDisposed)
                {
                    btnNext.Enabled = true;
                }
            }
        }

        private async Task<bool> CheckEmailExists(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT COUNT(*) FROM Members WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)await cmd.ExecuteScalarAsync();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task<int> SaveMemberToDatabase(Member member)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"INSERT INTO Members (FirstName, LastName, Email, Phone, MembershipType, JoinDate, IsActive) 
                                    VALUES (@FirstName, @LastName, @Email, @Phone, @MembershipType, @JoinDate, @IsActive);
                                    SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", member.LastName);
                        cmd.Parameters.AddWithValue("@Email", member.Email);
                        cmd.Parameters.AddWithValue("@Phone", member.Phone);
                        cmd.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                        cmd.Parameters.AddWithValue("@JoinDate", member.JoinDate);
                        cmd.Parameters.AddWithValue("@IsActive", member.IsActive);

                        int newId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cmbMembershipType.SelectedIndex = 0;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Find and show Form1 FIRST
            Form1 dashboard = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (dashboard != null && !dashboard.IsDisposed)
            {
                dashboard.Show();
                dashboard.BringToFront();
                dashboard.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Form1 mainForm = new Form1("", "", "");
                mainForm.Show();
            }

            // THEN close AddMember
            this.Dispose();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            quoteTimer?.Stop();
            quoteTimer?.Dispose();
            base.OnFormClosing(e);
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

    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string MembershipType { get; set; } = "Basic";
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}