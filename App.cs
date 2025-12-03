namespace WinFormsApp1
{
    internal static class App
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Enable visual styles for modern look
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the application with GUI as the main form
            Application.Run(new GUI());

        }
    }
}