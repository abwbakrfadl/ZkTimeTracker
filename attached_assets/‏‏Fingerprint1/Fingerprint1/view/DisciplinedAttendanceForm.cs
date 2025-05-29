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
    public partial class DisciplinedAttendanceForm : Form
    {
       // private SqlConnection conn;
        private DataGridView dgvReport;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerate;
        private Button btnGenerate1;
        private Button btnExportExcel;
        private Button btnExportPDF;
        string a = null;

        public DisciplinedAttendanceForm()
        {
            InitializeComponent();
          //  conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "تقرير المنضبطين في الحضور";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1000, 600);

            Label lblStartDate = new Label
            {
                Text = "من تاريخ:",
                Location = new Point(20, 23),
                AutoSize = true
            };

            dtpStartDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(80, 20),
                Size = new Size(120, 20)
            };

            Label lblEndDate = new Label
            {
                Text = "إلى تاريخ:",
                Location = new Point(220, 23),
                AutoSize = true
            };

            dtpEndDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(280, 20),
                Size = new Size(120, 20)
            };

            btnGenerate = new Button
            {
                Text = " التقرير حضور نصراف",
                Location = new Point(420, 20),
                Size = new Size(100, 30)
            };
            btnGenerate.Click += BtnGenerate_Click;

            btnGenerate1 = new Button
            {
                Text = " تقرير الحضور فقط",
                Location = new Point(540, 20),
                Size = new Size(100, 30)
            };
            btnGenerate1.Click += BtnGenerate1_Click;

            btnExportExcel = new Button
            {
                Text = "طباعة التقرير",
                Location = new Point(660, 20),
                Size = new Size(100, 30)
            };
            btnExportExcel.Click += (s, e) => PrintDisciplinedReport();

            //btnExportPDF = new Button
            //{
            //    Text = "تصدير PDF",
            //    Location = new Point(720, 20),
            //    Size = new Size(100, 30)
            //};
            //btnExportPDF.Click += BtnExportPDF_Click;

            dgvReport = new DataGridView
            {
                Dock = DockStyle.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RightToLeft = RightToLeft.Yes,
                Size = new Size(960, 500),
                Location = new Point(20, 70),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            this.Controls.AddRange(new Control[] {
            lblStartDate,
                dtpStartDate,
            lblEndDate, dtpEndDate,
            btnGenerate, btnExportExcel,
            btnExportPDF, dgvReport,btnGenerate1
        });
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
             a = "a";
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(GetDisciplinedEmployeesQuery(), connection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvReport.DataSource = dt;

                        // تنسيق عمود النسبة المئوية
                        if (dgvReport.Columns["نسبة الانضباط"] != null)
                        {
                            dgvReport.Columns["نسبة الانضباط"].DefaultCellStyle.Format = "N2";
                        }

                        // Debug information
                        MessageBox.Show($"تم تحميل {dt.Rows.Count} صف");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }
        private void BtnGenerate1_Click(object sender, EventArgs e)
        {
            a = "b";
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(GetDisciplinedEmployeesQuery1(), connection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvReport.DataSource = dt;

                        // تنسيق عمود النسبة المئوية
                        if (dgvReport.Columns["نسبة الانضباط"] != null)
                        {
                            dgvReport.Columns["نسبة الانضباط"].DefaultCellStyle.Format = "N2";
                        }

                        // Debug information
                        MessageBox.Show($"تم تحميل {dt.Rows.Count} صف");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //{
            //    sfd.Filter = "Excel Files|*.xlsx";
            //    sfd.FileName = "تقرير_المنضبطين_" + DateTime.Now.ToString("yyyy-MM-dd");

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var package = new ExcelPackage())
            //        {
            //            var worksheet = package.Workbook.Worksheets.Add("تقرير المنضبطين");

            //            // إضافة العناوين
            //            for (int i = 0; i < dgvReport.Columns.Count; i++)
            //            {
            //                worksheet.Cells[1, i + 1].Value = dgvReport.Columns[i].HeaderText;
            //            }

            //            // إضافة البيانات
            //            for (int i = 0; i < dgvReport.Rows.Count; i++)
            //            {
            //                for (int j = 0; j < dgvReport.Columns.Count; j++)
            //                {
            //                    worksheet.Cells[i + 2, j + 1].Value = dgvReport.Rows[i].Cells[j].Value?.ToString();
            //                }
            //            }

            //            File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
            //        }
            //        MessageBox.Show("تم تصدير الملف بنجاح");
            //    }
            //}
        }

        private void BtnExportPDF_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //{
            //    sfd.Filter = "PDF Files|*.pdf";
            //    sfd.FileName = "تقرير_المنضبطين_" + DateTime.Now.ToString("yyyy-MM-dd");

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        Document doc = new Document(PageOrientation.Landscape);
            //        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
            //        doc.Open();

            //        BaseFont bf = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //        Font font = new Font(bf, 12);

            //        PdfPTable table = new PdfPTable(dgvReport.Columns.Count);

            //        foreach (DataGridViewColumn column in dgvReport.Columns)
            //        {
            //            table.AddCell(new Phrase(column.HeaderText, font));
            //        }

            //        foreach (DataGridViewRow row in dgvReport.Rows)
            //        {
            //            foreach (DataGridViewCell cell in row.Cells)
            //            {
            //                table.AddCell(new Phrase(cell.Value?.ToString() ?? "", font));
            //            }
            //        }

            //        doc.Add(table);
            //        doc.Close();
            //        MessageBox.Show("تم تصدير الملف بنجاح");
            //    }
            //}
        }
        private string GetDisciplinedEmployeesQuery()
        {
            return @"
    WITH DailyAttendance AS (
        SELECT 
            e.UserID,
            e.Name,
            sh.ShiftName,
            CAST(a.DateTime AS DATE) AS AttendanceDate,
            MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS DailyCheckIn,
            MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS DailyCheckOut,
            sh.StartTime,
            sh.EndTime,
            s.CheckInGracePeriod
        FROM Employees e
        INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        LEFT JOIN Attendance a ON e.UserID = a.UserID 
            AND CAST(a.DateTime AS DATE) BETWEEN @StartDate AND @EndDate
        LEFT JOIN Shifts s ON sh.ShiftID = s.ShiftID
        WHERE e.Enabled = 1
        GROUP BY e.UserID, e.Name, sh.ShiftName, CAST(a.DateTime AS DATE), 
                 sh.StartTime, sh.EndTime, s.CheckInGracePeriod
    )
    SELECT 
        UserID AS 'المعرف',
        Name AS 'الاسم',
        ShiftName AS 'الوردية',
        COUNT(DISTINCT AttendanceDate) AS 'عدد أيام الحضور',
        SUM(CASE 
            WHEN CAST(DailyCheckIn AS TIME) <= DATEADD(MINUTE, CheckInGracePeriod, StartTime)
            AND CAST(DailyCheckOut AS TIME) >= EndTime 
            THEN 1 ELSE 0 
        END) AS 'أيام الانضباط',
        CAST(
            CASE 
                WHEN COUNT(DISTINCT AttendanceDate) > 0 
                THEN SUM(CASE 
                    WHEN CAST(DailyCheckIn AS TIME) <= DATEADD(MINUTE, CheckInGracePeriod, StartTime)
                    AND CAST(DailyCheckOut AS TIME) >= EndTime 
                    THEN 1 ELSE 0 
                END) * 100.0 / COUNT(DISTINCT AttendanceDate)
                ELSE 0 
            END AS DECIMAL(5,2)
        ) AS 'نسبة الانضباط'
    FROM DailyAttendance
    WHERE AttendanceDate IS NOT NULL
    GROUP BY UserID, Name, ShiftName
    ORDER BY 'نسبة الانضباط' DESC;";
        }
        private string GetDisciplinedEmployeesQuery1()
        {
            return @"
WITH DateRange AS (
    -- توليد مجموعة من الأيام بين تاريخ البداية والنهاية
    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
    FROM sys.objects
),
WorkingDaysCTE AS (
    -- تحديد أيام العمل المطلوبة لكل موظف
    SELECT
        e.UserID,
        e.Name,
        sh.ShiftName,
        d.Date AS AttendanceDate,
        sh.StartTime,
        sh.EndTime,
        sh.CheckInStart
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    INNER JOIN DateRange d ON d.Date BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID
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
    WHERE e.Enabled = 1
),
FilteredDays AS (
    -- استبعاد العطل الرسمية
    SELECT 
        wd.UserID,
        wd.Name,
        wd.ShiftName,
        wd.AttendanceDate,
        wd.StartTime,
        wd.EndTime,
        wd.CheckInStart
    FROM WorkingDaysCTE wd
    LEFT JOIN Holidays h ON wd.AttendanceDate = h.HolidayDate
    WHERE h.HolidayDate IS NULL -- ليس عطلة رسمية
),
DailyAttendance AS (
    -- جمع بيانات الحضور والانصراف لكل موظف
    SELECT 
        fd.UserID,
        fd.Name,
        fd.ShiftName,
        fd.AttendanceDate,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS DailyCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS DailyCheckOut,
        fd.StartTime,
        fd.EndTime,
        fd.CheckInStart
    FROM FilteredDays fd
    LEFT JOIN Attendance a ON fd.UserID = a.UserID 
        AND CAST(a.DateTime AS DATE) = fd.AttendanceDate
    GROUP BY fd.UserID, fd.Name, fd.ShiftName, fd.AttendanceDate, 
             fd.StartTime, fd.EndTime, fd.CheckInStart
),
FilteredAttendance AS (
    SELECT 
        UserID,
        Name,
        ShiftName,
        COUNT(DISTINCT AttendanceDate) AS RequiredWorkingDays, -- عدد أيام الدوام المطلوبة
        SUM(CASE 
            WHEN DailyCheckIn IS NOT NULL AND DailyCheckOut IS NOT NULL THEN 1 
            ELSE 0 
        END) AS ActualWorkingDays, -- عدد أيام الحضور الفعلي
        SUM(CASE 
            WHEN CAST(DailyCheckIn AS TIME) >= CAST(CheckInStart AS TIME)
                 AND CAST(DailyCheckIn AS TIME) <= CAST(StartTime AS TIME)
                 AND CAST(DailyCheckOut AS TIME) >= CAST(EndTime AS TIME) THEN 1 
            ELSE 0 
        END) AS DisciplinedDays -- عدد أيام الانضباط
    FROM DailyAttendance
    GROUP BY UserID, Name, ShiftName
)
SELECT 
    UserID AS 'المعرف',
    Name AS 'الاسم',
    ShiftName AS 'الوردية',
    RequiredWorkingDays AS 'عدد أيام الدوام المطلوبة',
    ActualWorkingDays AS 'عدد أيام الحضور الفعلي',
    DisciplinedDays AS 'أيام الانضباط',
    CAST(
        CASE 
            WHEN RequiredWorkingDays > 0 
            THEN DisciplinedDays * 100.0 / RequiredWorkingDays
            ELSE 0 
        END AS DECIMAL(5,2)
    ) AS 'نسبة الانضباط (%)'
FROM FilteredAttendance
ORDER BY 'نسبة الانضباط (%)' DESC;";
        }
        //    private string GetDisciplinedEmployeesQuery1()
        //    {
        //        return @"
        //WITH DailyAttendance AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        sh.ShiftName,
        //        CAST(a.DateTime AS DATE) AS AttendanceDate,
        //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS DailyCheckIn,
        //        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS DailyCheckOut,
        //        sh.StartTime,
        //        sh.EndTime,
        //        s.CheckInGracePeriod
        //    FROM Employees e
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        //        AND CAST(a.DateTime AS DATE) BETWEEN @StartDate AND @EndDate
        //    LEFT JOIN Shifts s ON sh.ShiftID = s.ShiftID
        //    WHERE e.Enabled = 1
        //    GROUP BY e.UserID, e.Name, sh.ShiftName, CAST(a.DateTime AS DATE), 
        //             sh.StartTime, sh.EndTime, s.CheckInGracePeriod
        //)
        //SELECT 
        //    UserID AS 'المعرف',
        //    Name AS 'الاسم',
        //    ShiftName AS 'الوردية',
        //    COUNT(DISTINCT AttendanceDate) AS 'عدد أيام الحضور',
        //    SUM(CASE 
        //        WHEN CAST(DailyCheckIn AS TIME) <= DATEADD(MINUTE, CheckInGracePeriod, StartTime)

        //        THEN 1 ELSE 0 
        //    END) AS 'أيام الانضباط',
        //    CAST(
        //        CASE 
        //            WHEN COUNT(DISTINCT AttendanceDate) > 0 
        //            THEN SUM(CASE 
        //                WHEN CAST(DailyCheckIn AS TIME) <= DATEADD(MINUTE, CheckInGracePeriod, StartTime)

        //                THEN 1 ELSE 0 
        //            END) * 100.0 / COUNT(DISTINCT AttendanceDate)
        //            ELSE 0 
        //        END AS DECIMAL(5,2)
        //    ) AS 'نسبة الانضباط'
        //FROM DailyAttendance
        //WHERE AttendanceDate IS NOT NULL
        //GROUP BY UserID, Name, ShiftName
        //ORDER BY 'نسبة الانضباط' DESC;";
        //    }
        private void PrintDisciplinedReport()
        { if (a == "a") 
            {
                try
                {
                    string html = @"
<!DOCTYPE html>
<html dir='rtl'>
<head>
    <meta charset='utf-8'>
    <style>
        body { font-family: Arial; margin: 20px; }
        .report { border: 2px solid #000; padding: 20px; }
        .header { text-align: center; margin-bottom: 20px; }
        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        th { background-color: #000080; color: white; padding: 8px; }
        td { padding: 6px; border: 1px solid #ddd; text-align: center; }
        tr:nth-child(even) { background-color: #f9f9f9; }
        .highlight { background-color: #e6ffe6; }
        @media print { .no-print { display: none; } }
    </style>
    <script>
        window.onload = function () {
            setTimeout(() => {
                window.print();
            }, 1000);
        };
    </script>
</head>
<body>
    <div class='report'>
        <div class='header'>
            <h2>تقرير المنضبطين في حضور و نصراف</h2>
            <p>الفترة من: " + dtpStartDate.Value.ToString("yyyy/MM/dd") + @" إلى: " + dtpEndDate.Value.ToString("yyyy/MM/dd") + @"</p>
        </div>

        <table>
            <tr>
                <th>المعرف</th>
                <th>الاسم</th>
                <th>الوردية</th>
                <th>عدد أيام الحضور</th>
                <th>أيام الانضباط</th>
                <th>نسبة الانضباط</th>
            </tr>";

                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        decimal disciplineRate = decimal.Parse(row.Cells["نسبة الانضباط"].Value.ToString());
                        string rowClass = disciplineRate >= 90 ? "highlight" : "";

                        html += $@"<tr class='{rowClass}'>
                <td>{row.Cells["المعرف"].Value}</td>
                <td>{row.Cells["الاسم"].Value}</td>
                <td>{row.Cells["الوردية"].Value}</td>
                <td>{row.Cells["عدد أيام الحضور"].Value}</td>
                <td>{row.Cells["أيام الانضباط"].Value}</td>
                <td>{row.Cells["نسبة الانضباط"].Value}%</td>
            </tr>";
                    }

                    html += @"</table>
    </div>
    <button class='no-print' onclick='window.print()'>طباعة</button>
</body>
</html>";

                    string tempFile = Path.Combine(Path.GetTempPath(), "disciplined_employees_report.html");
                    File.WriteAllText(tempFile, html, Encoding.UTF8);
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c start {tempFile}",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    string html = @"
<!DOCTYPE html>
<html dir='rtl'>
<head>
    <meta charset='utf-8'>
    <style>
        body { font-family: Arial; margin: 20px; }
        .report { border: 2px solid #000; padding: 20px; }
        .header { text-align: center; margin-bottom: 20px; }
        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        th { background-color: #000080; color: white; padding: 8px; }
        td { padding: 6px; border: 1px solid #ddd; text-align: center; }
        tr:nth-child(even) { background-color: #f9f9f9; }
        .highlight { background-color: #e6ffe6; }
        @media print { .no-print { display: none; } }
    </style>
    <script>
        window.onload = function () {
            setTimeout(() => {
                window.print();
            }, 1000);
        };
    </script>
</head>
<body>
    <div class='report'>
        <div class='header'>
            <h2>تقرير المنضبطين في الحضور</h2>
            <p>الفترة من: " + dtpStartDate.Value.ToString("yyyy/MM/dd") + @" إلى: " + dtpEndDate.Value.ToString("yyyy/MM/dd") + @"</p>
        </div>

        <table>
            <tr>
                <th>المعرف</th>
                <th>الاسم</th>
                <th>الوردية</th>
                <th>عدد أيام الدوام المطلوبة</th>
                 <th>عدد أيام الحضور الفعلي</th>
                <th>أيام الانضباط</th>
                <th>نسبة الانضباط (%)</th>
            </tr>";

                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        decimal disciplineRate = decimal.Parse(row.Cells["نسبة الانضباط (%)"].Value.ToString());
                        string rowClass = disciplineRate >= 90 ? "highlight" : "";

                        html += $@"<tr class='{rowClass}'>
                <td>{row.Cells["المعرف"].Value}</td>
                <td>{row.Cells["الاسم"].Value}</td>
                <td>{row.Cells["الوردية"].Value}</td>
                <td>{row.Cells["عدد أيام الدوام المطلوبة"].Value}</td>
                <td>{row.Cells["عدد أيام الحضور الفعلي"].Value}</td>
                <td>{row.Cells["أيام الانضباط"].Value}</td>
                <td>{row.Cells["نسبة الانضباط (%)"].Value}%</td>
            </tr>";
                    }

                    html += @"</table>
    </div>
    <button class='no-print' onclick='window.print()'>طباعة</button>
</body>
</html>";

                    string tempFile = Path.Combine(Path.GetTempPath(), "disciplined_employees_report.html");
                    File.WriteAllText(tempFile, html, Encoding.UTF8);
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = $"/c start {tempFile}",
                        UseShellExecute = true,
                        CreateNoWindow = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
            }
           
        }
        //        private string GetDisciplinedAttendanceQuery()
        //        {
        //            // ضع هنا الاستعلام السابق
        //            return @"
        //WITH DateRange AS (
        //    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        //        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
        //    FROM sys.objects
        //),
        //WorkingDaysOnly AS (
        //    SELECT d.Date
        //    FROM DateRange d
        //    LEFT JOIN Holidays h ON h.HolidayDate = d.Date
        //    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        //        CASE DATENAME(WEEKDAY, d.Date)
        //            WHEN 'Sunday' THEN N'الأحد'
        //            WHEN 'Monday' THEN N'الاثنين'
        //            WHEN 'Tuesday' THEN N'الثلاثاء'
        //            WHEN 'Wednesday' THEN N'الأربعاء'
        //            WHEN 'Thursday' THEN N'الخميس'
        //            WHEN 'Friday' THEN N'الجمعة'
        //            WHEN 'Saturday' THEN N'السبت'
        //        END
        //    )
        //    WHERE h.HolidayDate IS NULL AND w.DayOfWeek IS NOT NULL
        //),
        //AttendanceCTE AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        sh.ShiftName,
        //        d.Date AS AttendanceDate,
        //        sh.StartTime AS ScheduledCheckIn,
        //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn
        //    FROM Employees e
        //    CROSS JOIN WorkingDaysOnly d
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        //        AND d.Date BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        //        AND CAST(a.DateTime AS DATE) = d.Date
        //    WHERE e.Enabled = 1
        //    GROUP BY e.UserID, e.Name, sh.ShiftName, d.Date, sh.StartTime
        //),
        //DisciplinedEmployees AS (
        //    SELECT 
        //        a.UserID,
        //        a.Name,
        //        COUNT(*) AS TotalWorkDays,
        //        SUM(CASE 
        //            WHEN l.LeaveType IS NOT NULL THEN 0
        //            WHEN a.ActualCheckIn IS NULL THEN 0
        //            WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 1
        //            ELSE 0
        //        END) AS OnTimeDays
        //    FROM AttendanceCTE a
        //    LEFT JOIN Leaves l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
        //    LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
        //    GROUP BY a.UserID, a.Name
        //)

        //SELECT 
        //    UserID AS 'المعرف',
        //    Name AS 'الاسم',
        //    TotalWorkDays AS 'إجمالي أيام العمل',
        //    OnTimeDays AS 'أيام الحضور في الموعد',
        //    CAST((CAST(OnTimeDays AS FLOAT) / NULLIF(TotalWorkDays, 0)) * 100 AS DECIMAL(5,2)) AS 'نسبة الانضباط %'
        //FROM DisciplinedEmployees
        //WHERE OnTimeDays > 0
        //ORDER BY (CAST(OnTimeDays AS FLOAT) / NULLIF(TotalWorkDays, 0)) DESC, Name ASC;
        //"; // الاستعلام الكامل الذي قدمته سابقاً
        //        }
    }
}
