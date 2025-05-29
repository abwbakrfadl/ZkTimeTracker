using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class MonthlyReportForm : Form
    {
      //  private SqlConnection conn;
        private DataGridView dgvReport;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerate;

        public MonthlyReportForm()
        {
            InitializeComponent();
        //    conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
        }

        private void InitializeControls()
        {
            // تهيئة عناصر التحكم
            this.Text = "التقرير الشهري للحضور والانصراف";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1200, 600);

            // إنشاء التقويم
            dtpStartDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(20, 20),
                Size = new Size(120, 20)
            };

            dtpEndDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(160, 20),
                Size = new Size(120, 20)
            };

            // زر عرض التقرير
            btnGenerate = new Button
            {
                Text = "عرض التقرير",
                Location = new Point(300, 20),
                Size = new Size(100, 30)
            };
            btnGenerate.Click += BtnGenerate_Click;

            // جدول عرض البيانات
            dgvReport = new DataGridView
            {
                Dock = DockStyle.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RightToLeft = RightToLeft.Yes,
                Size = new Size(1160, 500),
                Location = new Point(20, 70)
            };

            // إضافة عناصر التحكم للنموذج
            this.Controls.AddRange(new Control[] { dtpStartDate, dtpEndDate, btnGenerate, dgvReport });
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(GetReportQuery(), connection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvReport.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ: " + ex.Message);
                }
            }
        }

        private string GetReportQuery()
        {
            return @"
WITH AttendanceCTE AS (
    SELECT 
        e.UserID,
        e.Name,
        sh.ShiftName,
        CAST(a.DateTime AS DATE) AS AttendanceDate,
        sh.StartTime AS ScheduledCheckIn,
        sh.EndTime AS ScheduledCheckOut,
        -- إضافة CheckInStart كبداية فترة تسجيل الحضور
        CAST(@StartDate AS DATETIME) + CAST(sh.CheckInStart AS DATETIME) AS CheckInStartTime,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        AND @StartDate BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        AND CAST(a.DateTime AS DATE) BETWEEN @StartDate AND @EndDate
    WHERE e.Enabled = 1
    GROUP BY e.UserID, e.Name, sh.ShiftName, CAST(a.DateTime AS DATE), sh.StartTime, sh.EndTime, sh.CheckInStart
),

LeavePermissionCTE AS (
    SELECT 
        e.UserID,
        l.LeaveDate,
        l.LeaveType,
        p.PermissionDate,
        p.Status AS PermissionStatus
    FROM Employees e
    LEFT JOIN Leaves l ON e.UserID = l.UserID 
        AND l.LeaveDate BETWEEN @StartDate AND @EndDate
    LEFT JOIN Permissions p ON e.UserID = p.UserID 
        AND p.PermissionDate BETWEEN @StartDate AND @EndDate
)

SELECT 
    a.UserID AS 'المعرف',
    a.Name AS 'الاسم',
    a.ShiftName AS 'الوردية',
    a.AttendanceDate AS 'التاريخ',
    CASE DATENAME(WEEKDAY, a.AttendanceDate)
        WHEN 'Sunday' THEN N'الأحد'
        WHEN 'Monday' THEN N'الاثنين'
        WHEN 'Tuesday' THEN N'الثلاثاء'
        WHEN 'Wednesday' THEN N'الأربعاء'
        WHEN 'Thursday' THEN N'الخميس'
        WHEN 'Friday' THEN N'الجمعة'
        WHEN 'Saturday' THEN N'السبت'
    END AS 'يوم الأسبوع',
    -- عرض الأوقات بنمط 24 ساعة
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 108), '--') AS 'الحضور الفعلي',
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 108), '--') AS 'الانصراف الفعلي',
    CASE 
        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
        -- حضور قبل فترة الحضور (غير مسموح)
        WHEN a.ActualCheckIn < a.CheckInStartTime THEN 'غائب (حضور مبكر غير مسموح)'
        -- غياب كامل
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
        -- تأخير بدون انصراف
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL 
             AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر بدون انصراف'
        -- حضور نصف يوم
        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) 
             AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم'
        -- تأخير
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'غائب-حضور متاخر'
        -- انصراف مبكر
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
        -- حاضر ضمن فترة السماح
        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        ELSE 'غائب'
    END AS 'الحالة',
    s.CheckInGracePeriod AS 'سماحية الحضور (دقيقة)',
    s.CheckOutGracePeriod AS 'سماحية الانصراف (دقيقة)',
    l.LeaveType AS 'نوع الإجازة',
    l.PermissionStatus AS 'حالة الإذن'
