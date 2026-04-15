using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Gym_Membership_System
{
    public partial class BoardUpdate : Form
    {
        private int _memberId;
        private string _connectionString;

        // Visual constants for dark background
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        public BoardUpdate(int memberId, string connectionString)
        {
            InitializeComponent();
            _memberId = memberId;
            _connectionString = connectionString;

            // Setup dark background
            this.BackgroundImage = null;
            this.DoubleBuffered = true;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);

            // Call async method without awaiting (fire and forget)
            _ = LoadMemberDataAsync();
        }

        private async Task LoadMemberDataAsync()
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
                                        Phone
                                    FROM Members 
                                    WHERE MemberID = @MemberID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", _memberId);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                // Use Invoke to update UI controls from background thread
                                this.Invoke(new Action(() =>
                                {
                                    lblMemberIDValue.Text = $"MEM-{_memberId:D4}";
                                    txtFirstName.Text = reader["FirstName"].ToString();
                                    txtLastName.Text = reader["LastName"].ToString();
                                    txtEmail.Text = reader["Email"].ToString();
                                    txtPhone.Text = reader["Phone"].ToString();
                                }));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error loading member data: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
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
                        string query = @"UPDATE Members 
                                        SET FirstName = @FirstName,
                                            LastName = @LastName,
                                            Email = @Email,
                                            Phone = @Phone
                                        WHERE MemberID = @MemberID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MemberID", _memberId);
                            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());

                            int rowsAffected = await cmd.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                statusStripLabel.Text = "✓ Member information updated successfully!";
                                statusStripLabel.ForeColor = Color.FromArgb(76, 175, 80);

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
            DialogResult result = MessageBox.Show("Discard changes and close?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
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
                var img = _backgroundImage;
                float ratio = Math.Max((float)rect.Width / img.Width, (float)rect.Height / img.Height);
                int drawW = (int)Math.Ceiling(img.Width * ratio);
                int drawH = (int)Math.Ceiling(img.Height * ratio);
                int drawX = rect.X + (rect.Width - drawW) / 2;
                int drawY = rect.Y + (rect.Height - drawH) / 2;
                g.DrawImage(img, new Rectangle(drawX, drawY, drawW, drawH));
            }

            using (var overlay = new SolidBrush(Color.FromArgb(OverlayAlpha, 0, 0, 0)))
                g.FillRectangle(overlay, rect);

            using (var path = new GraphicsPath())
            {
                float inflateW = rect.Width * 0.5f;
                float inflateH = rect.Height * 0.5f;
                path.AddEllipse(rect.X - inflateW / 2, rect.Y - inflateH / 2, rect.Width + inflateW, rect.Height + inflateH);
                using (var pgb = new PathGradientBrush(path))
                {
                    pgb.CenterColor = Color.FromArgb(0, 0, 0, 0);
                    pgb.SurroundColors = new[] { Color.FromArgb(VignetteAlpha, 0, 0, 0) };
                    pgb.FocusScales = new PointF(VignetteFocus, VignetteFocus);
                    g.FillRectangle(pgb, rect);
                }
            }

            using (var lg = new LinearGradientBrush(rect, Color.FromArgb(GradientAlpha, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), 90f))
                g.FillRectangle(lg, rect);
        }
    }
}