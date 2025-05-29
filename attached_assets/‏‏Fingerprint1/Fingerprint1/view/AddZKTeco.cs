using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

using zkemkeeper;
namespace Fingerprint1.view
{
    public partial class AddZKTeco : Form
    {
        private CZKEMClass zkDevice;
        public AddZKTeco()
        {
            InitializeComponent();
            InitializeZKTecoDevice();
        }
      
        

        private void InitializeZKTecoDevice()
        {
            zkDevice = new CZKEMClass();

            // عنوان IP للجهاز ورقم المنفذ
            string ipAddress = "192.168.1.201";
            int port = 4370;

            // محاولة الاتصال بالجهاز
            if (zkDevice.Connect_Net(ipAddress, port))
            {
                lblMessage.Text = "تم الاتصال بالجهاز بنجاح!";
            }
            else
            {
                lblMessage.Text = "فشل الاتصال بالجهاز.";
            }
        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            try
            {
                // بدء استخراج بيانات الموظفين
                GetEmployeeData(zkDevice, dgvData);

                lblMessage.Text = "تم جلب بيانات الموظفين بنجاح!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"حدث خطأ: {ex.Message}";
            }
        }
        static void GetEmployeeData(CZKEMClass zkDevice, DataGridView dgvData)
        {
            string userID = "";
            string name = "";
            string password = "";
            int privilege = 0;
            bool enabled = false;

            // بدء استخراج بيانات الموظفين
            zkDevice.ReadAllUserID(1); // 1 يشير إلى رقم الجهاز (يمكن أن يكون متعدد الأجهزة)
            var employeeList = new System.Collections.Generic.List<Employee>();
            while (zkDevice.SSR_GetAllUserInfo(1, out userID, out name, out password, out privilege, out enabled))
            {
                Console.WriteLine($"ID: {userID}, Name: {name}, Password: {password}, Privilege: {privilege}, Enabled: {enabled}");

                employeeList.Add(new Employee
                {
                    UserID = userID,
                    Name = name,
                    Password = password,
                    Privilege = privilege,
                    Enabled = enabled
                });

                // إدراج البيانات في قاعدة بيانات SQL Server
                InsertEmployeeToDatabase(userID, name, password, privilege, enabled); 
            }
            dgvData.DataSource = employeeList;
            // عرض البيانات في DataGridView


        }
        static void InsertEmployeeToDatabase(string userID, string name, string password, int privilege, bool enabled)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (UserID, Name, Password, Privilege, Enabled) VALUES (@UserID, @Name, @Password, @Privilege, @Enabled)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Privilege", privilege);
                command.Parameters.AddWithValue("@Enabled", enabled);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("تم إدراج الموظف بنجاح في قاعدة البيانات.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"حدث خطأ أثناء إدراج البيانات: {ex.Message}");
                }
            }
        }
    }
    public class Employee
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Privilege { get; set; }
        public bool Enabled { get; set; }
    }
}