FROM AttendanceCTE a
LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
LEFT JOIN WorkingDays w ON w.DayOfWeek = (
    CASE DATENAME(WEEKDAY, a.AttendanceDate)
        WHEN 'Sunday' THEN N'الأحد'
        WHEN 'Monday' THEN N'الاثنين'
        WHEN 'Tuesday' THEN N'الثلاثاء'
        WHEN 'Wednesday' THEN N'الأربعاء'
        WHEN 'Thursday' THEN N'الخميس'
        WHEN 'Friday' THEN N'الجمعة'
        WHEN 'Saturday' THEN N'السبت'
    END
)
LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
ORDER BY 
    a.Name ASC,
    a.AttendanceDate ASC,
    a.ShiftName ASC;
";
        }
        //        private string GetReportQuery()
        //        {
        //            // هنا نضع نص الاستعلام الذي قمنا بإنشائه سابقاً
        //            return @"WITH AttendanceCTE AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        sh.ShiftName,
        //        CAST(a.DateTime AS DATE) AS AttendanceDate,
        //        sh.StartTime AS ScheduledCheckIn,
        //        sh.EndTime AS ScheduledCheckOut,
        //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        //        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
        //    FROM Employees e
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        //        AND @StartDate BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        //        AND CAST(a.DateTime AS DATE) BETWEEN @StartDate AND @EndDate
        //    WHERE e.Enabled = 1
        //    GROUP BY e.UserID, e.Name, sh.ShiftName, CAST(a.DateTime AS DATE), sh.StartTime, sh.EndTime
        //),

        //LeavePermissionCTE AS (
        //    SELECT 
        //        e.UserID,
        //        l.LeaveDate,
        //        l.LeaveType,
        //        p.PermissionDate,
        //        p.Status AS PermissionStatus
        //    FROM Employees e
        //    LEFT JOIN Leaves l ON e.UserID = l.UserID 
        //        AND l.LeaveDate BETWEEN @StartDate AND @EndDate
        //    LEFT JOIN Permissions p ON e.UserID = p.UserID 
        //        AND p.PermissionDate BETWEEN @StartDate AND @EndDate
        //)


        //SELECT 
        //    --a.UserID AS 'المعرف',
        //    --a.Name AS 'الاسم',
        //    --a.ShiftName AS 'الوردية',
        //    --a.AttendanceDate AS 'التاريخ',

        //    a.UserID AS 'المعرف',
        //    a.Name AS 'الاسم',
        //    a.ShiftName AS 'الوردية',
        //    a.AttendanceDate AS 'التاريخ',
        //    CASE DATENAME(WEEKDAY, a.AttendanceDate)
        //        WHEN 'Sunday' THEN N'الأحد'
        //        WHEN 'Monday' THEN N'الاثنين'
        //        WHEN 'Tuesday' THEN N'الثلاثاء'
        //        WHEN 'Wednesday' THEN N'الأربعاء'
        //        WHEN 'Thursday' THEN N'الخميس'
        //        WHEN 'Friday' THEN N'الجمعة'
        //        WHEN 'Saturday' THEN N'السبت'
        //    END AS 'يوم الأسبوع',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
        //    CASE 
        //        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        //        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        //        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'


        //       WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'

        //        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)  THEN 'حضور متاخر بدون انصراف'
        //        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم' 
        //        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN ' غائب-حضور متاخر '
        //        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
        //        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        //        ELSE 'غائب'
        //    END AS 'الحالة',
        //    s.CheckInGracePeriod AS 'سماحية الحضور (دقيقة)',
        //    s.CheckOutGracePeriod AS 'سماحية الانصراف (دقيقة)',
        //    l.LeaveType AS 'نوع الإجازة',
        //    l.PermissionStatus AS 'حالة الإذن'
        //FROM AttendanceCTE a
        //LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
        //LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
        //LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        //    CASE DATENAME(WEEKDAY, a.AttendanceDate)
        //        WHEN 'Sunday' THEN N'الأحد'
        //        WHEN 'Monday' THEN N'الاثنين'
        //        WHEN 'Tuesday' THEN N'الثلاثاء'
        //        WHEN 'Wednesday' THEN N'الأربعاء'
        //        WHEN 'Thursday' THEN N'الخميس'
        //        WHEN 'Friday' THEN N'الجمعة'
        //        WHEN 'Saturday' THEN N'السبت'
        //    END
        //)
        //LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
        //ORDER BY 
        //    a.Name ASC,
        //    a.AttendanceDate ASC,
        //    a.ShiftName ASC;  "; // الاستعلام الكامل هنا
        //                         }
        // WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم'

        //private string GetReportQuery()
        //{
        //    // هنا نضع نص الاستعلام الذي قمنا بإنشائه سابقاً
        //    return @"WITH DateRange AS (
        //    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        //        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
        //    FROM sys.objects
        //),
        //AttendanceCTE AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        sh.ShiftName,
        //        d.Date AS AttendanceDate,
        //        sh.StartTime AS ScheduledCheckIn,
        //        sh.EndTime AS ScheduledCheckOut,
        //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        //        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
        //    FROM Employees e
        //    CROSS JOIN DateRange d
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        //        AND d.Date BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        //        AND CAST(a.DateTime AS DATE) = d.Date
        //    WHERE e.Enabled = 1
        //    GROUP BY e.UserID, e.Name, sh.ShiftName, d.Date, sh.StartTime, sh.EndTime
        //),

        //LeavePermissionCTE AS (
        //    SELECT 
        //        e.UserID,
        //        l.LeaveDate,
        //        l.LeaveType,
        //        p.PermissionDate,
        //        p.Status AS PermissionStatus
        //    FROM Employees e
        //    LEFT JOIN Leaves l ON e.UserID = l.UserID 
        //        AND l.LeaveDate BETWEEN @StartDate AND @EndDate
        //    LEFT JOIN Permissions p ON e.UserID = p.UserID 
        //        AND p.PermissionDate BETWEEN @StartDate AND @EndDate
        //)

        //SELECT 
        //    a.UserID AS 'المعرف',
        //    a.Name AS 'الاسم',
        //    a.ShiftName AS 'الوردية',
        //    a.AttendanceDate AS 'التاريخ',
        //    CASE DATENAME(WEEKDAY, a.AttendanceDate)
        //        WHEN 'Sunday' THEN N'الأحد'
        //        WHEN 'Monday' THEN N'الاثنين'
        //        WHEN 'Tuesday' THEN N'الثلاثاء'
        //        WHEN 'Wednesday' THEN N'الأربعاء'
        //        WHEN 'Thursday' THEN N'الخميس'
        //        WHEN 'Friday' THEN N'الجمعة'
        //        WHEN 'Saturday' THEN N'السبت'
        //    END AS 'يوم الأسبوع',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
        //    CASE 
        //        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        //        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        //        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
        //        WHEN a.ActualCheckIn IS NULL THEN 'غائب'
        //        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم'
        //        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'غائب'
        //        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
        //        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        //        ELSE 'غائب'
        //    END AS 'الحالة',
        //    s.CheckInGracePeriod AS 'سماحية الحضور (دقيقة)',
        //    s.CheckOutGracePeriod AS 'سماحية الانصراف (دقيقة)',
        //    l.LeaveType AS 'نوع الإجازة',
        //    l.PermissionStatus AS 'حالة الإذن'
        //FROM AttendanceCTE a
        //LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
        //LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
        //LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        //    CASE DATENAME(WEEKDAY, a.AttendanceDate)
        //        WHEN 'Sunday' THEN N'الأحد'
        //        WHEN 'Monday' THEN N'الاثنين'
        //        WHEN 'Tuesday' THEN N'الثلاثاء'
        //        WHEN 'Wednesday' THEN N'الأربعاء'
        //        WHEN 'Thursday' THEN N'الخميس'
        //        WHEN 'Friday' THEN N'الجمعة'
        //        WHEN 'Saturday' THEN N'السبت'
        //    END
        //)
        //LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
        //ORDER BY 
        //    a.Name ASC,
        //    a.AttendanceDate ASC,
        //    a.ShiftName ASC;"; // الاستعلام الكامل هنا
        //}
    }
}
