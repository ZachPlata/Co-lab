using System;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class ReportDialog : Form
    {
        public string ReportReason => _txtReason.Text.Trim();

        public ReportDialog(string listingTitle, string ownerName)
        {
            InitializeComponent();
            lblTarget.Text = $"Listing: {listingTitle}\nPosted by: {ownerName}";
        }

        private void QuickChip_Click(object? sender, EventArgs e)
        {
            if (sender is Button chip)
            {
                _txtReason.Text = chip.Text;
                _txtReason.SelectionStart = _txtReason.Text.Length;
                _txtReason.Focus();
            }
        }

        private void txtReason_TextChanged(object? sender, EventArgs e)
        {
            errorProvider1.SetError(_txtReason, string.Empty);
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            errorProvider1.Clear();
            string reason = _txtReason.Text.Trim();
            if (string.IsNullOrWhiteSpace(reason) || reason.Length < 10 || reason.Length > 500)
            {
                errorProvider1.SetIconPadding(_txtReason, 6);
                errorProvider1.SetError(_txtReason, "Please enter 10–500 characters describing the issue.");
                _txtReason.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}