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
using Timer = System.Windows.Forms.Timer;

namespace Gym_Membership_System
{
    public partial class AddMember : BaseForm
    {
        private string connectionString = "Server=DESKTOP-PMQJTOJ;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Visual constants - MATCHING LOGIN FORM'S DARKER SETTINGS
        private const int OverlayAlpha = 180;      // Same as Login - very dark
        private const int VignetteAlpha = 200;     // Same as Login - strong vignette
        private const float VignetteFocus = 0.55f; // Same as Login - tight focus
        private const int GradientAlpha = 80;      // Same as Login - strong gradient
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        private bool isTransitioning = false;
        private bool isShowingError = false;

        // All quotes - expanded to match Login + more
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
            this.BackgroundImage = null; // Let OnPaintBackground handle background with effects
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;
            this.Text = "Add Member - FitWare";

            // Setup quote timer
            quoteTimer = new System.Windows.Forms.Timer();
            quoteTimer.Interval = 5000;
            quoteTimer.Tick += QuoteTimer_Tick;
            quoteTimer.Start();

            lblQuote.Text = quotes[0];
            currentQuoteIndex = 0;

            // Enable custom painting for smooth rendering (matching Login form)
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
            Timer fadeIn = new Timer();
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

        private void FadeOutAndNavigate()
        {
            if (isTransitioning) return;
            isTransitioning = true;

            Timer fadeOut = new Timer();
            fadeOut.Interval = 15;
            fadeOut.Tick += (s, e) =>
            {
                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.05;
                }
                else
                {
                    fadeOut.Stop();
                    fadeOut.Dispose();

                    Form1 dashboard = null;
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is Form1)
                        {
                            dashboard = (Form1)f;
                            break;
                        }
                    }

                    if (dashboard != null)
                    {
                        dashboard.Show();
                        dashboard.BringToFront();
                        dashboard.WindowState = FormWindowState.Normal;
                        dashboard.WindowState = FormWindowState.Maximized;
                        _ = dashboard.RefreshMembers();
                        this.Hide();
                        this.Opacity = 1;
                        isTransitioning = false;
                    }
                    else
                    {
                        Form1 mainForm = new Form1("", "", "");
                        mainForm.Show();
                        this.Hide();
                        isTransitioning = false;
                    }
                }
            };
            fadeOut.Start();
        }

        private void SetupEventHandlers()
        {
            btnAdd.Click += BtnAdd_Click;
            btnClear.Click += BtnClear_Click;
            btnBack.Click += BtnBack_Click;
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
            // Get the form client size (matching Login form approach)
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int centerX = formWidth / 2;

            // Logo at top (like Login's lblTitle)
            int topOffset = 100;
            lblLogo.Location = new Point(centerX - 600, topOffset);
            lblLogo.Size = new Size(1200, 100);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;

            // Quote below logo (like Login's lblQuote)
            lblQuote.Location = new Point(centerX - 500, lblLogo.Bottom + 20);
            lblQuote.Size = new Size(1000, 40);
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;

            // Calculate vertical center for form fields - TIGHTER SPACING
            int panelHeight = 350;  // Reduced from 400
            int panelTop = (formHeight - panelHeight) / 2 + 50;
            int currentY = panelTop;

            // Tighter spacing between fields (reduced from 20px to 12px)
            int fieldSpacing = 12;

            // First Name
            lblFirstName.Location = new Point(centerX - 200, currentY);
            txtFirstName.Location = new Point(centerX - 200, lblFirstName.Bottom + 5);
            currentY = txtFirstName.Bottom + fieldSpacing;

            // Last Name
            lblLastName.Location = new Point(centerX - 200, currentY);
            txtLastName.Location = new Point(centerX - 200, lblLastName.Bottom + 5);
            currentY = txtLastName.Bottom + fieldSpacing;

            // Email
            lblEmail.Location = new Point(centerX - 200, currentY);
            txtEmail.Location = new Point(centerX - 200, lblEmail.Bottom + 5);
            currentY = txtEmail.Bottom + fieldSpacing;

            // Phone
            lblPhone.Location = new Point(centerX - 200, currentY);
            txtPhone.Location = new Point(centerX - 200, lblPhone.Bottom + 5);
            currentY = txtPhone.Bottom + fieldSpacing;

            // Membership Type
            lblMembershipType.Location = new Point(centerX - 200, currentY);
            cmbMembershipType.Location = new Point(centerX - 200, lblMembershipType.Bottom + 5);
            currentY = cmbMembershipType.Bottom + 25;  // Slightly more space before buttons

            // Buttons - side by side
            btnAdd.Location = new Point(centerX - 200, currentY);
            btnClear.Location = new Point(centerX + 20, currentY);  // Closer together (was +50)

            // BACK button at bottom right (matching Login's style)
            btnBack.Location = new Point(formWidth - 160, formHeight - 100);
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            if (await CheckEmailExists(txtEmail.Text))
            {
                if (!isShowingError)
                {
                    isShowingError = true;
                    MessageBox.Show("A member with this email already exists.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isShowingError = false;
                }
                return;
            }

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
                ClearForm();
                if (!isShowingError)
                {
                    isShowingError = true;
                    MessageBox.Show($"Member {newMember.FirstName} {newMember.LastName} added successfully! (ID: MEM-{newMemberId:D4})",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isShowingError = false;
                }
                FadeOutAndNavigate();
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
            FadeOutAndNavigate();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            quoteTimer?.Stop();
            quoteTimer?.Dispose();
            base.OnFormClosing(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // EXACT MATCH of Login form's OnPaintBackground
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