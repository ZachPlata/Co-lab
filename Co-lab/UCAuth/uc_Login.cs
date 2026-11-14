using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB.UCAuth
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_Login : UserControl
    {
        private static readonly Regex EmailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@ue\.edu\.ph$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public uc_Login()
        {
            InitializeComponent();
        }

        private void uc_Login_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            if (ParentForm != null)
            {
                ParentForm.AcceptButton = btnLogin;
            }
        }

        public void SetEmail(string email)
        {
            txtEmail.Text = email;
            txtPassword.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;
            lblGeneralError.Visible = false;

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(email))
            {
                lblEmailError.Text = "Email is required.";
                lblEmailError.Visible = true;
                hasError = true;
            }
            else if (!EmailRegex.IsMatch(email))
            {
                lblEmailError.Text = "Please use your @ue.edu.ph email.";
                lblEmailError.Visible = true;
                hasError = true;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblPasswordError.Text = "Password is required.";
                lblPasswordError.Visible = true;
                hasError = true;
            }

            if (hasError)
            {
                return;
            }

            try
            {
                string query = @"SELECT UserId, FullName, Email, Password, Role, is_blacklisted, BanReason,
                                        is_logged_in, last_active,
                                        TIMESTAMPDIFF(SECOND, last_active, NOW()) AS inactive_seconds
                                 FROM tbl_users WHERE Email = @Email LIMIT 1";
                DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@Email", email));

                if (dt.Rows.Count == 0)
                {
                    lblGeneralError.Text = "Invalid email or password.";
                    lblGeneralError.Visible = true;
                    return;
                }

                DataRow row = dt.Rows[0];
                string storedPassword = row["Password"]?.ToString() ?? "";

                if (!AuthHelper.VerifyPassword(password, storedPassword))
                {
                    lblGeneralError.Text = "Invalid email or password.";
                    lblGeneralError.Visible = true;
                    return;
                }

                int isBlacklisted = 0;
                if (row["is_blacklisted"] != DBNull.Value)
                {
                    isBlacklisted = Convert.ToInt32(row["is_blacklisted"]);
                }

                if (isBlacklisted == 1)
                {
                    string banReason = row["BanReason"]?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(banReason))
                    {
                        lblGeneralError.Text = $"This account has been suspended.\nReason: {banReason}";
                    }
                    else
                    {
                        lblGeneralError.Text = "This account has been suspended.";
                    }
                    lblGeneralError.Visible = true;
                    return;
                }

                int userId = Convert.ToInt32(row["UserId"]);
                string fullName = row["FullName"]?.ToString() ?? "";
                string role = row["Role"]?.ToString() ?? "Student";

                // Check if account is actively logged in on another device
                int isLoggedIn = 0;
                if (row["is_logged_in"] != DBNull.Value)
                {
                    isLoggedIn = Convert.ToInt32(row["is_logged_in"]);
                }

                bool isActiveOnOtherDevice = false;
                if (isLoggedIn == 1 && row["last_active"] != DBNull.Value && row["inactive_seconds"] != DBNull.Value)
                {
                    long seconds = Convert.ToInt64(row["inactive_seconds"]);
                    // Active if last heartbeat was within the last 30 seconds
                    if (seconds >= -5 && seconds < 30)
                    {
                        isActiveOnOtherDevice = true;
                    }
                }

                if (isActiveOnOtherDevice)
                {
                    lblGeneralError.Text = "This account is currently active on another device.\nPlease sign out from that device first.";
                    lblGeneralError.Visible = true;
                    return;
                }

                // Generate new session token and register session in DB
                string newSessionId = Guid.NewGuid().ToString("N");
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE tbl_users SET is_logged_in = 1, last_active = NOW(), session_id = @sid WHERE UserId = @uid",
                    new MySqlParameter("@sid", newSessionId),
                    new MySqlParameter("@uid", userId)
                );

                UserSession.Set(userId, fullName, email, role, newSessionId);

                if (ParentForm is LoginForm loginForm)
                {
                    loginForm.DialogResult = DialogResult.OK;
                    loginForm.Close();
                }
            }
            catch (MySqlException ex)
            {
                lblGeneralError.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblGeneralError.Visible = true;
                System.Diagnostics.Debug.WriteLine($"Database connection error: {ex.Message}");
            }
            catch (Exception ex)
            {
                lblGeneralError.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblGeneralError.Visible = true;
                System.Diagnostics.Debug.WriteLine($"Login error: {ex.Message}");
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "🔒";
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ParentForm is LoginForm loginForm)
            {
                loginForm.ShowForgotPassword();
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ParentForm is LoginForm loginForm)
            {
                loginForm.ShowRegister();
            }
        }

        private void lnkTos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using TosDialog dlg = new TosDialog(readOnlyMode: true);
            dlg.ShowDialog(this);
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }
    }
}

