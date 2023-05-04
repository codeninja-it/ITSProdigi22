using System.Web;

namespace RubricaWin
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argomenti)
        {
            string fileDaAprire = "rubrica.json";
            if (argomenti.Length == 1)
                fileDaAprire = argomenti[0];
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Form1 finestra = new Form1(fileDaAprire);
            Application.Run(finestra);
        }
    }
}