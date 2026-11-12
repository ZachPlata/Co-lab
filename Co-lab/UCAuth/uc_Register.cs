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

        public uc_Register()
        {
            InitializeComponent();
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

            // 1. Full Name
            string fullName = txtFullName.Text.Trim();
            if (string.IsNullOrWhiteSpace(fullName))
            {
                isValid = false;
                if (showErrors && _hasUserInteracted && !string.IsNullOrEmpty(txtFullName.Text))
                {
                    lblFullNameError.Text = "Full name is required.";
                    lblFullNameError.Visible = true;
                }
                else if (!showErrors)
                {
                    lblFullNameError.Visible = false;
                }
            }
            else
            {
                lblFullNameError.Visible = false;
            }

            // 2. UE Email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                isValid = false;
                if (showErrors && _hasUserInteracted && !string.IsNullOrEmpty(txtEmail.Text))
                {
                    lblEmailError.Text = "UE email is required.";
                    lblEmailError.Visible = true;
                }
                else if (!showErrors)
                {
                    lblEmailError.Visible = false;
                }
            }
            else if (!EmailRegex.IsMatch(email))
            {
                isValid = false;
                if (showErrors)
                {
                    lblEmailError.Text = "Please use your @ue.edu.ph email.";
                    lblEmailError.Visible = true;
                }
            }
            else
            {
                lblEmailError.Visible = false;
            }

            // 3. Password
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                isValid = false;
                if (showErrors && !string.IsNullOrEmpty(password))
                {
                    lblPasswordError.Text = "Password must be at least 8 characters.";
                    lblPasswordError.Visible = true;
                }
                else if (!showErrors)
                {
                    lblPasswordError.Visible = false;
                }
            }
            else
            {
                lblPasswordError.Visible = false;
            }

            // 4. Confirm Password
            string confirmPassword = txtConfirmPassword.Text;
            if (string.IsNullOrEmpty(confirmPassword) || confirmPassword != password)
            {
                isValid = false;
                if (showErrors && !string.IsNullOrEmpty(confirmPassword))
                {
                    lblConfirmPasswordError.Text = "Passwords do not match.";
                    lblConfirmPasswordError.Visible = true;
                }
                else if (!showErrors)
                {
                    lblConfirmPasswordError.Visible = false;
                }
            }
            else
            {
                lblConfirmPasswordError.Visible = false;
            }

            // 5. Security Question
            if (cmbSecurityQuestion.SelectedIndex < 0)
            {
                isValid = false;
                if (showErrors && _hasUserInteracted)
                {
                    // Do not show aggressively until submit or interaction
                }
            }
            else
            {
                lblSecurityQuestionError.Visible = false;
            }

            // 6. Security Answer
            string answer = txtSecurityAnswer.Text.Trim();
            if (string.IsNullOrWhiteSpace(answer) || answer.Length < 2)
            {
                isValid = false;
                if (showErrors && !string.IsNullOrEmpty(txtSecurityAnswer.Text))
                {
                    lblSecurityAnswerError.Text = "Security answer must be at least 2 characters.";
                    lblSecurityAnswerError.Visible = true;
                }
                else if (!showErrors)
                {
                    lblSecurityAnswerError.Visible = false;
                }
            }
            else
            {
                lblSecurityAnswerError.Visible = false;
            }

            // 7. Terms of Service accepted
            if (!chkTos.Checked)
            {
                isValid = false;
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
                string checkQuery = "SELECT COUNT(*) FROM tbl_users WHERE Email = @Email";
                object? countObj = DatabaseHelper.ExecuteScalar(checkQuery, new MySqlParameter("@Email", email));
                int count = Convert.ToInt32(countObj);

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
                string insertQuery = @"INSERT INTO tbl_users (FullName, Email, Password, Role, SecurityQuestion, SecurityAnswer) 
                                       VALUES (@FullName, @Email, @Password, 'Student', @SecurityQuestion, @SecurityAnswer)";

                DatabaseHelper.ExecuteNonQuery(
                    insertQuery,
                    new MySqlParameter("@FullName", fullName),
                    new MySqlParameter("@Email", email),
                    new MySqlParameter("@Password", hashedPassword),
                    new MySqlParameter("@SecurityQuestion", securityQuestion),
                    new MySqlParameter("@SecurityAnswer", securityAnswer));

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

