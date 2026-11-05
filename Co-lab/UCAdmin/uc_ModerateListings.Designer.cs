namespace Co_LAB
{
    partial class uc_ModerateListings
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
            pnlHeader = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            cmbStatusFilter = new ComboBox();
            lblFilter = new Label();
            lblStatusCount = new Label();
            pnlActions = new Panel();
            btnDelete = new Button();
            btnFlag = new Button();
            btnApprove = new Button();
            dgvListings = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvListings).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(28, 28, 33);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(btnSearch);
            pnlHeader.Controls.Add(txtSearch);
            pnlHeader.Controls.Add(cmbStatusFilter);
            pnlHeader.Controls.Add(lblFilter);
            pnlHeader.Controls.Add(lblStatusCount);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20, 15, 20, 15);
            pnlHeader.Size = new Size(950, 68);
            pnlHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(39, 39, 42);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(570, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 29);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "↺ Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(16, 185, 129);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(480, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(84, 29);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(39, 39, 42);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(250, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by title, student...";
            txtSearch.Size = new Size(220, 24);
            txtSearch.TabIndex = 3;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.BackColor = Color.FromArgb(39, 39, 42);
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.FlatStyle = FlatStyle.Flat;
            cmbStatusFilter.Font = new Font("Segoe UI", 9.5F);
            cmbStatusFilter.ForeColor = Color.White;
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "All Statuses", "Active", "Flagged", "Pending", "Archived" });
            cmbStatusFilter.Location = new Point(78, 22);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(150, 25);
            cmbStatusFilter.TabIndex = 2;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilter.ForeColor = Color.FromArgb(161, 161, 170);
            lblFilter.Location = new Point(22, 26);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(45, 15);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Status:";
            // 
            // lblStatusCount
            // 
            lblStatusCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatusCount.AutoSize = true;
            lblStatusCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatusCount.ForeColor = Color.FromArgb(161, 161, 170);
            lblStatusCount.Location = new Point(810, 26);
            lblStatusCount.Name = "lblStatusCount";
            lblStatusCount.Size = new Size(116, 15);
            lblStatusCount.TabIndex = 0;
            lblStatusCount.Text = "0 listings loaded";
            lblStatusCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(28, 28, 33);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnFlag);
            pnlActions.Controls.Add(btnApprove);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 572);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(20, 12, 20, 12);
            pnlActions.Size = new Size(950, 60);
            pnlActions.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(185, 28, 28);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(800, 14);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 32);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Delete Listing";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnFlag
            // 
            btnFlag.BackColor = Color.FromArgb(217, 119, 6);
            btnFlag.Cursor = Cursors.Hand;
            btnFlag.FlatAppearance.BorderSize = 0;
            btnFlag.FlatStyle = FlatStyle.Flat;
            btnFlag.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnFlag.ForeColor = Color.White;
            btnFlag.Location = new Point(180, 14);
            btnFlag.Name = "btnFlag";
            btnFlag.Size = new Size(140, 32);
            btnFlag.TabIndex = 1;
            btnFlag.Text = "🚩 Flag as Suspicious";
            btnFlag.UseVisualStyleBackColor = false;
            btnFlag.Click += btnFlag_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.FromArgb(16, 185, 129);
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnApprove.ForeColor = Color.White;
            btnApprove.Location = new Point(22, 14);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(145, 32);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "✅ Approve / Set Active";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // dgvListings
            // 
            dgvListings.AllowUserToAddRows = false;
            dgvListings.AllowUserToDeleteRows = false;
            dgvListings.AllowUserToResizeRows = false;
            dgvListings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListings.BackgroundColor = Color.FromArgb(24, 24, 27);
            dgvListings.BorderStyle = BorderStyle.None;
            dgvListings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvListings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(32, 32, 36);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(32, 32, 36);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvListings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvListings.ColumnHeadersHeight = 40;
            dgvListings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 24, 27);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(228, 228, 231);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(39, 39, 45);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(16, 185, 129);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvListings.DefaultCellStyle = dataGridViewCellStyle2;
            dgvListings.Dock = DockStyle.Fill;
            dgvListings.EnableHeadersVisualStyles = false;
            dgvListings.GridColor = Color.FromArgb(39, 39, 42);
            dgvListings.Location = new Point(0, 68);
            dgvListings.MultiSelect = false;
            dgvListings.Name = "dgvListings";
            dgvListings.ReadOnly = true;
            dgvListings.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvListings.RowHeadersVisible = false;
            dgvListings.RowTemplate.Height = 36;
            dgvListings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListings.Size = new Size(950, 504);
            dgvListings.TabIndex = 2;
            // 
            // uc_ModerateListings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(dgvListings);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            Name = "uc_ModerateListings";
            Size = new Size(950, 632);
            Load += uc_ModerateListings_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvListings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblFilter;
        private ComboBox cmbStatusFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Label lblStatusCount;
        private Panel pnlActions;
        private Button btnApprove;
        private Button btnFlag;
        private Button btnDelete;
        private DataGridView dgvListings;
    }
}
