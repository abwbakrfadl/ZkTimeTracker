using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ImprovedFingerprint.Forms
{
    public partial class DatabaseSettingsForm : XtraForm
    {
        public DatabaseSettingsForm()
        {
            InitializeComponent();
            
            this.Text = "إعدادات قاعدة البيانات";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            try
            {
                // تحميل الإعدادات الحالية من app.config
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["cn"]?.ConnectionString;
                
                if (!string.IsNullOrEmpty(connectionString))
                {
                    var builder = new SqlConnectionStringBuilder(connectionString);
                    
                    textEditServer.Text = builder.DataSource ?? "";
                    textEditDatabase.Text = builder.InitialCatalog ?? "";
                    textEditUsername.Text = builder.UserID ?? "";
                    textEditPassword.Text = builder.Password ?? "";
                    checkEditIntegratedSecurity.Checked = builder.IntegratedSecurity;
                    
                    UpdateConnectionPreview();
                }
                else
                {
                    // إعدادات افتراضية
                    textEditServer.Text = "localhost";
                    textEditDatabase.Text = "FingerprintDB";
                    checkEditIntegratedSecurity.Checked = true;
                    UpdateConnectionPreview();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل الإعدادات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateConnectionPreview()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = textEditServer.Text.Trim();
                builder.InitialCatalog = textEditDatabase.Text.Trim();
                builder.IntegratedSecurity = checkEditIntegratedSecurity.Checked;
                
                if (!checkEditIntegratedSecurity.Checked)
                {
                    builder.UserID = textEditUsername.Text.Trim();
                    builder.Password = textEditPassword.Text;
                }
                
                builder.ConnectTimeout = 30;
                builder.CommandTimeout = 60;
                
                memoEditConnectionString.Text = builder.ConnectionString;
            }
            catch (Exception ex)
            {
                memoEditConnectionString.Text = $"خطأ في بناء نص الاتصال: {ex.Message}";
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري اختبار الاتصال...";
                Application.DoEvents();

                var connectionString = memoEditConnectionString.Text;
                
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // اختبار تنفيذ استعلام بسيط
                    using (var command = new SqlCommand("SELECT @@VERSION", connection))
                    {
                        var version = command.ExecuteScalar()?.ToString();
                        
                        lblStatus.Text = "تم الاتصال بنجاح ✓";
                        lblStatus.Appearance.ForeColor = System.Drawing.Color.Green;
                        
                        var message = "تم الاتصال بقاعدة البيانات بنجاح";
                        if (!string.IsNullOrEmpty(version))
                        {
                            message += $"\n\nإصدار SQL Server:\n{version.Substring(0, Math.Min(version.Length, 100))}...";
                        }
                        
                        XtraMessageBox.Show(message, "نجح الاختبار",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "فشل في الاتصال ✗";
                lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
                
                var errorMessage = "فشل في الاتصال بقاعدة البيانات:\n\n" + ex.Message;
                
                if (ex.Message.Contains("network-related") || ex.Message.Contains("server was not found"))
                {
                    errorMessage += "\n\nتأكد من:\n• تشغيل خدمة SQL Server\n• صحة اسم الخادم\n• الاتصال بالشبكة";
                }
                else if (ex.Message.Contains("Login failed"))
                {
                    errorMessage += "\n\nتأكد من:\n• صحة اسم المستخدم وكلمة المرور\n• صلاحيات الوصول لقاعدة البيانات";
                }
                
                XtraMessageBox.Show(errorMessage, "فشل الاختبار",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textEditServer.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم الخادم", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditServer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textEditDatabase.Text))
            {
                XtraMessageBox.Show("الرجاء إدخال اسم قاعدة البيانات", "بيانات ناقصة",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEditDatabase.Focus();
                return false;
            }

            if (!checkEditIntegratedSecurity.Checked)
            {
                if (string.IsNullOrWhiteSpace(textEditUsername.Text))
                {
                    XtraMessageBox.Show("الرجاء إدخال اسم المستخدم", "بيانات ناقصة",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEditUsername.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                var result = XtraMessageBox.Show(
                    "هل تريد حفظ إعدادات قاعدة البيانات؟\nسيتم إعادة تشغيل التطبيق لتطبيق التغييرات.",
                    "تأكيد الحفظ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SaveSettings();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حفظ الإعدادات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                var connectionString = memoEditConnectionString.Text;
                
                // حفظ الإعدادات في app.config
                var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                    System.Configuration.ConfigurationUserLevel.None);
                
                if (config.ConnectionStrings.ConnectionStrings["cn"] != null)
                {
                    config.ConnectionStrings.ConnectionStrings["cn"].ConnectionString = connectionString;
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Add(new System.Configuration.ConnectionStringSettings(
                        "cn", connectionString));
                }
                
                config.Save(System.Configuration.ConfigurationSaveMode.Modified);
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
                
                XtraMessageBox.Show("تم حفظ إعدادات قاعدة البيانات بنجاح", "تم الحفظ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في حفظ الإعدادات: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkEditIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            bool useWindowsAuth = checkEditIntegratedSecurity.Checked;
            
            textEditUsername.Enabled = !useWindowsAuth;
            textEditPassword.Enabled = !useWindowsAuth;
            
            if (useWindowsAuth)
            {
                textEditUsername.Text = "";
                textEditPassword.Text = "";
            }
            
            UpdateConnectionPreview();
        }

        private void textEdit_TextChanged(object sender, EventArgs e)
        {
            UpdateConnectionPreview();
        }
    }
}