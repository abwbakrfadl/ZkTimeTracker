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
    public partial class DailyReportForm : Form
    {
      //  private SqlConnection conn;
        //private DataGridView dgvReport;
        //private DateTimePicker dtpDate;
        //private Button btnGenerate;
        //private Button btnExportExcel;
        //private Button btnExportPDF;

        public DailyReportForm()
        {
            InitializeComponent();
           // conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            //InitializeControls();
        }

        //private void InitializeControls()
        //{
        //    this.Text = "التقرير اليومي للحضور والانصراف";
        //    this.RightToLeft = RightToLeft.Yes;
        //    this.RightToLeftLayout = true;
        //    this.Size = new Size(1200, 600);

        //    // التقويم
        //    dtpDate = new DateTimePicker
        //    {
        //        Format = DateTimePickerFormat.Short,
        //        Location = new Point(20, 30),
        //        Size = new Size(120, 20)
        //    };

        //    // أزرار التحكم
        //    btnGenerate = new Button
        //    {
        //        Text = "عرض التقرير",
        //        Location = new Point(160, 30),
        //        Size = new Size(100, 30)
        //    };
        //    btnGenerate.Click += BtnGenerate_Click;

        //    btnExportExcel = new Button
        //    {
        //        Text = "تصدير Excel",
        //        Location = new Point(280, 30),
        //        Size = new Size(100, 30)
        //    };
        //    btnExportExcel.Click += BtnExportExcel_Click;

        //    btnExportPDF = new Button
        //    {
        //        Text = "تصدير PDF",
        //        Location = new Point(400, 30),
        //        Size = new Size(100, 30)
        //    };
        //    btnExportPDF.Click += BtnExportPDF_Click;

        //    // جدول عرض البيانات
        //    dgvReport = new DataGridView
        //    {
        //        Dock = DockStyle.Bottom,
        //        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        //        RightToLeft = RightToLeft.Yes,
        //        Size = new Size(1160, 500),
        //        Location = new Point(20, 70)
        //    };

        //    this.Controls.AddRange(new Control[] {
        //    dtpDate, btnGenerate, btnExportExcel, btnExportPDF, dgvReport
        //});
        //}

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
                <th>ميعاد الانصراف المخطط</th>
                <th>الانصراف الفعلي</th>
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
                <div>متاخر: " + summary["متاخر"] + @"</div> <!-- تم تصحيح الخطأ الإملائي هنا -->
                <div>إجازة: " + summary["إجازة"] + @"</div>
                <div>عطلة رسمية: " + summary["عطلة رسمية"] + @"</div>
                <div>عطلة أسبوعية: " + summary["عطلة أسبوعية"] + @"</div> <!-- إضافة عطلة أسبوعية -->
                <div>حضور متاخر بدون انصراف: " + summary["حضور متاخر بدون انصراف"] + @"</div>
                <div>حضور بدون انصراف: " + summary["حضور بدون انصراف"] + @"</div>
                <div>حضور متاخر: " + summary["حضور متاخر"] + @"</div>
                <div>لم يسجل حضور: " + summary["لم يسجل حضور"] + @"</div>
                <div>حضور متاخر وانصراف مبكر: " + summary["حضور متاخر وانصراف مبكر"] + @"</div>
                <div>انصراف مبكر: " + summary["انصراف مبكر"] + @"</div>
                <div>أذن عمل: " + summary["أذن عمل"] + @"</div>
            </div>
        </div>
    </div>
    <button class='no-print' onclick='window.print()' style='margin: 20px;'>طباعة</button>
</body>
</html>";

                string tempFile = Path.Combine(Path.GetTempPath(), "daily_attendance_report1.html");
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
        {"متاخر", 0}, // تم إلغاء التعليق وإصلاح التهجئة
        {"إجازة", 0},
        {"عطلة رسمية", 0},
        {"عطلة أسبوعية", 0},
        {"أذن عمل", 0},
        {"حضور متاخر بدون انصراف", 0},
        {"حضور بدون انصراف", 0},
        {"حضور متاخر", 0},
        {"لم يسجل حضور", 0},
        {"حضور متاخر وانصراف مبكر", 0},
        {"انصراف مبكر", 0}
    };

            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                string status = row.Cells["الحالة"].Value?.ToString()?.Trim() ?? "";
                if (status.Contains("إجازة"))
                    summary["إجازة"]++;
                else if (status == "متاخر")
                    summary["متاخر"]++;
                else if (status == "عطلة رسمية")
                    summary["عطلة رسمية"]++;
                else if (status == "عطلة أسبوعية")
                    summary["عطلة أسبوعية"]++;
                else if (status == "أذن عمل")
                    summary["أذن عمل"]++;
                else if (status == "حضور متاخر بدون انصراف")
                    summary["حضور متاخر بدون انصراف"]++;
                else if (status == "حضور بدون انصراف")
                    summary["حضور بدون انصراف"]++;
                else if (status == "حضور متاخر")
                    summary["حضور متاخر"]++;
                else if (status == "لم يسجل حضور")
                    summary["لم يسجل حضور"]++;
                else if (status == "حضور متاخر وانصراف مبكر")
                    summary["حضور متاخر وانصراف مبكر"]++;
                else if (status == "انصراف مبكر")
                    summary["انصراف مبكر"]++;
                else if (summary.ContainsKey(status))
                    summary[status]++;
                else
                {
                    // حالة غير متوقعة (يمكن إضافتها إلى القاموس أو تجاهلها)
                    if (!summary.ContainsKey("غير معرف"))
                        summary.Add("غير معرف", 1);
                    else
                        summary["غير معرف"]++;
                }
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
                    using (SqlCommand cmd = new SqlCommand(GetDailyReportQuery(), connection))
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
            //    sfd.FileName = "تقرير_يومي_" + dtpDate.Value.ToString("yyyy-MM-dd");

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var package = new ExcelPackage())
            //        {
            //            var worksheet = package.Workbook.Worksheets.Add("تقرير يومي");

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
            PrintDailyReportWeb();
            //using (SaveFileDialog sfd = new SaveFileDialog())
            //{
            //    sfd.Filter = "PDF Files|*.pdf";
            //    sfd.FileName = "تقرير_يومي_" + dtpDate.Value.ToString("yyyy-MM-dd");

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
       // التقرير اليومي : 
