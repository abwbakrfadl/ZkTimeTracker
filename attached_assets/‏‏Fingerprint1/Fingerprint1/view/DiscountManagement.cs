using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class DiscountManagement : Form
    {
      //  private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private BindingSource bindingSource;
        //private DataGridView dataGridView;
        //private TextBox txtConditionName;
        //private TextBox txtDiscountAmount;
        //private Button btnAdd, btnUpdate;

        public DiscountManagement()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
           
            LoadData();
            StyleDataGridView(dataGridView);
            txtConditionName.Enabled = false;
            InitializeButtonStates();
        }

        private void InitializeDatabaseConnection()
        {
            // تغيير Connection String حسب إعداداتك
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
           
            }

        private void LoadData()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    dataAdapter = new SqlDataAdapter("SELECT * FROM Discounts", connection);
                    dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    bindingSource = new BindingSource(dataTable, "");
                    dataGridView.DataSource = bindingSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}");
            }
        }
        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RightToLeft = RightToLeft.Yes;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(87, 87, 178);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Cairo", 10);

            // Header Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Cairo", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 50;

            // Alternating Row Colors
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 250);
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5);
            dgv.RowTemplate.Height = 40;

            // Border Style
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(240, 240, 240);

            // Selection Style
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Scrollbar Style
            dgv.ScrollBars = ScrollBars.Both;
        }
       
        
        private void InitializeButtonStates()
        {
            // التحقق مما إذا كانت البيانات موجودة بالفعل في الجدول
            bool dataExists = CheckIfDataExists();

            if (dataExists)
            {
                btnCreateData.Enabled = false; // تعطيل زر "إنشاء البيانات"
                btnDeleteData.Enabled = true;  // تفعيل زر "حذف البيانات"
            }
            else
            {
                btnCreateData.Enabled = true;  // تفعيل زر "إنشاء البيانات"
                btnDeleteData.Enabled = false; // تعطيل زر "حذف البيانات"
            }
        }

        private bool CheckIfDataExists()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Discounts";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        private void ClearInputs()
        {
            txtConditionName.Clear();
            txtDiscountAmount.Clear();
        }

        private void gunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView.Rows.Count)
                return;

            var row = dataGridView.Rows[e.RowIndex];
            txtConditionName.Text = row.Cells["ConditionName"].Value?.ToString() ?? "";
            txtDiscountAmount.Text = row.Cells["DiscountAmount"].Value?.ToString() ?? "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى اختيار سجل لتعديله!");
                return;
            }

            var selectedRow = dataGridView.SelectedRows[0];
            int discountId = (int)selectedRow.Cells["DiscountID"].Value;
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(
                        "UPDATE Discounts SET ConditionName = @ConditionName, DiscountAmount = @DiscountAmount WHERE DiscountID = @DiscountID",
                        connection);
                    command.Parameters.AddWithValue("@ConditionName", txtConditionName.Text);
                    command.Parameters.AddWithValue("@DiscountAmount", decimal.Parse(txtDiscountAmount.Text));
                    command.Parameters.AddWithValue("@DiscountID", discountId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    LoadData();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"خطأ: {ex.Message}");
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = @"
                        INSERT INTO Discounts (ConditionName, DiscountAmount)
                        VALUES
                        ('غائب', '0.00'),
                        ('حضور متاخر بدون انصراف', '0.00'),
                        ('حضور بدون انصراف', '0.00'),
                        ('حضور متاخر', '0.00'),
                        ('انصراف مبكر', '0.00'),
                        ('حاضر', '0.00'),
                        ('عطلة رسمية', '0.00'),
                        ('حضور متاخر وانصراف مبكر', '0.00'),
                        ('لم يسجل حضور', '0.00');";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("تم إنشاء البيانات بنجاح!");

                // تعطيل زر "إنشاء البيانات" وتفعيل زر "حذف البيانات"
                btnCreateData.Enabled = false;
                btnDeleteData.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Discounts";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("تم حذف البيانات بنجاح!");

                // تعطيل زر "حذف البيانات" وتفعيل زر "إنشاء البيانات"
                btnCreateData.Enabled = true;
                btnDeleteData.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ: {ex.Message}");
            }
        }
    }
}



