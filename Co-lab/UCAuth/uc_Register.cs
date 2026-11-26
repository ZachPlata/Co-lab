using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Co_LAB.UCAuth
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class uc_Register : UserControl
    {
        private static readonly Regex EmailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@ue\.edu\.ph$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private bool _hasUserInteracted = false;
        private readonly ErrorProvider _errorProvider;

        public uc_Register()
        {
            InitializeComponent();
            _errorProvider = ValidationHelper.Create(this);
            lblFullNameError.Visible = false;
            lblEmailError.Visible = false;
            lblPasswordError.Visible = false;
            lblConfirmPasswordError.Visible = false;
            lblSecurityQuestionError.Visible = false;
            lblSecurityAnswerError.Visible = false;
        }

        private void uc_Register_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            ValidateForm(showErrors: false);
        }

        private void inputField_Changed(object sender, EventArgs e)
        {
            _hasUserInteracted = true;
            ValidateForm(showErrors: true);
        }

        private bool ValidateForm(bool showErrors)
        {
            lblGeneralError.Visible = false;
            bool isValid = true;
            Control? firstInvalid = null;

            // 1. Full Name
            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                isValid = false;
                firstInvalid ??= txtFullName;
                if (showErrors && _hasUserInteracted)
                    ValidationHelper.SetError(_errorProvider, txtFullName, "Full name is required.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, txtFullName);
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, txtFullName);
            }

            // 2. UE Email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                isValid = false;
                firstInvalid ??= txtEmail;
                if (showErrors && _hasUserInteracted)
                    ValidationHelper.SetError(_errorProvider, txtEmail, "UE email is required.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, txtEmail);
            }
            else if (!EmailRegex.IsMatch(email))
            {
                isValid = false;
                firstInvalid ??= txtEmail;
                if (showErrors)
                    ValidationHelper.SetError(_errorProvider, txtEmail, "Please use your @ue.edu.ph email.");
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, txtEmail);
            }

            // 3. Password
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                isValid = false;
                firstInvalid ??= txtPassword;
                if (showErrors && _hasUserInteracted)
                    ValidationHelper.SetError(_errorProvider, pnlPassword, "Password must be at least 8 characters.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, pnlPassword);
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, pnlPassword);
            }

            // 4. Confirm Password
            string confirmPassword = txtConfirmPassword.Text;
            if (string.IsNullOrEmpty(confirmPassword) || confirmPassword != password)
            {
                isValid = false;
                firstInvalid ??= txtConfirmPassword;
                if (showErrors && (!string.IsNullOrEmpty(confirmPassword) || _hasUserInteracted))
                    ValidationHelper.SetError(_errorProvider, pnlConfirmPassword, "Passwords do not match.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, pnlConfirmPassword);
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, pnlConfirmPassword);
            }

            // 5. Security Question
            if (cmbSecurityQuestion.SelectedIndex < 0)
            {
                isValid = false;
                firstInvalid ??= cmbSecurityQuestion;
                if (showErrors && _hasUserInteracted)
                    ValidationHelper.SetError(_errorProvider, cmbSecurityQuestion, "Please select a security question.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, cmbSecurityQuestion);
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, cmbSecurityQuestion);
            }

            // 6. Security Answer
            string answer = txtSecurityAnswer.Text.Trim();
            if (string.IsNullOrWhiteSpace(answer) || answer.Length < 2)
            {
                isValid = false;
                firstInvalid ??= txtSecurityAnswer;
                if (showErrors && _hasUserInteracted)
                    ValidationHelper.SetError(_errorProvider, txtSecurityAnswer, "Security answer must be at least 2 characters.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, txtSecurityAnswer);
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, txtSecurityAnswer);
            }

            // 7. Terms of Service accepted
            if (!chkTos.Checked)
            {
                isValid = false;
                firstInvalid ??= chkTos;
                if (showErrors && _hasUserInteracted)
                    ValidationHelper.SetError(_errorProvider, pnlTos, "You must read and accept the Terms of Service.");
                else if (!showErrors)
                    ValidationHelper.ClearError(_errorProvider, pnlTos);
            }
            else
            {
                ValidationHelper.ClearError(_errorProvider, pnlTos);
            }

            // Update button state
            btnRegister.Enabled = isValid;
            if (isValid)
            {
                btnRegister.BackColor = Color.FromArgb(46, 125, 70);
                btnRegister.ForeColor = Color.White;
            }
            else
            {
                btnRegister.BackColor = Color.FromArgb(28, 38, 30);
                btnRegister.ForeColor = Color.FromArgb(90, 115, 100);
            }

            return isValid;
        }

        private void lnkReadTos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using TosDialog dlg = new TosDialog(readOnlyMode: false);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                chkTos.Enabled = true;
                chkTos.Checked = true;
            }
            else
            {
                chkTos.Checked = false;
                chkTos.Enabled = false;
            }
            ValidateForm(showErrors: true);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _hasUserInteracted = true;
            if (!ValidateForm(showErrors: true))
            {
                // Highlight any missing fields explicitly
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    lblFullNameError.Text = "Full name is required.";
                    lblFullNameError.Visible = true;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    lblEmailError.Text = "UE email is required.";
                    lblEmailError.Visible = true;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    lblPasswordError.Text = "Password is required (min 8 chars).";
                    lblPasswordError.Visible = true;
                }
                if (cmbSecurityQuestion.SelectedIndex < 0)
                {
                    lblSecurityQuestionError.Text = "Please select a security question.";
                    lblSecurityQuestionError.Visible = true;
                }
                if (string.IsNullOrWhiteSpace(txtSecurityAnswer.Text))
                {
                    lblSecurityAnswerError.Text = "Security answer is required (min 2 chars).";
                    lblSecurityAnswerError.Visible = true;
                }
                if (!chkTos.Checked)
                {
                    lblGeneralError.Text = "You must read and accept the Terms of Service to create an account.";
                    lblGeneralError.Visible = true;
                }
                return;
            }

            string email = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text;
            string securityQuestion = cmbSecurityQuestion.SelectedItem?.ToString() ?? "";
            string securityAnswer = txtSecurityAnswer.Text.Trim().ToLowerInvariant();

            try
            {
                // Check if email is already registered
                using MySqlConnection conn = DatabaseHelper.GetConnection();
                MySqlCommand cmd = new MySqlCommand();
                conn.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM tbl_users WHERE Email = @Email";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Email", email);

                int count = 0;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader[0] != DBNull.Value)
                    {
                        count = Convert.ToInt32(reader[0]);
                    }
                }
                conn.Close();

                if (count > 0)
                {
                    lblEmailError.Text = "This email is already registered.";
                    lblEmailError.Visible = true;
                    btnRegister.Enabled = false;
                    btnRegister.BackColor = Color.FromArgb(39, 39, 42);
                    btnRegister.ForeColor = Color.FromArgb(113, 113, 122);
                    return;
                }

                // Insert student user
                string hashedPassword = AuthHelper.HashPassword(password);
                using MySqlConnection insertConn = DatabaseHelper.GetConnection();
                MySqlCommand insertCmd = new MySqlCommand();
                insertConn.Open();
                insertCmd.CommandText = @"INSERT INTO tbl_users (FullName, Email, Password, Role, SecurityQuestion, SecurityAnswer) 
                                          VALUES (@FullName, @Email, @Password, 'Student', @SecurityQuestion, @SecurityAnswer)";
                insertCmd.Connection = insertConn;
                insertCmd.Parameters.AddWithValue("@FullName", fullName);
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Password", hashedPassword);
                insertCmd.Parameters.AddWithValue("@SecurityQuestion", securityQuestion);
                insertCmd.Parameters.AddWithValue("@SecurityAnswer", securityAnswer);
                insertCmd.ExecuteNonQuery();
                insertConn.Close();

                MessageBox.Show(
                    "Registration successful! You can now sign in with your UE credentials.",
                    "Account Created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (ParentForm is LoginForm loginForm)
                {
                    loginForm.ShowLogin(email);
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
                System.Diagnostics.Debug.WriteLine($"Registration error: {ex.Message}");
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "🔒";
        }

        private void btnToggleConfirm_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
            btnToggleConfirm.Text = txtConfirmPassword.UseSystemPasswordChar ? "👁" : "🔒";
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ParentForm is LoginForm loginForm)
            {
                loginForm.ShowLogin();
            }
        }
    }
}

