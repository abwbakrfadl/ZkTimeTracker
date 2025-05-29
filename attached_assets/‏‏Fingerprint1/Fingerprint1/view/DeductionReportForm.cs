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
    public partial class DeductionReportForm : Form
    {
       // private SqlConnection conn;
        private DateTimePicker dtpFromDate;
        private DateTimePicker dtpToDate;
        private ComboBox cmbEmployee;
        private Button btnGenerate;
        private DataGridView dgvReport;
        private Label lblTotalDeduction;

        public DeductionReportForm()
        {
            InitializeComponent();
           // conn = new SqlConnection(@"Server=DESKTOP-3F7NFV1\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True");
            InitializeForm();
            LoadEmployees();
        }

        private void InitializeForm()
        {
            this.Text = "تقرير الخصومات المتوقعة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel for controls
            TableLayoutPanel controlPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 100,
                ColumnCount = 4,
                RowCount = 2,
                Padding = new Padding(10)
            };

            // Initialize controls
            dtpFromDate = new DateTimePicker { Dock = DockStyle.Fill };
            dtpToDate = new DateTimePicker { Dock = DockStyle.Fill };
            cmbEmployee = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            btnGenerate = new Button { Text = "عرض التقرير", Dock = DockStyle.Fill };

            // Add controls to panel
            controlPanel.Controls.Add(new Label { Text = "من تاريخ:", Dock = DockStyle.Fill }, 0, 0);
            controlPanel.Controls.Add(dtpFromDate, 1, 0);
            controlPanel.Controls.Add(new Label { Text = "إلى تاريخ:", Dock = DockStyle.Fill }, 2, 0);
            controlPanel.Controls.Add(dtpToDate, 3, 0);
            controlPanel.Controls.Add(new Label { Text = "الموظف:", Dock = DockStyle.Fill }, 0, 1);
            controlPanel.Controls.Add(cmbEmployee, 1, 1);
            controlPanel.Controls.Add(btnGenerate, 3, 1);

            // Initialize DataGridView
            dgvReport = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                RightToLeft = RightToLeft.Yes
            };

            // Total Label
            lblTotalDeduction = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            // Add controls to form
            this.Controls.Add(dgvReport);
            this.Controls.Add(lblTotalDeduction);
            this.Controls.Add(controlPanel);

            // Add event handler
            btnGenerate.Click += BtnGenerate_Click;
        }

        private void LoadEmployees()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    using (SqlCommand cmd = new SqlCommand("SELECT UserID, Name FROM Employees WHERE Enabled = 1", connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DataRow allRow = dt.NewRow();
                        allRow["UserID"] = DBNull.Value;
                        allRow["Name"] = "-- جميع الموظفين --";
                        dt.Rows.InsertAt(allRow, 0);

                        cmbEmployee.DisplayMember = "Name";
                        cmbEmployee.ValueMember = "UserID";
                        cmbEmployee.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل بيانات الموظفين: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    // First, let's check if we have any attendance records
                    string checkSql = @"
            SELECT COUNT(*) 
            FROM Attendance a
            INNER JOIN Employees e ON a.UserID = e.UserID
            WHERE CAST(a.DateTime AS DATE) BETWEEN @FromDate AND @ToDate
            AND (@UserID IS NULL OR e.UserID = @UserID)";

                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                        checkCmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);
                        checkCmd.Parameters.AddWithValue("@UserID",
                            cmbEmployee.SelectedIndex == 0 ? DBNull.Value : cmbEmployee.SelectedValue);

                        connection.Open();
                        int recordCount = (int)checkCmd.ExecuteScalar();
                        connection.Close();

                        if (recordCount == 0)
                        {
                            MessageBox.Show("لا توجد سجلات حضور للفترة المحددة");
                            return;
                        }
                    }

                    // If we have records, let's get the detailed report
                    string sql = @"
           DECLARE @FromDate DATE;
DECLARE @ToDate DATE ;
DECLARE @UserID;
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

