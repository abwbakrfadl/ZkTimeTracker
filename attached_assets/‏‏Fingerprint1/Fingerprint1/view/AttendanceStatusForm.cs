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
using Fingerprint1;

namespace Fingerprint1.view
{
    public partial class AttendanceStatusForm : Form
    {
       // private SqlConnection conn;
        private DataGridView dgvStatus;
        private TextBox txtStatusName;
        private ComboBox cmbStatusType;
        private NumericUpDown numMinutesFrom;
        private NumericUpDown numMinutesTo;
        private NumericUpDown numDeduction;
        private CheckBox chkUseDeduction;
        private CheckBox chkIsDefault;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private NumericUpDown numDeductionAmount;
        public AttendanceStatusForm()
        {
            InitializeComponent();
            //conn = new SqlConnection(@"Server=DESKTOP-3F7NFV1\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True");
            InitializeForm();
            LoadStatus();
        }

        private void InitializeForm()
        {
            this.Text = "إدارة حالات الحضور والانصراف";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            TableLayoutPanel inputPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 250,
                ColumnCount = 2,
                RowCount = 8,
                Padding = new Padding(10)
            };
            numDeductionAmount = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 10000
            };

            txtStatusName = new TextBox { Dock = DockStyle.Fill };
            cmbStatusType = new ComboBox
            {
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatusType.Items.AddRange(new string[] { "CheckIn", "CheckOut" });

            numMinutesFrom = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = -999,
                Maximum = 999
            };

            numMinutesTo = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = -999,
                Maximum = 999
            };

            numDeduction = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                DecimalPlaces = 2,
                Maximum = 10000
            };


            chkUseDeduction = new CheckBox { Text = "استخدام الخصم", Dock = DockStyle.Fill };
            chkIsDefault = new CheckBox { Text = "حالة افتراضية", Dock = DockStyle.Fill };
            txtDescription = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 50 };

            int row = 0;
            AddControlWithLabel(inputPanel, "اسم الحالة:", txtStatusName, row++);
            AddControlWithLabel(inputPanel, "نوع الحالة:", cmbStatusType, row++);
            AddControlWithLabel(inputPanel, "من الدقيقة:", numMinutesFrom, row++);
            AddControlWithLabel(inputPanel, "إلى الدقيقة:", numMinutesTo, row++);
            AddControlWithLabel(inputPanel, "مبلغ الخصم:", numDeduction, row++);
            AddControlWithLabel(inputPanel, "", chkUseDeduction, row++);
            AddControlWithLabel(inputPanel, "", chkIsDefault, row++);
            AddControlWithLabel(inputPanel, "الوصف:", txtDescription, row++);

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

            dgvStatus = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                RightToLeft = RightToLeft.Yes
            };

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            dgvStatus.SelectionChanged += DgvStatus_SelectionChanged;

            this.Controls.Add(dgvStatus);
            this.Controls.Add(buttonPanel);
            this.Controls.Add(inputPanel);

            Label lblHelp = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = false,
                Height = 120,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9F),
                Text = @"إرشادات ضبط الحالات:
