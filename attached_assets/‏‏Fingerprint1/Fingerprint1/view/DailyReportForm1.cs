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
    public partial class DailyReportForm1 : Form
    {
        //private SqlConnection conn;
        private DataGridView dgvReport;
        private DateTimePicker dtpDate;
        private Button btnGenerate;
        private Button btnExportExcel;
        private Button btnExportPDF;

        public DailyReportForm1()
        {
            InitializeComponent();
         //   conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "التقرير اليومي للحضور والانصراف";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1200, 600);

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

            btnExportExcel = new Button
            {
                Text = "تصدير Excel",
                Location = new Point(280, 20),
                Size = new Size(100, 30)
            };
            btnExportExcel.Click += BtnExportExcel_Click;

            btnExportPDF = new Button
            {
                Text = "تصدير PDF",
                Location = new Point(400, 20),
                Size = new Size(100, 30)
            };
            btnExportPDF.Click += BtnExportPDF_Click;

            // جدول عرض البيانات
            dgvReport = new DataGridView
            {
                Dock = DockStyle.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RightToLeft = RightToLeft.Yes,
                Size = new Size(1160, 500),
                Location = new Point(20, 70)
            };

            this.Controls.AddRange(new Control[] {
            dtpDate, btnGenerate, btnExportExcel, btnExportPDF, dgvReport
        });
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
            private string GetDailyReportQuery()
        {
            return @"
WITH AttendanceCTE AS (
    SELECT 
        e.UserID,
        e.Name,
        sh.ShiftName,
        sh.StartTime AS ScheduledCheckIn,
        sh.EndTime AS ScheduledCheckOut,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        AND @ReportDate BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        AND CAST(a.DateTime AS DATE) = @ReportDate
    WHERE e.Enabled = 1
    GROUP BY e.UserID, e.Name, sh.ShiftName, sh.StartTime, sh.EndTime
),

LeavePermissionCTE AS (
    SELECT 
        e.UserID,
        MAX(CASE WHEN l.LeaveDate = @ReportDate THEN l.LeaveType END) AS LeaveType,
        MAX(CASE WHEN p.PermissionDate = @ReportDate THEN p.Status END) AS PermissionStatus
    FROM Employees e
    LEFT JOIN Leaves l ON e.UserID = l.UserID AND l.LeaveDate = @ReportDate
    LEFT JOIN Permissions p ON e.UserID = p.UserID AND p.PermissionDate = @ReportDate
    GROUP BY e.UserID
)

SELECT 
    a.UserID AS 'المعرف',
    a.Name AS 'الاسم',
    a.ShiftName AS 'الوردية',
    CASE DATENAME(WEEKDAY, @ReportDate)
        WHEN 'Sunday' THEN N'الأحد'
        WHEN 'Monday' THEN N'الاثنين'
        WHEN 'Tuesday' THEN N'الثلاثاء'
        WHEN 'Wednesday' THEN N'الأربعاء'
        WHEN 'Thursday' THEN N'الخميس'
        WHEN 'Friday' THEN N'الجمعة'
        WHEN 'Saturday' THEN N'السبت'
    END AS 'يوم الأسبوع',
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckIn AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الحضور المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckIn AS TIME), 100), '--') AS 'الحضور الفعلي',
    COALESCE(CONVERT(VARCHAR, CAST(a.ScheduledCheckOut AS TIME), 100), 'لا يوجد جدول') AS 'ميعاد الانصراف المخطط',
    COALESCE(CONVERT(VARCHAR, CAST(a.ActualCheckOut AS TIME), 100), '--') AS 'الانصراف الفعلي',
    CASE 
        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'

	 WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
        WHEN a.ActualCheckIn IS NULL  AND a.ActualCheckOut IS NOT NULL THEN 'لم يسجل حضور'
        WHEN CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر'

        ELSE 'غائب'
    END AS ' حالة الحضور',
 CASE 
        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
	    WHEN a.ActualCheckIn IS NOT NULL  AND a.ActualCheckOut IS NULL THEN 'لم يسجل انصارف'
	    WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
      	WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
	    WHEN CAST(a.ActualCheckOut AS TIME) >= a.ScheduledCheckOut THEN 'انصراف '
ELSE 'غائب'
    END AS 'حالة الانصراف',
    s.CheckInGracePeriod AS 'سماحية الحضور (دقيقة)',
    s.CheckOutGracePeriod AS 'سماحية الانصراف (دقيقة)',
    l.LeaveType AS 'نوع الإجازة',
    l.PermissionStatus AS 'حالة الإذن'
FROM AttendanceCTE a
LEFT JOIN LeavePermissionCTE l ON a.UserID = l.UserID
LEFT JOIN Holidays h ON h.HolidayDate = @ReportDate
LEFT JOIN WorkingDays w ON w.DayOfWeek = (
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
LEFT JOIN Shifts s ON a.ShiftName = s.ShiftName
ORDER BY a.ShiftName, a.Name;";
        }
        //        private string GetDailyReportQuery()
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
        //CASE 
        //    WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        //    WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        //    WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        //    WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
        //    WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
        //    WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NOT NULL THEN 'لم يسجل حضور'
        //    WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL THEN 'لم يسجل انصراف'
        //    ELSE (
        //        SELECT TOP 1 ast.StatusName
        //        FROM AttendanceStatus ast
        //        WHERE 
        //            (ast.StatusType = 'CheckIn' AND
        //            DATEDIFF(MINUTE, CAST(a.ScheduledCheckIn AS TIME), CAST(a.ActualCheckIn AS TIME)) 
        //            BETWEEN ast.MinutesFrom AND ast.MinutesTo)
        //            OR
        //            (ast.StatusType = 'CheckOut' AND
        //            DATEDIFF(MINUTE, CAST(a.ScheduledCheckOut AS TIME), CAST(a.ActualCheckOut AS TIME)) 
        //            BETWEEN ast.MinutesFrom AND ast.MinutesTo)
        //        ORDER BY 
        //            CASE 
        //                WHEN ast.StatusType = 'CheckIn' THEN 
        //                    ABS(DATEDIFF(MINUTE, CAST(a.ScheduledCheckIn AS TIME), CAST(a.ActualCheckIn AS TIME)))
        //                ELSE 
        //                    ABS(DATEDIFF(MINUTE, CAST(a.ScheduledCheckOut AS TIME), CAST(a.ActualCheckOut AS TIME)))
        //            END DESC
        //    )
        //END AS 'الحالة',
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
    }
}
