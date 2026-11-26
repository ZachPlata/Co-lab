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

        private readonly ErrorProvider _errorProvider;

        public uc_ManageSkills()
        {
            InitializeComponent();
            _errorProvider = ValidationHelper.Create(this);
            cmbKnownSkills.SelectedIndexChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, cmbKnownSkills);
            txtDesiredSkill.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtDesiredSkill);
            txtLocation.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtLocation);
            txtDescription.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtDescription);
            pnlCreateOffer.Resize += (s, e) => LayoutCreateOfferControls();
        }

        private void LayoutCreateOfferControls()
        {
            if (pnlCreateOffer == null || cmbKnownSkills == null) return;

            int leftMargin = 28;
            int rightMargin = 28;
            int gap = 26;
            int avail = Math.Max(640, pnlCreateOffer.ClientSize.Width - leftMargin - rightMargin);

            int modeWidth = 140;
            int remaining = avail - modeWidth - (gap * 3);
            int knownWidth = (int)(remaining * 0.36);
            int desiredWidth = (int)(remaining * 0.34);
            int locWidth = Math.Max(140, remaining - knownWidth - desiredWidth);

            cmbKnownSkills.Location = new Point(leftMargin, 59);
            cmbKnownSkills.Width = knownWidth;
            lblSelectKnownSkill.Location = new Point(cmbKnownSkills.Left, 39);

            txtDesiredSkill.Location = new Point(cmbKnownSkills.Right + gap, 59);
            txtDesiredSkill.Width = desiredWidth;
            lblDesiredSkill.Location = new Point(txtDesiredSkill.Left, 39);

            cmbDeliveryMode.Location = new Point(txtDesiredSkill.Right + gap, 59);
            cmbDeliveryMode.Width = modeWidth;
            lblDeliveryMode.Location = new Point(cmbDeliveryMode.Left, 39);

            txtLocation.Location = new Point(cmbDeliveryMode.Right + gap, 59);
            txtLocation.Width = locWidth;
            lblLocation.Location = new Point(txtLocation.Left, 39);
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
            LayoutCreateOfferControls();

            if (!UserSession.IsVerified)
            {
                btnPublishListing.Enabled = false;
                btnPublishListing.BackColor = Color.FromArgb(45, 52, 47);
                btnPublishListing.ForeColor = Color.FromArgb(160, 165, 160);
                btnPublishListing.Text = "🔒 Pending Verification";
                var tt = new ToolTip();
                tt.SetToolTip(btnPublishListing, "Account pending Admin verification. Publishing listings is disabled until approved.");
            }
        }

        private int ResolveCurrentUserId()
        {
            if (UserSession.UserId > 0)
            {
                return UserSession.UserId;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(UserSession.Email))
                {
                    using MySqlConnection conn = DatabaseHelper.GetConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    conn.Open();
                    cmd.CommandText = "SELECT UserId FROM tbl_users WHERE Email = @email LIMIT 1";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@email", UserSession.Email.Trim());
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() && int.TryParse(reader[0]?.ToString(), out int parsedByEmail) && parsedByEmail > 0)
                    {
                        UserSession.UserId = parsedByEmail;
                        conn.Close();
                        return parsedByEmail;
                    }
                    conn.Close();
                }

                if (!string.IsNullOrWhiteSpace(UserSession.FullName))
                {
                    using MySqlConnection conn = DatabaseHelper.GetConnection();
                    MySqlCommand cmd = new MySqlCommand();
                    conn.Open();
                    cmd.CommandText = "SELECT UserId FROM tbl_users WHERE FullName = @name LIMIT 1";
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@name", UserSession.FullName.Trim());
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read() && int.TryParse(reader[0]?.ToString(), out int parsedByName) && parsedByName > 0)
                    {
                        UserSession.UserId = parsedByName;
                        conn.Close();
                        return parsedByName;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resolving current user ID: {ex.Message}");
            }

            return 0;
        }

        /// <summary>
        /// Populates the dropdown with skills the logged-in student has in tbl_user_skills.
        /// </summary>
        public void LoadKnownSkillsDropdown()
        {
            cmbKnownSkills.Items.Clear();

            try
            {
                int uid = ResolveCurrentUserId();
                if (uid <= 0)
                {
                    cmbKnownSkills.Items.Add("-- No known skills yet (Add in Dashboard first) --");
                    cmbKnownSkills.SelectedIndex = 0;
                    return;
                }

                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT UserSkillId, SkillName, Category FROM tbl_user_skills WHERE UserId = @uid ORDER BY SkillName ASC";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", uid);
                da.SelectCommand = cmd;
                da.Fill(ds, "known");
                conn.Close();

                DataTable dt = ds.Tables["known"]!;

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
                int uid = ResolveCurrentUserId();
                string fullName = UserSession.FullName?.Trim() ?? string.Empty;

                if (uid <= 0 && string.IsNullOrWhiteSpace(fullName))
                {
                    dgvMyListings.DataSource = null;
                    lblListingsCount.Text = "0 active listings";
                    return;
                }

                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = @"SELECT 
                                        SkillId, 
                                        SkillTitle AS `Offered Skill`, 
                                        Category, 
                                        DesiredSkill AS `Wanted In Exchange`, 
                                        DeliveryMode AS `Mode`, 
                                        Location AS `Meeting Place / Tool`, 
                                        Status, 
                                        CreatedAt AS `Date Posted` 
                                    FROM tbl_skills 
                                    WHERE ((@uid > 0 AND UserId = @uid) OR (@name != '' AND OfferedBy = @name))
                                      AND Status != 'Archived' 
                                    ORDER BY SkillId DESC";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@name", fullName);
                da.SelectCommand = cmd;
                da.Fill(ds, "listings");
                conn.Close();

                DataTable dt = ds.Tables["listings"]!;

                dgvMyListings.DataSource = dt;

                if (dgvMyListings.Columns["SkillId"] is DataGridViewColumn colSkill)
                {
                    colSkill.Visible = false;
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
            if (!UserSession.IsVerified)
            {
                MessageBox.Show(
                    "Your account is pending Admin verification. You can set up your bio skills now, and publish listings once approved.",
                    "Pending Verification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ValidationHelper.ClearAll(_errorProvider);
            Control? firstInvalid = null;

            KnownSkillItem? selectedKnownSkill = cmbKnownSkills.SelectedItem as KnownSkillItem;
            if (selectedKnownSkill == null)
            {
                ValidationHelper.SetError(_errorProvider, cmbKnownSkills, "Select one of your known skills from your bio first.");
                firstInvalid ??= cmbKnownSkills;
            }

            string desiredSkill = txtDesiredSkill.Text.Trim();
            if (string.IsNullOrWhiteSpace(desiredSkill) || desiredSkill.Length < 2 || desiredSkill.Length > 150)
            {
                ValidationHelper.SetError(_errorProvider, txtDesiredSkill, "Enter a desired skill (2–150 characters).");
                firstInvalid ??= txtDesiredSkill;
            }

            string deliveryMode = cmbDeliveryMode.SelectedItem?.ToString() ?? "Online";
            string location = txtLocation.Text.Trim();
            if (string.IsNullOrWhiteSpace(location) || location.Length < 3 || location.Length > 150)
            {
                ValidationHelper.SetError(_errorProvider, txtLocation, "Enter a meeting place or online tool (3–150 characters).");
                firstInvalid ??= txtLocation;
            }

            string description = txtDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(description) || description.Length < 10 || description.Length > 500)
            {
                ValidationHelper.SetError(_errorProvider, txtDescription, "Enter a description (10–500 characters).");
                firstInvalid ??= txtDescription;
            }

            if (firstInvalid != null || selectedKnownSkill == null)
            {
                firstInvalid?.Focus();
                return;
            }

            int uid = ResolveCurrentUserId();
            string offeredBy = UserSession.FullName?.Trim() ?? string.Empty;
            if (uid <= 0 || string.IsNullOrWhiteSpace(offeredBy))
            {
                MessageBox.Show(
                    "Your user session is no longer valid. Please sign out and log in again before publishing a skill.",
                    "Session Expired",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            btnPublishListing.Enabled = false;
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                conn.Open();

                using (MySqlCommand dupCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM tbl_skills WHERE UserId = @uid AND UserSkillId = @uskid AND Status = 'Active'", conn))
                {
                    dupCmd.Parameters.AddWithValue("@uid", uid);
                    dupCmd.Parameters.AddWithValue("@uskid", selectedKnownSkill.UserSkillId);
                    int activeDup = Convert.ToInt32(dupCmd.ExecuteScalar());
                    if (activeDup > 0)
                    {
                        ValidationHelper.SetError(_errorProvider, cmbKnownSkills, "You already have an Active listing for this skill.");
                        cmbKnownSkills.Focus();
                        return;
                    }
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = @"INSERT INTO tbl_skills 
                    (UserId, UserSkillId, SkillTitle, Category, Description, OfferedBy, DesiredSkill, DeliveryMode, Location, Status) 
                    VALUES 
                    (@uid, @userSkillId, @title, @category, @desc, @offeredBy, @desired, @mode, @loc, 'Active')";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.Parameters.AddWithValue("@userSkillId", selectedKnownSkill.UserSkillId);
                cmd.Parameters.AddWithValue("@title", selectedKnownSkill.SkillName);
                cmd.Parameters.AddWithValue("@category", selectedKnownSkill.Category);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@offeredBy", offeredBy);
                cmd.Parameters.AddWithValue("@desired", desiredSkill);
                cmd.Parameters.AddWithValue("@mode", deliveryMode);
                cmd.Parameters.AddWithValue("@loc", location);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();

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
            finally
            {
                if (!IsDisposed) btnPublishListing.Enabled = UserSession.IsVerified;
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
            var idVal = row.Cells["SkillId"]?.Value;
            if (idVal == null || !int.TryParse(idVal.ToString(), out int skillId))
            {
                MessageBox.Show("Invalid listing selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = row.Cells["Status"]?.Value?.ToString() ?? "Active";
            string newStatus = string.Equals(currentStatus, "Active", StringComparison.OrdinalIgnoreCase) ? "Paused" : "Active";

            btnPublishListing.Enabled = false;
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "UPDATE tbl_skills SET Status = @status WHERE SkillId = @id";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", skillId);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

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
            var idVal = row.Cells["SkillId"]?.Value;
            if (idVal == null || !int.TryParse(idVal.ToString(), out int skillId))
            {
                MessageBox.Show("Invalid listing selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string skillTitle = row.Cells["Offered Skill"]?.Value?.ToString() ?? "this listing";

            if (MessageBox.Show($"Are you sure you want to delete '{skillTitle}' from the marketplace?\n\n(This will not delete the skill from your profile bio).", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            btnPublishListing.Enabled = false;
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "DELETE FROM tbl_skills WHERE SkillId = @id";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@id", skillId);
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

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
            LayoutCreateOfferControls();

            if (!UserSession.IsVerified)
            {
                btnPublishListing.Enabled = false;
                btnPublishListing.BackColor = Color.FromArgb(45, 52, 47);
                btnPublishListing.ForeColor = Color.FromArgb(160, 165, 160);
                btnPublishListing.Text = "🔒 Pending Verification";
                var tt = new ToolTip();
                tt.SetToolTip(btnPublishListing, "Account pending Admin verification. Publishing listings is disabled until approved.");
            }
        }
    }
}
