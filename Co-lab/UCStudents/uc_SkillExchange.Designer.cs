namespace Co_LAB
{
    partial class uc_SkillExchange
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
            txtSearch = new TextBox();
            lblSearch = new Label();
            flpMarketplace = new FlowLayoutPanel();
            pnlFilterBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilterBar
            // 
            pnlFilterBar.BackColor = Color.FromArgb(20, 28, 23);
            pnlFilterBar.Controls.Add(lblListingCount);
            pnlFilterBar.Controls.Add(btnReset);
            pnlFilterBar.Controls.Add(btnSearch);
            pnlFilterBar.Controls.Add(cmbCategory);
            pnlFilterBar.Controls.Add(lblCategory);
            pnlFilterBar.Controls.Add(txtSearch);
            pnlFilterBar.Controls.Add(lblSearch);
            pnlFilterBar.Dock = DockStyle.Top;
            pnlFilterBar.Location = new Point(0, 0);
            pnlFilterBar.Name = "pnlFilterBar";
            pnlFilterBar.Padding = new Padding(20, 15, 20, 15);
            pnlFilterBar.Size = new Size(950, 68);
            pnlFilterBar.TabIndex = 0;
            // 
            // lblListingCount
            // 
            lblListingCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblListingCount.AutoSize = true;
            lblListingCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblListingCount.ForeColor = Color.FromArgb(130, 175, 145);
            lblListingCount.Location = new Point(810, 26);
            lblListingCount.Name = "lblListingCount";
            lblListingCount.Size = new Size(93, 15);
            lblListingCount.TabIndex = 6;
            lblListingCount.Text = "0 skills available";
            lblListingCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(28, 38, 30);
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnReset.FlatAppearance.BorderSize = 1;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI Semibold", 9F);
            btnReset.ForeColor = Color.FromArgb(220, 235, 225);
            btnReset.Location = new Point(660, 20);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 29);
            btnReset.TabIndex = 5;
            btnReset.Text = "↺ Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(46, 125, 70);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(570, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(14, 20, 16);
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Segoe UI", 9.5F);
            cmbCategory.ForeColor = Color.White;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(390, 21);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(165, 25);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCategory.ForeColor = Color.FromArgb(130, 175, 145);
            lblCategory.Location = new Point(325, 25);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(60, 15);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(78, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by skill title, description...";
            txtSearch.Size = new Size(230, 24);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(130, 175, 145);
            lblSearch.Location = new Point(22, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(48, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // flpMarketplace
            // 
            flpMarketplace.AutoScroll = true;
            flpMarketplace.BackColor = Color.FromArgb(14, 20, 16);
            flpMarketplace.Dock = DockStyle.Fill;
            flpMarketplace.Location = new Point(0, 68);
            flpMarketplace.Name = "flpMarketplace";
            flpMarketplace.Padding = new Padding(20);
            flpMarketplace.Size = new Size(950, 564);
            flpMarketplace.TabIndex = 1;
            flpMarketplace.Paint += flpMarketplace_Paint;
            // 
            // uc_SkillExchange
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(flpMarketplace);
            Controls.Add(pnlFilterBar);
            Name = "uc_SkillExchange";
            Size = new Size(950, 632);
            Load += uc_SkillExchange_Load;
            pnlFilterBar.ResumeLayout(false);
            pnlFilterBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilterBar;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Button btnSearch;
        private Button btnReset;
        private Label lblListingCount;
        private FlowLayoutPanel flpMarketplace;
    }
}
