using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using IOTimeControlApp.Forms;

namespace IOTimeControlApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Enable DevExpress Skins
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            
            Application.Run(new MainForm());
        }
    }
}