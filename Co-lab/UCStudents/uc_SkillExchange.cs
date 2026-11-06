using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_SkillExchange : UserControl
    {
        public uc_SkillExchange()
        {
            InitializeComponent();
        }

        private void uc_SkillExchange_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadMarketplaceCards("", "All Categories");
        }

        /// <summary>
        /// Loads skill categories from the database or falls back to common defaults.
        /// </summary>
        public void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT CategoryName FROM tbl_categories ORDER BY CategoryName ASC");
                foreach (DataRow row in dt.Rows)
                {
                    string? name = row["CategoryName"]?.ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        cmbCategory.Items.Add(name);
                    }
                }
            }
            catch
            {
                // Fallback default categories if tbl_categories is not yet created in phpMyAdmin
                cmbCategory.Items.AddRange(new object[] {
                    "Computer Science & IT",
                    "Graphic & Visual Design",
                    "Engineering & Math",
                    "Music & Arts",
                    "Language & Writing",
                    "Business & Marketing"
                });
            }

            cmbCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Queries the database and dynamically generates cards inside the FlowLayoutPanel.
        /// </summary>
        public void LoadMarketplaceCards(string keyword, string category)
        {
            flpMarketplace.SuspendLayout();
            flpMarketplace.Controls.Clear();

            try
            {
                string query = "SELECT * FROM tbl_skills WHERE (Status = 'Active' OR Status IS NULL)";
                var parameters = new System.Collections.Generic.List<MySqlParameter>();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    query += " AND (SkillTitle LIKE @kw OR Description LIKE @kw OR OfferedBy LIKE @kw)";
                    parameters.Add(new MySqlParameter("@kw", "%" + keyword.Trim() + "%"));
                }

                if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
                {
                    query += " AND Category = @cat";
                    parameters.Add(new MySqlParameter("@cat", category));
                }

                query += " ORDER BY SkillId DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters.ToArray());

                if (dt.Rows.Count == 0)
                {
                    ShowEmptyState("No skill listings found matching your search.");
                    lblListingCount.Text = "0 skills available";
                }
                else
                {
                    lblListingCount.Text = $"{dt.Rows.Count} skill(s) available";
                    foreach (DataRow row in dt.Rows)
                    {
                        var card = new UCStudents.uc_SkillCard();
                        card.BindData(row);
                        card.RequestTradeClicked += (s, args) =>
                        {
                            OnRequestTradeClicked(args.SkillId, args.SkillTitle, args.OfferedBy, args.DeliveryMode);
                        };
                        card.ReportClicked += (s, args) =>
                        {
                            OnReportClicked(args.SkillId, args.SkillTitle, args.OfferedBy);
                        };
                        flpMarketplace.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowEmptyState($"Could not connect to database: {ex.Message}\nMake sure MySQL is running in XAMPP.");
                lblListingCount.Text = "Database offline";
            }
            finally
            {
                flpMarketplace.ResumeLayout();
            }
        }

        private void ShowEmptyState(string message)
        {
            Label lblEmpty = new Label
            {
                Text = message,
                ForeColor = Color.FromArgb(161, 161, 170),
                Font = new Font("Segoe UI", 10.5F),
                AutoSize = false,
                Size = new Size(600, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(120, 100, 0, 0)
            };
            flpMarketplace.Controls.Add(lblEmpty);
        }

        private void OnRequestTradeClicked(string skillId, string title, string owner, string mode)
        {
            MessageBox.Show(
                $"Opening trade proposal for:\n\nSkill: {title}\nOffered by: {owner}\nMode: {mode}\n\n(Trowa's FormTradeRequest will open here!)",
                "Trade Request",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void OnReportClicked(string skillId, string title, string owner)
        {
            string reason = Microsoft.VisualBasic.Interaction.InputBox(
                $"Why are you reporting this listing?\n\nListing: {title}\nPosted by: {owner}",
                "Report Listing / Student",
                "Inappropriate content or spam");

            if (!string.IsNullOrWhiteSpace(reason))
            {
                try
                {
                    string insertSql = @"INSERT INTO tbl_reports (SkillId, ReportedUser, Reason, ReportDate, Status) 
                                         VALUES (@sid, @user, @reason, NOW(), 'Pending')";
                    DatabaseHelper.ExecuteNonQuery(insertSql,
                        new MySqlParameter("@sid", skillId),
                        new MySqlParameter("@user", owner),
                        new MySqlParameter("@reason", reason.Trim())
                    );
                    MessageBox.Show("Report submitted successfully. Admin will review this listing.", "Report Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not record report: {ex.Message}", "Database Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbCategory.SelectedIndex = 0;
            LoadMarketplaceCards("", "All Categories");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMarketplaceCards(txtSearch.Text, cmbCategory.SelectedItem?.ToString() ?? "All Categories");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void flpMarketplace_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
