using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class DailyAttendanceForm : Form
    {
      //  private SqlConnection conn;
        private DataGridView dgvReport;
        private DateTimePicker dtpDate;
        private Button btnGenerate;
        private Button btnDisciplinedReport;
        private Button btnCrisxtalReport;

        public DailyAttendanceForm()
        {
            InitializeComponent();
          //  conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "تقرير الحضور اليومي";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1000, 600);

            // التقويم
            dtpDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(20, 20),
                Size = new Size(120, 20)
            };

            // أزرار التحكم
            btnGenerate = new Button
            {
                Text = "عرض التقرير",
                Location = new Point(160, 20),
                Size = new Size(100, 30)
            };
            btnGenerate.Click += BtnGenerate_Click;


            btnDisciplinedReport = new Button
            {
                Text = "طباعة التقرير",
                Location = new Point(280, 20),
                Size = new Size(100, 30)
            };
            btnDisciplinedReport.Click += (s, e) => PrintDailyReportWeb();
            this.Controls.Add(btnDisciplinedReport);

            btnCrisxtalReport = new Button
            {
                Text = "طباعة كرستال",
                Location = new Point(360, 20),
                Size = new Size(100, 30)
            };
            btnCrisxtalReport.Click += (s, e) => btnCrisxtalReport_Click(this, EventArgs.Empty);

            this.Controls.Add(btnCrisxtalReport);
            // جدول عرض البيانات
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
            dtpDate, btnGenerate,btnDisciplinedReport, dgvReport
        });
        }

        private void btnCrisxtalReport_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. امسح البيانات القديمة
                using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM Temp_DailyAttendanceReport", conn))
                {
                    deleteCmd.ExecuteNonQuery();
                }
               

                // 2. خزن البيانات الجديدة من DataGridView
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    if (row.IsNewRow) continue;

                    string query = @"INSERT INTO Temp_DailyAttendanceReport 
                 (UserID, Name, ShiftName, AttendanceDate, DayOfWeek, ScheduledCheckIn, ActualCheckIn, Status, LeaveType, PermissionStatus)
                 VALUES (@UserID, @Name, @ShiftName, @AttendanceDate, @DayOfWeek, @ScheduledCheckIn, @ActualCheckIn, @Status, @LeaveType, @PermissionStatus)";

                    using (SqlCommand insertCmd = new SqlCommand(query, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@UserID", row.Cells["المعرف"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@Name", row.Cells["الاسم"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@ShiftName", row.Cells["الوردية"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@AttendanceDate", row.Cells["التاريخ"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@DayOfWeek", row.Cells["يوم الأسبوع"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@ScheduledCheckIn", row.Cells["ميعاد الحضور المخطط"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@ActualCheckIn", row.Cells["الحضور الفعلي"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@Status", row.Cells["الحالة"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@LeaveType", row.Cells["نوع الإجازة"].Value ?? DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@PermissionStatus", row.Cells["حالة الإذن"].Value ?? DBNull.Value);

                        insertCmd.ExecuteNonQuery();
                    }
                }
                ShowCrystalReport();
            }
        }
        private void ShowCrystalReport()
        {
            ReportDocument rpt = new ReportDocument();
            //  rpt.Load(Path.Combine(Application.StartupPath, "DailyAttendanceReport.rpt"));
            rpt.Load(Path.Combine(Application.StartupPath, "DailyAttendanceReport.rpt"));

            AppSetting setting = new AppSetting();
            string connString = setting.GetConnectionString("cn");
            var builder = new SqlConnectionStringBuilder(connString);

            ConnectionInfo crConnInfo = new ConnectionInfo
            {
                ServerName = builder.DataSource,
                DatabaseName = builder.InitialCatalog,
                IntegratedSecurity = true
            };

            foreach (Table tbl in rpt.Database.Tables)
            {
                TableLogOnInfo logOnInfo = tbl.LogOnInfo;
                logOnInfo.ConnectionInfo = crConnInfo;
                tbl.ApplyLogOnInfo(logOnInfo);
                tbl.Location = $"{builder.InitialCatalog}.dbo.{tbl.Name}";
            }

            foreach (Section sec in rpt.ReportDefinition.Sections)
            {
                foreach (ReportObject obj in sec.ReportObjects)
                {
                    if (obj.Kind != ReportObjectKind.SubreportObject)
                        continue;

                    SubreportObject sub = (SubreportObject)obj;
                    ReportDocument subRpt = sub.OpenSubreport(sub.SubreportName);
                    foreach (Table tbl in subRpt.Database.Tables)
                    {
                        TableLogOnInfo logOnInfo = tbl.LogOnInfo;
                        logOnInfo.ConnectionInfo = crConnInfo;
                        tbl.ApplyLogOnInfo(logOnInfo);
                        tbl.Location = $"{builder.InitialCatalog}.dbo.{tbl.Name}";
                    }
                }
            }

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }



        private void PrintDailyReportWeb()
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
        .summary { margin-top: 20px; padding: 10px; background-color: #f0f0f0; }
        @media print { .no-print { display: none; } }
    </style>

</head>
<body>
    <div class='report'>
        <div class='header'>
            <h2>تقرير الحضور اليومي</h2>
            <p>التاريخ: " + dtpDate.Value.ToString("yyyy/MM/dd") + @"</p>
        </div>

        <table>
            <tr>
                <th>المعرف</th>
                <th>الاسم</th>
                <th>الوردية</th>
                <th>التاريخ</th>
                <th>يوم الأسبوع</th>
                <th>ميعاد الحضور المخطط</th>
                <th>الحضور الفعلي</th>
                <th>الحالة</th>
                <th>نوع الإجازة</th>
                <th>حالة الإذن</th>
            </tr>";

                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    html += @"<tr>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        html += @"<td>" + (cell.Value?.ToString() ?? "--") + @"</td>";
                    }
                    html += @"</tr>";
                }

                html += @"</table>

        <div class='summary'>
            <h3>ملخص الحضور:</h3>
            <div style='display: grid; grid-template-columns: repeat(4, 1fr); gap: 10px;'>";

                var summary = CalculateAttendanceSummary();
                html += @"
                <div>حاضر: " + summary["حاضر"] + @"</div>
                <div>غائب: " + summary["غائب"] + @"</div>
                <div>متأخر: " + summary["متاخر"] + @"</div>
                <div>إجازة: " + summary["إجازة"] + @"</div>
                <div>عطلة رسمية: " + summary["عطلة رسمية"] + @"</div>
               
                <div>أذن عمل: " + summary["أذن عمل"] + @"</div>
            </div>
        </div>
    </div>
    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>

