namespace Co_LAB
{
    partial class uc_PostSkill
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeaderCard = new Panel();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlUserBadge = new Panel();
            lblUserIcon = new Label();
            lblUserName = new Label();
            lblUserRole = new Label();

            pnlPolicyNotice = new Panel();
            lblPolicyIcon = new Label();
            lblPolicyText = new Label();

            pnlOfferDetails = new Panel();
            lblSection1Title = new Label();
            lblSkillTitle = new Label();
            txtSkillTitle = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblProficiency = new Label();
            cmbProficiency = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();

            pnlExchangeDetails = new Panel();
            lblSection2Title = new Label();
            lblDesiredSkill = new Label();
            txtDesiredSkill = new TextBox();
            lblDeliveryMode = new Label();
            pnlDeliveryMode = new Panel();
            rbOnline = new RadioButton();
            rbFaceToFace = new RadioButton();
            lblLocation = new Label();
            txtLocation = new TextBox();
            lblAvailability = new Label();
            txtAvailability = new TextBox();
            pnlTip = new Panel();
            lblTipText = new Label();

            pnlActionBar = new Panel();
            lblStatusMessage = new Label();
            btnPostSkill = new Button();
            btnClear = new Button();

            pnlHeaderCard.SuspendLayout();
            pnlUserBadge.SuspendLayout();
            pnlPolicyNotice.SuspendLayout();
            pnlOfferDetails.SuspendLayout();
            pnlExchangeDetails.SuspendLayout();
            pnlDeliveryMode.SuspendLayout();
            pnlTip.SuspendLayout();
            pnlActionBar.SuspendLayout();
            SuspendLayout();

            // 
            // pnlHeaderCard
            // 
            pnlHeaderCard.BackColor = Color.FromArgb(20, 28, 23);
            pnlHeaderCard.Controls.Add(lblHeaderTitle);
            pnlHeaderCard.Controls.Add(lblHeaderSubtitle);
            pnlHeaderCard.Controls.Add(pnlUserBadge);
            pnlHeaderCard.Location = new Point(25, 20);
            pnlHeaderCard.Name = "pnlHeaderCard";
            pnlHeaderCard.Size = new Size(960, 90);
            pnlHeaderCard.TabIndex = 0;
            pnlHeaderCard.Paint += RoundPanel_Paint;

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(231, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Post a New Skill Offer";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 50);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(585, 17);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Share your skills and knowledge with fellow UE students in exchange for subjects you want to learn.";

            // 
            // pnlUserBadge
            // 
            pnlUserBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlUserBadge.BackColor = Color.FromArgb(14, 20, 16);
            pnlUserBadge.Controls.Add(lblUserIcon);
            pnlUserBadge.Controls.Add(lblUserName);
            pnlUserBadge.Controls.Add(lblUserRole);
            pnlUserBadge.Location = new Point(740, 20);
            pnlUserBadge.Name = "pnlUserBadge";
            pnlUserBadge.Size = new Size(196, 50);
            pnlUserBadge.TabIndex = 2;
            pnlUserBadge.Paint += RoundPanel_Paint;

            // 
            // lblUserIcon
            // 
            lblUserIcon.AutoSize = true;
            lblUserIcon.Font = new Font("Segoe UI", 16F);
            lblUserIcon.ForeColor = Color.FromArgb(74, 222, 128);
            lblUserIcon.Location = new Point(10, 8);
            lblUserIcon.Name = "lblUserIcon";
            lblUserIcon.Size = new Size(33, 30);
            lblUserIcon.TabIndex = 0;
            lblUserIcon.Text = "👤";

            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(46, 8);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(100, 17);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Juan Dela Cruz";

            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 8F);
            lblUserRole.ForeColor = Color.FromArgb(74, 222, 128);
            lblUserRole.Location = new Point(47, 27);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(104, 13);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "● Verified Student";

            // 
            // pnlPolicyNotice
            // 
            pnlPolicyNotice.BackColor = Color.FromArgb(20, 28, 23);
            pnlPolicyNotice.Controls.Add(lblPolicyIcon);
            pnlPolicyNotice.Controls.Add(lblPolicyText);
            pnlPolicyNotice.Location = new Point(25, 120);
            pnlPolicyNotice.Name = "pnlPolicyNotice";
            pnlPolicyNotice.Size = new Size(960, 42);
            pnlPolicyNotice.TabIndex = 1;
            pnlPolicyNotice.Paint += RoundPanel_Paint;

