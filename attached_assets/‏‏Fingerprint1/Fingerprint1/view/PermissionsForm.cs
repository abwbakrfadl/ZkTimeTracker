using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class PermissionsForm : Form
    {
       // private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

        public PermissionsForm()
        {
            InitializeComponent();
            LoadPermissions();
            LoadEmployees();
            InitializeStatus();
            GridView();
        }
        private void GridView()
        {
            dgvPermissions.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvPermissions.Font = new Font("Arial", 11);
            dgvPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //dgvPermissions.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvPermissions.ReadOnly = true;
            dgvPermissions.BackgroundColor = Color.White;
            dgvPermissions.BorderStyle = BorderStyle.None;
            dgvPermissions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPermissions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermissions.Dock = DockStyle.Bottom;
            dgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPermissions.RightToLeft = RightToLeft.Yes;

            // تنسيق رأس الجدول
            dgvPermissions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvPermissions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPermissions.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvPermissions.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPermissions.ColumnHeadersHeight = 40;

            // تنسيق الصفوف
            dgvPermissions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvPermissions.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPermissions.DefaultCellStyle.Padding = new Padding(5);
            dgvPermissions.RowTemplate.Height = 35;
            //dgvReport.Columns[0].Visible = false; // إخفاء العمود الأول
            //dgvReport.Columns[3].Visible = false;
            // تنسيق الصفوف البديلة
            dgvPermissions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
        }

        private void LoadPermissions()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
           
                try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT p.PermissionID, e.Name AS EmployeeName, p.PermissionDate, p.StartTime, p.EndTime, p.Reason, p.Status
                        FROM Permissions p
                        INNER JOIN Employees e ON p.UserID = e.UserID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dgvPermissions.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الأذونات: {ex.Message}");
            }
        }

        private void LoadEmployees()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            try
            {
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

        private void InitializeStatus()
        {
            // ملء ComboBox بحالات الإذن
            cmbStatus.Items.AddRange(new string[] { "مقبول", "مرفوض", "قيد المراجعة" });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            if (cmbEmployees.SelectedItem == null || string.IsNullOrEmpty(txtPermissionDate.Text) ||
                string.IsNullOrEmpty(txtStartTime.Text) || string.IsNullOrEmpty(txtEndTime.Text) ||
                string.IsNullOrEmpty(txtReason.Text) || string.IsNullOrEmpty(cmbStatus.Text))
            {
                MessageBox.Show("يرجى ملء جميع الحقول.");
                return;
            }

            try
            {
                var selectedEmployee = (dynamic)cmbEmployees.SelectedItem;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Permissions (UserID, PermissionDate, StartTime, EndTime, Reason, Status)
                        VALUES (@UserID, @PermissionDate, @StartTime, @EndTime, @Reason, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", selectedEmployee.UserID);
                    command.Parameters.AddWithValue("@PermissionDate", DateTime.Parse(txtPermissionDate.Text));
                    command.Parameters.AddWithValue("@StartTime", TimeSpan.Parse(txtStartTime.Text));
                    command.Parameters.AddWithValue("@EndTime", TimeSpan.Parse(txtEndTime.Text));
                    command.Parameters.AddWithValue("@Reason", txtReason.Text);
                    command.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تمت إضافة الإذن بنجاح!");
                LoadPermissions(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إضافة الإذن: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            if (dgvPermissions.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد إذن لتعديله.");
                return;
            }

            if (cmbEmployees.SelectedItem == null || string.IsNullOrEmpty(txtPermissionDate.Text) ||
                string.IsNullOrEmpty(txtStartTime.Text) || string.IsNullOrEmpty(txtEndTime.Text) ||
                string.IsNullOrEmpty(txtReason.Text) || string.IsNullOrEmpty(cmbStatus.Text))
            {
                MessageBox.Show("يرجى ملء جميع الحقول.");
                return;
            }

            try
            {
                var selectedEmployee = (dynamic)cmbEmployees.SelectedItem;
                int permissionID = Convert.ToInt32(dgvPermissions.SelectedRows[0].Cells["PermissionID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Permissions
                        SET UserID = @UserID,
                            PermissionDate = @PermissionDate,
                            StartTime = @StartTime,
                            EndTime = @EndTime,
                            Reason = @Reason,
                            Status = @Status
                        WHERE PermissionID = @PermissionID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PermissionID", permissionID);
                    command.Parameters.AddWithValue("@UserID", selectedEmployee.UserID);
                    command.Parameters.AddWithValue("@PermissionDate", DateTime.Parse(txtPermissionDate.Text));
                    command.Parameters.AddWithValue("@StartTime", TimeSpan.Parse(txtStartTime.Text));
                    command.Parameters.AddWithValue("@EndTime", TimeSpan.Parse(txtEndTime.Text));
                    command.Parameters.AddWithValue("@Reason", txtReason.Text);
                    command.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم تحديث الإذن بنجاح!");
                LoadPermissions(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث الإذن: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            if (dgvPermissions.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد إذن لحذفه.");
                return;
            }

            try
            {
                int permissionID = Convert.ToInt32(dgvPermissions.SelectedRows[0].Cells["PermissionID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Permissions WHERE PermissionID = @PermissionID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PermissionID", permissionID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم حذف الإذن بنجاح!");
                LoadPermissions(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف الإذن: {ex.Message}");
            }
        }

        private void dgvPermissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPermissions();
        }
    }
}