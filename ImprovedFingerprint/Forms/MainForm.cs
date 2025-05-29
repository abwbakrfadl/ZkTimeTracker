using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using ImprovedFingerprint.Services;
using ImprovedFingerprint.Helpers;

namespace ImprovedFingerprint.Forms
{
    public partial class MainForm : RibbonForm
    {
        private DeviceService _deviceService;
        private DatabaseService _databaseService;
        private bool _isDeviceConnected = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeServices();
            SetupRibbon();
            
            this.Text = "نظام إدارة البصمة - ZKTeco U350";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.WindowState = FormWindowState.Maximized;
            
            UpdateConnectionStatus();
        }

        private void InitializeServices()
        {
            try
            {
                _deviceService = new DeviceService();
                _databaseService = new DatabaseService();
                
                // اختبار الاتصال بقاعدة البيانات
                if (_databaseService.TestConnection())
                {
                    lblDatabaseStatus.Text = "قاعدة البيانات: متصلة ✓";
                    lblDatabaseStatus.Appearance.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblDatabaseStatus.Text = "قاعدة البيانات: غير متصلة ✗";
                    lblDatabaseStatus.Appearance.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تهيئة الخدمات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupRibbon()
        {
            // سيتم إعداد شريط الأدوات هنا
            UpdateRibbonButtons();
        }

        private void UpdateRibbonButtons()
        {
            // تحديث حالة الأزرار بناءً على اتصال الجهاز
            btnDisconnectDevice.Enabled = _isDeviceConnected;
            btnTimeControl.Enabled = _isDeviceConnected;
            btnImportEmployees.Enabled = _isDeviceConnected;
            btnSyncData.Enabled = _isDeviceConnected;
            btnDeviceInfo.Enabled = _isDeviceConnected;
        }

        private void UpdateConnectionStatus()
        {
            _isDeviceConnected = _deviceService?.IsConnected ?? false;
            
            if (_isDeviceConnected)
            {
                lblDeviceStatus.Text = "جهاز البصمة: متصل ✓";
                lblDeviceStatus.Appearance.ForeColor = System.Drawing.Color.Green;
                
                if (!string.IsNullOrEmpty(_deviceService.DeviceInfo))
                {
                    lblDeviceInfo.Text = _deviceService.DeviceInfo.Replace("\n", " | ");
                }
            }
            else
            {
                lblDeviceStatus.Text = "جهاز البصمة: غير متصل ✗";
                lblDeviceStatus.Appearance.ForeColor = System.Drawing.Color.Red;
                lblDeviceInfo.Text = "لا يوجد معلومات جهاز";
            }
            
            UpdateRibbonButtons();
        }

        private void btnConnectDevice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (var connectionForm = new DeviceConnectionForm())
                {
                    if (connectionForm.ShowDialog() == DialogResult.OK)
                    {
                        var ipAddress = connectionForm.IPAddress;
                        var port = connectionForm.Port;
                        
                        lblDeviceStatus.Text = "جاري الاتصال بالجهاز...";
                        Application.DoEvents();
                        
                        if (_deviceService.Connect(ipAddress, port))
                        {
                            UpdateConnectionStatus();
                            XtraMessageBox.Show("تم الاتصال بجهاز البصمة بنجاح", "نجح الاتصال",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            UpdateConnectionStatus();
                            XtraMessageBox.Show("فشل في الاتصال بجهاز البصمة. تحقق من عنوان IP والمنفذ",
                                "فشل الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateConnectionStatus();
                XtraMessageBox.Show($"خطأ في الاتصال بالجهاز: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnectDevice_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_deviceService != null && _deviceService.IsConnected)
                {
                    _deviceService.Disconnect();
                    UpdateConnectionStatus();
                    XtraMessageBox.Show("تم قطع الاتصال بجهاز البصمة", "تم قطع الاتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في قطع الاتصال: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimeControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!_isDeviceConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var timeControlForm = new IOTimeControlForm(_deviceService))
                {
                    timeControlForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في فتح شاشة ضبط الأوقات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportEmployees_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!_isDeviceConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var importForm = new EmployeeDataImportForm(_deviceService))
                {
                    importForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في فتح شاشة استيراد الموظفين: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAttendanceReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (var reportForm = new AttendanceReportForm(_databaseService))
                {
                    reportForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في فتح شاشة تقارير الحضور: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSyncData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!_isDeviceConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = XtraMessageBox.Show(
                    "هل تريد مزامنة بيانات الحضور من الجهاز إلى قاعدة البيانات؟\nقد يستغرق هذا بعض الوقت.",
                    "تأكيد المزامنة",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SyncAttendanceData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في مزامنة البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SyncAttendanceData()
        {
            try
            {
                lblDeviceStatus.Text = "جاري مزامنة بيانات الحضور...";
                Application.DoEvents();

                var attendanceRecords = _deviceService.GetAttendanceRecords();
                int successCount = 0;
                int errorCount = 0;

                foreach (var record in attendanceRecords)
                {
                    try
                    {
                        // البحث عن اسم الموظف
                        var employees = _databaseService.GetAllEmployees();
                        var employee = employees.Find(e => e.EmployeeNumber == record.EmployeeNumber);
                        
                        if (employee != null)
                        {
                            record.EmployeeName = employee.FullName;
                            record.EmployeeId = employee.EmployeeId;
                        }

                        if (_databaseService.InsertAttendanceRecord(record))
                        {
                            successCount++;
                        }
                        else
                        {
                            errorCount++;
                        }
                    }
                    catch
                    {
                        errorCount++;
                    }
                }

                UpdateConnectionStatus();

                var message = $"تم مزامنة بيانات الحضور:\n" +
                             $"• تم إدراج {successCount} سجل بنجاح\n" +
                             $"• فشل في إدراج {errorCount} سجل";

                XtraMessageBox.Show(message, "نتائج المزامنة",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateConnectionStatus();
                throw new Exception($"خطأ في مزامنة البيانات: {ex.Message}");
            }
        }

        private void btnDeviceInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!_isDeviceConnected)
                {
                    XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var deviceInfo = _deviceService.DeviceInfo ?? "لا توجد معلومات متاحة";
                XtraMessageBox.Show(deviceInfo, "معلومات الجهاز",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في عرض معلومات الجهاز: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatabaseSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                using (var settingsForm = new DatabaseSettingsForm())
                {
                    if (settingsForm.ShowDialog() == DialogResult.OK)
                    {
                        // إعادة تهيئة خدمة قاعدة البيانات
                        _databaseService = new DatabaseService();
                        
                        if (_databaseService.TestConnection())
                        {
                            lblDatabaseStatus.Text = "قاعدة البيانات: متصلة ✓";
                            lblDatabaseStatus.Appearance.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblDatabaseStatus.Text = "قاعدة البيانات: غير متصلة ✗";
                            lblDatabaseStatus.Appearance.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في إعدادات قاعدة البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            var aboutMessage = @"نظام إدارة البصمة - ZKTeco U350
الإصدار 2.0

تطوير: فريق التطوير
تاريخ الإصدار: 2024

الميزات:
• إدارة أجهزة البصمة ZKTeco U350
• ضبط أوقات الدخول والخروج للفترات الثلاث
• استيراد بيانات الموظفين من الجهاز
• تقارير الحضور والانصراف
• مزامنة البيانات التلقائية

للدعم التقني، الرجاء التواصل مع قسم تقنية المعلومات.";

            XtraMessageBox.Show(aboutMessage, "حول البرنامج",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (_deviceService?.IsConnected == true)
                {
                    _deviceService.Disconnect();
                }
                
                _deviceService?.Dispose();
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ فقط، لا نمنع الإغلاق
                System.Diagnostics.Debug.WriteLine($"خطأ عند إغلاق البرنامج: {ex.Message}");
            }
            
            base.OnFormClosing(e);
        }
    }
}