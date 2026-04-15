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
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilterDate = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.btnBasic = new System.Windows.Forms.Button();
            this.btnPremium = new System.Windows.Forms.Button();
            this.dgvPayments = new System.Windows.Forms.DataGridView();

            this.topPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvPayments).BeginInit();
            this.SuspendLayout();

            // topPanel
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnRefresh);
            this.topPanel.Controls.Add(this.btnPrintReceipt);
            this.topPanel.Controls.Add(this.btnBack);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1371, 80);
            this.topPanel.TabIndex = 3;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblTitle.Location = new System.Drawing.Point(34, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 46);
            this.lblTitle.Text = "💰 Payment Management";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(525, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 47);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "⟳ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;

            // btnPrintReceipt
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintReceipt.FlatAppearance.BorderSize = 0;
            this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.White;
            this.btnPrintReceipt.Location = new System.Drawing.Point(650, 25);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(137, 47);
            this.btnPrintReceipt.TabIndex = 2;
            this.btnPrintReceipt.Text = "🖨️ Print Receipt";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnBack.Location = new System.Drawing.Point(800, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 47);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;

            // filterPanel
            this.filterPanel.BackColor = System.Drawing.Color.White;
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.dtpFilterDate);
            this.filterPanel.Controls.Add(this.btnApplyFilter);
            this.filterPanel.Controls.Add(this.lblSearch);
            this.filterPanel.Controls.Add(this.lblFilterDate);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 80);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Padding = new System.Windows.Forms.Padding(23, 20, 23, 13);
            this.filterPanel.Size = new System.Drawing.Size(1371, 85);
            this.filterPanel.TabIndex = 2;

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(23, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔍 Search by receipt # or member name...";
            this.txtSearch.Size = new System.Drawing.Size(300, 32);
            this.txtSearch.TabIndex = 0;

            // dtpFilterDate
            this.dtpFilterDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterDate.Location = new System.Drawing.Point(380, 45);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(137, 32);
            this.dtpFilterDate.TabIndex = 3;
            this.dtpFilterDate.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);

            // btnApplyFilter
            this.btnApplyFilter.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
            this.btnApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyFilter.FlatAppearance.BorderSize = 0;
            this.btnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(540, 42);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(91, 40);
            this.btnApplyFilter.TabIndex = 5;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.UseVisualStyleBackColor = false;

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblSearch.Location = new System.Drawing.Point(23, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(56, 20);
            this.lblSearch.Text = "Search:";

            // lblFilterDate
            this.lblFilterDate.AutoSize = true;
            this.lblFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterDate.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblFilterDate.Location = new System.Drawing.Point(380, 20);
            this.lblFilterDate.Name = "lblFilterDate";
            this.lblFilterDate.Size = new System.Drawing.Size(44, 20);
            this.lblFilterDate.Text = "Date:";

            // statsPanel
            this.statsPanel.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.statsPanel.Controls.Add(this.lblTotalAmount);
            this.statsPanel.Controls.Add(this.lblTotalPayments);
            this.statsPanel.Controls.Add(this.btnBasic);
            this.statsPanel.Controls.Add(this.btnPremium);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsPanel.Location = new System.Drawing.Point(0, 165);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Padding = new System.Windows.Forms.Padding(23, 13, 23, 13);
            this.statsPanel.Size = new System.Drawing.Size(1371, 70);
            this.statsPanel.TabIndex = 1;

            // lblTotalAmount
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(23, 15);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(250, 40);
            this.lblTotalAmount.TabIndex = 0;
            this.lblTotalAmount.Text = "💰 Total: ₱0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblTotalPayments
            this.lblTotalPayments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalPayments.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPayments.Location = new System.Drawing.Point(280, 15);
            this.lblTotalPayments.Name = "lblTotalPayments";
            this.lblTotalPayments.Size = new System.Drawing.Size(250, 40);
            this.lblTotalPayments.TabIndex = 1;
            this.lblTotalPayments.Text = "📊 Transactions: 0";
            this.lblTotalPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnBasic
            this.btnBasic.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnBasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBasic.ForeColor = System.Drawing.Color.White;
            this.btnBasic.Location = new System.Drawing.Point(580, 15);
            this.btnBasic.Name = "btnBasic";
            this.btnBasic.Size = new System.Drawing.Size(150, 40);
            this.btnBasic.TabIndex = 4;
            this.btnBasic.Text = "⭐ BASIC: 0";
            this.btnBasic.UseVisualStyleBackColor = false;

            // btnPremium
            this.btnPremium.BackColor = System.Drawing.Color.FromArgb(156, 39, 176);
            this.btnPremium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPremium.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPremium.ForeColor = System.Drawing.Color.White;
            this.btnPremium.Location = new System.Drawing.Point(750, 15);
            this.btnPremium.Name = "btnPremium";
            this.btnPremium.Size = new System.Drawing.Size(150, 40);
            this.btnPremium.TabIndex = 5;
            this.btnPremium.Text = "💎 PREMIUM: 0";
            this.btnPremium.UseVisualStyleBackColor = false;

            // dgvPayments
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPayments.ColumnHeadersHeight = 45;
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayments.EnableHeadersVisualStyles = false;
            this.dgvPayments.GridColor = System.Drawing.Color.FromArgb(235, 235, 240);
            this.dgvPayments.Location = new System.Drawing.Point(0, 235);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.RowTemplate.Height = 40;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(1371, 698);
            this.dgvPayments.TabIndex = 0;

            // FormPayments
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.ClientSize = new System.Drawing.Size(1371, 933);
            this.Controls.Add(this.dgvPayments);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.Name = "FormPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FitWare - Payment Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvPayments).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFilterDate;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalPayments;
        private System.Windows.Forms.Button btnBasic;
        private System.Windows.Forms.Button btnPremium;
        private System.Windows.Forms.DataGridView dgvPayments;
    }
}