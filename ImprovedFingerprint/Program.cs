using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;
using ImprovedFingerprint.Forms;

namespace ImprovedFingerprint
{
    static class Program
    {
        /// <summary>
        /// نقطة الدخول الرئيسية للتطبيق.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // تهيئة DevExpress
            DevExpress.UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            
            try
            {
                // تطبيق الإعدادات العربية
                System.Threading.Thread.CurrentThread.CurrentUICulture = 
                    new System.Globalization.CultureInfo("ar-SA");
                System.Threading.Thread.CurrentThread.CurrentCulture = 
                    new System.Globalization.CultureInfo("ar-SA");
                
                // بدء تشغيل الشاشة الرئيسية
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في بدء تشغيل التطبيق:\n\n{ex.Message}", 
                    "خطأ في التطبيق", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}