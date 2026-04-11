namespace Gym_Membership_System
{
    partial class Attendance
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
            this.lblSelectCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblDueAlert = new System.Windows.Forms.Label();
            this.lblWeekRange = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.btnMarkPresent = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // FORM SETTINGS
            // ============================================
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.DoubleBuffered = true;
            this.Text = "Attendance Tracker - FitWare";
            this.Name = "Attendance";

            // ============================================
            // TITLE LABEL
            // ============================================
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 60);
            this.lblTitle.Text = "ATTENDANCE TRACKER";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(30, 0, 0, 0);

            // ============================================
            // SELECT CUSTOMER LABEL
            // ============================================
            this.lblSelectCustomer.AutoSize = true;
            this.lblSelectCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectCustomer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSelectCustomer.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblSelectCustomer.Location = new System.Drawing.Point(0, 0);
            this.lblSelectCustomer.Name = "lblSelectCustomer";
            this.lblSelectCustomer.Size = new Size(180, 32);
            this.lblSelectCustomer.Text = "Select Customer:";
            this.lblSelectCustomer.TextAlign = ContentAlignment.MiddleRight;

            // ============================================
            // CUSTOMER COMBOBOX
            // ============================================
            this.cmbCustomer.BackColor = System.Drawing.Color.White;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCustomer.Location = new System.Drawing.Point(0, 0);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new Size(350, 36);
            this.cmbCustomer.TabIndex = 1;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);

            // ============================================
            // STATUS LABEL
            // ============================================
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new Size(70, 28);
            this.lblStatusLabel.Text = "Status:";
            this.lblStatusLabel.TextAlign = ContentAlignment.MiddleRight;

            // ============================================
            // STATUS VALUE
            // ============================================
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(0, 0);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new Size(180, 32);
            this.lblStatusValue.Text = "Select a customer";

            // ============================================
            // DUE ALERT LABEL
            // ============================================
            this.lblDueAlert.AutoSize = true;
            this.lblDueAlert.BackColor = System.Drawing.Color.Transparent;
            this.lblDueAlert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDueAlert.Location = new System.Drawing.Point(0, 0);
            this.lblDueAlert.Name = "lblDueAlert";
            this.lblDueAlert.Size = new Size(0, 25);

            // ============================================
            // WEEK RANGE LABEL
            // ============================================
            this.lblWeekRange.AutoSize = true;
            this.lblWeekRange.BackColor = System.Drawing.Color.Transparent;
            this.lblWeekRange.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblWeekRange.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblWeekRange.Location = new System.Drawing.Point(0, 0);
            this.lblWeekRange.Name = "lblWeekRange";
            this.lblWeekRange.Size = new Size(220, 23);
            this.lblWeekRange.Text = "Showing last 7 days of attendance";

            // ============================================
            // DATA GRID VIEW
            // ============================================
            this.dgvAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAttendance.ColumnHeadersHeight = 45;
            this.dgvAttendance.EnableHeadersVisualStyles = false;
            this.dgvAttendance.GridColor = System.Drawing.Color.FromArgb(235, 235, 240);
            this.dgvAttendance.RowHeadersVisible = false;
            this.dgvAttendance.RowTemplate.Height = 40;
            this.dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendance.AllowUserToAddRows = false;
            this.dgvAttendance.AllowUserToDeleteRows = false;
            this.dgvAttendance.ReadOnly = true;
            this.dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendance.Location = new System.Drawing.Point(0, 0);
            this.dgvAttendance.Name = "dgvAttendance";
            this.dgvAttendance.Size = new Size(900, 400);
            this.dgvAttendance.TabIndex = 2;

            // Header styling
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 70);
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // Row styling
            this.dgvAttendance.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvAttendance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvAttendance.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 235);
            this.dgvAttendance.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.dgvAttendance.DefaultCellStyle.Padding = new Padding(10);
            this.dgvAttendance.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);

            // Predefine columns
            this.dgvAttendance.Columns.Add("Date", "Date");
            this.dgvAttendance.Columns.Add("Day", "Day");
            this.dgvAttendance.Columns.Add("Status", "Status");
            this.dgvAttendance.Columns.Add("CheckIn", "Check In");
            this.dgvAttendance.Columns.Add("CheckOut", "Check Out");

            // Column widths
            this.dgvAttendance.Columns["Date"].Width = 120;
            this.dgvAttendance.Columns["Day"].Width = 100;
            this.dgvAttendance.Columns["Status"].Width = 100;
            this.dgvAttendance.Columns["CheckIn"].Width = 100;
            this.dgvAttendance.Columns["CheckOut"].Width = 100;

            // Center align all columns
            foreach (DataGridViewColumn col in this.dgvAttendance.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // ============================================
            // MARK PRESENT BUTTON
            // ============================================
            this.btnMarkPresent.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnMarkPresent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkPresent.FlatAppearance.BorderSize = 0;
            this.btnMarkPresent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkPresent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarkPresent.ForeColor = System.Drawing.Color.White;
            this.btnMarkPresent.Location = new System.Drawing.Point(0, 0);
            this.btnMarkPresent.Name = "btnMarkPresent";
            this.btnMarkPresent.Size = new Size(160, 45);
            this.btnMarkPresent.Text = "✓ MARK PRESENT";
            this.btnMarkPresent.UseVisualStyleBackColor = false;
            this.btnMarkPresent.Click += new System.EventHandler(this.btnMarkPresent_Click);

            // ============================================
            // REFRESH BUTTON
            // ============================================
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(140, 45);
            this.btnRefresh.Text = "⟳ REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ============================================
            // CLOSE BUTTON
            // ============================================
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(140, 45);
            this.btnClose.Text = "✖ CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ============================================
            // ADD ALL CONTROLS
            // ============================================
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSelectCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblStatusLabel);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.lblDueAlert);
            this.Controls.Add(this.lblWeekRange);
            this.Controls.Add(this.dgvAttendance);
            this.Controls.Add(this.btnMarkPresent);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);

            this.Load += new System.EventHandler(this.Attendance_Load);
            this.Resize += new System.EventHandler(this.Attendance_Resize);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSelectCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblDueAlert;
        private System.Windows.Forms.Label lblWeekRange;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Button btnMarkPresent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}