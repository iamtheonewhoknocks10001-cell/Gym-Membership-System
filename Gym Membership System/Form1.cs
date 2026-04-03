using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Timer = System.Windows.Forms.Timer;

namespace Gym_Membership_System
{
    public partial class Form1 : BaseForm
    {
        private const int OverlayAlpha = 60;
        private const int VignetteAlpha = 120;
        private const float VignetteFocus = 0.65f;
        private const int GradientAlpha = 40;
        private readonly Image _backgroundImage = Properties.Resources.edited;

        private string connectionString = "Server=DESKTOP-AH6OHHK;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        private string _email;
        private string _role;
        private string _username;
        private DataTable membersTable;
        private bool isLoading = false;

        private Panel loadingPanel;
        private Label loadingLabel;

        public Form1(string email, string role, string username)
        {
            InitializeComponent();

            _email = email ?? "admin@gym.com";
            _role = role ?? "Admin";
            _username = username ?? "Admin";

            this.BackgroundImage = null;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            CreateLoadingIndicator();
            SetupModernDashboard();

            this.Load += Form1_Load;
            this.Resize += (s, e) => { CenterContent(); CenterTable(); };
            this.Shown += (s, e) => CenterTable();

            ConfigureDataGridView();
        }

        private void SetupModernDashboard()
        {
            statsFlowLayout.Controls.Clear();
            CreateTotalMembersCard();
            CreateActiveMembersCard();
            CreateNewMembersCard();
            statsFlowLayout.PerformLayout();
        }

