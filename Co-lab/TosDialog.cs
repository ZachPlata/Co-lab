using System;
using System.Drawing;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class TosDialog : Form
    {
        public TosDialog(bool readOnlyMode = false)
        {
            InitializeComponent();

            if (readOnlyMode)
            {
                btnAccept.Visible = false;
                btnDecline.Visible = false;
                btnClose.Visible = true;
            }
            else
            {
                btnAccept.Visible = true;
                btnDecline.Visible = true;
                btnClose.Visible = false;
            }
        }

        private void TosDialog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            LoadTosContent();
        }

        private void LoadTosContent()
        {
            string regulationsText = "";

            try
            {
                object? tosObj = DatabaseHelper.ExecuteScalar("SELECT TosContent FROM tbl_tos ORDER BY TosId DESC LIMIT 1");
                if (tosObj != null && tosObj != DBNull.Value)
                {
                    regulationsText = tosObj.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                // Fallback text if database is offline or unreachable
                System.Diagnostics.Debug.WriteLine($"Could not load TOS from database: {ex.Message}");
            }

            if (string.IsNullOrWhiteSpace(regulationsText))
            {
                regulationsText = "WELCOME TO CO-LAB: UE STUDENT SKILL EXCHANGE\n\n" +
                                  "1. ELIGIBILITY: You must be an officially enrolled student of the University of the East with a valid @ue.edu.ph email address.\n\n" +
                                  "2. ACADEMIC INTEGRITY: Skills exchanged must focus on tutoring, mentoring, creative skills, or technical training. Directly completing someone else's graded exam, quiz, or project is strictly forbidden.\n\n" +
                                  "3. NON-MONETARY POLICY: Co-LAB is a barter/exchange platform. Charging cash or cryptocurrency for skill sharing is prohibited.\n\n" +
                                  "4. SAFETY & CONDUCT: Respect your fellow students. For Face-to-Face exchanges, only meet in public campus areas (Libraries, Student Centers, Cafeteria).\n\n" +
                                  "5. VIOLATIONS: Violations will lead to immediate account suspension and blacklisting.";
            }

            txtTosContent.Text = regulationsText.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            txtTosContent.SelectionStart = 0;
            txtTosContent.SelectionLength = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

