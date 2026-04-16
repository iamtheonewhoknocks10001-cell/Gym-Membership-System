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
            this.lblSearchClient = new System.Windows.Forms.Label();
            this.txtSearchClient = new System.Windows.Forms.TextBox();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.dgvAttendance = new System.Windows.Forms.DataGridView();
            this.btnMarkPresent = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendance)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // FORM SETTINGS
            // ============================================
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
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
            this.lblTitle.Size = new System.Drawing.Size(100, 65);
            this.lblTitle.Text = "ATTENDANCE TRACKER";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(30, 0, 0, 0);

            // ============================================
            // SEARCH CLIENT LABEL
            // ============================================
            this.lblSearchClient.AutoSize = true;
            this.lblSearchClient.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchClient.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSearchClient.ForeColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.lblSearchClient.Location = new System.Drawing.Point(0, 0);
            this.lblSearchClient.Name = "lblSearchClient";
            this.lblSearchClient.Size = new Size(150, 32);
            this.lblSearchClient.Text = "Search Client:";
            this.lblSearchClient.TextAlign = ContentAlignment.MiddleRight;

            // ============================================
            // SEARCH TEXTBOX
            // ============================================
            this.txtSearchClient.BackColor = System.Drawing.Color.White;
            this.txtSearchClient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearchClient.Location = new System.Drawing.Point(0, 0);
            this.txtSearchClient.Name = "txtSearchClient";
            this.txtSearchClient.PlaceholderText = "🔍 Type member name to search...";
            this.txtSearchClient.Size = new Size(350, 36);
            this.txtSearchClient.TabIndex = 1;
            this.txtSearchClient.TextChanged += new System.EventHandler(this.txtSearchClient_TextChanged);

            // ============================================
            // STATUS LABEL
            // ============================================
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.lblStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new Size(80, 32);
            this.lblStatusLabel.Text = "Status:";
            this.lblStatusLabel.TextAlign = ContentAlignment.MiddleRight;

            // ============================================
            // STATUS VALUE
            // ============================================
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.lblStatusValue.Location = new System.Drawing.Point(0, 0);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new Size(180, 32);
            this.lblStatusValue.Text = "Select a member";

            // ============================================
            // DATA GRID VIEW - Simplified columns
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
            this.dgvAttendance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendance_CellClick);

            // Header styling
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 70);
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Aquamarine;
            this.dgvAttendance.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            // Row styling
            this.dgvAttendance.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvAttendance.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvAttendance.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightCoral;
            this.dgvAttendance.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAttendance.DefaultCellStyle.Padding = new Padding(10);
            this.dgvAttendance.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;


            // Hide MemberID column
            if (this.dgvAttendance.Columns.Contains("MemberID"))
                this.dgvAttendance.Columns["MemberID"].Visible = false;

            // Column widths
            if (this.dgvAttendance.Columns.Count >= 6)
            {
                this.dgvAttendance.Columns["MemberName"].Width = 250;
                this.dgvAttendance.Columns["DateJoined"].Width = 120;
                this.dgvAttendance.Columns["DueDate"].Width = 120;
                this.dgvAttendance.Columns["Status"].Width = 120;
                this.dgvAttendance.Columns["LastCheckIn"].Width = 150;
            }

            // Center align columns
            foreach (DataGridViewColumn col in this.dgvAttendance.Columns)
            {
                if (col.Name != "MemberName")
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
            this.Controls.Add(this.lblSearchClient);
            this.Controls.Add(this.txtSearchClient);
            this.Controls.Add(this.lblStatusLabel);
            this.Controls.Add(this.lblStatusValue);
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
        private System.Windows.Forms.Label lblSearchClient;
        private System.Windows.Forms.TextBox txtSearchClient;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.Button btnMarkPresent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}