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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblMembershipType = new System.Windows.Forms.Label();
            this.cmbMembershipType = new System.Windows.Forms.ComboBox();
            this.priceInfoPanel = new System.Windows.Forms.Panel();
            this.lblPriceInfo = new System.Windows.Forms.Label();
            this.lblPaymentPeriod = new System.Windows.Forms.Label();
            this.cmbPaymentPeriod = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblCalculatedAmount = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblTransactionRef = new System.Windows.Forms.Label();
            this.txtTransactionRef = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.priceInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "💰 New Payment Record";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(350, 40);
            this.lblTitle.Name = "lblTitle";

            // lblMember
            this.lblMember.Text = "Select Member:";
            this.lblMember.Location = new System.Drawing.Point(20, 80);
            this.lblMember.Size = new System.Drawing.Size(150, 25);
            this.lblMember.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMember.Name = "lblMember";

            // cmbMember
            this.cmbMember.Location = new System.Drawing.Point(180, 78);
            this.cmbMember.Size = new System.Drawing.Size(330, 30);
            this.cmbMember.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMember.Name = "cmbMember";

            // lblMembershipType
            this.lblMembershipType.Text = "Membership Type:";
            this.lblMembershipType.Location = new System.Drawing.Point(20, 120);
            this.lblMembershipType.Size = new System.Drawing.Size(150, 25);
            this.lblMembershipType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMembershipType.Name = "lblMembershipType";

            // cmbMembershipType
            this.cmbMembershipType.Location = new System.Drawing.Point(180, 118);
            this.cmbMembershipType.Size = new System.Drawing.Size(200, 30);
            this.cmbMembershipType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMembershipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembershipType.Items.AddRange(new object[] { "BASIC", "PREMIUM" });
            this.cmbMembershipType.Name = "cmbMembershipType";

            // priceInfoPanel
            this.priceInfoPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.priceInfoPanel.Location = new System.Drawing.Point(20, 160);
            this.priceInfoPanel.Size = new System.Drawing.Size(490, 70);
            this.priceInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceInfoPanel.Name = "priceInfoPanel";

            // lblPriceInfo
            this.lblPriceInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblPriceInfo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblPriceInfo.Location = new System.Drawing.Point(10, 8);
            this.lblPriceInfo.Size = new System.Drawing.Size(470, 55);
            this.lblPriceInfo.Text = "📋 PRICING (35 PHP/day):\n• BASIC: Monthly ₱1,050 | Quarterly ₱3,150 | Annual ₱12,775\n• PREMIUM: Monthly ₱1,400 | Quarterly ₱4,000 | Annual ₱15,000";
            this.lblPriceInfo.Name = "lblPriceInfo";
            this.priceInfoPanel.Controls.Add(this.lblPriceInfo);

            // lblPaymentPeriod
            this.lblPaymentPeriod.Text = "Payment Period:";
            this.lblPaymentPeriod.Location = new System.Drawing.Point(20, 250);
            this.lblPaymentPeriod.Size = new System.Drawing.Size(150, 25);
            this.lblPaymentPeriod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentPeriod.Name = "lblPaymentPeriod";

            // cmbPaymentPeriod
            this.cmbPaymentPeriod.Location = new System.Drawing.Point(180, 248);
            this.cmbPaymentPeriod.Size = new System.Drawing.Size(200, 30);
            this.cmbPaymentPeriod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaymentPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentPeriod.Items.AddRange(new object[] { "Monthly", "Quarterly", "Annual" });
            this.cmbPaymentPeriod.Name = "cmbPaymentPeriod";

            // lblAmount
            this.lblAmount.Text = "Amount:";
            this.lblAmount.Location = new System.Drawing.Point(20, 290);
            this.lblAmount.Size = new System.Drawing.Size(150, 25);
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAmount.Name = "lblAmount";

            // nudAmount
            this.nudAmount.Location = new System.Drawing.Point(180, 288);
            this.nudAmount.Size = new System.Drawing.Size(150, 30);
            this.nudAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Minimum = 0;
            this.nudAmount.Maximum = 50000;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.Enabled = false;
            this.nudAmount.Name = "nudAmount";

            // lblCalculatedAmount
            this.lblCalculatedAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCalculatedAmount.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblCalculatedAmount.Location = new System.Drawing.Point(350, 288);
            this.lblCalculatedAmount.Size = new System.Drawing.Size(160, 30);
            this.lblCalculatedAmount.Text = "";
            this.lblCalculatedAmount.Name = "lblCalculatedAmount";

            // lblPaymentMethod
            this.lblPaymentMethod.Text = "Payment Method:";
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 330);
            this.lblPaymentMethod.Size = new System.Drawing.Size(150, 25);
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentMethod.Name = "lblPaymentMethod";

            // cmbPaymentMethod
            this.cmbPaymentMethod.Location = new System.Drawing.Point(180, 328);
            this.cmbPaymentMethod.Size = new System.Drawing.Size(200, 30);
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "GCash" });
            this.cmbPaymentMethod.SelectedIndex = 0;
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";

            // lblPaymentDate
            this.lblPaymentDate.Text = "Payment Date:";
            this.lblPaymentDate.Location = new System.Drawing.Point(20, 370);
            this.lblPaymentDate.Size = new System.Drawing.Size(150, 25);
            this.lblPaymentDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentDate.Name = "lblPaymentDate";

            // dtpPaymentDate
            this.dtpPaymentDate.Location = new System.Drawing.Point(180, 368);
            this.dtpPaymentDate.Size = new System.Drawing.Size(200, 30);
            this.dtpPaymentDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpPaymentDate.Value = System.DateTime.Now;
            this.dtpPaymentDate.Name = "dtpPaymentDate";

            // lblDueDate
            this.lblDueDate.Text = "Due Date:";
            this.lblDueDate.Location = new System.Drawing.Point(20, 410);
            this.lblDueDate.Size = new System.Drawing.Size(150, 25);
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDueDate.Name = "lblDueDate";

            // dtpDueDate
            this.dtpDueDate.Location = new System.Drawing.Point(180, 408);
            this.dtpDueDate.Size = new System.Drawing.Size(200, 30);
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDueDate.Value = System.DateTime.Now.AddMonths(1);
            this.dtpDueDate.Name = "dtpDueDate";

            // lblTransactionRef
            this.lblTransactionRef.Text = "Transaction Ref:";
            this.lblTransactionRef.Location = new System.Drawing.Point(20, 450);
            this.lblTransactionRef.Size = new System.Drawing.Size(150, 25);
            this.lblTransactionRef.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTransactionRef.Name = "lblTransactionRef";

            // txtTransactionRef
            this.txtTransactionRef.Location = new System.Drawing.Point(180, 448);
            this.txtTransactionRef.Size = new System.Drawing.Size(330, 30);
            this.txtTransactionRef.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTransactionRef.PlaceholderText = "Optional - GCash reference #";
            this.txtTransactionRef.Name = "txtTransactionRef";

            // lblNotes
            this.lblNotes.Text = "Notes:";
            this.lblNotes.Location = new System.Drawing.Point(20, 490);
            this.lblNotes.Size = new System.Drawing.Size(150, 25);
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNotes.Name = "lblNotes";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(180, 488);
            this.txtNotes.Size = new System.Drawing.Size(330, 25);
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.PlaceholderText = "Optional notes";
            this.txtNotes.Name = "txtNotes";

            // btnSave
            this.btnSave.Text = "💾 Save Payment";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(180, 530);
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(340, 530);
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;

            // AddPaymentForm
            this.Text = "Add New Payment";
            this.Size = new System.Drawing.Size(550, 620);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddPaymentForm";

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.lblMembershipType);
            this.Controls.Add(this.cmbMembershipType);
            this.Controls.Add(this.priceInfoPanel);
            this.Controls.Add(this.lblPaymentPeriod);
            this.Controls.Add(this.cmbPaymentPeriod);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.lblCalculatedAmount);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblPaymentDate);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblTransactionRef);
            this.Controls.Add(this.txtTransactionRef);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            // Resume layouts
            this.priceInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
        }

        // Control declarations
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label lblMembershipType;
        private System.Windows.Forms.ComboBox cmbMembershipType;
        private System.Windows.Forms.Panel priceInfoPanel;
        private System.Windows.Forms.Label lblPriceInfo;
        private System.Windows.Forms.Label lblPaymentPeriod;
        private System.Windows.Forms.ComboBox cmbPaymentPeriod;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblCalculatedAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblTransactionRef;
        private System.Windows.Forms.TextBox txtTransactionRef;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}