namespace Co_LAB
{
    partial class uc_ReportedStudents
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            dataGridViewReports = new DataGridView();
            colReportId = new DataGridViewTextBoxColumn();
            colReportedStudent = new DataGridViewTextBoxColumn();
            colReporter = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colBlacklist = new DataGridViewButtonColumn();
            lblTitle = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(6, 95, 70);
            panel1.Location = new Point(32, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(949, 78);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(6, 95, 70);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(dataGridViewReports);
            panel2.Controls.Add(lblTitle);
            panel2.Location = new Point(33, 163);
            panel2.Name = "panel2";
            panel2.Size = new Size(949, 560);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(16, 185, 129);
            panel3.Location = new Point(64, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(839, 47);
            panel3.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(70, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 21);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Reported Students";
            // 
            // dataGridViewReports
            // 
            dataGridViewReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReports.Columns.AddRange(new DataGridViewColumn[] {
            colReportId,
            colReportedStudent,
            colReporter,
            colReason,
            colDate,
            colBlacklist});
            dataGridViewReports.Location = new Point(20, 110);
            dataGridViewReports.Name = "dataGridViewReports";
            dataGridViewReports.RowHeadersWidth = 51;
            dataGridViewReports.RowTemplate.Height = 29;
            dataGridViewReports.Size = new Size(910, 430);
            dataGridViewReports.TabIndex = 3;
            // 
            // colReportId
            // 
            colReportId.HeaderText = "Report ID";
            colReportId.MinimumWidth = 6;
            colReportId.Name = "colReportId";
            colReportId.Width = 125;
            // 
            // colReportedStudent
            // 
            colReportedStudent.HeaderText = "Student";
            colReportedStudent.MinimumWidth = 6;
            colReportedStudent.Name = "colReportedStudent";
            colReportedStudent.Width = 150;
            // 
            // colReporter
            // 
            colReporter.HeaderText = "Reporter";
            colReporter.MinimumWidth = 6;
            colReporter.Name = "colReporter";
            colReporter.Width = 150;
            // 
            // colReason
            // 
            colReason.HeaderText = "Reason";
            colReason.MinimumWidth = 6;
            colReason.Name = "colReason";
            colReason.Width = 200;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.Width = 120;
            // 
            // colBlacklist
            // 
            colBlacklist.HeaderText = "Blacklist";
            colBlacklist.MinimumWidth = 6;
            colBlacklist.Name = "colBlacklist";
            colBlacklist.Width = 80;
            // 
            // uc_ReportedStudents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "uc_ReportedStudents";
            Size = new Size(1086, 843);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}
