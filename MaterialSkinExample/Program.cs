using System;
using System.Windows.Forms;
using PYALauncherApps.Controllers;
using PYALauncherApps.Views;

namespace MaterialSkinExample
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Main());

            AppController.Initialize();



        }
    }
}