//            private string GetDailyReportQuery()
//        {
//            return @"
//WITH AttendanceCTE AS (
//    SELECT 
//        e.UserID,
//        e.Name,
//        sh.ShiftName,
//        sh.StartTime AS ScheduledCheckIn,
//        sh.EndTime AS ScheduledCheckOut,
//        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
//        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
//    FROM Employees e
//    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
//    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
//        AND @ReportDate BETWEEN sc.StartDate AND sc.EndDate
//    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
//    LEFT JOIN Attendance a ON e.UserID = a.UserID 
//        AND CAST(a.DateTime AS DATE) = @ReportDate
//    WHERE e.Enabled = 1
//    GROUP BY e.UserID, e.Name, sh.ShiftName, sh.StartTime, sh.EndTime
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
//    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
//    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
//    CASE 
//        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
//        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
//        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
//        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
       
//        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
//        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)  THEN 'حضور متاخر بدون انصراف'
//        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم' 
//        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN ' غائب-حضور متاخر '
//        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
//        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
//        ELSE 'غائب'
//    END AS 'الحالة',
//    s.CheckInGracePeriod AS 'سماحية الحضور (دقيقة)',
//    s.CheckOutGracePeriod AS 'سماحية الانصراف (دقيقة)',
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

//ORDER BY a.ShiftName, a.Name;";
//        }

        private void DailyReportForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyReportForm1 adminPanel = new DailyReportForm1();
            adminPanel.Show();
        }
        private string GetDailyReportQuery()
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
        CAST(@ReportDate AS DATETIME) + CAST(sh.StartTime AS DATETIME) AS ScheduledCheckIn,
        CAST(@ReportDate AS DATETIME) + CAST(sh.EndTime AS DATETIME) AS ScheduledCheckOut,
        CAST(@ReportDate AS DATETIME) + CAST(sh.CheckInStart AS DATETIME) AS CheckInStartTime,
        sh.CheckInGracePeriod,
        a.DateTime AS ActualDateTime,
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
        ra.CheckInStartTime,
        ra.CheckInGracePeriod,
        MIN(CASE WHEN ra.InOutMode = 0 THEN ra.ActualDateTime END) AS ActualCheckIn,
        MAX(CASE WHEN ra.InOutMode = 1 THEN ra.ActualDateTime END) AS ActualCheckOut
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
    COALESCE(CONVERT(VARCHAR,  CAST(a.ScheduledCheckIn AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط (24 ساعة)',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 108), '--') AS 'الحضور الفعلي (24 ساعة)',
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 108), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط (24 ساعة)',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 108), '--') AS 'الانصراف الفعلي (24 ساعة)',
    CASE 
        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        WHEN swd.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        WHEN a.ActualCheckIn < a.CheckInStartTime THEN N'غائب'
        WHEN a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut >= a.ScheduledCheckOut 
            THEN N'حاضر'
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut IS NULL 
            THEN N'حضور متاخر بدون انصراف'
        WHEN a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut IS NULL 
            THEN N'حضور بدون انصراف'
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut >= a.ScheduledCheckOut 
            THEN N'حضور متاخر'
        WHEN a.ActualCheckIn IS NULL 
             AND a.ActualCheckOut >= a.ScheduledCheckOut 
            THEN N'لم يسجل حضور'
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut < a.ScheduledCheckOut 
            THEN N'حضور متاخر وانصراف مبكر'
        WHEN a.ActualCheckOut < a.ScheduledCheckOut 
             AND a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'انصراف مبكر'
        ELSE N'غائب'
    END AS 'الحالة',
    l.LeaveType AS 'نوع الإجازة',
    l.PermissionStatus AS 'حالة الإذن'
FROM AggregatedAttendance a
LEFT JOIN FilteredLeavePermission l ON a.UserID = l.UserID AND a.AttendanceDate = l.LeaveDate
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


        private string GetDailyReportQuery1()
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
        -- استخدام StartTime و CheckInStart كأوقات بدء العمل وتسجيل الحضور
        CAST(@ReportDate AS DATETIME) + CAST(sh.StartTime AS DATETIME) AS ScheduledCheckIn, -- بداية العمل
        CAST(@ReportDate AS DATETIME) + CAST(sh.EndTime AS DATETIME) AS ScheduledCheckOut, -- نهاية العمل
        CAST(@ReportDate AS DATETIME) + CAST(sh.CheckInStart AS DATETIME) AS CheckInStartTime, -- بداية فترة تسجيل الحضور
        sh.CheckInGracePeriod,
        a.DateTime AS ActualDateTime,
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
        MIN(CASE WHEN ra.InOutMode = 0 THEN ra.ActualDateTime END) AS ActualCheckIn,
        MAX(CASE WHEN ra.InOutMode = 1 THEN ra.ActualDateTime END) AS ActualCheckOut
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
        UserID,
        LeaveDate,
        LeaveType,
        PermissionStatus
    FROM (
        SELECT 
            e.UserID,
            l.LeaveDate,
            l.LeaveType,
            p.Status AS PermissionStatus,
            ROW_NUMBER() OVER (PARTITION BY e.UserID, CAST(@ReportDate AS DATE) ORDER BY p.PermissionDate DESC) AS RowNum
        FROM Employees e
        LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = CAST(@ReportDate AS DATE)
        LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = CAST(@ReportDate AS DATE)
        WHERE (@UserID IS NULL OR e.UserID = @UserID)
    ) t WHERE RowNum = 1


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
    COALESCE(CONVERT(VARCHAR, a.ScheduledCheckIn, 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط (24 ساعة)',
    COALESCE(CONVERT(VARCHAR, a.ActualCheckIn, 100), '--') AS 'الحضور الفعلي (24 ساعة)',
    COALESCE(CONVERT(VARCHAR, a.ScheduledCheckOut, 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط (24 ساعة)',
    COALESCE(CONVERT(VARCHAR, a.ActualCheckOut, 100), '--') AS 'الانصراف الفعلي (24 ساعة)',
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
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        -- 6. حضور قبل فترة الحضور (غير مسموح)
        WHEN a.ActualCheckIn < a.CheckInStartTime THEN N'غائب'
        -- 7. حاضر (ضمن فترة السماح)
        WHEN a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut >= a.ScheduledCheckOut 
            THEN N'حاضر'
        -- 8. تأخير بدون انصراف
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut IS NULL 
            THEN N'حضور متاخر بدون انصراف'
        -- 9. حضور بدون انصراف (ضمن السماح)
        WHEN a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut IS NULL 
            THEN N'حضور بدون انصراف'
        -- 10. تأخير مع انصراف في الوقت المحدد
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut >= a.ScheduledCheckOut 
            THEN N'حضور متاخر'
        -- 11. عدم تسجيل الحضور مع انصراف في الوقت المحدد
        WHEN a.ActualCheckIn IS NULL 
             AND a.ActualCheckOut >= a.ScheduledCheckOut 
            THEN N'لم يسجل حضور'
        -- 12. تأخير + انصراف مبكر
        WHEN a.ActualCheckIn > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
             AND a.ActualCheckOut < a.ScheduledCheckOut 
            THEN N'حضور متاخر وانصراف مبكر'
        -- 13. انصراف مبكر مع حضور في الوقت المحدد
        WHEN a.ActualCheckOut < a.ScheduledCheckOut 
             AND a.ActualCheckIn <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) 
            THEN N'انصراف مبكر'
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

        //        private string GetDailyReportQuery()
        //        {
        //            return @"

        //DECLARE @UserID INT = NULL;




        //WITH RawAttendance AS (
        //    SELECT 
        //        e.UserID,
        //        e.Name,
        //        CAST(@ReportDate AS DATE) AS AttendanceDate,
        //        sh.ShiftID,
        //        sh.ShiftName,
        //        sh.StartTime AS ScheduledCheckIn,
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
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
        //    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
        //    CASE 
        //        WHEN h.HolidayDate IS NOT NULL THEN N'عطلة رسمية'
        //        WHEN swd.DayOfWeek IS NULL THEN N'عطلة أسبوعية'
        //        WHEN l.LeaveType IS NOT NULL THEN N'إجازة (' + l.LeaveType + N')'
        //        WHEN l.PermissionStatus = N'مقبول' THEN N'أذن عمل'
        //        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN N'غائب'
        //        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) AND 
        //             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'حاضر'
        //        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND 
        //             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'حضور متاخر بدون انصراف'
        //        WHEN (a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn)) AND
        //            a.ActualCheckOut IS NULL THEN N'حضور بدون انصراف'
        //        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) AND 
        //             CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'حضور متاخر'
        //        WHEN a.ActualCheckIn IS NULL AND CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN N'لم يسجل حضور'
        //        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL AND 
        //             CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) AND 
        //             CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN N'حضور متاخر وانصراف مبكر'
        //        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut AND 
        //             CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, a.CheckInGracePeriod, a.ScheduledCheckIn) THEN N'انصراف مبكر'
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


    }
}


//WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'

//       WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر بدون انصراف'
//        WHEN(a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم' 

//       WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'غائب-حضور متاخر'
//        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
//        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'

//WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'

//       WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر بدون انصراف'
//        WHEN(a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم' 

//       WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'غائب-حضور متاخر'
//        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
//        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'