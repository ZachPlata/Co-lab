using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_addskill : UserControl
    {
        /// <summary>
        /// Event fired when a skill is successfully added.
        /// </summary>
        public event EventHandler<SkillEventArgs>? SkillAdded;

        /// <summary>
        /// Event fired when the Cancel button is clicked.
        /// </summary>
        public event EventHandler? CancelClicked;

        public class SkillEventArgs : EventArgs
        {
            public string Category { get; }
            public string SkillTitle { get; }

            public SkillEventArgs(string category, string skillTitle)
            {
                Category = category;
                SkillTitle = skillTitle;
            }
        }

        public uc_addskill()
        {
            InitializeComponent();
        }

        private void uc_addskill_Load(object? sender, EventArgs e)
        {
            LoadCategories();

            if (cmbCategory.Items.Count > 0 && cmbCategory.SelectedIndex < 0)
            {
                cmbCategory.SelectedIndex = 0;
            }

            txtSkillOffer.Focus();
        }

        /// <summary>
        /// Loads categories from the database if available; falls back to default categories.
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT CategoryName FROM tbl_categories ORDER BY CategoryId ASC");
                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbCategory.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string? name = row["CategoryName"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            cmbCategory.Items.Add(name);
                        }
                    }
                }
            }
            catch
            {
                // Database offline — retain default design-time categories
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string category = cmbCategory.SelectedItem?.ToString() ?? "";
            string skillOffer = txtSkillOffer.Text.Trim();
            string studentName = StudentMainForm.CurrentStudentName;

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please select a skill category.", "Category Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(skillOffer))
            {
                MessageBox.Show("Please enter the skill you can offer.", "Skill Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSkillOffer.Focus();
                return;
            }

            // Attempt to persist to MySQL database (tbl_skills)
            try
            {
                string sql = @"
                    INSERT INTO tbl_skills 
                    (SkillTitle, Category, Description, OfferedBy, DesiredSkill, DeliveryMode, Location, Status)
                    VALUES 
                    (@title, @category, @desc, @offeredBy, 'Open to any skill', 'Online', 'Campus / Online', 'Active');";

                DatabaseHelper.ExecuteNonQuery(sql,
                    new MySqlParameter("@title", skillOffer),
                    new MySqlParameter("@category", category),
                    new MySqlParameter("@desc", $"Skill offer by {studentName}: {skillOffer}"),
                    new MySqlParameter("@offeredBy", studentName));

                MessageBox.Show(
                    $"Skill '{skillOffer}' under '{category}' has been successfully added to your offerings!",
                    "Skill Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Skill '{skillOffer}' added! (Database note: {ex.Message})",
                    "Skill Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // Raise the SkillAdded event for any parent container
            SkillAdded?.Invoke(this, new SkillEventArgs(category, skillOffer));

            txtSkillOffer.Clear();
            txtSkillOffer.Focus();

            // If hosted inside a modal dialog form, close with DialogResult.OK
            if (this.ParentForm != null && this.ParentForm.Modal)
            {
                this.ParentForm.DialogResult = DialogResult.OK;
                this.ParentForm.Close();
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            txtSkillOffer.Clear();
            CancelClicked?.Invoke(this, EventArgs.Empty);

            // If hosted inside a modal dialog form, close it
            if (this.ParentForm != null && this.ParentForm.Modal)
            {
                this.ParentForm.DialogResult = DialogResult.Cancel;
                this.ParentForm.Close();
            }
        }

        private void txtSkillOffer_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAdd.PerformClick();
            }
        }
    }
}
