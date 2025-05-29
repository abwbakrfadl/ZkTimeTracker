using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using ImprovedFingerprint.Services;
using ImprovedFingerprint.Models;

namespace ImprovedFingerprint.Forms
{
    public partial class IOTimeControlForm : XtraForm
    {
        private readonly DeviceService _deviceService;
        private readonly DatabaseService _databaseService;

        public IOTimeControlForm(DeviceService deviceService)
        {
            InitializeComponent();
            _deviceService = deviceService;
            _databaseService = new DatabaseService();
            
            this.Text = "ضبط أوقات الدخول والخروج - جهاز البصمة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            
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

                // تحميل الإعدادات الافتراضية للفترات الثلاث
                LoadMorningShiftSettings();
                LoadEveningShiftSettings();
                LoadNightShiftSettings();

                lblStatus.Text = "تم تحميل الإعدادات الافتراضية للفترات الثلاث";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الإعدادات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMorningShiftSettings()
        {
            var morningShift = DefaultTimeSettings.MorningShift;
            timeEditMorningInStart.Time = DateTime.Today.Add(morningShift.CheckInStartTime);
            timeEditMorningInEnd.Time = DateTime.Today.Add(morningShift.CheckInEndTime);
            timeEditMorningOutStart.Time = DateTime.Today.Add(morningShift.CheckOutStartTime);
            timeEditMorningOutEnd.Time = DateTime.Today.Add(morningShift.CheckOutEndTime);
        }

        private void LoadEveningShiftSettings()
        {
            var eveningShift = DefaultTimeSettings.EveningShift;
            timeEditEveningInStart.Time = DateTime.Today.Add(eveningShift.CheckInStartTime);
            timeEditEveningInEnd.Time = DateTime.Today.Add(eveningShift.CheckInEndTime);
            timeEditEveningOutStart.Time = DateTime.Today.Add(eveningShift.CheckOutStartTime);
            timeEditEveningOutEnd.Time = DateTime.Today.Add(eveningShift.CheckOutEndTime);
        }

        private void LoadNightShiftSettings()
        {
            var nightShift = DefaultTimeSettings.NightShift;
            timeEditNightInStart.Time = DateTime.Today.Add(nightShift.CheckInStartTime);
            
            // للفترة الليلية، نضيف يوم للأوقات التي تكون في اليوم التالي
            var nightInEndTime = nightShift.CheckInEndTime;
            if (nightInEndTime.Hours < 12) // إذا كان الوقت في الصباح الباكر
                nightInEndTime = nightInEndTime.Add(TimeSpan.FromDays(1));
            timeEditNightInEnd.Time = DateTime.Today.Add(nightInEndTime);
            
            var nightOutStartTime = nightShift.CheckOutStartTime;
            if (nightOutStartTime.Hours < 12)
                nightOutStartTime = nightOutStartTime.Add(TimeSpan.FromDays(1));
            timeEditNightOutStart.Time = DateTime.Today.Add(nightOutStartTime);
            
            var nightOutEndTime = nightShift.CheckOutEndTime;
            if (nightOutEndTime.Hours < 12)
                nightOutEndTime = nightOutEndTime.Add(TimeSpan.FromDays(1));
            timeEditNightOutEnd.Time = DateTime.Today.Add(nightOutEndTime);
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

                if (!ValidateTimeSettings())
                    return;

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري تطبيق إعدادات الوقت على الجهاز...";
                Application.DoEvents();

                bool success = ApplyTimeSettingsToDevice();

                if (success)
                {
                    SaveTimeSettingsToDatabase();
                    lblStatus.Text = "تم تطبيق إعدادات الوقت بنجاح على جهاز البصمة وحفظها في قاعدة البيانات";
                    XtraMessageBox.Show("تم تطبيق إعدادات التحكم في أوقات الدخول والخروج بنجاح", 
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
            if (!ValidateShiftTimes("الصباحية", timeEditMorningInStart.Time, timeEditMorningInEnd.Time,
                                   timeEditMorningOutStart.Time, timeEditMorningOutEnd.Time))
                return false;

            // التحقق من الفترة المسائية
            if (!ValidateShiftTimes("المسائية", timeEditEveningInStart.Time, timeEditEveningInEnd.Time,
                                   timeEditEveningOutStart.Time, timeEditEveningOutEnd.Time))
                return false;

            // للفترة الليلية لها معالجة خاصة بسبب امتدادها لليوم التالي
            if (!ValidateNightShiftTimes())
                return false;

            return true;
        }

        private bool ValidateShiftTimes(string shiftName, DateTime inStart, DateTime inEnd, DateTime outStart, DateTime outEnd)
        {
            if (inStart.TimeOfDay >= inEnd.TimeOfDay)
            {
                XtraMessageBox.Show($"الفترة {shiftName}: وقت بداية الدخول يجب أن يكون أقل من وقت نهاية الدخول", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (outStart.TimeOfDay >= outEnd.TimeOfDay)
            {
                XtraMessageBox.Show($"الفترة {shiftName}: وقت بداية الخروج يجب أن يكون أقل من وقت نهاية الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (inEnd.TimeOfDay > outStart.TimeOfDay)
            {
                XtraMessageBox.Show($"الفترة {shiftName}: يجب أن ينتهي وقت الدخول قبل بداية وقت الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidateNightShiftTimes()
        {
            // للفترة الليلية، نتعامل مع الأوقات التي قد تمتد لليوم التالي
            var nightInStart = timeEditNightInStart.Time.TimeOfDay;
            var nightInEnd = timeEditNightInEnd.Time.TimeOfDay;
            var nightOutStart = timeEditNightOutStart.Time.TimeOfDay;
            var nightOutEnd = timeEditNightOutEnd.Time.TimeOfDay;

            // إذا كان وقت النهاية أقل من وقت البداية، فهذا يعني أنه في اليوم التالي
            if (nightInEnd < nightInStart && nightInStart.Hours >= 22)
            {
                // هذا طبيعي للفترة الليلية
            }
            else if (nightInStart >= nightInEnd)
            {
                XtraMessageBox.Show("الفترة الليلية: وقت بداية الدخول يجب أن يكون أقل من وقت نهاية الدخول", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nightOutEnd < nightOutStart && nightOutStart.Hours >= 22)
            {
                // هذا طبيعي للفترة الليلية
            }
            else if (nightOutStart >= nightOutEnd)
            {
                XtraMessageBox.Show("الفترة الليلية: وقت بداية الخروج يجب أن يكون أقل من وقت نهاية الخروج", 
                    "خطأ في الإعدادات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ApplyTimeSettingsToDevice()
        {
            try
            {
                // ضبط الفترة الصباحية (المناطق الزمنية 1 و 2)
                bool morning1 = _deviceService.SetTimeZone(1, timeEditMorningInStart.Time.TimeOfDay, timeEditMorningInEnd.Time.TimeOfDay);
                bool morning2 = _deviceService.SetTimeZone(2, timeEditMorningOutStart.Time.TimeOfDay, timeEditMorningOutEnd.Time.TimeOfDay);

                // ضبط الفترة المسائية (المناطق الزمنية 3 و 4)
                bool evening1 = _deviceService.SetTimeZone(3, timeEditEveningInStart.Time.TimeOfDay, timeEditEveningInEnd.Time.TimeOfDay);
                bool evening2 = _deviceService.SetTimeZone(4, timeEditEveningOutStart.Time.TimeOfDay, timeEditEveningOutEnd.Time.TimeOfDay);

                // ضبط الفترة الليلية (المناطق الزمنية 5 و 6)
                bool night1 = _deviceService.SetTimeZone(5, timeEditNightInStart.Time.TimeOfDay, timeEditNightInEnd.Time.TimeOfDay);
                bool night2 = _deviceService.SetTimeZone(6, timeEditNightOutStart.Time.TimeOfDay, timeEditNightOutEnd.Time.TimeOfDay);

                // حفظ الإعدادات في الجهاز
                bool refreshSuccess = _deviceService.RefreshData();

                return morning1 && morning2 && evening1 && evening2 && night1 && night2 && refreshSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في تطبيق إعدادات الوقت على الجهاز: {ex.Message}");
            }
        }

        private void SaveTimeSettingsToDatabase()
        {
            try
            {
                // حفظ إعدادات الفترة الصباحية
                var morningSettings = new TimeSettings
                {
                    ShiftName = "الوردية الصباحية",
                    CheckInStartTime = timeEditMorningInStart.Time.TimeOfDay,
                    CheckInEndTime = timeEditMorningInEnd.Time.TimeOfDay,
                    CheckOutStartTime = timeEditMorningOutStart.Time.TimeOfDay,
                    CheckOutEndTime = timeEditMorningOutEnd.Time.TimeOfDay,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Notes = "تم التطبيق على الجهاز"
                };

                // حفظ إعدادات الفترة المسائية
                var eveningSettings = new TimeSettings
                {
                    ShiftName = "الوردية المسائية",
                    CheckInStartTime = timeEditEveningInStart.Time.TimeOfDay,
                    CheckInEndTime = timeEditEveningInEnd.Time.TimeOfDay,
                    CheckOutStartTime = timeEditEveningOutStart.Time.TimeOfDay,
                    CheckOutEndTime = timeEditEveningOutEnd.Time.TimeOfDay,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Notes = "تم التطبيق على الجهاز"
                };

                // حفظ إعدادات الفترة الليلية
                var nightSettings = new TimeSettings
                {
                    ShiftName = "الوردية الليلية",
                    CheckInStartTime = timeEditNightInStart.Time.TimeOfDay,
                    CheckInEndTime = timeEditNightInEnd.Time.TimeOfDay,
                    CheckOutStartTime = timeEditNightOutStart.Time.TimeOfDay,
                    CheckOutEndTime = timeEditNightOutEnd.Time.TimeOfDay,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Notes = "تم التطبيق على الجهاز - فترة ليلية قد تمتد لليوم التالي"
                };

                _databaseService.SaveTimeSettings(morningSettings);
                _databaseService.SaveTimeSettings(eveningSettings);
                _databaseService.SaveTimeSettings(nightSettings);
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في حفظ الإعدادات في قاعدة البيانات: {ex.Message}");
            }
        }

        private void btnTestSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTimeSettings())
                    return;

                string settings = GenerateSettingsReport();
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

        private string GenerateSettingsReport()
        {
            return $@"إعدادات أوقات الدخول والخروج للفترات الثلاث:

الفترة الصباحية:
• دخول: من {timeEditMorningInStart.Time:HH:mm} إلى {timeEditMorningInEnd.Time:HH:mm}
• خروج: من {timeEditMorningOutStart.Time:HH:mm} إلى {timeEditMorningOutEnd.Time:HH:mm}

الفترة المسائية:
• دخول: من {timeEditEveningInStart.Time:HH:mm} إلى {timeEditEveningInEnd.Time:HH:mm}
• خروج: من {timeEditEveningOutStart.Time:HH:mm} إلى {timeEditEveningOutEnd.Time:HH:mm}

الفترة الليلية:
• دخول: من {timeEditNightInStart.Time:HH:mm} إلى {timeEditNightInEnd.Time:HH:mm}
• خروج: من {timeEditNightOutStart.Time:HH:mm} إلى {timeEditNightOutEnd.Time:HH:mm}

سيتم تطبيق هذه الإعدادات على جهاز البصمة ليميز تلقائياً بين أوقات الدخول والخروج في كل فترة.";
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

        private void btnLoadFromDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري تحميل الإعدادات من قاعدة البيانات...";
                Application.DoEvents();

                var timeSettings = _databaseService.GetTimeSettings();
                
                foreach (var setting in timeSettings)
                {
                    switch (setting.ShiftName)
                    {
                        case "الوردية الصباحية":
                            timeEditMorningInStart.Time = DateTime.Today.Add(setting.CheckInStartTime);
                            timeEditMorningInEnd.Time = DateTime.Today.Add(setting.CheckInEndTime);
                            timeEditMorningOutStart.Time = DateTime.Today.Add(setting.CheckOutStartTime);
                            timeEditMorningOutEnd.Time = DateTime.Today.Add(setting.CheckOutEndTime);
                            break;
                            
                        case "الوردية المسائية":
                            timeEditEveningInStart.Time = DateTime.Today.Add(setting.CheckInStartTime);
                            timeEditEveningInEnd.Time = DateTime.Today.Add(setting.CheckInEndTime);
                            timeEditEveningOutStart.Time = DateTime.Today.Add(setting.CheckOutStartTime);
                            timeEditEveningOutEnd.Time = DateTime.Today.Add(setting.CheckOutEndTime);
                            break;
                            
                        case "الوردية الليلية":
                            timeEditNightInStart.Time = DateTime.Today.Add(setting.CheckInStartTime);
                            timeEditNightInEnd.Time = DateTime.Today.Add(setting.CheckInEndTime);
                            timeEditNightOutStart.Time = DateTime.Today.Add(setting.CheckOutStartTime);
                            timeEditNightOutEnd.Time = DateTime.Today.Add(setting.CheckOutEndTime);
                            break;
                    }
                }

                lblStatus.Text = "تم تحميل الإعدادات من قاعدة البيانات بنجاح";
                XtraMessageBox.Show("تم تحميل إعدادات الأوقات من قاعدة البيانات بنجاح", 
                    "نجح التحميل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في تحميل الإعدادات من قاعدة البيانات";
                XtraMessageBox.Show($"خطأ في تحميل الإعدادات: {ex.Message}", "خطأ", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}