            // 
            // lblPolicyIcon
            // 
            lblPolicyIcon.AutoSize = true;
            lblPolicyIcon.Font = new Font("Segoe UI", 11F);
            lblPolicyIcon.ForeColor = Color.FromArgb(250, 204, 21);
            lblPolicyIcon.Location = new Point(14, 10);
            lblPolicyIcon.Name = "lblPolicyIcon";
            lblPolicyIcon.Size = new Size(24, 20);
            lblPolicyIcon.TabIndex = 0;
            lblPolicyIcon.Text = "💡";

            // 
            // lblPolicyText
            // 
            lblPolicyText.AutoSize = true;
            lblPolicyText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPolicyText.ForeColor = Color.FromArgb(200, 220, 210);
            lblPolicyText.Location = new Point(44, 13);
            lblPolicyText.Name = "lblPolicyText";
            lblPolicyText.Size = new Size(748, 15);
            lblPolicyText.TabIndex = 1;
            lblPolicyText.Text = "Strictly Cash-Free Barter: Skills must be exchanged mutually. Charging money or doing graded coursework for others is forbidden.";

            // 
            // pnlOfferDetails
            // 
            pnlOfferDetails.BackColor = Color.FromArgb(20, 28, 23);
            pnlOfferDetails.Controls.Add(lblSection1Title);
            pnlOfferDetails.Controls.Add(lblSkillTitle);
            pnlOfferDetails.Controls.Add(txtSkillTitle);
            pnlOfferDetails.Controls.Add(lblCategory);
            pnlOfferDetails.Controls.Add(cmbCategory);
            pnlOfferDetails.Controls.Add(lblProficiency);
            pnlOfferDetails.Controls.Add(cmbProficiency);
            pnlOfferDetails.Controls.Add(lblDescription);
            pnlOfferDetails.Controls.Add(txtDescription);
            pnlOfferDetails.Location = new Point(25, 175);
            pnlOfferDetails.Name = "pnlOfferDetails";
            pnlOfferDetails.Size = new Size(470, 490);
            pnlOfferDetails.TabIndex = 2;
            pnlOfferDetails.Paint += RoundPanel_Paint;

            // 
            // lblSection1Title
            // 
            lblSection1Title.AutoSize = true;
            lblSection1Title.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblSection1Title.ForeColor = Color.FromArgb(74, 222, 128);
            lblSection1Title.Location = new Point(18, 16);
            lblSection1Title.Name = "lblSection1Title";
            lblSection1Title.Size = new Size(242, 21);
            lblSection1Title.TabIndex = 0;
            lblSection1Title.Text = "1. Skill You Can Share / Teach";

            // 
            // lblSkillTitle
            // 
            lblSkillTitle.AutoSize = true;
            lblSkillTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSkillTitle.ForeColor = Color.White;
            lblSkillTitle.Location = new Point(18, 52);
            lblSkillTitle.Name = "lblSkillTitle";
            lblSkillTitle.Size = new Size(116, 15);
            lblSkillTitle.TabIndex = 1;
            lblSkillTitle.Text = "Skill Title / Topic: *";

            // 
            // txtSkillTitle
            // 
            txtSkillTitle.BackColor = Color.FromArgb(14, 20, 16);
            txtSkillTitle.BorderStyle = BorderStyle.FixedSingle;
            txtSkillTitle.Font = new Font("Segoe UI", 9.5F);
            txtSkillTitle.ForeColor = Color.White;
            txtSkillTitle.Location = new Point(20, 72);
            txtSkillTitle.Name = "txtSkillTitle";
            txtSkillTitle.PlaceholderText = "e.g., C# WinForms & MySQL Tutoring, Figma UI/UX...";
            txtSkillTitle.Size = new Size(430, 24);
            txtSkillTitle.TabIndex = 2;

            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.ForeColor = Color.White;
            lblCategory.Location = new Point(18, 108);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(95, 15);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Skill Category: *";

            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(14, 20, 16);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Segoe UI", 9.5F);
            cmbCategory.ForeColor = Color.White;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Items.AddRange(new object[] {
                "Computer Science & IT",
                "Graphic & Visual Design",
                "Engineering & Math",
                "Music & Arts",
                "Language & Writing",
                "Business & Marketing",
                "Video Editing & Multimedia"
            });
            cmbCategory.Location = new Point(20, 128);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(430, 25);
            cmbCategory.TabIndex = 4;

            // 
            // lblProficiency
            // 
            lblProficiency.AutoSize = true;
            lblProficiency.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProficiency.ForeColor = Color.White;
            lblProficiency.Location = new Point(18, 166);
            lblProficiency.Name = "lblProficiency";
            lblProficiency.Size = new Size(137, 15);
            lblProficiency.TabIndex = 5;
            lblProficiency.Text = "Your Proficiency Level:";

