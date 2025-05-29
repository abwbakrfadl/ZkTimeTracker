using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class HolidaysForm : Form
    {
      //  private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

        public HolidaysForm()
        {
            InitializeComponent();
            LoadHolidays();
            GridView();
        }
        private void GridView()
        {
            dgvHolidays.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvHolidays.Font = new Font("Arial", 11);
            dgvHolidays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //dgvHolidays.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvHolidays.ReadOnly = true;
            dgvHolidays.BackgroundColor = Color.White;
            dgvHolidays.BorderStyle = BorderStyle.None;
            dgvHolidays.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHolidays.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHolidays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHolidays.Dock = DockStyle.Bottom;
            dgvHolidays.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHolidays.RightToLeft = RightToLeft.Yes;

            // تنسيق رأس الجدول
            dgvHolidays.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvHolidays.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHolidays.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvHolidays.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvHolidays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvHolidays.ColumnHeadersHeight = 40;

            // تنسيق الصفوف
            dgvHolidays.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvHolidays.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvHolidays.DefaultCellStyle.Padding = new Padding(5);
            dgvHolidays.RowTemplate.Height = 35;
            //dgvReport.Columns[0].Visible = false; // إخفاء العمود الأول
            //dgvReport.Columns[3].Visible = false;
            // تنسيق الصفوف البديلة
            dgvHolidays.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void LoadHolidays()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                  
                    string query = "SELECT HolidayID, HolidayDate, HolidayName FROM Holidays";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dgvHolidays.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل أيام العطل: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHolidayDate.Text) || string.IsNullOrEmpty(txtHolidayName.Text))
            {
                MessageBox.Show("يرجى إدخال تاريخ واسم العطلة.");
                return;
            }

            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Holidays (HolidayDate, HolidayName)
                        VALUES (@HolidayDate, @HolidayName)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HolidayDate", DateTime.Parse(txtHolidayDate.Text));
                    command.Parameters.AddWithValue("@HolidayName", txtHolidayName.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تمت إضافة العطلة بنجاح!");
                LoadHolidays(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إضافة العطلة: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvHolidays.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد عطلة لتعديلها.");
                return;
            }

            if (string.IsNullOrEmpty(txtHolidayDate.Text) || string.IsNullOrEmpty(txtHolidayName.Text))
            {
                MessageBox.Show("يرجى إدخال تاريخ واسم العطلة.");
                return;
            }

            try
            {
                int holidayID = Convert.ToInt32(dgvHolidays.SelectedRows[0].Cells["HolidayID"].Value);

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Holidays
                        SET HolidayDate = @HolidayDate,
                            HolidayName = @HolidayName
                        WHERE HolidayID = @HolidayID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HolidayID", holidayID);
                    command.Parameters.AddWithValue("@HolidayDate", DateTime.Parse(txtHolidayDate.Text));
                    command.Parameters.AddWithValue("@HolidayName", txtHolidayName.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم تحديث العطلة بنجاح!");
                LoadHolidays(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث العطلة: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHolidays.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد عطلة لحذفها.");
                return;
            }

            try
            {
                int holidayID = Convert.ToInt32(dgvHolidays.SelectedRows[0].Cells["HolidayID"].Value);

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Holidays WHERE HolidayID = @HolidayID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@HolidayID", holidayID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم حذف العطلة بنجاح!");
                LoadHolidays(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف العطلة: {ex.Message}");
            }
        }

        private void dgvHolidays_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHolidays();
        }
    }
}