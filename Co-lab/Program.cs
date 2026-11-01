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
            // Launch Student Portal by default:
            Application.Run(new StudentMainForm());

            // To launch Admin Portal instead, swap with:
            // Application.Run(new AdminMainForm());
        }
    }
}