</body>
</html>";

                string tempFile = Path.Combine(Path.GetTempPath(), "daily_attendance_report.html");
                File.WriteAllText(tempFile, html, Encoding.UTF8);
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
        private Dictionary<string, int> CalculateAttendanceSummary()
        {
            var summary = new Dictionary<string, int>()
    {
        {"حاضر", 0},
        {"غائب", 0},
        {"متاخر", 0},
        {"إجازة", 0},
        {"عطلة رسمية", 0},
        {"عطلة أسبوعية", 0},
        {"أذن عمل", 0},
        {"متأخر", 0}  // أضفنا هذا المفتاح
    };

            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString() ?? "";
                if (status.Contains("إجازة"))
                    summary["إجازة"]++;
                else if (status == "متاخر")
                    summary["متاخر"]++;
                else if (summary.ContainsKey(status))
                    summary[status]++;
            }

            return summary;
        }
   
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(GetDailyAttendanceQuery(), connection))
                    {
                        cmd.Parameters.AddWithValue("@ReportDate", dtpDate.Value.Date);
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

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //{
            //    sfd.Filter = "Excel Files|*.xlsx";
            //    sfd.FileName = "تقرير_الحضور_" + dtpDate.Value.ToString("yyyy-MM-dd");

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var package = new ExcelPackage())
            //        {
            //            var worksheet = package.Workbook.Worksheets.Add("تقرير الحضور");

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
            //    sfd.FileName = "تقرير_الحضور_" + dtpDate.Value.ToString("yyyy-MM-dd");

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
        private string GetDailyAttendanceQuery()
        {
            return @" 
DECLARE @UserID INT = NULL;

WITH RawAttendance AS (
    SELECT 
        e.UserID,
        e.Name,
        CAST(@ReportDate AS DATE) AS AttendanceDate,
        sh.ShiftID,
        sh.ShiftName,
        -- إضافة CheckInStart و EndTime
        CAST(@ReportDate AS DATETIME) + CAST(sh.StartTime AS DATETIME) AS ScheduledCheckIn, -- بداية العمل
        CAST(@ReportDate AS DATETIME) + CAST(sh.EndTime AS DATETIME) AS ScheduledCheckOut, -- نهاية العمل
        CAST(@ReportDate AS DATETIME) + CAST(sh.CheckInStart AS DATETIME) AS CheckInStartTime, -- بداية فترة تسجيل الحضور
        sh.CheckInGracePeriod,
        a.DateTime,
        a.InOutMode
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
        AND CAST(@ReportDate AS DATE) BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID
        AND swd.DayOfWeek = (
            CASE DATENAME(WEEKDAY, @ReportDate)
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
        AND CAST(a.DateTime AS DATE) = CAST(@ReportDate AS DATE)
    WHERE (@UserID IS NULL OR e.UserID = @UserID)
),
AggregatedAttendance AS (
    SELECT 
        ra.UserID,
        ra.Name,
        ra.AttendanceDate,
        ra.ShiftName,
        ra.ScheduledCheckIn,
        ra.ScheduledCheckOut,
        ra.CheckInStartTime, -- بداية فترة تسجيل الحضور
        ra.CheckInGracePeriod,
        MIN(CASE WHEN ra.InOutMode = 0 THEN ra.DateTime END) AS ActualCheckIn,
        MAX(CASE WHEN ra.InOutMode = 1 THEN ra.DateTime END) AS ActualCheckOut
    FROM RawAttendance ra
    GROUP BY 
        ra.UserID,
        ra.Name,
        ra.AttendanceDate,
        ra.ShiftName,
        ra.ScheduledCheckIn,
        ra.ScheduledCheckOut,
        ra.CheckInStartTime,
        ra.CheckInGracePeriod
),
LeavePermissionCTE AS (
    SELECT 
        e.UserID,
        CAST(@ReportDate AS DATE) AS LeaveDate,
        l.LeaveType,
        p.Status AS PermissionStatus,
        ROW_NUMBER() OVER (PARTITION BY e.UserID, CAST(@ReportDate AS DATE) ORDER BY p.PermissionDate DESC) AS RowNum
    FROM Employees e
    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = CAST(@ReportDate AS DATE)
    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = CAST(@ReportDate AS DATE)
    WHERE (@UserID IS NULL OR e.UserID = @UserID)
),
FilteredLeavePermission AS (
    SELECT 
        UserID,
        LeaveDate,
        LeaveType,
        PermissionStatus
    FROM LeavePermissionCTE
    WHERE RowNum = 1

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
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
    CASE 
        -- 1. عطلة رسمية
        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        -- 2. عطلة أسبوعية
        WHEN swd.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        -- 3. إجازة
        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
        -- 4. إذن عمل
        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        -- 5. غياب كامل
        WHEN a.ActualCheckIn IS NULL THEN N'غائب'
        -- 6. حضور قبل فترة الحضور (غير مسموح)
        WHEN a.ActualCheckIn < a.CheckInStartTime THEN N'غائب (حضور مبكر غير مسموح)'
        -- 7. حاضر (ضمن فترة السماح)
        WHEN a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'حاضر'
        -- 8. تأخير
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'متاخر'
        -- حالة افتراضية للغياب
        ELSE N'غائب'
    END AS 'الحالة',
    l.LeaveType AS 'نوع الإجازة',
    l.PermissionStatus AS 'حالة الإذن'
FROM AggregatedAttendance a
LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
LEFT JOIN Holidays h ON h.HolidayDate = a.AttendanceDate
LEFT JOIN ShiftWorkingDays swd ON swd.ShiftID = (
    SELECT ShiftID FROM Shifts WHERE ShiftName = a.ShiftName
) AND swd.DayOfWeek = (
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
ORDER BY 
    a.UserID,
    a.AttendanceDate ASC, 
    a.ShiftName;
";
        }
        //        private string GetDailyAttendanceQuery()
        //        {
        //            // استعلام التقرير اليومي للحضور فقط
        //            return @" 
        //DECLARE @UserID INT = NULL;




        //WITH RawAttendance AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        CAST(@ReportDate AS DATE) AS AttendanceDate,
        //        sh.ShiftID,
        //        sh.ShiftName,
        //        -- sh.StartTime AS ScheduledCheckIn,
        //        sh.EndTime AS ScheduledCheckOut,
        //        sh.CheckInGracePeriod,
        //        a.DateTime,
        //        a.InOutMode
        //    FROM Employees e
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
        //        AND CAST(@ReportDate AS DATE) BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    INNER JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID
        //        AND swd.DayOfWeek = (
        //            CASE DATENAME(WEEKDAY, @ReportDate)
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
        //        AND CAST(a.DateTime AS DATE) = CAST(@ReportDate AS DATE)
        //    WHERE (@UserID IS NULL OR e.UserID = @UserID)
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
        //        UserID,
        //        LeaveDate,
        //        LeaveType,
        //        PermissionStatus
        //    FROM (
        //        SELECT 
        //            e.UserID,
        //            l.LeaveDate,
        //            l.LeaveType,
        //            p.Status AS PermissionStatus,
        //            ROW_NUMBER() OVER (PARTITION BY e.UserID, CAST(@ReportDate AS DATE) ORDER BY p.PermissionDate DESC) AS RowNum
        //        FROM Employees e
        //        LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = CAST(@ReportDate AS DATE)
        //        LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = CAST(@ReportDate AS DATE)
        //        WHERE (@UserID IS NULL OR e.UserID = @UserID)
        //    ) t WHERE RowNum = 1
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
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 108), '--') AS 'الحضور الفعلي',


        //    CASE 
        //        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        //        WHEN swd.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
        //        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        //        WHEN a.ActualCheckIn IS NULL THEN N'غائب'

        //        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'متاخر'
        //        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn)  THEN N'حاضر'
        //        ELSE N'غائب'
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
        //    a.UserID,
        //    a.AttendanceDate ASC, 
        //    a.ShiftName;
        //";
        //        }

        //        private string GetDailyAttendanceQuery()
        //        {
        //            // استعلام التقرير اليومي للحضور فقط
        //            return @"WITH AttendanceCTE AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        sh.ShiftName,
        //        sh.StartTime AS ScheduledCheckIn,
        //        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn
        //    FROM Employees e
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        //        AND @ReportDate BETWEEN sc.StartDate AND sc.EndDate
        //    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
        //    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        //        AND CAST(a.DateTime AS DATE) = @ReportDate
        //    WHERE e.Enabled = 1
        //    GROUP BY e.UserID, e.Name, sh.ShiftName, sh.StartTime
        //),

        //LeavePermissionCTE AS (
        //    SELECT 
        //        e.UserID,
        //        MAX(CASE WHEN l.LeaveDate = @ReportDate THEN l.LeaveType END) AS LeaveType,
        //        MAX(CASE WHEN p.PermissionDate = @ReportDate THEN p.Status END) AS PermissionStatus
        //    FROM Employees e
        //    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = @ReportDate
        //    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = @ReportDate
        //    GROUP BY e.UserID
        //)

        //SELECT 
        //    a.UserID AS 'المعرف',
        //    a.Name AS 'الاسم',
        //    a.ShiftName AS 'الوردية',
        //    CASE DATENAME(WEEKDAY, @ReportDate)
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
        //    CASE 
        //        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        //        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        //        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
        //        WHEN a.ActualCheckIn IS NULL THEN 'غائب'
        //        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'متاخر'
        //        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        //        ELSE 'غائب'
        //    END AS 'الحالة',

        //    l.LeaveType AS 'نوع الإجازة',
        //    l.PermissionStatus AS 'حالة الإذن'
        //FROM AttendanceCTE a
        //LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID
        //LEFT JOIN Holidays h ON h.HolidayDate = @ReportDate
        //LEFT JOIN WorkingDays w ON w.DayOfWeek = (
        //    CASE DATENAME(WEEKDAY, @ReportDate)
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
        //ORDER BY a.ShiftName, a.Name;
        //"; // ضع هنا الاستعلام الكامل الذي قدمته سابقاً
        //        }
    }
}
//COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
//    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',