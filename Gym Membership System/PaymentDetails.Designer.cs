namespace Gym_Membership_System
{
    partial class PaymentDetails
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
            this.panelContainer = new System.Windows.Forms.Panel();

            // Payment ID Section
            this.lblPaymentID = new System.Windows.Forms.Label();
            this.lblPaymentIDValue = new System.Windows.Forms.Label();

            // Payment Status Section
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();

            // Payment Method Section
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblMethodValue = new System.Windows.Forms.Label();

            // Amount Section
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();

            // Due Date Section
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblDueDateValue = new System.Windows.Forms.Label();

            // Remaining Time Section
            this.lblRemaining = new System.Windows.Forms.Label();
            this.lblRemainingValue = new System.Windows.Forms.Label();

            // Divider
            this.panelDivider = new System.Windows.Forms.Panel();

            // Buttons
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            this.panelContainer.SuspendLayout();
            this.SuspendLayout();

            // ============================================
            // FORM SETTINGS
            // ============================================
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.ClientSize = new System.Drawing.Size(500, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Details - FitWare";
            this.DoubleBuffered = true;

            // ============================================
            // TITLE
            // ============================================
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 60);
            this.lblTitle.Text = "PAYMENT DETAILS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ============================================
            // CONTAINER PANEL
            // ============================================
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.Controls.Add(this.lblPaymentID);
            this.panelContainer.Controls.Add(this.lblPaymentIDValue);
            this.panelContainer.Controls.Add(this.lblStatus);
            this.panelContainer.Controls.Add(this.lblStatusValue);
            this.panelContainer.Controls.Add(this.lblMethod);
            this.panelContainer.Controls.Add(this.lblMethodValue);
            this.panelContainer.Controls.Add(this.lblAmount);
            this.panelContainer.Controls.Add(this.lblAmountValue);
            this.panelContainer.Controls.Add(this.lblDueDate);
            this.panelContainer.Controls.Add(this.lblDueDateValue);
            this.panelContainer.Controls.Add(this.lblRemaining);
            this.panelContainer.Controls.Add(this.lblRemainingValue);
            this.panelContainer.Controls.Add(this.panelDivider);
            this.panelContainer.Location = new System.Drawing.Point(25, 110);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(450, 320);

            // ============================================
            // PAYMENT ID
            // ============================================
            this.lblPaymentID.AutoSize = true;
            this.lblPaymentID.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPaymentID.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblPaymentID.Location = new System.Drawing.Point(30, 20);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(112, 28);
            this.lblPaymentID.Text = "Payment ID:";

            this.lblPaymentIDValue.AutoSize = true;
            this.lblPaymentIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentIDValue.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblPaymentIDValue.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblPaymentIDValue.Location = new System.Drawing.Point(180, 20);
            this.lblPaymentIDValue.Name = "lblPaymentIDValue";
            this.lblPaymentIDValue.Size = new System.Drawing.Size(0, 28);

            // ============================================
            // PAYMENT STATUS
            // ============================================
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblStatus.Location = new System.Drawing.Point(30, 65);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 28);
            this.lblStatus.Text = "Status:";

            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(180, 65);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(0, 28);

            // ============================================
            // PAYMENT METHOD
            // ============================================
            this.lblMethod.AutoSize = true;
            this.lblMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblMethod.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblMethod.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblMethod.Location = new System.Drawing.Point(30, 110);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(86, 28);
            this.lblMethod.Text = "Method:";

            this.lblMethodValue.AutoSize = true;
            this.lblMethodValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMethodValue.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblMethodValue.ForeColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.lblMethodValue.Location = new System.Drawing.Point(180, 110);
            this.lblMethodValue.Name = "lblMethodValue";
            this.lblMethodValue.Size = new System.Drawing.Size(0, 28);

            // ============================================
            // AMOUNT
            // ============================================
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblAmount.Location = new System.Drawing.Point(30, 155);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(81, 28);
            this.lblAmount.Text = "Amount:";

            this.lblAmountValue.AutoSize = true;
            this.lblAmountValue.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountValue.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblAmountValue.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblAmountValue.Location = new System.Drawing.Point(180, 153);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(0, 32);

            // ============================================
            // DUE DATE
            // ============================================
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDueDate.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblDueDate.Location = new System.Drawing.Point(30, 200);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new Size(96, 28);
            this.lblDueDate.Text = "Due Date:";

            this.lblDueDateValue.AutoSize = true;
            this.lblDueDateValue.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDateValue.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblDueDateValue.ForeColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.lblDueDateValue.Location = new System.Drawing.Point(180, 200);
            this.lblDueDateValue.Name = "lblDueDateValue";
            this.lblDueDateValue.Size = new System.Drawing.Size(0, 28);

            // ============================================
            // REMAINING TIME
            // ============================================
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblRemaining.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblRemaining.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblRemaining.Location = new System.Drawing.Point(30, 245);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new Size(166, 28);
            this.lblRemaining.Text = "Remaining Time:";

            this.lblRemainingValue.AutoSize = true;
            this.lblRemainingValue.BackColor = System.Drawing.Color.Transparent;
            this.lblRemainingValue.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblRemainingValue.Location = new System.Drawing.Point(30, 278);
            this.lblRemainingValue.Name = "lblRemainingValue";
            this.lblRemainingValue.Size = new System.Drawing.Size(0, 28);

            // ============================================
            // DIVIDER
            // ============================================
            this.panelDivider.BackColor = System.Drawing.Color.FromArgb(60, 60, 70);
            this.panelDivider.Location = new System.Drawing.Point(20, 315);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(410, 1);
            // In the InitializeComponent method, change the btnRenew section to always be visible:

            // ============================================
            // RENEW BUTTON - Always visible
            // ============================================
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnRenew.Cursor = Cursors.Hand;
            this.btnRenew.FlatAppearance.BorderSize = 0;
            this.btnRenew.FlatStyle = FlatStyle.Flat;
            this.btnRenew.Font = new Font("Calibri", 12F, FontStyle.Bold);
            this.btnRenew.ForeColor = Color.White;
            this.btnRenew.Location = new Point(100, 455);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new Size(140, 40);
            this.btnRenew.Text = "🔄 RENEW";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Visible = true;  // Always visible
            this.btnRenew.Enabled = true;   // Always enabled
            this.btnRenew.Click += new EventHandler(this.btnRenew_Click);

            // ============================================
            // CLOSE BUTTON
            // ============================================
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Font = new Font("Calibri", 12F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(260, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(140, 40);
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // ============================================
            // ADD CONTROLS
            // ============================================
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.lblTitle);

            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label lblPaymentID;
        private System.Windows.Forms.Label lblPaymentIDValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblMethodValue;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDueDateValue;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label lblRemainingValue;
        private System.Windows.Forms.Panel panelDivider;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnClose;
    }
}