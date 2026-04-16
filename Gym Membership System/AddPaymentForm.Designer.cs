namespace Gym_Membership_System
{
    partial class AddPaymentForm
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
            lblTitle = new Label();
            lblMember = new Label();
            cmbMember = new ComboBox();
            lblMembershipType = new Label();
            cmbMembershipType = new ComboBox();
            lblPaymentPeriod = new Label();
            cmbPaymentPeriod = new ComboBox();
            lblAmount = new Label();
            nudAmount = new NumericUpDown();
            lblPaymentMethod = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaymentDate = new Label();
            dtpPaymentDate = new DateTimePicker();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            SuspendLayout();

            // ============================================
            // FORM BACKGROUND
            // ============================================
            this.BackColor = Color.FromArgb(30, 30, 35);
            this.BackgroundImage = null;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.DoubleBuffered = true;
            this.Text = "Add Payment - FitWare";

            // ============================================
            // TITLE
            // ============================================
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Impact", 58F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 100, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1200, 100);
            lblTitle.TabIndex = 30;
            lblTitle.Text = "ADD PAYMENT";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ============================================
            // MEMBER
            // ============================================
            lblMember.BackColor = Color.Transparent;
            lblMember.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMember.ForeColor = Color.FromArgb(220, 220, 230);
            lblMember.Location = new Point(0, 0);
            lblMember.Name = "lblMember";
            lblMember.Size = new Size(180, 35);
            lblMember.TabIndex = 29;
            lblMember.Text = "Member:";
            lblMember.TextAlign = ContentAlignment.MiddleRight;

            cmbMember.BackColor = Color.FromArgb(55, 55, 62);
            cmbMember.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMember.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            cmbMember.ForeColor = Color.FromArgb(220, 220, 230);
            cmbMember.Location = new Point(0, 0);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(400, 38);
            cmbMember.TabIndex = 1;

            // ============================================
            // MEMBERSHIP TYPE
            // ============================================
            lblMembershipType.BackColor = Color.Transparent;
            lblMembershipType.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMembershipType.ForeColor = Color.FromArgb(220, 220, 230);
            lblMembershipType.Location = new Point(0, 0);
            lblMembershipType.Name = "lblMembershipType";
            lblMembershipType.Size = new Size(180, 35);
            lblMembershipType.TabIndex = 28;
            lblMembershipType.Text = "Membership Type:";
            lblMembershipType.TextAlign = ContentAlignment.MiddleRight;

            cmbMembershipType.BackColor = Color.FromArgb(55, 55, 62);
            cmbMembershipType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMembershipType.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            cmbMembershipType.ForeColor = Color.FromArgb(220, 220, 230);
            cmbMembershipType.Location = new Point(0, 0);
            cmbMembershipType.Name = "cmbMembershipType";
            cmbMembershipType.Size = new Size(400, 38);
            cmbMembershipType.TabIndex = 3;

            // ============================================
            // PAYMENT PERIOD
            // ============================================
            lblPaymentPeriod.BackColor = Color.Transparent;
            lblPaymentPeriod.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPaymentPeriod.ForeColor = Color.FromArgb(220, 220, 230);
            lblPaymentPeriod.Location = new Point(0, 0);
            lblPaymentPeriod.Name = "lblPaymentPeriod";
            lblPaymentPeriod.Size = new Size(180, 35);
            lblPaymentPeriod.TabIndex = 27;
            lblPaymentPeriod.Text = "Payment Period:";
            lblPaymentPeriod.TextAlign = ContentAlignment.MiddleRight;

            cmbPaymentPeriod.BackColor = Color.FromArgb(55, 55, 62);
            cmbPaymentPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentPeriod.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            cmbPaymentPeriod.ForeColor = Color.FromArgb(220, 220, 230);
            cmbPaymentPeriod.Items.AddRange(new object[] { "Monthly", "Quarterly", "Annual" });
            cmbPaymentPeriod.Location = new Point(0, 0);
            cmbPaymentPeriod.Name = "cmbPaymentPeriod";
            cmbPaymentPeriod.Size = new Size(400, 38);
            cmbPaymentPeriod.TabIndex = 5;

            // ============================================
            // AMOUNT
            // ============================================
            lblAmount.BackColor = Color.Transparent;
            lblAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(255, 150, 100);
            lblAmount.Location = new Point(0, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(180, 35);
            lblAmount.TabIndex = 26;
            lblAmount.Text = "Amount:";
            lblAmount.TextAlign = ContentAlignment.MiddleRight;

            nudAmount.BackColor = Color.FromArgb(55, 55, 62);
            nudAmount.DecimalPlaces = 2;
            nudAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            nudAmount.ForeColor = Color.FromArgb(255, 180, 80);
            nudAmount.Location = new Point(0, 0);
            nudAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.ReadOnly = true;
            nudAmount.Size = new Size(400, 42);
            nudAmount.TabIndex = 7;
            nudAmount.ThousandsSeparator = true;

            // ============================================
            // PAYMENT METHOD
            // ============================================
            lblPaymentMethod.BackColor = Color.Transparent;
            lblPaymentMethod.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPaymentMethod.ForeColor = Color.FromArgb(220, 220, 230);
            lblPaymentMethod.Location = new Point(0, 0);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(180, 35);
            lblPaymentMethod.TabIndex = 25;
            lblPaymentMethod.Text = "Payment Method:";
            lblPaymentMethod.TextAlign = ContentAlignment.MiddleRight;

            cmbPaymentMethod.BackColor = Color.FromArgb(55, 55, 62);
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            cmbPaymentMethod.ForeColor = Color.FromArgb(220, 220, 230);
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "GCash" });
            cmbPaymentMethod.Location = new Point(0, 0);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(400, 38);
            cmbPaymentMethod.TabIndex = 9;

            // ============================================
            // PAYMENT DATE
            // ============================================
            lblPaymentDate.BackColor = Color.Transparent;
            lblPaymentDate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPaymentDate.ForeColor = Color.FromArgb(220, 220, 230);
            lblPaymentDate.Location = new Point(0, 0);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new Size(180, 35);
            lblPaymentDate.TabIndex = 24;
            lblPaymentDate.Text = "Payment Date:";
            lblPaymentDate.TextAlign = ContentAlignment.MiddleRight;

            dtpPaymentDate.Enabled = false;
            dtpPaymentDate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dtpPaymentDate.ForeColor = Color.FromArgb(220, 220, 230);
            dtpPaymentDate.Location = new Point(0, 0);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(400, 38);
            dtpPaymentDate.TabIndex = 11;
            dtpPaymentDate.Value = DateTime.Now;

            // ============================================
            // DUE DATE
            // ============================================
            lblDueDate.BackColor = Color.Transparent;
            lblDueDate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDueDate.ForeColor = Color.FromArgb(220, 220, 230);
            lblDueDate.Location = new Point(0, 0);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(180, 35);
            lblDueDate.TabIndex = 23;
            lblDueDate.Text = "Due Date:";
            lblDueDate.TextAlign = ContentAlignment.MiddleRight;

            dtpDueDate.Enabled = false;
            dtpDueDate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dtpDueDate.ForeColor = Color.FromArgb(220, 220, 230);
            dtpDueDate.Location = new Point(0, 0);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(400, 38);
            dtpDueDate.TabIndex = 13;

            // ============================================
            // SAVE BUTTON
            // ============================================
            btnSave.BackColor = Color.FromArgb(255, 100, 50);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Calibri", 18F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 50);
            btnSave.TabIndex = 19;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;

            // ============================================
            // CANCEL BUTTON
            // ============================================
            btnCancel.BackColor = Color.FromArgb(80, 80, 90);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Calibri", 18F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 50);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;

            // ============================================
            // BACK BUTTON
            // ============================================
            btnBack.BackColor = Color.FromArgb(80, 80, 90);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(0, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(140, 45);
            btnBack.TabIndex = 21;
            btnBack.Text = "← BACK";
            btnBack.UseVisualStyleBackColor = false;
            // REMOVED: btnBack.Click += (s, e) => this.Close();

            // ============================================
            // ADD ALL CONTROLS
            // ============================================
            this.Controls.Add(btnBack);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnSave);
            this.Controls.Add(dtpDueDate);
            this.Controls.Add(lblDueDate);
            this.Controls.Add(dtpPaymentDate);
            this.Controls.Add(lblPaymentDate);
            this.Controls.Add(cmbPaymentMethod);
            this.Controls.Add(lblPaymentMethod);
            this.Controls.Add(nudAmount);
            this.Controls.Add(lblAmount);
            this.Controls.Add(cmbPaymentPeriod);
            this.Controls.Add(lblPaymentPeriod);
            this.Controls.Add(cmbMembershipType);
            this.Controls.Add(lblMembershipType);
            this.Controls.Add(cmbMember);
            this.Controls.Add(lblMember);
            this.Controls.Add(lblTitle);

            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label lblMembershipType;
        private System.Windows.Forms.ComboBox cmbMembershipType;
        private System.Windows.Forms.Label lblPaymentPeriod;
        private System.Windows.Forms.ComboBox cmbPaymentPeriod;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
    }
}