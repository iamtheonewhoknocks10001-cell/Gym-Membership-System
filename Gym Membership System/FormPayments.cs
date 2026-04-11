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
        private string _currentUser = "Admin";

        public FormPayments()
        {
            InitializeComponent();
            AttachEventHandlers();
            LoadPayments();
            LoadFilters();
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
            this.dgvPayments.CellContentClick += dgvPayments_CellContentClick;
        }

        private void FormPayments_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
        }

        private async void LoadFilters()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string membershipQuery = "SELECT PlanName FROM MembershipPlans WHERE IsActive = 1 ORDER BY PlanName";
                    SqlDataAdapter membershipAdapter = new SqlDataAdapter(membershipQuery, conn);
                    DataTable membershipDt = new DataTable();
                    membershipAdapter.Fill(membershipDt);

                    cmbMembershipFilter.Items.Clear();
                    cmbMembershipFilter.Items.Add("All");

                    foreach (DataRow row in membershipDt.Rows)
                    {
                        cmbMembershipFilter.Items.Add(row["PlanName"].ToString());
                    }

                    if (cmbMembershipFilter.Items.Count > 0)
                        cmbMembershipFilter.SelectedIndex = 0;

                    cmbStatusFilter.Items.Clear();
                    cmbStatusFilter.Items.AddRange(new string[] { "All", "Paid", "Pending", "Overdue" });
                    cmbStatusFilter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    adapter.Fill(dt);  // Remove await Task.Run

                    paymentsTable = dt;
                    dgvPayments.DataSource = dt;
                    FormatPaymentColumns();
                    UpdateStatistics();
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
            // ... your existing code ...
        }

        private void DgvPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // ... your existing code ...
        }

        private void UpdateStatistics()
        {
            // ... your existing code ...
        }

        private void ApplyFilters()
        {
            // ... your existing code ...
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
            // ... your existing code ...
        }

        private void PrintReceipt(string receiptNumber, string memberName, decimal amount, string membership, string paymentDate, string paymentMethod)
        {
            // ... your existing code ...
        }

        // SINGLE BtnBack_Click method - keep only this one
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

        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }
    }
}