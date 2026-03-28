namespace Gym_Membership_System
{
    partial class Form1
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


            // Navigation Panel - Fixed at top
            this.navPanel = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnBlogs = new System.Windows.Forms.Button();
            this.btnAboutUs = new System.Windows.Forms.Button();
            this.btnContactUs = new System.Windows.Forms.Button();

            // Dashboard Container - Fills remaining space
            this.dashboardContainer = new System.Windows.Forms.Panel();

            // Dashboard Content Panel - Contains all dashboard elements
            this.dashboardContent = new System.Windows.Forms.Panel();

            // Greeting Panel
            this.greetingPanel = new System.Windows.Forms.Panel();
            this.lblGreeting = new System.Windows.Forms.Label();

            // Stats Panel
            this.statsPanel = new System.Windows.Forms.Panel();
            this.statsContainer = new System.Windows.Forms.Panel();
            this.statsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();

            // Members Section Panel
            this.membersSection = new System.Windows.Forms.Panel();
            this.membersHeader = new System.Windows.Forms.Panel();
            this.membersHeaderContent = new System.Windows.Forms.Panel();
            this.lblMembersTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tableContainer = new System.Windows.Forms.Panel();
            this.dgvMembers = new System.Windows.Forms.DataGridView();

            // Suspend layouts
            this.navPanel.SuspendLayout();
            this.dashboardContainer.SuspendLayout();
            this.dashboardContent.SuspendLayout();
            this.greetingPanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.statsContainer.SuspendLayout();
            this.membersSection.SuspendLayout();
            this.membersHeader.SuspendLayout();
            this.membersHeaderContent.SuspendLayout();
            this.tableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // NAVIGATION PANEL - Top fixed bar
            // ============================================
            this.navPanel.BackColor = System.Drawing.Color.White;
            this.navPanel.Controls.Add(this.lblLogo);
            this.navPanel.Controls.Add(this.btnHome);
            this.navPanel.Controls.Add(this.btnStore);
            this.navPanel.Controls.Add(this.btnBlogs);
            this.navPanel.Controls.Add(this.btnAboutUs);
            this.navPanel.Controls.Add(this.btnContactUs);
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.navPanel.Height = 65;
            this.navPanel.Name = "navPanel";

            this.navPanel.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawLine(pen, 0, this.navPanel.Height - 1, this.navPanel.Width, this.navPanel.Height - 1);
                }
            };

            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.lblLogo.Location = new System.Drawing.Point(30, 20);
            this.lblLogo.Text = "FITNESS CLUB";

            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnHome.Location = new System.Drawing.Point(220, 18);
            this.btnHome.Size = new System.Drawing.Size(110, 30);
            this.btnHome.Text = "ADD MEMBER";
            this.btnHome.Click += new System.EventHandler(this.btnAddMember_Click);

            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.FlatAppearance.BorderSize = 0;
            this.btnStore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStore.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnStore.Location = new System.Drawing.Point(340, 18);
            this.btnStore.Size = new System.Drawing.Size(120, 30);
            this.btnStore.Text = "MANAGE";
            this.btnStore.Click += new System.EventHandler(this.btnManage_Click);

            this.btnBlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlogs.FlatAppearance.BorderSize = 0;
            this.btnBlogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBlogs.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnBlogs.Location = new System.Drawing.Point(470, 18);
            this.btnBlogs.Size = new System.Drawing.Size(100, 30);
            this.btnBlogs.Text = "TRAINERS";
            this.btnBlogs.Click += new System.EventHandler(this.btnTrainers_Click);

            this.btnAboutUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutUs.FlatAppearance.BorderSize = 0;
            this.btnAboutUs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAboutUs.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnAboutUs.Location = new System.Drawing.Point(580, 18);
            this.btnAboutUs.Size = new System.Drawing.Size(100, 30);
            this.btnAboutUs.Text = "PAYMENTS";
            this.btnAboutUs.Click += new System.EventHandler(this.btnPayments_Click);

            this.btnContactUs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContactUs.FlatAppearance.BorderSize = 0;
            this.btnContactUs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnContactUs.ForeColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.btnContactUs.Location = new System.Drawing.Point(690, 18);
            this.btnContactUs.Size = new System.Drawing.Size(100, 30);
            this.btnContactUs.Text = "LOG OUT";
            this.btnContactUs.Click += new System.EventHandler(this.btnLogout_Click);

            // ============================================
            // DASHBOARD CONTAINER
            // ============================================
            this.dashboardContainer.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.dashboardContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardContainer.Padding = new System.Windows.Forms.Padding(40, 30, 40, 40);
            this.dashboardContainer.Controls.Add(this.dashboardContent);

            // ============================================
            // DASHBOARD CONTENT
            // ============================================
            this.dashboardContent.BackColor = System.Drawing.Color.Transparent;
            this.dashboardContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardContent.Controls.Add(this.membersSection);
            this.dashboardContent.Controls.Add(this.statsPanel);
            this.dashboardContent.Controls.Add(this.greetingPanel);

            // ============================================
            // GREETING PANEL
            // ============================================
            this.greetingPanel.BackColor = System.Drawing.Color.Transparent;
            this.greetingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.greetingPanel.Height = 80;
            this.greetingPanel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);

            this.lblGreeting.BackColor = System.Drawing.Color.Transparent;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblGreeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.greetingPanel.Controls.Add(this.lblGreeting);

            // ============================================
            // STATS PANEL - With colored cards
            // ============================================
            this.statsPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.statsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.statsPanel.Height = 150;
            this.statsPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 20);

            this.statsContainer.BackColor = System.Drawing.Color.Transparent;
            this.statsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsContainer.Controls.Add(this.statsFlowLayout);

            this.statsFlowLayout.BackColor = System.Drawing.Color.Transparent;
            this.statsFlowLayout.AutoSize = true;
            this.statsFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.statsFlowLayout.WrapContents = false;
            this.statsFlowLayout.Location = new System.Drawing.Point(0, 0);

            this.statsContainer.Resize += (s, e) => CenterStatsPanel();
            this.statsPanel.Controls.Add(this.statsContainer);

            // ============================================
            // MEMBERS SECTION - White background
            // ============================================
            this.membersSection.BackColor = System.Drawing.Color.White;
            this.membersSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membersSection.Padding = new System.Windows.Forms.Padding(0);

            // ============================================
            // MEMBERS HEADER - Light lavender background
            // ============================================
            this.membersHeader.BackColor = System.Drawing.Color.LightCyan;
            this.membersHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.membersHeader.Height = 85;
            this.membersHeader.Padding = new System.Windows.Forms.Padding(0);

            this.membersHeader.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(235, 235, 240), 1))
                {
                    e.Graphics.DrawLine(pen, 0, this.membersHeader.Height - 1, this.membersHeader.Width, this.membersHeader.Height - 1);
                }
            };

            // Header Content Container
            this.membersHeaderContent.BackColor = System.Drawing.Color.Transparent;
            this.membersHeaderContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.membersHeaderContent.Controls.Add(this.lblMembersTitle);
            this.membersHeaderContent.Controls.Add(this.txtSearch);
            this.membersHeaderContent.Controls.Add(this.btnRefresh);
            this.membersHeaderContent.Resize += (s, e) => CenterHeaderContent();

            // Members Title - Colored text
            this.lblMembersTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblMembersTitle.ForeColor = System.Drawing.Color.FromArgb(75, 85, 110);
            this.lblMembersTitle.Size = new System.Drawing.Size(200, 45);
            this.lblMembersTitle.Text = "📋 Members List";
            this.lblMembersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMembersTitle.AutoSize = false;

            // Search Box - With improved styling
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Size = new System.Drawing.Size(385, 36);
            this.txtSearch.PlaceholderText = "🔍 Search by name, email, or ID...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // Refresh Button - With hover effect and accent color
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 120, 150);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Size = new System.Drawing.Size(110, 36);
            this.btnRefresh.Text = "⟳ Refresh";
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnRefresh.MouseEnter += (s, e) => { this.btnRefresh.BackColor = Color.FromArgb(80, 100, 130); };
            this.btnRefresh.MouseLeave += (s, e) => { this.btnRefresh.BackColor = Color.FromArgb(100, 120, 150); };

            this.membersHeader.Controls.Add(this.membersHeaderContent);

            // ============================================
            // TABLE CONTAINER
            // ============================================
            this.tableContainer.BackColor = System.Drawing.Color.LightGray;
            this.tableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableContainer.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20); // Add padding around table
            this.tableContainer.Controls.Add(this.dgvMembers);

            this.dgvMembers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMembers.ColumnHeadersHeight = 45;
            this.dgvMembers.EnableHeadersVisualStyles = false;
            this.dgvMembers.GridColor = System.Drawing.Color.FromArgb(235, 235, 240);
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.RowTemplate.Height = 40;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.ReadOnly = true;

            // Header styling - Darker for contrast
            this.dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 245);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 70);
            this.dgvMembers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // Row styling - White and light alternating
            this.dgvMembers.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMembers.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvMembers.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 245, 235);
            this.dgvMembers.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(255, 100, 0);
            this.dgvMembers.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10);
            this.dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);

            this.dgvMembers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellDoubleClick);
            this.tableContainer.Resize += (s, e) => CenterTable();

            this.membersSection.Controls.Add(this.tableContainer);
            this.membersSection.Controls.Add(this.membersHeader);

            // ============================================
            // FORM LAYOUT
            // ============================================
            this.dashboardContent.Controls.Add(this.membersSection);
            this.dashboardContent.Controls.Add(this.statsPanel);
            this.dashboardContent.Controls.Add(this.greetingPanel);
            this.dashboardContainer.Controls.Add(this.dashboardContent);

            // Form1
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.BackgroundImage = null;
            this.ClientSize = new System.Drawing.Size(1515, 821);
            this.Controls.Add(this.dashboardContainer);
            this.Controls.Add(this.navPanel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "FitWare Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);

            // Resume layouts
            this.navPanel.ResumeLayout(false);
            this.navPanel.PerformLayout();
            this.dashboardContainer.ResumeLayout(false);
            this.dashboardContent.ResumeLayout(false);
            this.greetingPanel.ResumeLayout(false);
            this.statsPanel.ResumeLayout(false);
            this.statsContainer.ResumeLayout(false);
            this.statsContainer.PerformLayout();
            this.membersSection.ResumeLayout(false);
            this.membersHeader.ResumeLayout(false);
            this.membersHeaderContent.ResumeLayout(false);
            this.membersHeaderContent.PerformLayout();
            this.tableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
        }



        private void CenterStatsPanel()
        {
            if (this.statsFlowLayout == null || this.statsContainer == null) return;

            int flowLayoutWidth = this.statsFlowLayout.PreferredSize.Width;
            int containerWidth = this.statsContainer.Width;
            int leftPosition = (containerWidth - flowLayoutWidth) / 2;

            if (leftPosition < 0) leftPosition = 0;

            this.statsFlowLayout.Location = new System.Drawing.Point(leftPosition, 0);
        }

        private void CenterHeaderContent()
        {
            if (this.membersHeaderContent == null) return;

            int containerWidth = this.membersHeaderContent.Width;

            // Element dimensions
            int titleWidth = 200;
            int searchWidth = 385;
            int refreshWidth = 110;
            int spacing = 30;

            // Search bar height - adjustable
            int searchBarHeight = 19; // Change this to adjust search bar height

            // Calculate total width
            int totalWidth = titleWidth + spacing + searchWidth + spacing + refreshWidth;
            int startX = (containerWidth - totalWidth) / 2;

            if (startX < 10) startX = 10;

            // Individual vertical positions
            int titleVerticalPosition = 26;      // Position for Members List text
            int searchBarVerticalPosition = 23;  // Position for search bar
            int refreshVerticalPosition = 26;    // Position for refresh button

            // Set search bar height
            this.txtSearch.Height = searchBarHeight;

            // Adjust search bar position if height changes
            int adjustedSearchPosition = searchBarVerticalPosition - ((searchBarHeight - 36) / 2);

            // Position title
            this.lblMembersTitle.Location = new System.Drawing.Point(startX, titleVerticalPosition);

            // Position search bar
            this.txtSearch.Location = new System.Drawing.Point(startX + titleWidth + spacing, adjustedSearchPosition);
            this.txtSearch.Size = new System.Drawing.Size(searchWidth, searchBarHeight);

            // Position refresh button
            this.btnRefresh.Location = new System.Drawing.Point(startX + titleWidth + spacing + searchWidth + spacing, refreshVerticalPosition);
        }

        private void CenterTable()
        {
            if (this.dgvMembers == null || this.tableContainer == null) return;

            // Calculate table size - use 95% of container width to leave margins
            int desiredWidth = (int)(this.tableContainer.Width * 0.95);
            int desiredHeight = this.tableContainer.Height - 30;

            // Set minimum and maximum constraints
            if (desiredWidth > 1400) desiredWidth = 1400;
            if (desiredWidth < 700) desiredWidth = 700;

            // Center the table horizontally and vertically
            this.dgvMembers.Width = desiredWidth;
            this.dgvMembers.Height = desiredHeight;
            this.dgvMembers.Left = (this.tableContainer.Width - this.dgvMembers.Width) / 2;
            this.dgvMembers.Top = (this.tableContainer.Height - this.dgvMembers.Height) / 2;

            // Set anchor to none for manual positioning
            this.dgvMembers.Anchor = System.Windows.Forms.AnchorStyles.None;

            // Force the table to fill columns properly
            this.dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // CONTROL DECLARATIONS
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnBlogs;
        private System.Windows.Forms.Button btnAboutUs;
        private System.Windows.Forms.Button btnContactUs;

        private System.Windows.Forms.Panel dashboardContainer;
        private System.Windows.Forms.Panel dashboardContent;

        private System.Windows.Forms.Panel greetingPanel;
        private System.Windows.Forms.Label lblGreeting;

        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel statsContainer;
        private System.Windows.Forms.FlowLayoutPanel statsFlowLayout;

        private System.Windows.Forms.Panel membersSection;
        private System.Windows.Forms.Panel membersHeader;
        private System.Windows.Forms.Panel membersHeaderContent;
        private System.Windows.Forms.Label lblMembersTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.Panel tableContainer;
        private System.Windows.Forms.DataGridView dgvMembers;

        // Stats card controls
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Panel cardActive;
        private System.Windows.Forms.Label lblActiveLabel;
        private System.Windows.Forms.Label lblActiveValue;
        private System.Windows.Forms.Panel cardNew;
        private System.Windows.Forms.Label lblNewLabel;
        private System.Windows.Forms.Label lblNewValue;
    }
}