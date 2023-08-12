using AbaloneGame.View;

namespace AbaloneGame
{
    internal static class Abalone
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new View.WelcomeForm());
        }
    }
}