using System;
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
    public partial class SIGNUP : BaseForm  // Change from Form to BaseForm
    {
        private string connectionString = "Server=DESKTOP-AH6OHHK;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Visual constants - Made darker like login page
        private const int OverlayAlpha = 180;  // Increased from 100 to 180 (darker)
        private const int VignetteAlpha = 220; // Increased from 200 to 220
        private const float VignetteFocus = 0.45f;
        private const int GradientAlpha = 100; // Increased from 80 to 100
        private readonly Image _backgroundImage = Properties.Resources.signupbg1;

        // Control dimensions for consistent layout - INCREASED SIZES
        private const int LabelWidth = 150;      // Increased from 120
        private const int FieldWidth = 350;      // Increased from 300
        private const int FieldHeight = 35;      // Increased from 30
        private const int Spacing = 20;          // Increased from 15
        private const int RowHeight = 55;         // Increased from 45

        private bool isTransitioning = false;
        private bool isResetting = false;

        public SIGNUP()
        {
            // Start with opacity 0 for fade-in
            this.Opacity = 0;

            InitializeComponent();
            SetupForm();
            this.Disposed += (s, e) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Environment.Exit(0);
                }
            };
        }

        private void SetupForm()
        {
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

            // Configure title - Centered
            lblSignup.Text = "CREATE ADMIN ACCOUNT";
            lblSignup.Font = new Font("Impact", 52F, FontStyle.Bold);
            lblSignup.ForeColor = Color.White;
            lblSignup.TextAlign = ContentAlignment.MiddleCenter; // Center aligned
            lblSignup.Size = new Size(900, 100);
            lblSignup.AutoSize = false;

            // Configure warning - Centered
            lblWarning.Text = "⚠️ FIRST TIME SETUP ⚠️";
            lblWarning.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(255, 100, 0);
            lblWarning.TextAlign = ContentAlignment.MiddleCenter; // Center aligned
            lblWarning.Size = new Size(500, 45);
            lblWarning.AutoSize = false;

            this.Load += (s, e) => CenterControls();
            this.Resize += (s, e) => CenterControls();
            this.Shown += (s, e) => FadeIn();

            SetupEventHandlers();
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

        private void OpenFormSmoothly(Form newForm)
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

                    newForm.Opacity = 0;
                    newForm.StartPosition = FormStartPosition.CenterScreen;
                    newForm.Show();
                    this.Close();

                    Timer fadeIn = new Timer();
                    fadeIn.Interval = 15;
                    fadeIn.Tick += (s2, e2) =>
                    {
                        if (newForm.Opacity < 1)
                        {
                            newForm.Opacity += 0.05;
                        }
                        else
                        {
                            fadeIn.Stop();
                            isTransitioning = false;
                        }
                    };
                    fadeIn.Start();
                }
            };
            fadeOut.Start();
        }

        private void SetupEventHandlers()
        {
            // Unsubscribe first to prevent multiple subscriptions
            btnSave.Click -= BtnSave_Click;
            btnSave.Click += BtnSave_Click;

            btnReset.Click -= BtnReset_Click;
            btnReset.Click += BtnReset_Click;

            lblBackToLogin.Click -= LblBackToLogin_Click;
            lblBackToLogin.Click += LblBackToLogin_Click;

            chkShowPassword.CheckedChanged -= chkShowPassword_CheckedChanged;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            // Validation events
            txtFirstName.Leave -= ValidateRequiredField;
            txtFirstName.Leave += ValidateRequiredField;

            txtLastName.Leave -= ValidateRequiredField;
            txtLastName.Leave += ValidateRequiredField;

            txtEmail.Leave -= ValidateEmail;
            txtEmail.Leave += ValidateEmail;

            txtUsername.Leave -= ValidateUsername;
            txtUsername.Leave += ValidateUsername;

            txtPassword.Leave -= ValidatePassword;
            txtPassword.Leave += ValidatePassword;

            txtConfirmPassword.Leave -= ValidateConfirmPassword;
            txtConfirmPassword.Leave += ValidateConfirmPassword;

            // Real-time feedback
            txtConfirmPassword.TextChanged -= txtConfirmPassword_TextChanged;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;

            txtLastName.TextChanged -= txtLastName_TextChanged;
            txtLastName.TextChanged += txtLastName_TextChanged;
        }

        private void CenterControls()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Calculate center positions
            int centerX = formWidth / 2;
            int panelWidth = LabelWidth + FieldWidth + Spacing;
            int leftColX = centerX - panelWidth / 2;
            int rightColX = leftColX + LabelWidth + Spacing;

            // TITLE - Centered on the form
            int titleY = 100;
            lblSignup.Location = new Point(centerX - lblSignup.Width / 2, titleY);

            // WARNING - Centered directly under title
            lblWarning.Location = new Point(centerX - lblWarning.Width / 2, lblSignup.Bottom + 5);

            // Calculate starting Y for form fields - MOVED DOWN
            int totalRows = 6;
            int totalFormHeight = totalRows * RowHeight + 250;
            int startY = (formHeight - totalFormHeight) / 2 + 120;

            int currentY = startY;

            // First Name Row
            lblFirstName.Location = new Point(leftColX, currentY);
            lblFirstName.Font = new Font("Lato", 14F, FontStyle.Bold);
            txtFirstName.Location = new Point(rightColX, currentY);
            txtFirstName.Font = new Font("Lato", 14F, FontStyle.Regular);
            txtFirstName.Size = new Size(FieldWidth, FieldHeight);
            currentY += RowHeight;

            // Last Name Row
            lblLastName.Location = new Point(leftColX, currentY);
            lblLastName.Font = new Font("Lato", 14F, FontStyle.Bold);
            txtLastName.Location = new Point(rightColX, currentY);
            txtLastName.Font = new Font("Lato", 14F, FontStyle.Regular);
            txtLastName.Size = new Size(FieldWidth, FieldHeight);
            currentY += RowHeight;

            // Email Row
            lblEmail.Location = new Point(leftColX, currentY);
            lblEmail.Font = new Font("Lato", 14F, FontStyle.Bold);
            txtEmail.Location = new Point(rightColX, currentY);
            txtEmail.Font = new Font("Lato", 14F, FontStyle.Regular);
            txtEmail.Size = new Size(FieldWidth, FieldHeight);
            currentY += RowHeight;

            // Username Row
            lblUsername.Location = new Point(leftColX, currentY);
            lblUsername.Font = new Font("Lato", 14F, FontStyle.Bold);
            txtUsername.Location = new Point(rightColX, currentY);
            txtUsername.Font = new Font("Lato", 14F, FontStyle.Regular);
            txtUsername.Size = new Size(FieldWidth, FieldHeight);
            currentY += RowHeight;

            // Password Row
            lblPassword.Location = new Point(leftColX, currentY);
            lblPassword.Font = new Font("Lato", 14F, FontStyle.Bold);
            txtPassword.Location = new Point(rightColX, currentY);
            txtPassword.Font = new Font("Lato", 14F, FontStyle.Regular);
            txtPassword.Size = new Size(FieldWidth, FieldHeight);
            currentY += RowHeight;

            // Confirm Password Row
            lblConfirmPassword.Location = new Point(leftColX, currentY);
            lblConfirmPassword.Font = new Font("Lato", 14F, FontStyle.Bold);
            txtConfirmPassword.Location = new Point(rightColX, currentY);
            txtConfirmPassword.Font = new Font("Lato", 14F, FontStyle.Regular);
            txtConfirmPassword.Size = new Size(FieldWidth, FieldHeight);
            currentY += RowHeight;

            // Show Password checkbox
            chkShowPassword.Location = new Point(rightColX, currentY);
            chkShowPassword.Font = new Font("Lato", 12F, FontStyle.Regular);
            currentY += RowHeight - 10;

            // Buttons
            int buttonWidth = 180;
            int buttonHeight = 55;
            int buttonSpacing = 30;
            int totalButtonsWidth = buttonWidth * 2 + buttonSpacing;
            int buttonStartX = centerX - totalButtonsWidth / 2;

            btnSave.Location = new Point(buttonStartX, currentY);
            btnSave.Size = new Size(buttonWidth, buttonHeight);
            btnSave.Font = new Font("Lato", 16F, FontStyle.Bold);

            btnReset.Location = new Point(buttonStartX + buttonWidth + buttonSpacing, currentY);
            btnReset.Size = new Size(buttonWidth, buttonHeight);
            btnReset.Font = new Font("Lato", 16F, FontStyle.Bold);
            currentY += 70;

            // Back to Login link
            lblBackToLogin.Location = new Point(centerX - lblBackToLogin.Width / 2, currentY);
            lblBackToLogin.Font = new Font("Lato", 14F, FontStyle.Underline);
        }

        // Rest of your methods remain the same...
        // (All validation methods, database methods, etc. remain unchanged)

        private void ValidateRequiredField(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    errorProvider.SetError(textBox, "This field is required");
                    textBox.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                    textBox.BackColor = Color.White;
                }
            }
        }

        private void ValidateEmail(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    errorProvider.SetError(txtEmail, "Please enter a valid email address");
                    txtEmail.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    errorProvider.SetError(txtEmail, "");
                    txtEmail.BackColor = Color.White;
                }
            }
        }

        private void ValidateUsername(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                if (txtUsername.Text.Length < 4)
                {
                    errorProvider.SetError(txtUsername, "Username must be at least 4 characters");
                    txtUsername.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    errorProvider.SetError(txtUsername, "");
                    txtUsername.BackColor = Color.White;
                }
            }
        }

        private void ValidatePassword(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (txtPassword.Text.Length < 6)
                {
                    errorProvider.SetError(txtPassword, "Password must be at least 6 characters");
                    txtPassword.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    errorProvider.SetError(txtPassword, "");
                    txtPassword.BackColor = Color.White;
                }
            }
        }

        private void ValidateConfirmPassword(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    errorProvider.SetError(txtConfirmPassword, "Passwords do not match");
                    txtConfirmPassword.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    errorProvider.SetError(txtConfirmPassword, "");
                    txtConfirmPassword.BackColor = Color.FromArgb(200, 255, 200);
                }
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length > 0)
            {
                string text = txtLastName.Text;
                string capitalized = char.ToUpper(text[0]) + (text.Length > 1 ? text.Substring(1).ToLower() : "");
                if (text != capitalized)
                {
                    int selectionStart = txtLastName.SelectionStart;
                    txtLastName.Text = capitalized;
                    txtLastName.SelectionStart = selectionStart > 0 ? selectionStart : 1;
                }
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                if (txtConfirmPassword.Text != txtPassword.Text)
                {
                    txtConfirmPassword.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    txtConfirmPassword.BackColor = Color.FromArgb(200, 255, 200);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
            txtConfirmPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
                return;

            bool messageShown = false;

            // Check if email already exists
            bool emailExists = await CheckEmailExists(txtEmail.Text);
            if (emailExists)
            {
                errorProvider.SetError(txtEmail, "Email already registered");
                txtEmail.BackColor = Color.FromArgb(255, 200, 200);

                if (!messageShown)
                {
                    MessageBox.Show("An account with this email already exists. Please use a different email or login.",
                        "Email Already Registered",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    messageShown = true;
                }
                return;
            }

            // Check if username already exists
            bool usernameExists = await CheckUsernameExists(txtUsername.Text);
            if (usernameExists)
            {
                errorProvider.SetError(txtUsername, "Username already taken");
                txtUsername.BackColor = Color.FromArgb(255, 200, 200);

                if (!messageShown)
                {
                    MessageBox.Show("This username is already taken. Please choose a different username.",
                        "Username Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    messageShown = true;
                }
                return;
            }

            // If both checks pass, create the account
            bool success = await CreateNewAdmin();

            if (success)
            {
                MessageBox.Show("Account created successfully! You can now log in.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await Task.Delay(500);

                foreach (Form f in Application.OpenForms)
                {
                    if (f is LOGIN)
                    {
                        f.Show();
                        this.Close(); // This will trigger BaseForm closing and exit app
                        return;
                    }
                }
            }
        }

        private void LblBackToLogin_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is LOGIN)
                {
                    f.Show();
                    this.Close(); // This will trigger BaseForm closing and exit app
                    return;
                }
            }
        }

        private bool ValidateAllFields()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "First name is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Last name is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email is required");
                isValid = false;
            }
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                errorProvider.SetError(txtEmail, "Valid email is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Username is required");
                isValid = false;
            }
            else if (txtUsername.Text.Length < 4)
            {
                errorProvider.SetError(txtUsername, "Username must be at least 4 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 6)
            {
                errorProvider.SetError(txtPassword, "Password must be at least 6 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider.SetError(txtConfirmPassword, "Please confirm your password");
                isValid = false;
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider.SetError(txtConfirmPassword, "Passwords do not match");
                isValid = false;
            }

            return isValid;
        }

        private async Task<bool> CheckEmailExists(string email)
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
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> CheckUsernameExists(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
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

        private async Task<bool> CreateNewAdmin()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"INSERT INTO Admins (FirstName, LastName, Email, Username, PasswordHash, Role, IsActive) 
                            VALUES (@FirstName, @LastName, @Email, @Username, @Password, 'Admin', 1)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        int result = await cmd.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            // Set flag that first account was created
                            Program.FirstAccountCreated = true;
                        }

                        return result > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    if (ex.Message.Contains("Username"))
                    {
                        MessageBox.Show("This username is already taken.",
                            "Username Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (ex.Message.Contains("Email"))
                    {
                        MessageBox.Show("An account with this email already exists.",
                            "Email Already Registered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            if (isResetting) return;
            isResetting = true;

            DialogResult result = MessageBox.Show("Reset all fields?",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                txtFirstName.Clear();
                txtLastName.Clear();
                txtEmail.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                errorProvider.Clear();

                txtFirstName.BackColor = Color.White;
                txtLastName.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtUsername.BackColor = Color.White;
                txtPassword.BackColor = Color.White;
                txtConfirmPassword.BackColor = Color.White;

                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
                chkShowPassword.Checked = false;
            }

            isResetting = false;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = ClientRectangle;

            if (_backgroundImage != null)
            {
                float ratio = Math.Max((float)rect.Width / _backgroundImage.Width,
                                      (float)rect.Height / _backgroundImage.Height);
                int drawW = (int)(_backgroundImage.Width * ratio);
                int drawH = (int)(_backgroundImage.Height * ratio);
                int drawX = (rect.Width - drawW) / 2;
                int drawY = (rect.Height - drawH) / 2;
                g.DrawImage(_backgroundImage, new Rectangle(drawX, drawY, drawW, drawH));
            }

            // DARKER OVERLAY - matches login page
            using (var overlay = new SolidBrush(Color.FromArgb(OverlayAlpha, 0, 0, 0)))
                g.FillRectangle(overlay, rect);

            // Vignette effect - darker edges
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

            // Gradient overlay
            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(GradientAlpha, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), 90f))
                g.FillRectangle(lg, rect);
        }
    }
}