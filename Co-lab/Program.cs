using System;
using System.Windows.Forms;

namespace Co_LAB
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    DialogResult result = loginForm.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        // User cancelled or closed the login window
                        break;
                    }
                }

                if (!UserSession.IsLoggedIn)
                {
                    break;
                }

                StudentMainForm.CurrentStudentName = UserSession.FullName;

                if (UserSession.Role == "Student")
                {
                    Application.Run(new StudentMainForm());

                    // When the main form closes AND UserSession was cleared by a Sign Out, return to LoginForm; otherwise exit the app.
                    if (!UserSession.IsLoggedIn)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (UserSession.Role == "Admin")
                {
                    Application.Run(new AdminMainForm());

                    // When the admin form closes AND UserSession was cleared by a Sign Out, return to LoginForm; otherwise exit the app.
                    if (!UserSession.IsLoggedIn)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
