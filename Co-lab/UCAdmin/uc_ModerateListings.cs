using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_ModerateListings : UserControl
    {
        public uc_ModerateListings()
        {
            InitializeComponent();
        }

        private void uc_ModerateListings_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0; // "All Statuses"
            LoadListings("", "All Statuses");
        }

        /// <summary>
        /// Loads listings from tbl_skills into the DataGridView with optional search and status filter.
        /// </summary>
        public void LoadListings(string keyword, string status)
        {
            try
            {
                string query = "SELECT SkillId, SkillTitle, Category, OfferedBy, DeliveryMode, Status FROM tbl_skills WHERE 1=1";
                var parameters = new System.Collections.Generic.List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (SkillTitle LIKE @kw OR Description LIKE @kw OR OfferedBy LIKE @kw)";
                    parameters.Add(new MySqlParameter("@kw", "%" + keyword.Trim() + "%"));
                }

                if (!string.IsNullOrWhiteSpace(status) && status != "All Statuses")
                {
                    query += " AND Status = @status";
                    parameters.Add(new MySqlParameter("@status", status));
                }

                query += " ORDER BY SkillId DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
                dgvListings.DataSource = dt;
                lblStatusCount.Text = $"{dt.Rows.Count} listing(s) found";

                // Format Headers for clean display
                if (dgvListings.Columns.Contains("SkillId") && dgvListings.Columns["SkillId"] is DataGridViewColumn colId)
                {
                    colId.HeaderText = "ID";
                    colId.Width = 60;
                }
                if (dgvListings.Columns.Contains("SkillTitle") && dgvListings.Columns["SkillTitle"] is DataGridViewColumn colTitle) colTitle.HeaderText = "Skill Title";
                if (dgvListings.Columns.Contains("Category") && dgvListings.Columns["Category"] is DataGridViewColumn colCat) colCat.HeaderText = "Category";
                if (dgvListings.Columns.Contains("OfferedBy") && dgvListings.Columns["OfferedBy"] is DataGridViewColumn colOff) colOff.HeaderText = "Student";
                if (dgvListings.Columns.Contains("DeliveryMode") && dgvListings.Columns["DeliveryMode"] is DataGridViewColumn colMode) colMode.HeaderText = "Mode";
                if (dgvListings.Columns.Contains("Status") && dgvListings.Columns["Status"] is DataGridViewColumn colStat) colStat.HeaderText = "Status";
            }
            catch (Exception ex)
            {
                lblStatusCount.Text = "Database offline / Error";
                MessageBox.Show($"Could not load listings from database:\n{ex.Message}\n\nMake sure XAMPP MySQL is started.", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string? GetSelectedSkillId()
        {
            if (dgvListings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a listing from the table first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return dgvListings.SelectedRows[0].Cells["SkillId"]?.Value?.ToString();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string? id = GetSelectedSkillId();
            if (string.IsNullOrEmpty(id)) return;

            try
            {
                DatabaseHelper.ExecuteNonQuery("UPDATE tbl_skills SET Status = 'Active' WHERE SkillId = @id",
                    new MySqlParameter("@id", id));
                MessageBox.Show("Listing approved and marked as Active.", "Listing Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadCurrentView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving listing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFlag_Click(object sender, EventArgs e)
        {
            string? id = GetSelectedSkillId();
            if (string.IsNullOrEmpty(id)) return;

            try
            {
                DatabaseHelper.ExecuteNonQuery("UPDATE tbl_skills SET Status = 'Flagged' WHERE SkillId = @id",
                    new MySqlParameter("@id", id));
                MessageBox.Show("Listing flagged for moderation review.", "Listing Flagged", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ReloadCurrentView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error flagging listing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string? id = GetSelectedSkillId();
            if (string.IsNullOrEmpty(id)) return;

            DialogResult ans = MessageBox.Show(
                $"Are you sure you want to permanently delete Listing #{id}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ans == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM tbl_skills WHERE SkillId = @id",
                        new MySqlParameter("@id", id));
                    MessageBox.Show("Listing deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadCurrentView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting listing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadCurrentView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0;
            ReloadCurrentView();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadCurrentView();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void ReloadCurrentView()
        {
            LoadListings(txtSearch.Text, cmbStatusFilter.SelectedItem?.ToString() ?? "All Statuses");
        }
    }
}
