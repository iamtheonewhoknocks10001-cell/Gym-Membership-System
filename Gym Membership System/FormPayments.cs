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
        private string connectionString = "Server=DESKTOP-AH6OHHK;Database=GymDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private DataTable paymentsTable;
        private string _currentUser = "Admin";

        // Pricing based on 35 PHP per day
        private decimal GetPrice(string membership, string period)
        {
            if (membership == "BASIC")
            {
                if (period == "Monthly") return 1050.00m;      // 30 days x 35
                if (period == "Quarterly") return 3150.00m;    // 90 days x 35
                if (period == "Annual") return 12775.00m;      // 365 days x 35
            }
            else if (membership == "PREMIUM")
            {
                if (period == "Monthly") return 1400.00m;      // 40 days equivalent
                if (period == "Quarterly") return 4000.00m;    // 114 days equivalent
                if (period == "Annual") return 15000.00m;      // 428 days equivalent
            }
            return 0;
        }

        public FormPayments()
        {
            InitializeComponent();
            AttachEventHandlers();
            LoadPayments();
        }

        private void AttachEventHandlers()
        {
            this.Load += FormPayments_Load;
            this.btnAddPayment.Click += BtnAddPayment_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnPrintReceipt.Click += BtnPrintReceipt_Click;
            this.btnBack.Click += BtnBack_Click;
            this.btnApplyFilter.Click += BtnApplyFilter_Click;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvPayments.CellFormatting += DgvPayments_CellFormatting;
        }

        private void FormPayments_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
        }

        private async void LoadPayments()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT 
                                        p.PaymentID,
                                        p.ReceiptNumber,
                                        m.FirstName + ' ' + m.LastName AS MemberName,
                                        m.MembershipType,
                                        p.Amount,
                                        FORMAT(p.PaymentDate, 'MM/dd/yyyy HH:mm') AS PaymentDate,
                                        FORMAT(p.DueDate, 'MM/dd/yyyy') AS DueDate,
                                        p.PaymentMethod,
                                        p.PaymentStatus,
                                        p.PaymentFor AS MembershipPaid,
                                        p.PaymentPeriod,
                                        p.TransactionReference,
                                        p.ProcessedBy
                                    FROM Payments p
                                    INNER JOIN Members m ON p.MemberID = m.MemberID
                                    ORDER BY p.PaymentDate DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    await Task.Run(() => adapter.Fill(dt));

                    paymentsTable = dt;
                    dgvPayments.DataSource = dt;
                    FormatPaymentColumns();
                    UpdateStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payments: {ex.Message}\n\nPlease ensure the database is connected.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatPaymentColumns()
        {
            if (dgvPayments.Columns.Count == 0) return;

            if (dgvPayments.Columns.Contains("PaymentID"))
                dgvPayments.Columns["PaymentID"].Visible = false;

            if (dgvPayments.Columns.Contains("ReceiptNumber"))
            {
                dgvPayments.Columns["ReceiptNumber"].HeaderText = "Receipt #";
                dgvPayments.Columns["ReceiptNumber"].Width = 100;
            }

            if (dgvPayments.Columns.Contains("MemberName"))
            {
                dgvPayments.Columns["MemberName"].HeaderText = "Member";
                dgvPayments.Columns["MemberName"].Width = 150;
            }

            if (dgvPayments.Columns.Contains("MembershipType"))
            {
                dgvPayments.Columns["MembershipType"].HeaderText = "Plan";
                dgvPayments.Columns["MembershipType"].Width = 80;
            }

            if (dgvPayments.Columns.Contains("Amount"))
            {
                dgvPayments.Columns["Amount"].HeaderText = "Amount";
                dgvPayments.Columns["Amount"].DefaultCellStyle.Format = "C2";
                dgvPayments.Columns["Amount"].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("fil-PH");
                dgvPayments.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPayments.Columns["Amount"].Width = 120;
            }

            if (dgvPayments.Columns.Contains("PaymentDate"))
            {
                dgvPayments.Columns["PaymentDate"].HeaderText = "Payment Date";
                dgvPayments.Columns["PaymentDate"].Width = 130;
            }

            if (dgvPayments.Columns.Contains("DueDate"))
            {
                dgvPayments.Columns["DueDate"].HeaderText = "Due Date";
                dgvPayments.Columns["DueDate"].Width = 100;
            }

            if (dgvPayments.Columns.Contains("PaymentMethod"))
            {
                dgvPayments.Columns["PaymentMethod"].HeaderText = "Method";
                dgvPayments.Columns["PaymentMethod"].Width = 100;
            }

            if (dgvPayments.Columns.Contains("PaymentStatus"))
            {
                dgvPayments.Columns["PaymentStatus"].HeaderText = "Status";
                dgvPayments.Columns["PaymentStatus"].Width = 90;
            }

            if (dgvPayments.Columns.Contains("MembershipPaid"))
            {
                dgvPayments.Columns["MembershipPaid"].HeaderText = "Membership";
                dgvPayments.Columns["MembershipPaid"].Width = 100;
            }

            if (dgvPayments.Columns.Contains("PaymentPeriod"))
            {
                dgvPayments.Columns["PaymentPeriod"].HeaderText = "Period";
                dgvPayments.Columns["PaymentPeriod"].Width = 90;
            }

            if (dgvPayments.Columns.Contains("TransactionReference"))
            {
                dgvPayments.Columns["TransactionReference"].HeaderText = "Transaction Ref";
                dgvPayments.Columns["TransactionReference"].Width = 120;
            }

            if (dgvPayments.Columns.Contains("ProcessedBy"))
            {
                dgvPayments.Columns["ProcessedBy"].HeaderText = "Processed By";
                dgvPayments.Columns["ProcessedBy"].Width = 120;
            }
        }

        private void DgvPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPayments.Columns[e.ColumnIndex].Name == "PaymentStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Paid")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(76, 175, 80);
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
                else if (status == "Pending")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(255, 193, 7);
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            }

            if (dgvPayments.Columns[e.ColumnIndex].Name == "MembershipPaid" && e.Value != null)
            {
                string membership = e.Value.ToString();
                if (membership == "BASIC")
                    e.CellStyle.ForeColor = Color.FromArgb(33, 150, 243);
                else if (membership == "PREMIUM")
                    e.CellStyle.ForeColor = Color.FromArgb(156, 39, 176);
            }

            if (dgvPayments.Columns[e.ColumnIndex].Name == "Amount" && e.Value != null)
            {
                e.CellStyle.Format = "C2";
                e.CellStyle.FormatProvider = new System.Globalization.CultureInfo("fil-PH");
            }
        }

        private void UpdateStatistics()
        {
            if (paymentsTable == null) return;

            var paidPayments = paymentsTable.AsEnumerable()
                .Where(row => row.Field<string>("PaymentStatus") == "Paid");

            decimal totalAmount = paidPayments.Sum(row => row.Field<decimal>("Amount"));
            int totalCount = paidPayments.Count();

            decimal basicAmount = paidPayments
                .Where(row => row.Field<string>("MembershipPaid") == "BASIC")
                .Sum(row => row.Field<decimal>("Amount"));
            int basicCount = paidPayments
                .Count(row => row.Field<string>("MembershipPaid") == "BASIC");

            decimal premiumAmount = paidPayments
                .Where(row => row.Field<string>("MembershipPaid") == "PREMIUM")
                .Sum(row => row.Field<decimal>("Amount"));
            int premiumCount = paidPayments
                .Count(row => row.Field<string>("MembershipPaid") == "PREMIUM");

            lblTotalAmount.Text = $"💰 Total: ₱{totalAmount:N2}";
            lblTotalPayments.Text = $"📊 Payments: {totalCount}";
            lblBasicTotal.Text = $"⭐ BASIC: ₱{basicAmount:N2} ({basicCount})";
            lblPremiumTotal.Text = $"💎 PREMIUM: ₱{premiumAmount:N2} ({premiumCount})";
        }

        private void ApplyFilters()
        {
            if (paymentsTable == null) return;

            string searchTerm = txtSearch.Text.Trim();
            string statusFilter = cmbStatusFilter.SelectedItem?.ToString();
            string membershipFilter = cmbMembershipFilter.SelectedItem?.ToString();
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

            string filter = "";

            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                filter = $"PaymentStatus = '{statusFilter}'";
            }

            if (!string.IsNullOrEmpty(membershipFilter) && membershipFilter != "All")
            {
                if (filter.Length > 0) filter += " AND ";
                filter += $"MembershipPaid = '{membershipFilter}'";
            }

            if (filter.Length > 0) filter += " AND ";
            filter += $"PaymentDate >= '{startDate:yyyy-MM-dd}' AND PaymentDate <= '{endDate:yyyy-MM-dd}'";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (filter.Length > 0) filter += " AND ";
                filter += $"ReceiptNumber LIKE '%{searchTerm}%'";
            }

            paymentsTable.DefaultView.RowFilter = filter;
            UpdateStatistics();
        }

        private void BtnAddPayment_Click(object sender, EventArgs e)
        {
            AddPaymentForm addPaymentForm = new AddPaymentForm(connectionString, _currentUser);
            addPaymentForm.ShowDialog();
            LoadPayments();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
        }

        private void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPayments.SelectedRows[0];
                string receiptNumber = row.Cells["ReceiptNumber"].Value?.ToString() ?? "N/A";
                string memberName = row.Cells["MemberName"].Value?.ToString() ?? "N/A";
                decimal amount = row.Cells["Amount"].Value != null ? Convert.ToDecimal(row.Cells["Amount"].Value) : 0;
                string membership = row.Cells["MembershipPaid"].Value?.ToString() ?? "N/A";
                string paymentDate = row.Cells["PaymentDate"].Value?.ToString() ?? DateTime.Now.ToString("MM/dd/yyyy");
                string paymentMethod = row.Cells["PaymentMethod"].Value?.ToString() ?? "N/A";

                PrintReceipt(receiptNumber, memberName, amount, membership, paymentDate, paymentMethod);
            }
            else
            {
                MessageBox.Show("Please select a payment to print receipt.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintReceipt(string receiptNumber, string memberName, decimal amount, string membership, string paymentDate, string paymentMethod)
        {
            string receiptText = $@"
╔══════════════════════════════════════════════════════════╗
║                    FITWARE GYM                           ║
║                  Payment Receipt                         ║
╠══════════════════════════════════════════════════════════╣
║  Receipt #: {receiptNumber.PadRight(44)}║
║  Date:      {paymentDate.PadRight(44)}║
║  Member:    {memberName.PadRight(44)}║
║  Membership: {membership.PadRight(44)}║
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
    }
}