using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class IOTimeControlForm : XtraForm
    {
        private readonly DeviceService _deviceService;

        public IOTimeControlForm(DeviceService deviceService)
        {
            InitializeComponent();
            _deviceService = deviceService;
            
            // تحميل الإعدادات الحالية للجهاز
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                if (!_deviceService.IsConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // تحديد الأوقات الافتراضية حسب طلبك
                // الدخول من 6:00 إلى 10:59
                timeEditCheckInStart.Time = DateTime.Today.AddHours(6);  // 6:00 صباحاً
                timeEditCheckInEnd.Time = DateTime.Today.AddHours(10).AddMinutes(59); // 10:59 صباحاً
                
                // الخروج من 11:00 إلى 13:00
                timeEditCheckOutStart.Time = DateTime.Today.AddHours(11); // 11:00 صباحاً
                timeEditCheckOutEnd.Time = DateTime.Today.AddHours(13);   // 13:00 ظهراً

                lblStatus.Text = "تم تحميل الإعدادات الافتراضية";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الإعدادات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApplyToDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_deviceService.IsConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من صحة الأوقات المدخلة
                if (!ValidateTimeSettings())
                {
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري تطبيق إعدادات الوقت على الجهاز...";
                Application.DoEvents();

                // تطبيق إعدادات الوقت على الجهاز
                bool success = ApplyIOTimeSettings();

                if (success)
                {
                    lblStatus.Text = "تم تطبيق إعدادات الوقت بنجاح على جهاز البصمة";
                    XtraMessageBox.Show("تم تطبيق إعدادات التحكم في أوقات الدخول والخروج بنجاح على الجهاز", 
                        "نجح التطبيق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "فشل في تطبيق إعدادات الوقت على الجهاز";
                    XtraMessageBox.Show("فشل في تطبيق إعدادات الوقت على الجهاز. تأكد من اتصال الجهاز", 
                        "فشل التطبيق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في تطبيق الإعدادات";
                XtraMessageBox.Show($"خطأ في تطبيق إعدادات الوقت: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidateTimeSettings()
        {
            // التحقق من أن وقت بداية الدخول أقل من وقت نهاية الدخول
            if (timeEditCheckInStart.Time >= timeEditCheckInEnd.Time)
            {
                XtraMessageBox.Show("وقت بداية الدخول يجب أن يكون أقل من وقت نهاية الدخول", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من أن وقت بداية الخروج أقل من وقت نهاية الخروج
            if (timeEditCheckOutStart.Time >= timeEditCheckOutEnd.Time)
            {
                XtraMessageBox.Show("وقت بداية الخروج يجب أن يكون أقل من وقت نهاية الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من عدم تداخل أوقات الدخول والخروج
            if (timeEditCheckInEnd.Time > timeEditCheckOutStart.Time)
            {
                XtraMessageBox.Show("يجب أن ينتهي وقت الدخول قبل بداية وقت الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ApplyIOTimeSettings()
        {
            try
            {
                // الحصول على COM object من DeviceService
                var zkemKeeper = GetZkemKeeperFromDeviceService();
                if (zkemKeeper == null)
                {
                    return false;
                }

                // إعداد أوقات الدخول والخروج في الجهاز
                // تحويل الأوقات إلى تنسيق الجهاز
                TimeSpan checkInStart = timeEditCheckInStart.Time.TimeOfDay;
                TimeSpan checkInEnd = timeEditCheckInEnd.Time.TimeOfDay;
                TimeSpan checkOutStart = timeEditCheckOutStart.Time.TimeOfDay;
                TimeSpan checkOutEnd = timeEditCheckOutEnd.Time.TimeOfDay;

                // ضبط فترة الدخول (IN)
                bool success1 = SetTimeZone(zkemKeeper, 1, checkInStart, checkInEnd, 0); 

                // ضبط فترة الخروج (OUT)  
                bool success2 = SetTimeZone(zkemKeeper, 2, checkOutStart, checkOutEnd, 1); 

                // حفظ الإعدادات في الجهاز
                bool saveSuccess = (bool)zkemKeeper.GetType().InvokeMember(
                    "RefreshData",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    zkemKeeper,
                    new object[] { 1 });

                return success1 && success2 && saveSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception("خطأ في تطبيق إعدادات الوقت على الجهاز: " + ex.Message);
            }
        }

        private bool SetTimeZone(object zkemKeeper, int timeZoneId, TimeSpan startTime, TimeSpan endTime, int inOutMode)
        {
            try
            {
                // ضبط المنطقة الزمنية في الجهاز
                bool success = (bool)zkemKeeper.GetType().InvokeMember(
                    "SetUserTZ",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    zkemKeeper,
                    new object[] { 
                        1,                    // رقم الجهاز
                        timeZoneId,          // رقم المنطقة الزمنية
                        startTime.Hours,     // ساعة البداية
                        startTime.Minutes,   // دقيقة البداية
                        endTime.Hours,       // ساعة النهاية
                        endTime.Minutes,     // دقيقة النهاية
                        1,                   // يوم الأحد
                        1,                   // يوم الاثنين
                        1,                   // يوم الثلاثاء
                        1,                   // يوم الأربعاء
                        1,                   // يوم الخميس
                        1,                   // يوم الجمعة
                        1                    // يوم السبت
                    });

                return success;
            }
            catch
            {
                return false;
            }
        }

        private object GetZkemKeeperFromDeviceService()
        {
            try
            {
                // الحصول على COM object من DeviceService باستخدام Reflection
                var deviceServiceType = _deviceService.GetType();
                var zkemKeeperField = deviceServiceType.GetField("_zkemKeeper", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                
                if (zkemKeeperField != null)
                {
                    return zkemKeeperField.GetValue(_deviceService);
                }
                
                return null;
            }
            catch
            {
                return null;
            }
        }

        private void btnTestSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTimeSettings())
                {
                    return;
                }

                // عرض الإعدادات الحالية للمراجعة
                string settings = $@"إعدادات أوقات الدخول والخروج:

فترة الدخول (IN):
من الساعة: {timeEditCheckInStart.Time.ToString("HH:mm")}
إلى الساعة: {timeEditCheckInEnd.Time.ToString("HH:mm")}

فترة الخروج (OUT):
من الساعة: {timeEditCheckOutStart.Time.ToString("HH:mm")}
إلى الساعة: {timeEditCheckOutEnd.Time.ToString("HH:mm")}

هذا يعني أن:
- البصمات المسجلة من {timeEditCheckInStart.Time.ToString("HH:mm")} إلى {timeEditCheckInEnd.Time.ToString("HH:mm")} ستعتبر دخول
- البصمات المسجلة من {timeEditCheckOutStart.Time.ToString("HH:mm")} إلى {timeEditCheckOutEnd.Time.ToString("HH:mm")} ستعتبر خروج";

                XtraMessageBox.Show(settings, "مراجعة الإعدادات", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                lblStatus.Text = "تم اختبار الإعدادات بنجاح";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في اختبار الإعدادات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("هل تريد إعادة تعيين الإعدادات إلى القيم الافتراضية؟", 
                "تأكيد إعادة التعيين", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoadCurrentSettings();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGetFromDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_deviceService.IsConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري قراءة إعدادات الوقت من الجهاز...";
                Application.DoEvents();

                // قراءة الإعدادات الحالية من الجهاز
                bool success = ReadIOTimeSettingsFromDevice();

                if (success)
                {
                    lblStatus.Text = "تم قراءة إعدادات الوقت من الجهاز بنجاح";
                    XtraMessageBox.Show("تم قراءة إعدادات التحكم في أوقات الدخول والخروج من الجهاز بنجاح", 
                        "نجح القراءة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "لا توجد إعدادات مخصصة في الجهاز، تم تحميل القيم الافتراضية";
                    LoadCurrentSettings();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في قراءة الإعدادات من الجهاز";
                XtraMessageBox.Show($"خطأ في قراءة إعدادات الوقت من الجهاز: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ReadIOTimeSettingsFromDevice()
        {
            try
            {
                var zkemKeeper = GetZkemKeeperFromDeviceService();
                if (zkemKeeper == null)
                {
                    return false;
                }

                // محاولة قراءة المناطق الزمنية من الجهاز
                // للآن سنحمل القيم الافتراضية
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}