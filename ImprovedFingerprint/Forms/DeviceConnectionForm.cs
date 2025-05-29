using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ImprovedFingerprint.Forms
{
    public partial class DeviceConnectionForm : XtraForm
    {
        public string IPAddress { get; private set; }
        public int Port { get; private set; }

        public DeviceConnectionForm()
        {
            InitializeComponent();
            
            this.Text = "الاتصال بجهاز البصمة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            LoadDefaultSettings();
        }

        private void LoadDefaultSettings()
        {
            // تحميل الإعدادات الافتراضية
            textEditIP.Text = "192.168.1.201";
            spinEditPort.Value = 4370;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    IPAddress = textEditIP.Text.Trim();
                    Port = (int)spinEditPort.Value;
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في البيانات المدخلة: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // التحقق من عنوان IP
            if (string.IsNullOrWhiteSpace(textEditIP.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال عنوان IP للجهاز", "بيانات ناقصة", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditIP.Focus();
                return false;
            }

            // التحقق من صحة عنوان IP
            if (!System.Net.IPAddress.TryParse(textEditIP.Text.Trim(), out _))
            {
                XtraMessageBox.Show("عنوان IP غير صحيح. الرجاء إدخال عنوان صحيح مثل 192.168.1.201", 
                    "عنوان غير صحيح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditIP.Focus();
                return false;
            }

            // التحقق من المنفذ
            if (spinEditPort.Value < 1 || spinEditPort.Value > 65535)
            {
                XtraMessageBox.Show("رقم المنفذ يجب أن يكون بين 1 و 65535", "منفذ غير صحيح", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinEditPort.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري اختبار الاتصال...";
                Application.DoEvents();

                // محاولة الاتصال السريع
                using (var client = new System.Net.Sockets.TcpClient())
                {
                    var result = client.BeginConnect(textEditIP.Text.Trim(), (int)spinEditPort.Value, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(5000); // انتظار 5 ثوان

                    if (success && client.Connected)
                    {
                        lblStatus.Text = "تم الاتصال بنجاح ✓";
                        lblStatus.Appearance.ForeColor = System.Drawing.Color.Green;
                        XtraMessageBox.Show("تم الاتصال بالجهاز بنجاح", "نجح الاختبار", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblStatus.Text = "فشل في الاتصال ✗";
                        lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
                        XtraMessageBox.Show("فشل في الاتصال بالجهاز. تحقق من عنوان IP والمنفذ والتأكد من تشغيل الجهاز", 
                            "فشل الاختبار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في اختبار الاتصال";
                lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
                XtraMessageBox.Show($"خطأ في اختبار الاتصال: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}