namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class StudentMainForm : Form
    {
        public static string CurrentStudentName { get; set; } = "Juan Dela Cruz";

        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            // Reflect current student name in header and dashboard button
            lblWelcome.Text = $"Welcome, {CurrentStudentName}";
            btn_UserDashboard.Text = $"👤 {CurrentStudentName} (Dashboard)";

            btn_SkillExchange.PerformClick();
        }

        // ==========================================
        // NAVIGATION SHORTCUTS
        // ==========================================

        public void NavigateToSkillExchange() => btn_SkillExchange.PerformClick();
        public void NavigateToPostSkill() => btn_PostSkill.PerformClick();
        public void NavigateToManageSkills() => btn_ManageSkills.PerformClick();
        public void NavigateToTradeRequests() => btn_TradeRequests.PerformClick();
        public void NavigateToUserDashboard() => btn_UserDashboard.PerformClick();

        // ==========================================
        // SIDEBAR BUTTON CLICK EVENTS (TRANSITIONS)
        // ==========================================

        private void btn_SkillExchange_Click(object sender, EventArgs e)
        {
            uc_SkillExchange frm = new uc_SkillExchange();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_SkillExchange);
            lblHeaderTitle.Text = "Skill Exchange";
        }

        private void btn_PostSkill_Click(object sender, EventArgs e)
        {
            uc_PostSkill frm = new uc_PostSkill();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_PostSkill);
            lblHeaderTitle.Text = "Post New Skill";
        }

        private void btn_ManageSkills_Click(object sender, EventArgs e)
        {
            uc_ManageSkills frm = new uc_ManageSkills();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_ManageSkills);
            lblHeaderTitle.Text = "My Listings";
        }

        private void btn_TradeRequests_Click(object sender, EventArgs e)
        {
            uc_TradeRequests frm = new uc_TradeRequests();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_TradeRequests);
            lblHeaderTitle.Text = "Trade Requests";
        }

        private void btn_UserDashboard_Click(object sender, EventArgs e)
        {
            uc_UserDashboard frm = new uc_UserDashboard
            {
                CurrentStudentName = CurrentStudentName,
                Dock = DockStyle.Fill
            };
            panelContent.Controls.Clear();
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_UserDashboard);
            lblHeaderTitle.Text = "Student Profile & Dashboard";
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            btn_UserDashboard.PerformClick();
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] navButtons = { btn_SkillExchange, btn_PostSkill, btn_ManageSkills, btn_TradeRequests };
            foreach (var btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(28, 28, 33);
                    btn.ForeColor = Color.FromArgb(16, 185, 129); // Emerald Green
                    pnlNavIndicator.Visible = true;
                    pnlNavIndicator.Location = new Point(0, btn.Top);
                    pnlNavIndicator.Height = btn.Height;
                }
                else
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(161, 161, 170); // Muted gray
                }
            }

            if (btn_UserDashboard != null)
            {
                if (activeButton == btn_UserDashboard)
                {
                    btn_UserDashboard.BackColor = Color.FromArgb(28, 28, 33);
                    btn_UserDashboard.ForeColor = Color.FromArgb(16, 185, 129);
                    pnlNavIndicator.Visible = false;
                }
                else
                {
                    btn_UserDashboard.BackColor = Color.Transparent;
                    btn_UserDashboard.ForeColor = Color.FromArgb(161, 161, 170);
                }
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserSession.Clear();
                this.Close();
            }
        }
    }
}
