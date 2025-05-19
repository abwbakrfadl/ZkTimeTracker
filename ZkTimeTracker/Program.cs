using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.Skins;
using ZKTecoAttendanceSystem.Forms;

namespace ZKTecoAttendanceSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize DevExpress skins and themes
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            
            try
            {
                // Start the application with the main form
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                // Show error message for any unhandled exceptions
                MessageBox.Show($"An unhandled error occurred: {ex.Message}\n\nThe application will now close.",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}