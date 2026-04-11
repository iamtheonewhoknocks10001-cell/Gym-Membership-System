using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class BoardUpdate : Form
    {
        private int _memberId;
        private string _connectionString;
        private bool isEditing = false;

        public BoardUpdate(int memberId, string connectionString)
        {
            InitializeComponent();
            _memberId = memberId;
            _connectionString = connectionString;
            LoadMemberData();
            SetControlsReadOnly(true);
        }

        private async void LoadMemberData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    string query = @"SELECT 
                                        MemberID,
                                        FirstName, 
                                        LastName, 
                                        Email, 
                                        Phone,
                                        MembershipType, 
                                        JoinDate,
                                        IsActive
                                    FROM Members 
                                    WHERE MemberID = @MemberID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", _memberId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Load data into form controls
                                lblMemberIDValue.Text = $"MEM-{_memberId:D4}";
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtLastName.Text = reader["LastName"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtPhone.Text = reader["Phone"].ToString();

                                // Set membership type
                                string membershipType = reader["MembershipType"].ToString();
                                if (cmbMembershipType.Items.Contains(membershipType))
                                    cmbMembershipType.SelectedItem = membershipType;
                                else
                                    cmbMembershipType.SelectedIndex = 0;

                                dtpJoinDate.Value = Convert.ToDateTime(reader["JoinDate"]);

                                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                                cmbStatus.SelectedItem = isActive ? "Active" : "Inactive";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading member data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlsReadOnly(bool readOnly)
        {
            txtFirstName.ReadOnly = readOnly;
            txtLastName.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtPhone.ReadOnly = readOnly;
            cmbMembershipType.Enabled = !readOnly;
            dtpJoinDate.Enabled = !readOnly;
            cmbStatus.Enabled = !readOnly;

            btnUpdate.Enabled = !readOnly;
            btnEdit.Enabled = readOnly;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditing = true;
            SetControlsReadOnly(false);
            txtFirstName.Focus();
            statusStripLabel.Text = "Edit mode: You can now update member information.";
            statusStripLabel.ForeColor = Color.FromArgb(255, 100, 0);
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to update this member's information?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        await conn.OpenAsync();
                        // REMOVED UpdatedAt column from the query
                        string query = @"UPDATE Members 
                                        SET FirstName = @FirstName,
                                            LastName = @LastName,
                                            Email = @Email,
                                            Phone = @Phone,
                                            MembershipType = @MembershipType,
                                            JoinDate = @JoinDate,
                                            IsActive = @IsActive
                                        WHERE MemberID = @MemberID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MemberID", _memberId);
                            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("@MembershipType", cmbMembershipType.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value);
                            cmd.Parameters.AddWithValue("@IsActive", cmbStatus.SelectedItem.ToString() == "Active");

                            int rowsAffected = await cmd.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                statusStripLabel.Text = "✓ Member information updated successfully!";
                                statusStripLabel.ForeColor = Color.FromArgb(76, 175, 80);
                                isEditing = false;
                                SetControlsReadOnly(true);

                                MessageBox.Show("Member information has been updated successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                statusStripLabel.Text = "✗ No changes were made.";
                                statusStripLabel.ForeColor = Color.Red;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating member: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusStripLabel.Text = "✗ Error updating member information.";
                    statusStripLabel.ForeColor = Color.Red;
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                DialogResult result = MessageBox.Show("Discard changes and close?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}