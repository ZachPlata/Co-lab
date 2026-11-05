namespace Co_LAB
{
    partial class uc_SkillCategories
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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyleAlt = new DataGridViewCellStyle();

            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlAdminBadge = new Panel();
            lblDot = new Label();
            lblAdminText = new Label();

            pnlCategoryDetails = new Panel();
            lblCategoryDetailsTitle = new Label();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAddCategory = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClearSelection = new Button();

            pnlExistingCategories = new Panel();
            lblExistingTitle = new Label();
            txtSearch = new TextBox();
            dgvCategories = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewTextBoxColumn();
            lblHint = new Label();
            lblTotalTagged = new Label();

            pnlAdminBadge.SuspendLayout();
            pnlCategoryDetails.SuspendLayout();
            pnlExistingCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(346, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Skill Categories Management";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 48);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(365, 15);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Manage and organize skill categories available across the exchange platform";

            // 
            // pnlAdminBadge
            // 
            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(20, 28, 23);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminText);
            pnlAdminBadge.Location = new Point(730, 18);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(196, 36);
            pnlAdminBadge.TabIndex = 2;
            pnlAdminBadge.Paint += RoundPanel_Paint;

            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDot.ForeColor = Color.FromArgb(34, 197, 94);
            lblDot.Location = new Point(14, 7);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(16, 20);
            lblDot.TabIndex = 0;
            lblDot.Text = "●";

            // 
            // lblAdminText
            // 
            lblAdminText.AutoSize = true;
            lblAdminText.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAdminText.ForeColor = Color.White;
            lblAdminText.Location = new Point(34, 10);
            lblAdminText.Name = "lblAdminText";
            lblAdminText.Size = new Size(147, 15);
            lblAdminText.TabIndex = 1;
            lblAdminText.Text = "Logged In: Admin System";

            // 
            // pnlCategoryDetails (Left Panel: Category Details)
            // 
            pnlCategoryDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlCategoryDetails.BackColor = Color.FromArgb(20, 28, 23);
            pnlCategoryDetails.Controls.Add(btnClearSelection);
            pnlCategoryDetails.Controls.Add(btnDelete);
            pnlCategoryDetails.Controls.Add(btnUpdate);
            pnlCategoryDetails.Controls.Add(btnAddCategory);
            pnlCategoryDetails.Controls.Add(txtDescription);
            pnlCategoryDetails.Controls.Add(lblDescription);
            pnlCategoryDetails.Controls.Add(txtCategoryName);
            pnlCategoryDetails.Controls.Add(lblCategoryName);
            pnlCategoryDetails.Controls.Add(lblCategoryDetailsTitle);
            pnlCategoryDetails.Location = new Point(24, 78);
            pnlCategoryDetails.Name = "pnlCategoryDetails";
            pnlCategoryDetails.Size = new Size(330, 622);
            pnlCategoryDetails.TabIndex = 3;
            pnlCategoryDetails.Paint += RoundPanel_Paint;

            // 
            // lblCategoryDetailsTitle
            // 
            lblCategoryDetailsTitle.AutoSize = true;
            lblCategoryDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategoryDetailsTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblCategoryDetailsTitle.Location = new Point(20, 20);
            lblCategoryDetailsTitle.Name = "lblCategoryDetailsTitle";
            lblCategoryDetailsTitle.Size = new Size(135, 21);
            lblCategoryDetailsTitle.TabIndex = 0;
            lblCategoryDetailsTitle.Text = "Category Details";

            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCategoryName.ForeColor = Color.FromArgb(228, 228, 231);
            lblCategoryName.Location = new Point(20, 62);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(91, 15);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Category Name";

            // 
            // txtCategoryName
            // 
            txtCategoryName.BackColor = Color.FromArgb(14, 20, 16);
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.ForeColor = Color.White;
            txtCategoryName.Location = new Point(20, 84);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "e.g. Graphic & Motion Design";
            txtCategoryName.Size = new Size(290, 25);
            txtCategoryName.TabIndex = 2;

            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(228, 228, 231);
            lblDescription.Location = new Point(20, 128);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(68, 15);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";

            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(14, 20, 16);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(20, 150);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Brief summary of skills belonging to this category...";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(290, 140);
            txtDescription.TabIndex = 4;

            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.FromArgb(46, 125, 70);
            btnAddCategory.Cursor = Cursors.Hand;
            btnAddCategory.FlatAppearance.BorderSize = 0;
            btnAddCategory.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 150, 86);
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnAddCategory.ForeColor = Color.White;
            btnAddCategory.Location = new Point(20, 310);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(290, 40);
            btnAddCategory.TabIndex = 5;
            btnAddCategory.Text = "+ Add Category";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;

            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(28, 38, 30);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnUpdate.FlatAppearance.BorderSize = 1;
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 65, 48);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI Semibold", 9F);
            btnUpdate.ForeColor = Color.FromArgb(161, 161, 170);
            btnUpdate.Location = new Point(20, 362);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(138, 36);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "✏ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;

            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(28, 38, 30);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnDelete.FlatAppearance.BorderSize = 1;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 32, 35);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9F);
            btnDelete.ForeColor = Color.FromArgb(161, 161, 170);
            btnDelete.Location = new Point(172, 362);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 36);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "🗑 Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // 
            // btnClearSelection
            // 
            btnClearSelection.BackColor = Color.FromArgb(18, 25, 20);
            btnClearSelection.Cursor = Cursors.Hand;
            btnClearSelection.FlatAppearance.BorderColor = Color.FromArgb(36, 52, 40);
            btnClearSelection.FlatAppearance.BorderSize = 1;
            btnClearSelection.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 38, 30);
            btnClearSelection.FlatStyle = FlatStyle.Flat;
            btnClearSelection.Font = new Font("Segoe UI Semibold", 8.5F);
            btnClearSelection.ForeColor = Color.FromArgb(180, 195, 185);
            btnClearSelection.Location = new Point(20, 410);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(290, 34);
            btnClearSelection.TabIndex = 8;
            btnClearSelection.Text = "↺ Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = false;
            btnClearSelection.Click += btnClearSelection_Click;

            // 
            // pnlExistingCategories (Right Panel: Existing Categories)
            // 
            pnlExistingCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlExistingCategories.BackColor = Color.FromArgb(20, 28, 23);
            pnlExistingCategories.Controls.Add(lblTotalTagged);
            pnlExistingCategories.Controls.Add(lblHint);
            pnlExistingCategories.Controls.Add(dgvCategories);
            pnlExistingCategories.Controls.Add(txtSearch);
            pnlExistingCategories.Controls.Add(lblExistingTitle);
            pnlExistingCategories.Location = new Point(372, 78);
            pnlExistingCategories.Name = "pnlExistingCategories";
            pnlExistingCategories.Size = new Size(554, 622);
            pnlExistingCategories.TabIndex = 4;
            pnlExistingCategories.Paint += RoundPanel_Paint;

            // 
            // lblExistingTitle
            // 
            lblExistingTitle.AutoSize = true;
            lblExistingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblExistingTitle.ForeColor = Color.White;
            lblExistingTitle.Location = new Point(20, 20);
            lblExistingTitle.Name = "lblExistingTitle";
            lblExistingTitle.Size = new Size(183, 21);
            lblExistingTitle.TabIndex = 0;
            lblExistingTitle.Text = "Existing Categories (0)";

            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(314, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search categories...";
            txtSearch.Size = new Size(220, 24);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AllowUserToResizeRows = false;
            dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategories.BackgroundColor = Color.FromArgb(14, 20, 16);
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.Padding = new Padding(6, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.WrapMode = DataGridViewTriState.False;
            dgvCategories.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvCategories.ColumnHeadersHeight = 36;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDesc, colActions });

            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.FromArgb(18, 25, 20);
            dgvRowStyle.Font = new Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle.Padding = new Padding(6, 0, 0, 0);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyle.SelectionForeColor = Color.White;
            dgvRowStyle.WrapMode = DataGridViewTriState.False;
            dgvCategories.DefaultCellStyle = dgvRowStyle;

            dgvRowStyleAlt.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyleAlt.BackColor = Color.FromArgb(15, 22, 17);
            dgvRowStyleAlt.Font = new Font("Segoe UI", 9F);
            dgvRowStyleAlt.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyleAlt.Padding = new Padding(6, 0, 0, 0);
            dgvRowStyleAlt.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyleAlt.SelectionForeColor = Color.White;
            dgvRowStyleAlt.WrapMode = DataGridViewTriState.False;
            dgvCategories.AlternatingRowsDefaultCellStyle = dgvRowStyleAlt;

            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.GridColor = Color.FromArgb(30, 44, 34);
            dgvCategories.Location = new Point(20, 56);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.RowTemplate.Height = 40;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(514, 522);
            dgvCategories.TabIndex = 2;
            dgvCategories.CellClick += dgvCategories_CellClick;
            dgvCategories.CellFormatting += dgvCategories_CellFormatting;
            dgvCategories.CellMouseEnter += dgvCategories_CellMouseEnter;
            dgvCategories.SelectionChanged += dgvCategories_SelectionChanged;

            // 
            // colId
            // 
            colId.DataPropertyName = "CategoryId";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 45;

            // 
            // colName
            // 
            colName.DataPropertyName = "CategoryName";
            colName.HeaderText = "Category Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 145;

            // 
            // colDesc
            // 
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.DataPropertyName = "Description";
            colDesc.HeaderText = "Description";
            colDesc.Name = "colDesc";
            colDesc.ReadOnly = true;

            // 
            // colActions
            // 
            colActions.HeaderText = "Actions";
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.Width = 65;

            // 
            // lblHint
            // 
            lblHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI Italic", 8.25F);
            lblHint.ForeColor = Color.FromArgb(120, 155, 130);
            lblHint.Location = new Point(20, 592);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(169, 13);
            lblHint.TabIndex = 3;
            lblHint.Text = "Click any row to populate edit form";

            // 
            // lblTotalTagged
            // 
            lblTotalTagged.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalTagged.Font = new Font("Segoe UI", 8.25F);
            lblTotalTagged.ForeColor = Color.FromArgb(120, 155, 130);
            lblTotalTagged.Location = new Point(314, 592);
            lblTotalTagged.Name = "lblTotalTagged";
            lblTotalTagged.Size = new Size(220, 18);
            lblTotalTagged.TabIndex = 4;
            lblTotalTagged.Text = "Total Listings Tagged: 0";
            lblTotalTagged.TextAlign = ContentAlignment.MiddleRight;

            // 
            // uc_SkillCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlExistingCategories);
            Controls.Add(pnlCategoryDetails);
            Controls.Add(pnlAdminBadge);
            Controls.Add(lblHeaderSubtitle);
            Controls.Add(lblHeaderTitle);
            Name = "uc_SkillCategories";
            Size = new Size(950, 720);
            Load += uc_SkillCategories_Load;

            pnlAdminBadge.ResumeLayout(false);
            pnlAdminBadge.PerformLayout();
            pnlCategoryDetails.ResumeLayout(false);
            pnlCategoryDetails.PerformLayout();
            pnlExistingCategories.ResumeLayout(false);
            pnlExistingCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlAdminBadge;
        private Label lblDot;
        private Label lblAdminText;

        private Panel pnlCategoryDetails;
        private Label lblCategoryDetailsTitle;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnAddCategory;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClearSelection;

        private Panel pnlExistingCategories;
        private Label lblExistingTitle;
        private TextBox txtSearch;
        private DataGridView dgvCategories;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colActions;
        private Label lblHint;
        private Label lblTotalTagged;
    }
}
