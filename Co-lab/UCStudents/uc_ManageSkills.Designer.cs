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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            pnlCreateOffer = new Panel();
            btnClearForm = new Button();
            btnPublishListing = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtLocation = new TextBox();
            lblLocation = new Label();
            cmbDeliveryMode = new ComboBox();
            lblDeliveryMode = new Label();
            txtDesiredSkill = new TextBox();
            lblDesiredSkill = new Label();
            cmbKnownSkills = new ComboBox();
            lblSelectKnownSkill = new Label();
            lblSectionTitle = new Label();
            pnlListingsHeader = new Panel();
            lblListingsCount = new Label();
            lblMyListingsTitle = new Label();
            pnlActions = new Panel();
            btnRefresh = new Button();
            btnToggleStatus = new Button();
            btnDeleteListing = new Button();
            dgvMyListings = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlCreateOffer.SuspendLayout();
            pnlListingsHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyListings).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(20, 28, 23);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(25, 14, 25, 14);
            pnlHeader.Size = new Size(950, 64);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblHeaderSubtitle.Location = new Point(27, 36);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(478, 15);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Publish your known skills to the public barter marketplace and manage your active offers.";
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(25, 10);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(183, 25);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "My Barter Offerings";
            // 
            // pnlCreateOffer
            // 
            pnlCreateOffer.BackColor = Color.FromArgb(20, 28, 23);
            pnlCreateOffer.Controls.Add(btnClearForm);
            pnlCreateOffer.Controls.Add(btnPublishListing);
            pnlCreateOffer.Controls.Add(txtDescription);
            pnlCreateOffer.Controls.Add(lblDescription);
            pnlCreateOffer.Controls.Add(txtLocation);
            pnlCreateOffer.Controls.Add(lblLocation);
            pnlCreateOffer.Controls.Add(cmbDeliveryMode);
            pnlCreateOffer.Controls.Add(lblDeliveryMode);
            pnlCreateOffer.Controls.Add(txtDesiredSkill);
            pnlCreateOffer.Controls.Add(lblDesiredSkill);
            pnlCreateOffer.Controls.Add(cmbKnownSkills);
            pnlCreateOffer.Controls.Add(lblSelectKnownSkill);
            pnlCreateOffer.Controls.Add(lblSectionTitle);
            pnlCreateOffer.Dock = DockStyle.Top;
            pnlCreateOffer.Location = new Point(0, 64);
            pnlCreateOffer.Name = "pnlCreateOffer";
            pnlCreateOffer.Padding = new Padding(25, 14, 25, 14);
            pnlCreateOffer.Size = new Size(950, 200);
            pnlCreateOffer.TabIndex = 1;
            // 
            // btnClearForm
            // 
            btnClearForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearForm.BackColor = Color.FromArgb(28, 38, 30);
            btnClearForm.Cursor = Cursors.Hand;
            btnClearForm.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnClearForm.FlatStyle = FlatStyle.Flat;
            btnClearForm.Font = new Font("Segoe UI", 9F);
            btnClearForm.ForeColor = Color.FromArgb(220, 235, 225);
            btnClearForm.Location = new Point(733, 156);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(190, 28);
            btnClearForm.TabIndex = 12;
            btnClearForm.Text = "↺ Clear Inputs";
            btnClearForm.UseVisualStyleBackColor = false;
            btnClearForm.Click += btnClearForm_Click;
            // 
            // btnPublishListing
            // 
            btnPublishListing.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPublishListing.BackColor = Color.FromArgb(46, 125, 70);
            btnPublishListing.Cursor = Cursors.Hand;
            btnPublishListing.FlatAppearance.BorderSize = 0;
            btnPublishListing.FlatStyle = FlatStyle.Flat;
            btnPublishListing.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnPublishListing.ForeColor = Color.White;
            btnPublishListing.Location = new Point(733, 116);
            btnPublishListing.Name = "btnPublishListing";
            btnPublishListing.Size = new Size(190, 34);
            btnPublishListing.TabIndex = 11;
            btnPublishListing.Text = "🚀 Publish to Market";
            btnPublishListing.UseVisualStyleBackColor = false;
            btnPublishListing.Click += btnPublishListing_Click;
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.BackColor = Color.FromArgb(14, 20, 16);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 9.5F);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(28, 116);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Describe what you will teach, topics covered, session length...";
            txtDescription.Size = new Size(680, 68);
            txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 9F);
            lblDescription.ForeColor = Color.FromArgb(212, 212, 216);
            lblDescription.Location = new Point(25, 96);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(109, 15);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Listing Description:";
            // 
            // txtLocation
            // 
            txtLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLocation.BackColor = Color.FromArgb(14, 20, 16);
            txtLocation.BorderStyle = BorderStyle.FixedSingle;
            txtLocation.Font = new Font("Segoe UI", 9.5F);
            txtLocation.ForeColor = Color.White;
            txtLocation.Location = new Point(733, 59);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "e.g. Discord or TYK Library";
            txtLocation.Size = new Size(190, 24);
            txtLocation.TabIndex = 8;
            // 
            // lblLocation
            // 
            lblLocation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI Semibold", 9F);
            lblLocation.ForeColor = Color.FromArgb(212, 212, 216);
            lblLocation.Location = new Point(730, 40);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(111, 15);
            lblLocation.TabIndex = 7;
            lblLocation.Text = "Meeting / Platform:";
            // 
            // cmbDeliveryMode
            // 
            cmbDeliveryMode.BackColor = Color.FromArgb(14, 20, 16);
            cmbDeliveryMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDeliveryMode.FlatStyle = FlatStyle.Flat;
            cmbDeliveryMode.Font = new Font("Segoe UI", 9.5F);
            cmbDeliveryMode.ForeColor = Color.White;
            cmbDeliveryMode.FormattingEnabled = true;
            cmbDeliveryMode.Items.AddRange(new object[] { "Online", "Face-to-Face" });
            cmbDeliveryMode.Location = new Point(565, 59);
            cmbDeliveryMode.Name = "cmbDeliveryMode";
            cmbDeliveryMode.Size = new Size(140, 25);
            cmbDeliveryMode.TabIndex = 6;
            // 
            // lblDeliveryMode
            // 
            lblDeliveryMode.AutoSize = true;
            lblDeliveryMode.Font = new Font("Segoe UI Semibold", 9F);
            lblDeliveryMode.ForeColor = Color.FromArgb(212, 212, 216);
            lblDeliveryMode.Location = new Point(565, 40);
            lblDeliveryMode.Name = "lblDeliveryMode";
            lblDeliveryMode.Size = new Size(87, 15);
            lblDeliveryMode.TabIndex = 5;
            lblDeliveryMode.Text = "Delivery Mode:";
            // 
            // txtDesiredSkill
            // 
            txtDesiredSkill.BackColor = Color.FromArgb(14, 20, 16);
            txtDesiredSkill.BorderStyle = BorderStyle.FixedSingle;
            txtDesiredSkill.Font = new Font("Segoe UI", 9.5F);
            txtDesiredSkill.ForeColor = Color.White;
            txtDesiredSkill.Location = new Point(313, 59);
            txtDesiredSkill.Name = "txtDesiredSkill";
            txtDesiredSkill.PlaceholderText = "e.g. Photoshop basics, Python help";
            txtDesiredSkill.Size = new Size(230, 24);
            txtDesiredSkill.TabIndex = 4;
            // 
            // lblDesiredSkill
            // 
            lblDesiredSkill.AutoSize = true;
            lblDesiredSkill.Font = new Font("Segoe UI Semibold", 9F);
            lblDesiredSkill.ForeColor = Color.FromArgb(212, 212, 216);
            lblDesiredSkill.Location = new Point(310, 40);
            lblDesiredSkill.Name = "lblDesiredSkill";
            lblDesiredSkill.Size = new Size(142, 15);
            lblDesiredSkill.TabIndex = 3;
            lblDesiredSkill.Text = "Desired Skill in Exchange:";
            // 
            // cmbKnownSkills
            // 
            cmbKnownSkills.BackColor = Color.FromArgb(14, 20, 16);
            cmbKnownSkills.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKnownSkills.FlatStyle = FlatStyle.Flat;
            cmbKnownSkills.Font = new Font("Segoe UI", 9.5F);
            cmbKnownSkills.ForeColor = Color.White;
            cmbKnownSkills.FormattingEnabled = true;
            cmbKnownSkills.Location = new Point(28, 59);
            cmbKnownSkills.Name = "cmbKnownSkills";
            cmbKnownSkills.Size = new Size(260, 25);
            cmbKnownSkills.TabIndex = 2;
            // 
            // lblSelectKnownSkill
            // 
            lblSelectKnownSkill.AutoSize = true;
            lblSelectKnownSkill.Font = new Font("Segoe UI Semibold", 9F);
            lblSelectKnownSkill.ForeColor = Color.FromArgb(212, 212, 216);
            lblSelectKnownSkill.Location = new Point(25, 40);
            lblSelectKnownSkill.Name = "lblSelectKnownSkill";
            lblSelectKnownSkill.Size = new Size(150, 15);
            lblSelectKnownSkill.TabIndex = 1;
            lblSelectKnownSkill.Text = "Choose From Known Skills:";
            // 
            // lblSectionTitle
            // 
            lblSectionTitle.AutoSize = true;
            lblSectionTitle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblSectionTitle.ForeColor = Color.FromArgb(74, 222, 128);
            lblSectionTitle.Location = new Point(25, 10);
            lblSectionTitle.Name = "lblSectionTitle";
            lblSectionTitle.Size = new Size(233, 19);
            lblSectionTitle.TabIndex = 0;
            lblSectionTitle.Text = "➕ Post a New Skill to Marketplace";
            // 
            // pnlListingsHeader
            // 
            pnlListingsHeader.BackColor = Color.FromArgb(18, 25, 20);
            pnlListingsHeader.Controls.Add(lblListingsCount);
            pnlListingsHeader.Controls.Add(lblMyListingsTitle);
            pnlListingsHeader.Dock = DockStyle.Top;
            pnlListingsHeader.Location = new Point(0, 264);
            pnlListingsHeader.Name = "pnlListingsHeader";
            pnlListingsHeader.Padding = new Padding(25, 10, 25, 10);
            pnlListingsHeader.Size = new Size(950, 42);
            pnlListingsHeader.TabIndex = 2;
            // 
            // lblListingsCount
            // 
            lblListingsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblListingsCount.AutoSize = true;
            lblListingsCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblListingsCount.ForeColor = Color.FromArgb(130, 175, 145);
            lblListingsCount.Location = new Point(800, 14);
            lblListingsCount.Name = "lblListingsCount";
            lblListingsCount.Size = new Size(87, 15);
            lblListingsCount.TabIndex = 1;
            lblListingsCount.Text = "0 active listings";
            lblListingsCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMyListingsTitle
            // 
            lblMyListingsTitle.AutoSize = true;
            lblMyListingsTitle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblMyListingsTitle.ForeColor = Color.White;
            lblMyListingsTitle.Location = new Point(25, 11);
            lblMyListingsTitle.Name = "lblMyListingsTitle";
            lblMyListingsTitle.Size = new Size(168, 19);
            lblMyListingsTitle.TabIndex = 0;
            lblMyListingsTitle.Text = "Active Listings on Market";
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(20, 28, 23);
            pnlActions.Controls.Add(btnRefresh);
            pnlActions.Controls.Add(btnToggleStatus);
            pnlActions.Controls.Add(btnDeleteListing);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 580);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(25, 10, 25, 10);
            pnlActions.Size = new Size(950, 52);
            pnlActions.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(28, 38, 30);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F);
            btnRefresh.ForeColor = Color.FromArgb(220, 235, 225);
            btnRefresh.Location = new Point(200, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(95, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "↺ Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.BackColor = Color.FromArgb(28, 38, 30);
            btnToggleStatus.Cursor = Cursors.Hand;
            btnToggleStatus.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnToggleStatus.FlatStyle = FlatStyle.Flat;
            btnToggleStatus.Font = new Font("Segoe UI Semibold", 9F);
            btnToggleStatus.ForeColor = Color.FromArgb(220, 235, 225);
            btnToggleStatus.Location = new Point(25, 10);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(165, 32);
            btnToggleStatus.TabIndex = 1;
            btnToggleStatus.Text = "⏸️ Pause / Activate Offer";
            btnToggleStatus.UseVisualStyleBackColor = false;
            btnToggleStatus.Click += btnToggleStatus_Click;
            // 
            // btnDeleteListing
            // 
            btnDeleteListing.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeleteListing.BackColor = Color.FromArgb(45, 24, 26);
            btnDeleteListing.Cursor = Cursors.Hand;
            btnDeleteListing.FlatAppearance.BorderColor = Color.FromArgb(60, 35, 40);
            btnDeleteListing.FlatStyle = FlatStyle.Flat;
            btnDeleteListing.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnDeleteListing.ForeColor = Color.FromArgb(248, 113, 113);
            btnDeleteListing.Location = new Point(810, 10);
            btnDeleteListing.Name = "btnDeleteListing";
            btnDeleteListing.Size = new Size(115, 32);
            btnDeleteListing.TabIndex = 0;
            btnDeleteListing.Text = "🗑️ Delete Listing";
            btnDeleteListing.UseVisualStyleBackColor = false;
            btnDeleteListing.Click += btnDeleteListing_Click;
            // 
            // dgvMyListings
            // 
            dgvMyListings.AllowUserToAddRows = false;
            dgvMyListings.AllowUserToDeleteRows = false;
            dgvMyListings.AllowUserToResizeRows = false;
            dgvMyListings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyListings.BackgroundColor = Color.FromArgb(14, 20, 16);
            dgvMyListings.BorderStyle = BorderStyle.None;
            dgvMyListings.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMyListings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(20, 28, 23);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(74, 222, 128);
            dataGridViewCellStyle1.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(20, 28, 23);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(74, 222, 128);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMyListings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMyListings.ColumnHeadersHeight = 38;
            dgvMyListings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(18, 25, 20);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(228, 228, 231);
            dataGridViewCellStyle2.Padding = new Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(34, 52, 40);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMyListings.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMyListings.Dock = DockStyle.Fill;
            dgvMyListings.EnableHeadersVisualStyles = false;
            dgvMyListings.GridColor = Color.FromArgb(30, 44, 34);
            dgvMyListings.Location = new Point(0, 306);
            dgvMyListings.MultiSelect = false;
            dgvMyListings.Name = "dgvMyListings";
            dgvMyListings.ReadOnly = true;
            dgvMyListings.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvMyListings.RowHeadersVisible = false;
            dgvMyListings.RowTemplate.Height = 36;
            dgvMyListings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyListings.Size = new Size(950, 274);
            dgvMyListings.TabIndex = 4;
            // 
            // uc_ManageSkills
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(dgvMyListings);
            Controls.Add(pnlActions);
            Controls.Add(pnlListingsHeader);
            Controls.Add(pnlCreateOffer);
            Controls.Add(pnlHeader);
            Name = "uc_ManageSkills";
            Size = new Size(950, 632);
            Load += uc_ManageSkills_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCreateOffer.ResumeLayout(false);
            pnlCreateOffer.PerformLayout();
            pnlListingsHeader.ResumeLayout(false);
            pnlListingsHeader.PerformLayout();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMyListings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlCreateOffer;
        private Label lblSectionTitle;
        private Label lblSelectKnownSkill;
        private ComboBox cmbKnownSkills;
        private Label lblDesiredSkill;
        private TextBox txtDesiredSkill;
        private Label lblDeliveryMode;
        private ComboBox cmbDeliveryMode;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnPublishListing;
        private Button btnClearForm;
        private Panel pnlListingsHeader;
        private Label lblMyListingsTitle;
        private Label lblListingsCount;
        private Panel pnlActions;
        private Button btnDeleteListing;
        private Button btnToggleStatus;
        private Button btnRefresh;
        private DataGridView dgvMyListings;
    }
}
