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
            pnlPurpleDivider = new Panel();
            pnlNavArea = new Panel();
            pnlNavContainer = new Panel();
            pnlNavIndicator = new Panel();
            btn_UpdateTOS = new Button();
            btn_SkillCategories = new Button();
            btn_ReportedStudents = new Button();
            btn_ModerateListings = new Button();
            btn_AdminDashboard = new Button();
            pnlSidebarBottom = new Panel();
            btn_SignOut = new Button();
            pnlBrand = new Panel();
            lblBrandSub = new Label();
            lblBrandTitle2 = new Label();
            lblBrandTitle1 = new Label();
            pnlRail = new Panel();
            lblRailHelp = new Label();
            lblRailSettings = new Label();
            lblRailCap = new Label();
            lblRailClock = new Label();
            lblRailChat = new Label();
            lblRailGrid = new Label();
            lblRailSearch = new Label();
            lblRailStar = new Label();
            panelContent = new Panel();

            pnlSidebar.SuspendLayout();
            pnlNavArea.SuspendLayout();
            pnlNavContainer.SuspendLayout();
            pnlSidebarBottom.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlRail.SuspendLayout();
            SuspendLayout();

            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(13, 20, 16);
            pnlSidebar.Controls.Add(pnlPurpleDivider);
            pnlSidebar.Controls.Add(pnlNavArea);
            pnlSidebar.Controls.Add(pnlRail);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(245, 720);
            pnlSidebar.TabIndex = 0;

            // 
            // pnlPurpleDivider (Vertical Purple Line from reference)
            // 
            pnlPurpleDivider.BackColor = Color.FromArgb(124, 58, 237);
            pnlPurpleDivider.Dock = DockStyle.Right;
            pnlPurpleDivider.Location = new Point(243, 0);
            pnlPurpleDivider.Name = "pnlPurpleDivider";
            pnlPurpleDivider.Size = new Size(2, 720);
            pnlPurpleDivider.TabIndex = 2;

            // 
            // pnlRail (Far-left mini icon strip)
            // 
            pnlRail.BackColor = Color.FromArgb(10, 15, 12);
            pnlRail.Controls.Add(lblRailHelp);
            pnlRail.Controls.Add(lblRailSettings);
            pnlRail.Controls.Add(lblRailCap);
            pnlRail.Controls.Add(lblRailClock);
            pnlRail.Controls.Add(lblRailChat);
            pnlRail.Controls.Add(lblRailGrid);
            pnlRail.Controls.Add(lblRailSearch);
            pnlRail.Controls.Add(lblRailStar);
            pnlRail.Dock = DockStyle.Left;
            pnlRail.Location = new Point(0, 0);
            pnlRail.Name = "pnlRail";
            pnlRail.Size = new Size(42, 720);
            pnlRail.TabIndex = 0;

            // 
            // lblRailStar
            // 
            lblRailStar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRailStar.ForeColor = Color.FromArgb(56, 189, 248);
            lblRailStar.Location = new Point(0, 16);
            lblRailStar.Name = "lblRailStar";
            lblRailStar.Size = new Size(42, 28);
            lblRailStar.TabIndex = 0;
            lblRailStar.Text = "✦";
            lblRailStar.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailSearch
            // 
            lblRailSearch.Font = new Font("Segoe UI", 10F);
            lblRailSearch.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailSearch.Location = new Point(0, 105);
            lblRailSearch.Name = "lblRailSearch";
            lblRailSearch.Size = new Size(42, 28);
            lblRailSearch.TabIndex = 1;
            lblRailSearch.Text = "🔍";
            lblRailSearch.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailGrid
            // 
            lblRailGrid.Font = new Font("Segoe UI", 11F);
            lblRailGrid.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailGrid.Location = new Point(0, 145);
            lblRailGrid.Name = "lblRailGrid";
            lblRailGrid.Size = new Size(42, 28);
            lblRailGrid.TabIndex = 2;
            lblRailGrid.Text = "⊞";
            lblRailGrid.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailChat
            // 
            lblRailChat.Font = new Font("Segoe UI", 10F);
            lblRailChat.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailChat.Location = new Point(0, 185);
            lblRailChat.Name = "lblRailChat";
            lblRailChat.Size = new Size(42, 28);
            lblRailChat.TabIndex = 3;
            lblRailChat.Text = "💬";
            lblRailChat.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailClock
            // 
            lblRailClock.Font = new Font("Segoe UI", 10F);
            lblRailClock.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailClock.Location = new Point(0, 225);
            lblRailClock.Name = "lblRailClock";
            lblRailClock.Size = new Size(42, 28);
            lblRailClock.TabIndex = 4;
            lblRailClock.Text = "🕒";
            lblRailClock.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailCap
            // 
            lblRailCap.Font = new Font("Segoe UI", 10F);
            lblRailCap.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailCap.Location = new Point(0, 265);
            lblRailCap.Name = "lblRailCap";
            lblRailCap.Size = new Size(42, 28);
            lblRailCap.TabIndex = 5;
            lblRailCap.Text = "🎓";
            lblRailCap.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailSettings
            // 
            lblRailSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRailSettings.Font = new Font("Segoe UI", 10F);
            lblRailSettings.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailSettings.Location = new Point(0, 640);
            lblRailSettings.Name = "lblRailSettings";
            lblRailSettings.Size = new Size(42, 28);
            lblRailSettings.TabIndex = 6;
            lblRailSettings.Text = "⚙";
            lblRailSettings.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblRailHelp
            // 
            lblRailHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblRailHelp.Font = new Font("Segoe UI", 10F);
            lblRailHelp.ForeColor = Color.FromArgb(120, 140, 125);
            lblRailHelp.Location = new Point(0, 675);
            lblRailHelp.Name = "lblRailHelp";
            lblRailHelp.Size = new Size(42, 28);
            lblRailHelp.TabIndex = 7;
            lblRailHelp.Text = "❓";
            lblRailHelp.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlNavArea (Main Sidebar Area)
            // 
            pnlNavArea.BackColor = Color.FromArgb(13, 20, 16);
            pnlNavArea.Controls.Add(pnlNavContainer);
            pnlNavArea.Controls.Add(pnlSidebarBottom);
            pnlNavArea.Controls.Add(pnlBrand);
            pnlNavArea.Dock = DockStyle.Fill;
            pnlNavArea.Location = new Point(42, 0);
            pnlNavArea.Name = "pnlNavArea";
            pnlNavArea.Size = new Size(203, 720);
            pnlNavArea.TabIndex = 1;

            // 
            // pnlBrand
            // 
            pnlBrand.Controls.Add(lblBrandSub);
            pnlBrand.Controls.Add(lblBrandTitle2);
            pnlBrand.Controls.Add(lblBrandTitle1);
            pnlBrand.Dock = DockStyle.Top;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Padding = new Padding(12, 16, 12, 10);
            pnlBrand.Size = new Size(203, 85);
            pnlBrand.TabIndex = 0;

            // 
            // lblBrandTitle1
            // 
            lblBrandTitle1.AutoSize = true;
            lblBrandTitle1.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblBrandTitle1.ForeColor = Color.FromArgb(212, 143, 56);
            lblBrandTitle1.Location = new Point(10, 14);
            lblBrandTitle1.Name = "lblBrandTitle1";
            lblBrandTitle1.Size = new Size(80, 21);
            lblBrandTitle1.TabIndex = 0;
            lblBrandTitle1.Text = "UE SKILL";

            // 
            // lblBrandTitle2
            // 
            lblBrandTitle2.AutoSize = true;
            lblBrandTitle2.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblBrandTitle2.ForeColor = Color.FromArgb(212, 143, 56);
            lblBrandTitle2.Location = new Point(10, 34);
            lblBrandTitle2.Name = "lblBrandTitle2";
            lblBrandTitle2.Size = new Size(99, 21);
            lblBrandTitle2.TabIndex = 1;
            lblBrandTitle2.Text = "EXCHANGE";

            // 
            // lblBrandSub
            // 
            lblBrandSub.AutoSize = true;
            lblBrandSub.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            lblBrandSub.ForeColor = Color.FromArgb(160, 130, 90);
            lblBrandSub.Location = new Point(12, 57);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(79, 12);
            lblBrandSub.TabIndex = 2;
            lblBrandSub.Text = "ADMIN PORTAL";

            // 
            // pnlNavContainer
            // 
            pnlNavContainer.Controls.Add(pnlNavIndicator);
            pnlNavContainer.Controls.Add(btn_UpdateTOS);
            pnlNavContainer.Controls.Add(btn_SkillCategories);
            pnlNavContainer.Controls.Add(btn_ReportedStudents);
            pnlNavContainer.Controls.Add(btn_ModerateListings);
            pnlNavContainer.Controls.Add(btn_AdminDashboard);
            pnlNavContainer.Dock = DockStyle.Fill;
            pnlNavContainer.Location = new Point(0, 85);
            pnlNavContainer.Name = "pnlNavContainer";
            pnlNavContainer.Padding = new Padding(6, 4, 6, 0);
            pnlNavContainer.Size = new Size(203, 565);
            pnlNavContainer.TabIndex = 1;

            // 
            // pnlNavIndicator
            // 
            pnlNavIndicator.BackColor = Color.FromArgb(16, 185, 129);
            pnlNavIndicator.Location = new Point(6, 168);
            pnlNavIndicator.Name = "pnlNavIndicator";
            pnlNavIndicator.Size = new Size(4, 46);
            pnlNavIndicator.TabIndex = 5;

            // 
            // btn_AdminDashboard
            // 
            btn_AdminDashboard.Cursor = Cursors.Hand;
            btn_AdminDashboard.Dock = DockStyle.Top;
            btn_AdminDashboard.FlatAppearance.BorderSize = 0;
            btn_AdminDashboard.FlatStyle = FlatStyle.Flat;
            btn_AdminDashboard.Font = new Font("Segoe UI Semibold", 8.5F);
            btn_AdminDashboard.ForeColor = Color.FromArgb(161, 161, 170);
            btn_AdminDashboard.Location = new Point(6, 4);
            btn_AdminDashboard.Name = "btn_AdminDashboard";
            btn_AdminDashboard.Padding = new Padding(12, 0, 4, 0);
            btn_AdminDashboard.Size = new Size(191, 52);
            btn_AdminDashboard.TabIndex = 0;
            btn_AdminDashboard.Text = "⊞  Dashboard Overview\r\n    uc_AdminDashboard.cs";
            btn_AdminDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btn_AdminDashboard.UseVisualStyleBackColor = true;
            btn_AdminDashboard.Click += btn_AdminDashboard_Click;

            // 
            // btn_ModerateListings
            // 
            btn_ModerateListings.Cursor = Cursors.Hand;
            btn_ModerateListings.Dock = DockStyle.Top;
            btn_ModerateListings.FlatAppearance.BorderSize = 0;
            btn_ModerateListings.FlatStyle = FlatStyle.Flat;
            btn_ModerateListings.Font = new Font("Segoe UI Semibold", 8.5F);
            btn_ModerateListings.ForeColor = Color.FromArgb(161, 161, 170);
            btn_ModerateListings.Location = new Point(6, 56);
            btn_ModerateListings.Name = "btn_ModerateListings";
            btn_ModerateListings.Padding = new Padding(12, 0, 4, 0);
            btn_ModerateListings.Size = new Size(191, 52);
            btn_ModerateListings.TabIndex = 1;
            btn_ModerateListings.Text = "🛡  Moderate Listings   (3)\r\n    uc_ModerateListings.cs";
            btn_ModerateListings.TextAlign = ContentAlignment.MiddleLeft;
            btn_ModerateListings.UseVisualStyleBackColor = true;
            btn_ModerateListings.Click += btn_ModerateListings_Click;

            // 
            // btn_ReportedStudents
            // 
            btn_ReportedStudents.Cursor = Cursors.Hand;
            btn_ReportedStudents.Dock = DockStyle.Top;
            btn_ReportedStudents.FlatAppearance.BorderSize = 0;
            btn_ReportedStudents.FlatStyle = FlatStyle.Flat;
            btn_ReportedStudents.Font = new Font("Segoe UI Semibold", 8.5F);
            btn_ReportedStudents.ForeColor = Color.FromArgb(161, 161, 170);
            btn_ReportedStudents.Location = new Point(6, 108);
            btn_ReportedStudents.Name = "btn_ReportedStudents";
            btn_ReportedStudents.Padding = new Padding(12, 0, 4, 0);
            btn_ReportedStudents.Size = new Size(191, 52);
            btn_ReportedStudents.TabIndex = 2;
            btn_ReportedStudents.Text = "👥  Reported Students  (2)\r\n    uc_ReportedStudents.cs";
            btn_ReportedStudents.TextAlign = ContentAlignment.MiddleLeft;
            btn_ReportedStudents.UseVisualStyleBackColor = true;
            btn_ReportedStudents.Click += btn_ReportedStudents_Click;

            // 
            // btn_SkillCategories
            // 
            btn_SkillCategories.Cursor = Cursors.Hand;
            btn_SkillCategories.Dock = DockStyle.Top;
            btn_SkillCategories.FlatAppearance.BorderColor = Color.FromArgb(16, 185, 129);
            btn_SkillCategories.FlatAppearance.BorderSize = 1;
            btn_SkillCategories.FlatStyle = FlatStyle.Flat;
            btn_SkillCategories.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btn_SkillCategories.ForeColor = Color.White;
            btn_SkillCategories.BackColor = Color.FromArgb(18, 38, 26);
            btn_SkillCategories.Location = new Point(6, 160);
            btn_SkillCategories.Name = "btn_SkillCategories";
            btn_SkillCategories.Padding = new Padding(12, 0, 4, 0);
            btn_SkillCategories.Size = new Size(191, 52);
            btn_SkillCategories.TabIndex = 3;
            btn_SkillCategories.Text = "🗂  Skill Categories\r\n    uc_SkillCategories.cs";
            btn_SkillCategories.TextAlign = ContentAlignment.MiddleLeft;
            btn_SkillCategories.UseVisualStyleBackColor = false;
            btn_SkillCategories.Click += btn_SkillCategories_Click;

            // 
            // btn_UpdateTOS
            // 
            btn_UpdateTOS.Cursor = Cursors.Hand;
            btn_UpdateTOS.Dock = DockStyle.Top;
            btn_UpdateTOS.FlatAppearance.BorderSize = 0;
            btn_UpdateTOS.FlatStyle = FlatStyle.Flat;
            btn_UpdateTOS.Font = new Font("Segoe UI Semibold", 8.5F);
            btn_UpdateTOS.ForeColor = Color.FromArgb(161, 161, 170);
            btn_UpdateTOS.Location = new Point(6, 212);
            btn_UpdateTOS.Name = "btn_UpdateTOS";
            btn_UpdateTOS.Padding = new Padding(12, 0, 4, 0);
            btn_UpdateTOS.Size = new Size(191, 52);
            btn_UpdateTOS.TabIndex = 4;
            btn_UpdateTOS.Text = "📋  Update TOS\r\n    uc_UpdateTOS.cs";
            btn_UpdateTOS.TextAlign = ContentAlignment.MiddleLeft;
            btn_UpdateTOS.UseVisualStyleBackColor = true;
            btn_UpdateTOS.Click += btn_UpdateTOS_Click;

            // 
            // pnlSidebarBottom
            // 
            pnlSidebarBottom.Controls.Add(btn_SignOut);
            pnlSidebarBottom.Dock = DockStyle.Bottom;
            pnlSidebarBottom.Location = new Point(0, 650);
            pnlSidebarBottom.Name = "pnlSidebarBottom";
            pnlSidebarBottom.Padding = new Padding(8, 0, 8, 14);
            pnlSidebarBottom.Size = new Size(203, 70);
            pnlSidebarBottom.TabIndex = 2;

            // 
            // btn_SignOut
            // 
            btn_SignOut.Cursor = Cursors.Hand;
            btn_SignOut.Dock = DockStyle.Bottom;
            btn_SignOut.FlatAppearance.BorderSize = 0;
            btn_SignOut.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 20, 20);
            btn_SignOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 15, 15);
            btn_SignOut.FlatStyle = FlatStyle.Flat;
            btn_SignOut.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btn_SignOut.ForeColor = Color.FromArgb(239, 83, 80);
            btn_SignOut.Location = new Point(8, 16);
            btn_SignOut.Name = "btn_SignOut";
            btn_SignOut.Padding = new Padding(8, 0, 0, 0);
            btn_SignOut.Size = new Size(187, 40);
            btn_SignOut.TabIndex = 0;
            btn_SignOut.Text = "[→  Sign Out";
            btn_SignOut.TextAlign = ContentAlignment.MiddleLeft;
            btn_SignOut.UseVisualStyleBackColor = true;
            btn_SignOut.Click += btn_SignOut_Click;

            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(14, 20, 16);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(245, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(955, 720);
            panelContent.TabIndex = 1;

            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            ClientSize = new Size(1200, 720);
            Controls.Add(panelContent);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1050, 650);
            Name = "AdminMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CO-LAB - Admin Management Portal";
            Load += AdminMainForm_Load;

            pnlSidebar.ResumeLayout(false);
            pnlNavArea.ResumeLayout(false);
            pnlNavContainer.ResumeLayout(false);
            pnlSidebarBottom.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            pnlRail.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlRail;
        private Label lblRailStar;
        private Label lblRailSearch;
        private Label lblRailGrid;
        private Label lblRailChat;
        private Label lblRailClock;
        private Label lblRailCap;
        private Label lblRailSettings;
        private Label lblRailHelp;
        private Panel pnlNavArea;
        private Panel pnlBrand;
        private Label lblBrandTitle1;
        private Label lblBrandTitle2;
        private Label lblBrandSub;
        private Panel pnlNavContainer;
        private Button btn_AdminDashboard;
        private Button btn_ModerateListings;
        private Button btn_ReportedStudents;
        private Button btn_SkillCategories;
        private Button btn_UpdateTOS;
        private Panel pnlNavIndicator;
        private Panel pnlSidebarBottom;
        private Button btn_SignOut;
        private Panel pnlPurpleDivider;
        private Panel panelContent;
    }
}
