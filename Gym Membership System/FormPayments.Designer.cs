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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            topPanel = new Panel();
            lblTitle = new Label();
            btnAddPayment = new Button();
            btnRefresh = new Button();
            btnPrintReceipt = new Button();
            btnBack = new Button();
            filterPanel = new Panel();
            txtSearch = new TextBox();
            cmbStatusFilter = new ComboBox();
            cmbMembershipFilter = new ComboBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnApplyFilter = new Button();
            lblFilterStatus = new Label();
            lblFilterMembership = new Label();
            lblFilterDate = new Label();
            statsPanel = new Panel();
            lblTotalAmount = new Label();
            lblTotalPayments = new Label();
            lblBasicTotal = new Label();
            lblPremiumTotal = new Label();
            panelStatsDivider = new Panel();
            dgvPayments = new DataGridView();
            topPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(lblTitle);
            topPanel.Controls.Add(btnAddPayment);
            topPanel.Controls.Add(btnRefresh);
            topPanel.Controls.Add(btnPrintReceipt);
            topPanel.Controls.Add(btnBack);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1371, 93);
            topPanel.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 100, 0);
            lblTitle.Location = new Point(34, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(437, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💰 Payment Management";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnAddPayment
            // 
            btnAddPayment.BackColor = Color.FromArgb(76, 175, 80);
            btnAddPayment.Cursor = Cursors.Hand;
            btnAddPayment.FlatAppearance.BorderSize = 0;
            btnAddPayment.FlatStyle = FlatStyle.Flat;
            btnAddPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddPayment.ForeColor = Color.White;
            btnAddPayment.Location = new Point(434, 24);
            btnAddPayment.Margin = new Padding(3, 4, 3, 4);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(160, 47);
            btnAddPayment.TabIndex = 0;
            btnAddPayment.Text = "+ New Payment";
            btnAddPayment.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(100, 120, 150);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(611, 24);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 47);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "⟳ Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.BackColor = Color.FromArgb(33, 150, 243);
            btnPrintReceipt.Cursor = Cursors.Hand;
            btnPrintReceipt.FlatAppearance.BorderSize = 0;
            btnPrintReceipt.FlatStyle = FlatStyle.Flat;
            btnPrintReceipt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrintReceipt.ForeColor = Color.White;
            btnPrintReceipt.Location = new Point(743, 24);
            btnPrintReceipt.Margin = new Padding(3, 4, 3, 4);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(137, 47);
            btnPrintReceipt.TabIndex = 2;
            btnPrintReceipt.Text = "🖨️ Print Receipt";
            btnPrintReceipt.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(200, 200, 210);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.FromArgb(80, 80, 90);
            btnBack.Location = new Point(897, 24);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(114, 47);
            btnBack.TabIndex = 3;
            btnBack.Text = "← Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.White;
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(cmbStatusFilter);
            filterPanel.Controls.Add(cmbMembershipFilter);
            filterPanel.Controls.Add(dtpStartDate);
            filterPanel.Controls.Add(dtpEndDate);
            filterPanel.Controls.Add(btnApplyFilter);
            filterPanel.Controls.Add(lblFilterStatus);
            filterPanel.Controls.Add(lblFilterMembership);
            filterPanel.Controls.Add(lblFilterDate);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(0, 93);
            filterPanel.Margin = new Padding(3, 4, 3, 4);
            filterPanel.Name = "filterPanel";
            filterPanel.Padding = new Padding(23, 20, 23, 13);
            filterPanel.Size = new Size(1371, 107);
            filterPanel.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(23, 53);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search by receipt #...";
            txtSearch.Size = new Size(251, 32);
            txtSearch.TabIndex = 0;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 11F);
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Paid", "Pending" });
            cmbStatusFilter.Location = new Point(297, 51);
            cmbStatusFilter.Margin = new Padding(3, 4, 3, 4);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(125, 33);
            cmbStatusFilter.TabIndex = 1;
            // 
            // cmbMembershipFilter
            // 
            cmbMembershipFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMembershipFilter.Font = new Font("Segoe UI", 11F);
            cmbMembershipFilter.Items.AddRange(new object[] { "All", "BASIC", "PREMIUM" });
            cmbMembershipFilter.Location = new Point(446, 51);
            cmbMembershipFilter.Margin = new Padding(3, 4, 3, 4);
            cmbMembershipFilter.Name = "cmbMembershipFilter";
            cmbMembershipFilter.Size = new Size(137, 33);
            cmbMembershipFilter.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 11F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(606, 51);
            dtpStartDate.Margin = new Padding(3, 4, 3, 4);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(114, 32);
            dtpStartDate.TabIndex = 3;
            dtpStartDate.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 11F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(731, 51);
            dtpEndDate.Margin = new Padding(3, 4, 3, 4);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(114, 32);
            dtpEndDate.TabIndex = 4;
            dtpEndDate.Value = new DateTime(2026, 4, 6, 21, 2, 54, 436);
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.BackColor = Color.FromArgb(100, 120, 150);
            btnApplyFilter.Cursor = Cursors.Hand;
            btnApplyFilter.FlatAppearance.BorderSize = 0;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApplyFilter.ForeColor = Color.White;
            btnApplyFilter.Location = new Point(869, 48);
            btnApplyFilter.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(91, 40);
            btnApplyFilter.TabIndex = 5;
            btnApplyFilter.Text = "Apply";
            btnApplyFilter.UseVisualStyleBackColor = false;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new Font("Segoe UI", 9F);
            lblFilterStatus.ForeColor = Color.FromArgb(100, 100, 110);
            lblFilterStatus.Location = new Point(297, 27);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(52, 20);
            lblFilterStatus.TabIndex = 6;
            lblFilterStatus.Text = "Status:";
            // 
            // lblFilterMembership
            // 
            lblFilterMembership.AutoSize = true;
            lblFilterMembership.Font = new Font("Segoe UI", 9F);
            lblFilterMembership.ForeColor = Color.FromArgb(100, 100, 110);
            lblFilterMembership.Location = new Point(446, 27);
            lblFilterMembership.Name = "lblFilterMembership";
            lblFilterMembership.Size = new Size(95, 20);
            lblFilterMembership.TabIndex = 7;
            lblFilterMembership.Text = "Membership:";
            // 
            // lblFilterDate
            // 
            lblFilterDate.AutoSize = true;
            lblFilterDate.Font = new Font("Segoe UI", 9F);
            lblFilterDate.ForeColor = Color.FromArgb(100, 100, 110);
            lblFilterDate.Location = new Point(606, 27);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new Size(44, 20);
            lblFilterDate.TabIndex = 8;
            lblFilterDate.Text = "Date:";
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.FromArgb(248, 249, 252);
            statsPanel.Controls.Add(lblTotalAmount);
            statsPanel.Controls.Add(lblTotalPayments);
            statsPanel.Controls.Add(lblBasicTotal);
            statsPanel.Controls.Add(lblPremiumTotal);
            statsPanel.Controls.Add(panelStatsDivider);
            statsPanel.Dock = DockStyle.Top;
            statsPanel.Location = new Point(0, 200);
            statsPanel.Margin = new Padding(3, 4, 3, 4);
            statsPanel.Name = "statsPanel";
            statsPanel.Padding = new Padding(23, 13, 23, 13);
            statsPanel.Size = new Size(1371, 80);
            statsPanel.TabIndex = 1;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(255, 100, 0);
            lblTotalAmount.Location = new Point(23, 20);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(229, 40);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "💰 Total: ₱0.00";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalPayments
            // 
            lblTotalPayments.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPayments.ForeColor = Color.FromArgb(76, 175, 80);
            lblTotalPayments.Location = new Point(263, 20);
            lblTotalPayments.Name = "lblTotalPayments";
            lblTotalPayments.Size = new Size(206, 40);
            lblTotalPayments.TabIndex = 1;
            lblTotalPayments.Text = "📊 Payments: 0";
            lblTotalPayments.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBasicTotal
            // 
            lblBasicTotal.Font = new Font("Segoe UI", 11F);
            lblBasicTotal.ForeColor = Color.FromArgb(33, 150, 243);
            lblBasicTotal.Location = new Point(514, 20);
            lblBasicTotal.Name = "lblBasicTotal";
            lblBasicTotal.Size = new Size(229, 40);
            lblBasicTotal.TabIndex = 2;
            lblBasicTotal.Text = "⭐ BASIC: ₱0.00";
            lblBasicTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPremiumTotal
            // 
            lblPremiumTotal.Font = new Font("Segoe UI", 11F);
            lblPremiumTotal.ForeColor = Color.FromArgb(156, 39, 176);
            lblPremiumTotal.Location = new Point(754, 20);
            lblPremiumTotal.Name = "lblPremiumTotal";
            lblPremiumTotal.Size = new Size(251, 40);
            lblPremiumTotal.TabIndex = 3;
            lblPremiumTotal.Text = "💎 PREMIUM: ₱0.00";
            lblPremiumTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelStatsDivider
            // 
            panelStatsDivider.BackColor = Color.FromArgb(230, 230, 240);
            panelStatsDivider.Dock = DockStyle.Bottom;
            panelStatsDivider.Location = new Point(23, 66);
            panelStatsDivider.Margin = new Padding(3, 4, 3, 4);
            panelStatsDivider.Name = "panelStatsDivider";
            panelStatsDivider.Size = new Size(1325, 1);
            panelStatsDivider.TabIndex = 4;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 255);
            dgvPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(60, 60, 70);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPayments.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 245, 235);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(255, 100, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPayments.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPayments.Dock = DockStyle.Fill;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.GridColor = Color.FromArgb(235, 235, 240);
            dgvPayments.Location = new Point(0, 280);
            dgvPayments.Margin = new Padding(3, 4, 3, 4);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.RowTemplate.Height = 40;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(1371, 653);
            dgvPayments.TabIndex = 0;
            dgvPayments.CellContentClick += dgvPayments_CellContentClick;
            // 
            // FormPayments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 250);
            ClientSize = new Size(1371, 933);
            Controls.Add(dgvPayments);
            Controls.Add(statsPanel);
            Controls.Add(filterPanel);
            Controls.Add(topPanel);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPayments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FitWare - Payment Management";
            WindowState = FormWindowState.Maximized;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            statsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
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