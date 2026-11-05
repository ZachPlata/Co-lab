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

        public uc_SkillCategories()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void uc_SkillCategories_Load(object sender, EventArgs e)
        {
            EnsureDatabaseSchema();
            ResetForm();
            LoadCategories();
        }

        /// <summary>
        /// Ensures tbl_categories has the Description column if it doesn't already exist.
        /// </summary>
        private void EnsureDatabaseSchema()
        {
            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "ALTER TABLE tbl_categories ADD COLUMN IF NOT EXISTS Description TEXT DEFAULT NULL;");
            }
            catch
            {
                // Column might already exist or user lacks alter permission, which is safe to ignore
            }
        }

        /// <summary>
        /// Loads categories from the database into the DataGridView with optional search keyword filtering.
        /// </summary>
        public void LoadCategories(string searchKeyword = "")
        {
            try
            {
                string query = "SELECT CategoryId, CategoryName, IFNULL(Description, '') AS Description FROM tbl_categories WHERE 1=1";
                var parameters = new System.Collections.Generic.List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(searchKeyword))
                {
                    query += " AND (CategoryName LIKE @kw OR Description LIKE @kw)";
                    parameters.Add(new MySqlParameter("@kw", "%" + searchKeyword.Trim() + "%"));
                }

                query += " ORDER BY CategoryId ASC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
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
                object? result = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_skills WHERE Category IN (SELECT CategoryName FROM tbl_categories);");

                int total = result != null && int.TryParse(result.ToString(), out int val) ? val : 0;
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

        private void dgvCategories_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colActions.Index)
            {
                e.Value = "✏   🗑";
                e.FormattingApplied = true;
            }
        }

        private void dgvCategories_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colActions.Index)
            {
                dgvCategories.Cursor = Cursors.Hand;
            }
            else
            {
                dgvCategories.Cursor = Cursors.Default;
            }
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // If action cell clicked (✏ or 🗑)
            if (e.ColumnIndex == colActions.Index)
            {
                var cellRect = dgvCategories.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point pt = dgvCategories.PointToClient(Cursor.Position);

                // Left half of cell: Edit (✏)
                if (pt.X - cellRect.Left < cellRect.Width / 2)
                {
                    dgvCategories.Rows[e.RowIndex].Selected = true;
                    txtCategoryName.Focus();
                    txtCategoryName.SelectAll();
                }
                // Right half of cell: Delete (🗑)
                else
                {
                    dgvCategories.Rows[e.RowIndex].Selected = true;
                    btnDelete.PerformClick();
                }
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
            string name = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a category name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Focus();
                return;
            }

            try
            {
                // Check for duplicates
                object? dupCheck = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_categories WHERE LOWER(CategoryName) = LOWER(@name)",
                    new MySqlParameter("@name", name));

                if (dupCheck != null && int.TryParse(dupCheck.ToString(), out int existing) && existing > 0)
                {
                    MessageBox.Show($"A category named '{name}' already exists.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                int rows = DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO tbl_categories (CategoryName, Description) VALUES (@name, @desc)",
                    new MySqlParameter("@name", name),
                    new MySqlParameter("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc));

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
            if (_selectedCategoryId <= 0)
            {
                MessageBox.Show("Please select a category from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = txtCategoryName.Text.Trim();
            string desc = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Category name cannot be empty.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Focus();
                return;
            }

            try
            {
                // Check if new name conflicts with another category
                object? dupCheck = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_categories WHERE LOWER(CategoryName) = LOWER(@name) AND CategoryId != @id",
                    new MySqlParameter("@name", name),
                    new MySqlParameter("@id", _selectedCategoryId));

                if (dupCheck != null && int.TryParse(dupCheck.ToString(), out int existing) && existing > 0)
                {
                    MessageBox.Show($"Another category named '{name}' already exists.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                int rows = DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_categories SET CategoryName = @name, Description = @desc WHERE CategoryId = @id",
                    new MySqlParameter("@name", name),
                    new MySqlParameter("@desc", string.IsNullOrEmpty(desc) ? (object)DBNull.Value : desc),
                    new MySqlParameter("@id", _selectedCategoryId));

                if (rows > 0)
                {
                    // If name changed, update listings tagged under old name
                    if (!string.Equals(_originalCategoryName, name, StringComparison.OrdinalIgnoreCase))
                    {
                        DatabaseHelper.ExecuteNonQuery(
                            "UPDATE tbl_skills SET Category = @newName WHERE Category = @oldName",
                            new MySqlParameter("@newName", name),
                            new MySqlParameter("@oldName", _originalCategoryName));
                    }

                    MessageBox.Show($"Category '{name}' was updated successfully!", "Category Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                    LoadCategories(txtSearch.Text);
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

            // Check if any listings are tagged with this category
            int taggedListings = 0;
            try
            {
                object? countObj = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM tbl_skills WHERE Category = @cat",
                    new MySqlParameter("@cat", name));

                if (countObj != null && int.TryParse(countObj.ToString(), out int c))
                {
                    taggedListings = c;
                }
            }
            catch
            {
                // Ignored
            }

            string confirmMsg = $"Are you sure you want to delete the category '{name}'?";
            if (taggedListings > 0)
            {
                confirmMsg += $"\n\nWarning: There are {taggedListings} active skill listing(s) tagged under this category!";
            }

            if (MessageBox.Show(confirmMsg, "Confirm Category Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM tbl_categories WHERE CategoryId = @id",
                    new MySqlParameter("@id", _selectedCategoryId));

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
    }
}
