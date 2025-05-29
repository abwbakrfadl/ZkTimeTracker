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
    public partial class LoginForm : Form
    {
      



            public LoginForm()
            {
                InitializeComponent();

            }

            

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtpassword.Text;
            if (username == "abubakr" && password == "abubak123r")
            {
                AddUserAdmin();
            }
            else
            {

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");

               
               
                string query = "SELECT Role FROM UserType WHERE Username = @Username AND Password = @Password";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            // تنفيذ الاستعلام والحصول على الدور
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                string Role = result.ToString();
                                MessageBox.Show("تم تسجيل الدخول بنجاح!");

                                // فتح نافذة جديدة بناءً على الدور
                                if (Role == "مدير")
                                {
                                    OpenAdminPanel();
                                }
                                else if(Role == "موظف")
                                {
                                    OpenAdminPanel1();
                                    //OpenUserPanel();
                                }
                                else
                                {
                                    MessageBox.Show("لاتوجد فورم عادي!");
                                    //OpenUserPanel();
                                }
                            }
                            else
                            {
                                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صحيحة!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ: " + ex.Message);
                }

            }
        }
        private void AddUserAdmin()
        {
            // افتح نافذة الإدارة (Admin Panel)
            AddUser adminPanel = new AddUser();
            adminPanel.Show();
           // this.Hide(); // إخفاء نافذة تسجيل الدخول
        }
        private void OpenAdminPanel()
        {
            // إغلاق نافذة تسجيل الدخول
            this.Hide();

            // إنشاء النموذج الرئيسي
            MainForm adminPanel = new MainForm();

            // عند إغلاق النموذج الرئيسي، أغلق التطبيق
            adminPanel.FormClosed += (s, args) => Application.Exit();

            // عرض النموذج الرئيسي
            adminPanel.Show();
        }

        private void OpenAdminPanel1()
        {
            // إغلاق نافذة تسجيل الدخول
            this.Hide();

            // إنشاء النموذج الرئيسي
            MainForm1 adminPanel = new MainForm1();

            // عند إغلاق النموذج الرئيسي، أغلق التطبيق
            adminPanel.FormClosed += (s, args) => Application.Exit();

            // عرض النموذج الرئيسي
            adminPanel.Show();
        }
        //private void OpenAdminPanel()
        //    {
        //    // افتح نافذة الإدارة (Admin Panel)
        //    //MainForm adminPanel = new MainForm();
        //    //adminPanel.Show();
        //    //this.Hide(); // إخفاء نافذة تسجيل الدخول
        //    MainForm adminPanel = new MainForm();

        //    // إغلاق نافذة LoginForm تمامًا بدلًا من إخفائها
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();

        //    // تشغيل النافذة الرئيسية في loop جديد
        //    Application.Run(adminPanel);

        //}

        //private void OpenAdminPanel1()
        //{
        //    // افتح نافذة الإدارة (Admin Panel)
        //    //MainForm1 adminPanel = new MainForm1();
        //    //adminPanel.Show();
        //    //this.Hide(); // إخفاء نافذة تسجيل الدخول
        //    MainForm1 adminPanel = new MainForm1();

        //    // إغلاق نافذة LoginForm تمامًا بدلًا من إخفائها
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();

        //    // تشغيل النافذة الرئيسية في loop جديد
        //    Application.Run(adminPanel);
        //}

        private void guna2Button1_Click(object sender, EventArgs e)
            {
                //Application.Exit();
                Application.ExitThread();
            }

        private void MenuConn_Click(object sender, EventArgs e)
        {
            connm adminPanel = new connm();
            adminPanel.Show();
        }





        //private void OpenUserPanel()
        //{
        //    // افتح نافذة المستخدم العادي (User Panel)
        //    UserPanel userPanel = new UserPanel();
        //    userPanel.Show();
        //    this.Hide(); // إخفاء نافذة تسجيل الدخول
        //}
    }



    }

