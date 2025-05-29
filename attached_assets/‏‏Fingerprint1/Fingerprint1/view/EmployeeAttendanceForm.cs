using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class EmployeeAttendanceForm : Form
    {
        //private SqlConnection conn;
        private DataGridView dgvReport;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbEmployees;
        private Button btnGenerate;
        private Button btnExportExcel;
        private Button btnWebPrint;

        public EmployeeAttendanceForm()
        {
            InitializeComponent();
            //conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
            LoadEmployees();
        }

        private void InitializeControls()
        {
            this.Text = "تقرير الحضور والانصراف للموظف";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1200, 600);

            // قائمة الموظفين
            cmbEmployees = new ComboBox
            {
                Location = new Point(20, 20),
                Size = new Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // التواريخ
            Label lblStartDate = new Label
            {
                Text = "من تاريخ:",
                Location = new Point(240, 23),
                AutoSize = true
            };

            dtpStartDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(300, 20),
                Size = new Size(120, 20)
            };

            Label lblEndDate = new Label
            {
                Text = "إلى تاريخ:",
                Location = new Point(440, 23),
                AutoSize = true
            };

            dtpEndDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(500, 20),
                Size = new Size(120, 20)
            };

            btnGenerate = new Button
            {
                Text = "عرض التقرير",
                Location = new Point(640, 20),
                Size = new Size(100, 30)
            };
            btnGenerate.Click += BtnGenerate_Click;

            btnExportExcel = new Button
            {
                Text = "تصدير Excel",
                Location = new Point(760, 20),
                Size = new Size(100, 30)
            };
           // btnExportExcel.Click += BtnExportExcel_Click;

            //btnExportPDF = new Button
            //{
            //    Text = "تصدير PDF",
            //    Location = new Point(880, 20),
            //    Size = new Size(100, 30)
            //};
            //  btnExportPDF.Click += BtnExportPDF_Click;
            btnWebPrint = new Button
            {
                Text = "طباعة عبر الويب",
                Location = new Point(880, 20),
                Size = new Size(100, 30)
            };
            btnWebPrint.Click += (s, e) => PrintEmployeeAttendanceWeb();
            dgvReport = new DataGridView
            {
                Dock = DockStyle.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RightToLeft = RightToLeft.Yes,
                Size = new Size(1160, 500),
                Location = new Point(20, 70),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            this.Controls.AddRange(new Control[] {
            cmbEmployees, lblStartDate, dtpStartDate,
            lblEndDate, dtpEndDate, btnGenerate,
            btnExportExcel, btnWebPrint, dgvReport
        });
            cmbEmployees.Items.Add(new { UserID = (int?)null, Name = "جميع الموظفين" });
        }

        private void LoadEmployees()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // إنشاء DataTable مع UserID كـ Object لدعم DBNull.Value
                    DataTable dt = new DataTable();
                    dt.Columns.Add("UserID", typeof(object)); // UserID كـ Object
                    dt.Columns.Add("Name", typeof(string));

                    // إضافة خيار "جميع الموظفين" كأول عنصر
                    DataRow allRow = dt.NewRow();
                    allRow["UserID"] = DBNull.Value; // قيمة NULL
                    allRow["Name"] = "جميع الموظفين";
                    dt.Rows.Add(allRow);

                    // تحميل الموظفين من قاعدة البيانات
                    using (SqlCommand cmd = new SqlCommand("SELECT UserID, Name FROM Employees WHERE Enabled = 1 ORDER BY Name", connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt); // يُضيف الموظفين إلى DataTable بعد السطر الأول
                    }

                    // ربط البيانات بالـ ComboBox
                    cmbEmployees.DisplayMember = "Name";
                    cmbEmployees.ValueMember = "UserID";
                    cmbEmployees.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل بيانات الموظفين: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void PrintEmployeeAttendanceWeb()
        {
            try
            {
                // تجميع البيانات حسب الموظف
                var groupedData = dgvReport.Rows.Cast<DataGridViewRow>()
                    .GroupBy(row => row.Cells["الاسم"].Value?.ToString())
                    .ToList();

                // بدء كتابة HTML
                string html = @"
<!DOCTYPE html>
<html dir='rtl'>
<head>
    <meta charset='utf-8'>
    <style>
        body { font-family: Arial; margin: 20px; }
        .report { border: 2px solid #000; padding: 20px; margin-bottom: 20px; page-break-after: always; }
        .header { text-align: center; margin-bottom: 20px; }
        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        th { background-color: #000080; color: white; padding: 8px; }
        td { padding: 6px; border: 1px solid #ddd; text-align: center; }
        tr:nth-child(even) { background-color: #f9f9f9; }
        .summary { margin-top: 20px; padding: 10px; background-color: #f0f0f0; }
        @media print { 
            .no-print { display: none; } 
            .report { page-break-after: always; }
        }
    </style>
</head>
<body>";

                // إضافة فترة التقرير
                html += @"
<div class='header'>
    <h2>تقرير الحضور والانصراف</h2>
    <p>الفترة من: " + dtpStartDate.Value.ToString("yyyy/MM/dd") + @" إلى: " + dtpEndDate.Value.ToString("yyyy/MM/dd") + @"</p>
</div>";

                // إنشاء قسم لكل موظف
                foreach (var group in groupedData)
                {
                    string employeeName = group.Key;

                    // إضافة عنوان القسم للموظف
                    html += @"
<div class='report'>
    <div class='header'>
        <h3>اسم الموظف: " + employeeName + @"</h3>
    </div>

    <table>
        <tr>
            <th>التاريخ</th>
            <th>يوم الأسبوع</th>
            <th>الوردية</th>
            <th>ميعاد الحضور</th>
            <th>الحضور الفعلي</th>
            <th>ميعاد الانصراف</th>
            <th>الانصراف الفعلي</th>
            <th>الحالة</th>
        </tr>";

                    // إضافة الأيام الخاصة بالموظف
                    foreach (var row in group)
                    {
                        html += @"<tr>
                    <td>" + Convert.ToDateTime(row.Cells["التاريخ"].Value).ToString("yyyy/MM/dd") + @"</td>
                    <td>" + row.Cells["يوم الأسبوع"].Value + @"</td>
                    <td>" + row.Cells["الوردية"].Value + @"</td>
                    <td>" + row.Cells["ميعاد الحضور المخطط"].Value + @"</td>
                    <td>" + row.Cells["الحضور الفعلي"].Value + @"</td>
                    <td>" + row.Cells["ميعاد الانصراف المخطط"].Value + @"</td>
                    <td>" + row.Cells["الانصراف الفعلي"].Value + @"</td>
                    <td>" + row.Cells["الحالة"].Value + @"</td>
                </tr>";
                    }

                    html += @"</table>";

                    // حساب ملخص الحضور للموظف الحالي
                    var summary = CalculateAttendanceSummaryForEmployee(group);

                    // إضافة ملخص الحضور الخاص بالموظف
                    html += @"
<div class='summary'>
    <h3>ملخص الحضور:</h3>
    <div style='display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px;'>";

                    foreach (var item in summary)
                    {
                        html += @"<div>" + item.Key + ": " + item.Value + @"</div>";
                    }

                    html += @"</div>
</div>
</div>";
                }

                // زر الطباعة
                html += @"
<button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
</body>
</html>";

                // حفظ التقرير في ملف مؤقت
                string tempFile = Path.Combine(Path.GetTempPath(), "employee_attendance_report.html");
                File.WriteAllText(tempFile, html, Encoding.UTF8);

                // فتح الملف في المتصفح
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c start {tempFile}",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }

        // دالة لحساب ملخص الحضور لكل موظف
        private Dictionary<string, int> CalculateAttendanceSummaryForEmployee(IEnumerable<DataGridViewRow> rows)
        {
            var summary = new Dictionary<string, int>()
    {
        {"حاضر", 0},
        {"غائب", 0},
        {"حضور متاخر", 0},
        {"انصراف مبكر", 0},
        {"حضور متاخر وانصراف مبكر", 0},
        {"حضور متاخر بدون انصراف", 0},
        {"حضور بدون انصراف", 0},
        {"لم يسجل حضور", 0},
        {"إجازة", 0},
        {"عطلة رسمية", 0},
        {"عطلة أسبوعية", 0},
        {"أذن عمل", 0}
    };

            foreach (var row in rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString() ?? "";
                if (status.Contains("إجازة"))
                    summary["إجازة"]++;
                else if (summary.ContainsKey(status))
                    summary[status]++;
            }

            return summary;
        }
        //        private void PrintEmployeeAttendanceWeb()
        //        {
        //            try
        //            {
        //                // بدء كتابة HTML
        //                string html = @"
        //<!DOCTYPE html>
        //<html dir='rtl'>
        //<head>
        //    <meta charset='utf-8'>
        //    <style>
        //        body { font-family: Arial; margin: 20px; }
        //        .report { border: 2px solid #000; padding: 20px; margin-bottom: 20px; }
        //        .header { text-align: center; margin-bottom: 20px; }
        //        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        //        th { background-color: #000080; color: white; padding: 8px; }
        //        td { padding: 6px; border: 1px solid #ddd; text-align: center; }
        //        tr:nth-child(even) { background-color: #f9f9f9; }
        //        .summary { margin-top: 20px; padding: 10px; background-color: #f0f0f0; }
        //        @media print { .no-print { display: none; } }
        //    </style>
        //</head>
        //<body>";

        //                // تجميع البيانات حسب الموظف
        //                var groupedData = dgvReport.Rows.Cast<DataGridViewRow>()
        //                    .GroupBy(row => row.Cells["الاسم"].Value?.ToString())
        //                    .ToList();

        //                // إضافة فترة التقرير
        //                html += @"
        //<div class='header'>
        //    <h2>تقرير الحضور والانصراف</h2>
        //    <p>الفترة من: " + dtpStartDate.Value.ToString("yyyy/MM/dd") + @" إلى: " + dtpEndDate.Value.ToString("yyyy/MM/dd") + @"</p>
        //</div>";

        //                // إنشاء قسم لكل موظف
        //                foreach (var group in groupedData)
        //                {
        //                    string employeeName = group.Key;

        //                    // إضافة عنوان القسم للموظف
        //                    html += @"
        //<div class='report'>
        //    <div class='header'>
        //        <h3>اسم الموظف: " + employeeName + @"</h3>
        //    </div>

        //    <table>
        //        <tr>
        //            <th>التاريخ</th>
        //            <th>يوم الأسبوع</th>
        //            <th>الوردية</th>
        //            <th>ميعاد الحضور</th>
        //            <th>الحضور الفعلي</th>
        //            <th>ميعاد الانصراف</th>
        //            <th>الانصراف الفعلي</th>
        //            <th>الحالة</th>
        //        </tr>";

        //                    // إضافة الأيام الخاصة بالموظف
        //                    foreach (var row in group)
        //                    {
        //                        html += @"<tr>
        //                    <td>" + Convert.ToDateTime(row.Cells["التاريخ"].Value).ToString("yyyy/MM/dd") + @"</td>
        //                    <td>" + row.Cells["يوم الأسبوع"].Value + @"</td>
        //                    <td>" + row.Cells["الوردية"].Value + @"</td>
        //                    <td>" + row.Cells["ميعاد الحضور المخطط"].Value + @"</td>
        //                    <td>" + row.Cells["الحضور الفعلي"].Value + @"</td>
        //                    <td>" + row.Cells["ميعاد الانصراف المخطط"].Value + @"</td>
        //                    <td>" + row.Cells["الانصراف الفعلي"].Value + @"</td>
        //                    <td>" + row.Cells["الحالة"].Value + @"</td>
        //                </tr>";
        //                    }

        //                    html += @"</table>
        //</div>";
        //                }

        //                // إضافة ملخص الحضور العام
        //                html += @"
        //<div class='summary'>
        //    <h3>ملخص الحضور:</h3>
        //    <div style='display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px;'>";

        //                var summary = CalculateAttendanceSummary();
        //                foreach (var item in summary)
        //                {
        //                    html += @"<div>" + item.Key + ": " + item.Value + @"</div>";
        //                }

        //                html += @"</div>
        //</div>
        //<button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
        //</body>
        //</html>";

        //                // حفظ التقرير في ملف مؤقت
        //                string tempFile = Path.Combine(Path.GetTempPath(), "employee_attendance_report.html");
        //                File.WriteAllText(tempFile, html, Encoding.UTF8);

        //                // فتح الملف في المتصفح
        //                var psi = new ProcessStartInfo
        //                {
        //                    FileName = "cmd.exe",
        //                    Arguments = $"/c start {tempFile}",
        //                    UseShellExecute = true,
        //                    CreateNoWindow = true
        //                };
        //                Process.Start(psi);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"حدث خطأ: {ex.Message}");
        //            }
        //        }
        //        2
        //        //        private void PrintEmployeeAttendanceWeb()
        //        //        {
        //        //            try
        //        //            {
        //        //                string html = @"
        //        //<!DOCTYPE html>
        //        //<html dir='rtl'>
        //        //<head>
        //        //    <meta charset='utf-8'>
        //        //    <style>
        //        //        body { font-family: Arial; margin: 20px; }
        //        //        .report { border: 2px solid #000; padding: 20px; }
        //        //        .header { text-align: center; margin-bottom: 20px; }
        //        //        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        //        //        th { background-color: #000080; color: white; padding: 8px; }
        //        //        td { padding: 6px; border: 1px solid #ddd; text-align: center; }
        //        //        tr:nth-child(even) { background-color: #f9f9f9; }
        //        //        .summary { margin-top: 20px; padding: 10px; background-color: #f0f0f0; }
        //        //        @media print { .no-print { display: none; } }
        //        //    </style>

        //        //</head>
        //        //<body>
        //        //    <div class='report'>
        //        //        <div class='header'>
        //        //            <h2>تقرير الحضور والانصراف للموظف</h2>
        //        //            <p>الفترة من: " + dtpStartDate.Value.ToString("yyyy/MM/dd") + @" إلى: " + dtpEndDate.Value.ToString("yyyy/MM/dd") + @"</p>
        //        //            <p>اسم الموظف: " + dgvReport.Rows[0].Cells["الاسم"].Value?.ToString() + @"</p>
        //        //        </div>

        //        //        <table>
        //        //            <tr>
        //        //                <th>التاريخ</th>
        //        //                <th>يوم الأسبوع</th>
        //        //                <th>الوردية</th>
        //        //                <th>ميعاد الحضور</th>
        //        //                <th>الحضور الفعلي</th>
        //        //                <th>ميعاد الانصراف</th>
        //        //                <th>الانصراف الفعلي</th>
        //        //                <th>الحالة</th>
        //        //            </tr>";

        //        //                foreach (DataGridViewRow row in dgvReport.Rows)
        //        //                {
        //        //                    html += @"<tr>
        //        //                <td>" + Convert.ToDateTime(row.Cells["التاريخ"].Value).ToString("yyyy/MM/dd") + @"</td>
        //        //                <td>" + row.Cells["يوم الأسبوع"].Value + @"</td>
        //        //                <td>" + row.Cells["الوردية"].Value + @"</td>
        //        //                <td>" + row.Cells["ميعاد الحضور المخطط"].Value + @"</td>
        //        //                <td>" + row.Cells["الحضور الفعلي"].Value + @"</td>
        //        //                <td>" + row.Cells["ميعاد الانصراف المخطط"].Value + @"</td>
        //        //                <td>" + row.Cells["الانصراف الفعلي"].Value + @"</td>
        //        //                <td>" + row.Cells["الحالة"].Value + @"</td>
        //        //            </tr>";
        //        //                }

        //        //                html += @"</table>

        //        //        <div class='summary'>
        //        //            <h3>ملخص الحضور:</h3>
        //        //            <div style='display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px;'>";

        //        //                var summary = CalculateAttendanceSummary();
        //        //                foreach (var item in summary)
        //        //                {
        //        //                    html += @"<div>" + item.Key + ": " + item.Value + @"</div>";
        //        //                }

        //        //                html += @"</div>
        //        //        </div>
        //        //    </div>
        //        // <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
        //        //</body>
        //        //</html>";

        //        //                string tempFile = Path.Combine(Path.GetTempPath(), "employee_attendance_report.html");
        //        //                File.WriteAllText(tempFile, html, Encoding.UTF8);
        //        //                var psi = new ProcessStartInfo
        //        //                {
        //        //                    FileName = "cmd.exe",
        //        //                    Arguments = $"/c start {tempFile}",
        //        //                    UseShellExecute = true,
        //        //                    CreateNoWindow = true
        //        //                };
        //        //                Process.Start(psi);
        //        //            }
        //        //            catch (Exception ex)
        //        //            {
        //        //                MessageBox.Show($"حدث خطأ: {ex.Message}");
        //        //            }
        //        //        }

        //        private Dictionary<string, int> CalculateAttendanceSummary()
        //        {
        //            var summary = new Dictionary<string, int>()
        //    {
        //        {"حاضر", 0},
        //        {"غائب", 0},
        //        {"حضور متاخر", 0},
        //        {"انصراف مبكر", 0},
        //        {"حضور متاخر وانصراف مبكر", 0},
        //        {"حضور متاخر بدون انصراف", 0},
        //        {"حضور بدون انصراف", 0},
        //        {"لم يسجل حضور", 0},
        //        {"إجازة", 0},
        //        {"عطلة رسمية", 0},
        //        {"عطلة أسبوعية", 0},
        //        {"أذن عمل", 0}
        //    };

        //            foreach (DataGridViewRow row in dgvReport.Rows)
        //            {
        //                string status = row.Cells["الحالة"].Value?.ToString() ?? "";
        //                if (status.Contains("إجازة"))
        //                    summary["إجازة"]++;
        //                else if (summary.ContainsKey(status))
        //                    summary[status]++;
        //            }

        //            return summary;
        //        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // تمرير القيمة الصحيحة لـ @UserID (NULL إذا تم اختيار "جميع الموظفين")
                    object selectedUserID = cmbEmployees.SelectedValue;
                    if (selectedUserID == DBNull.Value) // إذا كان الخيار "جميع الموظفين"
                    {
                        selectedUserID = DBNull.Value; // تمرير NULL إلى الاستعلام
                    }

                    // إنشاء الأمر SQL مع تمرير المعلمات
                    using (SqlCommand cmd = new SqlCommand(GetEmployeeAttendanceQuery(), connection))
                    {
                        // إضافة المعلمات مع التعامل الصحيح مع DBNull.Value
                        cmd.Parameters.Add(new SqlParameter("@UserID", selectedUserID));
                        cmd.Parameters.Add(new SqlParameter("@StartDate", dtpStartDate.Value.Date));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", dtpEndDate.Value.Date));

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvReport.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }

        // ... Export methods remain the same as previous example ...
        private string GetEmployeeAttendanceQuery()
        {
            return @"
WITH DateRange AS (
    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
    FROM sys.objects
),
AttendanceCTE AS (
    SELECT
        e.UserID,
        e.Name,
        sh.ShiftID,
        sh.ShiftName,
        d.Date AS AttendanceDate,
        sh.StartTime AS ScheduledCheckIn,
        sh.EndTime AS ScheduledCheckOut,
        -- إضافة CheckInStart كبداية فترة تسجيل الحضور
        CAST(d.Date AS DATETIME) + CAST(sh.CheckInStart AS DATETIME) AS CheckInStartTime,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
    INNER JOIN DateRange d ON d.Date BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID -- ربط بالجدول الجديد
        AND swd.DayOfWeek = (
            CASE DATENAME(WEEKDAY, d.Date)
                WHEN 'Sunday' THEN N'الأحد'
                WHEN 'Monday' THEN N'الاثنين'
                WHEN 'Tuesday' THEN N'الثلاثاء'
                WHEN 'Wednesday' THEN N'الأربعاء'
                WHEN 'Thursday' THEN N'الخميس'
                WHEN 'Friday' THEN N'الجمعة'
                WHEN 'Saturday' THEN N'السبت'
            END
        )
    LEFT JOIN Attendance a ON e.UserID = a.UserID
        AND CAST(a.DateTime AS DATE) = d.Date
    WHERE (@UserID IS NULL OR e.UserID = @UserID)
    GROUP BY
        e.UserID, e.Name, sh.ShiftID, sh.ShiftName, d.Date,
        sh.StartTime, sh.EndTime, sh.CheckInStart
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
    WHERE (@UserID IS NULL OR e.UserID = @UserID)
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
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 108), '--') AS 'الحضور الفعلي',
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 108), '--') AS 'الانصراف الفعلي',
    CASE
        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN N'إجازة'
        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        -- إضافة شرط حضور مبكر غير مسموح
        WHEN a.ActualCheckIn < a.CheckInStartTime THEN N'غائب'
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        WHEN (CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) AND
              CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut) THEN N'حاضر'
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND
             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND
            a.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) AND
             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'حضور متاخر'
        WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'لم يسجل حضور'
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND
             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) AND
             CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND
             CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'انصراف مبكر'
        ELSE N'غائب'
    END AS 'الحالة',
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
LEFT JOIN Shifts s ON a.ShiftID = s.ShiftID
ORDER BY
    CASE WHEN @UserID IS NULL THEN a.UserID ELSE 1 END,
    a.AttendanceDate,
    CASE
        WHEN a.ShiftName = 'فترة صباحيه' THEN 1
        WHEN a.ShiftName = 'فترة مسائية' THEN 2
        ELSE 3
    END,
    a.Name;";
        }
        //        private string GetEmployeeAttendanceQuery()
        //        {
        //            return @"
        //WITH DateRange AS (
        //    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        //        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
        //    FROM sys.objects
        //),
        //RawAttendance AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        d.Date AS AttendanceDate,
        //        sh.ShiftID,
        //        sh.ShiftName,
        //        sh.StartTime AS ScheduledCheckIn,
        //        sh.EndTime AS ScheduledCheckOut,
        //        sh.CheckInGracePeriod,
        //        a.DateTime,
        //        a.InOutMode
        //    FROM Employees e
        //    CROSS JOIN DateRange d
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
        //        AND d.Date BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID
        //        AND swd.DayOfWeek = (
        //            CASE DATENAME(WEEKDAY, d.Date)
        //                WHEN 'Sunday' THEN N'الأحد'
        //                WHEN 'Monday' THEN N'الاثنين'
        //                WHEN 'Tuesday' THEN N'الثلاثاء'
        //                WHEN 'Wednesday' THEN N'الأربعاء'
        //                WHEN 'Thursday' THEN N'الخميس'
        //                WHEN 'Friday' THEN N'الجمعة'
        //                WHEN 'Saturday' THEN N'السبت'
        //            END
        //        )
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID
        //        AND CAST(a.DateTime AS DATE) = d.Date
        //    WHERE (@UserID IS NULL OR e.UserID = @UserID) -- شرط اختياري
        //),
        //AggregatedAttendance AS (
        //    SELECT 
        //        ra.UserID,
        //        ra.Name,
        //        ra.AttendanceDate,
        //        ra.ShiftName,
        //        ra.ScheduledCheckIn,
        //        ra.ScheduledCheckOut,
        //        ra.CheckInGracePeriod,
        //        MIN(CASE WHEN ra.InOutMode = 0 THEN ra.DateTime END) AS ActualCheckIn,
        //        MAX(CASE WHEN ra.InOutMode = 1 THEN ra.DateTime END) AS ActualCheckOut
        //    FROM RawAttendance ra
        //    GROUP BY 
        //        ra.UserID,
        //        ra.Name,
        //        ra.AttendanceDate,
        //        ra.ShiftName,
        //        ra.ScheduledCheckIn,
        //        ra.ScheduledCheckOut,
        //        ra.CheckInGracePeriod
        //),
        //LeavePermissionCTE AS (
        //    SELECT 
        //        e.UserID,
        //        l.LeaveDate,
        //        l.LeaveType,
        //        p.PermissionDate,
        //        p.Status AS PermissionStatus,
        //        ROW_NUMBER() OVER (PARTITION BY e.UserID, l.LeaveDate ORDER BY p.PermissionDate DESC) AS RowNum
        //    FROM Employees e
        //    CROSS JOIN DateRange d
        //    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = d.Date
        //    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = d.Date
        //    WHERE (@UserID IS NULL OR e.UserID = @UserID) -- شرط اختياري
        //    GROUP BY e.UserID, d.Date, l.LeaveDate, l.LeaveType, p.PermissionDate, p.Status
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
        //        WHEN swd.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        //        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
        //        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
        //        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) AND 
        //             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN 'حاضر'
        //        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND 
        //             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر بدون انصراف'
        //        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn)) AND
        //            a.ActualCheckOut IS NULL THEN 'حضور بدون انصراف'
        //        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) AND 
        //             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN 'حضور متاخر'
        //        WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN 'لم يسجل حضور'
        //        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND 
        //             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) AND 
        //             CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'حضور متاخر وانصراف مبكر'
        //        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND 
        //             CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'انصراف مبكر'
        //        ELSE 'غائب'
        //    END AS 'الحالة',

        //    l.LeaveType AS 'نوع الإجازة',
        //    l.PermissionStatus AS 'حالة الإذن'

        //FROM AggregatedAttendance a
        //LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
        //LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
        //LEFT JOIN ShiftWorkingDays swd ON swd.ShiftID = (
        //    SELECT ShiftID FROM Shifts WHERE ShiftName = a.ShiftName
        //) AND swd.DayOfWeek = (
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
        //ORDER BY 
        //    a.UserID, -- ترتيب حسب معرف الموظف أولاً
        //    a.AttendanceDate ASC, 
        //    a.ShiftName;

        //";
        //        }
    }
}
