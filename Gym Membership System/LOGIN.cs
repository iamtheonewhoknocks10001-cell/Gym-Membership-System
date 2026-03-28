using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Timer = System.Windows.Forms.Timer;

namespace Gym_Membership_System
{
    public partial class LOGIN : BaseForm
    {
        // Database connection string
        private string connectionString = "Server=DESKTOP-PMQJTOJ;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Visual constants
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        // Timer and quotes
        private System.Windows.Forms.Timer quoteTimer;
        private string[] quotes = {
            "\"WHERE MUSCLE MEETS TECHNOLOGY\"",
            "\"NO EXCUSES. JUST RESULTS.\"",
            "\"Your body can stand almost anything. It's your mind that you have to convince.\"",
            "\"The only bad workout is the one that didn't happen.\"",
            "\"PROGRESS, NOT PERFECTION\"",
            "\"Success starts with self-discipline.\"",
            "\"TRAIN HARD. STAY STRONG.\"",
            "\"Your health is an investment, not an expense.\""
        };
        private int currentQuoteIndex = 0;

        private bool hasExistingAccounts = false;

        public LOGIN()
        {
            // Start with opacity 0 for fade-in
            this.Opacity = 0;

            InitializeComponent();
            InitializeCustomComponents();
            SetupForm();
        }

        private void InitializeCustomComponents()
        {
            // Setup quote timer
            quoteTimer = new System.Windows.Forms.Timer();
            quoteTimer.Interval = 5000;
            quoteTimer.Tick += QuoteTimer_Tick;
            quoteTimer.Start();

            // Set initial quote
            lblQuote.Text = quotes[0];
            currentQuoteIndex = 0;

            // Form settings
            this.BackgroundImage = null;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);
        }

