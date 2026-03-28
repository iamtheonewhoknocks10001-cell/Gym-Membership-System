namespace Gym_Membership_System
{
    partial class LOGIN
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
            lblLogin = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            chkShowPassword = new CheckBox();
            lblError = new Label();
            lblTitle = new Label();
            btnCreateAccount = new Button();
            lblQuote = new Label();
            lblForgotPassword = new Label();
            SuspendLayout();

            // lblTitle
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Impact", 58F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1200, 130);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WELCOME TO FITWARE";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblQuote
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuote.ForeColor = Color.FromArgb(255, 100, 0);
            lblQuote.Location = new Point(0, 130);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new Size(1000, 70);
            lblQuote.TabIndex = 1;
            lblQuote.Text = "\"WHERE MUSCLE MEETS TECHNOLOGY\"";
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.Cursor = Cursors.Hand;
            lblQuote.Click += lblQuote_Click;

            // lblError
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(550, 220);
            lblError.Name = "lblError";
            lblError.Size = new Size(400, 35);
            lblError.TabIndex = 2;
            lblError.TextAlign = ContentAlignment.MiddleCenter;

            // lblEmail
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(550, 270);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(400, 30);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email Address";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;

            // txtEmail
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(550, 300);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "admin@gym.com";
            txtEmail.Size = new Size(400, 29);
            txtEmail.TabIndex = 4;

            // lblPassword
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(550, 340);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(400, 30);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;

            // txtPassword
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(550, 370);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(400, 29);
            txtPassword.TabIndex = 6;

            // chkShowPassword
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.FromArgb(255, 150, 0);
            chkShowPassword.Location = new Point(550, 405);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(150, 25);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            // btnLogin - ONLY FONT CHANGED
            btnLogin.BackColor = Color.FromArgb(255, 100, 0);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0); // Changed from Impact 16F
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(550, 445);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += btnLogin_Click;

            // btnCreateAccount
            btnCreateAccount.BackColor = Color.FromArgb(76, 175, 80);
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(550, 505);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(400, 35);
            btnCreateAccount.TabIndex = 9;
            btnCreateAccount.Text = "CREATE FIRST ADMIN ACCOUNT";  // This is for first-time setup
            btnCreateAccount.TextAlign = ContentAlignment.MiddleCenter;
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.Click += btnCreateAccount_Click;

            // lblForgotPassword
            lblForgotPassword.BackColor = Color.Transparent;
            lblForgotPassword.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblForgotPassword.ForeColor = Color.FromArgb(255, 150, 0);
            lblForgotPassword.Location = new Point(550, 545);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(400, 25);
            lblForgotPassword.TabIndex = 10;
            lblForgotPassword.Text = "Forgot Password?";
            lblForgotPassword.Text = "Forgot Password?";
            lblForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            lblForgotPassword.Cursor = Cursors.Hand;
            lblForgotPassword.Visible = false;
            lblForgotPassword.Click += lblForgotPassword_Click;

            // LOGIN
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginbg;
            ClientSize = new Size(1515, 821);
            Controls.Add(lblForgotPassword);
            Controls.Add(btnCreateAccount);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblError);
            Controls.Add(lblQuote);
            Controls.Add(lblTitle);
            Name = "LOGIN";
            Text = "Admin Login";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblLogin;
        private Label lblError;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Button btnLogin;
        private Label lblTitle;
        private Button btnCreateAccount;
        private Label lblQuote;
        private Label lblForgotPassword;
    }

}