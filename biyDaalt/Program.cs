using System.Diagnostics;

namespace biyDaalt
{
    internal static class Program
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
            Dictionary<string, List<String>> reviews = dataHandler.return_review();
            if (reviews.ContainsKey("error"))
            {
                Debug.WriteLine("something wroing");
            }
            else
            {
                List<String> row1 = null;
                List<String> row2 = null;
                List<String> row3 = null;
                if (reviews.ContainsKey("1"))
                {
                    row1 = reviews["1"];
                }
                if (reviews.ContainsKey("2"))
                {
                    row2 = reviews["2"];
                }
                if (reviews.ContainsKey("3"))
                {
                    row3 = reviews["3"];
                }                
                Application.Run(new welcomePage(row1, row2, row3));
            }
            
        }
    }
}