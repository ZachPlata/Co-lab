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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlAdminBadge = new Panel();
            lblDot = new Label();
            lblAdminText = new Label();
            pnlCategoryDetails = new Panel();
            btnClearSelection = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAddCategory = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtCategoryName = new TextBox();
            lblCategoryName = new Label();
            lblCategoryDetailsTitle = new Label();
            pnlExistingCategories = new Panel();
            lblTotalTagged = new Label();
            lblHint = new Label();
            dgvCategories = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            lblExistingTitle = new Label();
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
            lblHeaderTitle.Location = new Point(24, 18);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(394, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Skill Categories Management";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 54);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(473, 19);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Manage and organize skill categories available across the exchange platform";
            // 
            // pnlAdminBadge
            // 
            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(20, 28, 23);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminText);
            pnlAdminBadge.Location = new Point(702, 20);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(224, 41);
            pnlAdminBadge.TabIndex = 2;
            pnlAdminBadge.Paint += RoundPanel_Paint;
            // 
            // lblDot
            // 
            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDot.ForeColor = Color.FromArgb(34, 197, 94);
            lblDot.Location = new Point(14, 9);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(20, 23);
            lblDot.TabIndex = 0;
            lblDot.Text = "●";
            // 
            // lblAdminText
            // 
            lblAdminText.AutoSize = true;
            lblAdminText.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAdminText.ForeColor = Color.White;
            lblAdminText.Location = new Point(36, 12);
            lblAdminText.Name = "lblAdminText";
            lblAdminText.Size = new Size(168, 19);
            lblAdminText.TabIndex = 1;
            lblAdminText.Text = "Logged In: Admin System";
            // 
            // pnlCategoryDetails
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
            pnlCategoryDetails.Location = new Point(24, 88);
            pnlCategoryDetails.Name = "pnlCategoryDetails";
            pnlCategoryDetails.Size = new Size(330, 705);
            pnlCategoryDetails.TabIndex = 3;
            pnlCategoryDetails.Paint += RoundPanel_Paint;
            // 
            // btnClearSelection
            // 
            btnClearSelection.BackColor = Color.FromArgb(18, 25, 20);
            btnClearSelection.Cursor = Cursors.Hand;
            btnClearSelection.FlatAppearance.BorderColor = Color.FromArgb(36, 52, 40);
            btnClearSelection.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 38, 30);
            btnClearSelection.FlatStyle = FlatStyle.Flat;
            btnClearSelection.Font = new Font("Segoe UI Semibold", 8.5F);
            btnClearSelection.ForeColor = Color.FromArgb(180, 195, 185);
            btnClearSelection.Location = new Point(20, 465);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(290, 39);
            btnClearSelection.TabIndex = 8;
            btnClearSelection.Text = "↺ Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = false;
            btnClearSelection.Click += btnClearSelection_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(28, 38, 30);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 32, 35);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9F);
            btnDelete.ForeColor = Color.FromArgb(161, 161, 170);
            btnDelete.Location = new Point(172, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 41);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "🗑 Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(28, 38, 30);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 65, 48);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI Semibold", 9F);
            btnUpdate.ForeColor = Color.FromArgb(161, 161, 170);
            btnUpdate.Location = new Point(20, 410);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(138, 41);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "✏ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
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
            btnAddCategory.Location = new Point(20, 351);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(290, 45);
            btnAddCategory.TabIndex = 5;
            btnAddCategory.Text = "+ Add Category";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(14, 20, 16);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(20, 170);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Brief summary of skills belonging to this category...";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(290, 158);
            txtDescription.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(228, 228, 231);
            lblDescription.Location = new Point(20, 145);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(81, 19);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // txtCategoryName
            // 
            txtCategoryName.BackColor = Color.FromArgb(14, 20, 16);
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.ForeColor = Color.White;
            txtCategoryName.Location = new Point(20, 95);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.PlaceholderText = "e.g. Graphic & Motion Design";
            txtCategoryName.Size = new Size(290, 27);
            txtCategoryName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCategoryName.ForeColor = Color.FromArgb(228, 228, 231);
            lblCategoryName.Location = new Point(20, 70);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(107, 19);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Category Name";
            // 
            // lblCategoryDetailsTitle
            // 
            lblCategoryDetailsTitle.AutoSize = true;
            lblCategoryDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCategoryDetailsTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblCategoryDetailsTitle.Location = new Point(20, 23);
            lblCategoryDetailsTitle.Name = "lblCategoryDetailsTitle";
            lblCategoryDetailsTitle.Size = new Size(153, 25);
            lblCategoryDetailsTitle.TabIndex = 0;
            lblCategoryDetailsTitle.Text = "Category Details";
            // 
            // pnlExistingCategories
            // 
            pnlExistingCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlExistingCategories.BackColor = Color.FromArgb(20, 28, 23);
            pnlExistingCategories.Controls.Add(lblTotalTagged);
            pnlExistingCategories.Controls.Add(lblHint);
            pnlExistingCategories.Controls.Add(dgvCategories);
            pnlExistingCategories.Controls.Add(txtSearch);
            pnlExistingCategories.Controls.Add(lblExistingTitle);
            pnlExistingCategories.Location = new Point(372, 88);
            pnlExistingCategories.Name = "pnlExistingCategories";
            pnlExistingCategories.Size = new Size(554, 705);
            pnlExistingCategories.TabIndex = 4;
            pnlExistingCategories.Paint += RoundPanel_Paint;
            // 
            // lblTotalTagged
            // 
            lblTotalTagged.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalTagged.Font = new Font("Segoe UI", 8.25F);
            lblTotalTagged.ForeColor = Color.FromArgb(120, 155, 130);
            lblTotalTagged.Location = new Point(314, 671);
            lblTotalTagged.Name = "lblTotalTagged";
            lblTotalTagged.Size = new Size(220, 20);
            lblTotalTagged.TabIndex = 4;
            lblTotalTagged.Text = "Total Listings Tagged: 0";
            lblTotalTagged.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblHint
            // 
            lblHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblHint.ForeColor = Color.FromArgb(120, 155, 130);
            lblHint.Location = new Point(20, 671);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(209, 16);
            lblHint.TabIndex = 3;
            lblHint.Text = "Click any row to populate edit form";
            // 
            // dgvCategories
            // 
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(15, 22, 17);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(228, 228, 231);
            dataGridViewCellStyle1.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCategories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategories.BackgroundColor = Color.FromArgb(14, 20, 16);
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 28, 23);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(74, 222, 128);
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCategories.ColumnHeadersHeight = 36;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDesc });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(18, 25, 20);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(228, 228, 231);
            dataGridViewCellStyle3.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCategories.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.GridColor = Color.FromArgb(30, 44, 34);
            dgvCategories.Location = new Point(20, 63);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.RowHeadersWidth = 45;
            dgvCategories.RowTemplate.Height = 40;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(514, 592);
            dgvCategories.TabIndex = 2;
            dgvCategories.CellContentClick += dgvCategories_CellContentClick;
            dgvCategories.SelectionChanged += dgvCategories_SelectionChanged;
            // 
            // colId
            // 
            colId.DataPropertyName = "CategoryId";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 45;
            // 
            // colName
            // 
            colName.DataPropertyName = "CategoryName";
            colName.HeaderText = "Category Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 145;
            // 
            // colDesc
            // 
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.DataPropertyName = "Description";
            colDesc.HeaderText = "Description";
            colDesc.MinimumWidth = 6;
            colDesc.Name = "colDesc";
            colDesc.ReadOnly = true;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(314, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search categories...";
            txtSearch.Size = new Size(220, 26);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblExistingTitle
            // 
            lblExistingTitle.AutoSize = true;
            lblExistingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblExistingTitle.ForeColor = Color.White;
            lblExistingTitle.Location = new Point(20, 23);
            lblExistingTitle.Name = "lblExistingTitle";
            lblExistingTitle.Size = new Size(203, 25);
            lblExistingTitle.TabIndex = 0;
            lblExistingTitle.Text = "Existing Categories (0)";
            // 
            // uc_SkillCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlExistingCategories);
            Controls.Add(pnlCategoryDetails);
            Controls.Add(pnlAdminBadge);
            Controls.Add(lblHeaderSubtitle);
            Controls.Add(lblHeaderTitle);
            Name = "uc_SkillCategories";
            Size = new Size(950, 816);
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
        private Label lblHint;
        private Label lblTotalTagged;
    }
}
