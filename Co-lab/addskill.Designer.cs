namespace Co_LAB
{
    partial class uc_addskill
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
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblSkillOffer = new Label();
            txtSkillOffer = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            pnlSeparator = new Panel();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(99, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add Skill";

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(209, 250, 229);
            lblSubtitle.Location = new Point(26, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(346, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Select a skill category and enter the skill you can offer to students.";

            // 
            // pnlSeparator
            // 
            pnlSeparator.BackColor = Color.FromArgb(4, 120, 87);
            pnlSeparator.Location = new Point(26, 72);
            pnlSeparator.Name = "pnlSeparator";
            pnlSeparator.Size = new Size(410, 2);
            pnlSeparator.TabIndex = 2;

            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategory.ForeColor = Color.White;
            lblCategory.Location = new Point(24, 88);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(98, 17);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Skill Category:";

            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(24, 24, 27);
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
            cmbCategory.Location = new Point(26, 110);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(410, 25);
            cmbCategory.TabIndex = 4;

            // 
            // lblSkillOffer
            // 
            lblSkillOffer.AutoSize = true;
            lblSkillOffer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSkillOffer.ForeColor = Color.White;
            lblSkillOffer.Location = new Point(24, 150);
            lblSkillOffer.Name = "lblSkillOffer";
            lblSkillOffer.Size = new Size(130, 17);
            lblSkillOffer.TabIndex = 5;
            lblSkillOffer.Text = "Skill you can offer:";

            // 
            // txtSkillOffer
            // 
            txtSkillOffer.BackColor = Color.FromArgb(24, 24, 27);
            txtSkillOffer.BorderStyle = BorderStyle.FixedSingle;
            txtSkillOffer.Font = new Font("Segoe UI", 10F);
            txtSkillOffer.ForeColor = Color.White;
            txtSkillOffer.Location = new Point(26, 172);
            txtSkillOffer.Name = "txtSkillOffer";
            txtSkillOffer.PlaceholderText = "e.g., C# Programming, Figma UI Design, Calculus Tutoring...";
            txtSkillOffer.Size = new Size(410, 25);
            txtSkillOffer.TabIndex = 6;
            txtSkillOffer.KeyDown += txtSkillOffer_KeyDown;

            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(216, 225);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 36);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "+ Add Skill";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(185, 28, 28);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(334, 225);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 36);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // 
            // uc_addskill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 95, 70);
            Controls.Add(pnlSeparator);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(txtSkillOffer);
            Controls.Add(lblSkillOffer);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Name = "uc_addskill";
            Padding = new Padding(20);
            Size = new Size(465, 285);
            Load += uc_addskill_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlSeparator;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblSkillOffer;
        private TextBox txtSkillOffer;
        private Button btnAdd;
        private Button btnCancel;
    }
}
