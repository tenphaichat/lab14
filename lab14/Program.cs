using System;
using System.IO;
using System.Windows.Forms;
using Lab14_AdvancedReport.GUI;

namespace Lab14_AdvancedReport
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args != null && args.Length > 0 && args[0].Equals("--capture", StringComparison.OrdinalIgnoreCase))
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string rootDir = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\.."));
                string screenshotsDir = Path.Combine(rootDir, "screenshots");

                ScreenshotCapture.RunCapture(screenshotsDir, rootDir);
                return;
            }

            Application.Run(new frmMain());
        }
    }
}
