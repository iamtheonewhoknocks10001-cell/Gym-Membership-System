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
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblQuote = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblMembershipType = new System.Windows.Forms.Label();
            this.cmbMembershipType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // FORM BACKGROUND
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            // Background image handled in OnPaintBackground

            // ============================================
            // LOGO - ORANGE like the quote!
            // ============================================
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Impact", 58F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);  // CHANGED to orange!
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Text = "FITWARE";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // Position set dynamically in CenterControls()

            // ============================================
            // QUOTE - Orange
            // ============================================
            this.lblQuote.BackColor = System.Drawing.Color.Transparent;
            this.lblQuote.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblQuote.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Text = "\"WHERE MUSCLE MEETS TECHNOLOGY\"";
            this.lblQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQuote.Click += new System.EventHandler(this.LblQuote_Click);
            // Position set dynamically in CenterControls()

            // ============================================
            // FORM FIELDS - Tighter spacing
            // ============================================

            // First Name - Label
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Size = new System.Drawing.Size(400, 25);
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Position set dynamically in CenterControls()

            // First Name - TextBox
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Size = new System.Drawing.Size(400, 29);
            this.txtFirstName.PlaceholderText = "Enter first name";
            // Position set dynamically in CenterControls()

            // Last Name - Label
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Size = new System.Drawing.Size(400, 25);
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Position set dynamically in CenterControls()

            // Last Name - TextBox
            this.txtLastName.BackColor = System.Drawing.Color.White;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Size = new System.Drawing.Size(400, 29);
            this.txtLastName.PlaceholderText = "Enter last name";
            // Position set dynamically in CenterControls()

            // Email - Label
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Size = new System.Drawing.Size(400, 25);
            this.lblEmail.Text = "Email Address";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Position set dynamically in CenterControls()

            // Email - TextBox
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Size = new System.Drawing.Size(400, 29);
            this.txtEmail.PlaceholderText = "member@example.com";
            // Position set dynamically in CenterControls()

            // Phone - Label
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Size = new System.Drawing.Size(400, 25);
            this.lblPhone.Text = "Phone Number";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Position set dynamically in CenterControls()

            // Phone - TextBox
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Size = new System.Drawing.Size(400, 29);
            this.txtPhone.PlaceholderText = "(555) 123-4567";
            // Position set dynamically in CenterControls()

            // Membership Type - Label
            this.lblMembershipType.BackColor = System.Drawing.Color.Transparent;
            this.lblMembershipType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMembershipType.ForeColor = System.Drawing.Color.White;
            this.lblMembershipType.Size = new System.Drawing.Size(400, 25);
            this.lblMembershipType.Text = "Membership Type";
            this.lblMembershipType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // Position set dynamically in CenterControls()

            // Membership Type - ComboBox
            this.cmbMembershipType.BackColor = System.Drawing.Color.White;
            this.cmbMembershipType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMembershipType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbMembershipType.ForeColor = System.Drawing.Color.Black;
            this.cmbMembershipType.Items.AddRange(new object[] { "Basic", "Premium" });
            this.cmbMembershipType.Size = new System.Drawing.Size(400, 29);
            this.cmbMembershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembershipType.SelectedIndex = 0;
            // Position set dynamically in CenterControls()

            // ADD Button
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Size = new System.Drawing.Size(180, 50);
            this.btnAdd.Text = "ADD MEMBER";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // Position set dynamically in CenterControls()

            // CLEAR Button
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Size = new System.Drawing.Size(180, 50);
            this.btnClear.Text = "CLEAR";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // Position set dynamically in CenterControls()

            // BACK Button
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Size = new System.Drawing.Size(140, 45);
            this.btnBack.Text = "← BACK";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // Position set dynamically in CenterControls()

            // Add all controls to the form
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblQuote);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblMembershipType);
            this.Controls.Add(this.cmbMembershipType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);

            // AddMember
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 821);
            this.Name = "AddMember";
            this.Text = "Add Member - FitWare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
    }
}