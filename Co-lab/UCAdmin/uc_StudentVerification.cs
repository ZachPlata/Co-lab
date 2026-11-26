using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_StudentVerification : UserControl
    {
        private int _selectedUserId = 0;
        private byte[]? _currentDocBytes;
        private string _currentDocName = "";

        public uc_StudentVerification()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void uc_StudentVerification_Load(object? sender, EventArgs e)
        {
            ResetForm();
            LoadVerifications();
        }

        public void LoadVerifications(string searchKeyword = "")
        {
            try
            {
                MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();

                string query = @"SELECT UserId, FullName, Email, VerificationStatus,
                                        CASE
                                            WHEN VerificationDocument IS NOT NULL THEN 'Uploaded'
                                            ELSE 'None'
                                        END AS DocStatus
                                 FROM tbl_users
                                 WHERE Role = 'Student' AND is_blacklisted = 0";

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query += " AND (FullName LIKE @kw OR Email LIKE @kw OR VerificationStatus LIKE @kw)";
                    cmd.Parameters.AddWithValue("@kw", "%" + searchKeyword.Trim() + "%");
                }

                query += " ORDER BY (VerificationDocument IS NOT NULL) DESC, (VerificationStatus = 'Pending') DESC, UserId DESC";

                cmd.CommandText = query;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "verifs");
                conn.Close();

                DataTable dt = ds.Tables["verifs"]!;
                dgvVerifications.DataSource = dt;
                dgvVerifications.ClearSelection();

                int total = dt != null ? dt.Rows.Count : 0;
                int pending = 0;
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (string.Equals(r["VerificationStatus"]?.ToString(), "Pending", StringComparison.OrdinalIgnoreCase))
                        {
                            pending++;
                        }
                    }
                }

                lblExistingTitle.Text = $"Student Verifications ({total})";
                lblTotalPending.Text = $"Pending Review: {pending}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load student verifications:\n{ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvVerifications_SelectionChanged(object? sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (dgvVerifications.SelectedRows.Count == 0)
            {
                ResetForm();
                return;
            }

            var row = dgvVerifications.SelectedRows[0];
            if (row.Cells["colUserId"]?.Value != null &&
                int.TryParse(row.Cells["colUserId"].Value?.ToString(), out int uid))
            {
                _selectedUserId = uid;
                txtStudentName.Text = row.Cells["colFullName"]?.Value?.ToString() ?? "";
                txtStudentEmail.Text = row.Cells["colEmail"]?.Value?.ToString() ?? "";
                LoadSelectedDocument(uid);
                SetActionMode(true);
            }
        }

        private void LoadSelectedDocument(int userId)
        {
            picDocument.Image?.Dispose();
            picDocument.Image = null;
            _currentDocBytes = null;
            _currentDocName = "";
            txtDocName.Text = "";
            txtVerificationNote.Text = "";

            try
            {
                MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "SELECT VerificationDocument, VerificationDocName, VerificationNote FROM tbl_users WHERE UserId = @uid LIMIT 1";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", userId);

                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtVerificationNote.Text = reader["VerificationNote"] != DBNull.Value ? reader["VerificationNote"].ToString() ?? "" : "";
                    _currentDocName = reader["VerificationDocName"] != DBNull.Value ? reader["VerificationDocName"].ToString() ?? "" : "";

                    if (reader["VerificationDocument"] != DBNull.Value)
                    {
                        _currentDocBytes = (byte[])reader["VerificationDocument"];
                    }
                }
                conn.Close();

                if (_currentDocBytes != null && _currentDocBytes.Length > 0)
                {
                    txtDocName.Text = string.IsNullOrWhiteSpace(_currentDocName) ? "Uploaded Document" : _currentDocName;
                    btnDownloadDoc.Enabled = true;

                    try
                    {
                        using MemoryStream ms = new MemoryStream(_currentDocBytes);
                        using Image img = Image.FromStream(ms);
                        picDocument.Image = new Bitmap(img);
                    }
                    catch
                    {
                        picDocument.Image = null;
                    }
                }
                else
                {
                    txtDocName.Text = "No document uploaded";
                    btnDownloadDoc.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load document:\n{ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvVerifications_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvVerifications.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                string val = e.Value.ToString() ?? "";
                if (val == "Verified")
                    e.CellStyle!.ForeColor = Color.FromArgb(74, 222, 128);
                else if (val == "Declined")
                    e.CellStyle!.ForeColor = Color.FromArgb(248, 113, 113);
                else
                    e.CellStyle!.ForeColor = Color.FromArgb(251, 191, 36);
            }
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            LoadVerifications(txtSearch.Text);
        }

        private void btnDownloadDoc_Click(object? sender, EventArgs e)
        {
            if (_currentDocBytes == null || _currentDocBytes.Length == 0)
            {
                errorProvider1.SetError(txtDocName, "No document uploaded for this student.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = string.IsNullOrWhiteSpace(_currentDocName) ? "verification_document.png" : _currentDocName,
                Filter = "All Files (*.*)|*.*"
            };

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, _currentDocBytes);
                MessageBox.Show($"Saved to:\n{sfd.FileName}", "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApprove_Click(object? sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (_selectedUserId <= 0)
            {
                errorProvider1.SetError(txtStudentName, "Please select a student first.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Approve and verify student '{txtStudentName.Text}'?",
                "Confirm Verification",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "UPDATE tbl_users SET is_verified = 1, VerificationStatus = 'Verified', VerificationNote = NULL WHERE UserId = @uid";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", _selectedUserId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Student '{txtStudentName.Text}' has been verified.", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadVerifications(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving student:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecline_Click(object? sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (_selectedUserId <= 0)
            {
                errorProvider1.SetError(txtStudentName, "Please select a student first.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Decline verification for '{txtStudentName.Text}'?",
                "Confirm Decline",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string note = txtVerificationNote.Text.Trim();
                MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "UPDATE tbl_users SET is_verified = 0, VerificationStatus = 'Declined', VerificationNote = @note WHERE UserId = @uid";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(note) ? (object)DBNull.Value : note);
                cmd.Parameters.AddWithValue("@uid", _selectedUserId);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Student '{txtStudentName.Text}' verification declined.", "Declined", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
                LoadVerifications(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error declining student:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSelection_Click(object? sender, EventArgs e)
        {
            dgvVerifications.ClearSelection();
            ResetForm();
        }

        private void ResetForm()
        {
            errorProvider1.Clear();
            _selectedUserId = 0;
            _currentDocBytes = null;
            _currentDocName = "";
            txtStudentName.Text = "";
            txtStudentEmail.Text = "";
            txtDocName.Text = "";
            txtVerificationNote.Text = "";
            picDocument.Image?.Dispose();
            picDocument.Image = null;
            btnDownloadDoc.Enabled = false;
            SetActionMode(false);
        }

        private void SetActionMode(bool enabled)
        {
            btnApprove.Enabled = enabled;
            btnApprove.BackColor = enabled ? Color.FromArgb(46, 125, 70) : Color.FromArgb(32, 44, 35);
            btnApprove.ForeColor = enabled ? Color.White : Color.FromArgb(120, 140, 125);

            btnDecline.Enabled = enabled;
            btnDecline.BackColor = enabled ? Color.FromArgb(185, 38, 38) : Color.FromArgb(32, 44, 35);
            btnDecline.ForeColor = enabled ? Color.White : Color.FromArgb(120, 140, 125);
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