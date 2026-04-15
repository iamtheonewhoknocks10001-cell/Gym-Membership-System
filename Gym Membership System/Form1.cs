using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class Form1 : BaseForm
    {
        private const int OverlayAlpha = 60;
        private const int VignetteAlpha = 120;
        private const float VignetteFocus = 0.65f;
        private const int GradientAlpha = 40;
        private readonly Image _backgroundImage = Properties.Resources.edited;

        private string connectionString = "Server=DESKTOP-PMQJTOJ;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";

        private string _email;
        private string _role;
        private string _username;
        private DataTable membersTable;
        private bool isLoading = false;
        private bool _showInactive = false;  // Track whether to show inactive members
        private bool _showAllMembers = false;  // Track whether to show all members (for Total Members card)
        private bool _showNewMembers = false;  // Track whether to show new members only (for New card)

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
            cardTotal.Click += (s, e) => ToggleShowAllMembers();

            cardTotal.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, cardTotal.Width - 1, cardTotal.Height - 1);
                }

                // Add indicator dot showing current filter state
                using (Brush brush = new SolidBrush(_showAllMembers ? Color.FromArgb(255, 100, 0) : Color.FromArgb(100, 100, 120)))
                {
                    e.Graphics.FillEllipse(brush, cardTotal.Width - 20, 10, 10, 10);
                }
            };

            Label totalIcon = new Label();
            totalIcon.Text = "👥";
            totalIcon.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            totalIcon.ForeColor = Color.FromArgb(100, 100, 120);
            totalIcon.Location = new Point(12, 10);
            totalIcon.Size = new Size(60, 60);
            totalIcon.Cursor = Cursors.Hand;
            totalIcon.Click += (s, e) => ToggleShowAllMembers();
            cardTotal.Controls.Add(totalIcon);

            lblTotalValue = new Label();
            lblTotalValue.Text = "0";
            lblTotalValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(50, 50, 60);
            lblTotalValue.Location = new Point(85, 15);
            lblTotalValue.Size = new Size(100, 50);
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;
            lblTotalValue.Cursor = Cursors.Hand;
            lblTotalValue.Click += (s, e) => ToggleShowAllMembers();
            cardTotal.Controls.Add(lblTotalValue);

            lblTotalLabel = new Label();
            lblTotalLabel.Text = "TOTAL MEMBERS";
            lblTotalLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTotalLabel.ForeColor = Color.Black;
            lblTotalLabel.Location = new Point(60, 70);
            lblTotalLabel.Size = new Size(150, 25);
            lblTotalLabel.Cursor = Cursors.Hand;
            lblTotalLabel.Click += (s, e) => ToggleShowAllMembers();
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
            cardActive.Click += (s, e) => ToggleShowInactive();  // Toggle inactive members

            cardActive.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, cardActive.Width - 1, cardActive.Height - 1);
                }

                // Add indicator dot showing current filter state
                using (Brush brush = new SolidBrush(_showInactive ? Color.FromArgb(255, 100, 0) : Color.FromArgb(76, 175, 80)))
                {
                    e.Graphics.FillEllipse(brush, cardActive.Width - 20, 10, 10, 10);
                }
            };

            Label activeIcon = new Label();
            activeIcon.Text = "💪";
            activeIcon.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            activeIcon.ForeColor = Color.FromArgb(76, 175, 80);
            activeIcon.Location = new Point(12, 10);
            activeIcon.Size = new Size(60, 60);
            activeIcon.Cursor = Cursors.Hand;
            activeIcon.Click += (s, e) => ToggleShowInactive();
            cardActive.Controls.Add(activeIcon);

            lblActiveValue = new Label();
            lblActiveValue.Text = "0";
            lblActiveValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblActiveValue.ForeColor = Color.FromArgb(76, 175, 80);
            lblActiveValue.Location = new Point(85, 15);
            lblActiveValue.Size = new Size(100, 50);
            lblActiveValue.TextAlign = ContentAlignment.MiddleLeft;
            lblActiveValue.Cursor = Cursors.Hand;
            lblActiveValue.Click += (s, e) => ToggleShowInactive();
            cardActive.Controls.Add(lblActiveValue);

            lblActiveLabel = new Label();
            lblActiveLabel.Text = "ACTIVE MEMBERS";
            lblActiveLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblActiveLabel.ForeColor = Color.Black;
            lblActiveLabel.Location = new Point(60, 70);
            lblActiveLabel.Size = new Size(200, 25);
            lblActiveLabel.Cursor = Cursors.Hand;
            lblActiveLabel.Click += (s, e) => ToggleShowInactive();
            cardActive.Controls.Add(lblActiveLabel);

            statsFlowLayout.Controls.Add(cardActive);
        }
        private async void ToggleShowAllMembers()
        {
            _showAllMembers = !_showAllMembers;
            _showInactive = false;  // Reset Active Members filter when Total card is clicked
            _showNewMembers = false; // Reset New Members filter when Total card is clicked

            // Visual feedback - flash the card
            cardTotal.BackColor = Color.FromArgb(255, 250, 240);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += (s, e) =>
            {
                cardTotal.BackColor = Color.White;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

            // Force refresh of the card's paint to update the indicator dot
            cardTotal.Invalidate();
            cardActive.Invalidate();
            cardNew.Invalidate();

            // Refresh the member list with the new filter
            await RefreshMembers();
        }
        private void CreateNewMembersCard()
        {
            cardNew = new Panel();
            cardNew.BackColor = Color.White;
            cardNew.Size = new Size(240, 110);
            cardNew.Margin = new Padding(12, 5, 12, 5);
            cardNew.Padding = new Padding(10);
            cardNew.Cursor = Cursors.Hand;
            cardNew.Click += (s, e) => ToggleShowNewMembers();  // Show new members only

            cardNew.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 240), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, cardNew.Width - 1, cardNew.Height - 1);
                }

                // Add indicator dot showing current filter state
                using (Brush brush = new SolidBrush(_showNewMembers ? Color.FromArgb(255, 100, 0) : Color.Purple))
                {
                    e.Graphics.FillEllipse(brush, cardNew.Width - 20, 10, 10, 10);
                }
            };

            Label newIcon = new Label();
            newIcon.Text = "✨";
            newIcon.Font = new Font("Segoe UI", 32F, FontStyle.Regular);
            newIcon.ForeColor = Color.FromArgb(255, 150, 0);
            newIcon.Location = new Point(12, 10);
            newIcon.Size = new Size(60, 60);
            newIcon.Cursor = Cursors.Hand;
            newIcon.Click += (s, e) => ToggleShowNewMembers();
            cardNew.Controls.Add(newIcon);

            lblNewValue = new Label();
            lblNewValue.Text = "0";
            lblNewValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblNewValue.ForeColor = Color.FromArgb(255, 150, 0);
            lblNewValue.Location = new Point(85, 15);
            lblNewValue.Size = new Size(100, 50);
            lblNewValue.TextAlign = ContentAlignment.MiddleLeft;
            lblNewValue.Cursor = Cursors.Hand;
            lblNewValue.Click += (s, e) => ToggleShowNewMembers();
            cardNew.Controls.Add(lblNewValue);

            lblNewLabel = new Label();
            lblNewLabel.Text = "NEW THIS MONTH";
            lblNewLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblNewLabel.ForeColor = Color.Black;
            lblNewLabel.Location = new Point(60, 70);
            lblNewLabel.Size = new Size(200, 25);
            lblNewLabel.Cursor = Cursors.Hand;
            lblNewLabel.Click += (s, e) => ToggleShowNewMembers();
            cardNew.Controls.Add(lblNewLabel);

            statsFlowLayout.Controls.Add(cardNew);
        }
        private async void ToggleShowInactive()
        {
            _showInactive = !_showInactive;
            _showAllMembers = false;  // Reset Total Members filter when Active card is clicked
            _showNewMembers = false;  // Reset New Members filter when Active card is clicked

            // Visual feedback - flash the card
            cardActive.BackColor = Color.FromArgb(255, 250, 240);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += (s, e) =>
            {
                cardActive.BackColor = Color.White;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

            // Force refresh of the card's paint to update the indicator dot
            cardActive.Invalidate();
            cardTotal.Invalidate();
            cardNew.Invalidate();

            // Refresh the member list with the new filter
            await RefreshMembers();
        }
        private async void ToggleShowNewMembers()
        {
            _showNewMembers = !_showNewMembers;

            // Reset other filters when New card is clicked
            _showAllMembers = false;
            _showInactive = false;

            // Visual feedback - flash the card
            cardNew.BackColor = Color.FromArgb(255, 250, 240);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200;
            timer.Tick += (s, e) =>
            {
                cardNew.BackColor = Color.White;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

            // Force refresh of all cards' paint to update indicator dots
            cardNew.Invalidate();
            cardTotal.Invalidate();
            cardActive.Invalidate();

            // Refresh the member list with the new filter
            await RefreshMembers();
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
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvMembers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMembers.ColumnHeadersHeight = 45;

            dgvMembers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 100, 0);  // Orange

            dgvMembers.DefaultCellStyle.BackColor = Color.White;
            dgvMembers.DefaultCellStyle.ForeColor = Color.Black;
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.PaleGreen;
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMembers.DefaultCellStyle.Padding = new Padding(10);
            dgvMembers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
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

                    // TOTAL MEMBERS - Count ALL members
                    string totalQuery = "SELECT COUNT(*) FROM Members";
                    using (SqlCommand cmd = new SqlCommand(totalQuery, conn))
                    {
                        int total = (int)await cmd.ExecuteScalarAsync();
                        UpdateLabelText(lblTotalValue, total.ToString());
                    }

                    // ACTIVE MEMBERS - Count only active members (IsActive = 1)
                    string activeQuery = "SELECT COUNT(*) FROM Members WHERE IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(activeQuery, conn))
                    {
                        int active = (int)await cmd.ExecuteScalarAsync();
                        UpdateLabelText(lblActiveValue, active.ToString());
                    }

                    // NEW MEMBERS THIS MONTH - Count members who joined this month (regardless of status)
                    // This updates correctly when a new member from this month is deleted
                    string newQuery = "SELECT COUNT(*) FROM Members WHERE JoinDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)";
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
                // First, update member status based on attendance
                await UpdateMemberStatusBasedOnAttendance();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query;
                    if (_showNewMembers)
                    {
                        query = @"SELECT 
                            MemberID,
                            'MEM-' + RIGHT('0000' + CAST(MemberID AS VARCHAR(4)), 4) AS ID,
                            FirstName AS [First Name], 
                            LastName AS [Last Name], 
                            Email, 
                            Phone,
                            MembershipType AS [Type], 
                            FORMAT(JoinDate, 'MM/dd/yyyy') AS [Join Date],
                            CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS [Status]
                        FROM Members 
                        WHERE JoinDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)
                        ORDER BY JoinDate DESC";
                    }
                    else if (_showAllMembers)
                    {
                        query = @"SELECT 
                            MemberID,
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
                    }
                    else
                    {
                        query = @"SELECT 
                            MemberID,
                            'MEM-' + RIGHT('0000' + CAST(MemberID AS VARCHAR(4)), 4) AS ID,
                            FirstName AS [First Name], 
                            LastName AS [Last Name], 
                            Email, 
                            Phone,
                            MembershipType AS [Type], 
                            FORMAT(JoinDate, 'MM/dd/yyyy') AS [Join Date],
                            CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS [Status]
                        FROM Members 
                        WHERE IsActive = 1
                        ORDER BY JoinDate DESC";
                    }

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

            if (columns.Contains("MemberID"))
                columns["MemberID"].Visible = false;

            columns["ID"].HeaderText = "ID";
            columns["ID"].Width = 80;
            columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            columns["First Name"].HeaderText = "First Name";
            columns["First Name"].Width = 100;

            columns["Last Name"].HeaderText = "Last Name";
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
                        row.Cells["Status"].Style.ForeColor = Color.FromArgb(244, 67, 54);
                        row.Cells["Status"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    }
                }
            }
        }
        private async Task UpdateMemberStatusBasedOnAttendance()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Update members to Inactive if they haven't attended within their subscription period
                    string query = @"
                UPDATE Members 
                SET IsActive = 0 
                WHERE MemberID IN (
                    SELECT m.MemberID
                    FROM Members m
                    LEFT JOIN (
                        SELECT MemberID, MAX(AttendanceDate) AS LastAttendance
                        FROM Attendance
                        GROUP BY MemberID
                    ) a ON m.MemberID = a.MemberID
                    WHERE 
                        (UPPER(m.MembershipType) = 'BASIC' AND (a.LastAttendance IS NULL OR a.LastAttendance < DATEADD(day, -14, GETDATE())))
                        OR (UPPER(m.MembershipType) = 'PREMIUM' AND (a.LastAttendance IS NULL OR a.LastAttendance < DATEADD(month, -2, GETDATE())))
                )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int updated = await cmd.ExecuteNonQueryAsync();
                        if (updated > 0)
                        {
                            Console.WriteLine($"Updated {updated} members to inactive due to attendance inactivity");
                        }
                    }

                    // Reactivate members who have recent attendance
                    string reactivateQuery = @"
                UPDATE Members 
                SET IsActive = 1 
                WHERE MemberID IN (
                    SELECT m.MemberID
                    FROM Members m
                    INNER JOIN Attendance a ON m.MemberID = a.MemberID
                    WHERE 
                        (UPPER(m.MembershipType) = 'BASIC' AND a.AttendanceDate >= DATEADD(day, -14, GETDATE()))
                        OR (UPPER(m.MembershipType) = 'PREMIUM' AND a.AttendanceDate >= DATEADD(month, -2, GETDATE()))
                    GROUP BY m.MemberID
                )";

                    using (SqlCommand cmd = new SqlCommand(reactivateQuery, conn))
                    {
                        int reactivated = await cmd.ExecuteNonQueryAsync();
                        if (reactivated > 0)
                        {
                            Console.WriteLine($"Reactivated {reactivated} members due to recent attendance");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating member status from attendance: {ex.Message}");
            }
        }

        public async Task RefreshMembers()
        {
            ShowLoading(true);
            UpdateLoadingText("Refreshing data... 🔄");

            try
            {
                await UpdateMemberStatusBasedOnAttendance(); // Add this line
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dgvMembers.SelectedRows[0];
            string memberId = selectedRow.Cells["ID"].Value?.ToString() ?? "";
            string memberName = $"{selectedRow.Cells["First Name"].Value} {selectedRow.Cells["Last Name"].Value}";
            string currentStatus = selectedRow.Cells["Status"].Value?.ToString() ?? "";

            // For permanent deletion, we don't need to check if inactive
            DialogResult result = MessageBox.Show(
                $"⚠️ PERMANENT DELETE ⚠️\n\n" +
                $"Are you sure you want to permanently delete {memberName} (ID: {memberId})?\n\n" +
                $"This will:\n" +
                $"• Permanently remove the member from the database\n" +
                $"• Delete ALL attendance records\n\n" +
                $"This action CANNOT be undone!",
                "Confirm Permanent Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (result == DialogResult.Yes)
            {
                await PermanentDeleteMember(memberId, memberName);
            }
        }

        private async Task PermanentDeleteMember(string memberId, string memberName)
        {
            ShowLoading(true);
            UpdateLoadingText($"Permanently deleting {memberName}... 🗑️");

            try
            {
                int actualMemberId = 0;
                if (memberId.StartsWith("MEM-"))
                {
                    string numericPart = memberId.Substring(4);
                    int.TryParse(numericPart, out actualMemberId);
                }
                else
                {
                    int.TryParse(memberId, out actualMemberId);
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // First, delete attendance records
                            string deleteAttendanceQuery = "DELETE FROM Attendance WHERE MemberID = @MemberID";
                            using (SqlCommand deleteAttendanceCmd = new SqlCommand(deleteAttendanceQuery, conn, transaction))
                            {
                                deleteAttendanceCmd.Parameters.AddWithValue("@MemberID", actualMemberId);
                                await deleteAttendanceCmd.ExecuteNonQueryAsync();
                            }

                            // Then, permanently delete the member
                            string deleteMemberQuery = "DELETE FROM Members WHERE MemberID = @MemberID";
                            using (SqlCommand deleteMemberCmd = new SqlCommand(deleteMemberQuery, conn, transaction))
                            {
                                deleteMemberCmd.Parameters.AddWithValue("@MemberID", actualMemberId);
                                int rowsAffected = await deleteMemberCmd.ExecuteNonQueryAsync();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    UpdateLoadingText("Permanent deletion complete! ✓");
                                    await Task.Delay(500);

                                    MessageBox.Show(
                                        $"{memberName} (ID: {memberId}) has been PERMANENTLY DELETED from the system.\n\n" +
                                        "All their attendance records have also been deleted.\n\n" +
                                        "This action cannot be undone!",
                                        "Member Permanently Deleted",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                    await RefreshMembers();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Unable to delete member. Please try again.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"Transaction failed: {ex.Message}", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting member: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private void dgvMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

                int memberId = 0;

                if (row.Cells["MemberID"].Value != null)
                {
                    memberId = Convert.ToInt32(row.Cells["MemberID"].Value);
                }
                else
                {
                    string memberIdString = row.Cells["ID"].Value?.ToString() ?? "";
                    if (memberIdString.StartsWith("MEM-"))
                    {
                        string numericPart = memberIdString.Substring(4);
                        int.TryParse(numericPart, out memberId);
                    }
                }

                if (memberId > 0)
                {
                    try
                    {
                        BoardUpdate updateForm = new BoardUpdate(memberId, connectionString);
                        updateForm.ShowDialog();
                        RefreshMembers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening update form: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to identify member ID.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AddMember addMemberForm = new AddMember())
            {
                addMemberForm.ShowDialog();
            }
            // Make sure Form1 is visible and refreshed
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Maximized;
            _ = RefreshMembers();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormPayments paymentForm = new FormPayments();
                paymentForm.ShowDialog();
                this.Show();
                this.BringToFront();
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show($"Error opening Payment Form: {ex.Message}\n\nMake sure the FormPayments class exists.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Attendance attendanceForm = new Attendance(connectionString);
                attendanceForm.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show($"Error opening Attendance Form: {ex.Message}",
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