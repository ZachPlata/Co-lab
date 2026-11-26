using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_SkillCategories : UserControl
    {
        private int _selectedCategoryId = 0;
        private string _originalCategoryName = "";
        private readonly ErrorProvider _errorProvider;

        public uc_SkillCategories()
        {
            InitializeComponent();
            _errorProvider = ValidationHelper.Create(this);
            txtCategoryName.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtCategoryName);
            txtDescription.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtDescription);

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void uc_SkillCategories_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadCategories();
        }

        /// <summary>
        /// Loads categories from the database into the DataGridView with optional search keyword filtering.
        /// </summary>
        public void LoadCategories(string searchKeyword = "")
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();

                string query = "SELECT CategoryId, CategoryName, IFNULL(Description, '') AS Description FROM tbl_categories WHERE 1=1";
                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query += " AND (CategoryName LIKE @kw OR Description LIKE @kw)";
                    cmd.Parameters.AddWithValue("@kw", "%" + searchKeyword.Trim() + "%");
                }
                query += " ORDER BY CategoryId ASC";

                cmd.CommandText = query;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds, "categories");
                conn.Close();

                DataTable dt = ds.Tables["categories"]!;
                dgvCategories.DataSource = dt;

                int count = dt != null ? dt.Rows.Count : 0;
                lblExistingTitle.Text = $"Existing Categories ({count})";

                UpdateTotalListingsTagged();
            }
            catch (Exception ex)
{
                lblExistingTitle.Text = "Existing Categories (0)";
                MessageBox.Show($"Could not load categories:\n{ex.Message}\n\nPlease verify XAMPP MySQL is active.",
                    "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Calculates and displays the total count of skills currently tagged with categories.
        /// </summary>
        private void UpdateTotalListingsTagged()
        {
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM tbl_skills WHERE Category IN (SELECT CategoryName FROM tbl_categories);";
                cmd.Connection = conn;

                int total = 0;
                using MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() && reader[0] != DBNull.Value)
                {
                    int.TryParse(reader[0].ToString(), out total);
                }
                conn.Close();
                lblTotalTagged.Text = $"Total Listings Tagged: {total}";
            }
            catch
            {
                lblTotalTagged.Text = "Total Listings Tagged: 0";
            }
        }

        // ==========================================
        // GRID EVENTS & CELL ACTIONS
        // ==========================================

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                SetEditMode(false);
                return;
            }

            var row = dgvCategories.SelectedRows[0];
            if (row.Cells["colId"]?.Value != null &&
                int.TryParse(row.Cells["colId"].Value?.ToString(), out int catId))
            {
                _selectedCategoryId = catId;
                _originalCategoryName = row.Cells["colName"]?.Value?.ToString() ?? "";
                txtCategoryName.Text = _originalCategoryName;
                txtDescription.Text = row.Cells["colDesc"]?.Value?.ToString() ?? "";
                SetEditMode(true);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCategories(txtSearch.Text);
        }

        // ==========================================
        // BUTTON HANDLERS (ADD / UPDATE / DELETE / CLEAR)
        // ==========================================

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ValidationHelper.ClearAll(_errorProvider);
            string name = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();
            Control? firstInvalid = null;

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 100)
            {
                ValidationHelper.SetError(_errorProvider, txtCategoryName, "Category name must be 3–100 characters.");
                firstInvalid ??= txtCategoryName;
            }

            if (desc.Length > 300)
            {
                ValidationHelper.SetError(_errorProvider, txtDescription, "Description cannot exceed 300 characters.");
                firstInvalid ??= txtDescription;
            }

            if (firstInvalid != null)
            {
                firstInvalid.Focus();
                return;
            }

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                // Check for duplicates
                MySqlCommand dupCmd = new MySqlCommand();
                dupCmd.CommandText = "SELECT COUNT(*) FROM tbl_categories WHERE LOWER(CategoryName) = LOWER(@name)";
                dupCmd.Connection = conn;
                dupCmd.Parameters.AddWithValue("@name", name);

                int existing = 0;
                using (MySqlDataReader reader = dupCmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        int.TryParse(reader[0].ToString(), out existing);
                    }
                }

                if (existing > 0)
                {
                    conn.Close();
                    ValidationHelper.SetError(_errorProvider, txtCategoryName, $"A category named '{name}' already exists.");
                    txtCategoryName.Focus();
                    return;
                }

                MySqlCommand insertCmd = new MySqlCommand();
                insertCmd.CommandText = "INSERT INTO tbl_categories (CategoryName, Description) VALUES (@name, @desc)";
                insertCmd.Connection = conn;
                insertCmd.Parameters.AddWithValue("@name", name);
                insertCmd.Parameters.AddWithValue("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc);
                int rows = insertCmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show($"Category '{name}' was successfully added!", "Category Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadCategories(txtSearch.Text);
                }
            }
            catch (Exception ex)
{
                MessageBox.Show($"Error adding category:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ValidationHelper.ClearAll(_errorProvider);
            if (_selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();
            Control? firstInvalid = null;

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 100)
            {
                ValidationHelper.SetError(_errorProvider, txtCategoryName, "Category name must be 3–100 characters.");
                firstInvalid ??= txtCategoryName;
            }

            if (desc.Length > 300)
            {
                ValidationHelper.SetError(_errorProvider, txtDescription, "Description cannot exceed 300 characters.");
                firstInvalid ??= txtDescription;
            }

            if (firstInvalid != null)
            {
                firstInvalid.Focus();
                return;
            }

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                // Check if new name conflicts with another category
                MySqlCommand dupCmd = new MySqlCommand();
                dupCmd.CommandText = "SELECT COUNT(*) FROM tbl_categories WHERE LOWER(CategoryName) = LOWER(@name) AND CategoryId != @id";
                dupCmd.Connection = conn;
                dupCmd.Parameters.AddWithValue("@name", name);
                dupCmd.Parameters.AddWithValue("@id", _selectedCategoryId);

                int existing = 0;
                using (MySqlDataReader reader = dupCmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        int.TryParse(reader[0].ToString(), out existing);
                    }
                }

                if (existing > 0)
                {
                    conn.Close();
                    ValidationHelper.SetError(_errorProvider, txtCategoryName, $"Another category named '{name}' already exists.");
                    txtCategoryName.Focus();
                    return;
                }

                using MySqlTransaction tx = conn.BeginTransaction();

                MySqlCommand updateCmd = new MySqlCommand();
                updateCmd.CommandText = "UPDATE tbl_categories SET CategoryName = @name, Description = @desc WHERE CategoryId = @id";
                updateCmd.Connection = conn;
                updateCmd.Transaction = tx;
                updateCmd.Parameters.AddWithValue("@name", name);
                updateCmd.Parameters.AddWithValue("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc);
                updateCmd.Parameters.AddWithValue("@id", _selectedCategoryId);
                int rows = updateCmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    if (!string.Equals(_originalCategoryName, name, StringComparison.OrdinalIgnoreCase))
                    {
                        MySqlCommand syncSkillsCmd = new MySqlCommand();
                        syncSkillsCmd.CommandText = "UPDATE tbl_skills SET Category = @newName WHERE Category = @oldName";
                        syncSkillsCmd.Connection = conn;
                        syncSkillsCmd.Transaction = tx;
                        syncSkillsCmd.Parameters.AddWithValue("@newName", name);
                        syncSkillsCmd.Parameters.AddWithValue("@oldName", _originalCategoryName);
                        syncSkillsCmd.ExecuteNonQuery();

                        MySqlCommand syncUserSkillsCmd = new MySqlCommand();
                        syncUserSkillsCmd.CommandText = "UPDATE tbl_user_skills SET Category = @newName WHERE Category = @oldName";
                        syncUserSkillsCmd.Connection = conn;
                        syncUserSkillsCmd.Transaction = tx;
                        syncUserSkillsCmd.Parameters.AddWithValue("@newName", name);
                        syncUserSkillsCmd.Parameters.AddWithValue("@oldName", _originalCategoryName);
                        syncUserSkillsCmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    conn.Close();
                    MessageBox.Show($"Category '{name}' was updated successfully!", "Category Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadCategories(txtSearch.Text);
                }
                else
                {
                    tx.Rollback();
                    conn.Close();
                }
            }
            catch (Exception ex)
{
                MessageBox.Show($"Error updating category:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = _originalCategoryName;

            int taggedListings = 0;
            int taggedUserSkills = 0;
            try
            {
                using MySqlConnection checkConn = DatabaseHelper.GetConnection();
                checkConn.Open();

                using (MySqlCommand checkCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM tbl_skills WHERE Category = @cat", checkConn))
                {
                    checkCmd.Parameters.AddWithValue("@cat", name);
                    taggedListings = Convert.ToInt32(checkCmd.ExecuteScalar());
                }

                using (MySqlCommand checkUserCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM tbl_user_skills WHERE Category = @cat", checkConn))
                {
                    checkUserCmd.Parameters.AddWithValue("@cat", name);
                    taggedUserSkills = Convert.ToInt32(checkUserCmd.ExecuteScalar());
                }
            }
            catch
            {
                MessageBox.Show("Could not verify category usage. Please check your database connection.", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (taggedListings > 0 || taggedUserSkills > 0)
            {
                MessageBox.Show(
                    $"Cannot delete category '{name}' because it is currently in use:\n\n" +
                    $"• Marketplace listings: {taggedListings}\n" +
                    $"• Student bio skills: {taggedUserSkills}\n\n" +
                    "Rename the category or reassign those skills first.",
                    "Category In Use",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = $"Are you sure you want to delete the category '{name}'?";

            if (MessageBox.Show(confirmMsg, "Confirm Category Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "DELETE FROM tbl_categories WHERE CategoryId = @id";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", _selectedCategoryId);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show($"Category '{name}' was successfully removed.", "Category Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadCategories(txtSearch.Text);
                }
            }
            catch (Exception ex)
{
                MessageBox.Show($"Error deleting category:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _selectedCategoryId = 0;
            _originalCategoryName = "";
            txtCategoryName.Text = "";
            txtDescription.Text = "";
            dgvCategories.ClearSelection();
            SetEditMode(false);
        }

        private void SetEditMode(bool isEditing)
        {
            if (isEditing)
            {
                btnUpdate.Enabled = true;
                btnUpdate.BackColor = Color.FromArgb(46, 125, 70);
                btnUpdate.ForeColor = Color.White;

                btnDelete.Enabled = true;
                btnDelete.BackColor = Color.FromArgb(185, 38, 38);
                btnDelete.ForeColor = Color.White;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.BackColor = Color.FromArgb(32, 44, 35);
                btnUpdate.ForeColor = Color.FromArgb(120, 140, 125);

                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.FromArgb(32, 44, 35);
                btnDelete.ForeColor = Color.FromArgb(120, 140, 125);
            }
        }

        // ==========================================
        // CUSTOM ROUNDED CORNERS PAINT
        // ==========================================

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

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
