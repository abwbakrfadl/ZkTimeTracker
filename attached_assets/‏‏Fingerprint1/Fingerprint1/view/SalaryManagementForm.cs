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
    public partial class SalaryManagementForm : Form
    {
      //  private SqlConnection conn;
        private DataGridView dgvSalaries;
        private ComboBox cboEmployees;
        private NumericUpDown nudBasicSalary;
        private NumericUpDown nudBonus;
        private DateTimePicker dtpEffectiveDate;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;

        public SalaryManagementForm()
        {
            InitializeComponent();
        //    conn = new SqlConnection("Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;");
            InitializeControls();
            ClearInputs(); // إضافة هذا السطر هنا
            LoadSalaryData();
        }

        private void InitializeControls()
        {
            this.Text = "إدارة الرواتب";
            this.RightToLeft = RightToLeft.Yes;
            this.Size = new Size(800, 600);

            // إنشاء لوحة للعناصر
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 120,
                ColumnCount = 3,
                RowCount = 3,
                Padding = new Padding(10)
            };

            // إضافة العناصر
            Label lblEmployee = new Label { Text = "الموظف:", Dock = DockStyle.Fill };
            cboEmployees = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Label lblSalary = new Label { Text = "الراتب الأساسي:", Dock = DockStyle.Fill };
            nudBasicSalary = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 2,
                Dock = DockStyle.Fill
            };

            Label lblBonus = new Label { Text = "المكافأة:", Dock = DockStyle.Fill };
            nudBonus = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 2,
                Dock = DockStyle.Fill
            };

            Label lblDate = new Label { Text = "تاريخ السريان:", Dock = DockStyle.Fill };
            dtpEffectiveDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Dock = DockStyle.Fill
            };

             FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 40,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                RightToLeft = RightToLeft.Yes
            };
            cboEmployees = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                SelectedIndex = -1  // إضافة هذا السطر
            };

            nudBasicSalary = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 2,
                Value = 0,  // تأكيد أن القيمة الابتدائية صفر
                Dock = DockStyle.Fill
            };

            nudBonus = new NumericUpDown
            {
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 2,
                Value = 0,  // تأكيد أن القيمة الابتدائية صفر
                Dock = DockStyle.Fill
            };
            btnSave = new Button { Text = "حفظ", Width = 100, RightToLeft = RightToLeft.Yes };
            btnUpdate = new Button { Text = "تعديل", Width = 100, RightToLeft = RightToLeft.Yes };
            btnDelete = new Button { Text = "حذف", Width = 100, RightToLeft = RightToLeft.Yes };

            // إضافة الأزرار بالترتيب المطلوب
            //buttonPanel.Controls.AddRange(new Control[] { btnSave, btnUpdate, btnDelete });

            btnSave.Click += BtnSave_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;

            buttonPanel.Controls.AddRange(new Control[] { btnSave, btnUpdate, btnDelete });

            // إضافة جدول عرض البيانات
            dgvSalaries = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvSalaries.SelectionChanged += DgvSalaries_SelectionChanged;

            // إضافة العناصر للوحة
            panel.Controls.Add(lblEmployee, 0, 0);
            panel.Controls.Add(cboEmployees, 1, 0);
            panel.Controls.Add(lblSalary, 0, 1);
            panel.Controls.Add(nudBasicSalary, 1, 1);
            panel.Controls.Add(lblBonus, 0, 2);
            panel.Controls.Add(nudBonus, 1, 2);
            panel.Controls.Add(lblDate, 2, 0);
            panel.Controls.Add(dtpEffectiveDate, 2, 1);

            // إضافة العناصر للنموذج
            this.Controls.Add(dgvSalaries);
            this.Controls.Add(buttonPanel);
            this.Controls.Add(panel);


            LoadEmployees();
            cboEmployees.SelectedIndex = -1; 
        }

        private void LoadEmployees()
        {

            string query = "SELECT UserID, Name FROM Employees WHERE Enabled = 1";
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboEmployees.DataSource = dt;
                    cboEmployees.DisplayMember = "Name";
                    cboEmployees.ValueMember = "UserID";

                }

                ClearInputs();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (cboEmployees.SelectedValue == null)
                    {
                        MessageBox.Show("الرجاء اختيار موظف");
                        return;
                    }

                    connection.Open();  // فتح الاتصال
                    SaveSalary(
                        cboEmployees.SelectedValue.ToString(),
                        nudBasicSalary.Value,
                        nudBonus.Value,
                        dtpEffectiveDate.Value
                    );
                    connection.Close();  // إغلاق الاتصال

                    LoadSalaryData();
                    ClearInputs();
                    MessageBox.Show("تم الحفظ بنجاح");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();  // التأكد من إغلاق الاتصال في حالة حدوث خطأ
                }
            }
        }

        private void LoadSalaryData()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();  // فتح الاتصال
                    string query = @"
            SELECT 
                e.Name AS 'اسم الموظف',
                es.BasicSalary AS 'الراتب الأساسي',
                es.Bonus AS 'المكافأة',
                es.EffectiveDate AS 'تاريخ السريان',
                es.IsActive AS 'نشط',
                e.UserID,
                es.SalaryID
            FROM EmployeeSalary es
            INNER JOIN Employees e ON e.UserID = es.UserID
            ORDER BY es.EffectiveDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSalaries.DataSource = dt;

                        dgvSalaries.Columns["UserID"].Visible = false;
                        dgvSalaries.Columns["SalaryID"].Visible = false;
                    }
                }
                finally
                {
                    connection.Close();  // إغلاق الاتصال
                }
            }
        }
        private void SaveSalary(string userId, decimal basicSalary, decimal bonus, DateTime effectiveDate)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    string query = @"
            UPDATE EmployeeSalary 
            SET IsActive = 0 
            WHERE UserID = @UserID AND IsActive = 1;

            INSERT INTO EmployeeSalary (UserID, BasicSalary, Bonus, EffectiveDate, IsActive)
            VALUES (@UserID, @BasicSalary, @Bonus, @EffectiveDate, 1)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@BasicSalary", basicSalary);
                        cmd.Parameters.AddWithValue("@Bonus", bonus);
                        cmd.Parameters.AddWithValue("@EffectiveDate", effectiveDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error saving salary: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (dgvSalaries.CurrentRow == null)
                    {
                        MessageBox.Show("الرجاء اختيار سجل للتعديل");
                        return;
                    }

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    int salaryId = Convert.ToInt32(dgvSalaries.CurrentRow.Cells["SalaryID"].Value);
                    string query = @"
            UPDATE EmployeeSalary 
            SET BasicSalary = @BasicSalary,
                Bonus = @Bonus,
                EffectiveDate = @EffectiveDate
            WHERE SalaryID = @SalaryID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@SalaryID", salaryId);
                        cmd.Parameters.AddWithValue("@BasicSalary", nudBasicSalary.Value);
                        cmd.Parameters.AddWithValue("@Bonus", nudBonus.Value);
                        cmd.Parameters.AddWithValue("@EffectiveDate", dtpEffectiveDate.Value);
                        cmd.ExecuteNonQuery();
                    }

                    LoadSalaryData();
                    ClearInputs();
                    MessageBox.Show("تم التعديل بنجاح");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (dgvSalaries.CurrentRow == null)
                    {
                        MessageBox.Show("الرجاء اختيار سجل للحذف");
                        return;
                    }

                    if (MessageBox.Show("هل أنت متأكد من حذف هذا السجل؟", "تأكيد الحذف",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    int salaryId = Convert.ToInt32(dgvSalaries.CurrentRow.Cells["SalaryID"].Value);
                    string query = "DELETE FROM EmployeeSalary WHERE SalaryID = @SalaryID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@SalaryID", salaryId);
                        cmd.ExecuteNonQuery();
                    }

                    LoadSalaryData();
                    ClearInputs();
                    MessageBox.Show("تم الحذف بنجاح");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void ClearInputs()
        {
            cboEmployees.SelectedIndex = -1;
            nudBasicSalary.Value = 0;
            nudBonus.Value = 0;
            dtpEffectiveDate.Value = DateTime.Now;
        }


        private void DgvSalaries_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalaries.CurrentRow != null)
            {
                cboEmployees.SelectedValue = dgvSalaries.CurrentRow.Cells["UserID"].Value;
                nudBasicSalary.Value = Convert.ToDecimal(dgvSalaries.CurrentRow.Cells["الراتب الأساسي"].Value);
                nudBonus.Value = Convert.ToDecimal(dgvSalaries.CurrentRow.Cells["المكافأة"].Value);
                dtpEffectiveDate.Value = Convert.ToDateTime(dgvSalaries.CurrentRow.Cells["تاريخ السريان"].Value);
            }
        }
    }
}
