using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Fingerprint1.view
{
    public partial class AttendanceReport : Form
    {
        
        private DataTable reportData;
        private DataGridView dataGridView;
        //private SqlConnection connectionString;
        public AttendanceReport()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeFormControls();
        }

        private void InitializeDatabaseConnection()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
        }

        private void InitializeFormControls()
        {
            this.Text = "تقرير الحضور والخصومات";
            this.Size = new System.Drawing.Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // عناصر تحديد النطاق الزمني والموظف
            Label lblStartDate = new Label { Text = "من تاريخ:", Location = new System.Drawing.Point(20, 20) };
            DateTimePicker dtpStartDate = new DateTimePicker { Location = new System.Drawing.Point(100, 20), Format = DateTimePickerFormat.Short };
            Label lblEndDate = new Label { Text = "إلى تاريخ:", Location = new System.Drawing.Point(250, 20) };
            DateTimePicker dtpEndDate = new DateTimePicker { Location = new System.Drawing.Point(330, 20), Format = DateTimePickerFormat.Short };
            Label lblEmployee = new Label { Text = "اختر موظف:", Location = new System.Drawing.Point(500, 20) };
            ComboBox cmbEmployees = new ComboBox { Location = new System.Drawing.Point(590, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            // حقل إدخال مبلغ الموظف
            Label lblEmployeeAmount = new Label { Text = "مبلغ الموظف:", Location = new System.Drawing.Point(820, 20) };
            TextBox txtEmployeeAmount = new TextBox { Location = new System.Drawing.Point(920, 20), Width = 150 };

            Button btnGenerate = new Button { Text = "عرض التقرير", Location = new System.Drawing.Point(1090, 20), BackColor = System.Drawing.Color.LightBlue };

            // حقول النتائج
            Label lblTotalDiscounts = new Label { Text = "إجمالي الخصومات:", Location = new System.Drawing.Point(20, 80) };
            TextBox txtTotalDiscounts = new TextBox { Location = new System.Drawing.Point(160, 80), Width = 150, Enabled = false };
            Label lblNetAmount = new Label { Text = "الصافي:", Location = new System.Drawing.Point(350, 80) };
            TextBox txtNetAmount = new TextBox { Location = new System.Drawing.Point(430, 80), Width = 150, Enabled = false };

            // جدول البيانات
            dataGridView = new DataGridView
            {
                Location = new System.Drawing.Point(20, 130),
                Size = new System.Drawing.Size(1150, 450),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };


            // إضافة العناصر إلى النموذج
            Controls.Add(lblStartDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(lblEmployee);
            Controls.Add(cmbEmployees);
            Controls.Add(lblEmployeeAmount);
            Controls.Add(txtEmployeeAmount);
            Controls.Add(btnGenerate);
            Controls.Add(lblTotalDiscounts);
            Controls.Add(txtTotalDiscounts);
            Controls.Add(lblNetAmount);
            Controls.Add(txtNetAmount);
            Controls.Add(dataGridView);

            // تعبئة ComboBox بالموظفين
            LoadEmployees(cmbEmployees);

            // حدث النقر على زر "عرض التقرير"
            btnGenerate.Click += (sender, e) =>
            {
                if (cmbEmployees.SelectedValue == null)
                {
                    MessageBox.Show("يرجى اختيار موظف!");
                    return;
                }

                // التحقق من إدخال مبلغ الموظف
                if (!decimal.TryParse(txtEmployeeAmount.Text, out decimal employeeAmount))
                {
                    MessageBox.Show("يرجى إدخال مبلغ الموظف بشكل صحيح!");
                    return;
                }

                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;
                string userId = cmbEmployees.SelectedValue?.ToString() ?? "";
                if (string.IsNullOrEmpty(userId))
                {
                    MessageBox.Show("يرجى اختيار موظف!");
                    return;
                }

                LoadReportData(userId, startDate, endDate);
                CalculateTotals(employeeAmount, txtTotalDiscounts, txtNetAmount);
            };
        }

        private void LoadEmployees(ComboBox cmbEmployees)
        {
           AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT UserID, Name FROM Employees WHERE Enabled = 1", connectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbEmployees.DataSource = dt;
                cmbEmployees.DisplayMember = "Name";
                cmbEmployees.ValueMember = "UserID"; // ← يجب أن يطابق اسم العمود (UserID)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }

        private void LoadReportData(string userId, DateTime startDate, DateTime endDate)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");


            string query = @"CREATE OR ALTER FUNCTION GetAttendanceReport
(
    @FromDate DATE,
    @ToDate DATE,
    @SelectedUserID NVARCHAR(50) = NULL
)
RETURNS TABLE
AS
RETURN
(
    WITH DateRange AS (
        SELECT TOP (ABS(DATEDIFF(DAY, @FromDate, @ToDate)) + 1)
            DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @FromDate) AS Date
        FROM sys.objects
    ),
    AttendanceCTE AS (
        SELECT 
            e.UserID,
            e.Name,
            sh.ShiftName,
            d.Date AS AttendanceDate,
            sh.StartTime AS ScheduledCheckIn,
            sh.EndTime AS ScheduledCheckOut,
            CAST(MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS DATETIME) AS ActualCheckIn,
            CAST(MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS DATETIME) AS ActualCheckOut
        FROM Employees e
        CROSS JOIN DateRange d
        INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
            AND d.Date BETWEEN sc.StartDate AND sc.EndDate
        INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        LEFT JOIN Attendance a ON e.UserID = a.UserID 
            AND CAST(a.DateTime AS DATE) = d.Date
        WHERE e.Enabled = 1
            AND (@SelectedUserID IS NULL OR e.UserID = @SelectedUserID)
        GROUP BY e.UserID, e.Name, sh.ShiftName, d.Date, sh.StartTime, sh.EndTime
    ),
    LeavePermissionCTE AS (
        SELECT 
            e.UserID,
            d.Date AS AttendanceDate,
            MAX(CASE WHEN l.LeaveDate = d.Date THEN l.LeaveType END) AS LeaveType,
            MAX(CASE WHEN p.PermissionDate = d.Date THEN p.Status END) AS PermissionStatus
        FROM Employees e
        CROSS JOIN DateRange d
        LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = d.Date
        LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = d.Date
        WHERE @SelectedUserID IS NULL OR e.UserID = @SelectedUserID
        GROUP BY e.UserID, d.Date
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
    FORMAT(a.ScheduledCheckIn, 'HH:mm:ss') AS 'ميعاد الحضور المخطط',
    FORMAT(a.ActualCheckIn, 'HH:mm:ss') AS 'الحضور الفعلي',
    FORMAT(a.ScheduledCheckOut, 'HH:mm:ss') AS 'ميعاد الانصراف المخطط',
    FORMAT(a.ActualCheckOut, 'HH:mm:ss') AS 'الانصراف الفعلي',
    CASE 
        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND 
            CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'حضور متاخر بدون انصراف'
        WHEN (a.ActualCheckIn IS NOT NULL AND 
            CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND 
            a.ActualCheckOut IS NULL THEN N'حضور نصف يوم'
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'غائب-حضور متاخر'
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'انصراف مبكر'
        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'حاضر'
        ELSE N'غائب'
    END AS 'الحالة',
    COALESCE(d.DiscountAmount, 0) AS 'مبلغ الخصم',
    s.CheckInGracePeriod AS 'سماحية الحضور (دقيقة)',
    s.CheckOutGracePeriod AS 'سماحية الانصراف (دقيقة)',
    l.LeaveType AS 'نوع الإجازة',
    l.PermissionStatus AS 'حالة الإذن'
FROM AttendanceCTE a
LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.AttendanceDate
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
LEFT JOIN Discounts d ON
    CASE
        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND 
            CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'حضور متاخر بدون انصراف'
        WHEN (a.ActualCheckIn IS NOT NULL AND 
            CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND 
            a.ActualCheckOut IS NULL THEN N'حضور نصف يوم'
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'غائب-حضور متاخر'
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'انصراف مبكر'
        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'حاضر'
        ELSE N'غائب'
    END = d.ConditionName
ORDER BY a.AttendanceDate, a.ShiftName, a.Name;
";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {

                    //SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@FromDate", startDate);
                    cmd.Parameters.AddWithValue("@ToDate", endDate);
                    cmd.Parameters.AddWithValue("@SelectedUserID", userId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    reportData = new DataTable();
                    da.Fill(reportData);

                    // التحقق من وجود بيانات قبل تعيين مصدر البيانات
                    if (reportData != null && reportData.Rows.Count > 0)
                    {
                        dataGridView.DataSource = reportData;
                    }
                    else
                    {
                        MessageBox.Show("لم يتم العثور على بيانات!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ: {ex.Message}");
                }
            }
        }

        private void CalculateTotals(decimal employeeAmount, TextBox txtTotalDiscounts, TextBox txtNetAmount)
        {
            try
            {
                // حساب إجمالي الخصومات
                decimal totalDiscounts = 0;
                foreach (DataRow row in reportData.Rows)
                {
                    totalDiscounts += Convert.ToDecimal(row["مبلغ الخصم"]);
                }

                // عرض النتائج
                txtTotalDiscounts.Text = totalDiscounts.ToString("N2");
                txtNetAmount.Text = (employeeAmount - totalDiscounts).ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }
    }
}