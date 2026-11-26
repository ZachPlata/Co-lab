using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB.UCAuth
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_ForgotPassword : UserControl
    {
        private static readonly Regex EmailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@ue\.edu\.ph$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private string _recoveryEmail = string.Empty;
        private string _storedQuestion = string.Empty;
        private string _storedAnswer = string.Empty;
        private int _failedAttempts = 0;
        private readonly ErrorProvider _errorProvider;

        public uc_ForgotPassword()
        {
            InitializeComponent();
            _errorProvider = ValidationHelper.Create(this);
            lblEmailError.Visible = false;
            lblAnswerError.Visible = false;
            lblNewPasswordError.Visible = false;
            lblConfirmPasswordError.Visible = false;

            txtEmail.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtEmail);
            txtAnswer.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, txtAnswer);
            txtNewPassword.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, pnlNewPassword);
            txtConfirmPassword.TextChanged += (s, e) => ValidationHelper.ClearError(_errorProvider, pnlConfirmPassword);
        }

        private void uc_ForgotPassword_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            ShowStep1();
        }

        private void ShowStep1()
        {
            pnlStep1.Visible = true;
            pnlStep2.Visible = false;
            lblStep1Error.Visible = false;
            lblEmailError.Visible = false;
            txtEmail.Focus();
        }

        private void ShowStep2()
        {
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
            lblStep2Error.Visible = false;
            lblAnswerError.Visible = false;
            lblNewPasswordError.Visible = false;
            lblConfirmPasswordError.Visible = false;
            txtAnswer.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtAnswer.Focus();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ValidationHelper.ClearAll(_errorProvider);
            lblStep1Error.Visible = false;
            lblEmailError.Visible = false;

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                ValidationHelper.SetError(_errorProvider, txtEmail, "UE email is required.");
                txtEmail.Focus();
                return;
            }

            if (!EmailRegex.IsMatch(email))
            {
                ValidationHelper.SetError(_errorProvider, txtEmail, "Please use your @ue.edu.ph email.");
                txtEmail.Focus();
                return;
            }

            try
            {
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter();
                conn.Open();
                cmd.CommandText = "SELECT SecurityQuestion, SecurityAnswer FROM tbl_users WHERE Email = @Email LIMIT 1";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Email", email);
                da.SelectCommand = cmd;
                da.Fill(ds, "users");
                conn.Close();

                DataTable dt = ds.Tables["users"]!;

                if (dt.Rows.Count == 0 ||
                    dt.Rows[0]["SecurityQuestion"] == DBNull.Value ||
                    string.IsNullOrWhiteSpace(dt.Rows[0]["SecurityQuestion"]?.ToString()) ||
                    dt.Rows[0]["SecurityAnswer"] == DBNull.Value ||
                    string.IsNullOrWhiteSpace(dt.Rows[0]["SecurityAnswer"]?.ToString()))
                {
                    // Show neutral message as required (do not reveal if account exists or lacks question)
                    lblStep1Error.Text = "We couldn't start recovery for this account. Contact the system administrator.";
                    lblStep1Error.Visible = true;
                    return;
                }

                _recoveryEmail = email;
                _storedQuestion = dt.Rows[0]["SecurityQuestion"].ToString()!;
                _storedAnswer = dt.Rows[0]["SecurityAnswer"].ToString()!;
                _failedAttempts = 0;

                lblQuestionText.Text = _storedQuestion;
                ShowStep2();
            }
            catch (MySqlException ex)
            {
                lblStep1Error.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblStep1Error.Visible = true;
                System.Diagnostics.Debug.WriteLine($"Database connection error: {ex.Message}");
            }
            catch (Exception ex)
            {
                lblStep1Error.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblStep1Error.Visible = true;
                System.Diagnostics.Debug.WriteLine($"Recovery error: {ex.Message}");
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            ValidationHelper.ClearAll(_errorProvider);
            lblStep2Error.Visible = false;
            lblAnswerError.Visible = false;
            lblNewPasswordError.Visible = false;
            lblConfirmPasswordError.Visible = false;

            if (_failedAttempts >= 5)
            {
                lblStep2Error.Text = "Too many failed attempts. Recovery is locked for this session.";
                lblStep2Error.Visible = true;
                btnResetPassword.Enabled = false;
                return;
            }

            string inputAnswer = txtAnswer.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            Control? firstInvalid = null;

            if (string.IsNullOrWhiteSpace(inputAnswer))
            {
                ValidationHelper.SetError(_errorProvider, txtAnswer, "Security answer is required.");
                firstInvalid ??= txtAnswer;
            }

            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 8)
            {
                ValidationHelper.SetError(_errorProvider, pnlNewPassword, "Password must be at least 8 characters.");
                firstInvalid ??= txtNewPassword;
            }

            if (string.IsNullOrEmpty(confirmPassword) || confirmPassword != newPassword)
            {
                ValidationHelper.SetError(_errorProvider, pnlConfirmPassword, "Passwords do not match.");
                firstInvalid ??= txtConfirmPassword;
            }

            if (firstInvalid != null)
            {
                firstInvalid.Focus();
                return;
            }

            // Compare answer trimmed and case-insensitively
            if (!string.Equals(inputAnswer.ToLowerInvariant(), _storedAnswer.Trim().ToLowerInvariant(), StringComparison.Ordinal))
            {
                _failedAttempts++;
                if (_failedAttempts >= 5)
                {
                    lblStep2Error.Text = "Too many failed attempts. Recovery is locked for this session.";
                    lblStep2Error.Visible = true;
                    btnResetPassword.Enabled = false;
                    txtAnswer.Enabled = false;
                    txtNewPassword.Enabled = false;
                    txtConfirmPassword.Enabled = false;
                }
                else
                {
                    lblStep2Error.Text = "Incorrect answer.";
                    lblStep2Error.Visible = true;
                }
                return;
            }

            // Answer is correct -> update password
            try
            {
                string hashedPassword = AuthHelper.HashPassword(newPassword);
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "UPDATE tbl_users SET Password = @Password WHERE Email = @Email";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Email", _recoveryEmail);
                int affected = cmd.ExecuteNonQuery();
                conn.Close();

                if (affected > 0)
                {
                    MessageBox.Show(
                        "Password reset successfully! You can now sign in with your new password.",
                        "Password Reset",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (ParentForm is LoginForm loginForm)
                    {
                        loginForm.ShowLogin(_recoveryEmail);
                    }
                }
                else
                {
                    lblStep2Error.Text = "Unable to update password. Please try again.";
                    lblStep2Error.Visible = true;
                }
            }
            catch (MySqlException ex)
            {
                lblStep2Error.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblStep2Error.Visible = true;
                System.Diagnostics.Debug.WriteLine($"Database connection error: {ex.Message}");
            }
            catch (Exception ex)
            {
                lblStep2Error.Text = "Could not connect to the database. Make sure MySQL is running in XAMPP.";
                lblStep2Error.Visible = true;
                System.Diagnostics.Debug.WriteLine($"Password reset error: {ex.Message}");
            }
        }

        private void btnToggleNewPassword_Click(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !txtNewPassword.UseSystemPasswordChar;
            btnToggleNewPassword.Text = txtNewPassword.UseSystemPasswordChar ? "👁" : "🔒";
        }

        private void btnToggleConfirmPassword_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
            btnToggleConfirmPassword.Text = txtConfirmPassword.UseSystemPasswordChar ? "👁" : "🔒";
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ParentForm is LoginForm loginForm)
            {
                loginForm.ShowLogin();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnContinue.PerformClick();
            }
        }
    }
}

