namespace Gym_Membership_System
{
    partial class AddMember
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblLogo = new Label();
            lblQuote = new Label();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblMembershipType = new Label();
            cmbMembershipType = new ComboBox();
            btnNext = new Button();  // Changed from btnAdd to btnNext
            btnClear = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Impact", 58F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(255, 100, 0);
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(114, 31);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "FITWARE";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblQuote
            // 
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Cursor = Cursors.Hand;
            lblQuote.Font = new Font("Calibri", 16F, FontStyle.Bold);
            lblQuote.ForeColor = Color.FromArgb(255, 100, 0);
            lblQuote.Location = new Point(0, 0);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new Size(114, 31);
            lblQuote.TabIndex = 1;
            lblQuote.Text = "\"WHERE MUSCLE MEETS TECHNOLOGY\"";
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            lblQuote.Click += LblQuote_Click;
            // 
            // lblFirstName
            // 
            lblFirstName.BackColor = Color.Transparent;
            lblFirstName.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(0, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(457, 33);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "First Name";
            lblFirstName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.White;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Calibri", 12F);
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Location = new Point(0, 0);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Enter first name";
            txtFirstName.Size = new Size(457, 34);
            txtFirstName.TabIndex = 3;
            // 
            // lblLastName
            // 
            lblLastName.BackColor = Color.Transparent;
            lblLastName.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(0, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(457, 33);
            lblLastName.TabIndex = 4;
            lblLastName.Text = "Last Name";
            lblLastName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.White;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Calibri", 12F);
            txtLastName.ForeColor = Color.Black;
            txtLastName.Location = new Point(0, 0);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Enter last name";
            txtLastName.Size = new Size(457, 34);
            txtLastName.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(457, 33);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email Address";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Calibri", 12F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(0, 0);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "member@example.com";
            txtEmail.Size = new Size(457, 34);
            txtEmail.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.BackColor = Color.Transparent;
            lblPhone.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblPhone.ForeColor = Color.White;
            lblPhone.Location = new Point(0, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(457, 33);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Phone Number";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.White;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Calibri", 12F);
            txtPhone.ForeColor = Color.Black;
            txtPhone.Location = new Point(0, 0);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "(555) 123-4567";
            txtPhone.Size = new Size(457, 34);
            txtPhone.TabIndex = 9;
            // 
            // lblMembershipType
            // 
            lblMembershipType.BackColor = Color.Transparent;
            lblMembershipType.Font = new Font("Calibri", 12F, FontStyle.Bold);
            lblMembershipType.ForeColor = Color.White;
            lblMembershipType.Location = new Point(0, 0);
            lblMembershipType.Name = "lblMembershipType";
            lblMembershipType.Size = new Size(457, 33);
            lblMembershipType.TabIndex = 10;
            lblMembershipType.Text = "Membership Type";
            lblMembershipType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbMembershipType
            // 
            cmbMembershipType.BackColor = Color.White;
            cmbMembershipType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMembershipType.FlatStyle = FlatStyle.Flat;
            cmbMembershipType.Font = new Font("Calibri", 12F);
            cmbMembershipType.ForeColor = Color.Black;
            cmbMembershipType.Items.AddRange(new object[] { "Basic", "Premium" });
            cmbMembershipType.Location = new Point(0, 0);
            cmbMembershipType.Margin = new Padding(3, 4, 3, 4);
            cmbMembershipType.Name = "cmbMembershipType";
            cmbMembershipType.Size = new Size(457, 36);
            cmbMembershipType.TabIndex = 11;
            // 
            // btnNext - Changed from btnAdd to btnNext
            // 
            btnNext.BackColor = Color.FromArgb(255, 100, 0);
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Calibri", 16F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(0, 0);
            btnNext.Margin = new Padding(3, 4, 3, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(206, 67);
            btnNext.TabIndex = 12;
            btnNext.Text = "NEXT →";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += BtnNext_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 100, 100);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Calibri", 16F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(0, 0);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(206, 67);
            btnClear.TabIndex = 13;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(100, 100, 100);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Calibri", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(0, 0);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(160, 60);
            btnBack.TabIndex = 14;
            btnBack.Text = "← BACK";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // AddMember
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 35);
            ClientSize = new Size(1731, 1095);
            Controls.Add(lblLogo);
            Controls.Add(lblQuote);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblMembershipType);
            Controls.Add(cmbMembershipType);
            Controls.Add(btnNext);
            Controls.Add(btnClear);
            Controls.Add(btnBack);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddMember";
            Text = "Add Member - FitWare";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblQuote;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblMembershipType;
        private System.Windows.Forms.ComboBox cmbMembershipType;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
    }
}