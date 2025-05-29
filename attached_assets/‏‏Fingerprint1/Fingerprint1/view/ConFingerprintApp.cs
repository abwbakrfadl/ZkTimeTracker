using System;
using System.Windows.Forms;
using zkemkeeper; // مكتبة ZKTeco

namespace Fingerprint1.view
{
    public partial class ConFingerprintApp : Form
    {
        private CZKEMClass zkDevice;

        public ConFingerprintApp()
        {
            InitializeComponent();
            zkDevice = new CZKEMClass(); // تهيئة جهاز البصمة
        }

        private void InitializeZKTecoDevice(string ipAddress, int port)
        {
            // محاولة الاتصال بالجهاز
            if (zkDevice.Connect_Net(ipAddress, port))
            {
                lblMessage.Text = "تم الاتصال بالجهاز بنجاح!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "فشل الاتصال بالجهاز.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text.Trim();
            string portText = txtPort.Text.Trim();

            // التحقق من صحة المدخلات
            if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(portText))
            {
                lblMessage.Text = "يرجى إدخال عنوان IP ورقم المنفذ.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!int.TryParse(portText, out int port) || port <= 0)
            {
                lblMessage.Text = "رقم المنفذ غير صحيح.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // محاولة الاتصال بالجهاز
            InitializeZKTecoDevice(ipAddress, port);
        }
    }
}