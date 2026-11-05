namespace Co_LAB
{
    partial class uc_UserDashboard
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dgvHeaderStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvHeaderStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle2 = new DataGridViewCellStyle();

            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlUserBadge = new Panel();
            lblUserPrefix = new Label();
            lblUserName = new Label();

            pnlCard1 = new Panel();
            lblCard1Title = new Label();
            lblCard1Value = new Label();

            pnlCard2 = new Panel();
            lblCard2Title = new Label();
            lblCard2Value = new Label();

            pnlCard3 = new Panel();
            lblCard3Title = new Label();
            lblCard3Value = new Label();

            pnlCard4 = new Panel();
            lblCard4Title = new Label();
            lblCard4Value = new Label();

            pnlShortcuts = new Panel();
            lblShortcutsTitle = new Label();
            btnPostSkill = new Button();
            btnBrowseMarketplace = new Button();
            btnReadRegulations = new Button();
            btnTradeHistory = new Button();

            pnlIncoming = new Panel();
            lblIncomingTitle = new Label();
            lblIncomingSub = new Label();
            dgvIncoming = new DataGridView();
            btnAccept = new Button();
            btnDecline = new Button();

            pnlMySkills = new Panel();
            lblMySkillsTitle = new Label();
            lblMySkillsSub = new Label();
            dgvMySkills = new DataGridView();
            btnCloseListing = new Button();

            pnlUserBadge.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlShortcuts.SuspendLayout();
            pnlIncoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncoming).BeginInit();
            pnlMySkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMySkills).BeginInit();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(307, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Trade Overview";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(161, 161, 170);
            lblSubtitle.Location = new Point(26, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(136, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome back, student!";

            // 
            // pnlUserBadge
            // 
            pnlUserBadge.BackColor = Color.FromArgb(28, 38, 31);
            pnlUserBadge.Controls.Add(lblUserPrefix);
            pnlUserBadge.Controls.Add(lblUserName);
            pnlUserBadge.Location = new Point(726, 14);
            pnlUserBadge.Name = "pnlUserBadge";
            pnlUserBadge.Size = new Size(200, 36);
            pnlUserBadge.TabIndex = 2;
            pnlUserBadge.Paint += RoundPanel_Paint;

            // 
            // lblUserPrefix
            // 
            lblUserPrefix.AutoSize = true;
            lblUserPrefix.Font = new Font("Segoe UI", 9F);
            lblUserPrefix.ForeColor = Color.FromArgb(161, 161, 170);
            lblUserPrefix.Location = new Point(14, 10);
            lblUserPrefix.Name = "lblUserPrefix";
            lblUserPrefix.Size = new Size(33, 15);
            lblUserPrefix.TabIndex = 0;
            lblUserPrefix.Text = "User:";

            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(48, 9);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(99, 17);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Juan Dela Cruz";

            // 
            // pnlCard1 (Active Skill Listings)
            // 
            pnlCard1.BackColor = Color.FromArgb(24, 34, 27);
            pnlCard1.Controls.Add(lblCard1Title);
            pnlCard1.Controls.Add(lblCard1Value);
            pnlCard1.Location = new Point(24, 68);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new Size(215, 105);
            pnlCard1.TabIndex = 3;
            pnlCard1.Paint += RoundPanel_Paint;

            // 
            // lblCard1Title
            // 
            lblCard1Title.Dock = DockStyle.Top;
            lblCard1Title.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCard1Title.ForeColor = Color.FromArgb(116, 168, 126);
            lblCard1Title.Location = new Point(0, 0);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Padding = new Padding(0, 12, 0, 0);
            lblCard1Title.Size = new Size(215, 42);
            lblCard1Title.TabIndex = 0;
            lblCard1Title.Text = "MY ACTIVE SKILL\r\nLISTINGS";
            lblCard1Title.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblCard1Value
            // 
            lblCard1Value.Dock = DockStyle.Fill;
            lblCard1Value.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            lblCard1Value.ForeColor = Color.White;
            lblCard1Value.Location = new Point(0, 42);
            lblCard1Value.Name = "lblCard1Value";
            lblCard1Value.Size = new Size(215, 63);
            lblCard1Value.TabIndex = 1;
            lblCard1Value.Text = "3";
            lblCard1Value.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlCard2 (Pending Incoming Requests)
            // 
            pnlCard2.BackColor = Color.FromArgb(24, 34, 27);
            pnlCard2.Controls.Add(lblCard2Title);
            pnlCard2.Controls.Add(lblCard2Value);
            pnlCard2.Location = new Point(253, 68);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new Size(215, 105);
            pnlCard2.TabIndex = 4;
            pnlCard2.Paint += RoundPanel_Paint;

            // 
            // lblCard2Title
            // 
            lblCard2Title.Dock = DockStyle.Top;
            lblCard2Title.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCard2Title.ForeColor = Color.FromArgb(234, 179, 8);
            lblCard2Title.Location = new Point(0, 0);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Padding = new Padding(0, 12, 0, 0);
            lblCard2Title.Size = new Size(215, 42);
            lblCard2Title.TabIndex = 0;
            lblCard2Title.Text = "PENDING INCOMING\r\nREQUESTS";
            lblCard2Title.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblCard2Value
            // 
            lblCard2Value.Dock = DockStyle.Fill;
            lblCard2Value.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            lblCard2Value.ForeColor = Color.FromArgb(234, 179, 8);
            lblCard2Value.Location = new Point(0, 42);
            lblCard2Value.Name = "lblCard2Value";
            lblCard2Value.Size = new Size(215, 63);
            lblCard2Value.TabIndex = 1;
            lblCard2Value.Text = "2";
            lblCard2Value.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlCard3 (Accepted Trades)
            // 
            pnlCard3.BackColor = Color.FromArgb(24, 34, 27);
            pnlCard3.Controls.Add(lblCard3Title);
            pnlCard3.Controls.Add(lblCard3Value);
            pnlCard3.Location = new Point(482, 68);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new Size(215, 105);
            pnlCard3.TabIndex = 5;
            pnlCard3.Paint += RoundPanel_Paint;

            // 
            // lblCard3Title
            // 
            lblCard3Title.Dock = DockStyle.Top;
            lblCard3Title.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCard3Title.ForeColor = Color.FromArgb(116, 168, 126);
            lblCard3Title.Location = new Point(0, 0);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Padding = new Padding(0, 12, 0, 0);
            lblCard3Title.Size = new Size(215, 42);
            lblCard3Title.TabIndex = 0;
            lblCard3Title.Text = "ACCEPTED TRADES\r\n(ACTIVE)";
            lblCard3Title.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblCard3Value
            // 
            lblCard3Value.Dock = DockStyle.Fill;
            lblCard3Value.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            lblCard3Value.ForeColor = Color.FromArgb(94, 204, 122);
            lblCard3Value.Location = new Point(0, 42);
            lblCard3Value.Name = "lblCard3Value";
            lblCard3Value.Size = new Size(215, 63);
            lblCard3Value.TabIndex = 1;
            lblCard3Value.Text = "5";
            lblCard3Value.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlCard4 (Outgoing Requests)
            // 
            pnlCard4.BackColor = Color.FromArgb(24, 34, 27);
            pnlCard4.Controls.Add(lblCard4Title);
            pnlCard4.Controls.Add(lblCard4Value);
            pnlCard4.Location = new Point(711, 68);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.Size = new Size(215, 105);
            pnlCard4.TabIndex = 6;
            pnlCard4.Paint += RoundPanel_Paint;

            // 
            // lblCard4Title
            // 
            lblCard4Title.Dock = DockStyle.Top;
            lblCard4Title.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCard4Title.ForeColor = Color.FromArgb(180, 195, 185);
            lblCard4Title.Location = new Point(0, 0);
            lblCard4Title.Name = "lblCard4Title";
            lblCard4Title.Padding = new Padding(0, 12, 0, 0);
            lblCard4Title.Size = new Size(215, 42);
            lblCard4Title.TabIndex = 0;
            lblCard4Title.Text = "OUTGOING\r\nREQUESTS";
            lblCard4Title.TextAlign = ContentAlignment.TopCenter;

            // 
            // lblCard4Value
            // 
            lblCard4Value.Dock = DockStyle.Fill;
            lblCard4Value.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            lblCard4Value.ForeColor = Color.White;
            lblCard4Value.Location = new Point(0, 42);
            lblCard4Value.Name = "lblCard4Value";
            lblCard4Value.Size = new Size(215, 63);
            lblCard4Value.TabIndex = 1;
            lblCard4Value.Text = "1";
            lblCard4Value.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlShortcuts
            // 
            pnlShortcuts.BackColor = Color.FromArgb(24, 34, 27);
            pnlShortcuts.Controls.Add(btnTradeHistory);
            pnlShortcuts.Controls.Add(btnReadRegulations);
            pnlShortcuts.Controls.Add(btnBrowseMarketplace);
            pnlShortcuts.Controls.Add(btnPostSkill);
            pnlShortcuts.Controls.Add(lblShortcutsTitle);
            pnlShortcuts.Location = new Point(24, 184);
            pnlShortcuts.Name = "pnlShortcuts";
            pnlShortcuts.Size = new Size(902, 80);
            pnlShortcuts.TabIndex = 7;
            pnlShortcuts.Paint += RoundPanel_Paint;

            // 
            // lblShortcutsTitle
            // 
            lblShortcutsTitle.AutoSize = true;
            lblShortcutsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShortcutsTitle.ForeColor = Color.White;
            lblShortcutsTitle.Location = new Point(20, 10);
            lblShortcutsTitle.Name = "lblShortcutsTitle";
            lblShortcutsTitle.Size = new Size(130, 19);
            lblShortcutsTitle.TabIndex = 0;
            lblShortcutsTitle.Text = "Student Shortcuts";

            // 
            // btnPostSkill
            // 
            btnPostSkill.BackColor = Color.FromArgb(20, 28, 23);
            btnPostSkill.Cursor = Cursors.Hand;
            btnPostSkill.FlatAppearance.BorderColor = Color.FromArgb(48, 68, 54);
            btnPostSkill.FlatAppearance.BorderSize = 1;
            btnPostSkill.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 45, 36);
            btnPostSkill.FlatStyle = FlatStyle.Flat;
            btnPostSkill.Font = new Font("Segoe UI Semibold", 9F);
            btnPostSkill.ForeColor = Color.White;
            btnPostSkill.Location = new Point(78, 36);
            btnPostSkill.Name = "btnPostSkill";
            btnPostSkill.Size = new Size(168, 32);
            btnPostSkill.TabIndex = 1;
            btnPostSkill.Text = "Post New Skill";
            btnPostSkill.UseVisualStyleBackColor = false;
            btnPostSkill.Click += btnPostSkill_Click;

            // 
            // btnBrowseMarketplace
            // 
            btnBrowseMarketplace.BackColor = Color.FromArgb(20, 28, 23);
            btnBrowseMarketplace.Cursor = Cursors.Hand;
            btnBrowseMarketplace.FlatAppearance.BorderColor = Color.FromArgb(48, 68, 54);
            btnBrowseMarketplace.FlatAppearance.BorderSize = 1;
            btnBrowseMarketplace.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 45, 36);
            btnBrowseMarketplace.FlatStyle = FlatStyle.Flat;
            btnBrowseMarketplace.Font = new Font("Segoe UI Semibold", 9F);
            btnBrowseMarketplace.ForeColor = Color.White;
            btnBrowseMarketplace.Location = new Point(266, 36);
            btnBrowseMarketplace.Name = "btnBrowseMarketplace";
            btnBrowseMarketplace.Size = new Size(178, 32);
            btnBrowseMarketplace.TabIndex = 2;
            btnBrowseMarketplace.Text = "Browse Marketplace";
            btnBrowseMarketplace.UseVisualStyleBackColor = false;
            btnBrowseMarketplace.Click += btnBrowseMarketplace_Click;

            // 
            // btnReadRegulations
            // 
            btnReadRegulations.BackColor = Color.FromArgb(20, 28, 23);
            btnReadRegulations.Cursor = Cursors.Hand;
            btnReadRegulations.FlatAppearance.BorderColor = Color.FromArgb(48, 68, 54);
            btnReadRegulations.FlatAppearance.BorderSize = 1;
            btnReadRegulations.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 45, 36);
            btnReadRegulations.FlatStyle = FlatStyle.Flat;
            btnReadRegulations.Font = new Font("Segoe UI Semibold", 9F);
            btnReadRegulations.ForeColor = Color.White;
            btnReadRegulations.Location = new Point(464, 36);
            btnReadRegulations.Name = "btnReadRegulations";
            btnReadRegulations.Size = new Size(172, 32);
            btnReadRegulations.TabIndex = 3;
            btnReadRegulations.Text = "Read Regulations";
            btnReadRegulations.UseVisualStyleBackColor = false;
            btnReadRegulations.Click += btnReadRegulations_Click;

            // 
            // btnTradeHistory
            // 
            btnTradeHistory.BackColor = Color.FromArgb(20, 28, 23);
            btnTradeHistory.Cursor = Cursors.Hand;
            btnTradeHistory.FlatAppearance.BorderColor = Color.FromArgb(48, 68, 54);
            btnTradeHistory.FlatAppearance.BorderSize = 1;
            btnTradeHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(32, 45, 36);
            btnTradeHistory.FlatStyle = FlatStyle.Flat;
            btnTradeHistory.Font = new Font("Segoe UI Semibold", 9F);
            btnTradeHistory.ForeColor = Color.White;
            btnTradeHistory.Location = new Point(656, 36);
            btnTradeHistory.Name = "btnTradeHistory";
            btnTradeHistory.Size = new Size(168, 32);
            btnTradeHistory.TabIndex = 4;
            btnTradeHistory.Text = "My Trade History";
            btnTradeHistory.UseVisualStyleBackColor = false;
            btnTradeHistory.Click += btnTradeHistory_Click;

            // 
            // pnlIncoming (Incoming Trade Requests)
            // 
            pnlIncoming.BackColor = Color.FromArgb(24, 34, 27);
            pnlIncoming.Controls.Add(btnDecline);
            pnlIncoming.Controls.Add(btnAccept);
            pnlIncoming.Controls.Add(dgvIncoming);
            pnlIncoming.Controls.Add(lblIncomingSub);
            pnlIncoming.Controls.Add(lblIncomingTitle);
            pnlIncoming.Location = new Point(24, 275);
            pnlIncoming.Name = "pnlIncoming";
            pnlIncoming.Size = new Size(443, 342);
            pnlIncoming.TabIndex = 8;
            pnlIncoming.Paint += RoundPanel_Paint;

            // 
            // lblIncomingTitle
            // 
            lblIncomingTitle.AutoSize = true;
            lblIncomingTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIncomingTitle.ForeColor = Color.White;
            lblIncomingTitle.Location = new Point(14, 12);
            lblIncomingTitle.Name = "lblIncomingTitle";
            lblIncomingTitle.Size = new Size(174, 19);
            lblIncomingTitle.TabIndex = 0;
            lblIncomingTitle.Text = "Incoming Trade Requests";

            // 
            // lblIncomingSub
            // 
            lblIncomingSub.AutoSize = true;
            lblIncomingSub.Font = new Font("Segoe UI", 8.5F);
            lblIncomingSub.ForeColor = Color.FromArgb(140, 160, 145);
            lblIncomingSub.Location = new Point(190, 15);
            lblIncomingSub.Name = "lblIncomingSub";
            lblIncomingSub.Size = new Size(149, 15);
            lblIncomingSub.TabIndex = 1;
            lblIncomingSub.Text = "(Waiting for your approval)";

            // 
            // dgvIncoming
            // 
            dgvIncoming.AllowUserToAddRows = false;
            dgvIncoming.AllowUserToDeleteRows = false;
            dgvIncoming.AllowUserToResizeRows = false;
            dgvIncoming.BackgroundColor = Color.FromArgb(19, 26, 21);
            dgvIncoming.BorderStyle = BorderStyle.None;
            dgvIncoming.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvIncoming.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvHeaderStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle1.BackColor = Color.FromArgb(28, 38, 31);
            dgvHeaderStyle1.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            dgvHeaderStyle1.ForeColor = Color.White;
            dgvHeaderStyle1.Padding = new Padding(4, 0, 0, 0);
            dgvHeaderStyle1.SelectionBackColor = Color.FromArgb(28, 38, 31);
            dgvHeaderStyle1.SelectionForeColor = Color.White;
            dgvHeaderStyle1.WrapMode = DataGridViewTriState.False;
            dgvIncoming.ColumnHeadersDefaultCellStyle = dgvHeaderStyle1;
            dgvIncoming.ColumnHeadersHeight = 28;
            dgvIncoming.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRowStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle1.BackColor = Color.FromArgb(22, 30, 24);
            dgvRowStyle1.Font = new Font("Segoe UI", 8.5F);
            dgvRowStyle1.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle1.Padding = new Padding(4, 0, 0, 0);
            dgvRowStyle1.SelectionBackColor = Color.FromArgb(38, 58, 45);
            dgvRowStyle1.SelectionForeColor = Color.White;
            dgvRowStyle1.WrapMode = DataGridViewTriState.False;
            dgvIncoming.DefaultCellStyle = dgvRowStyle1;
            dgvIncoming.EnableHeadersVisualStyles = false;
            dgvIncoming.GridColor = Color.FromArgb(42, 58, 46);
            dgvIncoming.Location = new Point(14, 38);
            dgvIncoming.MultiSelect = false;
            dgvIncoming.Name = "dgvIncoming";
            dgvIncoming.ReadOnly = true;
            dgvIncoming.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvIncoming.RowHeadersDefaultCellStyle = dgvHeaderStyle1;
            dgvIncoming.RowHeadersWidth = 24;
            dgvIncoming.RowTemplate.Height = 26;
            dgvIncoming.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncoming.Size = new Size(330, 288);
            dgvIncoming.TabIndex = 2;

            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.FromArgb(78, 135, 82);
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatAppearance.MouseOverBackColor = Color.FromArgb(92, 155, 96);
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(353, 142);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(78, 32);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;

            // 
            // btnDecline
            // 
            btnDecline.BackColor = Color.FromArgb(185, 38, 38);
            btnDecline.Cursor = Cursors.Hand;
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 48, 48);
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDecline.ForeColor = Color.White;
            btnDecline.Location = new Point(353, 184);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(78, 32);
            btnDecline.TabIndex = 4;
            btnDecline.Text = "Decline";
            btnDecline.UseVisualStyleBackColor = false;
            btnDecline.Click += btnDecline_Click;

            // 
            // pnlMySkills (My Offered Skills)
            // 
            pnlMySkills.BackColor = Color.FromArgb(24, 34, 27);
            pnlMySkills.Controls.Add(btnCloseListing);
            pnlMySkills.Controls.Add(dgvMySkills);
            pnlMySkills.Controls.Add(lblMySkillsSub);
            pnlMySkills.Controls.Add(lblMySkillsTitle);
            pnlMySkills.Location = new Point(483, 275);
            pnlMySkills.Name = "pnlMySkills";
            pnlMySkills.Size = new Size(443, 342);
            pnlMySkills.TabIndex = 9;
            pnlMySkills.Paint += RoundPanel_Paint;

            // 
            // lblMySkillsTitle
            // 
            lblMySkillsTitle.AutoSize = true;
            lblMySkillsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMySkillsTitle.ForeColor = Color.White;
            lblMySkillsTitle.Location = new Point(14, 12);
            lblMySkillsTitle.Name = "lblMySkillsTitle";
            lblMySkillsTitle.Size = new Size(127, 19);
            lblMySkillsTitle.TabIndex = 0;
            lblMySkillsTitle.Text = "My Offered Skills";

            // 
            // lblMySkillsSub
            // 
            lblMySkillsSub.AutoSize = true;
            lblMySkillsSub.Font = new Font("Segoe UI", 8.5F);
            lblMySkillsSub.ForeColor = Color.FromArgb(140, 160, 145);
            lblMySkillsSub.Location = new Point(143, 15);
            lblMySkillsSub.Name = "lblMySkillsSub";
            lblMySkillsSub.Size = new Size(157, 15);
            lblMySkillsSub.TabIndex = 1;
            lblMySkillsSub.Text = "(Manage your active posts)";

            // 
            // dgvMySkills
            // 
            dgvMySkills.AllowUserToAddRows = false;
            dgvMySkills.AllowUserToDeleteRows = false;
            dgvMySkills.AllowUserToResizeRows = false;
            dgvMySkills.BackgroundColor = Color.FromArgb(19, 26, 21);
            dgvMySkills.BorderStyle = BorderStyle.None;
            dgvMySkills.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvMySkills.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvHeaderStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle2.BackColor = Color.FromArgb(28, 38, 31);
            dgvHeaderStyle2.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            dgvHeaderStyle2.ForeColor = Color.White;
            dgvHeaderStyle2.Padding = new Padding(4, 0, 0, 0);
            dgvHeaderStyle2.SelectionBackColor = Color.FromArgb(28, 38, 31);
            dgvHeaderStyle2.SelectionForeColor = Color.White;
            dgvHeaderStyle2.WrapMode = DataGridViewTriState.False;
            dgvMySkills.ColumnHeadersDefaultCellStyle = dgvHeaderStyle2;
            dgvMySkills.ColumnHeadersHeight = 28;
            dgvMySkills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRowStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle2.BackColor = Color.FromArgb(22, 30, 24);
            dgvRowStyle2.Font = new Font("Segoe UI", 8.5F);
            dgvRowStyle2.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle2.Padding = new Padding(4, 0, 0, 0);
            dgvRowStyle2.SelectionBackColor = Color.FromArgb(38, 58, 45);
            dgvRowStyle2.SelectionForeColor = Color.White;
            dgvRowStyle2.WrapMode = DataGridViewTriState.False;
            dgvMySkills.DefaultCellStyle = dgvRowStyle2;
            dgvMySkills.EnableHeadersVisualStyles = false;
            dgvMySkills.GridColor = Color.FromArgb(42, 58, 46);
            dgvMySkills.Location = new Point(14, 38);
            dgvMySkills.MultiSelect = false;
            dgvMySkills.Name = "dgvMySkills";
            dgvMySkills.ReadOnly = true;
            dgvMySkills.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMySkills.RowHeadersDefaultCellStyle = dgvHeaderStyle2;
            dgvMySkills.RowHeadersWidth = 24;
            dgvMySkills.RowTemplate.Height = 26;
            dgvMySkills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMySkills.Size = new Size(415, 236);
            dgvMySkills.TabIndex = 2;

            // 
            // btnCloseListing
            // 
            btnCloseListing.BackColor = Color.FromArgb(185, 38, 38);
            btnCloseListing.Cursor = Cursors.Hand;
            btnCloseListing.FlatAppearance.BorderSize = 0;
            btnCloseListing.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 48, 48);
            btnCloseListing.FlatStyle = FlatStyle.Flat;
            btnCloseListing.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCloseListing.ForeColor = Color.White;
            btnCloseListing.Location = new Point(126, 288);
            btnCloseListing.Name = "btnCloseListing";
            btnCloseListing.Size = new Size(190, 36);
            btnCloseListing.TabIndex = 3;
            btnCloseListing.Text = "Close / Remove Listing";
            btnCloseListing.UseVisualStyleBackColor = false;
            btnCloseListing.Click += btnCloseListing_Click;

            // 
            // uc_UserDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlMySkills);
            Controls.Add(pnlIncoming);
            Controls.Add(pnlShortcuts);
            Controls.Add(pnlCard4);
            Controls.Add(pnlCard3);
            Controls.Add(pnlCard2);
            Controls.Add(pnlCard1);
            Controls.Add(pnlUserBadge);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Name = "uc_UserDashboard";
            Size = new Size(950, 632);
            Load += uc_UserDashboard_Load;

            pnlUserBadge.ResumeLayout(false);
            pnlUserBadge.PerformLayout();
            pnlCard1.ResumeLayout(false);
            pnlCard2.ResumeLayout(false);
            pnlCard3.ResumeLayout(false);
            pnlCard4.ResumeLayout(false);
            pnlShortcuts.ResumeLayout(false);
            pnlShortcuts.PerformLayout();
            pnlIncoming.ResumeLayout(false);
            pnlIncoming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIncoming).EndInit();
            pnlMySkills.ResumeLayout(false);
            pnlMySkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMySkills).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlUserBadge;
        private Label lblUserPrefix;
        private Label lblUserName;

        private Panel pnlCard1;
        private Label lblCard1Title;
        private Label lblCard1Value;

        private Panel pnlCard2;
        private Label lblCard2Title;
        private Label lblCard2Value;

        private Panel pnlCard3;
        private Label lblCard3Title;
        private Label lblCard3Value;

        private Panel pnlCard4;
        private Label lblCard4Title;
        private Label lblCard4Value;

        private Panel pnlShortcuts;
        private Label lblShortcutsTitle;
        private Button btnPostSkill;
        private Button btnBrowseMarketplace;
        private Button btnReadRegulations;
        private Button btnTradeHistory;

        private Panel pnlIncoming;
        private Label lblIncomingTitle;
        private Label lblIncomingSub;
        private DataGridView dgvIncoming;
        private Button btnAccept;
        private Button btnDecline;

        private Panel pnlMySkills;
        private Label lblMySkillsTitle;
        private Label lblMySkillsSub;
        private DataGridView dgvMySkills;
        private Button btnCloseListing;
    }
}
