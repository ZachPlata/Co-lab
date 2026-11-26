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
        private readonly ErrorProvider _errorProvider;

        public uc_Login()
        {
            InitializeComponent();
            _errorProvider = ValidationHelper.Create(this);
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;

            txtEmail.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtEmail);
            txtPassword.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, pnlPasswordWrapper);
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
            ValidationHelper.ClearAll(_errorProvider);
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;
            lblGeneralError.Visible = false;

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            Control? firstInvalid = null;

            if (string.IsNullOrWhiteSpace(email))
            {
                ValidationHelper.SetError(_errorProvider, txtEmail, "Email is required.");
                firstInvalid ??= txtEmail;
            }
            else if (!EmailRegex.IsMatch(email))
            {
                ValidationHelper.SetError(_errorProvider, txtEmail, "Please use your @ue.edu.ph email.");
                firstInvalid ??= txtEmail;
            }

            if (string.IsNullOrEmpty(password))
            {
                ValidationHelper.SetError(_errorProvider, pnlPasswordWrapper, "Password is required.");
                firstInvalid ??= txtPassword;
            }

            if (firstInvalid != null)
            {
                firstInvalid.Focus();
                return;
            }

            btnLogin.Enabled = false;
            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = @"SELECT UserId, FullName, Email, Password, Role, is_blacklisted, BanReason,
                                           is_verified, VerificationStatus, VerificationNote,
                                           is_logged_in, last_active,
                                           TIMESTAMPDIFF(SECOND, last_active, NOW()) AS inactive_seconds
                                    FROM tbl_users WHERE Email = @Email LIMIT 1";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Email", email);
                da.SelectCommand = cmd;
                da.Fill(ds, "users");
                conn.Close();

                DataTable dt = ds.Tables["users"]!;

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

                int userId = Convert.ToInt32(row["UserId"]);
                if (!AuthHelper.IsHashed(storedPassword))
                {
                    try
                    {
                        string migratedHash = AuthHelper.HashPassword(password);
                        using MySqlConnection migConn = DatabaseHelper.GetConnection();
                        MySqlCommand migCmd = new MySqlCommand();
                        migConn.Open();
                        migCmd.CommandText = "UPDATE tbl_users SET Password = @Password WHERE UserId = @uid";
                        migCmd.Connection = migConn;
                        migCmd.Parameters.AddWithValue("@Password", migratedHash);
                        migCmd.Parameters.AddWithValue("@uid", userId);
                        migCmd.ExecuteNonQuery();
                        migConn.Close();
                    }
                    catch (Exception ex)
{
                        System.Diagnostics.Debug.WriteLine($"Password migration error: {ex.Message}");
                    }
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

                string fullName = row["FullName"]?.ToString() ?? "";
                string role = row["Role"]?.ToString() ?? "Student";
                bool isVerified = row["is_verified"] != DBNull.Value && Convert.ToInt32(row["is_verified"]) == 1;
                string verificationStatus = row["VerificationStatus"]?.ToString() ?? (isVerified ? "Verified" : "Pending");
                string verificationNote = row["VerificationNote"]?.ToString() ?? "";

                if (string.Equals(verificationStatus, "Declined", StringComparison.OrdinalIgnoreCase))
                {
                    lblGeneralError.Text = string.IsNullOrWhiteSpace(verificationNote)
                        ? "Your account verification was declined by an Admin."
                        : $"Your account verification was declined.\nReason: {verificationNote}";
                    lblGeneralError.Visible = true;
                    return;
                }

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
                using MySqlConnection sessConn = DatabaseHelper.GetConnection();
                MySqlCommand sessCmd = new MySqlCommand();
                sessConn.Open();
                sessCmd.CommandText = "UPDATE tbl_users SET is_logged_in = 1, last_active = NOW(), session_id = @sid WHERE UserId = @uid";
                sessCmd.Connection = sessConn;
                sessCmd.Parameters.AddWithValue("@sid", newSessionId);
                sessCmd.Parameters.AddWithValue("@uid", userId);
                sessCmd.ExecuteNonQuery();
                sessConn.Close();

                UserSession.Set(userId, fullName, email, role, newSessionId, isVerified, verificationStatus);

                if (ParentForm is LoginForm loginForm)
                {
                    loginForm.DialogResult = DialogResult.OK;
                    loginForm.Close();
                }
            }
            catch (MySqlException)
            {
                lblGeneralError.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblGeneralError.Visible = true;
            }
            catch
            {
                lblGeneralError.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblGeneralError.Visible = true;
            }
            finally
            {
                if (!IsDisposed) btnLogin.Enabled = true;
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

