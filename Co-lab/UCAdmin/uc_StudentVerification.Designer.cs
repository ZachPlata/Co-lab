namespace Co_LAB
{
    partial class uc_StudentVerification
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
            pnlVerifDetails = new Panel();
            lblDetailsTitle = new Label();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblStudentEmail = new Label();
            txtStudentEmail = new TextBox();
            lblDocName = new Label();
            txtDocName = new TextBox();
            picDocument = new PictureBox();
            btnDownloadDoc = new Button();
            lblNote = new Label();
            txtVerificationNote = new TextBox();
            btnApprove = new Button();
            btnDecline = new Button();
            btnClearSelection = new Button();
            pnlVerifList = new Panel();
            lblExistingTitle = new Label();
            txtSearch = new TextBox();
            dgvVerifications = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colDocStatus = new DataGridViewTextBoxColumn();
            lblHint = new Label();
            lblTotalPending = new Label();
            errorProvider1 = new ErrorProvider(components);

            pnlAdminBadge.SuspendLayout();
            pnlVerifDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDocument).BeginInit();
            pnlVerifList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerifications).BeginInit();
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
            lblHeaderTitle.Text = "Student Verification";

            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(26, 54);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(560, 17);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Review uploaded student registration forms or IDs and approve or decline verification.";

            pnlAdminBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAdminBadge.BackColor = Color.FromArgb(20, 28, 23);
            pnlAdminBadge.Controls.Add(lblDot);
            pnlAdminBadge.Controls.Add(lblAdminText);
            pnlAdminBadge.Location = new Point(866, 20);
            pnlAdminBadge.Name = "pnlAdminBadge";
            pnlAdminBadge.Size = new Size(196, 41);
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
            lblAdminText.Text = "Document Review";

            pnlVerifDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlVerifDetails.BackColor = Color.FromArgb(20, 28, 23);
            pnlVerifDetails.Controls.Add(lblDetailsTitle);
            pnlVerifDetails.Controls.Add(lblStudentName);
            pnlVerifDetails.Controls.Add(txtStudentName);
            pnlVerifDetails.Controls.Add(lblStudentEmail);
            pnlVerifDetails.Controls.Add(txtStudentEmail);
            pnlVerifDetails.Controls.Add(lblDocName);
            pnlVerifDetails.Controls.Add(txtDocName);
            pnlVerifDetails.Controls.Add(picDocument);
            pnlVerifDetails.Controls.Add(btnDownloadDoc);
            pnlVerifDetails.Controls.Add(lblNote);
            pnlVerifDetails.Controls.Add(txtVerificationNote);
            pnlVerifDetails.Controls.Add(btnApprove);
            pnlVerifDetails.Controls.Add(btnDecline);
            pnlVerifDetails.Controls.Add(btnClearSelection);
            pnlVerifDetails.Location = new Point(24, 88);
            pnlVerifDetails.Name = "pnlVerifDetails";
            pnlVerifDetails.Size = new Size(340, 725);
            pnlVerifDetails.TabIndex = 3;
            pnlVerifDetails.Paint += RoundPanel_Paint;

            lblDetailsTitle.AutoSize = true;
            lblDetailsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailsTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblDetailsTitle.Location = new Point(20, 18);
            lblDetailsTitle.Name = "lblDetailsTitle";
            lblDetailsTitle.Size = new Size(165, 21);
            lblDetailsTitle.TabIndex = 0;
            lblDetailsTitle.Text = "Verification Review";

            lblStudentName.AutoSize = true;
            lblStudentName.Font = new Font("Segoe UI Semibold", 9F);
            lblStudentName.ForeColor = Color.FromArgb(228, 228, 231);
            lblStudentName.Location = new Point(20, 50);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(95, 15);
            lblStudentName.TabIndex = 1;
            lblStudentName.Text = "Student Name";

            txtStudentName.BackColor = Color.FromArgb(14, 20, 16);
            txtStudentName.BorderStyle = BorderStyle.FixedSingle;
            txtStudentName.Font = new Font("Segoe UI", 9.5F);
            txtStudentName.ForeColor = Color.White;
            txtStudentName.Location = new Point(20, 70);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.PlaceholderText = "Select a student from the table";
            txtStudentName.ReadOnly = true;
            txtStudentName.Size = new Size(282, 24);
            txtStudentName.TabIndex = 2;

            lblStudentEmail.AutoSize = true;
            lblStudentEmail.Font = new Font("Segoe UI Semibold", 9F);
            lblStudentEmail.ForeColor = Color.FromArgb(228, 228, 231);
            lblStudentEmail.Location = new Point(20, 104);
            lblStudentEmail.Name = "lblStudentEmail";
            lblStudentEmail.Size = new Size(85, 15);
            lblStudentEmail.TabIndex = 3;
            lblStudentEmail.Text = "Email Address";

            txtStudentEmail.BackColor = Color.FromArgb(14, 20, 16);
            txtStudentEmail.BorderStyle = BorderStyle.FixedSingle;
            txtStudentEmail.Font = new Font("Segoe UI", 9.5F);
            txtStudentEmail.ForeColor = Color.White;
            txtStudentEmail.Location = new Point(20, 124);
            txtStudentEmail.Name = "txtStudentEmail";
            txtStudentEmail.PlaceholderText = "-";
            txtStudentEmail.ReadOnly = true;
            txtStudentEmail.Size = new Size(282, 24);
            txtStudentEmail.TabIndex = 4;

            lblDocName.AutoSize = true;
            lblDocName.Font = new Font("Segoe UI Semibold", 9F);
            lblDocName.ForeColor = Color.FromArgb(228, 228, 231);
            lblDocName.Location = new Point(20, 158);
            lblDocName.Name = "lblDocName";
            lblDocName.Size = new Size(125, 15);
            lblDocName.TabIndex = 5;
            lblDocName.Text = "Uploaded Regform / ID";

            txtDocName.BackColor = Color.FromArgb(14, 20, 16);
            txtDocName.BorderStyle = BorderStyle.FixedSingle;
            txtDocName.Font = new Font("Segoe UI", 9F);
            txtDocName.ForeColor = Color.FromArgb(180, 210, 190);
            txtDocName.Location = new Point(20, 178);
            txtDocName.Name = "txtDocName";
            txtDocName.PlaceholderText = "No file uploaded";
            txtDocName.ReadOnly = true;
            txtDocName.Size = new Size(282, 23);
            txtDocName.TabIndex = 6;

            picDocument.BackColor = Color.FromArgb(14, 20, 16);
            picDocument.BorderStyle = BorderStyle.FixedSingle;
            picDocument.Location = new Point(20, 210);
            picDocument.Name = "picDocument";
            picDocument.Size = new Size(282, 180);
            picDocument.SizeMode = PictureBoxSizeMode.Zoom;
            picDocument.TabIndex = 7;
            picDocument.TabStop = false;

            btnDownloadDoc.BackColor = Color.FromArgb(28, 38, 30);
            btnDownloadDoc.Cursor = Cursors.Hand;
            btnDownloadDoc.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
            btnDownloadDoc.FlatAppearance.BorderSize = 1;
            btnDownloadDoc.FlatStyle = FlatStyle.Flat;
            btnDownloadDoc.Font = new Font("Segoe UI Semibold", 8.5F);
            btnDownloadDoc.ForeColor = Color.FromArgb(167, 243, 208);
            btnDownloadDoc.Location = new Point(20, 398);
            btnDownloadDoc.Name = "btnDownloadDoc";
            btnDownloadDoc.Size = new Size(282, 32);
            btnDownloadDoc.TabIndex = 8;
            btnDownloadDoc.Text = "⬇ Save / Open Uploaded File";
            btnDownloadDoc.UseVisualStyleBackColor = false;
            btnDownloadDoc.Click += btnDownloadDoc_Click;

            lblNote.AutoSize = true;
            lblNote.Font = new Font("Segoe UI Semibold", 9F);
            lblNote.ForeColor = Color.FromArgb(228, 228, 231);
            lblNote.Location = new Point(20, 442);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(155, 15);
            lblNote.TabIndex = 9;
            lblNote.Text = "Verification Note (optional)";

            txtVerificationNote.BackColor = Color.FromArgb(14, 20, 16);
            txtVerificationNote.BorderStyle = BorderStyle.FixedSingle;
            txtVerificationNote.Font = new Font("Segoe UI", 9F);
            txtVerificationNote.ForeColor = Color.White;
            txtVerificationNote.Location = new Point(20, 462);
            txtVerificationNote.MaxLength = 255;
            txtVerificationNote.Multiline = true;
            txtVerificationNote.Name = "txtVerificationNote";
            txtVerificationNote.PlaceholderText = "Reason if declining...";
            txtVerificationNote.Size = new Size(282, 68);
            txtVerificationNote.TabIndex = 10;

            btnApprove.BackColor = Color.FromArgb(32, 44, 35);
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnApprove.ForeColor = Color.FromArgb(120, 140, 125);
            btnApprove.Location = new Point(20, 544);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(135, 42);
            btnApprove.TabIndex = 11;
            btnApprove.Text = "✓ Approve";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;

            btnDecline.BackColor = Color.FromArgb(32, 44, 35);
            btnDecline.Cursor = Cursors.Hand;
            btnDecline.FlatAppearance.BorderSize = 0;
            btnDecline.FlatStyle = FlatStyle.Flat;
            btnDecline.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnDecline.ForeColor = Color.FromArgb(120, 140, 125);
            btnDecline.Location = new Point(167, 544);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(135, 42);
            btnDecline.TabIndex = 12;
            btnDecline.Text = "✗ Decline";
            btnDecline.UseVisualStyleBackColor = false;
            btnDecline.Click += btnDecline_Click;

            btnClearSelection.BackColor = Color.FromArgb(18, 25, 20);
            btnClearSelection.Cursor = Cursors.Hand;
            btnClearSelection.FlatAppearance.BorderColor = Color.FromArgb(36, 52, 40);
            btnClearSelection.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 38, 30);
            btnClearSelection.FlatStyle = FlatStyle.Flat;
            btnClearSelection.Font = new Font("Segoe UI Semibold", 8.5F);
            btnClearSelection.ForeColor = Color.FromArgb(180, 195, 185);
            btnClearSelection.Location = new Point(20, 598);
            btnClearSelection.Name = "btnClearSelection";
            btnClearSelection.Size = new Size(282, 38);
            btnClearSelection.TabIndex = 13;
            btnClearSelection.Text = "↺ Clear Selection";
            btnClearSelection.UseVisualStyleBackColor = false;
            btnClearSelection.Click += btnClearSelection_Click;

            pnlVerifList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlVerifList.BackColor = Color.FromArgb(20, 28, 23);
            pnlVerifList.Controls.Add(lblExistingTitle);
            pnlVerifList.Controls.Add(txtSearch);
            pnlVerifList.Controls.Add(dgvVerifications);
            pnlVerifList.Controls.Add(lblHint);
            pnlVerifList.Controls.Add(lblTotalPending);
            pnlVerifList.Location = new Point(382, 88);
            pnlVerifList.Name = "pnlVerifList";
            pnlVerifList.Size = new Size(680, 725);
            pnlVerifList.TabIndex = 4;
            pnlVerifList.Paint += RoundPanel_Paint;

            lblExistingTitle.AutoSize = true;
            lblExistingTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblExistingTitle.ForeColor = Color.White;
            lblExistingTitle.Location = new Point(20, 20);
            lblExistingTitle.Name = "lblExistingTitle";
            lblExistingTitle.Size = new Size(195, 21);
            lblExistingTitle.TabIndex = 0;
            lblExistingTitle.Text = "Student Verifications (0)";

            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(14, 20, 16);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(440, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Search student, status...";
            txtSearch.Size = new Size(220, 24);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;

            dgvVerifications.AllowUserToAddRows = false;
            dgvVerifications.AllowUserToDeleteRows = false;
            dgvVerifications.AllowUserToResizeRows = false;
            dgvVerifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVerifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVerifications.BackgroundColor = Color.FromArgb(14, 20, 16);
            dgvVerifications.BorderStyle = BorderStyle.None;
            dgvVerifications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVerifications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(74, 222, 128);
            dgvHeaderStyle.Padding = new Padding(8, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dgvVerifications.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvVerifications.ColumnHeadersHeight = 42;
            dgvVerifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvVerifications.Columns.AddRange(new DataGridViewColumn[] {
                colUserId,
                colFullName,
                colEmail,
                colStatus,
                colDocStatus
            });

            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.FromArgb(18, 25, 20);
            dgvRowStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyle.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyle.Padding = new Padding(8, 0, 0, 0);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyle.SelectionForeColor = Color.White;
            dgvVerifications.DefaultCellStyle = dgvRowStyle;

            dgvRowStyleAlt.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyleAlt.BackColor = Color.FromArgb(15, 22, 17);
            dgvRowStyleAlt.Font = new Font("Segoe UI", 9.5F);
            dgvRowStyleAlt.ForeColor = Color.FromArgb(228, 228, 231);
            dgvRowStyleAlt.Padding = new Padding(8, 0, 0, 0);
            dgvRowStyleAlt.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dgvRowStyleAlt.SelectionForeColor = Color.White;
            dgvVerifications.AlternatingRowsDefaultCellStyle = dgvRowStyleAlt;

            dgvVerifications.EnableHeadersVisualStyles = false;
            dgvVerifications.GridColor = Color.FromArgb(30, 44, 34);
            dgvVerifications.Location = new Point(20, 56);
            dgvVerifications.MultiSelect = false;
            dgvVerifications.Name = "dgvVerifications";
            dgvVerifications.ReadOnly = true;
            dgvVerifications.RowHeadersVisible = false;
            dgvVerifications.RowTemplate.Height = 40;
            dgvVerifications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVerifications.Size = new Size(640, 620);
            dgvVerifications.TabIndex = 2;
            dgvVerifications.SelectionChanged += dgvVerifications_SelectionChanged;
            dgvVerifications.CellFormatting += dgvVerifications_CellFormatting;

            colUserId.DataPropertyName = "UserId";
            colUserId.FillWeight = 10F;
            colUserId.HeaderText = "ID";
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;

            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 25F;
            colFullName.HeaderText = "Student Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;

            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 33F;
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;

            colStatus.DataPropertyName = "VerificationStatus";
            colStatus.FillWeight = 16F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;

            colDocStatus.DataPropertyName = "DocStatus";
            colDocStatus.FillWeight = 16F;
            colDocStatus.HeaderText = "Document";
            colDocStatus.Name = "colDocStatus";
            colDocStatus.ReadOnly = true;

            lblHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 8.5F);
            lblHint.ForeColor = Color.FromArgb(130, 175, 145);
            lblHint.Location = new Point(20, 690);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(250, 15);
            lblHint.TabIndex = 3;
            lblHint.Text = "Click any row to preview uploaded regform";

            lblTotalPending.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalPending.AutoSize = true;
            lblTotalPending.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTotalPending.ForeColor = Color.FromArgb(74, 222, 128);
            lblTotalPending.Location = new Point(525, 690);
            lblTotalPending.Name = "lblTotalPending";
            lblTotalPending.Size = new Size(135, 15);
            lblTotalPending.TabIndex = 4;
            lblTotalPending.Text = "Pending Review: 0";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlVerifDetails);
            Controls.Add(pnlVerifList);
            Controls.Add(pnlAdminBadge);
            Controls.Add(lblHeaderSubtitle);
            Controls.Add(lblHeaderTitle);
            Name = "uc_StudentVerification";
            Size = new Size(1086, 843);
            Load += uc_StudentVerification_Load;

            pnlAdminBadge.ResumeLayout(false);
            pnlAdminBadge.PerformLayout();
            pnlVerifDetails.ResumeLayout(false);
            pnlVerifDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDocument).EndInit();
            pnlVerifList.ResumeLayout(false);
            pnlVerifList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerifications).EndInit();
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
        private Panel pnlVerifDetails;
        private Label lblDetailsTitle;
        private Label lblStudentName;
        private TextBox txtStudentName;
        private Label lblStudentEmail;
        private TextBox txtStudentEmail;
        private Label lblDocName;
        private TextBox txtDocName;
        private PictureBox picDocument;
        private Button btnDownloadDoc;
        private Label lblNote;
        private TextBox txtVerificationNote;
        private Button btnApprove;
        private Button btnDecline;
        private Button btnClearSelection;
        private Panel pnlVerifList;
        private Label lblExistingTitle;
        private TextBox txtSearch;
        private DataGridView dgvVerifications;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDocStatus;
        private Label lblHint;
        private Label lblTotalPending;
        private ErrorProvider errorProvider1;
    }
}