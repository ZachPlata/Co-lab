using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_ManageSkills : UserControl
    {
        private class KnownSkillItem
        {
            public int UserSkillId { get; set; }
            public string SkillName { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;

            public override string ToString() => $"{SkillName} ({Category})";
        }

        public uc_ManageSkills()
        {
            InitializeComponent();
        }

        private void uc_ManageSkills_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            if (cmbDeliveryMode.Items.Count > 0 && cmbDeliveryMode.SelectedIndex < 0)
            {
                cmbDeliveryMode.SelectedIndex = 0;
            }

            LoadKnownSkillsDropdown();
            LoadMyListings();
        }

        /// <summary>
        /// Populates the dropdown with skills the logged-in student has in tbl_user_skills.
        /// </summary>
        public void LoadKnownSkillsDropdown()
        {
            cmbKnownSkills.Items.Clear();

            try
            {
                int uid = UserSession.UserId;
                DataTable dt;

                if (uid > 0)
                {
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT UserSkillId, SkillName, Category FROM tbl_user_skills WHERE UserId = @uid ORDER BY SkillName ASC",
                        new MySqlParameter("@uid", uid));
                }
                else
                {
                    dt = DatabaseHelper.ExecuteQuery(
                        @"SELECT s.UserSkillId, s.SkillName, s.Category 
                          FROM tbl_user_skills s 
                          INNER JOIN tbl_users u ON s.UserId = u.UserId 
                          WHERE u.FullName = @name ORDER BY s.SkillName ASC",
                        new MySqlParameter("@name", UserSession.FullName));
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbKnownSkills.Items.Add(new KnownSkillItem
                        {
                            UserSkillId = Convert.ToInt32(row["UserSkillId"]),
                            SkillName = row["SkillName"]?.ToString() ?? "",
                            Category = row["Category"]?.ToString() ?? "General"
                        });
                    }
                    cmbKnownSkills.SelectedIndex = 0;
                }
                else
                {
                    cmbKnownSkills.Items.Add("-- No known skills yet (Add in Dashboard first) --");
                    cmbKnownSkills.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading known skills: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads the student's public marketplace offerings from tbl_skills.
        /// </summary>
        public void LoadMyListings()
        {
            try
            {
                int uid = UserSession.UserId;
                string fullName = UserSession.FullName;

                string query = @"SELECT 
                                    SkillId, 
                                    SkillTitle AS [Offered Skill], 
                                    Category, 
                                    DesiredSkill AS [Wanted In Exchange], 
                                    DeliveryMode AS [Mode], 
                                    Location AS [Meeting Place / Tool], 
                                    Status, 
                                    CreatedAt AS [Date Posted] 
                                 FROM tbl_skills 
                                 WHERE (UserId = @uid OR OfferedBy = @name) AND Status != 'Archived' 
                                 ORDER BY SkillId DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@name", fullName));

                dgvMyListings.DataSource = dt;

                if (dgvMyListings.Columns["SkillId"] != null)
                {
                    dgvMyListings.Columns["SkillId"].Visible = false;
                }

                int activeCount = 0;
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (string.Equals(r["Status"]?.ToString(), "Active", StringComparison.OrdinalIgnoreCase))
                        {
                            activeCount++;
                        }
                    }
                    lblListingsCount.Text = $"{activeCount} active listing{(activeCount == 1 ? "" : "s")}";
                }
                else
                {
                    lblListingsCount.Text = "0 active listings";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading listings: {ex.Message}");
            }
        }

        private void btnPublishListing_Click(object sender, EventArgs e)
        {
            if (cmbKnownSkills.SelectedItem is not KnownSkillItem selectedKnownSkill)
            {
                MessageBox.Show(
                    "You must first have known skills added to your profile inventory!\n\n" +
                    "Please go to your Student Dashboard to add the skills you know, then return here to publish them to the marketplace.",
                    "No Known Skill Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string desiredSkill = txtDesiredSkill.Text.Trim();
            if (string.IsNullOrWhiteSpace(desiredSkill))
            {
                MessageBox.Show("Please specify what skill you would like to receive in exchange (e.g. Photoshop, Python help, Calculus).", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesiredSkill.Focus();
                return;
            }

            string deliveryMode = cmbDeliveryMode.SelectedItem?.ToString() ?? "Online";
            string location = txtLocation.Text.Trim();
            if (string.IsNullOrWhiteSpace(location))
            {
                location = deliveryMode == "Online" ? "Discord / Google Meet" : "Campus Library";
            }

            string description = txtDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a short description of what you will teach and what topics you can cover.", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            int uid = UserSession.UserId;
            string offeredBy = string.IsNullOrWhiteSpace(UserSession.FullName) ? "Zach Plata" : UserSession.FullName;

            try
            {
                string insertSql = @"INSERT INTO tbl_skills 
                    (UserId, UserSkillId, SkillTitle, Category, Description, OfferedBy, DesiredSkill, DeliveryMode, Location, Status) 
                    VALUES 
                    (@uid, @userSkillId, @title, @category, @desc, @offeredBy, @desired, @mode, @loc, 'Active')";

                int rows = DatabaseHelper.ExecuteNonQuery(insertSql,
                    new MySqlParameter("@uid", uid),
                    new MySqlParameter("@userSkillId", selectedKnownSkill.UserSkillId),
                    new MySqlParameter("@title", selectedKnownSkill.SkillName),
                    new MySqlParameter("@category", selectedKnownSkill.Category),
                    new MySqlParameter("@desc", description),
                    new MySqlParameter("@offeredBy", offeredBy),
                    new MySqlParameter("@desired", desiredSkill),
                    new MySqlParameter("@mode", deliveryMode),
                    new MySqlParameter("@loc", location));

                if (rows > 0)
                {
                    MessageBox.Show($"'{selectedKnownSkill.SkillName}' has been published to the marketplace!", "Offer Published", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadMyListings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to publish listing: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            if (cmbKnownSkills.Items.Count > 0) cmbKnownSkills.SelectedIndex = 0;
            txtDesiredSkill.Clear();
            if (cmbDeliveryMode.Items.Count > 0) cmbDeliveryMode.SelectedIndex = 0;
            txtLocation.Clear();
            txtDescription.Clear();
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvMyListings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a listing from the table to pause or activate.", "Select Listing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvMyListings.SelectedRows[0];
            if (row.Cells["SkillId"]?.Value == null || !int.TryParse(row.Cells["SkillId"].Value.ToString(), out int skillId))
            {
                MessageBox.Show("Invalid listing selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = row.Cells["Status"]?.Value?.ToString() ?? "Active";
            string newStatus = string.Equals(currentStatus, "Active", StringComparison.OrdinalIgnoreCase) ? "Paused" : "Active";

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_skills SET Status = @status WHERE SkillId = @id",
                    new MySqlParameter("@status", newStatus),
                    new MySqlParameter("@id", skillId));

                if (rows > 0)
                {
                    MessageBox.Show($"Listing status changed to '{newStatus}'.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMyListings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteListing_Click(object sender, EventArgs e)
        {
            if (dgvMyListings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a listing from the table to delete.", "Select Listing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvMyListings.SelectedRows[0];
            if (row.Cells["SkillId"]?.Value == null || !int.TryParse(row.Cells["SkillId"].Value.ToString(), out int skillId))
            {
                MessageBox.Show("Invalid listing selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string skillTitle = row.Cells["Offered Skill"]?.Value?.ToString() ?? "this listing";

            if (MessageBox.Show($"Are you sure you want to delete '{skillTitle}' from the marketplace?\n\n(This will not delete the skill from your profile bio).", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                int rows = DatabaseHelper.ExecuteNonQuery(
                    "DELETE FROM tbl_skills WHERE SkillId = @id",
                    new MySqlParameter("@id", skillId));

                if (rows > 0)
                {
                    MessageBox.Show("Listing deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMyListings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting listing: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadKnownSkillsDropdown();
            LoadMyListings();
        }
    }
}
