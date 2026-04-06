using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class AddPaymentForm : Form
    {
        private string connectionString;
        private string currentUser;

        public AddPaymentForm(string connString, string user)
        {
            connectionString = connString;
            currentUser = user;
            InitializeComponent();
            LoadMembers();
            AttachEvents();
        }

        private void AttachEvents()
        {
            cmbMembershipType.SelectedIndexChanged += (s, e) => UpdateAmount();
            cmbPaymentPeriod.SelectedIndexChanged += (s, e) => UpdateAmount();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();
        }

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MemberID, FirstName + ' ' + LastName AS MemberName FROM Members WHERE IsActive = 1 ORDER BY MemberName";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbMember.DisplayMember = "MemberName";
                    cmbMember.ValueMember = "MemberID";
                    cmbMember.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetPrice(string membership, string period)
        {
            if (membership == "BASIC")
            {
                if (period == "Monthly") return 1050.00m;
                if (period == "Quarterly") return 3150.00m;
                if (period == "Annual") return 12775.00m;
            }
            else if (membership == "PREMIUM")
            {
                if (period == "Monthly") return 1400.00m;
                if (period == "Quarterly") return 4000.00m;
                if (period == "Annual") return 15000.00m;
            }
            return 0;
        }

        private void UpdateAmount()
        {
            if (cmbMembershipType.SelectedItem != null && cmbPaymentPeriod.SelectedItem != null)
            {
                string membership = cmbMembershipType.SelectedItem.ToString();
                string period = cmbPaymentPeriod.SelectedItem.ToString();
                decimal amount = GetPrice(membership, period);

                nudAmount.Value = amount;
                lblCalculatedAmount.Text = $"₱{amount:N2}";
                lblCalculatedAmount.ForeColor = Color.FromArgb(76, 175, 80);

                if (period == "Monthly")
                    dtpDueDate.Value = DateTime.Now.AddMonths(1);
                else if (period == "Quarterly")
                    dtpDueDate.Value = DateTime.Now.AddMonths(3);
                else if (period == "Annual")
                    dtpDueDate.Value = DateTime.Now.AddYears(1);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedValue == null)
            {
                MessageBox.Show("Please select a member.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Please select membership and period to calculate amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string receiptNumber = GenerateReceiptNumber();
                    string paymentFor = cmbMembershipType.SelectedItem.ToString();
                    string paymentPeriod = cmbPaymentPeriod.SelectedItem.ToString();
                    string paymentStatus = "Paid";

                    string query = @"INSERT INTO Payments 
                                    (MemberID, Amount, PaymentDate, DueDate, PaymentMethod, 
                                     PaymentStatus, TransactionReference, ReceiptNumber, PaymentFor, 
                                     PaymentPeriod, Notes, ProcessedBy, CreatedAt)
                                    VALUES 
                                    (@MemberID, @Amount, @PaymentDate, @DueDate, @PaymentMethod,
                                     @PaymentStatus, @TransactionRef, @ReceiptNumber, @PaymentFor,
                                     @PaymentPeriod, @Notes, @ProcessedBy, @CreatedAt)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", (int)cmbMember.SelectedValue);
                        cmd.Parameters.AddWithValue("@Amount", nudAmount.Value);
                        cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                        cmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value);
                        cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                        cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        cmd.Parameters.AddWithValue("@TransactionRef", txtTransactionRef.Text);
                        cmd.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);
                        cmd.Parameters.AddWithValue("@PaymentFor", paymentFor);
                        cmd.Parameters.AddWithValue("@PaymentPeriod", paymentPeriod);
                        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        cmd.Parameters.AddWithValue("@ProcessedBy", currentUser);
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Payment recorded successfully!\nReceipt Number: {receiptNumber}\nAmount: ₱{nudAmount.Value:N2}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateReceiptNumber()
        {
            return $"RCP-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }
    }
}