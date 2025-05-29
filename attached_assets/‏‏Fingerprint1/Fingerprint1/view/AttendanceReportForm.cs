using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
namespace Fingerprint1.view
{
    public partial class AttendanceReportForm : Form
    {
       // private string _connectionString = "YourConnectionStringHere";

        public AttendanceReportForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.cmbEmployee = new ComboBox();
            this.btnShowReport = new Button();
            this.dgvReport = new DataGridView();
            this.btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // تاريخ البداية
            this.dtpStartDate.Location = new Point(20, 20);
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Value = DateTime.Now.AddMonths(-1);

            // تاريخ النهاية
            this.dtpEndDate.Location = new Point(200, 20);
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Value = DateTime.Now;

            // قائمة الموظفين
            this.cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEmployee.Location = new Point(380, 20);
            this.cmbEmployee.Width = 200;
            this.LoadEmployees();

            // زر عرض التقرير
            this.btnShowReport.Text = "عرض التقرير";
            this.btnShowReport.Location = new Point(600, 20);
            this.btnShowReport.Click += new EventHandler(this.btnShowReport_Click);

            // جدول العرض
            this.dgvReport.Location = new Point(20, 60);
            this.dgvReport.Size = new Size(760, 300);
            this.dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ReadOnly = true;

            // زر الطباعة
            this.btnPrint.Text = "طباعة التقرير";
            this.btnPrint.Location = new Point(600, 380);
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);

            // إعدادات النموذج
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnPrint);
            this.Text = "تقرير الموظفين المنضبطين";
            this.ResumeLayout(false);
        }

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbEmployee;
        private Button btnShowReport;
        private DataGridView dgvReport;
        private Button btnPrint;

        // تحميل قائمة الموظفين
        private void LoadEmployees()
        {
            AppSetting setting = new AppSetting();
            string _connectionString = setting.GetConnectionString("cn");
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT UserID, Name FROM Employees ORDER BY Name";
                var adapter = new SqlDataAdapter(query, connection);
                var table = new DataTable();
                adapter.Fill(table);

                // إضافة خيار "جميع الموظفين"
                cmbEmployee.Items.Add(new { UserID = -1, Name = "جميع الموظفين" });

                // إضافة الموظفين
                foreach (DataRow row in table.Rows)
                {
                    cmbEmployee.Items.Add(new { UserID = row["UserID"], Name = row["Name"] });
                }

                cmbEmployee.DisplayMember = "Name"; // العمود الذي سيتم عرضه
                cmbEmployee.ValueMember = "UserID"; // العمود الذي سيتم استخدامه كقيمة
                cmbEmployee.SelectedIndex = 0; // تحديد الخيار الأول افتراضيًا
            }
        }

        // عرض التقرير
        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value;
                int? employeeId = cmbEmployee.SelectedIndex > 0 ? (int?)cmbEmployee.SelectedValue : null;

                var dataTable = GetAttendanceReport(startDate, endDate, employeeId);
                dgvReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // استعلام جلب التقرير
        private DataTable GetAttendanceReport(DateTime startDate, DateTime endDate, int? employeeId)
        {
            var query = @"
WITH DateRange AS (
    SELECT TOP (ABS(DATEDIFF(DAY, @StartDate, @EndDate)) + 1)
        DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY object_id) - 1, @StartDate) AS Date
    FROM sys.objects
),
WorkingDaysCTE AS (
    SELECT
        e.UserID,
        d.Date AS AttendanceDate,
        sh.ShiftID,
        swd.DayOfWeek
    FROM Employees e
    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
    INNER JOIN Schedules sc ON es.ScheduleID = sc.ScheduleID
    INNER JOIN DateRange d ON d.Date BETWEEN sc.StartDate AND sc.EndDate
    INNER JOIN Shifts sh ON sc.ShiftID = sh.ShiftID
    LEFT JOIN ShiftWorkingDays swd ON sh.ShiftID = swd.ShiftID
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
    WHERE (@UserID IS NULL OR e.UserID = @UserID)
),
AttendanceCTE AS (
    SELECT
        wd.UserID,
        wd.AttendanceDate,
        MIN(CASE WHEN a.InOutMode = 0 THEN a.DateTime END) AS ActualCheckIn,
        MAX(CASE WHEN a.InOutMode = 1 THEN a.DateTime END) AS ActualCheckOut
    FROM WorkingDaysCTE wd
    LEFT JOIN Attendance a ON wd.UserID = a.UserID
        AND CAST(a.DateTime AS DATE) = wd.AttendanceDate
    GROUP BY wd.UserID, wd.AttendanceDate
),
SummaryCTE AS (
    SELECT
        wd.UserID,
        COUNT(DISTINCT wd.AttendanceDate) AS RequiredWorkingDays,
        COUNT(DISTINCT CASE 
            WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NOT NULL THEN wd.AttendanceDate 
        END) AS ActualWorkingDays
    FROM WorkingDaysCTE wd
    LEFT JOIN AttendanceCTE a ON wd.UserID = a.UserID AND wd.AttendanceDate = a.AttendanceDate
    GROUP BY wd.UserID
)
SELECT
    e.Name AS 'اسم الموظف',
    s.RequiredWorkingDays AS 'عدد أيام الدوام المطلوبة',
    s.ActualWorkingDays AS 'عدد أيام الحضور الفعلي',
    CAST((s.ActualWorkingDays * 100.0 / NULLIF(s.RequiredWorkingDays, 0)) AS DECIMAL(5, 2)) AS 'نسبة الانضباط (%)'
FROM SummaryCTE s
INNER JOIN Employees e ON s.UserID = e.UserID
WHERE (@UserID IS NULL OR e.UserID = @UserID)
ORDER BY e.Name;";

            var dataTable = new DataTable();
            AppSetting setting = new AppSetting();
            string _connectionString = setting.GetConnectionString("cn");
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                if (employeeId.HasValue)
                    command.Parameters.AddWithValue("@UserID", employeeId);
                else
                    command.Parameters.AddWithValue("@UserID", DBNull.Value);

                connection.Open();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // طباعة التقرير
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPageHandler);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            float yPos = 50;
            float xPos = 50;

            // عنوان التقرير
            e.Graphics.DrawString("تقرير الموظفين المنضبطين", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, xPos, yPos);
            yPos += 40;

            // فترة التقرير
            e.Graphics.DrawString($"الفترة: {dtpStartDate.Value.ToShortDateString()} إلى {dtpEndDate.Value.ToShortDateString()}", font, Brushes.Black, xPos, yPos);
            yPos += 30;

            // بيانات الجدول
            foreach (DataGridViewRow row in dgvReport.Rows)
            {
                if (!row.IsNewRow)
                {
                    string rowData = "";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        rowData += $"{cell.Value}\t";
                    }
                    e.Graphics.DrawString(rowData, font, Brushes.Black, xPos, yPos);
                    yPos += 20;
                }
            }
        }
    }
}