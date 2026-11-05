namespace Co_LAB.UCAuth
{
    partial class uc_Register
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
            pnlScrollContainer = new Panel();
            pnlCenter = new Panel();
            pnlBackToLogin = new Panel();
            lnkBackToLogin = new LinkLabel();
            lblAlreadyHaveAccount = new Label();
            btnRegister = new Button();
            pnlTos = new Panel();
            lnkReadTos = new LinkLabel();
            chkTos = new CheckBox();
            lblSecurityAnswerError = new Label();
            txtSecurityAnswer = new TextBox();
            lblSecurityAnswer = new Label();
            lblSecurityQuestionError = new Label();
            cmbSecurityQuestion = new ComboBox();
            lblSecurityQuestion = new Label();
            lblConfirmPasswordError = new Label();
            pnlConfirmPassword = new Panel();
            btnToggleConfirm = new Button();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            lblPasswordError = new Label();
            pnlPassword = new Panel();
            btnTogglePassword = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            lblEmailError = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblFullNameError = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblGeneralError = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlScrollContainer.SuspendLayout();
            pnlCenter.SuspendLayout();
            pnlBackToLogin.SuspendLayout();
            pnlTos.SuspendLayout();
            pnlConfirmPassword.SuspendLayout();
            pnlPassword.SuspendLayout();
            SuspendLayout();
            // 
            // pnlScrollContainer
            // 
            pnlScrollContainer.AutoScroll = true;
            pnlScrollContainer.Controls.Add(pnlCenter);
            pnlScrollContainer.Dock = DockStyle.Fill;
            pnlScrollContainer.Location = new Point(0, 0);
            pnlScrollContainer.Name = "pnlScrollContainer";
            pnlScrollContainer.Size = new Size(590, 600);
            pnlScrollContainer.TabIndex = 0;
            // 
            // pnlCenter
            // 
            pnlCenter.Anchor = AnchorStyles.Top;
            pnlCenter.Controls.Add(pnlBackToLogin);
            pnlCenter.Controls.Add(btnRegister);
            pnlCenter.Controls.Add(pnlTos);
            pnlCenter.Controls.Add(lblSecurityAnswerError);
            pnlCenter.Controls.Add(txtSecurityAnswer);
            pnlCenter.Controls.Add(lblSecurityAnswer);
            pnlCenter.Controls.Add(lblSecurityQuestionError);
            pnlCenter.Controls.Add(cmbSecurityQuestion);
            pnlCenter.Controls.Add(lblSecurityQuestion);
            pnlCenter.Controls.Add(lblConfirmPasswordError);
            pnlCenter.Controls.Add(pnlConfirmPassword);
            pnlCenter.Controls.Add(lblConfirmPassword);
            pnlCenter.Controls.Add(lblPasswordError);
            pnlCenter.Controls.Add(pnlPassword);
            pnlCenter.Controls.Add(lblPassword);
            pnlCenter.Controls.Add(lblEmailError);
            pnlCenter.Controls.Add(txtEmail);
            pnlCenter.Controls.Add(lblEmail);
            pnlCenter.Controls.Add(lblFullNameError);
            pnlCenter.Controls.Add(txtFullName);
            pnlCenter.Controls.Add(lblFullName);
            pnlCenter.Controls.Add(lblGeneralError);
            pnlCenter.Controls.Add(lblSubtitle);
            pnlCenter.Controls.Add(lblTitle);
            pnlCenter.Location = new Point(85, 12);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(420, 570);
            pnlCenter.TabIndex = 0;
            // 
            // pnlBackToLogin
            // 
            pnlBackToLogin.Controls.Add(lnkBackToLogin);
            pnlBackToLogin.Controls.Add(lblAlreadyHaveAccount);
            pnlBackToLogin.Location = new Point(0, 538);
            pnlBackToLogin.Name = "pnlBackToLogin";
            pnlBackToLogin.Size = new Size(410, 24);
            pnlBackToLogin.TabIndex = 23;
            // 
            // lnkBackToLogin
            // 
            lnkBackToLogin.ActiveLinkColor = Color.FromArgb(52, 211, 153);
            lnkBackToLogin.AutoSize = true;
            lnkBackToLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lnkBackToLogin.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkBackToLogin.LinkColor = Color.FromArgb(16, 185, 129);
            lnkBackToLogin.Location = new Point(236, 3);
            lnkBackToLogin.Name = "lnkBackToLogin";
            lnkBackToLogin.Size = new Size(95, 15);
            lnkBackToLogin.TabIndex = 1;
            lnkBackToLogin.TabStop = true;
            lnkBackToLogin.Text = "Back to Sign In";
            lnkBackToLogin.VisitedLinkColor = Color.FromArgb(16, 185, 129);
            lnkBackToLogin.LinkClicked += lnkBackToLogin_LinkClicked;
            // 
            // lblAlreadyHaveAccount
            // 
            lblAlreadyHaveAccount.AutoSize = true;
            lblAlreadyHaveAccount.Font = new Font("Segoe UI", 9F);
            lblAlreadyHaveAccount.ForeColor = Color.FromArgb(161, 161, 170);
            lblAlreadyHaveAccount.Location = new Point(86, 3);
            lblAlreadyHaveAccount.Name = "lblAlreadyHaveAccount";
            lblAlreadyHaveAccount.Size = new Size(145, 15);
            lblAlreadyHaveAccount.TabIndex = 0;
            lblAlreadyHaveAccount.Text = "Already have an account?";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(39, 39, 42);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Enabled = false;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.FromArgb(113, 113, 122);
            btnRegister.Location = new Point(0, 494);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(410, 38);
            btnRegister.TabIndex = 22;
            btnRegister.Text = "Create Account";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // pnlTos
            // 
            pnlTos.Controls.Add(lnkReadTos);
            pnlTos.Controls.Add(chkTos);
            pnlTos.Location = new Point(0, 464);
            pnlTos.Name = "pnlTos";
            pnlTos.Size = new Size(410, 24);
            pnlTos.TabIndex = 21;
            // 
            // lnkReadTos
            // 
            lnkReadTos.ActiveLinkColor = Color.FromArgb(52, 211, 153);
            lnkReadTos.AutoSize = true;
            lnkReadTos.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lnkReadTos.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkReadTos.LinkColor = Color.FromArgb(16, 185, 129);
            lnkReadTos.Location = new Point(190, 4);
            lnkReadTos.Name = "lnkReadTos";
            lnkReadTos.Size = new Size(127, 15);
            lnkReadTos.TabIndex = 1;
            lnkReadTos.TabStop = true;
            lnkReadTos.Text = "(Read Terms of Service)";
            lnkReadTos.VisitedLinkColor = Color.FromArgb(16, 185, 129);
            lnkReadTos.LinkClicked += lnkReadTos_LinkClicked;
            // 
            // chkTos
            // 
            chkTos.AutoSize = true;
            chkTos.Cursor = Cursors.Hand;
            chkTos.Enabled = false;
            chkTos.Font = new Font("Segoe UI", 8.5F);
            chkTos.ForeColor = Color.FromArgb(161, 161, 170);
            chkTos.Location = new Point(0, 3);
            chkTos.Name = "chkTos";
            chkTos.Size = new Size(183, 19);
            chkTos.TabIndex = 0;
            chkTos.Text = "I agree to the Terms of Service";
            chkTos.UseVisualStyleBackColor = true;
            chkTos.CheckedChanged += inputField_Changed;
            // 
            // lblSecurityAnswerError
            // 
            lblSecurityAnswerError.AutoSize = true;
            lblSecurityAnswerError.Font = new Font("Segoe UI", 8F);
            lblSecurityAnswerError.ForeColor = Color.FromArgb(239, 68, 68);
            lblSecurityAnswerError.Location = new Point(0, 446);
            lblSecurityAnswerError.Name = "lblSecurityAnswerError";
            lblSecurityAnswerError.Size = new Size(174, 13);
            lblSecurityAnswerError.TabIndex = 20;
            lblSecurityAnswerError.Text = "Security answer is required (min 2).";
            lblSecurityAnswerError.Visible = false;
            // 
            // txtSecurityAnswer
            // 
            txtSecurityAnswer.BackColor = Color.FromArgb(39, 39, 42);
            txtSecurityAnswer.BorderStyle = BorderStyle.FixedSingle;
            txtSecurityAnswer.Font = new Font("Segoe UI", 9.5F);
            txtSecurityAnswer.ForeColor = Color.White;
            txtSecurityAnswer.Location = new Point(0, 420);
            txtSecurityAnswer.Name = "txtSecurityAnswer";
            txtSecurityAnswer.Size = new Size(410, 24);
            txtSecurityAnswer.TabIndex = 19;
            txtSecurityAnswer.TextChanged += inputField_Changed;
            // 
            // lblSecurityAnswer
            // 
            lblSecurityAnswer.AutoSize = true;
            lblSecurityAnswer.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSecurityAnswer.ForeColor = Color.FromArgb(161, 161, 170);
            lblSecurityAnswer.Location = new Point(0, 402);
            lblSecurityAnswer.Name = "lblSecurityAnswer";
            lblSecurityAnswer.Size = new Size(95, 15);
            lblSecurityAnswer.TabIndex = 18;
            lblSecurityAnswer.Text = "Security Answer";
            // 
            // lblSecurityQuestionError
            // 
            lblSecurityQuestionError.AutoSize = true;
            lblSecurityQuestionError.Font = new Font("Segoe UI", 8F);
            lblSecurityQuestionError.ForeColor = Color.FromArgb(239, 68, 68);
            lblSecurityQuestionError.Location = new Point(0, 385);
            lblSecurityQuestionError.Name = "lblSecurityQuestionError";
            lblSecurityQuestionError.Size = new Size(167, 13);
            lblSecurityQuestionError.TabIndex = 17;
            lblSecurityQuestionError.Text = "Please select a security question.";
            lblSecurityQuestionError.Visible = false;
            // 
            // cmbSecurityQuestion
            // 
            cmbSecurityQuestion.BackColor = Color.FromArgb(39, 39, 42);
            cmbSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSecurityQuestion.FlatStyle = FlatStyle.Flat;
            cmbSecurityQuestion.Font = new Font("Segoe UI", 9F);
            cmbSecurityQuestion.ForeColor = Color.White;
            cmbSecurityQuestion.FormattingEnabled = true;
            cmbSecurityQuestion.Items.AddRange(new object[] {
            "What was the name of your first pet?",
            "What city were you born in?",
            "What is your mother's maiden name?",
            "What was the name of your elementary school?",
            "What is your favorite childhood nickname?"});
            cmbSecurityQuestion.Location = new Point(0, 358);
            cmbSecurityQuestion.Name = "cmbSecurityQuestion";
            cmbSecurityQuestion.Size = new Size(410, 23);
            cmbSecurityQuestion.TabIndex = 16;
            cmbSecurityQuestion.SelectedIndexChanged += inputField_Changed;
            // 
            // lblSecurityQuestion
            // 
            lblSecurityQuestion.AutoSize = true;
            lblSecurityQuestion.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSecurityQuestion.ForeColor = Color.FromArgb(161, 161, 170);
            lblSecurityQuestion.Location = new Point(0, 340);
            lblSecurityQuestion.Name = "lblSecurityQuestion";
            lblSecurityQuestion.Size = new Size(106, 15);
            lblSecurityQuestion.TabIndex = 15;
            lblSecurityQuestion.Text = "Security Question";
            // 
            // lblConfirmPasswordError
            // 
            lblConfirmPasswordError.AutoSize = true;
            lblConfirmPasswordError.Font = new Font("Segoe UI", 8F);
            lblConfirmPasswordError.ForeColor = Color.FromArgb(239, 68, 68);
            lblConfirmPasswordError.Location = new Point(210, 323);
            lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            lblConfirmPasswordError.Size = new Size(130, 13);
            lblConfirmPasswordError.TabIndex = 14;
            lblConfirmPasswordError.Text = "Passwords do not match.";
            lblConfirmPasswordError.Visible = false;
            // 
            // pnlConfirmPassword
            // 
            pnlConfirmPassword.Controls.Add(btnToggleConfirm);
            pnlConfirmPassword.Controls.Add(txtConfirmPassword);
            pnlConfirmPassword.Location = new Point(210, 294);
            pnlConfirmPassword.Name = "pnlConfirmPassword";
            pnlConfirmPassword.Size = new Size(200, 27);
            pnlConfirmPassword.TabIndex = 13;
            // 
            // btnToggleConfirm
            // 
            btnToggleConfirm.BackColor = Color.FromArgb(45, 45, 50);
            btnToggleConfirm.Cursor = Cursors.Hand;
            btnToggleConfirm.FlatAppearance.BorderSize = 0;
            btnToggleConfirm.FlatStyle = FlatStyle.Flat;
            btnToggleConfirm.Font = new Font("Segoe UI", 8.5F);
            btnToggleConfirm.ForeColor = Color.White;
            btnToggleConfirm.Location = new Point(164, 0);
            btnToggleConfirm.Name = "btnToggleConfirm";
            btnToggleConfirm.Size = new Size(36, 25);
            btnToggleConfirm.TabIndex = 1;
            btnToggleConfirm.Text = "👁";
            btnToggleConfirm.UseVisualStyleBackColor = false;
            btnToggleConfirm.Click += btnToggleConfirm_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.FromArgb(39, 39, 42);
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 9.5F);
            txtConfirmPassword.ForeColor = Color.White;
            txtConfirmPassword.Location = new Point(0, 0);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(160, 24);
            txtConfirmPassword.TabIndex = 0;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.TextChanged += inputField_Changed;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(161, 161, 170);
            lblConfirmPassword.Location = new Point(210, 276);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(107, 15);
            lblConfirmPassword.TabIndex = 12;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPasswordError
            // 
            lblPasswordError.AutoSize = true;
            lblPasswordError.Font = new Font("Segoe UI", 8F);
            lblPasswordError.ForeColor = Color.FromArgb(239, 68, 68);
            lblPasswordError.Location = new Point(0, 323);
            lblPasswordError.Name = "lblPasswordError";
            lblPasswordError.Size = new Size(111, 13);
            lblPasswordError.TabIndex = 11;
            lblPasswordError.Text = "Min. 8 characters req.";
            lblPasswordError.Visible = false;
            // 
            // pnlPassword
            // 
            pnlPassword.Controls.Add(btnTogglePassword);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Location = new Point(0, 294);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(200, 27);
            pnlPassword.TabIndex = 10;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.FromArgb(45, 45, 50);
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI", 8.5F);
            btnTogglePassword.ForeColor = Color.White;
            btnTogglePassword.Location = new Point(164, 0);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(36, 25);
            btnTogglePassword.TabIndex = 1;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(39, 39, 42);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 9.5F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(160, 24);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += inputField_Changed;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(161, 161, 170);
            lblPassword.Location = new Point(0, 276);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 15);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password";
            // 
            // lblEmailError
            // 
            lblEmailError.AutoSize = true;
            lblEmailError.Font = new Font("Segoe UI", 8F);
            lblEmailError.ForeColor = Color.FromArgb(239, 68, 68);
            lblEmailError.Location = new Point(0, 258);
            lblEmailError.Name = "lblEmailError";
            lblEmailError.Size = new Size(187, 13);
            lblEmailError.TabIndex = 8;
            lblEmailError.Text = "Please use your @ue.edu.ph email.";
            lblEmailError.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(39, 39, 42);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(0, 231);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(410, 24);
            txtEmail.TabIndex = 7;
            txtEmail.TextChanged += inputField_Changed;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(161, 161, 170);
            lblEmail.Location = new Point(0, 213);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "UE Email Address";
            // 
            // lblFullNameError
            // 
            lblFullNameError.AutoSize = true;
            lblFullNameError.Font = new Font("Segoe UI", 8F);
            lblFullNameError.ForeColor = Color.FromArgb(239, 68, 68);
            lblFullNameError.Location = new Point(0, 195);
            lblFullNameError.Name = "lblFullNameError";
            lblFullNameError.Size = new Size(125, 13);
            lblFullNameError.TabIndex = 5;
            lblFullNameError.Text = "Full name is required.";
            lblFullNameError.Visible = false;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.FromArgb(39, 39, 42);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.ForeColor = Color.White;
            txtFullName.Location = new Point(0, 168);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(410, 24);
            txtFullName.TabIndex = 4;
            txtFullName.TextChanged += inputField_Changed;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(161, 161, 170);
            lblFullName.Location = new Point(0, 150);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(62, 15);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Full Name";
            // 
            // lblGeneralError
            // 
            lblGeneralError.Font = new Font("Segoe UI", 8.5F);
            lblGeneralError.ForeColor = Color.FromArgb(239, 68, 68);
            lblGeneralError.Location = new Point(0, 68);
            lblGeneralError.Name = "lblGeneralError";
            lblGeneralError.Size = new Size(410, 75);
            lblGeneralError.TabIndex = 2;
            lblGeneralError.Text = "Error message goes here";
            lblGeneralError.Visible = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(161, 161, 170);
            lblSubtitle.Location = new Point(0, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(236, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Join Co-LAB with your @ue.edu.ph credentials";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Account";
            // 
            // uc_Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 27);
            Controls.Add(pnlScrollContainer);
            Name = "uc_Register";
            Size = new Size(590, 600);
            Load += uc_Register_Load;
            pnlScrollContainer.ResumeLayout(false);
            pnlCenter.ResumeLayout(false);
            pnlCenter.PerformLayout();
            pnlBackToLogin.ResumeLayout(false);
            pnlBackToLogin.PerformLayout();
            pnlTos.ResumeLayout(false);
            pnlTos.PerformLayout();
            pnlConfirmPassword.ResumeLayout(false);
            pnlConfirmPassword.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlScrollContainer;
        private Panel pnlCenter;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblGeneralError;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblFullNameError;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEmailError;
        private Label lblPassword;
        private Panel pnlPassword;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private Label lblPasswordError;
        private Label lblConfirmPassword;
        private Panel pnlConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnToggleConfirm;
        private Label lblConfirmPasswordError;
        private Label lblSecurityQuestion;
        private ComboBox cmbSecurityQuestion;
        private Label lblSecurityQuestionError;
        private Label lblSecurityAnswer;
        private TextBox txtSecurityAnswer;
        private Label lblSecurityAnswerError;
        private Panel pnlTos;
        private CheckBox chkTos;
        private LinkLabel lnkReadTos;
        private Button btnRegister;
        private Panel pnlBackToLogin;
        private Label lblAlreadyHaveAccount;
        private LinkLabel lnkBackToLogin;
    }
}