        private void CreateTotalMembersCard()
        {
            cardTotal = new Panel();
            cardTotal.BackColor = Color.White;
            cardTotal.Size = new Size(240, 110);
            cardTotal.Margin = new Padding(12, 5, 12, 5);
            cardTotal.Padding = new Padding(10);
            cardTotal.Cursor = Cursors.Hand;
            cardTotal.Click += (s, e) => ShowMemberDetails("Total Members");

            cardTotal.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, cardTotal.Width - 1, cardTotal.Height - 1);
                }
            };

            Label totalIcon = new Label();
            totalIcon.Text = "👥";
            totalIcon.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            totalIcon.ForeColor = Color.FromArgb(100, 100, 120);
            totalIcon.Location = new Point(12, 25);
            totalIcon.Size = new Size(60, 60);
            cardTotal.Controls.Add(totalIcon);

            lblTotalValue = new Label();
            lblTotalValue.Text = "0";
            lblTotalValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(50, 50, 60);
            lblTotalValue.Location = new Point(85, 25);
            lblTotalValue.Size = new Size(100, 45);
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;
            cardTotal.Controls.Add(lblTotalValue);

            lblTotalLabel = new Label();
            lblTotalLabel.Text = "TOTAL MEMBERS";
            lblTotalLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTotalLabel.ForeColor = Color.FromArgb(150, 150, 160);
            lblTotalLabel.Location = new Point(85, 70);
            lblTotalLabel.Size = new Size(120, 20);
            cardTotal.Controls.Add(lblTotalLabel);

            statsFlowLayout.Controls.Add(cardTotal);
        }

        private void CreateActiveMembersCard()
        {
            cardActive = new Panel();
            cardActive.BackColor = Color.White;
            cardActive.Size = new Size(240, 110);
            cardActive.Margin = new Padding(12, 5, 12, 5);
            cardActive.Padding = new Padding(10);
            cardActive.Cursor = Cursors.Hand;
            cardActive.Click += (s, e) => ShowMemberDetails("Active Members");

            cardActive.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, cardActive.Width - 1, cardActive.Height - 1);
                }
            };

            Label activeIcon = new Label();
            activeIcon.Text = "💪";
            activeIcon.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            activeIcon.ForeColor = Color.FromArgb(76, 175, 80);
            activeIcon.Location = new Point(12, 25);
            activeIcon.Size = new Size(60, 60);
            cardActive.Controls.Add(activeIcon);

            lblActiveValue = new Label();
            lblActiveValue.Text = "0";
            lblActiveValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblActiveValue.ForeColor = Color.FromArgb(76, 175, 80);
            lblActiveValue.Location = new Point(85, 25);
            lblActiveValue.Size = new Size(100, 45);
            lblActiveValue.TextAlign = ContentAlignment.MiddleLeft;
            cardActive.Controls.Add(lblActiveValue);

            lblActiveLabel = new Label();
            lblActiveLabel.Text = "ACTIVE MEMBERS";
            lblActiveLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblActiveLabel.ForeColor = Color.FromArgb(150, 150, 160);
            lblActiveLabel.Location = new Point(85, 70);
            lblActiveLabel.Size = new Size(120, 20);
            cardActive.Controls.Add(lblActiveLabel);

            statsFlowLayout.Controls.Add(cardActive);
        }

        private void CreateNewMembersCard()
        {
            cardNew = new Panel();
            cardNew.BackColor = Color.White;
            cardNew.Size = new Size(240, 110);
            cardNew.Margin = new Padding(12, 5, 12, 5);
            cardNew.Padding = new Padding(10);
            cardNew.Cursor = Cursors.Hand;
            cardNew.Click += (s, e) => ShowMemberDetails("New Members");

            cardNew.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, cardNew.Width - 1, cardNew.Height - 1);
                }
            };

            Label newIcon = new Label();
            newIcon.Text = "✨";
            newIcon.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            newIcon.ForeColor = Color.FromArgb(255, 150, 0);
            newIcon.Location = new Point(12, 25);
            newIcon.Size = new Size(60, 60);
            cardNew.Controls.Add(newIcon);

            lblNewValue = new Label();
            lblNewValue.Text = "0";
            lblNewValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblNewValue.ForeColor = Color.FromArgb(255, 150, 0);
            lblNewValue.Location = new Point(85, 25);
            lblNewValue.Size = new Size(100, 45);
            lblNewValue.TextAlign = ContentAlignment.MiddleLeft;
            cardNew.Controls.Add(lblNewValue);

            lblNewLabel = new Label();
            lblNewLabel.Text = "NEW THIS MONTH";
            lblNewLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblNewLabel.ForeColor = Color.FromArgb(150, 150, 160);
            lblNewLabel.Location = new Point(85, 70);
            lblNewLabel.Size = new Size(120, 20);
            cardNew.Controls.Add(lblNewLabel);

            statsFlowLayout.Controls.Add(cardNew);
        }

        private void ShowMemberDetails(string category)
        {
            MessageBox.Show($"Showing detailed information for {category}",
                "Analytics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateLoadingIndicator()
        {
            loadingPanel = new Panel();
            loadingPanel.BackColor = Color.FromArgb(40, 40, 45);
            loadingPanel.Size = new Size(200, 80);
            loadingPanel.BorderStyle = BorderStyle.FixedSingle;
            loadingPanel.Visible = false;

            loadingLabel = new Label();
            loadingLabel.Text = "Loading data... ⏳";
            loadingLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            loadingLabel.ForeColor = Color.White;
            loadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            loadingLabel.Dock = DockStyle.Fill;

            loadingPanel.Controls.Add(loadingLabel);
            this.Controls.Add(loadingPanel);
        }

        private void ShowLoading(bool show)
        {
            if (loadingPanel.InvokeRequired)
            {
                loadingPanel.Invoke(new Action(() => ShowLoading(show)));
                return;
            }

            loadingPanel.Visible = show;
            if (show)
            {
                loadingPanel.BringToFront();
                loadingPanel.Left = (this.ClientSize.Width - loadingPanel.Width) / 2;
                loadingPanel.Top = (this.ClientSize.Height - loadingPanel.Height) / 2;
            }
        }

        private void UpdateLoadingText(string text)
        {
            if (loadingLabel.InvokeRequired)
            {
                loadingLabel.Invoke(new Action(() => loadingLabel.Text = text));
                return;
            }
            loadingLabel.Text = text;
        }

        private void ConfigureDataGridView()
        {
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvMembers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.ForeColor = Color.Black;
            dgvMembers.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.ReadOnly = true;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMembers.GridColor = Color.FromArgb(235, 235, 240);
            dgvMembers.RowTemplate.Height = 40;
            dgvMembers.RowsDefaultCellStyle.Padding = new Padding(10);
            dgvMembers.Dock = DockStyle.None;

            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 70);
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.ColumnHeadersHeight = 45;

            dgvMembers.DefaultCellStyle.BackColor = Color.White;
            dgvMembers.DefaultCellStyle.ForeColor = Color.Black;
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 245, 235);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 100, 0);
            dgvMembers.DefaultCellStyle.Padding = new Padding(10);
            dgvMembers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 255);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            SetGreeting();
            CenterContent();
            this.Text = $"FitWare Admin Panel - {_role}";

            ShowLoading(true);
            UpdateLoadingText("Loading members... 📋");

            try
            {
                await LoadDataAsync();
                UpdateLoadingText("Loading complete! ✓");
                await Task.Delay(500);
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private async Task LoadDataAsync()
        {
            if (isLoading) return;
            isLoading = true;

            try
            {
                UpdateLoadingText("Loading members... 📋");
                await LoadMembersAsync();

                UpdateLoadingText("Loading statistics... 📊");
                await UpdateStatsAsync();

                await UpdateTrends();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task UpdateTrends()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string previousMonthQuery = "SELECT COUNT(*) FROM Members WHERE JoinDate < DATEADD(month, -1, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(previousMonthQuery, conn))
                    {
                        int previousTotal = (int)await cmd.ExecuteScalarAsync();
                        int currentTotal = int.Parse(lblTotalValue.Text);

                        if (previousTotal > 0)
                        {
                            double percentChange = ((double)(currentTotal - previousTotal) / previousTotal) * 100;
                            // Update trend if needed
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating trends: {ex.Message}");
            }
        }

        private void SetGreeting()
        {
            int hour = DateTime.Now.Hour;
            string greeting;
            string icon;

            if (hour >= 5 && hour < 12)
            {
                greeting = "Good Morning";
                icon = "🌅";
            }
            else if (hour >= 12 && hour < 17)
            {
                greeting = "Good Afternoon";
                icon = "☀️";
            }
            else if (hour >= 17 && hour < 21)
            {
                greeting = "Good Evening";
                icon = "🌆";
            }
            else
            {
                greeting = "Good Night";
                icon = "🌙";
            }

            string displayName = _username;
            if (!string.IsNullOrEmpty(displayName) && displayName.Length > 0)
            {
                displayName = char.ToUpper(displayName[0]) + displayName.Substring(1).ToLower();
            }

            lblGreeting.Text = $"{icon}  {greeting}, {displayName}!";
        }

        private async Task UpdateStatsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string totalQuery = "SELECT COUNT(*) FROM Members";
                    using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
                    {
                        int total = (int)await cmd.ExecuteScalarAsync();
                        UpdateLabelText(lblTotalValue, total.ToString());
                    }

                    string activeQuery = "SELECT COUNT(*) FROM Members WHERE IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(activeQuery, conn))
                    {
                        int active = (int)await cmd.ExecuteScalarAsync();
                        UpdateLabelText(lblActiveValue, active.ToString());
                    }

                    string newQuery = "SELECT COUNT(*) FROM Members WHERE JoinDate >= DATEADD(month, -1, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(newQuery, conn))
                    {
                        int newMembers = (int)await cmd.ExecuteScalarAsync();
                        UpdateLabelText(lblNewValue, newMembers.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating stats: {ex.Message}");
            }
        }

        private void UpdateLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => label.Text = text));
            }
            else
            {
                label.Text = text;
            }
        }

        private void CenterContent()
        {
            int formCenterX = this.ClientSize.Width / 2;
            lblGreeting.Left = formCenterX - lblGreeting.Width / 2;

            if (statsFlowLayout != null && statsFlowLayout.Width > 0)
            {
                statsFlowLayout.Left = (statsPanel.Width - statsFlowLayout.Width) / 2;
            }

            if (loadingPanel != null && loadingPanel.Visible)
            {
                loadingPanel.Left = (this.ClientSize.Width - loadingPanel.Width) / 2;
                loadingPanel.Top = (this.ClientSize.Height - loadingPanel.Height) / 2;
            }
        }

        private async Task LoadMembersAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT 
                                        'MEM-' + RIGHT('0000' + CAST(MemberID AS VARCHAR(4)), 4) AS ID,
                                        FirstName AS [First Name], 
                                        LastName AS [Last Name], 
                                        Email, 
                                        Phone,
                                        MembershipType AS [Type], 
                                        FORMAT(JoinDate, 'MM/dd/yyyy') AS [Join Date],
                                        CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS [Status]
                                    FROM Members 
                                    ORDER BY JoinDate DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();

                    await Task.Run(() => adapter.Fill(dt));

                    this.BeginInvoke(new Action(() =>
                    {
                        membersTable = dt;
                        dgvMembers.DataSource = dt;
                        FormatColumns();
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatColumns()
        {
            if (dgvMembers.Columns.Count == 0) return;

            var columns = dgvMembers.Columns;

            columns["ID"].HeaderText = "ID";
            columns["ID"].Width = 80;
            columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            columns["First Name"].HeaderText = "First";
            columns["First Name"].Width = 100;

            columns["Last Name"].HeaderText = "Last";
            columns["Last Name"].Width = 100;

            columns["Email"].Width = 200;

            columns["Phone"].Width = 120;

            columns["Type"].HeaderText = "Type";
            columns["Type"].Width = 80;
            columns["Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            columns["Join Date"].HeaderText = "Joined";
            columns["Join Date"].Width = 90;
            columns["Join Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            columns["Status"].Width = 80;
            columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewRow row in dgvMembers.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    if (status == "Active")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(76, 175, 80);
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(255, 100, 100);
                    }
                }
            }
        }

        public async Task RefreshMembers()
        {
            ShowLoading(true);
            UpdateLoadingText("Refreshing data... 🔄");

            try
            {
                await LoadMembersAsync();
                await UpdateStatsAsync();
                await UpdateTrends();
                UpdateLoadingText("Refresh complete! ✓");
                await Task.Delay(300);
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshMembers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (membersTable != null)
            {
                string searchTerm = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    membersTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    membersTable.DefaultView.RowFilter = $"[First Name] LIKE '%{searchTerm}%' OR " +
                                                          $"[Last Name] LIKE '%{searchTerm}%' OR " +
                                                          $"Email LIKE '%{searchTerm}%' OR " +
                                                          $"ID LIKE '%{searchTerm}%' OR " +
                                                          $"[Type] LIKE '%{searchTerm}%'";
                }
            }
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
                string memberId = row.Cells["ID"].Value?.ToString() ?? "";
                MessageBox.Show($"Edit member {memberId}",
                    "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            AddMember addMemberForm = new AddMember();
            addMemberForm.Show();
            this.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Manage Member functionality for {_role}.", "Manage Member",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTrainers_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Trainers functionality for {_role}.", "Trainers",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            try
            {
                FormPayments paymentForm = new FormPayments();
                paymentForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Payment Form: {ex.Message}\n\nMake sure the FormPayments class exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string displayName = _username;

            string[] logoutMessages = {
                $"Have a good rest, {displayName}! 😴",
                $"See you next time, {displayName}! 👋",
                $"Take care and rest well, {displayName}! 🌙",
                $"Great work today, {displayName}! Time to recharge! ⚡",
                $"Until next time, {displayName}! Stay strong! 💪",
                $"Logging out... Have a peaceful rest, {displayName}! ✨",
                $"Well done today, {displayName}! Rest up! 🌟",
                $"See you soon, {displayName}! Keep crushing it! 🔥",
                $"Time to relax, {displayName}! You earned it! 🏆",
                $"Goodnight, {displayName}! Sweet dreams! 🌙✨"
            };

            Random random = new Random();
            string randomLogoutMessage = logoutMessages[random.Next(logoutMessages.Length)];

            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(randomLogoutMessage, "Goodbye!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Form f in Application.OpenForms)
                {
                    if (f is LOGIN)
                    {
                        f.Show();
                        break;
                    }
                }

                this.Close();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            if (_backgroundImage != null)
            {
                float ratio = Math.Max((float)rect.Width / _backgroundImage.Width,
                                      (float)rect.Height / _backgroundImage.Height);
                int drawW = (int)(_backgroundImage.Width * ratio);
                int drawH = (int)(_backgroundImage.Height * ratio);
                int drawX = (rect.Width - drawW) / 2;
                int drawY = (rect.Height - drawH) / 2;
                g.DrawImage(_backgroundImage, new Rectangle(drawX, drawY, drawW, drawH));
            }

            using (var overlay = new SolidBrush(Color.FromArgb(OverlayAlpha, 0, 0, 0)))
                g.FillRectangle(overlay, rect);

            using (var path = new GraphicsPath())
            {
                float inflateW = rect.Width * 0.5f;
                float inflateH = rect.Height * 0.5f;
                path.AddEllipse(rect.X - inflateW / 2, rect.Y - inflateH / 2,
                    rect.Width + inflateW, rect.Height + inflateH);
                using (var pgb = new PathGradientBrush(path))
                {
                    pgb.CenterColor = Color.FromArgb(0, 0, 0, 0);
                    pgb.SurroundColors = new[] { Color.FromArgb(VignetteAlpha, 0, 0, 0) };
                    pgb.FocusScales = new PointF(VignetteFocus, VignetteFocus);
                    g.FillRectangle(pgb, rect);
                }
            }

            using (var lg = new LinearGradientBrush(rect,
                Color.FromArgb(GradientAlpha, 0, 0, 0),
                Color.FromArgb(0, 0, 0, 0), 90f))
                g.FillRectangle(lg, rect);
        }
    }
}