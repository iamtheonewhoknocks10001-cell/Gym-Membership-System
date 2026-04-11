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
            // 
            // lblLogin
            // 
            lblLogin.Location = new Point(0, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(100, 23);
            lblLogin.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(629, 360);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(457, 40);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email Address";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(629, 400);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "admin@gym.com";
            txtEmail.Size = new Size(457, 34);
            txtEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(629, 453);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(457, 40);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(629, 493);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(457, 34);
            txtPassword.TabIndex = 6;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 100, 0);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Impact", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(629, 593);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(457, 67);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.BackColor = Color.Transparent;
            chkShowPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.ForeColor = Color.FromArgb(255, 150, 0);
            chkShowPassword.Location = new Point(629, 540);
            chkShowPassword.Margin = new Padding(3, 4, 3, 4);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(171, 33);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = false;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // lblError
            // 
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(629, 293);
            lblError.Name = "lblError";
            lblError.Size = new Size(457, 47);
            lblError.TabIndex = 2;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Impact", 58F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1371, 173);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WELCOME TO FITWARE";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.FromArgb(76, 175, 80);
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Impact", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.Location = new Point(629, 673);
            btnCreateAccount.Margin = new Padding(3, 4, 3, 4);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(457, 47);
            btnCreateAccount.TabIndex = 9;
            btnCreateAccount.Text = "CREATE FIRST ADMIN ACCOUNT";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // lblQuote
            // 
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Cursor = Cursors.Hand;
            lblQuote.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuote.ForeColor = Color.FromArgb(255, 100, 0);
            lblQuote.Location = new Point(0, 173);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new Size(1143, 93);
            lblQuote.TabIndex = 1;
            lblQuote.Text = "\"WHERE MUSCLE MEETS TECHNOLOGY\"";
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.Click += lblQuote_Click;
            // 
            // lblForgotPassword
            // 
            lblForgotPassword.BackColor = Color.Transparent;
            lblForgotPassword.Cursor = Cursors.Hand;
            lblForgotPassword.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblForgotPassword.ForeColor = Color.FromArgb(255, 150, 0);
            lblForgotPassword.Location = new Point(629, 727);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(457, 33);
            lblForgotPassword.TabIndex = 10;
            lblForgotPassword.Text = "Forgot Password?";
            lblForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            lblForgotPassword.Visible = false;
            lblForgotPassword.Click += lblForgotPassword_Click;
            // 
            // LOGIN
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginbg;
            ClientSize = new Size(1731, 1095);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "LOGIN";
            Text = "Admin Login";
            WindowState = FormWindowState.Maximized;
            Load += LOGIN_Load;
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