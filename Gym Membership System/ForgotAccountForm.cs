using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Timer = System.Windows.Forms.Timer;

namespace Gym_Membership_System
{
    public partial class ForgotAccountForm : BaseForm
    {
        private string connectionString;

        // Visual constants
        private const int OverlayAlpha = 180;
        private const int VignetteAlpha = 200;
        private const float VignetteFocus = 0.55f;
        private const int GradientAlpha = 80;
        private readonly Image _backgroundImage = Properties.Resources.loginbg;

        // Control declarations
        private Panel mainPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblInstruction;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnSearch;
        private Button btnCancel;
        private Panel resultsPanel;
        private Label lblResultsTitle;
        private DataGridView dgvResults;
        private Button btnUpdatePassword;

        private bool accountFound = false;
        private int foundAdminID = 0;
        private string foundEmail = "";
        private string foundUsername = "";

        public ForgotAccountForm(string connString)
        {
            connectionString = connString;
            InitializeComponent();
            SetupForm();
            this.Shown += (s, e) => FadeIn();
        }

        private void InitializeComponent()
        {
            // Form settings
            this.Text = "Account Recovery";
            this.Size = new Size(1000, 800);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.DoubleBuffered = true;
            this.BackgroundImage = null;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.DoubleBuffer, true);
        }

        private void SetupForm()
        {
            // Main panel with proper padding and margins
            mainPanel = new Panel();
            mainPanel.BackColor = Color.FromArgb(40, 40, 45);
            mainPanel.Size = new Size(920, 720);
            mainPanel.Location = new Point(40, 30);
            mainPanel.Padding = new Padding(25);
            this.Controls.Add(mainPanel);

            // Title
            lblTitle = new Label();
            lblTitle.Text = "ACCOUNT RECOVERY";
            lblTitle.Font = new Font("Impact", 32F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 100, 0);
            lblTitle.Size = new Size(500, 50);
            lblTitle.Location = new Point(210, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            mainPanel.Controls.Add(lblTitle);

            // Subtitle
            lblSubtitle = new Label();
            lblSubtitle.Text = "Recover your account";
            lblSubtitle.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblSubtitle.Size = new Size(300, 25);
            lblSubtitle.Location = new Point(310, 70);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            mainPanel.Controls.Add(lblSubtitle);

            // Instruction
            lblInstruction = new Label();
            lblInstruction.Text = "Enter any of the following details to find your account:";
            lblInstruction.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblInstruction.ForeColor = Color.White;
            lblInstruction.Size = new Size(500, 30);
            lblInstruction.Location = new Point(210, 110);
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            mainPanel.Controls.Add(lblInstruction);

            // Input fields
            int startY = 160;
            int labelX = 220;
            int fieldX = 370;
            int fieldWidth = 320;
            int labelWidth = 130;
            int rowSpacing = 55;

            // First Name
            lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Size = new Size(labelWidth, 30);
            lblFirstName.Location = new Point(labelX, startY);
            lblFirstName.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblFirstName);

            txtFirstName = new TextBox();
            txtFirstName.BackColor = Color.FromArgb(60, 60, 65);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.Font = new Font("Segoe UI", 12F);
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Size = new Size(fieldWidth, 35);
            txtFirstName.Location = new Point(fieldX, startY);
            txtFirstName.PlaceholderText = "Enter first name";
            txtFirstName.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtFirstName);

