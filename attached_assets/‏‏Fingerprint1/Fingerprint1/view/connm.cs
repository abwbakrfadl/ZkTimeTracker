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

namespace Fingerprint1.view
{
    public partial class connm : Form
    {
        public connm()
        {
            InitializeComponent();
           
        }
        private void connm_Load(object sender, EventArgs e)
        {
            cboServer.Items.Add(".");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add(string.Format(@"{0}\ABUBAKR", Environment.MachineName));
            cboServer.SelectedIndex = 3;
        }
       
        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-3F7NFV1\\ABUBAKR;Initial Catalog=CLINIC_BATABASE_2020;Integrated Security=True");
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-3F7NFV1\\ABUBAKR;Initial Catalog=CLINIC_BATABASE_2020;User ID=as; Password=123;
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2}; Password={3};", cboServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2}; Password={3};", cboServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SeveConnectionString("cn", connectionString);
                    MessageBox.Show("your connection string hes been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //FormLogin adminPanel = new FormLogin();
                    //adminPanel.Show();
                    //this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
