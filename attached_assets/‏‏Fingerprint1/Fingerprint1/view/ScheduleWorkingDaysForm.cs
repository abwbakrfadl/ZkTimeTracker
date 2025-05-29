using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class ScheduleWorkingDaysForm : Form
    {
       // private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

        // عناصر الواجهة
        private ComboBox cmbSchedule;
        private CheckedListBox clbDays;
        private Button btnSave, btnRefresh;

        public ScheduleWorkingDaysForm()
        {
            InitializeComponent();
            InitializeUI();
            LoadSchedules();
            LoadDays();
        }

        private void InitializeUI()
        {
            this.Text = "إدارة أيام الجداول الزمنية";
            this.Size = new System.Drawing.Size(600, 400);

            // ComboBox لاختيار الجدول الزمني
            cmbSchedule = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbSchedule.SelectedIndexChanged += CmbSchedule_SelectedIndexChanged;
            this.Controls.Add(cmbSchedule);

            // CheckedListBox لأيام الأسبوع
            clbDays = new CheckedListBox
            {
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(200, 200)
            };
            this.Controls.Add(clbDays);

            // زر حفظ التغييرات
            btnSave = new Button
            {
                Text = "حفظ",
                Location = new System.Drawing.Point(250, 300),
                Width = 100
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // زر تحديث البيانات
            btnRefresh = new Button
            {
                Text = "تحديث",
                Location = new System.Drawing.Point(370, 300),
                Width = 100
            };
            btnRefresh.Click += BtnRefresh_Click;
            this.Controls.Add(btnRefresh);
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
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cmbSchedule.Items.Add(new { ID = reader["ScheduleID"], Name = reader["ScheduleName"] });
                    cmbSchedule.DisplayMember = "Name";
                    cmbSchedule.ValueMember = "ID";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء تحميل الجداول الزمنية: {ex.Message}");
        }
    }
    private void LoadDays()
    {
        try
        {
            clbDays.Items.Clear();
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DayOfWeek FROM WorkingDays";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    clbDays.Items.Add(reader["DayOfWeek"].ToString(), false);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء تحميل الأيام الأسبوعية: {ex.Message}");
        }
    }
    private void CmbSchedule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbSchedule.SelectedItem == null) return;

        var selectedSchedule = (dynamic)cmbSchedule.SelectedItem;
        int scheduleID = selectedSchedule.ID;

        try
        {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT DayOfWeek FROM ScheduleWorkingDays WHERE ScheduleID = @ScheduleID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ScheduleID", scheduleID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string dayOfWeek = reader["DayOfWeek"].ToString();
                    for (int i = 0; i < clbDays.Items.Count; i++)
                    {
                        if (clbDays.Items[i].ToString() == dayOfWeek)
                        {
                            clbDays.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء تحميل الأيام المرتبطة بالجدول الزمني: {ex.Message}");
        }
    }
    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (cmbSchedule.SelectedItem == null)
        {
            MessageBox.Show("يرجى تحديد جدول زمني.");
            return;
        }

        var selectedSchedule = (dynamic)cmbSchedule.SelectedItem;
        int scheduleID = selectedSchedule.ID;

        try
        {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                // حذف الأيام القديمة
                string deleteQuery = "DELETE FROM ScheduleWorkingDays WHERE ScheduleID = @ScheduleID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@ScheduleID", scheduleID);
                deleteCommand.ExecuteNonQuery();

                // إضافة الأيام الجديدة
                foreach (var item in clbDays.CheckedItems)
                {
                    string dayOfWeek = item.ToString();
                    string insertQuery = "INSERT INTO ScheduleWorkingDays (ScheduleID, DayOfWeek) VALUES (@ScheduleID, @DayOfWeek)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@ScheduleID", scheduleID);
                    insertCommand.Parameters.AddWithValue("@DayOfWeek", dayOfWeek);
                    insertCommand.ExecuteNonQuery();
                }
            }

            MessageBox.Show("تم حفظ التغييرات بنجاح!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء حفظ التغييرات: {ex.Message}");
        }
    }
    private void BtnRefresh_Click(object sender, EventArgs e)
    {
        LoadSchedules();
        LoadDays();
        MessageBox.Show("تم تحديث البيانات بنجاح!");
    }
}}