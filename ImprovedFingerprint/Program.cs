using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using ImprovedFingerprint.Forms;

namespace ImprovedFingerprint
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // تطبيق سكين DevExpress
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SkinName = "WXI";
            
            // بدء النظام بشاشة تسجيل الدخول
            Application.Run(new LoginForm());
        }
    }
}