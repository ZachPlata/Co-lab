using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_StudentLists : UserControl
    {
        private int _selectedUserId = 0;

        public uc_StudentLists()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void uc_StudentLists_Load(object? sender, EventArgs e)
        {
            ResetForm();
            LoadUsers();
        }

        public void LoadUsers(string searchKeyword = "")
        {
            try
            {
                MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();

                string query = @"SELECT UserId, FullName, Email, Role,
                                        CASE
                                            WHEN is_blacklisted = 1 THEN 'Blacklisted'
                                            WHEN is_verified = 1 OR VerificationStatus = 'Verified' THEN 'Verified'
                                            WHEN VerificationStatus = 'Declined' THEN 'Declined'
                                            ELSE 'Pending'
                                        END AS DisplayStatus
                                 FROM tbl_users
                                 WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query += " AND (FullName LIKE @kw OR Email LIKE @kw OR Role LIKE @kw OR VerificationStatus LIKE @kw)";
                    cmd.Parameters.AddWithValue("@kw", "%" + searchKeyword.Trim() + "%");
                }

                query += " ORDER BY UserId ASC";

                cmd.CommandText = query;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "users");
                conn.Close();

                DataTable dt = ds.Tables["users"]!;
                dgvUsers.DataSource = dt;
                dgvUsers.ClearSelection();

                int count = dt != null ? dt.Rows.Count : 0;
                lblExistingTitle.Text = $"Registered Users ({count})";
                lblTotalUsers.Text = $"Total Accounts: {count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load users:\n{ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsers_SelectionChanged(object? sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dgvUsers.SelectedRows.Count == 0)
            {
                SetEditMode(false);
                return;
            }

            var row = dgvUsers.SelectedRows[0];
            if (row.Cells["colUserId"]?.Value != null &&
                int.TryParse(row.Cells["colUserId"].Value?.ToString(), out int uid))
            {
                _selectedUserId = uid;
                txtFullName.Text = row.Cells["colFullName"]?.Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["colEmail"]?.Value?.ToString() ?? "";

                string role = row.Cells["colRole"]?.Value?.ToString() ?? "Student";
                cmbRole.SelectedItem = cmbRole.Items.Contains(role) ? role : "Student";

                string status = row.Cells["colStatus"]?.Value?.ToString() ?? "Pending";
                cmbStatus.SelectedItem = cmbStatus.Items.Contains(status) ? status : "Pending";

                SetEditMode(true);
            }
        }

        private void dgvUsers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvUsers.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                string val = e.Value.ToString() ?? "";
                if (val == "Verified")
                    e.CellStyle!.ForeColor = Color.FromArgb(74, 222, 128);
                else if (val == "Blacklisted" || val == "Declined")
                    e.CellStyle!.ForeColor = Color.FromArgb(248, 113, 113);
                else
                    e.CellStyle!.ForeColor = Color.FromArgb(251, 191, 36);
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text);
        }

        private void btnUpdateUser_Click(object? sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (_selectedUserId <= 0)
            {
                errorProvider1.SetError(txtFullName, "Please select a user from the table.");
                return;
            }

            if (cmbRole.SelectedItem == null)
            {
                errorProvider1.SetError(cmbRole, "Please select a role.");
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                errorProvider1.SetError(cmbStatus, "Please select a status.");
                return;
            }

            string newRole = cmbRole.SelectedItem.ToString()!;
            string newStatus = cmbStatus.SelectedItem.ToString()!;

            if (_selectedUserId == UserSession.UserId &&
                (!string.Equals(newRole, "Admin", StringComparison.OrdinalIgnoreCase) || newStatus == "Blacklisted"))
            {
                errorProvider1.SetError(cmbRole, "You cannot demote or blacklist your own active admin account.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Update '{txtFullName.Text}' to Role: {newRole}, Status: {newStatus}?",
                "Confirm Account Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();

                int isVerified = newStatus == "Verified" ? 1 : 0;
                int isBlacklisted = newStatus == "Blacklisted" ? 1 : 0;
                string verificationStatus = newStatus == "Blacklisted" ? "Pending" : newStatus;

                cmd.CommandText = @"UPDATE tbl_users
                                    SET Role = @role,
                                        is_verified = @verified,
                                        VerificationStatus = @vstatus,
                                        is_blacklisted = @blacklisted,
                                        BanReason = @banReason
                                    WHERE UserId = @uid";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@role", newRole);
                cmd.Parameters.AddWithValue("@verified", isVerified);
                cmd.Parameters.AddWithValue("@vstatus", verificationStatus);
                cmd.Parameters.AddWithValue("@blacklisted", isBlacklisted);
                cmd.Parameters.AddWithValue("@banReason", isBlacklisted == 1 ? "Blacklisted by Admin" : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@uid", _selectedUserId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Account '{txtFullName.Text}' updated successfully.", "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadUsers(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSelection_Click(object? sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            errorProvider1.Clear();
            _selectedUserId = 0;
            txtFullName.Text = "";
            txtEmail.Text = "";
            cmbRole.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dgvUsers.ClearSelection();
            SetEditMode(false);
        }

        private void SetEditMode(bool enabled)
        {
            cmbRole.Enabled = enabled;
            cmbStatus.Enabled = enabled;
            btnUpdateUser.Enabled = enabled;
            btnUpdateUser.BackColor = enabled ? Color.FromArgb(46, 125, 70) : Color.FromArgb(32, 44, 35);
            btnUpdateUser.ForeColor = enabled ? Color.White : Color.FromArgb(120, 140, 125);
        }

        private void RoundPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control ctrl) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(1, 1, ctrl.Width - 3, ctrl.Height - 3);
            using var path = CreateRoundedRectanglePath(rect, 10);
            using var borderPen = new Pen(Color.FromArgb(40, 56, 45), 1.5f);
            e.Graphics.DrawPath(borderPen, path);
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}