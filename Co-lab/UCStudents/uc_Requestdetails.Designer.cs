namespace Co_LAB.UCStudents
{
    partial class uc_Requestdetails
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
            btnCancel = new Button();
            lblUserName = new Label();
            pnlAvatar = new Panel();
            txtNotes = new TextBox();
            lblRating = new Label();
            lblNotes = new Label();
            lblLocation = new Label();
            lblTradeMode = new Label();
            lblReturnSkill = new Label();
            pnlProfileCard = new Panel();
            lblUserDept = new Label();
            lblHeaderTitle = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            pnlProfileCard.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(28, 38, 30);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(220, 235, 225);
            btnCancel.Location = new Point(360, 439);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 32);
            btnCancel.TabIndex = 29;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = false;
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
            // txtNotes
            // 
            txtNotes.BackColor = Color.FromArgb(14, 20, 16);
            txtNotes.BorderStyle = BorderStyle.FixedSingle;
            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.ForeColor = Color.White;
            txtNotes.Location = new Point(20, 313);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(430, 110);
            txtNotes.TabIndex = 27;
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
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNotes.ForeColor = Color.White;
            lblNotes.Location = new Point(20, 291);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(43, 15);
            lblNotes.TabIndex = 26;
            lblNotes.Text = "Notes:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocation.ForeColor = Color.White;
            lblLocation.Location = new Point(20, 235);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(183, 15);
            lblLocation.TabIndex = 24;
            lblLocation.Text = "Exchange Format / Trade Mode:";
            // 
            // lblTradeMode
            // 
            lblTradeMode.AutoSize = true;
            lblTradeMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTradeMode.ForeColor = Color.White;
            lblTradeMode.Location = new Point(20, 175);
            lblTradeMode.Name = "lblTradeMode";
            lblTradeMode.Size = new Size(78, 15);
            lblTradeMode.TabIndex = 22;
            lblTradeMode.Text = "You Offered:";
            // 
            // lblReturnSkill
            // 
            lblReturnSkill.AutoSize = true;
            lblReturnSkill.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReturnSkill.ForeColor = Color.White;
            lblReturnSkill.Location = new Point(20, 119);
            lblReturnSkill.Name = "lblReturnSkill";
            lblReturnSkill.Size = new Size(71, 15);
            lblReturnSkill.TabIndex = 20;
            lblReturnSkill.Text = "They Offer:";
            // 
            // pnlProfileCard
            // 
            pnlProfileCard.BackColor = Color.FromArgb(20, 28, 23);
            pnlProfileCard.Controls.Add(lblRating);
            pnlProfileCard.Controls.Add(lblUserDept);
            pnlProfileCard.Controls.Add(lblUserName);
            pnlProfileCard.Controls.Add(pnlAvatar);
            pnlProfileCard.Location = new Point(20, 49);
            pnlProfileCard.Name = "pnlProfileCard";
            pnlProfileCard.Size = new Size(430, 58);
            pnlProfileCard.TabIndex = 19;
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
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(215, 30);
            lblHeaderTitle.TabIndex = 15;
            lblHeaderTitle.Text = "Transaction Details:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(14, 20, 16);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(21, 137);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(429, 23);
            textBox1.TabIndex = 30;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(14, 20, 16);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 9F);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(20, 198);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(430, 23);
            textBox2.TabIndex = 31;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(14, 20, 16);
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 9F);
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(20, 258);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(430, 23);
            textBox3.TabIndex = 32;
            // 
            // uc_Requestdetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnCancel);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(lblLocation);
            Controls.Add(lblTradeMode);
            Controls.Add(lblReturnSkill);
            Controls.Add(pnlProfileCard);
            Controls.Add(lblHeaderTitle);
            Name = "uc_Requestdetails";
            Size = new Size(470, 501);
            pnlProfileCard.ResumeLayout(false);
            pnlProfileCard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Label lblUserName;
        private Panel pnlAvatar;
        private TextBox txtNotes;
        private Label lblRating;
        private Label lblNotes;
        private Label lblLocation;
        private Label lblTradeMode;
        private Label lblReturnSkill;
        private Panel pnlProfileCard;
        private Label lblUserDept;
        private Label lblHeaderTitle;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
