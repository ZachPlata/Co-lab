using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class DeclineReasonDialog : Form
    {
        public string DeclineNote => txtReason.Text.Trim();

        public DeclineReasonDialog(string studentName)
        {
            InitializeComponent();
            lblPrompt.Text = $"Optional reason for declining '{studentName}':";
        }
    }
}