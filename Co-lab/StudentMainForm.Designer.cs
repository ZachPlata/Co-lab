namespace Co_LAB
{
    partial class StudentMainForm
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
            btn_TradeRequests = new Button();
            btn_ManageSkills = new Button();
            btn_PostSkill = new Button();
            btn_SkillExchange = new Button();
            pnlSidebarBottom = new Panel();
            btn_SignOut = new Button();
            btn_UserDashboard = new Button();
            pnlDividerBottom = new Panel();
            pnlBrand = new Panel();
            pnlDividerTop = new Panel();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            pnlHeader = new Panel();
            pnlDividerHeader = new Panel();
            lblWelcome = new Label();
            lblHeaderTitle = new Label();
            panelContent = new Panel();
            content_studpan = new FlowLayoutPanel();
            pnlSidebar.SuspendLayout();
            pnlNavContainer.SuspendLayout();
            pnlSidebarBottom.SuspendLayout();
            pnlBrand.SuspendLayout();
            pnlHeader.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(15, 15, 17);
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
            pnlNavContainer.Controls.Add(btn_TradeRequests);
            pnlNavContainer.Controls.Add(btn_ManageSkills);
            pnlNavContainer.Controls.Add(btn_PostSkill);
            pnlNavContainer.Controls.Add(btn_SkillExchange);
            pnlNavContainer.Dock = DockStyle.Fill;
            pnlNavContainer.Location = new Point(0, 113);
            pnlNavContainer.Margin = new Padding(3, 4, 3, 4);
            pnlNavContainer.Name = "pnlNavContainer";
            pnlNavContainer.Padding = new Padding(0, 13, 0, 0);
            pnlNavContainer.Size = new Size(286, 714);
            pnlNavContainer.TabIndex = 1;
            // 
            // pnlNavIndicator
            // 
            pnlNavIndicator.BackColor = Color.FromArgb(16, 185, 129);
            pnlNavIndicator.Location = new Point(0, 13);
            pnlNavIndicator.Margin = new Padding(3, 4, 3, 4);
            pnlNavIndicator.Name = "pnlNavIndicator";
            pnlNavIndicator.Size = new Size(5, 67);
            pnlNavIndicator.TabIndex = 4;
            // 
            // btn_TradeRequests
            // 
            btn_TradeRequests.Cursor = Cursors.Hand;
            btn_TradeRequests.Dock = DockStyle.Top;
            btn_TradeRequests.FlatAppearance.BorderSize = 0;
            btn_TradeRequests.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_TradeRequests.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_TradeRequests.FlatStyle = FlatStyle.Flat;
            btn_TradeRequests.Font = new Font("Segoe UI", 10F);
            btn_TradeRequests.ForeColor = Color.FromArgb(161, 161, 170);
            btn_TradeRequests.Location = new Point(0, 214);
            btn_TradeRequests.Margin = new Padding(3, 4, 3, 4);
            btn_TradeRequests.Name = "btn_TradeRequests";
            btn_TradeRequests.Padding = new Padding(25, 0, 11, 0);
            btn_TradeRequests.Size = new Size(286, 67);
            btn_TradeRequests.TabIndex = 3;
            btn_TradeRequests.Text = "Trade Requests";
            btn_TradeRequests.TextAlign = ContentAlignment.MiddleLeft;
            btn_TradeRequests.UseVisualStyleBackColor = true;
            btn_TradeRequests.Click += btn_TradeRequests_Click;
            // 
            // btn_ManageSkills
            // 
            btn_ManageSkills.Cursor = Cursors.Hand;
            btn_ManageSkills.Dock = DockStyle.Top;
            btn_ManageSkills.FlatAppearance.BorderSize = 0;
            btn_ManageSkills.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_ManageSkills.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_ManageSkills.FlatStyle = FlatStyle.Flat;
            btn_ManageSkills.Font = new Font("Segoe UI", 10F);
            btn_ManageSkills.ForeColor = Color.FromArgb(161, 161, 170);
            btn_ManageSkills.Location = new Point(0, 147);
            btn_ManageSkills.Margin = new Padding(3, 4, 3, 4);
            btn_ManageSkills.Name = "btn_ManageSkills";
            btn_ManageSkills.Padding = new Padding(25, 0, 11, 0);
            btn_ManageSkills.Size = new Size(286, 67);
            btn_ManageSkills.TabIndex = 2;
            btn_ManageSkills.Text = "My Listings";
            btn_ManageSkills.TextAlign = ContentAlignment.MiddleLeft;
            btn_ManageSkills.UseVisualStyleBackColor = true;
            btn_ManageSkills.Click += btn_ManageSkills_Click;
            // 
            // btn_PostSkill
            // 
            btn_PostSkill.Cursor = Cursors.Hand;
            btn_PostSkill.Dock = DockStyle.Top;
            btn_PostSkill.FlatAppearance.BorderSize = 0;
            btn_PostSkill.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_PostSkill.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_PostSkill.FlatStyle = FlatStyle.Flat;
            btn_PostSkill.Font = new Font("Segoe UI", 10F);
            btn_PostSkill.ForeColor = Color.FromArgb(161, 161, 170);
            btn_PostSkill.Location = new Point(0, 80);
            btn_PostSkill.Margin = new Padding(3, 4, 3, 4);
            btn_PostSkill.Name = "btn_PostSkill";
            btn_PostSkill.Padding = new Padding(25, 0, 11, 0);
            btn_PostSkill.Size = new Size(286, 67);
            btn_PostSkill.TabIndex = 1;
            btn_PostSkill.Text = "Post New Skill";
            btn_PostSkill.TextAlign = ContentAlignment.MiddleLeft;
            btn_PostSkill.UseVisualStyleBackColor = true;
            btn_PostSkill.Click += btn_PostSkill_Click;
            // 
            // btn_SkillExchange
            // 
            btn_SkillExchange.Cursor = Cursors.Hand;
            btn_SkillExchange.Dock = DockStyle.Top;
            btn_SkillExchange.FlatAppearance.BorderSize = 0;
            btn_SkillExchange.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_SkillExchange.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_SkillExchange.FlatStyle = FlatStyle.Flat;
            btn_SkillExchange.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_SkillExchange.ForeColor = Color.FromArgb(16, 185, 129);
            btn_SkillExchange.Location = new Point(0, 13);
            btn_SkillExchange.Margin = new Padding(3, 4, 3, 4);
            btn_SkillExchange.Name = "btn_SkillExchange";
            btn_SkillExchange.Padding = new Padding(25, 0, 11, 0);
            btn_SkillExchange.Size = new Size(286, 67);
            btn_SkillExchange.TabIndex = 0;
            btn_SkillExchange.Text = "Skill Exchange";
            btn_SkillExchange.TextAlign = ContentAlignment.MiddleLeft;
            btn_SkillExchange.UseVisualStyleBackColor = true;
            btn_SkillExchange.Click += btn_SkillExchange_Click;
            // 
            // pnlSidebarBottom
            // 
            pnlSidebarBottom.Controls.Add(btn_SignOut);
            pnlSidebarBottom.Controls.Add(btn_UserDashboard);
            pnlSidebarBottom.Controls.Add(pnlDividerBottom);
            pnlSidebarBottom.Dock = DockStyle.Bottom;
            pnlSidebarBottom.Location = new Point(0, 827);
            pnlSidebarBottom.Margin = new Padding(3, 4, 3, 4);
            pnlSidebarBottom.Name = "pnlSidebarBottom";
            pnlSidebarBottom.Size = new Size(286, 133);
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
            btn_SignOut.Location = new Point(0, 66);
            btn_SignOut.Margin = new Padding(3, 4, 3, 4);
            btn_SignOut.Name = "btn_SignOut";
            btn_SignOut.Padding = new Padding(25, 0, 0, 0);
            btn_SignOut.Size = new Size(286, 67);
            btn_SignOut.TabIndex = 2;
            btn_SignOut.Text = "Sign Out";
            btn_SignOut.TextAlign = ContentAlignment.MiddleLeft;
            btn_SignOut.UseVisualStyleBackColor = true;
            btn_SignOut.Click += btn_SignOut_Click;
            // 
            // btn_UserDashboard
            // 
            btn_UserDashboard.Cursor = Cursors.Hand;
            btn_UserDashboard.Dock = DockStyle.Top;
            btn_UserDashboard.FlatAppearance.BorderSize = 0;
            btn_UserDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 35, 42);
            btn_UserDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 28, 33);
            btn_UserDashboard.FlatStyle = FlatStyle.Flat;
            btn_UserDashboard.Font = new Font("Segoe UI", 9.5F);
            btn_UserDashboard.ForeColor = Color.FromArgb(161, 161, 170);
            btn_UserDashboard.Location = new Point(0, 1);
            btn_UserDashboard.Margin = new Padding(3, 4, 3, 4);
            btn_UserDashboard.Name = "btn_UserDashboard";
            btn_UserDashboard.Padding = new Padding(25, 0, 11, 0);
            btn_UserDashboard.Size = new Size(286, 64);
            btn_UserDashboard.TabIndex = 1;
            btn_UserDashboard.Text = "👤 Zach Plata (Dashboard)";
            btn_UserDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btn_UserDashboard.UseVisualStyleBackColor = true;
            btn_UserDashboard.Click += btn_UserDashboard_Click;
            // 
            // pnlDividerBottom
            // 
            pnlDividerBottom.BackColor = Color.FromArgb(39, 39, 42);
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
            pnlDividerTop.BackColor = Color.FromArgb(39, 39, 42);
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
            lblBrandSubtitle.ForeColor = Color.FromArgb(161, 161, 170);
            lblBrandSubtitle.Location = new Point(25, 64);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(166, 19);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "UE Student Skill Exchange";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.FromArgb(16, 185, 129);
            lblBrandTitle.Location = new Point(23, 24);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(116, 37);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "CO-LAB";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(18, 18, 20);
            pnlHeader.Controls.Add(pnlDividerHeader);
            pnlHeader.Controls.Add(lblWelcome);
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
            pnlDividerHeader.BackColor = Color.FromArgb(39, 39, 42);
            pnlDividerHeader.Dock = DockStyle.Bottom;
            pnlDividerHeader.Location = new Point(0, 112);
            pnlDividerHeader.Margin = new Padding(3, 4, 3, 4);
            pnlDividerHeader.Name = "pnlDividerHeader";
            pnlDividerHeader.Size = new Size(1085, 1);
            pnlDividerHeader.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWelcome.AutoSize = true;
            lblWelcome.Cursor = Cursors.Hand;
            lblWelcome.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(16, 185, 129);
            lblWelcome.Location = new Point(890, 43);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(176, 23);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome, Zach Plata";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(34, 32);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(199, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Skill Exchange";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(24, 24, 27);
            panelContent.Controls.Add(content_studpan);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(286, 113);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1085, 847);
            panelContent.TabIndex = 2;
            // 
            // content_studpan
            // 
            content_studpan.Location = new Point(0, 1);
            content_studpan.Margin = new Padding(3, 4, 3, 4);
            content_studpan.Name = "content_studpan";
            content_studpan.Size = new Size(1086, 843);
            content_studpan.TabIndex = 1;
            // 
            // StudentMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 17);
            ClientSize = new Size(1371, 960);
            Controls.Add(panelContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 784);
            Name = "StudentMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CO-LAB - Student Portal";
            Load += StudentMainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlNavContainer.ResumeLayout(false);
            pnlSidebarBottom.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlBrand;
        private Label lblBrandTitle;
        private Label lblBrandSubtitle;
        private Panel pnlDividerTop;
        private Panel pnlNavContainer;
        private Button btn_SkillExchange;
        private Button btn_PostSkill;
        private Button btn_ManageSkills;
        private Button btn_TradeRequests;
        private Panel pnlNavIndicator;
        private Panel pnlSidebarBottom;
        private Panel pnlDividerBottom;
        private Button btn_UserDashboard;
        private Button btn_SignOut;
        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblWelcome;
        private Panel pnlDividerHeader;
        private Panel panelContent;
        private FlowLayoutPanel content_studpan;
    }
}
