namespace Co_LAB.UCStudents
{
    partial class uc_RequestConfirmation
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
            TradeModeTxtBox = new TextBox();
            YourOfferTxtBox = new TextBox();
            TheyOfferTxtBox = new TextBox();
            btnCancel = new Button();
            txtNotes = new TextBox();
            lblNotes = new Label();
            lblLocation = new Label();
            lblTradeMode = new Label();
            lblReturnSkill = new Label();
            pnlProfileCard = new Panel();
            lblRating = new Label();
            lblUserDept = new Label();
            lblUserName = new Label();
            pnlAvatar = new Panel();
            lblHeaderTitle = new Label();
            btnSendRequest = new Button();
            pnlProfileCard.SuspendLayout();
            SuspendLayout();
            // 
            // TradeModeTxtBox
            // 
            TradeModeTxtBox.Location = new Point(20, 265);
            TradeModeTxtBox.Name = "TradeModeTxtBox";
            TradeModeTxtBox.Size = new Size(430, 23);
            TradeModeTxtBox.TabIndex = 43;
            // 
            // YourOfferTxtBox
            // 
            YourOfferTxtBox.Location = new Point(20, 205);
            YourOfferTxtBox.Name = "YourOfferTxtBox";
            YourOfferTxtBox.Size = new Size(430, 23);
            YourOfferTxtBox.TabIndex = 42;
            // 
            // TheyOfferTxtBox
            // 
            TheyOfferTxtBox.Location = new Point(21, 144);
            TheyOfferTxtBox.Name = "TheyOfferTxtBox";
            TheyOfferTxtBox.Size = new Size(429, 23);
            TheyOfferTxtBox.TabIndex = 41;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(185, 45, 45);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(360, 446);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 32);
            btnCancel.TabIndex = 40;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.ForeColor = Color.Black;
            txtNotes.Location = new Point(20, 320);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(430, 110);
            txtNotes.TabIndex = 39;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.ForeColor = Color.White;
            lblNotes.Location = new Point(20, 298);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(43, 15);
            lblNotes.TabIndex = 38;
            lblNotes.Text = "Notes:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocation.ForeColor = Color.White;
            lblLocation.Location = new Point(20, 242);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(183, 15);
            lblLocation.TabIndex = 37;
            lblLocation.Text = "Exchange Format / Trade Mode:";
            // 
            // lblTradeMode
            // 
            lblTradeMode.AutoSize = true;
            lblTradeMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTradeMode.ForeColor = Color.White;
            lblTradeMode.Location = new Point(20, 182);
            lblTradeMode.Name = "lblTradeMode";
            lblTradeMode.Size = new Size(78, 15);
            lblTradeMode.TabIndex = 36;
            lblTradeMode.Text = "You Offered:";
            // 
            // lblReturnSkill
            // 
            lblReturnSkill.AutoSize = true;
            lblReturnSkill.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReturnSkill.ForeColor = Color.White;
            lblReturnSkill.Location = new Point(20, 126);
            lblReturnSkill.Name = "lblReturnSkill";
            lblReturnSkill.Size = new Size(71, 15);
            lblReturnSkill.TabIndex = 35;
            lblReturnSkill.Text = "They Offer:";
            // 
            // pnlProfileCard
            // 
            pnlProfileCard.BackColor = Color.FromArgb(12, 26, 18);
            pnlProfileCard.Controls.Add(lblRating);
            pnlProfileCard.Controls.Add(lblUserDept);
            pnlProfileCard.Controls.Add(lblUserName);
            pnlProfileCard.Controls.Add(pnlAvatar);
            pnlProfileCard.Location = new Point(20, 56);
            pnlProfileCard.Name = "pnlProfileCard";
            pnlProfileCard.Size = new Size(430, 58);
            pnlProfileCard.TabIndex = 34;
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
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 23);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(258, 30);
            lblHeaderTitle.TabIndex = 33;
            lblHeaderTitle.Text = "Accept Trade Requests?";
            // 
            // btnSendRequest
            // 
            btnSendRequest.BackColor = Color.FromArgb(85, 138, 110);
            btnSendRequest.Cursor = Cursors.Hand;
            btnSendRequest.FlatAppearance.BorderSize = 0;
            btnSendRequest.FlatStyle = FlatStyle.Flat;
            btnSendRequest.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSendRequest.ForeColor = Color.White;
            btnSendRequest.Location = new Point(234, 446);
            btnSendRequest.Name = "btnSendRequest";
            btnSendRequest.Size = new Size(120, 32);
            btnSendRequest.TabIndex = 44;
            btnSendRequest.Text = "Confirm";
            btnSendRequest.UseVisualStyleBackColor = false;
            // 
            // uc_RequestConfirmation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(btnSendRequest);
            Controls.Add(TradeModeTxtBox);
            Controls.Add(YourOfferTxtBox);
            Controls.Add(TheyOfferTxtBox);
            Controls.Add(btnCancel);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(lblLocation);
            Controls.Add(lblTradeMode);
            Controls.Add(lblReturnSkill);
            Controls.Add(pnlProfileCard);
            Controls.Add(lblHeaderTitle);
            Name = "uc_RequestConfirmation";
            Size = new Size(470, 501);
            pnlProfileCard.ResumeLayout(false);
            pnlProfileCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TradeModeTxtBox;
        private TextBox YourOfferTxtBox;
        private TextBox TheyOfferTxtBox;
        private Button btnCancel;
        private TextBox txtNotes;
        private Label lblNotes;
        private Label lblLocation;
        private Label lblTradeMode;
        private Label lblReturnSkill;
        private Panel pnlProfileCard;
        private Label lblRating;
        private Label lblUserDept;
        private Label lblUserName;
        private Panel pnlAvatar;
        private Label lblHeaderTitle;
        private Button btnSendRequest;
    }
}
