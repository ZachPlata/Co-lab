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
            openFileDialog1 = new OpenFileDialog();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            panel3 = new Panel();
            button3 = new Button();
            panel4 = new Panel();
            button4 = new Button();
            panel5 = new Panel();
            button5 = new Button();
            panel6 = new Panel();
            button6 = new Button();
            panel7 = new Panel();
            button7 = new Button();
            panel8 = new Panel();
            button8 = new Button();
            panel9 = new Panel();
            button9 = new Button();
            panel10 = new Panel();
            button10 = new Button();
            panel11 = new Panel();
            button11 = new Button();
            pnlHeader.SuspendLayout();
            pnlActions.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
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
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(23, 20, 23, 20);
            pnlHeader.Size = new Size(1039, 91);
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
            btnRefresh.Location = new Point(651, 27);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(91, 39);
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
            btnSearch.Location = new Point(549, 27);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(96, 39);
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
            txtSearch.Location = new Point(286, 29);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by title, student...";
            txtSearch.Size = new Size(251, 29);
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
            cmbStatusFilter.Location = new Point(89, 29);
            cmbStatusFilter.Margin = new Padding(3, 4, 3, 4);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(171, 29);
            cmbStatusFilter.TabIndex = 2;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilter.ForeColor = Color.FromArgb(161, 161, 170);
            lblFilter.Location = new Point(25, 35);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(57, 20);
            lblFilter.TabIndex = 1;
            lblFilter.Text = "Status:";
            // 
            // lblStatusCount
            // 
            lblStatusCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatusCount.AutoSize = true;
            lblStatusCount.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatusCount.ForeColor = Color.FromArgb(161, 161, 170);
            lblStatusCount.Location = new Point(879, 35);
            lblStatusCount.Name = "lblStatusCount";
            lblStatusCount.Size = new Size(113, 20);
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
            pnlActions.Location = new Point(0, 763);
            pnlActions.Margin = new Padding(3, 4, 3, 4);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(23, 16, 23, 16);
            pnlActions.Size = new Size(1039, 80);
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
            btnDelete.Location = new Point(867, 19);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 43);
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
            btnFlag.Location = new Point(206, 19);
            btnFlag.Margin = new Padding(3, 4, 3, 4);
            btnFlag.Name = "btnFlag";
            btnFlag.Size = new Size(160, 43);
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
            btnApprove.Location = new Point(25, 19);
            btnApprove.Margin = new Padding(3, 4, 3, 4);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(166, 43);
            btnApprove.TabIndex = 0;
            btnApprove.Text = "✅ Approve / Set Active";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(6, 95, 70);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(1039, 37);
            panel1.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(793, 10);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 5;
            label6.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(660, 10);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 4;
            label5.Text = "Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(503, 10);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "Skill Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(323, 10);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 2;
            label3.Text = "Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 10);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 1;
            label2.Text = "Student";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 10);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "ListingID";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(16, 185, 129);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(-41, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(1080, 37);
            panel2.TabIndex = 4;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Location = new Point(980, 5);
            button2.Name = "button2";
            button2.Size = new Size(77, 29);
            button2.TabIndex = 1;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(16, 185, 129);
            panel3.Controls.Add(button3);
            panel3.Location = new Point(-41, 184);
            panel3.Name = "panel3";
            panel3.Size = new Size(1080, 37);
            panel3.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Location = new Point(982, 3);
            button3.Name = "button3";
            button3.Size = new Size(77, 29);
            button3.TabIndex = 2;
            button3.Text = "Remove";
            button3.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(16, 185, 129);
            panel4.Controls.Add(button4);
            panel4.Location = new Point(-41, 227);
            panel4.Name = "panel4";
            panel4.Size = new Size(1080, 37);
            panel4.TabIndex = 4;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.Location = new Point(982, 5);
            button4.Name = "button4";
            button4.Size = new Size(77, 29);
            button4.TabIndex = 3;
            button4.Text = "Remove";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(16, 185, 129);
            panel5.Controls.Add(button5);
            panel5.Location = new Point(-41, 270);
            panel5.Name = "panel5";
            panel5.Size = new Size(1080, 37);
            panel5.TabIndex = 4;
            // 
            // button5
            // 
            button5.BackColor = Color.Red;
            button5.Location = new Point(980, 5);
            button5.Name = "button5";
            button5.Size = new Size(77, 29);
            button5.TabIndex = 4;
            button5.Text = "Remove";
            button5.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(16, 185, 129);
            panel6.Controls.Add(button6);
            panel6.Location = new Point(-41, 313);
            panel6.Name = "panel6";
            panel6.Size = new Size(1080, 37);
            panel6.TabIndex = 4;
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.Location = new Point(980, 3);
            button6.Name = "button6";
            button6.Size = new Size(77, 29);
            button6.TabIndex = 5;
            button6.Text = "Remove";
            button6.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(16, 185, 129);
            panel7.Controls.Add(button7);
            panel7.Location = new Point(-41, 356);
            panel7.Name = "panel7";
            panel7.Size = new Size(1080, 37);
            panel7.TabIndex = 4;
            // 
            // button7
            // 
            button7.BackColor = Color.Red;
            button7.Location = new Point(980, 5);
            button7.Name = "button7";
            button7.Size = new Size(77, 29);
            button7.TabIndex = 6;
            button7.Text = "Remove";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(16, 185, 129);
            panel8.Controls.Add(button8);
            panel8.Location = new Point(-41, 399);
            panel8.Name = "panel8";
            panel8.Size = new Size(1080, 37);
            panel8.TabIndex = 4;
            // 
            // button8
            // 
            button8.BackColor = Color.Red;
            button8.Location = new Point(980, 5);
            button8.Name = "button8";
            button8.Size = new Size(77, 29);
            button8.TabIndex = 7;
            button8.Text = "Remove";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(16, 185, 129);
            panel9.Controls.Add(button9);
            panel9.Location = new Point(-42, 442);
            panel9.Name = "panel9";
            panel9.Size = new Size(1080, 37);
            panel9.TabIndex = 4;
            // 
            // button9
            // 
            button9.BackColor = Color.Red;
            button9.Location = new Point(981, 3);
            button9.Name = "button9";
            button9.Size = new Size(77, 29);
            button9.TabIndex = 8;
            button9.Text = "Remove";
            button9.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(16, 185, 129);
            panel10.Controls.Add(button10);
            panel10.Location = new Point(-41, 485);
            panel10.Name = "panel10";
            panel10.Size = new Size(1080, 37);
            panel10.TabIndex = 4;
            // 
            // button10
            // 
            button10.BackColor = Color.Red;
            button10.Location = new Point(980, 5);
            button10.Name = "button10";
            button10.Size = new Size(77, 29);
            button10.TabIndex = 9;
            button10.Text = "Remove";
            button10.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(16, 185, 129);
            panel11.Controls.Add(button11);
            panel11.Location = new Point(-41, 528);
            panel11.Name = "panel11";
            panel11.Size = new Size(1080, 37);
            panel11.TabIndex = 4;
            // 
            // button11
            // 
            button11.BackColor = Color.Red;
            button11.Location = new Point(980, 3);
            button11.Name = "button11";
            button11.Size = new Size(77, 29);
            button11.TabIndex = 10;
            button11.Text = "Remove";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // uc_ModerateListings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(panel11);
            Controls.Add(panel10);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_ModerateListings";
            Size = new Size(1039, 843);
            Load += uc_ModerateListings_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlActions.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel11.ResumeLayout(false);
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
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Panel panel10;
        private Button button10;
        private Panel panel11;
        private Button button11;
        private Label label6;
    }
}
