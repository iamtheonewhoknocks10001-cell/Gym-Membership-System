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
        private Label lblPhone;
        private TextBox txtPhone;
        private Button btnSearch;
        private Button btnCancel;
        private Panel resultsPanel;
        private Label lblResultsTitle;
        private DataGridView dgvResults;

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
            this.Size = new Size(1000, 750);
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
            // Main panel
            mainPanel = new Panel();
            mainPanel.BackColor = Color.FromArgb(40, 40, 45);
            mainPanel.Size = new Size(920, 620);
            mainPanel.Location = new Point(40, 30);
            mainPanel.Padding = new Padding(25);
            this.Controls.Add(mainPanel);

            // Title
            lblTitle = new Label();
            lblTitle.Text = "ACCOUNT RECOVERY";
            lblTitle.Font = new Font("Impact", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(255, 100, 0);
            lblTitle.Size = new Size(500, 40);
            lblTitle.Location = new Point(210, 15);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            mainPanel.Controls.Add(lblTitle);

            // Subtitle
            lblSubtitle = new Label();
            lblSubtitle.Text = "Recover your account";
            lblSubtitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblSubtitle.Size = new Size(300, 20);
            lblSubtitle.Location = new Point(310, 60);
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            mainPanel.Controls.Add(lblSubtitle);

            // Instruction
            lblInstruction = new Label();
            lblInstruction.Text = "Enter your details below to find your account:";
            lblInstruction.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblInstruction.ForeColor = Color.White;
            lblInstruction.Size = new Size(500, 25);
            lblInstruction.Location = new Point(210, 90);
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            mainPanel.Controls.Add(lblInstruction);

            // ============================================
            // INPUT FIELDS
            // ============================================
            int startY = 135;
            int labelX = 220;
            int fieldX = 370;
            int fieldWidth = 320;
            int labelWidth = 130;
            int rowSpacing = 50;

            // First Name
            lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Size = new Size(labelWidth, 28);
            lblFirstName.Location = new Point(labelX, startY);
            lblFirstName.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblFirstName);

            txtFirstName = new TextBox();
            txtFirstName.BackColor = Color.FromArgb(60, 60, 65);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.Font = new Font("Segoe UI", 11F);
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Size = new Size(fieldWidth, 30);
            txtFirstName.Location = new Point(fieldX, startY);
            txtFirstName.PlaceholderText = "Enter first name";
            txtFirstName.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtFirstName);

            // Last Name
            lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLastName.ForeColor = Color.White;
            lblLastName.Size = new Size(labelWidth, 28);
            lblLastName.Location = new Point(labelX, startY + rowSpacing);
            lblLastName.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblLastName);

            txtLastName = new TextBox();
            txtLastName.BackColor = Color.FromArgb(60, 60, 65);
            txtLastName.ForeColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 11F);
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Size = new Size(fieldWidth, 30);
            txtLastName.Location = new Point(fieldX, startY + rowSpacing);
            txtLastName.PlaceholderText = "Enter last name";
            txtLastName.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtLastName);

            // Email
            lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Size = new Size(labelWidth, 28);
            lblEmail.Location = new Point(labelX, startY + rowSpacing * 2);
            lblEmail.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblEmail);

            txtEmail = new TextBox();
            txtEmail.BackColor = Color.FromArgb(60, 60, 65);
            txtEmail.ForeColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Size = new Size(fieldWidth, 30);
            txtEmail.Location = new Point(fieldX, startY + rowSpacing * 2);
            txtEmail.PlaceholderText = "admin@gym.com";
            txtEmail.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtEmail);

            // Phone
            lblPhone = new Label();
            lblPhone.Text = "Phone:";
            lblPhone.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPhone.ForeColor = Color.White;
            lblPhone.Size = new Size(labelWidth, 28);
            lblPhone.Location = new Point(labelX, startY + rowSpacing * 3);
            lblPhone.TextAlign = ContentAlignment.MiddleRight;
            mainPanel.Controls.Add(lblPhone);

            txtPhone = new TextBox();
            txtPhone.BackColor = Color.FromArgb(60, 60, 65);
            txtPhone.ForeColor = Color.White;
            txtPhone.Font = new Font("Segoe UI", 11F);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Size = new Size(fieldWidth, 30);
            txtPhone.Location = new Point(fieldX, startY + rowSpacing * 3);
            txtPhone.PlaceholderText = "(555) 123-4567";
            txtPhone.TextChanged += (s, e) => ClearResults();
            mainPanel.Controls.Add(txtPhone);

            // ============================================
            // BUTTONS
            // ============================================
            int buttonY = startY + rowSpacing * 4 + 10;

            btnSearch = new Button();
            btnSearch.Text = "SEARCH ACCOUNT";
            btnSearch.BackColor = Color.FromArgb(255, 100, 0);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Size = new Size(200, 40);
            btnSearch.Location = new Point(240, buttonY);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Click += BtnSearch_Click;
            mainPanel.Controls.Add(btnSearch);

            btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.BackColor = Color.FromArgb(100, 100, 100);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Size = new Size(200, 40);
            btnCancel.Location = new Point(470, buttonY);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += BtnCancel_Click;
            mainPanel.Controls.Add(btnCancel);

            // ============================================
            // RESULTS PANEL
            // ============================================
            int resultsY = buttonY + 50;

            resultsPanel = new Panel();
            resultsPanel.BackColor = Color.FromArgb(50, 50, 55);
            resultsPanel.Size = new Size(840, 230);
            resultsPanel.Location = new Point(40, resultsY);
            resultsPanel.Visible = false;
            resultsPanel.Padding = new Padding(15);
            mainPanel.Controls.Add(resultsPanel);

            // Results Title
            lblResultsTitle = new Label();
            lblResultsTitle.Text = "ACCOUNT FOUND";
            lblResultsTitle.Font = new Font("Impact", 16F, FontStyle.Bold);
            lblResultsTitle.ForeColor = Color.FromArgb(76, 175, 80);
            lblResultsTitle.Size = new Size(300, 30);
            lblResultsTitle.Location = new Point(270, 10);
            lblResultsTitle.TextAlign = ContentAlignment.MiddleCenter;
            resultsPanel.Controls.Add(lblResultsTitle);

            // DataGridView for results
            dgvResults = new DataGridView();
            dgvResults.BackgroundColor = Color.FromArgb(60, 60, 65);
            dgvResults.ForeColor = Color.White;
            dgvResults.Font = new Font("Segoe UI", 10F);
            dgvResults.Size = new Size(800, 150);
            dgvResults.Location = new Point(20, 50);
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
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvResults.ColumnHeadersHeight = 35;

            // Cell styling
            dgvResults.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 65);
            dgvResults.DefaultCellStyle.ForeColor = Color.White;
            dgvResults.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 100, 0);
            dgvResults.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvResults.DefaultCellStyle.Padding = new Padding(8);

            dgvResults.CellDoubleClick += DgvResults_CellDoubleClick;
            resultsPanel.Controls.Add(dgvResults);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
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
            accountFound = false;
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
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

                    string query = @"SELECT AdminID, FirstName, LastName, Email, Username, Role, Phone 
                                    FROM Admins 
                                    WHERE FirstName = @FirstName 
                                    AND LastName = @LastName 
                                    AND Email = @Email 
                                    AND Phone = @Phone";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        if (dt.Rows.Count > 0)
                        {
                            dgvResults.DataSource = dt;

                            if (dgvResults.Columns["AdminID"] != null)
                                dgvResults.Columns["AdminID"].Visible = false;
                            if (dgvResults.Columns["Phone"] != null)
                                dgvResults.Columns["Phone"].Visible = false;

                            if (dgvResults.Columns["FirstName"] != null)
                                dgvResults.Columns["FirstName"].HeaderText = "First Name";
                            if (dgvResults.Columns["LastName"] != null)
                                dgvResults.Columns["LastName"].HeaderText = "Last Name";

                            resultsPanel.Visible = true;

                            if (dt.Rows.Count == 1)
                            {
                                lblResultsTitle.Text = "ACCOUNT FOUND";
                                lblResultsTitle.ForeColor = Color.FromArgb(76, 175, 80);

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
                            }
                        }
                        else
                        {
                            resultsPanel.Visible = false;
                            MessageBox.Show("No account found matching the provided information.\n\nPlease check your First Name, Last Name, Email, and Phone number.",
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

                if (row.Cells["AdminID"].Value != null)
                    foundAdminID = Convert.ToInt32(row.Cells["AdminID"].Value);

                foundEmail = row.Cells["Email"].Value?.ToString() ?? "";
                foundUsername = row.Cells["Username"].Value?.ToString() ?? "";

                accountFound = true;
            }
        }

        private async void DgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvResults.Rows[e.RowIndex];

                int adminId = Convert.ToInt32(row.Cells["AdminID"].Value);
                string email = row.Cells["Email"].Value?.ToString() ?? "";
                string username = row.Cells["Username"].Value?.ToString() ?? "";

                string newPassword = ShowPasswordDialog(email, username);
                if (!string.IsNullOrEmpty(newPassword))
                {
                    await UpdatePassword(adminId, newPassword, email);
                }
            }
        }

        private string ShowPasswordDialog(string email, string username)
        {
            Form passwordForm = new Form();
            passwordForm.Text = "Update Password";
            passwordForm.Size = new Size(450, 280);
            passwordForm.StartPosition = FormStartPosition.CenterParent;
            passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordForm.MaximizeBox = false;
            passwordForm.MinimizeBox = false;
            passwordForm.BackColor = Color.FromArgb(30, 30, 30);
            passwordForm.ForeColor = Color.White;
            passwordForm.Font = new Font("Segoe UI", 9F);

            Label lblInfo = new Label();
            lblInfo.Text = $"Account: {username}\n{email}";
            lblInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(255, 150, 0);
            lblInfo.Size = new Size(350, 50);
            lblInfo.Location = new Point(50, 15);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            passwordForm.Controls.Add(lblInfo);

            Label lblNewPassword = new Label();
            lblNewPassword.Text = "New Password:";
            lblNewPassword.Location = new Point(50, 80);
            lblNewPassword.Size = new Size(120, 25);
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(lblNewPassword);

            TextBox txtNewPassword = new TextBox();
            txtNewPassword.Location = new Point(180, 78);
            txtNewPassword.Size = new Size(200, 28);
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.BackColor = Color.FromArgb(60, 60, 65);
            txtNewPassword.ForeColor = Color.White;
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(txtNewPassword);

            Label lblConfirmPassword = new Label();
            lblConfirmPassword.Text = "Confirm:";
            lblConfirmPassword.Location = new Point(50, 120);
            lblConfirmPassword.Size = new Size(120, 25);
            lblConfirmPassword.ForeColor = Color.White;
            lblConfirmPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(lblConfirmPassword);

            TextBox txtConfirmPassword = new TextBox();
            txtConfirmPassword.Location = new Point(180, 118);
            txtConfirmPassword.Size = new Size(200, 28);
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.BackColor = Color.FromArgb(60, 60, 65);
            txtConfirmPassword.ForeColor = Color.White;
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            passwordForm.Controls.Add(txtConfirmPassword);

            Panel buttonPanel = new Panel();
            buttonPanel.Size = new Size(220, 38);
            buttonPanel.Location = new Point(115, 165);
            buttonPanel.BackColor = Color.Transparent;
            passwordForm.Controls.Add(buttonPanel);

            Button btnOK = new Button();
            btnOK.Text = "UPDATE";
            btnOK.BackColor = Color.FromArgb(76, 175, 80);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.ForeColor = Color.White;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOK.Location = new Point(0, 0);
            btnOK.Size = new Size(100, 36);
            btnOK.Cursor = Cursors.Hand;
            btnOK.DialogResult = DialogResult.OK;
            buttonPanel.Controls.Add(btnOK);

            Button btnCancelDialog = new Button();
            btnCancelDialog.Text = "CANCEL";
            btnCancelDialog.BackColor = Color.FromArgb(100, 100, 100);
            btnCancelDialog.FlatStyle = FlatStyle.Flat;
            btnCancelDialog.FlatAppearance.BorderSize = 0;
            btnCancelDialog.ForeColor = Color.White;
            btnCancelDialog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancelDialog.Location = new Point(120, 0);
            btnCancelDialog.Size = new Size(100, 36);
            btnCancelDialog.Cursor = Cursors.Hand;
            btnCancelDialog.DialogResult = DialogResult.Cancel;
            buttonPanel.Controls.Add(btnCancelDialog);

            if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters.",
                        "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ShowPasswordDialog(email, username);
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.",
                        "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ShowPasswordDialog(email, username);
                }

                return txtNewPassword.Text;
            }

            return null;
        }

        private async Task UpdatePassword(int adminId, string newPassword, string email)
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
                            MessageBox.Show($"✓ Password updated successfully for {email}!\n\nYou can now login with your new password.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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