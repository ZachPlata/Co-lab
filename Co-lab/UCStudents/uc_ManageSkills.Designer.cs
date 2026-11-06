namespace Co_LAB
{
    partial class uc_ManageSkills
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
            pnlFilterBar = new Panel();
            lblListingCount = new Label();
            btnReset = new Button();
            btnSearch = new Button();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            btn_Addskill = new Button();
            pnlFilterBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilterBar
            // 
            pnlFilterBar.BackColor = Color.FromArgb(28, 28, 33);
            pnlFilterBar.Controls.Add(btn_Addskill);
            pnlFilterBar.Controls.Add(lblListingCount);
            pnlFilterBar.Controls.Add(btnReset);
            pnlFilterBar.Controls.Add(btnSearch);
            pnlFilterBar.Controls.Add(cmbCategory);
            pnlFilterBar.Controls.Add(lblCategory);
            pnlFilterBar.Dock = DockStyle.Top;
            pnlFilterBar.Location = new Point(0, 0);
            pnlFilterBar.Name = "pnlFilterBar";
            pnlFilterBar.Padding = new Padding(20, 15, 20, 15);
            pnlFilterBar.Size = new Size(950, 68);
            pnlFilterBar.TabIndex = 1;
            // 
            // lblListingCount
            // 
            lblListingCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblListingCount.AutoSize = true;
            lblListingCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblListingCount.ForeColor = Color.FromArgb(161, 161, 170);
            lblListingCount.Location = new Point(1540, 41);
            lblListingCount.Name = "lblListingCount";
            lblListingCount.Size = new Size(93, 15);
            lblListingCount.TabIndex = 6;
            lblListingCount.Text = "0 skills available";
            lblListingCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(39, 39, 42);
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI Semibold", 9F);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(855, 20);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 29);
            btnReset.TabIndex = 5;
            btnReset.Text = "↺ Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(16, 185, 129);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(765, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(39, 39, 42);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Segoe UI", 9.5F);
            cmbCategory.ForeColor = Color.White;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(585, 21);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(165, 25);
            cmbCategory.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(161, 161, 170);
            lblCategory.Location = new Point(519, 27);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(60, 15);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // btn_Addskill
            // 
            btn_Addskill.BackColor = Color.FromArgb(16, 185, 129);
            btn_Addskill.Cursor = Cursors.Hand;
            btn_Addskill.FlatAppearance.BorderSize = 0;
            btn_Addskill.FlatStyle = FlatStyle.Flat;
            btn_Addskill.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btn_Addskill.ForeColor = Color.White;
            btn_Addskill.Location = new Point(41, 21);
            btn_Addskill.Name = "btn_Addskill";
            btn_Addskill.Size = new Size(84, 29);
            btn_Addskill.TabIndex = 7;
            btn_Addskill.Text = "✚ Add Skill";
            btn_Addskill.UseVisualStyleBackColor = false;
            // 
            // uc_ManageSkills
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(pnlFilterBar);
            Name = "uc_ManageSkills";
            Size = new Size(950, 632);
            pnlFilterBar.ResumeLayout(false);
            pnlFilterBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilterBar;
        private Button btn_Addskill;
        private Label lblListingCount;
        private Button btnReset;
        private Button btnSearch;
        private ComboBox cmbCategory;
        private Label lblCategory;
    }
}