- اسم الحالة: الاسم الذي سيظهر في التقارير (مثال: متأخر، غائب)
- نوع الحالة: CheckIn للحضور، CheckOut للانصراف
- من دقيقة: بداية فترة احتساب الحالة (مثال: 16 تعني بعد 16 دقيقة من وقت الدوام)
- إلى دقيقة: نهاية فترة احتساب الحالة (مثال: 30 تعني حتى 30 دقيقة من وقت الدوام)
- تطبيق الخصم: تفعيل/تعطيل الخصم على هذه الحالة
- مبلغ الخصم: قيمة الخصم المطبق عند تحقق هذه الحالة"
            };
            this.Controls.Add(lblHelp);

            // Add tooltips
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(txtStatusName, "اسم الحالة التي ستظهر في التقارير");
            tooltip.SetToolTip(cmbStatusType, "CheckIn للحضور - CheckOut للانصراف");
            tooltip.SetToolTip(numMinutesFrom, "بداية فترة احتساب الحالة بالدقائق (سالب للانصراف المبكر)");
            tooltip.SetToolTip(numMinutesTo, "نهاية فترة احتساب الحالة بالدقائق (سالب للانصراف المبكر)");
            tooltip.SetToolTip(chkUseDeduction, "تفعيل الخصم على هذه الحالة");
            tooltip.SetToolTip(numDeductionAmount, "مبلغ الخصم المطبق عند تحقق هذه الحالة");
            tooltip.SetToolTip(chkIsDefault, "الحالة الافتراضية عند عدم تحقق أي حالة أخرى");
            tooltip.SetToolTip(txtDescription, "وصف توضيحي للحالة وكيفية تطبيقها");
            AddControlWithLabel(inputPanel, "مبلغ الخصم:", numDeductionAmount, row++);

            // Add example button
            Button btnShowExamples = new Button
            {
                Text = "عرض أمثلة للإعدادات",
                Dock = DockStyle.Top,
                Height = 30
            };
            btnShowExamples.Click += BtnShowExamples_Click;
            this.Controls.Add(btnShowExamples);

            numDeductionAmount = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = 10000,
                Value = 0,
                ThousandsSeparator = true
            };
            
        }
    
        private void BtnShowExamples_Click(object sender, EventArgs e)
        {
            string examples = @"أمثلة لضبط الحالات:

            1. حالة (حاضر):
               - نوع الحالة: CheckIn
               - من دقيقة: -15 (قبل الدوام بـ15 دقيقة)
               - إلى دقيقة: 15 (بعد الدوام بـ15 دقيقة)
               - تطبيق الخصم: لا
               - الحالة الافتراضية: نعم

            2. حالة (متأخر):
               - نوع الحالة: CheckIn
               - من دقيقة: 16
               - إلى دقيقة: 30
               - تطبيق الخصم: نعم
               - مبلغ الخصم: 500

            3. حالة (انصراف مبكر):
               - نوع الحالة: CheckOut
               - من دقيقة: -60 (قبل نهاية الدوام بـ60 دقيقة)
               - إلى دقيقة: -16 (قبل نهاية الدوام بـ16 دقيقة)
               - تطبيق الخصم: نعم
               - مبلغ الخصم: 500

            4. حالة (لم يسجل انصراف):
               - نوع الحالة: CheckOut
               - من دقيقة: (فارغ)
               - إلى دقيقة: (فارغ)
               - تطبيق الخصم: نعم
               - مبلغ الخصم: 2000";

                        MessageBox.Show(examples, "أمثلة لضبط الحالات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
                }

        private void AddControlWithLabel(TableLayoutPanel panel, string labelText, Control control, int row)
        {
            if (!string.IsNullOrEmpty(labelText))
            {
                panel.Controls.Add(new Label { Text = labelText, Dock = DockStyle.Fill }, 0, row);
            }
            panel.Controls.Add(control, 1, row);
        }

        private void LoadStatus()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM AttendanceStatus", connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStatus.DataSource = dt;
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
            if (string.IsNullOrEmpty(txtStatusName.Text) || cmbStatusType.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء إدخال جميع البيانات المطلوبة");
                return;
            }
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO AttendanceStatus (
                    StatusName, StatusType, MinutesFrom, MinutesTo, 
                    DeductionAmount, UseDeduction, IsDefault, Description)
                VALUES (
                    @StatusName, @StatusType, @MinutesFrom, @MinutesTo,
                    @DeductionAmount, @UseDeduction, @IsDefault, @Description)", connection))
                    {
                        AddStatusParameters(cmd);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تمت إضافة الحالة بنجاح");
                        ClearInputs();
                        connection.Close();
                        LoadStatus();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في إضافة الحالة: " + ex.Message);
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
            if (dgvStatus.SelectedRows.Count == 0) return;
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    // Ensure connection is closed before opening
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    using (SqlCommand cmd = new SqlCommand(@"
            UPDATE AttendanceStatus SET 
                StatusName = @StatusName,
                StatusType = @StatusType,
                MinutesFrom = @MinutesFrom,
                MinutesTo = @MinutesTo,
                DeductionAmount = @DeductionAmount,
                UseDeduction = @UseDeduction,
                IsDefault = @IsDefault,
                Description = @Description
            WHERE StatusID = @StatusID", connection))
                    {
                        cmd.Parameters.AddWithValue("@StatusID", dgvStatus.SelectedRows[0].Cells["StatusID"].Value);
                        AddStatusParameters(cmd);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم تحديث الحالة بنجاح");
                        ClearInputs();
                        connection.Close();
                        LoadStatus();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحديث الحالة: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        //private void BtnUpdate_Click(object sender, EventArgs e)
        //{
        //    if (dgvStatus.SelectedRows.Count == 0) return;

        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand(@"
        //        UPDATE AttendanceStatus SET 
        //            StatusName = @StatusName,
        //            StatusType = @StatusType,
        //            MinutesFrom = @MinutesFrom,
        //            MinutesTo = @MinutesTo,
        //            DeductionAmount = @DeductionAmount,
        //            UseDeduction = @UseDeduction,
        //            IsDefault = @IsDefault,
        //            Description = @Description
        //        WHERE StatusID = @StatusID", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@StatusID", dgvStatus.SelectedRows[0].Cells["StatusID"].Value);
        //            AddStatusParameters(cmd);
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("تم تحديث الحالة بنجاح");
        //            ClearInputs();
        //            LoadStatus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("خطأ في تحديث الحالة: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();
        //    }
        //}

        private void AddStatusParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StatusName", txtStatusName.Text);
            cmd.Parameters.AddWithValue("@StatusType", cmbStatusType.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@MinutesFrom", numMinutesFrom.Value);
            cmd.Parameters.AddWithValue("@MinutesTo", numMinutesTo.Value);
            cmd.Parameters.AddWithValue("@DeductionAmount", numDeduction.Value);
            cmd.Parameters.AddWithValue("@UseDeduction", chkUseDeduction.Checked);
            cmd.Parameters.AddWithValue("@IsDefault", chkIsDefault.Checked);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStatus.SelectedRows.Count == 0) return;

            if (MessageBox.Show("هل أنت متأكد من حذف هذه الحالة؟", "تأكيد الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM AttendanceStatus WHERE StatusID = @StatusID", connection))
                        {
                            cmd.Parameters.AddWithValue("@StatusID",
                                dgvStatus.SelectedRows[0].Cells["StatusID"].Value);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("تم حذف الحالة بنجاح");
                            ClearInputs();
                            connection.Close();
                            LoadStatus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطأ في حذف الحالة: " + ex.Message);
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

        private void DgvStatus_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStatus.SelectedRows.Count > 0)
            {
                var row = dgvStatus.SelectedRows[0];
                txtStatusName.Text = row.Cells["StatusName"].Value.ToString();
                cmbStatusType.Text = row.Cells["StatusType"].Value.ToString();
                // ... existing code ...

                // Fix the MinutesFrom conversion
                numMinutesFrom.Value = row.Cells["MinutesFrom"].Value == DBNull.Value || row.Cells["MinutesFrom"].Value == null ?
                    0 : Convert.ToDecimal(row.Cells["MinutesFrom"].Value);

                // Fix the MinutesTo conversion
                numMinutesTo.Value = row.Cells["MinutesTo"].Value == DBNull.Value || row.Cells["MinutesTo"].Value == null ?
                    0 : Convert.ToDecimal(row.Cells["MinutesTo"].Value);

                // ... existing code ...
                numDeduction.Value = row.Cells["DeductionAmount"].Value != DBNull.Value ?
                    Convert.ToDecimal(row.Cells["DeductionAmount"].Value) : 0;
                chkUseDeduction.Checked = Convert.ToBoolean(row.Cells["UseDeduction"].Value);
                chkIsDefault.Checked = Convert.ToBoolean(row.Cells["IsDefault"].Value);
                txtDescription.Text = row.Cells["Description"].Value?.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
        }

        private void ClearInputs()
        {
            txtStatusName.Clear();
            cmbStatusType.SelectedIndex = -1;
            numMinutesFrom.Value = 0;
            numMinutesTo.Value = 0;
            numDeduction.Value = 0;
            chkUseDeduction.Checked = false;
            chkIsDefault.Checked = false;
            txtDescription.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
