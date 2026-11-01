namespace Co_LAB
{
    partial class Propose_skill_exchange
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
            lblHeaderTitle = new Label();
            lblTargetSkillTitle = new Label();
            lblTheyOffer = new Label();
            lblTheyNeed = new Label();
            pnlProfileCard = new Panel();
            lblRating = new Label();
            lblUserDept = new Label();
            lblUserName = new Label();
            pnlAvatar = new Panel();
            lblReturnSkill = new Label();
            cmbReturnSkill = new ComboBox();
            lblTradeMode = new Label();
            pnlTradeMode = new Panel();
            rbOnline = new RadioButton();
            rbFaceToFace = new RadioButton();
            lblLocation = new Label();
            txtLocation = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnSendRequest = new Button();
            btnCancel = new Button();
            pnlProfileCard.SuspendLayout();
            pnlTradeMode.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(251, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Propose Skill Exchange";
            // 
            // lblTargetSkillTitle
            // 
            lblTargetSkillTitle.AutoSize = true;
            lblTargetSkillTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTargetSkillTitle.ForeColor = Color.White;
            lblTargetSkillTitle.Location = new Point(20, 52);
            lblTargetSkillTitle.Name = "lblTargetSkillTitle";
            lblTargetSkillTitle.Size = new Size(88, 19);
            lblTargetSkillTitle.TabIndex = 1;
            lblTargetSkillTitle.Text = "Target Skill:";
            // 
            // lblTheyOffer
            // 
            lblTheyOffer.AutoSize = true;
            lblTheyOffer.Font = new Font("Segoe UI", 9F);
            lblTheyOffer.ForeColor = Color.FromArgb(200, 220, 210);
            lblTheyOffer.Location = new Point(116, 54);
            lblTheyOffer.Name = "lblTheyOffer";
            lblTheyOffer.Size = new Size(234, 15);
            lblTheyOffer.TabIndex = 2;
            lblTheyOffer.Text = "They Offer: C# WinForms  MySQL Tutoring";
            // 
            // lblTheyNeed
            // 
            lblTheyNeed.AutoSize = true;
            lblTheyNeed.Font = new Font("Segoe UI", 9F);
            lblTheyNeed.ForeColor = Color.FromArgb(200, 220, 210);
            lblTheyNeed.Location = new Point(116, 72);
            lblTheyNeed.Name = "lblTheyNeed";
            lblTheyNeed.Size = new Size(243, 15);
            lblTheyNeed.TabIndex = 3;
            lblTheyNeed.Text = "They Need: Figma UI Design or Video Editing";
            // 
            // pnlProfileCard
            // 
            pnlProfileCard.BackColor = Color.FromArgb(12, 26, 18);
            pnlProfileCard.Controls.Add(lblRating);
            pnlProfileCard.Controls.Add(lblUserDept);
            pnlProfileCard.Controls.Add(lblUserName);
            pnlProfileCard.Controls.Add(pnlAvatar);
            pnlProfileCard.Location = new Point(20, 98);
            pnlProfileCard.Name = "pnlProfileCard";
            pnlProfileCard.Size = new Size(430, 58);
            pnlProfileCard.TabIndex = 4;
            pnlProfileCard.Paint += pnlProfileCard_Paint;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRating.ForeColor = Color.FromArgb(250, 204, 21);
            lblRating.Location = new Point(345, 17);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(49, 20);
            lblRating.TabIndex = 3;
            lblRating.Text = "★ 5.0";
            // 
            // lblUserDept
            // 
            lblUserDept.AutoSize = true;
            lblUserDept.Font = new Font("Segoe UI", 8.25F);
            lblUserDept.ForeColor = Color.FromArgb(160, 180, 170);
            lblUserDept.Location = new Point(58, 30);
            lblUserDept.Name = "lblUserDept";
            lblUserDept.Size = new Size(256, 13);
            lblUserDept.TabIndex = 2;
            lblUserDept.Text = "College of Computer Studies and Systems (CCSS)";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(58, 9);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(114, 20);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Samantha Cruz";
            // 
            // pnlAvatar
            // 
            pnlAvatar.BackColor = Color.Transparent;
            pnlAvatar.Location = new Point(10, 9);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(40, 40);
            pnlAvatar.TabIndex = 0;
            pnlAvatar.Paint += pnlAvatar_Paint;
            // 
            // lblReturnSkill
            // 
            lblReturnSkill.AutoSize = true;
            lblReturnSkill.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReturnSkill.ForeColor = Color.White;
            lblReturnSkill.Location = new Point(20, 168);
            lblReturnSkill.Name = "lblReturnSkill";
            lblReturnSkill.Size = new Size(291, 15);
            lblReturnSkill.TabIndex = 5;
            lblReturnSkill.Text = "What skill will you give in return? (Strictly No Cash):";
            // 
            // cmbReturnSkill
            // 
            cmbReturnSkill.Font = new Font("Segoe UI", 9F);
            cmbReturnSkill.ForeColor = Color.FromArgb(80, 80, 80);
            cmbReturnSkill.FormattingEnabled = true;
            cmbReturnSkill.Items.AddRange(new object[] { "Select or type skill to offer in return..." });
            cmbReturnSkill.Location = new Point(20, 190);
            cmbReturnSkill.Name = "cmbReturnSkill";
            cmbReturnSkill.Size = new Size(430, 23);
            cmbReturnSkill.TabIndex = 6;
            // 
            // lblTradeMode
            // 
            lblTradeMode.AutoSize = true;
            lblTradeMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTradeMode.ForeColor = Color.White;
            lblTradeMode.Location = new Point(20, 224);
            lblTradeMode.Name = "lblTradeMode";
            lblTradeMode.Size = new Size(183, 15);
            lblTradeMode.TabIndex = 7;
            lblTradeMode.Text = "Exchange Format / Trade Mode:";
            // 
            // pnlTradeMode
            // 
            pnlTradeMode.BackColor = Color.White;
            pnlTradeMode.Controls.Add(rbOnline);
            pnlTradeMode.Controls.Add(rbFaceToFace);
            pnlTradeMode.Location = new Point(20, 246);
            pnlTradeMode.Name = "pnlTradeMode";
            pnlTradeMode.Size = new Size(430, 28);
            pnlTradeMode.TabIndex = 8;
            // 
            // rbOnline
            // 
            rbOnline.AutoSize = true;
            rbOnline.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbOnline.ForeColor = Color.Black;
            rbOnline.Location = new Point(230, 4);
            rbOnline.Name = "rbOnline";
            rbOnline.Size = new Size(105, 19);
            rbOnline.TabIndex = 1;
            rbOnline.TabStop = true;
            rbOnline.Text = "Online Session";
            rbOnline.UseVisualStyleBackColor = true;
            // 
            // rbFaceToFace
            // 
            rbFaceToFace.AutoSize = true;
            rbFaceToFace.Checked = true;
            rbFaceToFace.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            rbFaceToFace.ForeColor = Color.Black;
            rbFaceToFace.Location = new Point(15, 4);
            rbFaceToFace.Name = "rbFaceToFace";
            rbFaceToFace.Size = new Size(151, 19);
            rbFaceToFace.TabIndex = 0;
            rbFaceToFace.TabStop = true;
            rbFaceToFace.Text = "Face-to-Face (Campus)";
            rbFaceToFace.UseVisualStyleBackColor = true;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocation.ForeColor = Color.White;
            lblLocation.Location = new Point(20, 284);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(352, 15);
            lblLocation.TabIndex = 9;
            lblLocation.Text = "Required Campus Meetup Location (e.g., UE Library 2nd Floor):";
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("Segoe UI", 9F);
            txtLocation.ForeColor = Color.FromArgb(115, 115, 115);
            txtLocation.Location = new Point(20, 306);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(430, 23);
            txtLocation.TabIndex = 10;
            txtLocation.Text = "e.g., UE Manila Library 3rd Floor Study Hub, Tan Yan Kee Bldg";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.ForeColor = Color.White;
            lblNotes.Location = new Point(20, 340);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(43, 15);
            lblNotes.TabIndex = 11;
            lblNotes.Text = "Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.ForeColor = Color.Black;
            txtNotes.Location = new Point(20, 362);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(430, 110);
            txtNotes.TabIndex = 12;
            // 
            // btnSendRequest
            // 
            btnSendRequest.BackColor = Color.FromArgb(85, 138, 110);
            btnSendRequest.Cursor = Cursors.Hand;
            btnSendRequest.FlatAppearance.BorderSize = 0;
            btnSendRequest.FlatStyle = FlatStyle.Flat;
            btnSendRequest.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSendRequest.ForeColor = Color.White;
            btnSendRequest.Location = new Point(232, 488);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.Size = new Size(120, 32);
            btnSendRequest.TabIndex = 13;
            btnSendRequest.Text = "Send Request";
            btnSendRequest.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(185, 45, 45);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(360, 488);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 32);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // Propose_skill_exchange
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(btnCancel);
            Controls.Add(btnSendRequest);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtLocation);
            Controls.Add(lblLocation);
            Controls.Add(pnlTradeMode);
            Controls.Add(lblTradeMode);
            Controls.Add(cmbReturnSkill);
            Controls.Add(lblReturnSkill);
            Controls.Add(pnlProfileCard);
            Controls.Add(lblTheyNeed);
            Controls.Add(lblTheyOffer);
            Controls.Add(lblTargetSkillTitle);
            Controls.Add(lblHeaderTitle);
            Name = "Propose_skill_exchange";
            Size = new Size(470, 545);
            pnlProfileCard.ResumeLayout(false);
            pnlProfileCard.PerformLayout();
            pnlTradeMode.ResumeLayout(false);
            pnlTradeMode.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeaderTitle;
        private Label lblTargetSkillTitle;
        private Label lblTheyOffer;
        private Label lblTheyNeed;
        private Panel pnlProfileCard;
        private Panel pnlAvatar;
        private Label lblUserName;
        private Label lblUserDept;
        private Label lblRating;
        private Label lblReturnSkill;
        private ComboBox cmbReturnSkill;
        private Label lblTradeMode;
        private Panel pnlTradeMode;
        private RadioButton rbFaceToFace;
        private RadioButton rbOnline;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnSendRequest;
        private Button btnCancel;
    }
}
