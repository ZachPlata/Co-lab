using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_PostSkill : UserControl
    {
        public uc_PostSkill()
        {
            InitializeComponent();
        }

        private void uc_PostSkill_Load(object? sender, EventArgs e)
        {
            uc_PostSkill_Resize(this, EventArgs.Empty);

            // Reflect the active student name from session
            if (!string.IsNullOrWhiteSpace(StudentMainForm.CurrentStudentName))
            {
                lblUserName.Text = StudentMainForm.CurrentStudentName;
            }

            // Default selections
            if (cmbCategory.Items.Count > 0 && cmbCategory.SelectedIndex < 0)
                cmbCategory.SelectedIndex = 0;

            if (cmbProficiency.Items.Count > 0 && cmbProficiency.SelectedIndex < 0)
                cmbProficiency.SelectedIndex = 0;

            UpdateLocationRequirement();
        }

        private void DeliveryMode_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateLocationRequirement();
        }

        private void UpdateLocationRequirement()
        {
            if (rbFaceToFace.Checked)
            {
                lblLocation.Text = "Campus Meetup Location (Public Campus Area): *";
                lblLocation.ForeColor = Color.FromArgb(250, 204, 21); // Highlight yellow
                txtLocation.PlaceholderText = "e.g., UE Manila Library 3rd Flr, CCSS Study Lounge, Tan Yan Kee Bldg";
            }
            else
            {
                lblLocation.Text = "Campus Meetup Location (Optional for Online):";
                lblLocation.ForeColor = Color.White;
                txtLocation.PlaceholderText = "Leave blank or specify Discord, Google Meet, or Zoom preferences...";
            }
        }

        private void btnPostSkill_Click(object? sender, EventArgs e)
        {
            // 1. Validation
            string skillTitle = txtSkillTitle.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString() ?? "";
            string proficiency = cmbProficiency.SelectedItem?.ToString() ?? "";
            string description = txtDescription.Text.Trim();
            string desiredSkill = txtDesiredSkill.Text.Trim();
            string deliveryMode = rbFaceToFace.Checked ? "Face-to-Face" : "Online";
            string location = txtLocation.Text.Trim();
            string availability = txtAvailability.Text.Trim();
            string offeredBy = StudentMainForm.CurrentStudentName;

            if (string.IsNullOrWhiteSpace(skillTitle))
            {
                MessageBox.Show("Please enter a Skill Title / Topic.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSkillTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please select a Skill Category.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please provide a detailed description of what you will teach.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(desiredSkill))
            {
                MessageBox.Show("Please specify what skill or topic you want in return (Strictly Cash-Free).", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesiredSkill.Focus();
                return;
            }

            if (rbFaceToFace.Checked && string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("For Face-to-Face exchanges, please specify a safe public campus meetup spot (e.g., UE Library).",
                    "Meetup Location Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            // Append extra metadata (proficiency, availability) into the description for peer visibility
            string fullDescription = description;
            if (!string.IsNullOrWhiteSpace(proficiency) || !string.IsNullOrWhiteSpace(availability))
            {
                fullDescription += "\r\n\r\n--- Exchange Details ---";
                if (!string.IsNullOrWhiteSpace(proficiency))
                    fullDescription += $"\r\nProficiency: {proficiency}";
                if (!string.IsNullOrWhiteSpace(availability))
                    fullDescription += $"\r\nAvailability: {availability}";
            }

            // 2. Insert into MySQL Database (tbl_skills)
            try
            {
                string sql = @"
                    INSERT INTO tbl_skills 
                    (SkillTitle, Category, Description, OfferedBy, DesiredSkill, DeliveryMode, Location, Status)
                    VALUES 
                    (@title, @category, @desc, @offeredBy, @desired, @mode, @location, 'Active');";

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(sql,
                    new MySqlParameter("@title", skillTitle),
                    new MySqlParameter("@category", category),
                    new MySqlParameter("@desc", fullDescription),
                    new MySqlParameter("@offeredBy", offeredBy),
                    new MySqlParameter("@desired", desiredSkill),
                    new MySqlParameter("@mode", deliveryMode),
                    new MySqlParameter("@location", string.IsNullOrWhiteSpace(location) ? "Online Session" : location));

                if (rowsAffected > 0)
                {
                    MessageBox.Show(
                        $"🎉 Success!\n\nYour skill '{skillTitle}' has been posted to the Co-Lab Skill Exchange catalog.\nFellow students can now view your listing and propose trades!",
                        "Skill Listing Published",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearForm();
                }
                else
                {
                    MessageBox.Show("The skill could not be saved to the database. Please try again.",
                        "Save Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // In case database is offline, provide a clear friendly notice
                MessageBox.Show(
                    $"Skill listing validated successfully!\n\nDatabase offline note: Could not connect to MySQL to persist permanently.\nError: {ex.Message}\n\nPlease ensure your local XAMPP MySQL service is running.",
                    "Skill Ready (Database Offline)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Clear all entered fields?", "Confirm Clear",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtSkillTitle.Clear();
            txtDescription.Clear();
            txtDesiredSkill.Clear();
            txtLocation.Clear();
            txtAvailability.Clear();
            rbOnline.Checked = true;

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;

            if (cmbProficiency.Items.Count > 0)
                cmbProficiency.SelectedIndex = 0;

            txtSkillTitle.Focus();
        }

        // ==========================================
        // RESPONSIVE LAYOUT (MINIMIZED & MAXIMIZED MODES)
        // ==========================================
        private void uc_PostSkill_Resize(object? sender, EventArgs e)
        {
            int padding = 25;
            int availWidth = Math.Max(960, ClientSize.Width - (padding * 2) - (VScroll ? SystemInformation.VerticalScrollBarWidth : 0));

            pnlHeaderCard.Location = new Point(padding, 20);
            pnlHeaderCard.Width = availWidth;

            pnlPolicyNotice.Location = new Point(padding, 120);
            pnlPolicyNotice.Width = availWidth;

            int gap = 20;
            int colWidth = (availWidth - gap) / 2;

            pnlOfferDetails.Location = new Point(padding, 175);
            pnlOfferDetails.Width = colWidth;

            int innerWidth1 = Math.Max(300, colWidth - 40);
            txtSkillTitle.Width = innerWidth1;
            cmbCategory.Width = innerWidth1;
            cmbProficiency.Width = innerWidth1;
            txtDescription.Width = innerWidth1;

            pnlExchangeDetails.Location = new Point(pnlOfferDetails.Right + gap, 175);
            pnlExchangeDetails.Width = availWidth - colWidth - gap;

            int innerWidth2 = Math.Max(300, pnlExchangeDetails.Width - 40);
            txtDesiredSkill.Width = innerWidth2;
            pnlDeliveryMode.Width = innerWidth2;
            txtLocation.Width = innerWidth2;
            txtAvailability.Width = innerWidth2;
            pnlTip.Width = innerWidth2;

            pnlActionBar.Location = new Point(padding, 680);
            pnlActionBar.Width = availWidth;
            btnPostSkill.Left = pnlActionBar.Width - 20 - btnPostSkill.Width;
            btnClear.Left = btnPostSkill.Left - 15 - btnClear.Width;

            Invalidate(true);
        }

        private void RoundPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Control ctrl) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(1, 1, ctrl.Width - 3, ctrl.Height - 3);
            using var path = CreateRoundedRectanglePath(rect, 8);
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
