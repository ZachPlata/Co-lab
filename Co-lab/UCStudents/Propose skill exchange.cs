using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class Propose_skill_exchange : UserControl
    {
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int TargetSkillId { get; set; }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string TargetSkillTitle { get; set; } = string.Empty;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string TargetOwnerName { get; set; } = string.Empty;

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string TargetDesiredSkill { get; set; } = string.Empty;

        public Propose_skill_exchange()
        {
            InitializeComponent();
            btnCancel.Click += btnCancel_Click;
        }

        public void InitializeTrade(int skillId, string skillTitle, string owner, string mode)
        {
            TargetSkillId = skillId;
            TargetSkillTitle = skillTitle;
            TargetOwnerName = owner;

            lblTheyOffer.Text = $"They Offer: {skillTitle}";
            lblUserName.Text = owner;

            // Fetch details from tbl_skills (desired skill, college/dept if available)
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    @"SELECT s.DesiredSkill, s.Location, s.DeliveryMode, u.College 
                      FROM tbl_skills s 
                      LEFT JOIN tbl_users u ON s.UserId = u.UserId 
                      WHERE s.SkillId = @id LIMIT 1",
                    new MySqlParameter("@id", skillId));

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    TargetDesiredSkill = r["DesiredSkill"]?.ToString() ?? "Open to barter";
                    lblTheyNeed.Text = $"They Need: {TargetDesiredSkill}";

                    string college = r["College"]?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(college))
                    {
                        lblUserDept.Text = college;
                    }

                    string defaultMode = r["DeliveryMode"]?.ToString() ?? mode;
                    if (string.Equals(defaultMode, "Face-to-Face", StringComparison.OrdinalIgnoreCase))
                    {
                        rbFaceToFace.Checked = true;
                    }
                    else
                    {
                        rbOnline.Checked = true;
                    }

                    txtLocation.Text = r["Location"]?.ToString() ?? "";
                }
                else
                {
                    lblTheyNeed.Text = "They Need: Open to any skill";
                }
            }
            catch
            {
                lblTheyNeed.Text = "They Need: Open to any skill";
            }

            // Populate cmbReturnSkill from current student's known skills in tbl_user_skills
            LoadCurrentUserKnownSkills();
        }

        private void LoadCurrentUserKnownSkills()
        {
            cmbReturnSkill.Items.Clear();

            try
            {
                int uid = UserSession.UserId;
                DataTable dt;

                if (uid > 0)
                {
                    dt = DatabaseHelper.ExecuteQuery(
                        "SELECT SkillName, Category FROM tbl_user_skills WHERE UserId = @uid ORDER BY SkillName ASC",
                        new MySqlParameter("@uid", uid));
                }
                else
                {
                    dt = DatabaseHelper.ExecuteQuery(
                        @"SELECT s.SkillName, s.Category 
                          FROM tbl_user_skills s 
                          INNER JOIN tbl_users u ON s.UserId = u.UserId 
                          WHERE u.FullName = @name ORDER BY s.SkillName ASC",
                        new MySqlParameter("@name", UserSession.FullName));
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string sName = row["SkillName"]?.ToString() ?? "";
                        string cat = row["Category"]?.ToString() ?? "";
                        cmbReturnSkill.Items.Add($"{sName} ({cat})");
                    }
                    cmbReturnSkill.SelectedIndex = 0;
                }
                else
                {
                    cmbReturnSkill.Items.Add("-- No known skills yet (Add in Dashboard) --");
                    cmbReturnSkill.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading user known skills: {ex.Message}");
            }
        }

        private void pnlProfileCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(42, 68, 52), 1.5f);
            using var path = CreateRoundedRectanglePath(new Rectangle(1, 1, pnlProfileCard.Width - 3, pnlProfileCard.Height - 3), 8);
            e.Graphics.DrawPath(pen, path);
        }

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Circular dark background
            using var bgBrush = new SolidBrush(Color.FromArgb(22, 40, 30));
            e.Graphics.FillEllipse(bgBrush, 1, 1, 36, 36);

            using var borderPen = new Pen(Color.FromArgb(50, 78, 62), 1.5f);
            e.Graphics.DrawEllipse(borderPen, 1, 1, 36, 36);

            // White silhouette person icon
            using var whiteBrush = new SolidBrush(Color.White);
            // Head
            e.Graphics.FillEllipse(whiteBrush, 14, 8, 11, 11);
            // Shoulders
            using var path = new GraphicsPath();
            path.AddArc(7, 21, 24, 22, 180, 180);
            path.CloseFigure();
            e.Graphics.FillPath(whiteBrush, path);
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

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            string chosenSkill = cmbReturnSkill.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(chosenSkill) || chosenSkill.StartsWith("--"))
            {
                MessageBox.Show(
                    "You need to select one of your known skills to offer in return.\n\n" +
                    "If you have not added skills yet, please go to your Student Dashboard to add skills to your profile first.",
                    "No Skill Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string meetingMode = rbFaceToFace.Checked ? "Face-to-Face" : "Online";
            string location = txtLocation.Text.Trim();
            if (string.IsNullOrWhiteSpace(location))
            {
                location = meetingMode == "Online" ? "Discord / Google Meet" : "Campus Library";
            }

            string notes = txtNotes.Text.Trim();
            string senderName = string.IsNullOrWhiteSpace(UserSession.FullName) ? "Zach Plata" : UserSession.FullName;
            string senderEmail = string.IsNullOrWhiteSpace(UserSession.Email) ? "plata.zachbenedict@ue.edu.ph" : UserSession.Email;

            try
            {
                // Guard: Check if duplicate request already exists in Pending or Accepted state
                string dupCheck = @"SELECT Status FROM tbl_traderequests 
                                    WHERE TargetSkillId = @targetId 
                                      AND (SenderEmail = @email OR SenderName = @sender) 
                                      AND Status IN ('Pending', 'Accepted') 
                                    LIMIT 1";
                object? existing = DatabaseHelper.ExecuteScalar(dupCheck,
                    new MySqlParameter("@targetId", TargetSkillId),
                    new MySqlParameter("@email", senderEmail),
                    new MySqlParameter("@sender", senderName));

                if (existing != null && existing != DBNull.Value)
                {
                    MessageBox.Show(
                        $"You already have an ongoing trade proposal for this skill (Status: {existing}).\n\n" +
                        "You cannot submit duplicate proposals for the same skill.",
                        "Request Already Ongoing",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    if (ParentForm is Form parentForm)
                    {
                        parentForm.DialogResult = DialogResult.Cancel;
                        parentForm.Close();
                    }
                    return;
                }

                string sql = @"INSERT INTO tbl_traderequests 
                    (TargetSkillId, SenderName, SenderEmail, OfferedSkillTitle, MeetingMode, Location, Message, Status) 
                    VALUES 
                    (@targetId, @sender, @email, @offer, @mode, @loc, @msg, 'Pending')";

                int rows = DatabaseHelper.ExecuteNonQuery(sql,
                    new MySqlParameter("@targetId", TargetSkillId),
                    new MySqlParameter("@sender", senderName),
                    new MySqlParameter("@email", senderEmail),
                    new MySqlParameter("@offer", chosenSkill),
                    new MySqlParameter("@mode", meetingMode),
                    new MySqlParameter("@loc", location),
                    new MySqlParameter("@msg", notes));

                if (rows > 0)
                {
                    // Trigger notification to the skill listing owner
                    NotificationHelper.NotifyTradeRequest(TargetSkillId, TargetSkillTitle, senderName, senderEmail);

                    MessageBox.Show(
                        $"Your trade proposal has been sent to {TargetOwnerName}!\n\n" +
                        $"You can track the status of this proposal under 'Trade Requests'.",
                        "Proposal Sent",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (ParentForm is Form parentForm)
                    {
                        parentForm.DialogResult = DialogResult.OK;
                        parentForm.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send trade proposal: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            if (ParentForm is Form parentForm)
            {
                parentForm.DialogResult = DialogResult.Cancel;
                parentForm.Close();
            }
        }

        private void cmbReturnSkill_SelectedIndexChanged(object? sender, EventArgs e)
        {

        }
    }
}
