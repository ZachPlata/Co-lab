namespace Co_LAB
{
    partial class DeclineReasonDialog
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblPrompt = new Label();
            txtReason = new TextBox();
            btnCancel = new Button();
            btnConfirm = new Button();
            SuspendLayout();

            lblPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrompt.ForeColor = Color.FromArgb(220, 232, 224);
            lblPrompt.Location = new Point(16, 16);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(388, 22);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Optional reason for declining:";

            txtReason.BackColor = Color.FromArgb(28, 38, 31);
            txtReason.BorderStyle = BorderStyle.FixedSingle;
            txtReason.Font = new Font("Segoe UI", 9.5F);
            txtReason.ForeColor = Color.White;
            txtReason.Location = new Point(16, 46);
            txtReason.MaxLength = 255;
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.PlaceholderText = "e.g., Invalid @ue.edu.ph student details...";
            txtReason.Size = new Size(388, 90);
            txtReason.TabIndex = 1;

            btnCancel.BackColor = Color.FromArgb(38, 48, 42);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.5F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(162, 154);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(92, 36);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;

            btnConfirm.BackColor = Color.FromArgb(185, 28, 28);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(264, 154);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(140, 36);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Decline Account";
            btnConfirm.UseVisualStyleBackColor = false;

            AcceptButton = btnConfirm;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(20, 28, 23);
            CancelButton = btnCancel;
            ClientSize = new Size(420, 210);
            Controls.Add(lblPrompt);
            Controls.Add(txtReason);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeclineReasonDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Decline Student Verification";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrompt;
        private TextBox txtReason;
        private Button btnCancel;
        private Button btnConfirm;
    }
}