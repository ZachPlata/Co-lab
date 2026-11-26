namespace Co_LAB
{
    partial class ReportDialog
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
            components = new System.ComponentModel.Container();
            lblHeader = new Label();
            lblTarget = new Label();
            lblQuick = new Label();
            flpChips = new FlowLayoutPanel();
            chipCash = new Button();
            chipNoShow = new Button();
            chipDishonesty = new Button();
            chipSpam = new Button();
            lblDetails = new Label();
            _txtReason = new TextBox();
            _btnCancel = new Button();
            _btnSubmit = new Button();
            errorProvider1 = new ErrorProvider(components);
            flpChips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            lblHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(248, 113, 113);
            lblHeader.Location = new Point(20, 16);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(440, 26);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🚩 Report Listing or Student";

            lblTarget.AutoEllipsis = true;
            lblTarget.Font = new Font("Segoe UI", 9F);
            lblTarget.ForeColor = Color.FromArgb(185, 205, 192);
            lblTarget.Location = new Point(20, 48);
            lblTarget.Name = "lblTarget";
            lblTarget.Size = new Size(440, 38);
            lblTarget.TabIndex = 1;
            lblTarget.Text = "Listing:";

            lblQuick.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblQuick.ForeColor = Color.FromArgb(161, 161, 170);
            lblQuick.Location = new Point(20, 94);
            lblQuick.Name = "lblQuick";
            lblQuick.Size = new Size(120, 18);
            lblQuick.TabIndex = 2;
            lblQuick.Text = "Quick Reasons:";

            flpChips.BackColor = Color.Transparent;
            flpChips.Controls.Add(chipCash);
            flpChips.Controls.Add(chipNoShow);
            flpChips.Controls.Add(chipDishonesty);
            flpChips.Controls.Add(chipSpam);
            flpChips.Location = new Point(20, 116);
            flpChips.Name = "flpChips";
            flpChips.Size = new Size(440, 56);
            flpChips.TabIndex = 3;

            chipCash.AutoSize = true;
            chipCash.BackColor = Color.FromArgb(24, 34, 27);
            chipCash.Cursor = Cursors.Hand;
            chipCash.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
            chipCash.FlatStyle = FlatStyle.Flat;
            chipCash.Font = new Font("Segoe UI", 8F);
            chipCash.ForeColor = Color.FromArgb(200, 225, 210);
            chipCash.Location = new Point(0, 0);
            chipCash.Margin = new Padding(0, 0, 6, 6);
            chipCash.Name = "chipCash";
            chipCash.Padding = new Padding(6, 2, 6, 2);
            chipCash.Size = new Size(140, 23);
            chipCash.TabIndex = 0;
            chipCash.Text = "Cash payment demanded";
            chipCash.UseVisualStyleBackColor = false;
            chipCash.Click += QuickChip_Click;

            chipNoShow.AutoSize = true;
            chipNoShow.BackColor = Color.FromArgb(24, 34, 27);
            chipNoShow.Cursor = Cursors.Hand;
            chipNoShow.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
            chipNoShow.FlatStyle = FlatStyle.Flat;
            chipNoShow.Font = new Font("Segoe UI", 8F);
            chipNoShow.ForeColor = Color.FromArgb(200, 225, 210);
            chipNoShow.Location = new Point(146, 0);
            chipNoShow.Margin = new Padding(0, 0, 6, 6);
            chipNoShow.Name = "chipNoShow";
            chipNoShow.Padding = new Padding(6, 2, 6, 2);
            chipNoShow.Size = new Size(140, 23);
            chipNoShow.TabIndex = 1;
            chipNoShow.Text = "No-show / Ghosted meetup";
            chipNoShow.UseVisualStyleBackColor = false;
            chipNoShow.Click += QuickChip_Click;

            chipDishonesty.AutoSize = true;
            chipDishonesty.BackColor = Color.FromArgb(24, 34, 27);
            chipDishonesty.Cursor = Cursors.Hand;
            chipDishonesty.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
            chipDishonesty.FlatStyle = FlatStyle.Flat;
            chipDishonesty.Font = new Font("Segoe UI", 8F);
            chipDishonesty.ForeColor = Color.FromArgb(200, 225, 210);
            chipDishonesty.Location = new Point(292, 0);
            chipDishonesty.Margin = new Padding(0, 0, 6, 6);
            chipDishonesty.Name = "chipDishonesty";
            chipDishonesty.Padding = new Padding(6, 2, 6, 2);
            chipDishonesty.Size = new Size(125, 23);
            chipDishonesty.TabIndex = 2;
            chipDishonesty.Text = "Academic dishonesty";
            chipDishonesty.UseVisualStyleBackColor = false;
            chipDishonesty.Click += QuickChip_Click;

            chipSpam.AutoSize = true;
            chipSpam.BackColor = Color.FromArgb(24, 34, 27);
            chipSpam.Cursor = Cursors.Hand;
            chipSpam.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 70);
            chipSpam.FlatStyle = FlatStyle.Flat;
            chipSpam.Font = new Font("Segoe UI", 8F);
            chipSpam.ForeColor = Color.FromArgb(200, 225, 210);
            chipSpam.Location = new Point(0, 29);
            chipSpam.Margin = new Padding(0, 0, 6, 6);
            chipSpam.Name = "chipSpam";
            chipSpam.Padding = new Padding(6, 2, 6, 2);
            chipSpam.Size = new Size(165, 23);
            chipSpam.TabIndex = 3;
            chipSpam.Text = "Spam / Inappropriate content";
            chipSpam.UseVisualStyleBackColor = false;
            chipSpam.Click += QuickChip_Click;

            lblDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDetails.ForeColor = Color.White;
            lblDetails.Location = new Point(20, 178);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(300, 18);
            lblDetails.TabIndex = 4;
            lblDetails.Text = "Incident Details (10–500 characters):";

            _txtReason.BackColor = Color.FromArgb(20, 28, 23);
            _txtReason.BorderStyle = BorderStyle.FixedSingle;
            _txtReason.Font = new Font("Segoe UI", 9.5F);
            _txtReason.ForeColor = Color.White;
            _txtReason.Location = new Point(20, 200);
            _txtReason.MaxLength = 500;
            _txtReason.Multiline = true;
            _txtReason.Name = "_txtReason";
            _txtReason.PlaceholderText = "Describe what happened so Admins can review...";
            _txtReason.Size = new Size(416, 86);
            _txtReason.TabIndex = 5;
            _txtReason.TextChanged += txtReason_TextChanged;

            _btnCancel.BackColor = Color.FromArgb(30, 42, 34);
            _btnCancel.Cursor = Cursors.Hand;
            _btnCancel.DialogResult = DialogResult.Cancel;
            _btnCancel.FlatAppearance.BorderSize = 0;
            _btnCancel.FlatStyle = FlatStyle.Flat;
            _btnCancel.Font = new Font("Segoe UI", 9.5F);
            _btnCancel.ForeColor = Color.White;
            _btnCancel.Location = new Point(220, 302);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(100, 34);
            _btnCancel.TabIndex = 6;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = false;

            _btnSubmit.BackColor = Color.FromArgb(185, 28, 28);
            _btnSubmit.Cursor = Cursors.Hand;
            _btnSubmit.FlatAppearance.BorderSize = 0;
            _btnSubmit.FlatStyle = FlatStyle.Flat;
            _btnSubmit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            _btnSubmit.ForeColor = Color.White;
            _btnSubmit.Location = new Point(328, 302);
            _btnSubmit.Name = "_btnSubmit";
            _btnSubmit.Size = new Size(132, 34);
            _btnSubmit.TabIndex = 7;
            _btnSubmit.Text = "Submit Report";
            _btnSubmit.UseVisualStyleBackColor = false;
            _btnSubmit.Click += BtnSubmit_Click;

            AcceptButton = _btnSubmit;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(14, 20, 16);
            CancelButton = _btnCancel;
            ClientSize = new Size(480, 355);
            Controls.Add(lblHeader);
            Controls.Add(lblTarget);
            Controls.Add(lblQuick);
            Controls.Add(flpChips);
            Controls.Add(lblDetails);
            Controls.Add(_txtReason);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSubmit);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReportDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Report Listing / Student";
            flpChips.ResumeLayout(false);
            flpChips.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private Label lblTarget;
        private Label lblQuick;
        private FlowLayoutPanel flpChips;
        private Button chipCash;
        private Button chipNoShow;
        private Button chipDishonesty;
        private Button chipSpam;
        private Label lblDetails;
        private TextBox _txtReason;
        private Button _btnCancel;
        private Button _btnSubmit;
        private ErrorProvider errorProvider1;
    }
}