            // Last Name
            lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLastName.ForeColor = Color.White;
            lblLastName.Size = new Size(labelWidth, 30);
            lblLastName.Location = new Point(labelX, startY + rowSpacing);
            lblLastName.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblLastName);

            txtLastName = new TextBox();
            txtLastName.BackColor = Color.FromArgb(60, 60, 65);
            txtLastName.ForeColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 12F);
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Size = new Size(fieldWidth, 35);
            txtLastName.Location = new Point(fieldX, startY + rowSpacing);
            txtLastName.PlaceholderText = "Enter last name";
            txtLastName.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtLastName);

            // Email
            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Size = new Size(labelWidth, 30);
            lblEmail.Location = new Point(labelX, startY + rowSpacing * 2);
            lblEmail.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblEmail);

            txtEmail = new TextBox();
            txtEmail.BackColor = Color.FromArgb(60, 60, 65);
            txtEmail.ForeColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Size = new Size(fieldWidth, 35);
            txtEmail.Location = new Point(fieldX, startY + rowSpacing * 2);
            txtEmail.PlaceholderText = "admin@gym.com";
            txtEmail.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtEmail);

            // Buttons - UPDATED FONTS
            int buttonY = startY + rowSpacing * 3 + 25;

            btnSearch = new Button();
            btnSearch.Text = "SEARCH ACCOUNT";
            btnSearch.BackColor = Color.FromArgb(255, 100, 0);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new Font("Segoe UI", 14F, FontStyle.Bold); // Changed from Impact
            btnSearch.ForeColor = Color.White;
            btnSearch.Size = new Size(220, 45);
            btnSearch.Location = new Point(220, buttonY);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Click += BtnSearch_Click;
            mainPanel.Controls.Add(btnSearch);

            btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.BackColor = Color.FromArgb(100, 100, 100);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold); // Changed from Impact
            btnCancel.ForeColor = Color.White;
            btnCancel.Size = new Size(220, 45);
            btnCancel.Location = new Point(470, buttonY);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += BtnCancel_Click;
            mainPanel.Controls.Add(btnCancel);

            // Results Panel
            resultsPanel = new Panel();
            resultsPanel.BackColor = Color.FromArgb(50, 50, 55);
            resultsPanel.Size = new Size(840, 280);
            resultsPanel.Location = new Point(40, 380);
            resultsPanel.Visible = false;
            resultsPanel.Padding = new Padding(15);
            mainPanel.Controls.Add(resultsPanel);

            // Results Title
            lblResultsTitle = new Label();
            lblResultsTitle.Text = "ACCOUNT FOUND";
            lblResultsTitle.Font = new Font("Impact", 18F, FontStyle.Bold);
            lblResultsTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblResultsTitle.Size = new Size(300, 35);
            lblResultsTitle.Location = new Point(270, 15);
            lblResultsTitle.TextAlign = ContentAlignment.MiddleCenter;
            resultsPanel.Controls.Add(lblResultsTitle);

            // DataGridView for results
            dgvResults = new DataGridView();
            dgvResults.BackgroundColor = Color.FromArgb(60, 60, 65);
            dgvResults.ForeColor = Color.White;
            dgvResults.Font = new Font("Segoe UI", 11F);
            dgvResults.Size = new Size(800, 180);
            dgvResults.Location = new Point(20, 60);
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;
            dgvResults.RowHeadersVisible = false;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ReadOnly = true;
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResults.GridColor = Color.FromArgb(80, 80, 85);
            dgvResults.RowTemplate.Height = 35;

            // Header styling
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 70, 75);
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvResults.ColumnHeadersHeight = 40;

            // Cell styling
            dgvResults.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65);
            dgvResults.DefaultCellStyle.ForeColor = Color.White;
            dgvResults.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 100, 0);
            dgvResults.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvResults.DefaultCellStyle.Padding = new Padding(8);

            dgvResults.CellClick += DgvResults_CellClick;
            resultsPanel.Controls.Add(dgvResults);

            // Update Password Button - UPDATED FONT
            btnUpdatePassword = new Button();
            btnUpdatePassword.Text = "UPDATE PASSWORD";
            btnUpdatePassword.BackColor = Color.FromArgb(76, 175, 80);
            btnUpdatePassword.FlatStyle = FlatStyle.Flat;
            btnUpdatePassword.FlatAppearance.BorderSize = 0;
            btnUpdatePassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold); // Changed from Impact
            btnUpdatePassword.ForeColor = Color.White;
            btnUpdatePassword.Size = new Size(220, 45);
            btnUpdatePassword.Location = new Point(350, 670);
            btnUpdatePassword.Visible = false;
            btnUpdatePassword.Cursor = Cursors.Hand;
            btnUpdatePassword.Click += BtnUpdatePassword_Click;
            mainPanel.Controls.Add(btnUpdatePassword);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Find and show the login form
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

        private void FadeIn()
        {
            this.Opacity = 0;
            Timer fadeIn = new Timer();
            fadeIn.Interval = 15;
            fadeIn.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.05;
                }
                else
                {
                    fadeIn.Stop();
                    fadeIn.Dispose();
                }
            };
            fadeIn.Start();
        }

        private void ClearResults()
        {
            resultsPanel.Visible = false;
            btnUpdatePassword.Visible = false;
            accountFound = false;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                string.IsNullOrWhiteSpace(txtLastName.Text) &&
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter at least one search criteria.",
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await SearchAccounts();
        }

        private async Task SearchAccounts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    string query = "SELECT AdminID, FirstName, LastName, Email, Username, Role FROM Admins WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                        query += " AND FirstName LIKE '%" + txtFirstName.Text + "%'";

                    if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                        query += " AND LastName LIKE '%" + txtLastName.Text + "%'";

                    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                        query += " AND Email LIKE '%" + txtEmail.Text + "%'";

                    query += " ORDER BY LastName, FirstName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dgvResults.DataSource = dt;

                            // Hide AdminID column
                            if (dgvResults.Columns["AdminID"] != null)
                                dgvResults.Columns["AdminID"].Visible = false;

                            // Format column headers
                            if (dgvResults.Columns["FirstName"] != null)
                                dgvResults.Columns["FirstName"].HeaderText = "First Name";
                            if (dgvResults.Columns["LastName"] != null)
                                dgvResults.Columns["LastName"].HeaderText = "Last Name";

                            resultsPanel.Visible = true;

                            if (dt.Rows.Count == 1)
                            {
                                lblResultsTitle.Text = "ACCOUNT FOUND";
                                lblResultsTitle.ForeColor = Color.FromArgb(76, 175, 80);

                                // Auto-select the first row
                                if (dgvResults.Rows.Count > 0)
                                {
                                    dgvResults.Rows[0].Selected = true;
                                    SelectAccount(0);
                                }
                            }
                            else
                            {
                                lblResultsTitle.Text = $"MULTIPLE ACCOUNTS FOUND ({dt.Rows.Count})";
                                lblResultsTitle.ForeColor = Color.FromArgb(255, 150, 0);
                                btnUpdatePassword.Visible = false;
                            }
                        }
                        else
                        {
                            resultsPanel.Visible = false;
                            btnUpdatePassword.Visible = false;
                            MessageBox.Show("No accounts found with the provided information.",
                                "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching accounts: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectAccount(int rowIndex)
        {
            if (rowIndex >= 0 && dgvResults.Rows.Count > rowIndex)
            {
                DataGridViewRow row = dgvResults.Rows[rowIndex];

                // Safely get values
                if (row.Cells["AdminID"].Value != null)
                    foundAdminID = Convert.ToInt32(row.Cells["AdminID"].Value);

                foundEmail = row.Cells["Email"].Value?.ToString() ?? "";
                foundUsername = row.Cells["Username"].Value?.ToString() ?? "";

                accountFound = true;
                btnUpdatePassword.Visible = true;
            }
        }

        private void DgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectAccount(e.RowIndex);
            }
        }

        private async void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (!accountFound || foundAdminID == 0)
            {
                MessageBox.Show("Please search and select an account first.",
                    "No Account Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPassword = ShowPasswordDialog();
            if (!string.IsNullOrEmpty(newPassword))
            {
                await UpdatePassword(foundAdminID, newPassword);
            }
        }

        private string ShowPasswordDialog()
        {
            Form passwordForm = new Form();
            passwordForm.Text = "Update Password";
            passwordForm.Size = new Size(450, 300);
            passwordForm.StartPosition = FormStartPosition.CenterParent;
            passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordForm.MaximizeBox = false;
            passwordForm.MinimizeBox = false;
            passwordForm.BackColor = Color.FromArgb(30, 30, 30);
            passwordForm.ForeColor = Color.White;
            passwordForm.Font = new Font("Segoe UI", 9F);

            Label lblInfo = new Label();
            lblInfo.Text = $"Updating password for:\n{foundEmail}";
            lblInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(255, 150, 0);
            lblInfo.Size = new Size(350, 50);
            lblInfo.Location = new Point(50, 20);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            passwordForm.Controls.Add(lblInfo);

            Label lblNewPassword = new Label();
            lblNewPassword.Text = "New Password:";
            lblNewPassword.Location = new Point(50, 80);
            lblNewPassword.Size = new Size(120, 30);
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(lblNewPassword);

            TextBox txtNewPassword = new TextBox();
            txtNewPassword.Location = new Point(180, 80);
            txtNewPassword.Size = new Size(200, 30);
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.BackColor = Color.FromArgb(60, 60, 65);
            txtNewPassword.ForeColor = Color.White;
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(txtNewPassword);

            Label lblConfirmPassword = new Label();
            lblConfirmPassword.Text = "Confirm:";
            lblConfirmPassword.Location = new Point(50, 130);
            lblConfirmPassword.Size = new Size(120, 30);
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(lblConfirmPassword);

            TextBox txtConfirmPassword = new TextBox();
            txtConfirmPassword.Location = new Point(180, 130);
            txtConfirmPassword.Size = new Size(200, 30);
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.BackColor = Color.FromArgb(60, 60, 65);
            txtConfirmPassword.ForeColor = Color.White;
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(txtConfirmPassword);

            // UPDATED: Password dialog buttons with better fonts
            Button btnOK = new Button();
            btnOK.Text = "UPDATE";
            btnOK.BackColor = Color.FromArgb(76, 175, 80);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.ForeColor = Color.White;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold); // Changed from Impact
            btnOK.Location = new Point(120, 190);
            btnOK.Size = new Size(100, 40);
            btnOK.DialogResult = DialogResult.OK;
            passwordForm.Controls.Add(btnOK);

            Button btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.BackColor = Color.FromArgb(100, 100, 100);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.ForeColor = Color.White;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold); // Changed from Impact
            btnCancel.Location = new Point(240, 190);
            btnCancel.Size = new Size(100, 40);
            btnCancel.DialogResult = DialogResult.Cancel;
            passwordForm.Controls.Add(btnCancel);

            if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters.",
                        "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ShowPasswordDialog();
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.",
                        "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ShowPasswordDialog();
                }

                return txtNewPassword.Text;
            }

            return null;
        }

        private async Task UpdatePassword(int adminId, string newPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    string query = "UPDATE Admins SET PasswordHash = @Password WHERE AdminID = @AdminID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@AdminID", adminId);

                        int result = await cmd.ExecuteNonQueryAsync();

                        if (result > 0)
                        {
                            MessageBox.Show($"✓ Password updated successfully for {foundEmail}!\n\nYou can now login with your new password.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Find and show login form before closing
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Find and show the login form before closing
            foreach (Form f in Application.OpenForms)
            {
                if (f is LOGIN)
                {
                    f.Show();
                    break;
                }
            }
            base.OnFormClosing(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = ClientRectangle;

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

            // Dark overlay
            using (var overlay = new SolidBrush(Color.FromArgb(OverlayAlpha, 0, 0, 0)))
                g.FillRectangle(overlay, rect);

            // Vignette effect
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

            // Gradient overlay
            using (var lg = new LinearGradientBrush(rect,
                Color.FromArgb(GradientAlpha, 0, 0, 0),
                Color.FromArgb(0, 0, 0, 0), 90f))
                g.FillRectangle(lg, rect);
        }
    }
}