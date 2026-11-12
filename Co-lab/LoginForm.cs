using System;
using System.Drawing;
using System.Windows.Forms;
using Co_LAB.UCAuth;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            ShowLogin();
        }

        public void LoadView(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.Show();
        }

        public void ShowLogin(string? prefilledEmail = null)
        {
            uc_Login uc = new uc_Login();
            if (!string.IsNullOrEmpty(prefilledEmail))
            {
                uc.SetEmail(prefilledEmail);
            }
            LoadView(uc);
        }

        public void ShowRegister()
        {
            LoadView(new uc_Register());
        }

        public void ShowForgotPassword()
        {
            LoadView(new uc_ForgotPassword());
        }

        private void lblUniversity_Click(object sender, EventArgs e)
        {

        }
    }
}

