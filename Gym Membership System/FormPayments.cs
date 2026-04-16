using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class FormPayments : Form
    {
        private string connectionString = "Server=DESKTOP-PMQJTOJ;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private DataTable paymentsTable;
        private string currentFilterType = "All"; // "All", "Basic", "Premium"
        private bool _isDarkMode = true;

        public FormPayments()
        {
            InitializeComponent();
            AttachEventHandlers();

            // Subscribe to theme changes
            ThemeManager.ThemeChanged += OnThemeChanged;
        }

        private void OnThemeChanged(bool isDarkMode)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnThemeChanged(isDarkMode)));
                return;
            }

            _isDarkMode = isDarkMode;
            ApplyTheme(isDarkMode);
        }

        public void ApplyTheme(bool isDarkMode)
        {
            if (isDarkMode)
            {
                // ========== DARK MODE ==========
                this.BackColor = Color.FromArgb(30, 30, 35);

                // Labels
                lblTitle.ForeColor = Color.FromArgb(255, 100, 50);
                lblTotalAmount.ForeColor = Color.FromArgb(220, 220, 230);
                lblTotalPayments.ForeColor = Color.FromArgb(220, 220, 230);
                lblFilterDate.ForeColor = Color.FromArgb(220, 220, 230);

                // Buttons
                btnRefresh.BackColor = Color.FromArgb(70, 90, 120);
                btnRefresh.ForeColor = Color.White;
                btnPrintReceipt.BackColor = Color.FromArgb(80, 80, 90);
                btnPrintReceipt.ForeColor = Color.White;
                btnBack.BackColor = Color.FromArgb(80, 80, 90);
                btnBack.ForeColor = Color.White;
                btnApplyFilter.BackColor = Color.FromArgb(70, 90, 120);
                btnApplyFilter.ForeColor = Color.White;

                // Plan buttons
                if (currentFilterType == "Basic")
                {
                    btnBasic.BackColor = Color.FromArgb(255, 100, 50);
                }
                else
                {
                    btnBasic.BackColor = Color.FromArgb(33, 150, 243);
                }
                btnBasic.ForeColor = Color.White;

                if (currentFilterType == "Premium")
                {
                    btnPremium.BackColor = Color.FromArgb(255, 100, 50);
                }
                else
                {
                    btnPremium.BackColor = Color.FromArgb(156, 39, 176);
                }
                btnPremium.ForeColor = Color.White;

                // Search box
                txtSearch.BackColor = Color.FromArgb(55, 55, 62);
                txtSearch.ForeColor = Color.FromArgb(220, 220, 230);

                // DateTimePicker
                dtpFilterDate.BackColor = Color.FromArgb(55, 55, 62);
                dtpFilterDate.ForeColor = Color.FromArgb(220, 220, 230);

                // DataGridView
                dgvPayments.BackgroundColor = Color.FromArgb(45, 45, 52);
                dgvPayments.GridColor = Color.FromArgb(55, 55, 65);
                dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 58);
                dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 200, 210);
                dgvPayments.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 52);
                dgvPayments.DefaultCellStyle.ForeColor = Color.FromArgb(200, 200, 210);
                dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(48, 48, 55);
                dgvPayments.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 48);
                dgvPayments.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 200, 210);
            }
            else
            {
                // ========== LIGHT MODE ==========
                this.BackColor = Color.FromArgb(245, 245, 250);

                // Labels
                lblTitle.ForeColor = Color.FromArgb(255, 100, 0);
                lblTotalAmount.ForeColor = Color.FromArgb(50, 50, 60);
                lblTotalPayments.ForeColor = Color.FromArgb(50, 50, 60);
                lblFilterDate.ForeColor = Color.FromArgb(50, 50, 60);

                // Buttons
                btnRefresh.BackColor = Color.FromArgb(100, 120, 150);
                btnRefresh.ForeColor = Color.White;
                btnPrintReceipt.BackColor = Color.FromArgb(100, 100, 100);
                btnPrintReceipt.ForeColor = Color.White;
                btnBack.BackColor = Color.FromArgb(100, 100, 100);
                btnBack.ForeColor = Color.White;
                btnApplyFilter.BackColor = Color.FromArgb(100, 120, 150);
                btnApplyFilter.ForeColor = Color.White;

                // Plan buttons
                if (currentFilterType == "Basic")
                {
                    btnBasic.BackColor = Color.FromArgb(255, 100, 0);
                }
                else
                {
                    btnBasic.BackColor = Color.FromArgb(33, 150, 243);
                }
                btnBasic.ForeColor = Color.White;

                if (currentFilterType == "Premium")
                {
                    btnPremium.BackColor = Color.FromArgb(255, 100, 0);
                }
                else
                {
                    btnPremium.BackColor = Color.FromArgb(156, 39, 176);
                }
                btnPremium.ForeColor = Color.White;

                // Search box
                txtSearch.BackColor = Color.White;
                txtSearch.ForeColor = Color.Black;

                // DateTimePicker
                dtpFilterDate.BackColor = Color.White;
                dtpFilterDate.ForeColor = Color.Black;

                // DataGridView
                dgvPayments.BackgroundColor = Color.White;
                dgvPayments.GridColor = Color.FromArgb(235, 235, 240);
                dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
                dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 70);
                dgvPayments.DefaultCellStyle.BackColor = Color.White;
                dgvPayments.DefaultCellStyle.ForeColor = Color.Black;
                dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 252);
                dgvPayments.RowHeadersDefaultCellStyle.BackColor = Color.White;
                dgvPayments.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            }

            // Refresh the DataGridView
            dgvPayments.Refresh();
            this.Invalidate();
        }

        private void AttachEventHandlers()
        {
            this.Load += FormPayments_Load;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnPrintReceipt.Click += BtnPrintReceipt_Click;
            this.btnBack.Click += BtnBack_Click;
            this.btnApplyFilter.Click += BtnApplyFilter_Click;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvPayments.CellDoubleClick += DgvPayments_CellDoubleClick;
            this.btnBasic.Click += BtnBasic_Click;
            this.btnPremium.Click += BtnPremium_Click;
        }

        private async void FormPayments_Load(object sender, EventArgs e)
        {
            // Apply current theme
            _isDarkMode = ThemeManager.IsDarkMode;
            ApplyTheme(_isDarkMode);

            // Set default date to show all payments
            if (dtpFilterDate != null)
            {
                dtpFilterDate.Value = new DateTime(2020, 1, 1);
            }

            await LoadPaymentsAsync();
            await UpdateStatisticsAsync();
        }

        private async Task LoadPaymentsAsync()
        {
            try
            {
                if (dgvPayments == null || dgvPayments.IsDisposed) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = @"SELECT 
                                p.PaymentID,
                                p.ReceiptNumber,
                                m.FirstName + ' ' + m.LastName AS MemberName,
                                m.MembershipType,
                                p.PaymentDate,
                                p.DueDate
                            FROM Payments p
                            LEFT JOIN Members m ON p.MemberID = m.MemberID
                            ORDER BY p.PaymentDate DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    paymentsTable = dt;

                    if (dgvPayments.InvokeRequired)
                    {
                        dgvPayments.Invoke(new Action(() =>
                        {
                            dgvPayments.DataSource = dt;
                            FormatPaymentColumns();
                        }));
                    }
                    else
                    {
                        dgvPayments.DataSource = dt;
                        FormatPaymentColumns();
                    }

                    ApplyFilters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payments: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatPaymentColumns()
        {
            if (dgvPayments == null || dgvPayments.Columns.Count == 0) return;

            if (dgvPayments.Columns.Contains("PaymentID"))
                dgvPayments.Columns["PaymentID"].Visible = false;

            if (dgvPayments.Columns.Contains("MembershipType"))
                dgvPayments.Columns["MembershipType"].Visible = false;

            if (dgvPayments.Columns.Contains("ReceiptNumber"))
            {
                dgvPayments.Columns["ReceiptNumber"].HeaderText = "Receipt #";
                dgvPayments.Columns["ReceiptNumber"].Width = 150;
                dgvPayments.Columns["ReceiptNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPayments.Columns.Contains("MemberName"))
            {
                dgvPayments.Columns["MemberName"].HeaderText = "Member";
                dgvPayments.Columns["MemberName"].Width = 250;
            }

            if (dgvPayments.Columns.Contains("PaymentDate"))
            {
                dgvPayments.Columns["PaymentDate"].HeaderText = "Payment Date";
                dgvPayments.Columns["PaymentDate"].Width = 150;
                dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPayments.Columns.Contains("DueDate"))
            {
                dgvPayments.Columns["DueDate"].HeaderText = "Due Date";
                dgvPayments.Columns["DueDate"].Width = 120;
                dgvPayments.Columns["DueDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                dgvPayments.Columns["DueDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private async Task UpdateStatisticsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Total amount and count for all payments
                    string totalStatsQuery = @"
                        SELECT 
                            ISNULL(SUM(Amount), 0) AS TotalAmount,
                            COUNT(*) AS TotalCount
                        FROM Payments";

                    using (SqlCommand cmd = new SqlCommand(totalStatsQuery, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal totalAmount = reader.GetDecimal(0);
                                int totalCount = reader.GetInt32(1);

                                // Update UI on main thread
                                if (lblTotalAmount != null)
                                {
                                    if (lblTotalAmount.InvokeRequired)
                                        lblTotalAmount.Invoke(new Action(() => lblTotalAmount.Text = $"💰 Total: ₱{totalAmount:N2}"));
                                    else
                                        lblTotalAmount.Text = $"💰 Total: ₱{totalAmount:N2}";
                                }

                                if (lblTotalPayments != null)
                                {
                                    if (lblTotalPayments.InvokeRequired)
                                        lblTotalPayments.Invoke(new Action(() => lblTotalPayments.Text = $"📊 Transactions: {totalCount}"));
                                    else
                                        lblTotalPayments.Text = $"📊 Transactions: {totalCount}";
                                }
                            }
                        }
                    }

                    // Basic and Premium counts from Members table
                    string planCountsQuery = @"
                        SELECT 
                            MembershipType,
                            COUNT(*) AS Count
                        FROM Members
                        GROUP BY MembershipType";

                    using (SqlCommand cmd = new SqlCommand(planCountsQuery, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            int basicCount = 0, premiumCount = 0;
                            while (await reader.ReadAsync())
                            {
                                string type = reader["MembershipType"].ToString().ToUpper();
                                int count = reader.GetInt32(1);
                                if (type == "BASIC")
                                    basicCount = count;
                                else if (type == "PREMIUM")
                                    premiumCount = count;
                            }

                            // Update button texts on main thread using Invoke if needed
                            if (btnBasic != null)
                            {
                                if (btnBasic.InvokeRequired)
                                    btnBasic.Invoke(new Action(() => btnBasic.Text = $"⭐ BASIC: {basicCount}"));
                                else
                                    btnBasic.Text = $"⭐ BASIC: {basicCount}";
                            }

                            if (btnPremium != null)
                            {
                                if (btnPremium.InvokeRequired)
                                    btnPremium.Invoke(new Action(() => btnPremium.Text = $"💎 PREMIUM: {premiumCount}"));
                                else
                                    btnPremium.Text = $"💎 PREMIUM: {premiumCount}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating stats: {ex.Message}");
            }
        }

        private void ApplyFilters()
        {
            if (paymentsTable == null) return;

            string searchTerm = txtSearch.Text.Trim();
            DateTime selectedDate = dtpFilterDate.Value.Date;
            string filter = "";

            if (currentFilterType == "Basic")
                filter = $"MembershipType = 'BASIC'";
            else if (currentFilterType == "Premium")
                filter = $"MembershipType = 'PREMIUM'";

            if (filter.Length > 0) filter += " AND ";
            filter += $"PaymentDate >= '{selectedDate:yyyy-MM-dd}'";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += $"(ReceiptNumber LIKE '%{searchTerm}%' OR MemberName LIKE '%{searchTerm}%')";
            }

            paymentsTable.DefaultView.RowFilter = filter;
        }

        private async void BtnBasic_Click(object sender, EventArgs e)
        {
            currentFilterType = "Basic";
            HighlightPlanButton(btnBasic, btnPremium);
            ApplyFilters();
            ApplyTheme(_isDarkMode); // Refresh theme to update button colors
            await Task.CompletedTask;
        }

        private async void BtnPremium_Click(object sender, EventArgs e)
        {
            currentFilterType = "Premium";
            HighlightPlanButton(btnPremium, btnBasic);
            ApplyFilters();
            ApplyTheme(_isDarkMode); // Refresh theme to update button colors
            await Task.CompletedTask;
        }

        private void HighlightPlanButton(Button selected, Button other)
        {
            selected.BackColor = Color.FromArgb(255, 100, 50);
            selected.ForeColor = Color.White;
            other.BackColor = other == btnBasic ? Color.FromArgb(33, 150, 243) : Color.FromArgb(156, 39, 176);
            other.ForeColor = Color.White;
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            currentFilterType = "All";
            btnBasic.BackColor = Color.FromArgb(33, 150, 243);
            btnPremium.BackColor = Color.FromArgb(156, 39, 176);
            btnBasic.ForeColor = Color.White;
            btnPremium.ForeColor = Color.White;

            await LoadPaymentsAsync();
            await UpdateStatisticsAsync();
            ApplyTheme(_isDarkMode); // Refresh theme
        }

        private async void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvPayments == null || dgvPayments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment to print receipt.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvPayments.SelectedRows[0];

            int paymentId = 0;
            if (row.Cells["PaymentID"].Value != null)
                paymentId = Convert.ToInt32(row.Cells["PaymentID"].Value);

            string receiptNumber = row.Cells["ReceiptNumber"].Value?.ToString() ?? "N/A";
            string memberName = row.Cells["MemberName"].Value?.ToString() ?? "N/A";

            await PrintReceiptWithDetails(paymentId, receiptNumber, memberName);
        }

        private async Task PrintReceiptWithDetails(int paymentId, string receiptNumber, string memberName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT Amount, PaymentDate, PaymentMethod 
                                    FROM Payments WHERE PaymentID = @PaymentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                decimal amount = reader.GetDecimal(0);
                                string paymentDate = Convert.ToDateTime(reader["PaymentDate"]).ToString("MM/dd/yyyy HH:mm");
                                string paymentMethod = reader["PaymentMethod"].ToString();

                                string receiptText = $@"
╔══════════════════════════════════════════════════════════╗
║                    FITWARE GYM                           ║
║                  Payment Receipt                         ║
╠══════════════════════════════════════════════════════════╣
║  Receipt #: {receiptNumber.PadRight(44)}║
║  Date:      {paymentDate.PadRight(44)}║
║  Member:    {memberName.PadRight(44)}║
║  Method:    {paymentMethod.PadRight(44)}║
╠══════════════════════════════════════════════════════════╣
║  Amount Paid: ₱{amount:N2}".PadRight(47) + "║\n" +
@"╠══════════════════════════════════════════════════════════╣
║                                                          ║
║         Thank you for your payment!                      ║
║         Stay Fit with FitWare!                           ║
║                                                          ║
╚══════════════════════════════════════════════════════════╝";

                                MessageBox.Show(receiptText, "Receipt Preview - FitWare Gym",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private async void DgvPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPayments != null)
            {
                DataGridViewRow row = dgvPayments.Rows[e.RowIndex];

                int paymentId = 0;
                if (row.Cells["PaymentID"].Value != null)
                {
                    paymentId = Convert.ToInt32(row.Cells["PaymentID"].Value);
                }

                if (paymentId > 0)
                {
                    await OpenPaymentDetails(paymentId);
                }
            }
        }

        private async Task OpenPaymentDetails(int paymentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT 
                                        PaymentStatus, 
                                        PaymentMethod, 
                                        Amount, 
                                        DueDate 
                                    FROM Payments 
                                    WHERE PaymentID = @PaymentID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                string paymentStatus = reader["PaymentStatus"].ToString();
                                string paymentMethod = reader["PaymentMethod"].ToString();
                                decimal amount = reader.GetDecimal(2);
                                DateTime dueDate = reader.GetDateTime(3);

                                PaymentDetails paymentDetails = new PaymentDetails(paymentId, paymentStatus, paymentMethod, amount, dueDate, connectionString);
                                paymentDetails.ShowDialog();

                                await LoadPaymentsAsync();
                                await UpdateStatisticsAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening payment details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Unsubscribe from theme changes
            ThemeManager.ThemeChanged -= OnThemeChanged;
            base.OnFormClosed(e);
        }
    }
}