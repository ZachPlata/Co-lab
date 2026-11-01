using System;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            // Default to Skill Categories matching the reference template
            btn_SkillCategories.PerformClick();
        }

        // ==========================================
        // SIDEBAR BUTTON CLICK EVENTS (TRANSITIONS)
        // ==========================================

        private void btn_AdminDashboard_Click(object sender, EventArgs e)
        {
            uc_AdminDashboard frm = new uc_AdminDashboard();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_AdminDashboard);
        }

        private void btn_SkillCategories_Click(object sender, EventArgs e)
        {
            uc_SkillCategories frm = new uc_SkillCategories();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_SkillCategories);
        }

        private void btn_ModerateListings_Click(object sender, EventArgs e)
        {
            uc_ModerateListings frm = new uc_ModerateListings();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_ModerateListings);
        }

        private void btn_ReportedStudents_Click(object sender, EventArgs e)
        {
            uc_ReportedStudents frm = new uc_ReportedStudents();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_ReportedStudents);
        }

        private void btn_UpdateTOS_Click(object sender, EventArgs e)
        {
            uc_UpdateTOS frm = new uc_UpdateTOS();
            panelContent.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(frm);
            frm.Show();
            SetActiveButton(btn_UpdateTOS);
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] navButtons = { btn_AdminDashboard, btn_ModerateListings, btn_ReportedStudents, btn_SkillCategories, btn_UpdateTOS };
            foreach (var btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = Color.FromArgb(18, 38, 26);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
                    btn.FlatAppearance.BorderSize = 1;

                    pnlNavIndicator.Location = new Point(btn.Left, btn.Top + 6);
                    pnlNavIndicator.Height = btn.Height - 12;
                    pnlNavIndicator.Visible = true;
                    pnlNavIndicator.BringToFront();
                }
                else
                {
                    btn.BackColor = Color.FromArgb(161, 161, 170); // Use existing color instead
                    btn.ForeColor = Color.FromArgb(161, 161, 170);
                    btn.FlatAppearance.BorderColor = Color.Transparent;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void btn_SignOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to sign out of the Admin panel?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