        private async void SetupForm()
        {
            this.Load += (s, e) => CenterControls();
            this.Resize += (s, e) => CenterControls();
            this.Shown += (s, e) => FadeIn();

            // Check database status
            await CheckDatabaseStatus();
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
                }
            };
            fadeIn.Start();
        }

        private async Task CheckDatabaseStatus()
        {
            hasExistingAccounts = await CheckIfAnyAdminExists();

            if (!hasExistingAccounts)
            {
                // First time setup - show create account button
                lblError.Text = "Welcome! This is your first time running the system. Please create your admin account.";
                lblError.ForeColor = Color.FromArgb(255, 200, 0);
                btnCreateAccount.Text = "CREATE FIRST ADMIN ACCOUNT";
                btnCreateAccount.Font = new Font("Impact", 12F, FontStyle.Bold);
                btnCreateAccount.BackColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                // Has existing accounts - transform button to Forgot Account
                btnCreateAccount.Text = "FORGOT PASSWORD?";
                btnCreateAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                btnCreateAccount.BackColor = Color.FromArgb(255, 100, 0);
            }

            CenterControls();
        }

        private async Task<bool> CheckIfAnyAdminExists()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT COUNT(*) FROM Admins";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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

        private void CenterControls()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int centerX = formWidth / 2;

            // Title
            int topOffset = 120;
            lblTitle.Location = new Point(centerX - 600, topOffset);

            // Quote
            lblQuote.Location = new Point(centerX - 500, lblTitle.Bottom + 5);

            // Login panel
            int panelHeight = 350;
            int panelTop = (formHeight - panelHeight) / 2 + 50;

            lblError.Location = new Point(centerX - 200, panelTop);

            lblEmail.Location = new Point(centerX - 200, lblError.Bottom + 20);
            txtEmail.Location = new Point(centerX - 200, lblEmail.Bottom + 5);

            lblPassword.Location = new Point(centerX - 200, txtEmail.Bottom + 20);
            txtPassword.Location = new Point(centerX - 200, lblPassword.Bottom + 5);

            chkShowPassword.Location = new Point(centerX - 200, txtPassword.Bottom + 10);

            btnLogin.Location = new Point(centerX - 200, chkShowPassword.Bottom + 25);

            btnCreateAccount.Location = new Point(centerX - 200, btnLogin.Bottom + 15);

            if (lblForgotPassword != null)
            {
                lblForgotPassword.Location = new Point(centerX - 200, btnCreateAccount.Bottom + 5);
            }
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "Please enter email and password.";
                lblError.ForeColor = Color.FromArgb(255, 200, 100); // Orange/Yellow for warnings
                lblError.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                return;
            }

            var admin = await AuthenticateAdmin(txtEmail.Text, txtPassword.Text);

            if (admin != null)
            {
                if (!admin.IsActive)
                {
                    lblError.Text = "This account has been deactivated.";
                    lblError.ForeColor = Color.FromArgb(255, 100, 100); // Bright red for errors
                    lblError.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    await LogLoginAttempt(txtEmail.Text, false);
                    return;
                }

                await LogLoginAttempt(txtEmail.Text, true);
                await UpdateLastLogin(txtEmail.Text);

                lblError.Text = "Login successful!";
                lblError.ForeColor = Color.FromArgb(76, 175, 80); // Green for success
                lblError.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

                await Task.Delay(500);

                Form1 mainForm = new Form1(admin.Email, admin.Role, admin.FirstName);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = "Invalid email or password.";
                lblError.ForeColor = Color.FromArgb(255, 100, 100); // Bright red for errors
                lblError.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                await LogLoginAttempt(txtEmail.Text, false);
                await CheckIfEmailExists(txtEmail.Text);
            }
        }

        private async Task<AdminUser> AuthenticateAdmin(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT AdminID, FirstName, LastName, Email, Username, Role, IsActive 
                                    FROM Admins WHERE Email = @Email AND PasswordHash = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new AdminUser
                                {
                                    AdminID = Convert.ToInt32(reader["AdminID"]),
                                    FirstName = reader["FirstName"].ToString() ?? "",
                                    LastName = reader["LastName"].ToString() ?? "",
                                    Email = reader["Email"].ToString() ?? "",
                                    Username = reader["Username"].ToString() ?? "",
                                    Role = reader["Role"].ToString() ?? "Staff",
                                    IsActive = Convert.ToBoolean(reader["IsActive"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private async Task LogLoginAttempt(string email, bool success)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "INSERT INTO LoginAttempts (Email, WasSuccessful, AttemptTime) VALUES (@Email, @Success, @Time)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Success", success);
                        cmd.Parameters.AddWithValue("@Time", DateTime.Now);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch { }
        }

        private async Task UpdateLastLogin(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "UPDATE Admins SET LastLogin = @Time WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Time", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Email", email);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch { }
        }

        private async Task CheckIfEmailExists(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT COUNT(*) FROM Admins WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)await cmd.ExecuteScalarAsync();

                        if (count > 0 && lblForgotPassword != null)
                        {
                            lblForgotPassword.Visible = true;
                        }
                    }
                }
            }
            catch { }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!hasExistingAccounts)
            {
                SIGNUP signupForm = new SIGNUP();
                signupForm.Show();
                this.Hide();
            }
            else
            {
                ForgotAccountForm forgotForm = new ForgotAccountForm(connectionString);
                forgotForm.ShowDialog();
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please enter your email address first.",
                    "Email Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Send password reset instructions to {txtEmail.Text}?",
                "Reset Password",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Password reset instructions have been sent to your email.",
                    "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void QuoteTimer_Tick(object sender, EventArgs e)
        {
            currentQuoteIndex = (currentQuoteIndex + 1) % quotes.Length;
            lblQuote.Text = quotes[currentQuoteIndex];
        }

        private void lblQuote_Click(object sender, EventArgs e)
        {
            currentQuoteIndex = (currentQuoteIndex + 1) % quotes.Length;
            lblQuote.Text = quotes[currentQuoteIndex];
            quoteTimer.Stop();
            quoteTimer.Start();
        }
    }

    public class AdminUser
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Username { get; set; } = "";
        public string Role { get; set; } = "Staff";
        public bool IsActive { get; set; } = true;
    }
}