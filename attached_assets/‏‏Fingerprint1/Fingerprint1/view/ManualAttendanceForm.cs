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
    
        public partial class ManualAttendanceForm : Form
        {
            public ManualAttendanceForm()
            {
                InitializeComponent();
            LoadEmployees();
            }

            private void ManualAttendanceForm_Load(object sender, EventArgs e)
            {
                cmbInOutMode.Items.AddRange(new object[] { "دخول", "خروج" });
                cmbVerificationMode.Items.AddRange(new object[] { "افتراضي", "بصمة", "بطاقة", "بصمة + بطاقة", "بصمة أو بطاقة" });

                cmbInOutMode.SelectedIndex = 0;
                cmbVerificationMode.SelectedIndex = 0;

                dtpDate.Value = DateTime.Now;
                dtpTime.Value = DateTime.Now;
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
            private void btnSave_Click(object sender, EventArgs e)
            {
            object selectedUserID = cmbEmployees.SelectedValue;
            if (selectedUserID == DBNull.Value) // إذا كان الخيار "جميع الموظفين"
            {
                selectedUserID = DBNull.Value; // تمرير NULL إلى الاستعلام
            }
            string userID = selectedUserID.ToString();
            DateTime date = dtpDate.Value.Date;
                DateTime time = dtpTime.Value;
                DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                int inOutMode = cmbInOutMode.SelectedIndex;
                int verificationMode = cmbVerificationMode.SelectedIndex;

                if (string.IsNullOrWhiteSpace(userID))
                {
                    MessageBox.Show("الرجاء إدخال رقم الموظف");
                    return;
                }

                try
                {
                    InsertAttendanceToDatabase(userID, dateTime, verificationMode, inOutMode);
                    MessageBox.Show("تم حفظ الحضور بنجاح");
                    //this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ أثناء الحفظ: {ex.Message}");
                }
            }
        //private void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbEmployees.SelectedIndex == 0) // الكل
        //    {
        //        LoadEmployeeIds();
        //        btnPrevious.Enabled = true;
        //        btnNext.Enabled = true;
        //        currentEmployeeIndex = 0;
        //        LoadReportForCurrentEmployee();
        //    }
        //    else
        //    {
        //        btnPrevious.Enabled = false;
        //        btnNext.Enabled = false;
        //        // /*LoadMonthlyReport*/();
        //    }
        //}
        private void InsertAttendanceToDatabase(string userID, DateTime dateTime, int verifyMode, int inOutMode)
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Attendance (UserID, DateTime, VerificationMode, InOutMode) 
                                 VALUES (@UserID, @DateTime, @VerificationMode, @InOutMode)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@DateTime", dateTime);
                    command.Parameters.AddWithValue("@VerificationMode", verifyMode);
                    command.Parameters.AddWithValue("@InOutMode", inOutMode);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        
    }
    }