            // 
            // cmbProficiency
            // 
            cmbProficiency.BackColor = Color.FromArgb(14, 20, 16);
            cmbProficiency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProficiency.FlatStyle = FlatStyle.Flat;
            cmbProficiency.Font = new Font("Segoe UI", 9.5F);
            cmbProficiency.ForeColor = Color.White;
            cmbProficiency.FormattingEnabled = true;
            cmbProficiency.Items.AddRange(new object[] {
                "Intermediate (Solid grasp, can mentor and build)",
                "Advanced (In-depth mastery & practical experience)",
                "Beginner-Friendly Peer Tutor"
            });
            cmbProficiency.Location = new Point(20, 186);
            cmbProficiency.Name = "cmbProficiency";
            cmbProficiency.Size = new Size(430, 25);
            cmbProficiency.TabIndex = 6;

            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(18, 224);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(234, 15);
            lblDescription.TabIndex = 7;
            lblDescription.Text = "What will you teach? (Detailed Notes): *";

            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(14, 20, 16);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(20, 244);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Outline topics covered, session format, prerequisites, tools used (e.g., VS2022, Figma), or hands-on practice you offer...";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(430, 226);
            txtDescription.TabIndex = 8;

            // 
            // pnlExchangeDetails
            // 
            pnlExchangeDetails.BackColor = Color.FromArgb(20, 28, 23);
            pnlExchangeDetails.Controls.Add(lblSection2Title);
            pnlExchangeDetails.Controls.Add(lblDesiredSkill);
            pnlExchangeDetails.Controls.Add(txtDesiredSkill);
            pnlExchangeDetails.Controls.Add(lblDeliveryMode);
            pnlExchangeDetails.Controls.Add(pnlDeliveryMode);
            pnlExchangeDetails.Controls.Add(lblLocation);
            pnlExchangeDetails.Controls.Add(txtLocation);
            pnlExchangeDetails.Controls.Add(lblAvailability);
            pnlExchangeDetails.Controls.Add(txtAvailability);
            pnlExchangeDetails.Controls.Add(pnlTip);
            pnlExchangeDetails.Location = new Point(515, 175);
            pnlExchangeDetails.Name = "pnlExchangeDetails";
            pnlExchangeDetails.Size = new Size(470, 490);
            pnlExchangeDetails.TabIndex = 3;
            pnlExchangeDetails.Paint += RoundPanel_Paint;

            // 
            // lblSection2Title
            // 
            lblSection2Title.AutoSize = true;
            lblSection2Title.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lblSection2Title.ForeColor = Color.FromArgb(74, 222, 128);
            lblSection2Title.Location = new Point(18, 16);
            lblSection2Title.Name = "lblSection2Title";
            lblSection2Title.Size = new Size(260, 21);
            lblSection2Title.TabIndex = 0;
            lblSection2Title.Text = "2. Exchange Needs & Logistics";

            // 
            // lblDesiredSkill
            // 
            lblDesiredSkill.AutoSize = true;
            lblDesiredSkill.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDesiredSkill.ForeColor = Color.White;
            lblDesiredSkill.Location = new Point(18, 52);
            lblDesiredSkill.Name = "lblDesiredSkill";
            lblDesiredSkill.Size = new Size(286, 15);
            lblDesiredSkill.TabIndex = 1;
            lblDesiredSkill.Text = "Skill You Want in Return (Strictly No Cash): *";

            // 
            // txtDesiredSkill
            // 
            txtDesiredSkill.BackColor = Color.FromArgb(14, 20, 16);
            txtDesiredSkill.BorderStyle = BorderStyle.FixedSingle;
            txtDesiredSkill.Font = new Font("Segoe UI", 9.5F);
            txtDesiredSkill.ForeColor = Color.White;
            txtDesiredSkill.Location = new Point(20, 72);
            txtDesiredSkill.Name = "txtDesiredSkill";
            txtDesiredSkill.PlaceholderText = "e.g., Python Basics, Differential Calculus, or open to any skill...";
            txtDesiredSkill.Size = new Size(430, 24);
            txtDesiredSkill.TabIndex = 2;

            // 
            // lblDeliveryMode
            // 
            lblDeliveryMode.AutoSize = true;
            lblDeliveryMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeliveryMode.ForeColor = Color.White;
            lblDeliveryMode.Location = new Point(18, 108);
            lblDeliveryMode.Name = "lblDeliveryMode";
            lblDeliveryMode.Size = new Size(183, 15);
            lblDeliveryMode.TabIndex = 3;
            lblDeliveryMode.Text = "Exchange Format / Delivery: *";

