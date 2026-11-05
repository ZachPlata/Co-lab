using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_ReportedStudents : UserControl
    {
        public uc_ReportedStudents()
        {
            InitializeComponent();
            // Wire up events
            dataGridViewReports.CellContentClick += DataGridViewReports_CellContentClick;
            // Load sample data (replace with real data source later)
            LoadReports();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom painting
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom painting
        }

        // Simple data model for a report
        private class Report
        {
            public int ReportId { get; set; }
            public string Student { get; set; }
            public string Reporter { get; set; }
            public string Reason { get; set; }
            public DateTime Date { get; set; }
            public bool IsBlacklisted { get; set; }
        }

        // Populate the DataGridView with example rows
        private void LoadReports()
        {
            var sample = new List<Report>
            {
                new Report { ReportId = 1, Student = "John Doe", Reporter = "Teacher A", Reason = "Plagiarism", Date = DateTime.Now.AddDays(-2), IsBlacklisted = false },
                new Report { ReportId = 2, Student = "Jane Smith", Reporter = "Teacher B", Reason = "Cheating", Date = DateTime.Now.AddDays(-1), IsBlacklisted = true }
            };

            dataGridViewReports.Rows.Clear();
            foreach (var r in sample)
            {
                int rowIdx = dataGridViewReports.Rows.Add(r.ReportId, r.Student, r.Reporter, r.Reason, r.Date.ToShortDateString(), r.IsBlacklisted ? "Unblacklist" : "Blacklist");
                dataGridViewReports.Rows[rowIdx].Tag = r; // store the model for later use
            }
        }

        // Handle blacklist button clicks
        private void DataGridViewReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verify click is on the blacklist button column
            if (e.RowIndex < 0) return;
            var col = dataGridViewReports.Columns[e.ColumnIndex];
            if (col.Name != "colBlacklist") return;

            var row = dataGridViewReports.Rows[e.RowIndex];
            if (row.Tag is Report report)
            {
                // Toggle status
                report.IsBlacklisted = !report.IsBlacklisted;
                // Update button text
                row.Cells["colBlacklist"].Value = report.IsBlacklisted ? "Unblacklist" : "Blacklist";
                // TODO: Persist change to a data store
                MessageBox.Show($"Student '{report.Student}' has been {(report.IsBlacklisted ? "blacklisted" : "removed from blacklist")}.",
                    "Blacklist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
