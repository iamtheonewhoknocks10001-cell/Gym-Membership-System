namespace Gym_Membership_System
{
    partial class FormPayments
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
            // Top Panel
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();

            // Filter Panel
            this.filterPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.cmbMembershipFilter = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.lblFilterMembership = new System.Windows.Forms.Label();
            this.lblFilterDate = new System.Windows.Forms.Label();

            // Stats Panel
            this.statsPanel = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.lblBasicTotal = new System.Windows.Forms.Label();
            this.lblPremiumTotal = new System.Windows.Forms.Label();
            this.panelStatsDivider = new System.Windows.Forms.Panel();

            // Data Grid View
            this.dgvPayments = new System.Windows.Forms.DataGridView();

            // Suspend Layout
            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // TOP PANEL
            // ============================================
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnAddPayment);
            this.topPanel.Controls.Add(this.btnRefresh);
            this.topPanel.Controls.Add(this.btnPrintReceipt);
            this.topPanel.Controls.Add(this.btnBack);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Height = 70;
            this.topPanel.Name = "topPanel";

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblTitle.Location = new System.Drawing.Point(30, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 37);
            this.lblTitle.Text = "💰 Payment Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnAddPayment
            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPayment.FlatAppearance.BorderSize = 0;
            this.btnAddPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(380, 18);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(140, 35);
            this.btnAddPayment.TabIndex = 0;
            this.btnAddPayment.Text = "+ New Payment";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(535, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "⟳ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnPrintReceipt
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReceipt.FlatAppearance.BorderSize = 0;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.White;
            this.btnPrintReceipt.Location = new System.Drawing.Point(650, 18);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(120, 35);
            this.btnPrintReceipt.TabIndex = 2;
            this.btnPrintReceipt.Text = "🖨️ Print Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnBack.Location = new System.Drawing.Point(785, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;

            // ============================================
            // FILTER PANEL
            // ============================================
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.cmbStatusFilter);
            this.filterPanel.Controls.Add(this.cmbMembershipFilter);
            this.filterPanel.Controls.Add(this.dtpStartDate);
            this.filterPanel.Controls.Add(this.dtpEndDate);
            this.filterPanel.Controls.Add(this.btnApplyFilter);
            this.filterPanel.Controls.Add(this.lblFilterStatus);
            this.filterPanel.Controls.Add(this.lblFilterMembership);
            this.filterPanel.Controls.Add(this.lblFilterDate);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Height = 80;
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(20, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.PlaceholderText = "🔍 Search by receipt #...";

            // lblFilterStatus
            this.lblFilterStatus.AutoSize = true;
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblFilterStatus.Location = new System.Drawing.Point(260, 20);
            this.lblFilterStatus.Name = "lblFilterStatus";
            this.lblFilterStatus.Size = new System.Drawing.Size(42, 15);
            this.lblFilterStatus.Text = "Status:";

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStatusFilter.Items.AddRange(new object[] { "All", "Paid", "Pending" });
            this.cmbStatusFilter.Location = new System.Drawing.Point(260, 38);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(110, 28);
            this.cmbStatusFilter.TabIndex = 1;
            this.cmbStatusFilter.SelectedIndex = 0;

            // lblFilterMembership
            this.lblFilterMembership.AutoSize = true;
            this.lblFilterMembership.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFilterMembership.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblFilterMembership.Location = new System.Drawing.Point(390, 20);
            this.lblFilterMembership.Name = "lblFilterMembership";
            this.lblFilterMembership.Size = new System.Drawing.Size(70, 15);
            this.lblFilterMembership.Text = "Membership:";

            // cmbMembershipFilter
            this.cmbMembershipFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMembershipFilter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbMembershipFilter.Items.AddRange(new object[] { "All", "BASIC", "PREMIUM" });
            this.cmbMembershipFilter.Location = new System.Drawing.Point(390, 38);
            this.cmbMembershipFilter.Name = "cmbMembershipFilter";
            this.cmbMembershipFilter.Size = new System.Drawing.Size(120, 28);
            this.cmbMembershipFilter.TabIndex = 2;
            this.cmbMembershipFilter.SelectedIndex = 0;

            // lblFilterDate
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblFilterDate.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblFilterDate.Location = new System.Drawing.Point(530, 20);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(35, 15);
            this.lblFilterDate.Text = "Date:";

            // dtpStartDate
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(530, 38);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 27);
            this.dtpStartDate.TabIndex = 3;
            this.dtpStartDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);

            // dtpEndDate
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(640, 38);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 27);
            this.dtpEndDate.TabIndex = 4;
            this.dtpEndDate.Value = System.DateTime.Now;

            // btnApplyFilter
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.FlatAppearance.BorderSize = 0;
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(760, 36);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(80, 30);
            this.btnApplyFilter.TabIndex = 5;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.UseVisualStyleBackColor = false;
            this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;

            // ============================================
            // STATS PANEL
            // ============================================
            this.statsPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.statsPanel.Controls.Add(this.lblTotalAmount);
            this.statsPanel.Controls.Add(this.lblTotalPayments);
            this.statsPanel.Controls.Add(this.lblBasicTotal);
            this.statsPanel.Controls.Add(this.lblPremiumTotal);
            this.statsPanel.Controls.Add(this.panelStatsDivider);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsPanel.Height = 60;
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblTotalAmount
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 15);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(200, 30);
            this.lblTotalAmount.Text = "💰 Total: ₱0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblTotalPayments
            this.lblTotalPayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblTotalPayments.Location = new System.Drawing.Point(230, 15);
            this.lblTotalPayments.Name = "lblTotalPayments";
            this.lblTotalPayments.Size = new System.Drawing.Size(180, 30);
            this.lblTotalPayments.Text = "📊 Payments: 0";
            this.lblTotalPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblBasicTotal
            this.lblBasicTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblBasicTotal.ForeColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblBasicTotal.Location = new System.Drawing.Point(450, 15);
            this.lblBasicTotal.Name = "lblBasicTotal";
            this.lblBasicTotal.Size = new System.Drawing.Size(200, 30);
            this.lblBasicTotal.Text = "⭐ BASIC: ₱0.00";
            this.lblBasicTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblPremiumTotal
            this.lblPremiumTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblPremiumTotal.ForeColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.lblPremiumTotal.Location = new System.Drawing.Point(660, 15);
            this.lblPremiumTotal.Name = "lblPremiumTotal";
            this.lblPremiumTotal.Size = new System.Drawing.Size(220, 30);
            this.lblPremiumTotal.Text = "💎 PREMIUM: ₱0.00";
            this.lblPremiumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // panelStatsDivider
            this.panelStatsDivider.BackColor = System.Drawing.Color.FromArgb(230, 230, 240);
            this.panelStatsDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatsDivider.Height = 1;
            this.panelStatsDivider.Name = "panelStatsDivider";

            // ============================================
            // DATA GRID VIEW
            // ============================================
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPayments.ColumnHeadersHeight = 45;
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayments.EnableHeadersVisualStyles = false;
            this.dgvPayments.GridColor = System.Drawing.Color.FromArgb(235, 235, 240);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.RowTemplate.Height = 40;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Header Styling
            this.dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 70);
            this.dgvPayments.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvPayments.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Row Styling
            this.dgvPayments.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvPayments.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPayments.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 235);
            this.dgvPayments.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.dgvPayments.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.dgvPayments.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 255);
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // ============================================
            // FORM
            // ============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.Name = "FormPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FitWare - Payment Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // Resume Layout
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
        }

        // ============================================
        // CONTROL DECLARATIONS
        // ============================================
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbMembershipFilter;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.Label lblFilterMembership;
        private System.Windows.Forms.Label lblFilterDate;

        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalPayments;
        private System.Windows.Forms.Label lblBasicTotal;
        private System.Windows.Forms.Label lblPremiumTotal;
        private System.Windows.Forms.Panel panelStatsDivider;

        private System.Windows.Forms.DataGridView dgvPayments;
    }
}