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
    public partial class StatisticalReportForm : Form
    {
        //private SqlConnection conn;
        private DataGridView dgvReport;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerate;
        private Button btnExportExcel;
        private Button btnExportPDF;

        public StatisticalReportForm()
        {
            InitializeComponent();
           // conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "التقرير الإحصائي التجميعي";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1200, 600);

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
                Text = "عرض التقرير",
                Location = new Point(420, 20),
                Size = new Size(100, 30)
            };
            btnGenerate.Click += BtnGenerate_Click;

            btnExportExcel = new Button
            {
                Text = "تصدير Excel",
                Location = new Point(540, 20),
                Size = new Size(100, 30)
            };
            btnExportExcel.Click += BtnExportExcel_Click;

            btnExportPDF = new Button
            {
                Text = "تصدير PDF",
                Location = new Point(660, 20),
                Size = new Size(100, 30)
            };
            btnExportPDF.Click += BtnExportPDF_Click;

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
            lblStartDate, dtpStartDate,
            lblEndDate, dtpEndDate,
            btnGenerate, btnExportExcel,
            btnExportPDF, dgvReport
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
                    using (SqlCommand cmd = new SqlCommand(GetStatisticalReportQuery(), connection))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvReport.DataSource = dt;

                        // تنسيق أعمدة النسب المئوية
                        foreach (DataGridViewColumn col in dgvReport.Columns)
                        {
                            if (col.HeaderText.Contains("%"))
                            {
                                col.DefaultCellStyle.Format = "N2";
                            }
                        }
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
            //    sfd.FileName = "تقرير_إحصائي_" + DateTime.Now.ToString("yyyy-MM-dd");

            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var package = new ExcelPackage())
            //        {
            //            var worksheet = package.Workbook.Worksheets.Add("التقرير الإحصائي");

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
            //    sfd.FileName = "تقرير_إحصائي_" + DateTime.Now.ToString("yyyy-MM-dd");

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

        private string GetStatisticalReportQuery()
        {
            return @"
WITH DateRange AS (
    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
    FROM sys.objects
),
WorkingDaysOnly AS (
    SELECT d.Date
    FROM DateRange d
    LEFT JOIN Holidays h ON h.HolidayDate = d.Date
    LEFT JOIN WorkingDays w ON w.DayOfWeek = (
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
    WHERE h.HolidayDate IS NULL AND w.DayOfWeek IS NOT NULL
),
DailyAttendance AS (
    SELECT 
        e.UserID,
        e.Name,
        wd.Date AS WorkDate,
        sh.StartTime,
        sh.EndTime,
        s.CheckInGracePeriod,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS FirstCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS LastCheckOut
    FROM Employees e
    CROSS JOIN WorkingDaysOnly wd
    LEFT JOIN EmployeeSchedules es ON e.UserID = es.UserID
    LEFT JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID 
        AND wd.Date BETWEEN sc.StartDate AND sc.EndDate
    LEFT JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    LEFT JOIN Attendance a ON e.UserID = a.UserID 
        AND CAST(a.DateTime AS DATE) = wd.Date
    LEFT JOIN Shifts s ON sh.ShiftID = s.ShiftID
    WHERE e.Enabled = 1
    GROUP BY e.UserID, e.Name, wd.Date, sh.StartTime, sh.EndTime, s.CheckInGracePeriod
),
AttendanceStats AS (
    SELECT 
        UserID,
        Name,
        COUNT(WorkDate) AS TotalWorkDays,
        SUM(CASE WHEN FirstCheckIn IS NOT NULL THEN 1 ELSE 0 END) AS AttendanceDays,
        SUM(CASE WHEN FirstCheckIn IS NULL THEN 1 ELSE 0 END) AS AbsentDays,
        SUM(CASE 
            WHEN FirstCheckIn IS NOT NULL 
            AND CAST(FirstCheckIn AS TIME) > DATEADD(MINUTE, CheckInGracePeriod, StartTime) 
            THEN 1 ELSE 0 END) AS LateDays,
        SUM(CASE 
            WHEN LastCheckOut IS NOT NULL 
            AND CAST(LastCheckOut AS TIME) < EndTime 
            THEN 1 ELSE 0 END) AS EarlyLeaveDays
    FROM DailyAttendance
    GROUP BY UserID, Name
)

SELECT 
    Name AS 'الاسم',
    TotalWorkDays AS 'إجمالي أيام العمل',
    AttendanceDays AS 'أيام الحضور',
    AbsentDays AS 'أيام الغياب',
    LateDays AS 'أيام التأخير',
    EarlyLeaveDays AS 'أيام الانصراف المبكر',
    CAST((CAST(AttendanceDays AS FLOAT) / NULLIF(TotalWorkDays, 0)) * 100 AS DECIMAL(5,2)) AS 'نسبة الحضور %',
    CAST((CAST(AbsentDays AS FLOAT) / NULLIF(TotalWorkDays, 0)) * 100 AS DECIMAL(5,2)) AS 'نسبة الغياب %',
    CAST((CAST(LateDays AS FLOAT) / NULLIF(AttendanceDays, 0)) * 100 AS DECIMAL(5,2)) AS 'نسبة التأخير %',
    CAST((CAST(EarlyLeaveDays AS FLOAT) / NULLIF(AttendanceDays, 0)) * 100 AS DECIMAL(5,2)) AS 'نسبة الانصراف المبكر %'
FROM AttendanceStats
ORDER BY AttendanceDays DESC, Name ASC;
";
        }
    }
}
