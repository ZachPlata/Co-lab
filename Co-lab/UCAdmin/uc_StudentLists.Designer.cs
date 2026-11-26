namespace Co_LAB
{
    partial class uc_StudentLists
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyleAlt = new DataGridViewCellStyle();

            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlAdminBadge = new Panel();
            lblDot = new Label();
            lblAdminText = new Label();
            pnlUserDetails = new Panel();
            lblDetailsTitle = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnUpdateUser = new Button();
            btnClearSelection = new Button();
            pnlUsersList = new Panel();
            lblExistingTitle = new Label();
            txtSearch = new TextBox();
            dgvUsers = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblHint = new Label();
            lblTotalUsers = new Label();
            errorProvider1 = new ErrorProvider(components);

            pnlAdminBadge.SuspendLayout();
            pnlUserDetails.SuspendLayout();
            pnlUsersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(24, 18);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(340, 32);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Student & User Lists";

            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 54);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(520, 17);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "View all registered accounts, update verification or blacklist status, and manage user roles.";

            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(20, 28, 23);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminText);
            pnlAdminBadge.Location = new Point(850, 20);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(212, 41);
            pnlAdminBadge.TabIndex = 2;
            pnlAdminBadge.Paint += RoundPanel_Paint;

            lblDot.AutoSize = true;
            lblDot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDot.ForeColor = Color.FromArgb(34, 197, 94);
            lblDot.Location = new Point(14, 9);
            lblDot.Name = "lblDot";
            lblDot.Size = new Size(20, 20);
            lblDot.TabIndex = 0;
            lblDot.Text = "●";

            lblAdminText.AutoSize = true;
            lblAdminText.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAdminText.ForeColor = Color.White;
            lblAdminText.Location = new Point(36, 12);
            lblAdminText.Name = "lblAdminText";
            lblAdminText.Size = new Size(140, 17);
            lblAdminText.TabIndex = 1;
            lblAdminText.Text = "Account Management";

            pnlUserDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlUserDetails.BackColor = Color.FromArgb(20, 28, 23);
            pnlUserDetails.Controls.Add(lblDetailsTitle);
            pnlUserDetails.Controls.Add(lblFullName);
            pnlUserDetails.Controls.Add(txtFullName);
            pnlUserDetails.Controls.Add(lblEmail);
            pnlUserDetails.Controls.Add(txtEmail);
            pnlUserDetails.Controls.Add(lblRole);
            pnlUserDetails.Controls.Add(cmbRole);
            pnlUserDetails.Controls.Add(lblStatus);
            pnlUserDetails.Controls.Add(cmbStatus);
            pnlUserDetails.Controls.Add(btnUpdateUser);
            pnlUserDetails.Controls.Add(btnClearSelection);
            pnlUserDetails.Location = new Point(24, 88);
            pnlUserDetails.Name = "pnlUserDetails";
            pnlUserDetails.Size = new Size(330, 725);
            pnlUserDetails.TabIndex = 3;
            pnlUserDetails.Paint += RoundPanel_Paint;

            lblDetailsTitle.AutoSize = true;
            lblDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblDetailsTitle.Location = new Point(20, 20);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(120, 21);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "Account Details";

            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 9F);
            lblFullName.ForeColor = Color.FromArgb(228, 228, 231);
            lblFullName.Location = new Point(20, 60);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(70, 15);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name";

            txtFullName.BackColor = Color.FromArgb(14, 20, 16);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(20, 82);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Select a user from the table";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(272, 24);
            txtFullName.TabIndex = 2;

            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F);
            lblEmail.ForeColor = Color.FromArgb(228, 228, 231);
            lblEmail.Location = new Point(20, 122);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(85, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email Address";

            txtEmail.BackColor = Color.FromArgb(14, 20, 16);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(20, 144);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "-";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(272, 24);
            txtEmail.TabIndex = 4;

            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI Semibold", 9F);
            lblRole.ForeColor = Color.FromArgb(228, 228, 231);
            lblRole.Location = new Point(20, 184);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(65, 15);
            lblRole.TabIndex = 5;
            lblRole.Text = "User Role";

            cmbRole.BackColor = Color.FromArgb(14, 20, 16);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 9.5F);
            cmbRole.ForeColor = Color.White;
            cmbRole.Items.AddRange(new object[] { "Student", "Admin" });
            cmbRole.Location = new Point(20, 206);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(272, 25);
            cmbRole.TabIndex = 6;

            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F);
            lblStatus.ForeColor = Color.FromArgb(228, 228, 231);
            lblStatus.Location = new Point(20, 248);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(95, 15);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Account Status";

            cmbStatus.BackColor = Color.FromArgb(14, 20, 16);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Segoe UI", 9.5F);
            cmbStatus.ForeColor = Color.White;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Verified", "Declined", "Blacklisted" });
            cmbStatus.Location = new Point(20, 270);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(272, 25);
            cmbStatus.TabIndex = 8;

            btnUpdateUser.BackColor = Color.FromArgb(32, 44, 35);
            btnUpdateUser.Cursor = Cursors.Hand;
            btnUpdateUser.FlatAppearance.BorderSize = 0;
            btnUpdateUser.FlatStyle = FlatStyle.Flat;
            btnUpdateUser.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnUpdateUser.ForeColor = Color.FromArgb(120, 140, 125);
            btnUpdateUser.Location = new Point(20, 322);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(272, 44);
            btnUpdateUser.TabIndex = 9;
            btnUpdateUser.Text = "✓ Save Changes";
            btnUpdateUser.UseVisualStyleBackColor = false;
            btnUpdateUser.Click += btnUpdateUser_Click;

            btnClearSelection.BackColor = Color.FromArgb(18, 25, 20);
            btnClearSelection.Cursor = Cursors.Hand;
            btnClearSelection.FlatAppearance.BorderColor = Color.FromArgb(36, 52, 40);
            btnClearSelection.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 38, 30);
            btnClearSelection.FlatStyle = FlatStyle.Flat;
            btnClearSelection.Font = new Font("Segoe UI Semibold", 8.5F);
            btnClearSelection.ForeColor = Color.FromArgb(180, 195, 185);
            btnClearSelection.Location = new Point(20, 378);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(272, 39);
            btnClearSelection.TabIndex = 10;
            btnClearSelection.Text = "↺ Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = false;
            btnClearSelection.Click += btnClearSelection_Click;

            pnlUsersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlUsersList.BackColor = Color.FromArgb(20, 28, 23);
            pnlUsersList.Controls.Add(lblExistingTitle);
            pnlUsersList.Controls.Add(txtSearch);
            pnlUsersList.Controls.Add(dgvUsers);
            pnlUsersList.Controls.Add(lblHint);
            pnlUsersList.Controls.Add(lblTotalUsers);
            pnlUsersList.Location = new Point(372, 88);
            pnlUsersList.Name = "pnlUsersList";
            pnlUsersList.Size = new Size(690, 725);
            pnlUsersList.TabIndex = 4;
            pnlUsersList.Paint += RoundPanel_Paint;

            lblExistingTitle.AutoSize = true;
            lblExistingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblExistingTitle.ForeColor = Color.White;
            lblExistingTitle.Location = new Point(20, 20);
            lblExistingTitle.Name = "lblExistingTitle";
            lblExistingTitle.Size = new Size(150, 21);
            lblExistingTitle.TabIndex = 0;
            lblExistingTitle.Text = "Registered Users (0)";

            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(450, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search name, email, role...";
            txtSearch.Size = new Size(220, 24);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.FromArgb(14, 20, 16);
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.Padding = new Padding(8, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dgvUsers.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvUsers.ColumnHeadersHeight = 42;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUsers.Columns.AddRange(new DataGridViewColumn[] {
                colUserId,
                colFullName,
                colEmail,
                colRole,
                colStatus
            });

            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.FromArgb(18, 25, 20);
            dgvRowStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle.Padding = new Padding(8, 0, 0, 0);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyle.SelectionForeColor = Color.White;
            dgvUsers.DefaultCellStyle = dgvRowStyle;

            dgvRowStyleAlt.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyleAlt.BackColor = Color.FromArgb(15, 22, 17);
            dgvRowStyleAlt.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyleAlt.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyleAlt.Padding = new Padding(8, 0, 0, 0);
            dgvRowStyleAlt.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyleAlt.SelectionForeColor = Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle = dgvRowStyleAlt;

            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(30, 44, 34);
            dgvUsers.Location = new Point(20, 56);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 40;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(650, 620);
            dgvUsers.TabIndex = 2;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;

            colUserId.DataPropertyName = "UserId";
            colUserId.FillWeight = 10F;
            colUserId.HeaderText = "ID";
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;

            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 25F;
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;

            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 33F;
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;

            colRole.DataPropertyName = "Role";
            colRole.FillWeight = 14F;
            colRole.HeaderText = "Role";
            colRole.Name = "colRole";
            colRole.ReadOnly = true;

            colStatus.DataPropertyName = "DisplayStatus";
            colStatus.FillWeight = 18F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;

            lblHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 8.5F);
            lblHint.ForeColor = Color.FromArgb(130, 175, 145);
            lblHint.Location = new Point(20, 690);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(210, 15);
            lblHint.TabIndex = 3;
            lblHint.Text = "Click any row to edit role or status";

            lblTotalUsers.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTotalUsers.ForeColor = Color.FromArgb(74, 222, 128);
            lblTotalUsers.Location = new Point(540, 690);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(130, 15);
            lblTotalUsers.TabIndex = 4;
            lblTotalUsers.Text = "Total Accounts: 0";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlUserDetails);
            Controls.Add(pnlUsersList);
            Controls.Add(pnlAdminBadge);
            Controls.Add(lblHeaderSubtitle);
            Controls.Add(lblHeaderTitle);
            Name = "uc_StudentLists";
            Size = new Size(1086, 843);
            Load += uc_StudentLists_Load;

            pnlAdminBadge.ResumeLayout(false);
            pnlAdminBadge.PerformLayout();
            pnlUserDetails.ResumeLayout(false);
            pnlUserDetails.PerformLayout();
            pnlUsersList.ResumeLayout(false);
            pnlUsersList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlAdminBadge;
        private Label lblDot;
        private Label lblAdminText;
        private Panel pnlUserDetails;
        private Label lblDetailsTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnUpdateUser;
        private Button btnClearSelection;
        private Panel pnlUsersList;
        private Label lblExistingTitle;
        private TextBox txtSearch;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblHint;
        private Label lblTotalUsers;
        private ErrorProvider errorProvider1;
    }
}