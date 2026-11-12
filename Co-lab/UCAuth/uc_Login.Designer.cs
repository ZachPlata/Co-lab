namespace Co_LAB.UCAuth
{
    partial class uc_Login
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
            lnkTos = new LinkLabel();
            lblDivider = new Label();
            lnkRegister = new LinkLabel();
            lblNoAccount = new Label();
            btnLogin = new Button();
            lblPasswordError = new Label();
            pnlPasswordWrapper = new Panel();
            btnTogglePassword = new Button();
            txtPassword = new TextBox();
            lnkForgotPassword = new LinkLabel();
            lblPassword = new Label();
            lblEmailError = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            lblGeneralError = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlCenter.SuspendLayout();
            pnlPasswordWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCenter
            // 
            pnlCenter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCenter.Controls.Add(lnkTos);
            pnlCenter.Controls.Add(lblDivider);
            pnlCenter.Controls.Add(lnkRegister);
            pnlCenter.Controls.Add(lblNoAccount);
            pnlCenter.Controls.Add(btnLogin);
            pnlCenter.Controls.Add(lblPasswordError);
            pnlCenter.Controls.Add(pnlPasswordWrapper);
            pnlCenter.Controls.Add(lnkForgotPassword);
            pnlCenter.Controls.Add(lblPassword);
            pnlCenter.Controls.Add(lblEmailError);
            pnlCenter.Controls.Add(txtEmail);
            pnlCenter.Controls.Add(lblEmail);
            pnlCenter.Controls.Add(lblGeneralError);
            pnlCenter.Controls.Add(lblSubtitle);
            pnlCenter.Controls.Add(lblTitle);
            pnlCenter.Location = new Point(95, 30);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Size = new Size(400, 530);
            pnlCenter.TabIndex = 0;
            // 
            // lnkTos
            // 
            lnkTos.ActiveLinkColor = Color.FromArgb(74, 222, 128);
            lnkTos.AutoSize = true;
            lnkTos.Font = new Font("Segoe UI", 9F);
            lnkTos.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkTos.LinkColor = Color.FromArgb(130, 175, 145);
            lnkTos.Location = new Point(152, 480);
            lnkTos.Name = "lnkTos";
            lnkTos.Size = new Size(95, 15);
            lnkTos.TabIndex = 14;
            lnkTos.TabStop = true;
            lnkTos.Text = "Terms of Service";
            lnkTos.VisitedLinkColor = Color.FromArgb(130, 175, 145);
            lnkTos.LinkClicked += lnkTos_LinkClicked;
            // 
            // lblDivider
            // 
            lblDivider.AutoSize = true;
            lblDivider.ForeColor = Color.FromArgb(113, 113, 122);
            lblDivider.Location = new Point(236, 437);
            lblDivider.Name = "lblDivider";
            lblDivider.Size = new Size(12, 15);
            lblDivider.TabIndex = 13;
            lblDivider.Text = "•";
            // 
            // lnkRegister
            // 
            lnkRegister.ActiveLinkColor = Color.FromArgb(110, 235, 150);
            lnkRegister.AutoSize = true;
            lnkRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lnkRegister.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkRegister.LinkColor = Color.FromArgb(74, 222, 128);
            lnkRegister.Location = new Point(250, 437);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(92, 15);
            lnkRegister.TabIndex = 12;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Create account";
            lnkRegister.VisitedLinkColor = Color.FromArgb(74, 222, 128);
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // lblNoAccount
            // 
            lblNoAccount.AutoSize = true;
            lblNoAccount.Font = new Font("Segoe UI", 9F);
            lblNoAccount.ForeColor = Color.FromArgb(161, 161, 170);
            lblNoAccount.Location = new Point(78, 437);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(157, 15);
            lblNoAccount.TabIndex = 11;
            lblNoAccount.Text = "Don't have an account yet?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 125, 70);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 360);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 42);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblPasswordError
            // 
            lblPasswordError.AutoSize = true;
            lblPasswordError.Font = new Font("Segoe UI", 8.25F);
            lblPasswordError.ForeColor = Color.FromArgb(239, 68, 68);
            lblPasswordError.Location = new Point(0, 315);
            lblPasswordError.Name = "lblPasswordError";
            lblPasswordError.Size = new Size(118, 13);
            lblPasswordError.TabIndex = 9;
            lblPasswordError.Text = "Password is required.";
            lblPasswordError.Visible = false;
            // 
            // pnlPasswordWrapper
            // 
            pnlPasswordWrapper.Controls.Add(btnTogglePassword);
            pnlPasswordWrapper.Controls.Add(txtPassword);
            pnlPasswordWrapper.Location = new Point(0, 280);
            pnlPasswordWrapper.Name = "pnlPasswordWrapper";
            pnlPasswordWrapper.Size = new Size(400, 32);
            pnlPasswordWrapper.TabIndex = 8;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.FromArgb(28, 38, 30);
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderColor = Color.FromArgb(42, 60, 48);
            btnTogglePassword.FlatAppearance.BorderSize = 1;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI", 9F);
            btnTogglePassword.ForeColor = Color.White;
            btnTogglePassword.Location = new Point(356, 0);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(44, 30);
            btnTogglePassword.TabIndex = 1;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(20, 28, 23);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(0, 1);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(350, 27);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtInput_KeyDown;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.ActiveLinkColor = Color.FromArgb(110, 235, 150);
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 8.5F);
            lnkForgotPassword.LinkBehavior = LinkBehavior.HoverUnderline;
            lnkForgotPassword.LinkColor = Color.FromArgb(74, 222, 128);
            lnkForgotPassword.Location = new Point(300, 255);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(100, 15);
            lnkForgotPassword.TabIndex = 7;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Forgot password?";
            lnkForgotPassword.VisitedLinkColor = Color.FromArgb(74, 222, 128);
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(180, 215, 195);
            lblPassword.Location = new Point(0, 255);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // lblEmailError
            // 
            lblEmailError.AutoSize = true;
            lblEmailError.Font = new Font("Segoe UI", 8.25F);
            lblEmailError.ForeColor = Color.FromArgb(239, 68, 68);
            lblEmailError.Location = new Point(0, 225);
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
            txtEmail.Location = new Point(0, 192);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 27);
            txtEmail.TabIndex = 4;
            txtEmail.KeyDown += txtInput_KeyDown;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(180, 215, 195);
            lblEmail.Location = new Point(0, 168);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(106, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "UE Email Address";
            // 
            // lblGeneralError
            // 
            lblGeneralError.Font = new Font("Segoe UI", 9F);
            lblGeneralError.ForeColor = Color.FromArgb(239, 68, 68);
            lblGeneralError.Location = new Point(0, 85);
            lblGeneralError.Name = "lblGeneralError";
            lblGeneralError.Size = new Size(400, 68);
            lblGeneralError.TabIndex = 2;
            lblGeneralError.Text = "Error message goes here";
            lblGeneralError.Visible = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(130, 175, 145);
            lblSubtitle.Location = new Point(0, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(244, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Sign in to access student skills & trading";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(187, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome back!";
            // 
            // uc_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 20, 16);
            Controls.Add(pnlCenter);
            Name = "uc_Login";
            Size = new Size(590, 600);
            Load += uc_Login_Load;
            pnlCenter.ResumeLayout(false);
            pnlCenter.PerformLayout();
            pnlPasswordWrapper.ResumeLayout(false);
            pnlPasswordWrapper.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCenter;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblGeneralError;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblEmailError;
        private Label lblPassword;
        private LinkLabel lnkForgotPassword;
        private Panel pnlPasswordWrapper;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private Label lblPasswordError;
        private Button btnLogin;
        private Label lblNoAccount;
        private LinkLabel lnkRegister;
        private Label lblDivider;
        private LinkLabel lnkTos;
    }
}

