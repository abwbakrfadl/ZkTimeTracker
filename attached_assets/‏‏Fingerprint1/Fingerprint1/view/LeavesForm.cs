using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class LeavesForm : Form
    {
       // private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

        public LeavesForm()
        {
            InitializeComponent();
            LoadLeaves();
            LoadEmployees();
            GridView();
        }
        private void GridView()
        {
            dgvLeaves.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvLeaves.Font = new Font("Arial", 11);
            dgvLeaves.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //dgvLeaves.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvLeaves.ReadOnly = true;
            dgvLeaves.BackgroundColor = Color.White;
            dgvLeaves.BorderStyle = BorderStyle.None;
            dgvLeaves.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLeaves.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLeaves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeaves.Dock = DockStyle.Bottom;
            dgvLeaves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaves.RightToLeft = RightToLeft.Yes;

            // تنسيق رأس الجدول
            dgvLeaves.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvLeaves.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLeaves.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvLeaves.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvLeaves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLeaves.ColumnHeadersHeight = 40;

            // تنسيق الصفوف
            dgvLeaves.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvLeaves.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLeaves.DefaultCellStyle.Padding = new Padding(5);
            dgvLeaves.RowTemplate.Height = 35;
            //dgvReport.Columns[0].Visible = false; // إخفاء العمود الأول
            //dgvReport.Columns[3].Visible = false;
            // تنسيق الصفوف البديلة
            dgvLeaves.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
        }
        private void LoadLeaves()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT l.LeaveID, e.Name AS EmployeeName, l.LeaveDate, l.LeaveType, l.Reason 
                        FROM Leaves l
                        INNER JOIN Employees e ON l.UserID = e.UserID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dgvLeaves.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الإجازات: {ex.Message}");
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

                    cmbEmployees.Items.Clear();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbEmployees.Items.Add(new { UserID = reader["UserID"], Name = reader["Name"] });
                        }
                    }
                }

                cmbEmployees.DisplayMember = "Name";
                cmbEmployees.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الموظفين: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار موظف.");
                return;
            }

            try
            {
                var selectedEmployee = (dynamic)cmbEmployees.SelectedItem;

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Leaves (UserID, LeaveDate, LeaveType, Reason)
                        VALUES (@UserID, @LeaveDate, @LeaveType, @Reason)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", selectedEmployee.UserID);
                    command.Parameters.AddWithValue("@LeaveDate", DateTime.Parse(txtLeaveDate.Text));
                    command.Parameters.AddWithValue("@LeaveType", txtLeaveType.Text);
                    command.Parameters.AddWithValue("@Reason", txtReason.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تمت إضافة الإجازة بنجاح!");
                LoadLeaves(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إضافة الإجازة: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLeaves.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد إجازة لتعديلها.");
                return;
            }

            if (cmbEmployees.SelectedItem == null)
            {
                MessageBox.Show("يرجى اختيار موظف.");
                return;
            }

            try
            {
                var selectedEmployee = (dynamic)cmbEmployees.SelectedItem;
                int leaveID = Convert.ToInt32(dgvLeaves.SelectedRows[0].Cells["LeaveID"].Value);

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Leaves
                        SET UserID = @UserID,
                            LeaveDate = @LeaveDate,
                            LeaveType = @LeaveType,
                            Reason = @Reason
                        WHERE LeaveID = @LeaveID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LeaveID", leaveID);
                    command.Parameters.AddWithValue("@UserID", selectedEmployee.UserID);
                    command.Parameters.AddWithValue("@LeaveDate", DateTime.Parse(txtLeaveDate.Text));
                    command.Parameters.AddWithValue("@LeaveType", txtLeaveType.Text);
                    command.Parameters.AddWithValue("@Reason", txtReason.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم تحديث الإجازة بنجاح!");
                LoadLeaves(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث الإجازة: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLeaves.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد إجازة لحذفها.");
                return;
            }

            try
            {
                int leaveID = Convert.ToInt32(dgvLeaves.SelectedRows[0].Cells["LeaveID"].Value);

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Leaves WHERE LeaveID = @LeaveID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LeaveID", leaveID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم حذف الإجازة بنجاح!");
                LoadLeaves(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف الإجازة: {ex.Message}");
            }
        }

        private void dgvLeaves_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaves();
        }
    }
}