            // 
            // pnlDeliveryMode
            // 
            pnlDeliveryMode.BackColor = Color.FromArgb(14, 20, 16);
            pnlDeliveryMode.Controls.Add(rbOnline);
            pnlDeliveryMode.Controls.Add(rbFaceToFace);
            pnlDeliveryMode.Location = new Point(20, 128);
            pnlDeliveryMode.Name = "pnlDeliveryMode";
            pnlDeliveryMode.Size = new Size(430, 34);
            pnlDeliveryMode.TabIndex = 4;

            // 
            // rbOnline
            // 
            rbOnline.AutoSize = true;
            rbOnline.Checked = true;
            rbOnline.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbOnline.ForeColor = Color.White;
            rbOnline.Location = new Point(15, 7);
            rbOnline.Name = "rbOnline";
            rbOnline.Size = new Size(177, 19);
            rbOnline.TabIndex = 0;
            rbOnline.TabStop = true;
            rbOnline.Text = "🌐 Online (Meet / Discord)";
            rbOnline.UseVisualStyleBackColor = true;
            rbOnline.CheckedChanged += DeliveryMode_CheckedChanged;

            // 
            // rbFaceToFace
            // 
            rbFaceToFace.AutoSize = true;
            rbFaceToFace.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbFaceToFace.ForeColor = Color.White;
            rbFaceToFace.Location = new Point(220, 7);
            rbFaceToFace.Name = "rbFaceToFace";
            rbFaceToFace.Size = new Size(179, 19);
            rbFaceToFace.TabIndex = 1;
            rbFaceToFace.Text = "🏫 Face-to-Face (Campus)";
            rbFaceToFace.UseVisualStyleBackColor = true;
            rbFaceToFace.CheckedChanged += DeliveryMode_CheckedChanged;

            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocation.ForeColor = Color.White;
            lblLocation.Location = new Point(18, 172);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(295, 15);
            lblLocation.TabIndex = 5;
            lblLocation.Text = "Preferred Meetup Location (e.g., Campus Area):";

            // 
            // txtLocation
            // 
            txtLocation.BackColor = Color.FromArgb(14, 20, 16);
            txtLocation.BorderStyle = BorderStyle.FixedSingle;
            txtLocation.Font = new Font("Segoe UI", 9.5F);
            txtLocation.ForeColor = Color.White;
            txtLocation.Location = new Point(20, 192);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "e.g., UE Manila Library 3rd Flr Study Hub, Tan Yan Kee Bldg...";
            txtLocation.Size = new Size(430, 24);
            txtLocation.TabIndex = 6;

            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvailability.ForeColor = Color.White;
            lblAvailability.Location = new Point(18, 226);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(265, 15);
            lblAvailability.TabIndex = 7;
            lblAvailability.Text = "General Availability / Preferred Schedule:";

            // 
            // txtAvailability
            // 
            txtAvailability.BackColor = Color.FromArgb(14, 20, 16);
            txtAvailability.BorderStyle = BorderStyle.FixedSingle;
            txtAvailability.Font = new Font("Segoe UI", 9.5F);
            txtAvailability.ForeColor = Color.White;
            txtAvailability.Location = new Point(20, 246);
            txtAvailability.Name = "txtAvailability";
            txtAvailability.PlaceholderText = "e.g., Tuesdays & Thursdays after 3:00 PM, Weekends online...";
            txtAvailability.Size = new Size(430, 24);
            txtAvailability.TabIndex = 8;

            // 
            // pnlTip
            // 
            pnlTip.BackColor = Color.FromArgb(16, 23, 19);
            pnlTip.Controls.Add(lblTipText);
            pnlTip.Location = new Point(20, 300);
            pnlTip.Name = "pnlTip";
            pnlTip.Size = new Size(430, 170);
            pnlTip.TabIndex = 9;
            pnlTip.Paint += RoundPanel_Paint;

            // 
            // lblTipText
            // 
            lblTipText.Dock = DockStyle.Fill;
            lblTipText.Font = new Font("Segoe UI", 9.2F);
            lblTipText.ForeColor = Color.FromArgb(180, 215, 195);
            lblTipText.Location = new Point(0, 0);
            lblTipText.Name = "lblTipText";
            lblTipText.Padding = new Padding(16, 14, 16, 14);
            lblTipText.Size = new Size(430, 170);
            lblTipText.TabIndex = 0;
            lblTipText.Text = "🤝 How Co-Lab Works:\r\n\r\n1. Your listing appears on the student Skill Exchange catalog.\r\n2. Interested peers will propose trades from what they offer.\r\n3. You review proposals under 'Incoming Requests' and accept barter partners.\r\n4. Coordinate learning sessions safely via campus hubs or online!";

