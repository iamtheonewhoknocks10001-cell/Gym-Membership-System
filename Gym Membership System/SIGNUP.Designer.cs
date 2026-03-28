using System.ComponentModel;

namespace Gym_Membership_System
{
    partial class SIGNUP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            lblSignup = new Label();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSave = new Button();
            btnReset = new Button();
            lblBackToLogin = new Label();
            lblWarning = new Label();
            chkShowPassword = new CheckBox();
            errorProvider = new ErrorProvider(components);
            ((ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();

            // lblSignup - Title
            lblSignup.BackColor = Color.Transparent;
            lblSignup.Font = new Font("Impact", 52F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.ForeColor = Color.White;
            lblSignup.Location = new Point(0, 0);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(800, 100);
            lblSignup.TabIndex = 0;
            lblSignup.Text = "CREATE ADMIN ACCOUNT";
            lblSignup.TextAlign = ContentAlignment.MiddleCenter;

            // lblWarning - Warning message
            lblWarning.BackColor = Color.Transparent;
            lblWarning.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWarning.ForeColor = Color.FromArgb(255, 100, 0);
            lblWarning.Location = new Point(0, 0);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(400, 40);
            lblWarning.TabIndex = 25;
            lblWarning.Text = "⚠️ FIRST TIME SETUP ⚠️";
            lblWarning.TextAlign = ContentAlignment.MiddleCenter;

            // lblFirstName
            lblFirstName.BackColor = Color.Transparent;
            lblFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(300, 200);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(120, 25);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "First Name *";
            lblFirstName.TextAlign = ContentAlignment.MiddleRight;

            // txtFirstName
            txtFirstName.BackColor = Color.White;
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Location = new Point(430, 200);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Enter first name";
            txtFirstName.Size = new Size(250, 29);
            txtFirstName.TabIndex = 2;

            // lblLastName
            lblLastName.BackColor = Color.Transparent;
            lblLastName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(300, 250);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(120, 25);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Last Name *";
            lblLastName.TextAlign = ContentAlignment.MiddleRight;

            // txtLastName
            txtLastName.BackColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            txtLastName.ForeColor = Color.Black;
            txtLastName.Location = new Point(430, 250);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Enter last name";
            txtLastName.Size = new Size(250, 29);
            txtLastName.TabIndex = 4;
            txtLastName.TextChanged += txtLastName_TextChanged;

            // lblEmail
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(300, 300);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(120, 25);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email *";
            lblEmail.TextAlign = ContentAlignment.MiddleRight;

            // txtEmail
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(430, 300);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "admin@gym.com";
            txtEmail.Size = new Size(250, 29);
            txtEmail.TabIndex = 6;

            // lblUsername
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(300, 350);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(120, 25);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Username *";
            lblUsername.TextAlign = ContentAlignment.MiddleRight;

            // txtUsername
            txtUsername.BackColor = Color.White;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(430, 350);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Choose username";
            txtUsername.Size = new Size(250, 29);
            txtUsername.TabIndex = 8;

            // lblPassword
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(300, 400);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(120, 25);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password *";
            lblPassword.TextAlign = ContentAlignment.MiddleRight;

            // txtPassword
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(430, 400);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter password";
            txtPassword.Size = new Size(250, 29);
            txtPassword.TabIndex = 10;

            // lblConfirmPassword
            lblConfirmPassword.BackColor = Color.Transparent;
            lblConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Location = new Point(300, 450);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(120, 25);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Confirm *";
            lblConfirmPassword.TextAlign = ContentAlignment.MiddleRight;

            // txtConfirmPassword
            txtConfirmPassword.BackColor = Color.White;
            txtConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            txtConfirmPassword.ForeColor = Color.Black;
            txtConfirmPassword.Location = new Point(430, 450);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.PlaceholderText = "Confirm password";
            txtConfirmPassword.Size = new Size(250, 29);
            txtConfirmPassword.TabIndex = 12;
            txtConfirmPassword.TextChanged += txtConfirmPassword_TextChanged;

            // chkShowPassword
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0); // Changed from Lato
            chkShowPassword.ForeColor = Color.FromArgb(255, 200, 0);
            chkShowPassword.Location = new Point(430, 490);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(150, 25);
            chkShowPassword.TabIndex = 15;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            // btnSave - ONLY FONT CHANGED
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato 14F
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(350, 560);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 50);
            btnSave.TabIndex = 16;
            btnSave.Text = "CREATE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            btnSave.Click += BtnSave_Click;

            // btnReset - ONLY FONT CHANGED
            btnReset.BackColor = Color.FromArgb(220, 53, 69);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Lato 14F
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(550, 560);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(150, 50);
            btnReset.TabIndex = 17;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btnReset.Click += BtnReset_Click;

            // lblBackToLogin
            lblBackToLogin.BackColor = Color.Transparent;
            lblBackToLogin.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point, 0); // Changed from Lato
            lblBackToLogin.ForeColor = Color.FromArgb(255, 200, 0);
            lblBackToLogin.Location = new Point(425, 630);
            lblBackToLogin.Name = "lblBackToLogin";
            lblBackToLogin.Size = new Size(200, 25);
            lblBackToLogin.TabIndex = 18;
            lblBackToLogin.Text = "← Back to Login";
            lblBackToLogin.TextAlign = ContentAlignment.MiddleCenter;
            lblBackToLogin.Cursor = Cursors.Hand;
            lblBackToLogin.Click += LblBackToLogin_Click;

            // errorProvider
            errorProvider.ContainerControl = this;

            // SIGNUP
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.signupbg1;
            ClientSize = new Size(1515, 821);
            Controls.Add(lblBackToLogin);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(chkShowPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(lblWarning);
            Controls.Add(lblSignup);
            Name = "SIGNUP";
            Text = "Admin Signup";
            WindowState = FormWindowState.Maximized;
            ((ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblSignup;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnReset;
        private Label lblBackToLogin;
        private Label lblWarning;
        private CheckBox chkShowPassword;
        private ErrorProvider errorProvider;
    }
}