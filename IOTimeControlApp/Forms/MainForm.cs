using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IOTimeControlApp.Services;

namespace IOTimeControlApp.Forms
{
    public partial class MainForm : XtraForm
    {
        private readonly DeviceService _deviceService;

        public MainForm()
        {
            InitializeComponent();
            _deviceService = new DeviceService();
            
            // تعيين الأيقونة والنص
            this.Text = "نظام التحكم في أوقات الدخول والخروج - جهاز البصمة";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // تحديث حالة الاتصال عند تحميل النموذج
            UpdateConnectionStatus();
        }

        private void btnOpenTimeControl_Click(object sender, EventArgs e)
        {
            try
            {
                var timeControlForm = new IOTimeControlForm(_deviceService);
                timeControlForm.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في فتح شاشة التحكم في الأوقات: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري الاتصال بجهاز البصمة...";
                Application.DoEvents();

                // محاولة الاتصال بجهاز البصمة
                bool connected = _deviceService.Connect("192.168.1.100", 4370); // IP افتراضي

                if (connected)
                {
                    lblStatus.Text = "تم الاتصال بجهاز البصمة بنجاح";
                    btnConnect.Text = "قطع الاتصال";
                    btnConnect.Appearance.BackColor = System.Drawing.Color.Red;
                    btnOpenTimeControl.Enabled = true;
                    
                    XtraMessageBox.Show("تم الاتصال بجهاز البصمة بنجاح", "نجح الاتصال", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "فشل في الاتصال بجهاز البصمة";
                    XtraMessageBox.Show("فشل في الاتصال بجهاز البصمة. تأكد من:\n1. تشغيل الجهاز\n2. الاتصال بالشبكة\n3. عنوان IP الصحيح", 
                        "فشل الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في الاتصال";
                XtraMessageBox.Show($"خطأ في الاتصال بجهاز البصمة: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_deviceService.IsConnected)
                {
                    _deviceService.Disconnect();
                    lblStatus.Text = "تم قطع الاتصال بجهاز البصمة";
                    btnConnect.Text = "اتصال بالجهاز";
                    btnConnect.Appearance.BackColor = System.Drawing.Color.Green;
                    btnOpenTimeControl.Enabled = false;
                    
                    XtraMessageBox.Show("تم قطع الاتصال بجهاز البصمة", "قطع الاتصال", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في قطع الاتصال: {ex.Message}", 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateConnectionStatus()
        {
            if (_deviceService.IsConnected)
            {
                lblStatus.Text = "متصل بجهاز البصمة";
                btnConnect.Text = "قطع الاتصال";
                btnConnect.Appearance.BackColor = System.Drawing.Color.Red;
                btnOpenTimeControl.Enabled = true;
            }
            else
            {
                lblStatus.Text = "غير متصل بجهاز البصمة";
                btnConnect.Text = "اتصال بالجهاز";
                btnConnect.Appearance.BackColor = System.Drawing.Color.Green;
                btnOpenTimeControl.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("هل تريد إغلاق البرنامج؟", 
                "تأكيد الإغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                if (_deviceService.IsConnected)
                {
                    _deviceService.Disconnect();
                }
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_deviceService.IsConnected)
            {
                _deviceService.Disconnect();
            }
        }
    }
}