            // 
            // pnlActionBar
            // 
            pnlActionBar.BackColor = Color.FromArgb(20, 28, 23);
            pnlActionBar.Controls.Add(lblStatusMessage);
            pnlActionBar.Controls.Add(btnPostSkill);
            pnlActionBar.Controls.Add(btnClear);
            pnlActionBar.Location = new Point(25, 680);
            pnlActionBar.Name = "pnlActionBar";
            pnlActionBar.Size = new Size(960, 58);
            pnlActionBar.TabIndex = 4;
            pnlActionBar.Paint += RoundPanel_Paint;

            // 
            // lblStatusMessage
            // 
            lblStatusMessage.AutoSize = true;
            lblStatusMessage.Font = new Font("Segoe UI", 9F);
            lblStatusMessage.ForeColor = Color.FromArgb(130, 175, 145);
            lblStatusMessage.Location = new Point(18, 22);
            lblStatusMessage.Name = "lblStatusMessage";
            lblStatusMessage.Size = new Size(295, 15);
            lblStatusMessage.TabIndex = 0;
            lblStatusMessage.Text = "Please fill in all required fields marked with an asterisk (*)";

            // 
            // btnPostSkill
            // 
            btnPostSkill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPostSkill.BackColor = Color.FromArgb(46, 125, 70);
            btnPostSkill.Cursor = Cursors.Hand;
            btnPostSkill.FlatAppearance.BorderSize = 0;
            btnPostSkill.FlatStyle = FlatStyle.Flat;
            btnPostSkill.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnPostSkill.ForeColor = Color.White;
            btnPostSkill.Location = new Point(765, 11);
            btnPostSkill.Name = "btnPostSkill";
            btnPostSkill.Size = new Size(180, 36);
            btnPostSkill.TabIndex = 2;
            btnPostSkill.Text = "🚀 Post Skill Listing";
            btnPostSkill.UseVisualStyleBackColor = false;
            btnPostSkill.Click += btnPostSkill_Click;

            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(28, 38, 30);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnClear.FlatAppearance.BorderSize = 1;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 9F);
            btnClear.ForeColor = Color.FromArgb(220, 235, 225);
            btnClear.Location = new Point(650, 11);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 36);
            btnClear.TabIndex = 1;
            btnClear.Text = "↺ Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;

            // 
            // uc_PostSkill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(960, 760);
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlActionBar);
            Controls.Add(pnlExchangeDetails);
            Controls.Add(pnlOfferDetails);
            Controls.Add(pnlPolicyNotice);
            Controls.Add(pnlHeaderCard);
            Name = "uc_PostSkill";
            Size = new Size(1010, 760);
            Load += uc_PostSkill_Load;
            Resize += uc_PostSkill_Resize;

            pnlHeaderCard.ResumeLayout(false);
            pnlHeaderCard.PerformLayout();
            pnlUserBadge.ResumeLayout(false);
            pnlUserBadge.PerformLayout();
            pnlPolicyNotice.ResumeLayout(false);
            pnlPolicyNotice.PerformLayout();
            pnlOfferDetails.ResumeLayout(false);
            pnlOfferDetails.PerformLayout();
            pnlExchangeDetails.ResumeLayout(false);
            pnlExchangeDetails.PerformLayout();
            pnlDeliveryMode.ResumeLayout(false);
            pnlDeliveryMode.PerformLayout();
            pnlTip.ResumeLayout(false);
            pnlActionBar.ResumeLayout(false);
            pnlActionBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeaderCard;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlUserBadge;
        private Label lblUserIcon;
        private Label lblUserName;
        private Label lblUserRole;

        private Panel pnlPolicyNotice;
        private Label lblPolicyIcon;
        private Label lblPolicyText;

        private Panel pnlOfferDetails;
        private Label lblSection1Title;
        private Label lblSkillTitle;
        private TextBox txtSkillTitle;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblProficiency;
        private ComboBox cmbProficiency;
        private Label lblDescription;
        private TextBox txtDescription;

        private Panel pnlExchangeDetails;
        private Label lblSection2Title;
        private Label lblDesiredSkill;
        private TextBox txtDesiredSkill;
        private Label lblDeliveryMode;
        private Panel pnlDeliveryMode;
        private RadioButton rbOnline;
        private RadioButton rbFaceToFace;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblAvailability;
        private TextBox txtAvailability;
        private Panel pnlTip;
        private Label lblTipText;

        private Panel pnlActionBar;
        private Label lblStatusMessage;
        private Button btnPostSkill;
        private Button btnClear;
    }
}
