namespace Co_LAB.UCAuth
{
    partial class uc_ForgotPassword
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
            pnlCenter = new Panel();
            pnlBackToLogin = new Panel();
            lnkBackToLogin = new LinkLabel();
            pnlStep2 = new Panel();
            btnResetPassword = new Button();
            lblConfirmPasswordError = new Label();
            pnlConfirmPassword = new Panel();
            btnToggleConfirmPassword = new Button();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            lblNewPasswordError = new Label();
            pnlNewPassword = new Panel();
            btnToggleNewPassword = new Button();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            lblAnswerError = new Label();
            txtAnswer = new TextBox();
            lblAnswer = new Label();
            pnlQuestionBox = new Panel();
            lblQuestionText = new Label();
            lblSecurityQuestionPrompt = new Label();
            lblStep2Error = new Label();
            lblSubtitleStep2 = new Label();
            lblTitleStep2 = new Label();
            pnlStep1 = new Panel();
            btnContinue = new Button();
            lblEmailError = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblStep1Error = new Label();
            lblSubtitleStep1 = new Label();
            lblTitleStep1 = new Label();
            pnlCenter.SuspendLayout();
            pnlBackToLogin.SuspendLayout();
            pnlStep2.SuspendLayout();
            pnlConfirmPassword.SuspendLayout();
            pnlNewPassword.SuspendLayout();
            pnlQuestionBox.SuspendLayout();
            pnlStep1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCenter
            // 
            pnlCenter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCenter.Controls.Add(pnlBackToLogin);
            pnlCenter.Controls.Add(pnlStep2);
            pnlCenter.Controls.Add(pnlStep1);
            pnlCenter.Location = new Point(95, 25);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(400, 545);
            pnlCenter.TabIndex = 0;
            // 
            // pnlBackToLogin
            // 
            pnlBackToLogin.Controls.Add(lnkBackToLogin);
            pnlBackToLogin.Dock = DockStyle.Bottom;
            pnlBackToLogin.Location = new Point(0, 510);
            pnlBackToLogin.Name = "pnlBackToLogin";
            pnlBackToLogin.Size = new Size(400, 35);
            pnlBackToLogin.TabIndex = 2;
            // 
            // lnkBackToLogin
            // 
            lnkBackToLogin.ActiveLinkColor = Color.FromArgb(110, 235, 150);
            lnkBackToLogin.Anchor = AnchorStyles.None;
            lnkBackToLogin.AutoSize = true;
            lnkBackToLogin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lnkBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkBackToLogin.LinkColor = Color.FromArgb(74, 222, 128);
            lnkBackToLogin.Location = new Point(148, 8);
            lnkBackToLogin.Name = "lnkBackToLogin";
            lnkBackToLogin.Size = new Size(99, 17);
            lnkBackToLogin.TabIndex = 0;
            lnkBackToLogin.TabStop = true;
            lnkBackToLogin.Text = "Back to Sign In";
            lnkBackToLogin.VisitedLinkColor = Color.FromArgb(74, 222, 128);
            lnkBackToLogin.LinkClicked += lnkBackToLogin_LinkClicked;
            // 
            // pnlStep2
            // 
            pnlStep2.Controls.Add(btnResetPassword);
            pnlStep2.Controls.Add(lblConfirmPasswordError);
            pnlStep2.Controls.Add(pnlConfirmPassword);
            pnlStep2.Controls.Add(lblConfirmPassword);
            pnlStep2.Controls.Add(lblNewPasswordError);
            pnlStep2.Controls.Add(pnlNewPassword);
            pnlStep2.Controls.Add(lblNewPassword);
            pnlStep2.Controls.Add(lblAnswerError);
            pnlStep2.Controls.Add(txtAnswer);
            pnlStep2.Controls.Add(lblAnswer);
            pnlStep2.Controls.Add(pnlQuestionBox);
            pnlStep2.Controls.Add(lblSecurityQuestionPrompt);
            pnlStep2.Controls.Add(lblStep2Error);
            pnlStep2.Controls.Add(lblSubtitleStep2);
            pnlStep2.Controls.Add(lblTitleStep2);
            pnlStep2.Dock = DockStyle.Fill;
            pnlStep2.Location = new Point(0, 0);
            pnlStep2.Name = "pnlStep2";
            pnlStep2.Size = new Size(400, 545);
            pnlStep2.TabIndex = 1;
            pnlStep2.Visible = false;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(46, 125, 70);
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(0, 460);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(400, 38);
            btnResetPassword.TabIndex = 14;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // lblConfirmPasswordError
            // 
            lblConfirmPasswordError.AutoSize = true;
            lblConfirmPasswordError.Font = new Font("Segoe UI", 8F);
            lblConfirmPasswordError.ForeColor = Color.FromArgb(239, 68, 68);
            lblConfirmPasswordError.Location = new Point(0, 436);
            lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            lblConfirmPasswordError.Size = new Size(130, 13);
            lblConfirmPasswordError.TabIndex = 13;
            lblConfirmPasswordError.Text = "Passwords do not match.";
            lblConfirmPasswordError.Visible = false;
            // 
            // pnlConfirmPassword
            // 
            pnlConfirmPassword.Controls.Add(btnToggleConfirmPassword);
            pnlConfirmPassword.Controls.Add(txtConfirmPassword);
            pnlConfirmPassword.Location = new Point(0, 406);
            pnlConfirmPassword.Name = "pnlConfirmPassword";
            pnlConfirmPassword.Size = new Size(400, 27);
            pnlConfirmPassword.TabIndex = 12;
            // 
            // btnToggleConfirmPassword
            // 
            btnToggleConfirmPassword.BackColor = Color.FromArgb(28, 38, 30);
            btnToggleConfirmPassword.Cursor = Cursors.Hand;
            btnToggleConfirmPassword.FlatAppearance.BorderSize = 0;
            btnToggleConfirmPassword.FlatStyle = FlatStyle.Flat;
            btnToggleConfirmPassword.Font = new Font("Segoe UI", 8.5F);
            btnToggleConfirmPassword.ForeColor = Color.White;
            btnToggleConfirmPassword.Location = new Point(360, 0);
            btnToggleConfirmPassword.Name = "btnToggleConfirmPassword";
            btnToggleConfirmPassword.Size = new Size(40, 26);
            btnToggleConfirmPassword.TabIndex = 1;
            btnToggleConfirmPassword.Text = "👁";
            btnToggleConfirmPassword.UseVisualStyleBackColor = false;
            btnToggleConfirmPassword.Click += btnToggleConfirmPassword_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(20, 28, 23);
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 9.5F);
            txtConfirmPassword.ForeColor = Color.White;
            txtConfirmPassword.Location = new Point(0, 1);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(355, 24);
            txtConfirmPassword.TabIndex = 0;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(180, 215, 195);
            lblConfirmPassword.Location = new Point(0, 386);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(134, 15);
            lblConfirmPassword.TabIndex = 11;
            lblConfirmPassword.Text = "Confirm New Password";
            // 
            // lblNewPasswordError
            // 
            lblNewPasswordError.AutoSize = true;
            lblNewPasswordError.Font = new Font("Segoe UI", 8F);
            lblNewPasswordError.ForeColor = Color.FromArgb(239, 68, 68);
            lblNewPasswordError.Location = new Point(0, 365);
            lblNewPasswordError.Name = "lblNewPasswordError";
            lblNewPasswordError.Size = new Size(167, 13);
            lblNewPasswordError.TabIndex = 10;
            lblNewPasswordError.Text = "Password must be >= 8 characters.";
            lblNewPasswordError.Visible = false;
            // 
            // pnlNewPassword
            // 
            pnlNewPassword.Controls.Add(btnToggleNewPassword);
            pnlNewPassword.Controls.Add(txtNewPassword);
            pnlNewPassword.Location = new Point(0, 335);
            pnlNewPassword.Name = "pnlNewPassword";
            pnlNewPassword.Size = new Size(400, 27);
            pnlNewPassword.TabIndex = 9;
            // 
            // btnToggleNewPassword
            // 
            btnToggleNewPassword.BackColor = Color.FromArgb(28, 38, 30);
            btnToggleNewPassword.Cursor = Cursors.Hand;
            btnToggleNewPassword.FlatAppearance.BorderSize = 0;
            btnToggleNewPassword.FlatStyle = FlatStyle.Flat;
            btnToggleNewPassword.Font = new Font("Segoe UI", 8.5F);
            btnToggleNewPassword.ForeColor = Color.White;
            btnToggleNewPassword.Location = new Point(360, 0);
            btnToggleNewPassword.Name = "btnToggleNewPassword";
            btnToggleNewPassword.Size = new Size(40, 26);
            btnToggleNewPassword.TabIndex = 1;
            btnToggleNewPassword.Text = "👁";
            btnToggleNewPassword.UseVisualStyleBackColor = false;
            btnToggleNewPassword.Click += btnToggleNewPassword_Click;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.FromArgb(20, 28, 23);
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 9.5F);
            txtNewPassword.ForeColor = Color.White;
            txtNewPassword.Location = new Point(0, 1);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(355, 24);
            txtNewPassword.TabIndex = 0;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(180, 215, 195);
            lblNewPassword.Location = new Point(0, 315);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(160, 15);
            lblNewPassword.TabIndex = 8;
            lblNewPassword.Text = "New Password (min 8 chars)";
            // 
            // lblAnswerError
            // 
            lblAnswerError.AutoSize = true;
            lblAnswerError.Font = new Font("Segoe UI", 8F);
            lblAnswerError.ForeColor = Color.FromArgb(239, 68, 68);
            lblAnswerError.Location = new Point(0, 294);
            lblAnswerError.Name = "lblAnswerError";
            lblAnswerError.Size = new Size(125, 13);
            lblAnswerError.TabIndex = 7;
            lblAnswerError.Text = "Security answer is req.";
            lblAnswerError.Visible = false;
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.FromArgb(20, 28, 23);
            txtAnswer.BorderStyle = BorderStyle.FixedSingle;
            txtAnswer.Font = new Font("Segoe UI", 10F);
            txtAnswer.ForeColor = Color.White;
            txtAnswer.Location = new Point(0, 266);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(400, 25);
            txtAnswer.TabIndex = 6;
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAnswer.ForeColor = Color.FromArgb(180, 215, 195);
            lblAnswer.Location = new Point(0, 246);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(95, 15);
            lblAnswer.TabIndex = 5;
            lblAnswer.Text = "Security Answer";
            // 
            // pnlQuestionBox
            // 
            pnlQuestionBox.BackColor = Color.FromArgb(20, 28, 23);
            pnlQuestionBox.Controls.Add(lblQuestionText);
            pnlQuestionBox.Location = new Point(0, 185);
            pnlQuestionBox.Name = "pnlQuestionBox";
            pnlQuestionBox.Padding = new Padding(10, 8, 10, 8);
            pnlQuestionBox.Size = new Size(400, 52);
            pnlQuestionBox.TabIndex = 4;
            // 
            // lblQuestionText
            // 
            lblQuestionText.Dock = DockStyle.Fill;
            lblQuestionText.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQuestionText.ForeColor = Color.FromArgb(74, 222, 128);
            lblQuestionText.Location = new Point(10, 8);
            lblQuestionText.Name = "lblQuestionText";
            lblQuestionText.Size = new Size(380, 36);
            lblQuestionText.TabIndex = 0;
            lblQuestionText.Text = "What was the name of your first pet?";
            // 
            // lblSecurityQuestionPrompt
            // 
            lblSecurityQuestionPrompt.AutoSize = true;
            lblSecurityQuestionPrompt.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSecurityQuestionPrompt.ForeColor = Color.FromArgb(180, 215, 195);
            lblSecurityQuestionPrompt.Location = new Point(0, 165);
            lblSecurityQuestionPrompt.Name = "lblSecurityQuestionPrompt";
            lblSecurityQuestionPrompt.Size = new Size(153, 15);
            lblSecurityQuestionPrompt.TabIndex = 3;
            lblSecurityQuestionPrompt.Text = "Registered Security Question";
            // 
            // lblStep2Error
            // 
            lblStep2Error.Font = new Font("Segoe UI", 8.5F);
            lblStep2Error.ForeColor = Color.FromArgb(239, 68, 68);
            lblStep2Error.Location = new Point(0, 95);
            lblStep2Error.Name = "lblStep2Error";
            lblStep2Error.Size = new Size(400, 60);
            lblStep2Error.TabIndex = 2;
            lblStep2Error.Text = "Error message";
            lblStep2Error.Visible = false;
            // 
            // lblSubtitleStep2
            // 
            lblSubtitleStep2.AutoSize = true;
            lblSubtitleStep2.Font = new Font("Segoe UI", 9.5F);
            lblSubtitleStep2.ForeColor = Color.FromArgb(130, 175, 145);
            lblSubtitleStep2.Location = new Point(0, 50);
            lblSubtitleStep2.Name = "lblSubtitleStep2";
            lblSubtitleStep2.Size = new Size(309, 17);
            lblSubtitleStep2.TabIndex = 1;
            lblSubtitleStep2.Text = "Answer your security question to set a new password";
            // 
            // lblTitleStep2
            // 
            lblTitleStep2.AutoSize = true;
            lblTitleStep2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitleStep2.ForeColor = Color.White;
            lblTitleStep2.Location = new Point(0, 12);
            lblTitleStep2.Name = "lblTitleStep2";
            lblTitleStep2.Size = new Size(241, 32);
            lblTitleStep2.TabIndex = 0;
            lblTitleStep2.Text = "Security Verification";
            // 
            // pnlStep1
            // 
            pnlStep1.Controls.Add(btnContinue);
            pnlStep1.Controls.Add(lblEmailError);
            pnlStep1.Controls.Add(txtEmail);
            pnlStep1.Controls.Add(lblEmail);
            pnlStep1.Controls.Add(lblStep1Error);
            pnlStep1.Controls.Add(lblSubtitleStep1);
            pnlStep1.Controls.Add(lblTitleStep1);
            pnlStep1.Dock = DockStyle.Fill;
            pnlStep1.Location = new Point(0, 0);
            pnlStep1.Name = "pnlStep1";
            pnlStep1.Size = new Size(400, 545);
            pnlStep1.TabIndex = 0;
            // 
            // btnContinue
            // 
            btnContinue.BackColor = Color.FromArgb(46, 125, 70);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.Location = new Point(0, 310);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(400, 42);
            btnContinue.TabIndex = 6;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // lblEmailError
            // 
            lblEmailError.AutoSize = true;
            lblEmailError.Font = new Font("Segoe UI", 8.25F);
            lblEmailError.ForeColor = Color.FromArgb(239, 68, 68);
            lblEmailError.Location = new Point(0, 265);
            lblEmailError.Name = "lblEmailError";
            lblEmailError.Size = new Size(187, 13);
            lblEmailError.TabIndex = 5;
            lblEmailError.Text = "Please use your @ue.edu.ph email.";
            lblEmailError.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(20, 28, 23);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(0, 232);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 27);
            txtEmail.TabIndex = 4;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(180, 215, 195);
            lblEmail.Location = new Point(0, 208);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "UE Email Address";
            // 
            // lblStep1Error
            // 
            lblStep1Error.Font = new Font("Segoe UI", 9F);
            lblStep1Error.ForeColor = Color.FromArgb(239, 68, 68);
            lblStep1Error.Location = new Point(0, 105);
            lblStep1Error.Name = "lblStep1Error";
            lblStep1Error.Size = new Size(400, 85);
            lblStep1Error.TabIndex = 2;
            lblStep1Error.Text = "Error message";
            lblStep1Error.Visible = false;
            // 
            // lblSubtitleStep1
            // 
            lblSubtitleStep1.AutoSize = true;
            lblSubtitleStep1.Font = new Font("Segoe UI", 9.5F);
            lblSubtitleStep1.ForeColor = Color.FromArgb(130, 175, 145);
            lblSubtitleStep1.Location = new Point(0, 52);
            lblSubtitleStep1.Name = "lblSubtitleStep1";
            lblSubtitleStep1.Size = new Size(265, 17);
            lblSubtitleStep1.TabIndex = 1;
            lblSubtitleStep1.Text = "Enter your UE email to verify your security question";
            // 
            // lblTitleStep1
            // 
            lblTitleStep1.AutoSize = true;
            lblTitleStep1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitleStep1.ForeColor = Color.White;
            lblTitleStep1.Location = new Point(0, 14);
            lblTitleStep1.Name = "lblTitleStep1";
            lblTitleStep1.Size = new Size(204, 32);
            lblTitleStep1.TabIndex = 0;
            lblTitleStep1.Text = "Forgot Password";
            // 
            // uc_ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlCenter);
            Name = "uc_ForgotPassword";
            Size = new Size(590, 600);
            Load += uc_ForgotPassword_Load;
            pnlCenter.ResumeLayout(false);
            pnlBackToLogin.ResumeLayout(false);
            pnlBackToLogin.PerformLayout();
            pnlStep2.ResumeLayout(false);
            pnlStep2.PerformLayout();
            pnlConfirmPassword.ResumeLayout(false);
            pnlConfirmPassword.PerformLayout();
            pnlNewPassword.ResumeLayout(false);
            pnlNewPassword.PerformLayout();
            pnlQuestionBox.ResumeLayout(false);
            pnlStep1.ResumeLayout(false);
            pnlStep1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCenter;
        private Panel pnlStep1;
        private Label lblTitleStep1;
        private Label lblSubtitleStep1;
        private Label lblStep1Error;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEmailError;
        private Button btnContinue;
        private Panel pnlStep2;
        private Label lblTitleStep2;
        private Label lblSubtitleStep2;
        private Label lblStep2Error;
        private Label lblSecurityQuestionPrompt;
        private Panel pnlQuestionBox;
        private Label lblQuestionText;
        private Label lblAnswer;
        private TextBox txtAnswer;
        private Label lblAnswerError;
        private Label lblNewPassword;
        private Panel pnlNewPassword;
        private TextBox txtNewPassword;
        private Button btnToggleNewPassword;
        private Label lblNewPasswordError;
        private Label lblConfirmPassword;
        private Panel pnlConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnToggleConfirmPassword;
        private Label lblConfirmPasswordError;
        private Button btnResetPassword;
        private Panel pnlBackToLogin;
        private LinkLabel lnkBackToLogin;
    }
}

