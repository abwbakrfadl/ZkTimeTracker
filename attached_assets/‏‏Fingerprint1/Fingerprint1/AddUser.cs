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

using Fingerprint1.view;
namespace Fingerprint1
{
    public partial class AddUser : Form
    {




        public AddUser()
        {
            InitializeComponent();

        }
        private void LoadStatus()
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM UserType", connection))
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
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtpassword.Text) || cmbRole.SelectedIndex == -1)
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
                    //        CREATE TABLE UserType(
                    //UserID int IDENTITY(1, 1) NOT NULL,
                    //Username nvarchar(50) NOT NULL,
                    //Password nvarchar(50) NOT NULL,
                    //Role nvarchar(20) NOT NULL);
                    // استعلام SQL للتحقق من المستخدم ودوره
                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO UserType (
                    Username, Password, Role)
                VALUES (
                    @Username, @Password, @Role)", connection))
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

        private void ClearInputs()
        {
            txtUser.Clear();
            txtpassword.Clear();
            cmbRole.SelectedIndex = -1;
          
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
                    //        CREATE TABLE UserType(
                    //UserID int IDENTITY(1, 1) NOT NULL,
                    //Username nvarchar(50) NOT NULL,
                    //Password nvarchar(50) NOT NULL,
                    //Role nvarchar(20) NOT NULL);
                    // استعلام SQL للتحقق من المستخدم ودوره

                    // Ensure connection is closed before opening
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    using (SqlCommand cmd = new SqlCommand(@"
            UPDATE AttendanceStatus SET 
                Username = @Username,
                Password = @Password,
                Role = @Role
            WHERE UserID = @UserID", connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", dgvStatus.SelectedRows[0].Cells["UserID"].Value);
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

        private void AddStatusParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Username", txtUser.Text);
            cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
           
           
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
                    {//        CREATE TABLE UserType(
                     //UserID int IDENTITY(1, 1) NOT NULL,
                     //Username nvarchar(50) NOT NULL,
                     //Password nvarchar(50) NOT NULL,
                     //Role nvarchar(20) NOT NULL);
                     // استعلام SQL للتحقق من المستخدم ودوره
                        using (SqlCommand cmd = new SqlCommand(
                            "DELETE FROM UserType WHERE UserID = @UserID", connection))
                        {
                            cmd.Parameters.AddWithValue("@UserID",
                                dgvStatus.SelectedRows[0].Cells["UserID"].Value);

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



        private void DgvStatus_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStatus.SelectedRows.Count > 0)
            {
                var row = dgvStatus.SelectedRows[0];
                txtUser.Text = row.Cells["Username"].Value.ToString();
                txtpassword.Text = row.Cells["Password"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();
               
               

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                BtnAdd.Enabled = false;
            }
        }

    }



}

