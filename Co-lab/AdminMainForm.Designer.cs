namespace Co_LAB
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlNavContainer = new Panel();
            pnlNavIndicator = new Panel();
            btn_ReportedStudents = new Button();
            btn_ModerateListings = new Button();
            btn_SkillCategories = new Button();
            btn_AdminDashboard = new Button();
            pnlSidebarBottom = new Panel();
            btn_SignOut = new Button();
            pnlDividerBottom = new Panel();
            pnlBrand = new Panel();
            pnlDividerTop = new Panel();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            pnlHeader = new Panel();
            pnlDividerHeader = new Panel();
            lblAdminProfile = new Label();
            lblHeaderTitle = new Label();
            panelContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlNavContainer.SuspendLayout();
            pnlSidebarBottom.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(12, 17, 14);
            pnlSidebar.Controls.Add(pnlNavContainer);
            pnlSidebar.Controls.Add(pnlSidebarBottom);
            pnlSidebar.Controls.Add(pnlBrand);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(3, 4, 3, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(286, 960);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlNavContainer
            // 
            pnlNavContainer.Controls.Add(pnlNavIndicator);
            pnlNavContainer.Controls.Add(btn_ReportedStudents);
            pnlNavContainer.Controls.Add(btn_ModerateListings);
            pnlNavContainer.Controls.Add(btn_SkillCategories);
            pnlNavContainer.Controls.Add(btn_AdminDashboard);
            pnlNavContainer.Dock = DockStyle.Fill;
            pnlNavContainer.Location = new Point(0, 113);
            pnlNavContainer.Margin = new Padding(3, 4, 3, 4);
            pnlNavContainer.Name = "pnlNavContainer";
            pnlNavContainer.Padding = new Padding(0, 13, 0, 0);
            pnlNavContainer.Size = new Size(286, 757);
            pnlNavContainer.TabIndex = 1;
            // 
            // pnlNavIndicator
            // 
            pnlNavIndicator.BackColor = Color.FromArgb(16, 185, 129);
            pnlNavIndicator.Location = new Point(0, 13);
            pnlNavIndicator.Margin = new Padding(3, 4, 3, 4);
            pnlNavIndicator.Name = "pnlNavIndicator";
            pnlNavIndicator.Size = new Size(5, 67);
            pnlNavIndicator.TabIndex = 5;
            // 
            // btn_ReportedStudents
            // 
            btn_ReportedStudents.Cursor = Cursors.Hand;
            btn_ReportedStudents.Dock = DockStyle.Top;
            btn_ReportedStudents.FlatAppearance.BorderSize = 0;
            btn_ReportedStudents.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_ReportedStudents.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_ReportedStudents.FlatStyle = FlatStyle.Flat;
            btn_ReportedStudents.Font = new Font("Segoe UI", 10F);
            btn_ReportedStudents.ForeColor = Color.FromArgb(161, 161, 170);
            btn_ReportedStudents.Location = new Point(0, 214);
            btn_ReportedStudents.Margin = new Padding(3, 4, 3, 4);
            btn_ReportedStudents.Name = "btn_ReportedStudents";
            btn_ReportedStudents.Padding = new Padding(25, 0, 11, 0);
            btn_ReportedStudents.Size = new Size(286, 67);
            btn_ReportedStudents.TabIndex = 3;
            btn_ReportedStudents.Text = "Reports & Blacklist";
            btn_ReportedStudents.TextAlign = ContentAlignment.MiddleLeft;
            btn_ReportedStudents.UseVisualStyleBackColor = true;
            btn_ReportedStudents.Click += btn_ReportedStudents_Click;
            // 
            // btn_ModerateListings
            // 
            btn_ModerateListings.Cursor = Cursors.Hand;
            btn_ModerateListings.Dock = DockStyle.Top;
            btn_ModerateListings.FlatAppearance.BorderSize = 0;
            btn_ModerateListings.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_ModerateListings.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_ModerateListings.FlatStyle = FlatStyle.Flat;
            btn_ModerateListings.Font = new Font("Segoe UI", 10F);
            btn_ModerateListings.ForeColor = Color.FromArgb(161, 161, 170);
            btn_ModerateListings.Location = new Point(0, 147);
            btn_ModerateListings.Margin = new Padding(3, 4, 3, 4);
            btn_ModerateListings.Name = "btn_ModerateListings";
            btn_ModerateListings.Padding = new Padding(25, 0, 11, 0);
            btn_ModerateListings.Size = new Size(286, 67);
            btn_ModerateListings.TabIndex = 2;
            btn_ModerateListings.Text = "Moderate Listings";
            btn_ModerateListings.TextAlign = ContentAlignment.MiddleLeft;
            btn_ModerateListings.UseVisualStyleBackColor = true;
            btn_ModerateListings.Click += btn_ModerateListings_Click;
            // 
            // btn_SkillCategories
            // 
            btn_SkillCategories.Cursor = Cursors.Hand;
            btn_SkillCategories.Dock = DockStyle.Top;
            btn_SkillCategories.FlatAppearance.BorderSize = 0;
            btn_SkillCategories.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_SkillCategories.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_SkillCategories.FlatStyle = FlatStyle.Flat;
            btn_SkillCategories.Font = new Font("Segoe UI", 10F);
            btn_SkillCategories.ForeColor = Color.FromArgb(161, 161, 170);
            btn_SkillCategories.Location = new Point(0, 80);
            btn_SkillCategories.Margin = new Padding(3, 4, 3, 4);
            btn_SkillCategories.Name = "btn_SkillCategories";
            btn_SkillCategories.Padding = new Padding(25, 0, 11, 0);
            btn_SkillCategories.Size = new Size(286, 67);
            btn_SkillCategories.TabIndex = 1;
            btn_SkillCategories.Text = "Skill Categories";
            btn_SkillCategories.TextAlign = ContentAlignment.MiddleLeft;
            btn_SkillCategories.UseVisualStyleBackColor = true;
            btn_SkillCategories.Click += btn_SkillCategories_Click;
            // 
            // btn_AdminDashboard
            // 
            btn_AdminDashboard.Cursor = Cursors.Hand;
            btn_AdminDashboard.Dock = DockStyle.Top;
            btn_AdminDashboard.FlatAppearance.BorderSize = 0;
            btn_AdminDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_AdminDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_AdminDashboard.FlatStyle = FlatStyle.Flat;
            btn_AdminDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_AdminDashboard.ForeColor = Color.FromArgb(16, 185, 129);
            btn_AdminDashboard.Location = new Point(0, 13);
            btn_AdminDashboard.Margin = new Padding(3, 4, 3, 4);
            btn_AdminDashboard.Name = "btn_AdminDashboard";
            btn_AdminDashboard.Padding = new Padding(25, 0, 11, 0);
            btn_AdminDashboard.Size = new Size(286, 67);
            btn_AdminDashboard.TabIndex = 0;
            btn_AdminDashboard.Text = "Admin Dashboard";
            btn_AdminDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btn_AdminDashboard.UseVisualStyleBackColor = true;
            btn_AdminDashboard.Click += btn_AdminDashboard_Click;
            // 
            // pnlSidebarBottom
            // 
            pnlSidebarBottom.Controls.Add(btn_SignOut);
            pnlSidebarBottom.Controls.Add(pnlDividerBottom);
            pnlSidebarBottom.Dock = DockStyle.Bottom;
            pnlSidebarBottom.Location = new Point(0, 870);
            pnlSidebarBottom.Margin = new Padding(3, 4, 3, 4);
            pnlSidebarBottom.Name = "pnlSidebarBottom";
            pnlSidebarBottom.Size = new Size(286, 90);
            pnlSidebarBottom.TabIndex = 2;
            // 
            // btn_SignOut
            // 
            btn_SignOut.Cursor = Cursors.Hand;
            btn_SignOut.Dock = DockStyle.Bottom;
            btn_SignOut.FlatAppearance.BorderSize = 0;
            btn_SignOut.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, 25, 25);
            btn_SignOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 20, 20);
            btn_SignOut.FlatStyle = FlatStyle.Flat;
            btn_SignOut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btn_SignOut.ForeColor = Color.FromArgb(239, 68, 68);
            btn_SignOut.Location = new Point(0, 23);
            btn_SignOut.Margin = new Padding(3, 4, 3, 4);
            btn_SignOut.Name = "btn_SignOut";
            btn_SignOut.Padding = new Padding(25, 0, 0, 0);
            btn_SignOut.Size = new Size(286, 67);
            btn_SignOut.TabIndex = 0;
            btn_SignOut.Text = "Sign Out";
            btn_SignOut.TextAlign = ContentAlignment.MiddleLeft;
            btn_SignOut.UseVisualStyleBackColor = true;
            btn_SignOut.Click += btn_SignOut_Click;
            // 
            // pnlDividerBottom
            // 
            pnlDividerBottom.BackColor = Color.FromArgb(30, 44, 34);
            pnlDividerBottom.Dock = DockStyle.Top;
            pnlDividerBottom.Location = new Point(0, 0);
            pnlDividerBottom.Margin = new Padding(3, 4, 3, 4);
            pnlDividerBottom.Name = "pnlDividerBottom";
            pnlDividerBottom.Size = new Size(286, 1);
            pnlDividerBottom.TabIndex = 0;
            // 
            // pnlBrand
            // 
            pnlBrand.Controls.Add(pnlDividerTop);
            pnlBrand.Controls.Add(lblBrandSubtitle);
            pnlBrand.Controls.Add(lblBrandTitle);
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Margin = new Padding(3, 4, 3, 4);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(286, 113);
            pnlBrand.TabIndex = 0;
            // 
            // pnlDividerTop
            // 
            pnlDividerTop.BackColor = Color.FromArgb(30, 44, 34);
            pnlDividerTop.Dock = DockStyle.Bottom;
            pnlDividerTop.Location = new Point(0, 112);
            pnlDividerTop.Margin = new Padding(3, 4, 3, 4);
            pnlDividerTop.Name = "pnlDividerTop";
            pnlDividerTop.Size = new Size(286, 1);
            pnlDividerTop.TabIndex = 2;
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.AutoSize = true;
            lblBrandSubtitle.Font = new Font("Segoe UI", 8.25F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblBrandSubtitle.Location = new Point(25, 64);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(166, 19);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Administration Portal";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblBrandTitle.Location = new Point(23, 24);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(116, 37);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "CO-LAB";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(18, 25, 20);
            pnlHeader.Controls.Add(pnlDividerHeader);
            pnlHeader.Controls.Add(lblAdminProfile);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(286, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1085, 113);
            pnlHeader.TabIndex = 1;
            // 
            // pnlDividerHeader
            // 
            pnlDividerHeader.BackColor = Color.FromArgb(30, 44, 34);
            pnlDividerHeader.Dock = DockStyle.Bottom;
            pnlDividerHeader.Location = new Point(0, 112);
            pnlDividerHeader.Margin = new Padding(3, 4, 3, 4);
            pnlDividerHeader.Name = "pnlDividerHeader";
            pnlDividerHeader.Size = new Size(1085, 1);
            pnlDividerHeader.TabIndex = 2;
            // 
            // lblAdminProfile
            // 
            lblAdminProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdminProfile.AutoSize = true;
            lblAdminProfile.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblAdminProfile.ForeColor = Color.FromArgb(74, 222, 128);
            lblAdminProfile.Location = new Point(890, 43);
            lblAdminProfile.Name = "lblAdminProfile";
            lblAdminProfile.Size = new Size(160, 23);
            lblAdminProfile.TabIndex = 1;
            lblAdminProfile.Text = "🛡️ Administrator";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(34, 32);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(244, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Admin Dashboard";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(14, 20, 16);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(286, 113);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1085, 847);
            panelContent.TabIndex = 2;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            ClientSize = new Size(1371, 960);
            Controls.Add(panelContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 784);
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CO-LAB - Admin Management Portal";
            Load += AdminMainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlNavContainer.ResumeLayout(false);
            pnlSidebarBottom.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlBrand;
        private Label lblBrandTitle;
        private Label lblBrandSubtitle;
        private Panel pnlDividerTop;
        private Panel pnlNavContainer;
        private Button btn_AdminDashboard;
        private Button btn_SkillCategories;
        private Button btn_ModerateListings;
        private Button btn_ReportedStudents;
        private Panel pnlNavIndicator;
        private Panel pnlSidebarBottom;
        private Panel pnlDividerBottom;
        private Button btn_SignOut;
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblAdminProfile;
        private Panel pnlDividerHeader;
        private Panel panelContent;
    }
}

