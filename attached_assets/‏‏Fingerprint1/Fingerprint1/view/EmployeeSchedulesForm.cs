using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class EmployeeSchedulesForm : Form
    {
        //  private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

        public EmployeeSchedulesForm()
        {
            InitializeComponent();
            LoadEmployeeSchedules();
            LoadEmployees();
            LoadSchedules();
            GridView();
        }
        private void GridView()
        {
            dgvEmployeeSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvEmployeeSchedules.Font = new Font("Arial", 11);
            dgvEmployeeSchedules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //dgvEmployeeSchedules.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvEmployeeSchedules.ReadOnly = true;
            dgvEmployeeSchedules.BackgroundColor = Color.White;
            dgvEmployeeSchedules.BorderStyle = BorderStyle.None;
            dgvEmployeeSchedules.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmployeeSchedules.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEmployeeSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployeeSchedules.Dock = DockStyle.Bottom;
            dgvEmployeeSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployeeSchedules.RightToLeft = RightToLeft.Yes;

            // تنسيق رأس الجدول
            dgvEmployeeSchedules.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvEmployeeSchedules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployeeSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvEmployeeSchedules.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvEmployeeSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvEmployeeSchedules.ColumnHeadersHeight = 40;

            // تنسيق الصفوف
            dgvEmployeeSchedules.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvEmployeeSchedules.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEmployeeSchedules.DefaultCellStyle.Padding = new Padding(5);
            dgvEmployeeSchedules.RowTemplate.Height = 35;
            //dgvReport.Columns[0].Visible = false; // إخفاء العمود الأول
            //dgvReport.Columns[3].Visible = false;
            // تنسيق الصفوف البديلة
            dgvEmployeeSchedules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
        }
        private void LoadEmployeeSchedules()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                        string query = @"
                        SELECT es.EmployeeScheduleID, e.Name AS EmployeeName, s.ScheduleName, s.StartDate, s.EndDate
                        FROM EmployeeSchedules es
                        INNER JOIN Employees e ON es.UserID = e.UserID
                        INNER JOIN Schedules s ON es.ScheduleID = s.ScheduleID";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        var dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);

                        dgvEmployeeSchedules.DataSource = dataTable;
                    }
                }
            
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل العلاقات: {ex.Message}");
            }
        }

        private void LoadEmployees()
        {
           
                try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");

                using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT UserID, Name FROM Employees";
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();

                        clbEmployees.Items.Clear();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clbEmployees.Items.Add(new { UserID = reader["UserID"], Name = reader["Name"] });
                            }
                        }
                    }

                    clbEmployees.DisplayMember = "Name";
                    clbEmployees.ValueMember = "UserID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء تحميل الموظفين: {ex.Message}");
                }
            
        }

        private void LoadSchedules()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                        string query = "SELECT ScheduleID, ScheduleName FROM Schedules";
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();

                        cmbSchedules.Items.Clear();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbSchedules.Items.Add(new { ScheduleID = reader["ScheduleID"], ScheduleName = reader["ScheduleName"] });
                            }
                        }
                    }

                    cmbSchedules.DisplayMember = "ScheduleName";
                    cmbSchedules.ValueMember = "ScheduleID";
                }
            
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الورديات: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbSchedules.SelectedItem == null || clbEmployees.CheckedItems.Count == 0)
            {
                MessageBox.Show("يرجى اختيار وردية وواحد أو أكثر من الموظفين.");
                return;
            }

            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var selectedSchedule = (dynamic)cmbSchedules.SelectedItem;

                   
                        connection.Open();

                        foreach (var item in clbEmployees.CheckedItems)
                        {
                            var selectedEmployee = (dynamic)item;

                            string query = @"
                            INSERT INTO EmployeeSchedules (UserID, ScheduleID)
                            VALUES (@UserID, @ScheduleID)";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@UserID", selectedEmployee.UserID);
                            command.Parameters.AddWithValue("@ScheduleID", selectedSchedule.ScheduleID);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("تمت إضافة العلاقات بنجاح!");
                    LoadEmployeeSchedules(); // تحديث الجدول
                }
            
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إضافة العلاقات: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployeeSchedules.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد علاقة لحذفها.");
                return;
            }

            try
            {
                int employeeScheduleID = Convert.ToInt32(dgvEmployeeSchedules.SelectedRows[0].Cells["EmployeeScheduleID"].Value);
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                  
                    string query = "DELETE FROM EmployeeSchedules WHERE EmployeeScheduleID = @EmployeeScheduleID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeScheduleID", employeeScheduleID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم حذف العلاقة بنجاح!");
                LoadEmployeeSchedules(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف العلاقة: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployeeSchedules();
        }

        
    }
}