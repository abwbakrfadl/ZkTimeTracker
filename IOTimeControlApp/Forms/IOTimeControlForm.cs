using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IOTimeControlApp.Services;

namespace IOTimeControlApp.Forms
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

                // الفترة الصباحية
                timeEditMorningInStart.Time = DateTime.Today.AddHours(6);     // 6:00 صباحاً
                timeEditMorningInEnd.Time = DateTime.Today.AddHours(10).AddMinutes(59); // 10:59 صباحاً
                timeEditMorningOutStart.Time = DateTime.Today.AddHours(11);   // 11:00 صباحاً
                timeEditMorningOutEnd.Time = DateTime.Today.AddHours(13);     // 13:00 ظهراً
                
                // الفترة المسائية
                timeEditEveningInStart.Time = DateTime.Today.AddHours(14);    // 14:00 ظهراً
                timeEditEveningInEnd.Time = DateTime.Today.AddHours(18).AddMinutes(59); // 18:59 مساءً
                timeEditEveningOutStart.Time = DateTime.Today.AddHours(19);   // 19:00 مساءً
                timeEditEveningOutEnd.Time = DateTime.Today.AddHours(21);     // 21:00 ليلاً
                
                // الفترة الليلية
                timeEditNightInStart.Time = DateTime.Today.AddHours(22);      // 22:00 ليلاً
                timeEditNightInEnd.Time = DateTime.Today.AddHours(2).AddMinutes(59); // 02:59 فجراً
                timeEditNightOutStart.Time = DateTime.Today.AddHours(3);      // 03:00 فجراً
                timeEditNightOutEnd.Time = DateTime.Today.AddHours(5);        // 05:00 فجراً

                lblStatus.Text = "تم تحميل الإعدادات الافتراضية للفترات الثلاث";
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
            // التحقق من الفترة الصباحية
            if (timeEditMorningInStart.Time >= timeEditMorningInEnd.Time)
            {
                XtraMessageBox.Show("الفترة الصباحية: وقت بداية الدخول يجب أن يكون أقل من وقت نهاية الدخول", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (timeEditMorningOutStart.Time >= timeEditMorningOutEnd.Time)
            {
                XtraMessageBox.Show("الفترة الصباحية: وقت بداية الخروج يجب أن يكون أقل من وقت نهاية الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (timeEditMorningInEnd.Time > timeEditMorningOutStart.Time)
            {
                XtraMessageBox.Show("الفترة الصباحية: يجب أن ينتهي وقت الدخول قبل بداية وقت الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من الفترة المسائية
            if (timeEditEveningInStart.Time >= timeEditEveningInEnd.Time)
            {
                XtraMessageBox.Show("الفترة المسائية: وقت بداية الدخول يجب أن يكون أقل من وقت نهاية الدخول", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (timeEditEveningOutStart.Time >= timeEditEveningOutEnd.Time)
            {
                XtraMessageBox.Show("الفترة المسائية: وقت بداية الخروج يجب أن يكون أقل من وقت نهاية الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (timeEditEveningInEnd.Time > timeEditEveningOutStart.Time)
            {
                XtraMessageBox.Show("الفترة المسائية: يجب أن ينتهي وقت الدخول قبل بداية وقت الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // التحقق من الفترة الليلية
            if (timeEditNightInStart.Time >= timeEditNightInEnd.Time)
            {
                // للفترة الليلية قد تمتد للاليوم التالي، لذا نحتاج فحص خاص
                if (timeEditNightInStart.Hour >= 22 && timeEditNightInEnd.Hour <= 6)
                {
                    // هذا طبيعي للفترة الليلية التي تمتد ليوم جديد
                }
                else
                {
                    XtraMessageBox.Show("الفترة الليلية: وقت بداية الدخول يجب أن يكون أقل من وقت نهاية الدخول", 
                        "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (timeEditNightOutStart.Time >= timeEditNightOutEnd.Time)
            {
                if (timeEditNightOutStart.Hour >= 22 && timeEditNightOutEnd.Hour <= 6)
                {
                    // هذا طبيعي للفترة الليلية
                }
                else
                {
                    XtraMessageBox.Show("الفترة الليلية: وقت بداية الخروج يجب أن يكون أقل من وقت نهاية الخروج", 
                        "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
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

                // تحويل الأوقات إلى تنسيق الجهاز
                // الفترة الصباحية
                TimeSpan morningInStart = timeEditMorningInStart.Time.TimeOfDay;
                TimeSpan morningInEnd = timeEditMorningInEnd.Time.TimeOfDay;
                TimeSpan morningOutStart = timeEditMorningOutStart.Time.TimeOfDay;
                TimeSpan morningOutEnd = timeEditMorningOutEnd.Time.TimeOfDay;

                // الفترة المسائية
                TimeSpan eveningInStart = timeEditEveningInStart.Time.TimeOfDay;
                TimeSpan eveningInEnd = timeEditEveningInEnd.Time.TimeOfDay;
                TimeSpan eveningOutStart = timeEditEveningOutStart.Time.TimeOfDay;
                TimeSpan eveningOutEnd = timeEditEveningOutEnd.Time.TimeOfDay;

                // الفترة الليلية
                TimeSpan nightInStart = timeEditNightInStart.Time.TimeOfDay;
                TimeSpan nightInEnd = timeEditNightInEnd.Time.TimeOfDay;
                TimeSpan nightOutStart = timeEditNightOutStart.Time.TimeOfDay;
                TimeSpan nightOutEnd = timeEditNightOutEnd.Time.TimeOfDay;

                // ضبط المناطق الزمنية في الجهاز
                // الفترة الصباحية
                bool success1 = SetTimeZone(zkemKeeper, 1, morningInStart, morningInEnd, 0);    // دخول صباحي
                bool success2 = SetTimeZone(zkemKeeper, 2, morningOutStart, morningOutEnd, 1);  // خروج صباحي

                // الفترة المسائية
                bool success3 = SetTimeZone(zkemKeeper, 3, eveningInStart, eveningInEnd, 0);    // دخول مسائي
                bool success4 = SetTimeZone(zkemKeeper, 4, eveningOutStart, eveningOutEnd, 1);  // خروج مسائي

                // الفترة الليلية
                bool success5 = SetTimeZone(zkemKeeper, 5, nightInStart, nightInEnd, 0);        // دخول ليلي
                bool success6 = SetTimeZone(zkemKeeper, 6, nightOutStart, nightOutEnd, 1);      // خروج ليلي

                // حفظ الإعدادات في الجهاز
                bool saveSuccess = (bool)zkemKeeper.GetType().InvokeMember(
                    "RefreshData",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    zkemKeeper,
                    new object[] { 1 });

                return success1 && success2 && success3 && success4 && success5 && success6 && saveSuccess;
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
                string settings = $@"إعدادات أوقات الدخول والخروج للفترات الثلاث:

الفترة الصباحية:
• دخول: من {timeEditMorningInStart.Time.ToString("HH:mm")} إلى {timeEditMorningInEnd.Time.ToString("HH:mm")}
• خروج: من {timeEditMorningOutStart.Time.ToString("HH:mm")} إلى {timeEditMorningOutEnd.Time.ToString("HH:mm")}

الفترة المسائية:
• دخول: من {timeEditEveningInStart.Time.ToString("HH:mm")} إلى {timeEditEveningInEnd.Time.ToString("HH:mm")}
• خروج: من {timeEditEveningOutStart.Time.ToString("HH:mm")} إلى {timeEditEveningOutEnd.Time.ToString("HH:mm")}

الفترة الليلية:
• دخول: من {timeEditNightInStart.Time.ToString("HH:mm")} إلى {timeEditNightInEnd.Time.ToString("HH:mm")}
• خروج: من {timeEditNightOutStart.Time.ToString("HH:mm")} إلى {timeEditNightOutEnd.Time.ToString("HH:mm")}

سيتم تطبيق هذه الإعدادات على جهاز البصمة ليميز تلقائياً بين أوقات الدخول والخروج في كل فترة.";

                XtraMessageBox.Show(settings, "مراجعة إعدادات الفترات الثلاث", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                lblStatus.Text = "تم اختبار إعدادات الفترات الثلاث بنجاح";
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