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
    public partial class BonusForm : Form
    {
       // private SqlConnection conn;
        //private DataGridView dgvBonus;
        //private ComboBox cmbEmployees;
        //private NumericUpDown numBonusAmount;
        //private DateTimePicker dtpStartDate;
        //private DateTimePicker dtpEndDate;
        //private CheckBox chkIsActive;
        //private TextBox txtBonusNotes;
        //private Button btnAdd;
        //private Button btnUpdate;
        //private Button btnDelete;
        //private Button btnClear;

        public BonusForm()
        {
            InitializeComponent();
          //  conn = new SqlConnection(@"Server=DESKTOP-3F7NFV1\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True");
            InitializeForm();
            LoadEmployees();
            LoadBonuses();
        }

        private void InitializeForm()
        {
            this.Text = "إدارة المكافآت";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // إنشاء لوحة الإدخال
            TableLayoutPanel inputPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 200,
                ColumnCount = 2,
                RowCount = 6,
                Padding = new Padding(10)
            };

            // إنشاء عناصر التحكم
            cmbEmployees = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            numBonusAmount = new NumericUpDown { Dock = DockStyle.Fill, Maximum = 100000, DecimalPlaces = 2 };
            dtpStartDate = new DateTimePicker { Dock = DockStyle.Fill };
            dtpEndDate = new DateTimePicker { Dock = DockStyle.Fill };
            chkIsActive = new CheckBox { Text = "مفعل", Checked = true };
            txtBonusNotes = new TextBox { Dock = DockStyle.Fill, Multiline = true };

            // إضافة العناصر إلى اللوحة
            int row = 0;
            AddControlWithLabel(inputPanel, "الموظف:", cmbEmployees, row++);
            AddControlWithLabel(inputPanel, "مبلغ المكافأة:", numBonusAmount, row++);
            AddControlWithLabel(inputPanel, "تاريخ البداية:", dtpStartDate, row++);
            AddControlWithLabel(inputPanel, "تاريخ النهاية:", dtpEndDate, row++);
            AddControlWithLabel(inputPanel, "", chkIsActive, row++);
            AddControlWithLabel(inputPanel, "ملاحظات:", txtBonusNotes, row++);

            // إنشاء لوحة الأزرار
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 40,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10)
            };

            btnAdd = new Button { Text = "إضافة", Width = 100 };
            btnUpdate = new Button { Text = "تحديث", Width = 100, Enabled = false };
            btnDelete = new Button { Text = "حذف", Width = 100, Enabled = false };
            btnClear = new Button { Text = "تفريغ", Width = 100 };

            buttonPanel.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete, btnClear });

            // إنشاء جدول العرض
            dgvBonus = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                RightToLeft = RightToLeft.Yes
            };

            // إضافة الأحداث
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            dgvBonus.SelectionChanged += DgvBonus_SelectionChanged;

            // إضافة العناصر إلى النموذج
            this.Controls.Add(dgvBonus);
            this.Controls.Add(buttonPanel);
            this.Controls.Add(inputPanel);
        }

        private void AddControlWithLabel(TableLayoutPanel panel, string labelText, Control control, int row)
        {
            if (!string.IsNullOrEmpty(labelText))
            {
                panel.Controls.Add(new Label { Text = labelText, Dock = DockStyle.Fill }, 0, row);
            }
            panel.Controls.Add(control, 1, row);
        }

        private void LoadEmployees()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT UserID, Name FROM Employees WHERE Enabled = 1", connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        cmbEmployees.DisplayMember = "Name";
                        cmbEmployees.ValueMember = "UserID";
                        cmbEmployees.DataSource = dt;
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void LoadBonuses()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"
                SELECT b.BonusID, e.Name AS 'اسم الموظف',
                       b.BonusAmount AS 'المكافأة',
                       b.StartDate AS 'تاريخ البداية',
                       b.EndDate AS 'تاريخ النهاية',
                       b.IsActive AS 'مفعل',
                       b.Notes AS 'ملاحظات'
                FROM EmployeeBonus b
                INNER JOIN Employees e ON b.UserID = e.UserID", connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvBonus.DataSource = dt;
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedValue == null)
            {
                MessageBox.Show("الرجاء اختيار موظف");
                return;
            }
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    using (SqlCommand cmd = new SqlCommand(@"
            INSERT INTO EmployeeBonus (UserID, BonusAmount, StartDate, EndDate, IsActive, Notes)
            VALUES (@UserID, @Amount, @StartDate, @EndDate, @IsActive, @Notes)", connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", cmbEmployees.SelectedValue);
                        cmd.Parameters.AddWithValue("@Amount", numBonusAmount.Value);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                        cmd.Parameters.AddWithValue("@Notes", txtBonusNotes.Text);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت إضافة المكافأة بنجاح");
                        ClearInputs();
                        connection.Close();
                        LoadBonuses();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إضافة المكافأة: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        //private void BtnAdd_Click(object sender, EventArgs e)
        //{
        //    if (cmbEmployees.SelectedValue == null)
        //    {
        //        MessageBox.Show("الرجاء اختيار موظف");
        //        return;
        //    }

        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"
        //        INSERT INTO EmployeeBonus (UserID, BonusAmount, StartDate, EndDate, IsActive, Notes)
        //        VALUES (@UserID, @Amount, @StartDate, @EndDate, @IsActive, @Notes)", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@UserID", cmbEmployees.SelectedValue);
        //            cmd.Parameters.AddWithValue("@Amount", numBonusAmount.Value);
        //            cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
        //            cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
        //            cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
        //            cmd.Parameters.AddWithValue("@Notes", txtBonusNotes.Text);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("تمت إضافة المكافأة بنجاح");
        //            ClearInputs();
        //            LoadBonuses();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("خطأ في إضافة المكافأة: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();
        //    }
        //}

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBonus.SelectedRows.Count == 0) return;
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(@"
                UPDATE EmployeeBonus SET 
                    UserID = @UserID,
                    BonusAmount = @Amount,
                    StartDate = @StartDate,
                    EndDate = @EndDate,
                    IsActive = @IsActive,
                    Notes = @Notes
                WHERE BonusID = @BonusID", connection))
                    {
                        cmd.Parameters.AddWithValue("@BonusID", dgvBonus.SelectedRows[0].Cells["BonusID"].Value);
                        cmd.Parameters.AddWithValue("@UserID", cmbEmployees.SelectedValue);
                        cmd.Parameters.AddWithValue("@Amount", numBonusAmount.Value);
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                        cmd.Parameters.AddWithValue("@Notes", txtBonusNotes.Text);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم تحديث المكافأة بنجاح");
                        ClearInputs();
                        connection.Close();
                        LoadBonuses();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحديث المكافأة: " + ex.Message);
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
            if (dgvBonus.SelectedRows.Count == 0) return;

            if (MessageBox.Show("هل أنت متأكد من حذف هذه المكافأة؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {

                        using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM EmployeeBonus WHERE BonusID = @BonusID", connection))
                        {
                            cmd.Parameters.AddWithValue("@BonusID",
                                dgvBonus.SelectedRows[0].Cells["BonusID"].Value);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("تم حذف المكافأة بنجاح");
                            ClearInputs();
                            connection.Close();
                            LoadBonuses();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("خطأ في حذف المكافأة: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void DgvBonus_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBonus.SelectedRows.Count > 0)
            {
                var row = dgvBonus.SelectedRows[0];
                cmbEmployees.Text = row.Cells["اسم الموظف"].Value.ToString();
                numBonusAmount.Value = Convert.ToDecimal(row.Cells["المكافأة"].Value);
                dtpStartDate.Value = Convert.ToDateTime(row.Cells["تاريخ البداية"].Value);
                if (row.Cells["تاريخ النهاية"].Value != DBNull.Value)
                    dtpEndDate.Value = Convert.ToDateTime(row.Cells["تاريخ النهاية"].Value);
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["مفعل"].Value);
                txtBonusNotes.Text = row.Cells["ملاحظات"].Value?.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void ClearInputs()
        {
            cmbEmployees.SelectedIndex = -1;
            numBonusAmount.Value = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            chkIsActive.Checked = true;
            txtBonusNotes.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