LeavePermissionCTE AS(
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
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر بدون انصراف'
        WHEN(a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم' 

       WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'غائب-حضور متاخر'
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        ELSE 'غائب'
    END AS 'الحالة',
    COALESCE(d.DiscountAmount, 0) AS 'مبلغ الخصم',
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

LEFT JOIN Discounts d ON
    CASE
        WHEN h.HolidayDate IS NOT NULL THEN 'عطلة رسمية'
        WHEN w.DayOfWeek IS NULL THEN 'عطلة أسبوعية'
        WHEN l.LeaveType IS NOT NULL THEN 'إجازة (' + l.LeaveType + ')'
        WHEN l.PermissionStatus = 'مقبول' THEN 'أذن عمل'
        WHEN a.ActualCheckIn IS NULL AND a.ActualCheckOut IS NULL THEN 'غائب'
        WHEN a.ActualCheckIn IS NOT NULL AND a.ActualCheckOut IS NULL AND CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حضور متاخر بدون انصراف'
        WHEN(a.ActualCheckIn IS NOT NULL AND CAST(a.ActualCheckIn AS TIME) <= DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn)) AND a.ActualCheckOut IS NULL THEN 'حضور نصف يوم' 

       WHEN CAST(a.ActualCheckIn AS TIME) > DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'غائب-حضور متاخر'
        WHEN CAST(a.ActualCheckOut AS TIME) < a.ScheduledCheckOut THEN 'انصراف مبكر'
        WHEN CAST(a.ActualCheckIn AS TIME) < DATEADD(MINUTE, s.CheckInGracePeriod, a.ScheduledCheckIn) THEN 'حاضر'
        ELSE 'غائب'
    END = d.ConditionName
ORDER BY a.ShiftName, a.Name;";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                        cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date);
                        cmd.Parameters.AddWithValue("@UserID",
                            cmbEmployee.SelectedIndex == 0 ? DBNull.Value : cmbEmployee.SelectedValue);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Configure the DataGridView columns
                        dgvReport.DataSource = dt;
                        foreach (DataGridViewColumn col in dgvReport.Columns)
                        {
                            if (col.Name == "مبلغ الخصم")
                            {
                                col.DefaultCellStyle.Format = "N2";
                                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            }
                            else if (col.Name == "التاريخ")
                            {
                                col.DefaultCellStyle.Format = "dd/MM/yyyy";
                            }
                        }

                        // Calculate and display total deductions
                        if (dt.Rows.Count > 0)
                        {
                            decimal total = dt.AsEnumerable()
                                .Sum(row => row.Field<decimal?>("مبلغ الخصم") ?? 0);
                            lblTotalDeduction.Text = $"إجمالي الخصومات المتوقعة: {total:N2} ريال";
                        }
                        else
                        {
                            MessageBox.Show("لا توجد خصومات للفترة المحددة");
                            lblTotalDeduction.Text = "إجمالي الخصومات المتوقعة: 0.00 ريال";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إنشاء التقرير: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        //private void BtnGenerate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();

        //        // First, let's check if we have any attendance records
        //        string checkSql = @"
        //    SELECT COUNT(*) 
        //    FROM Attendance a
        //    INNER JOIN Employees e ON a.UserID = e.UserID
        //    WHERE a.DateTime BETWEEN @FromDate AND @ToDate
        //    AND (@UserID IS NULL OR e.UserID = @UserID)";

        //        using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
        //        {
        //            checkCmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
        //            checkCmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));
        //            checkCmd.Parameters.AddWithValue("@UserID",
        //                cmbEmployee.SelectedIndex == 0 ? DBNull.Value : cmbEmployee.SelectedValue);

        //            conn.Open();
        //            int recordCount = (int)checkCmd.ExecuteScalar();
        //            conn.Close();

        //            if (recordCount == 0)
        //            {
        //                MessageBox.Show("لا توجد سجلات حضور للفترة المحددة");
        //                return;
        //            }
        //        }

        //        // If we have records, let's get the detailed report
        //        string sql = @"
        //    SELECT 
        //        e.Name AS 'اسم الموظف',
        //        a.DateTime AS 'وقت التسجيل',
        //        a.InOutMode AS 'نوع التسجيل',
        //        sh.StartTime AS 'وقت بداية الدوام',
        //        sh.EndTime AS 'وقت نهاية الدوام',
        //        s.StatusName AS 'الحالة',
        //        s.DeductionAmount AS 'مبلغ الخصم'
        //    FROM Attendance a
        //    INNER JOIN Employees e ON a.UserID = e.UserID
        //    INNER JOIN EmployeeSchedules es ON e.UserID = es.UserID
        //    INNER JOIN Schedules sch ON es.ScheduleID = sch.ScheduleID
        //    INNER JOIN Shifts sh ON sch.ShiftID = sh.ShiftID
        //    LEFT JOIN AttendanceStatus s ON 
        //        (a.InOutMode = 1 AND s.StatusType = 'CheckIn')
        //        OR 
        //        (a.InOutMode = 2 AND s.StatusType = 'CheckOut')
        //    WHERE a.DateTime BETWEEN @FromDate AND @ToDate
        //    AND (@UserID IS NULL OR e.UserID = @UserID)
        //    ORDER BY e.Name, a.DateTime";

        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
        //            cmd.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1).AddSeconds(-1));
        //            cmd.Parameters.AddWithValue("@UserID",
        //                cmbEmployee.SelectedIndex == 0 ? DBNull.Value : cmbEmployee.SelectedValue);

        //            conn.Open();
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            adapter.Fill(dt);

        //            dgvReport.DataSource = dt;

        //            if (dt.Rows.Count > 0)
        //            {
        //                decimal total = dt.AsEnumerable()
        //                    .Sum(row => row.Field<decimal?>("مبلغ الخصم") ?? 0);
        //                lblTotalDeduction.Text = $"إجمالي الخصومات المتوقعة: {total:N2} ريال";
        //            }
        //            else
        //            {
        //                MessageBox.Show("لا توجد خصومات للفترة المحددة");
        //                lblTotalDeduction.Text = "إجمالي الخصومات المتوقعة: 0.00 ريال";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("خطأ في إنشاء التقرير: " + ex.Message + "\n\nتفاصيل الخطأ: " + ex.StackTrace);
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();
        //    }
        //}

    }
}
