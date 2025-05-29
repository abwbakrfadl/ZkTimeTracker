using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class WorkingDaysForm : Form
    {
        //private string connectionString = "Server=your_server_name;Database=your_database_name;User Id=your_user_id;Password=your_password;";

        public WorkingDaysForm()
        {
            InitializeComponent();
            LoadWorkingDays();
            InitializeDaysOfWeek();
            InitializeComp();
        }
        private void InitializeComp()
        {
            dgvWorkingDays.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvWorkingDays.Rows.Count)
                    return;

                var row = dgvWorkingDays.Rows[e.RowIndex];
                cmbDayOfWeek.Text = row.Cells["ConditionName"].Value?.ToString() ?? "";
               
            };
        }

        private void InitializeDaysOfWeek()
        {
            // ملء ComboBox بأيام الأسبوع
            cmbDayOfWeek.Items.AddRange(new string[] { "الأحد", "الاثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" });
        }

        private void LoadWorkingDays()
        {
          

            
                try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DayOfWeek FROM WorkingDays";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dgvWorkingDays.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل أيام الدوام: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDayOfWeek.Text))
            {
                MessageBox.Show("يرجى اختيار يوم.");
                return;
            }

            try
            {
                string selectedDay = cmbDayOfWeek.Text;

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        IF NOT EXISTS (SELECT 1 FROM WorkingDays WHERE DayOfWeek = @DayOfWeek)
                        BEGIN
                            INSERT INTO WorkingDays (DayOfWeek) VALUES (@DayOfWeek)
                        END";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DayOfWeek", selectedDay);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("تمت إضافة يوم الدوام بنجاح!");
                    }
                    else
                    {
                        MessageBox.Show("هذا اليوم موجود بالفعل في أيام الدوام.");
                    }
                }

                LoadWorkingDays(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إضافة يوم الدوام: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWorkingDays.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد يوم لحذفه.");
                return;
            }

            try
            {
                string selectedDay = dgvWorkingDays.SelectedRows[0].Cells["DayOfWeek"].Value.ToString();

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM WorkingDays WHERE DayOfWeek = @DayOfWeek";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DayOfWeek", selectedDay);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم حذف يوم الدوام بنجاح!");
                LoadWorkingDays(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف يوم الدوام: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWorkingDays();
        }
    }
}