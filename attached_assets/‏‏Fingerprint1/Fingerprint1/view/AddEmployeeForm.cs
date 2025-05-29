using DevExpress.XtraEditors;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using zkemkeeper;

namespace Fingerprint1.view
{
    public partial class AddEmployeeForm : XtraForm
    {
        private CZKEMClass zkDevice;
        private string currentEmployeeID = null;
        private bool isConnected = false;
       // public CZKEMClass axCZKEM1 = new CZKEMClass();
        private bool bAddControl = true;
        private bool bIsConnected;
        private int iMachineNumber = 1;

        public AddEmployeeForm()
        {
            InitializeComponent();
            InitializeZKTecoDevice();
            LoadEmployees();
            InitializeComboBoxes();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            CZKEMClass zkem = new CZKEMClass();
            if (this.txtIP.Text.Trim() == "" || this.txtPort.Text.Trim() == "")
            {
                int num1 = (int)MessageBox.Show("IP and Port cannot be null", "Error");
            }
            else
            {
                int dwErrorCode = 0;
                this.Cursor = Cursors.WaitCursor;
                if (this.btnConnect.Text == "فصل الاتصال")
                {
                    this.zkDevice.Disconnect();
                    this.bIsConnected = false;
                    this.btnConnect.Text = " اتصال";
                    this.lblState.Text = "Current State:فصل الاتصال";
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.bIsConnected = this.zkDevice.Connect_Net(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text));
                    if (this.bIsConnected)
                    {
                        this.btnConnect.Text = "فصل الاتصال";
                        this.btnConnect.Refresh();
                        this.lblState.Text = "Current State:اتصال";
                        this.iMachineNumber = 1;
                        this.zkDevice.RegEvent(this.iMachineNumber, (int)ushort.MaxValue);
                    }
                    else
                    {
                        this.zkDevice.GetLastError(ref dwErrorCode);
                        int num2 = (int)MessageBox.Show("غير قادر على توصيل الجهاز ، رمز الخطأ=" + dwErrorCode.ToString(), "Error");
                    }
                    this.Cursor = Cursors.Default;
                    if (this.txtIP.Text.Trim() == "" || this.txtPort.Text.Trim() == "")
                    {
                        int num3 = (int)MessageBox.Show("IP and Port cannot be null", "Error");
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        if (this.btnConnect.Text == "DisConnect")
                        {
                            this.zkDevice.Disconnect();
                            this.bIsConnected = false;
                            this.btnConnect.Text = "Connect";
                            this.lblState.Text = "Current State:DisConnected";
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            this.bIsConnected = this.zkDevice.Connect_Net(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text));
                            if (this.bIsConnected)
                            {
                                this.btnConnect.Text = "DisConnect";
                                this.btnConnect.Refresh();
                                this.lblState.Text = "Current State:Connected";
                                this.iMachineNumber = 1;
                                if (!this.zkDevice.RegEvent(this.iMachineNumber, (int)ushort.MaxValue))
                                    ;
                            }
                            else
                            {
                                this.zkDevice.GetLastError(ref dwErrorCode);
                                int num4 = (int)MessageBox.Show("غير قادر على توصيل الجهاز ، رمز الخطأ=" + dwErrorCode.ToString(), "Error");
                            }
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }
        private void InitializeZKTecoDevice()
        {
            zkDevice = new CZKEMClass();
            //isConnected = zkDevice.Connect_Net("150.150.4.201", 4370);
            //lblMessage.Text = isConnected ? "متصل بالجهاز" : "فشل الاتصال";

            // اشتراك في حدث تسجيل البصمة
            // في دالة InitializeZKTecoDevice:
            // في دالة InitializeZKTecoDevice:
            zkDevice.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(zkDevice_OnEnrollFingerEx);
            // zkDevice.OnEnrollFingerEx += new _IZKEMEvents_OnEnrollFingerExEventHandler(zkDevice_OnEnrollFingerEx);
            // في دالة InitializeZKTecoDevice
            //zkDevice.OnEnroll += new _IZKEMEvents_OnEnrollEventHandler(zkDevice_OnEnroll);
            // zkDevice.OnFinger += new _IZKEMEvents_OnFingerEventHandler(zkDevice_OnFinger);
        }

        private void InitializeComboBoxes()
        {
            // تعبئة ComboBox بنوع الإصبع
            cmbFingerIndex.Items.AddRange(new string[] {
                "الإبهام الأيمن (1)", "السبابة اليمنى (2)", "الوسطى اليمنى (3)",
                "البنصر اليمنى (4)", "الخنصر اليمنى (5)", "الإبهام الأيسر (6)",
                "السبابة اليسرى (7)", "الوسطى اليسرى (8)", "البنصر اليسرى (9)",
                "الخنصر اليسرى (10)"
            });
            cmbFingerIndex.SelectedIndex = 0;

            // تعبئة ComboBox بنوع الجنس
            cmbGenderType.Items.AddRange(new string[] { "ذكر", "أنثى" });
            cmbGenderType.SelectedIndex = 0;

            // تعبئة ComboBox بحالة الموظف
            cmbEmployeeStatus.Items.AddRange(new string[] { "نشط", "غير نشط", "موقوف" });
            cmbEmployeeStatus.SelectedIndex = 0;

            // تعبئة ComboBox بالصلاحيات
            cmbPrivilege.Items.AddRange(new string[] { "موظف", "مدير" });
            cmbPrivilege.SelectedIndex = 0;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                string userID = GetNextUserID();
                if (zkDevice.SSR_SetUserInfo(1, userID, txtName.Text, txtPassword.Text,
                    cmbPrivilege.SelectedIndex, chbEnabled.Checked))
                {
                    InsertEmployeeToDatabase(userID);
                    LoadEmployees();
                    MessageBox.Show("تمت الإضافة بنجاح!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("الاسم مطلوب!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("كلمة المرور مطلوبة!");
                return false;
            }
            return true;
        }

        private string GetNextUserID()
        {
            using (SqlConnection conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(MAX(CAST(UserID AS INT)), 0) + 1 
                    FROM Employees 
                    WHERE TRY_CAST(UserID AS INT) IS NOT NULL";

                SqlCommand cmd = new SqlCommand(query, conn);
                int nextID = Convert.ToInt32(cmd.ExecuteScalar());
                return nextID.ToString();
            }
        }

        private void InsertEmployeeToDatabase(string userID)
        {
            using (SqlConnection conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
            {
                string query = @"
                    INSERT INTO Employees (
                        UserID, Name, Password, Privilege, Enabled, Age, Department, 
                        JobTitle, Phone, FinancialID, Address, GenderType, 
                        EmployeeStatus, ProtectionType, CardNumber
                    ) VALUES (
                        @UserID, @Name, @Password, @Privilege, @Enabled, @Age, 
                        @Department, @JobTitle, @Phone, @FinancialID, @Address, 
                        @GenderType, @EmployeeStatus, @ProtectionType, @CardNumber
                    )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Privilege", cmbPrivilege.SelectedIndex);
                cmd.Parameters.AddWithValue("@Enabled", chbEnabled.Checked);
                cmd.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(txtAge.Text) ? DBNull.Value : (object)txtAge.Text);
                cmd.Parameters.AddWithValue("@Department", string.IsNullOrEmpty(txtDepartment.Text) ? DBNull.Value : (object)txtDepartment.Text);
                cmd.Parameters.AddWithValue("@JobTitle", string.IsNullOrEmpty(txtJobTitle.Text) ? DBNull.Value : (object)txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                cmd.Parameters.AddWithValue("@FinancialID", string.IsNullOrEmpty(txtFinancialID.Text) ? DBNull.Value : (object)txtFinancialID.Text);
                cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(txtAddress.Text) ? DBNull.Value : (object)txtAddress.Text);
                cmd.Parameters.AddWithValue("@GenderType", cmbGenderType.Text);
                cmd.Parameters.AddWithValue("@EmployeeStatus", cmbEmployeeStatus.Text);
                cmd.Parameters.AddWithValue("@ProtectionType", string.IsNullOrEmpty(txtProtectionType.Text) ? DBNull.Value : (object)txtProtectionType.Text);
                cmd.Parameters.AddWithValue("@CardNumber", string.IsNullOrEmpty(txtCardNumber.Text) ? DBNull.Value : (object)txtCardNumber.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private bool IsFingerprintExists(string employeeID, int fingerIndex)
        {
            using (SqlConnection conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM Fingerprints 
            WHERE EmployeeID = @EmployeeID AND FingerIndex = @FingerIndex";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@FingerIndex", fingerIndex);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
        private void btnEnrollFingerprint_Click(object sender, EventArgs e)
        {
            if (currentEmployeeID == null)
            {
                MessageBox.Show("حدد موظفاً أولاً!");
                return;
            }

            int fingerIndex = cmbFingerIndex.SelectedIndex; // 0-9
            int flag = 1; // 0: بصمة عادية، 1: بصمة مع التحقق

            // التحقق من وجود بصمة قديمة
            if (IsFingerprintExists(currentEmployeeID, fingerIndex))
            {
                // حذف البصمة القديمة إن وجدت
                if (!zkDevice.SSR_DelUserTmpExt(1, currentEmployeeID, fingerIndex))
                {
                    int errorCode = 0;
                    zkDevice.GetLastError(ref errorCode);
                    MessageBox.Show($"فشل حذف البصمة القديمة. رمز الخطأ: {errorCode}");
                    return;
                }
            }

            // بدء التسجيل
            if (zkDevice.StartEnrollEx(currentEmployeeID, fingerIndex, flag))
            {
                MessageBox.Show("ضع الإصبع على الجهاز...");
            }
            else
            {
                int errorCode = 0;
                zkDevice.GetLastError(ref errorCode);
                MessageBox.Show($"فشل التسجيل. رمز الخطأ: {errorCode}");
            }
        }

        //private bool IsFingerprintExists(string employeeID, int fingerIndex)
        //{
        //    int tmpLength = 0;
        //    byte[] tmpData = new byte[2048];
        //    int flag = 0;

        //    return zkDevice.GetUserTmpEx(1, employeeID, fingerIndex, out flag, out tmpData[0], out tmpLength);
        //}
        private void zkDevice_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            if (ActionResult == 0)
            {
                try
                {
                    // 1. تهيئة المتغيرات المطلوبة
                    int flag = 0;
                    byte[] tmpData = new byte[2048]; // الحجم الأقصى لقالب البصمة
                    int tmpLength = 0;

                    // 2. استدعاء الدالة الصحيحة مع معاملات صحيحة
                    bool success = zkDevice.GetUserTmpEx(
                        1,                          // رقم الجهاز
                        EnrollNumber,               // رقم الموظف كنص
                        FingerIndex,                // رقم الإصبع (0-9)
                        out flag,                   // نوع البصمة (Flag)
                        out tmpData[0],             // البايتات الخاصة بالقالب (مع out)
                        out tmpLength               // طول القالب
                    );


                    if (success && tmpLength > 0)
                    {
                        // تحويل البايتات إلى نص (Base64) لتخزينها في قاعدة البيانات
                        string template = Convert.ToBase64String(tmpData, 0, tmpLength);

                        // التحقق من وجود البصمة قبل الحفظ
                        if (!IsFingerprintExists(EnrollNumber.ToString(), FingerIndex))
                        {
                            SaveFingerprintTemplate(EnrollNumber.ToString(), FingerIndex, template);
                            MessageBox.Show("تم حفظ البصمة بنجاح!");
                        }
                        else
                        {
                            MessageBox.Show("بصمة هذا الإصبع مسجلة بالفعل لهذا الموظف.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("فشل في الحصول على قالب البصمة!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}");
                }
            }
        }
        //private void btnEnrollFingerprint_Click(object sender, EventArgs e)
        //{
        //    if (currentEmployeeID == null)
        //    {
        //        MessageBox.Show("حدد موظفاً أولاً!");
        //        return;
        //    }

        //    int fingerIndex = cmbFingerIndex.SelectedIndex; // 0-9
        //    int flag = 1; // 0: بصمة عادية، 1: بصمة مع التحقق

        //    // حذف البصمة القديمة إن وجدت
        //    zkDevice.SSR_DelUserTmpExt(1, currentEmployeeID, fingerIndex);

        //    // بدء التسجيل (لاحظ استخدام Convert.ToInt32)
        //    if (zkDevice.StartEnrollEx(Convert.ToString(currentEmployeeID), fingerIndex, flag))
        //    {
        //        MessageBox.Show("ضع الإصبع على الجهاز...");
        //    }
        //    else
        //    {
        //        int errorCode = 0;
        //        zkDevice.GetLastError(ref errorCode);
        //        MessageBox.Show($"فشل التسجيل. رمز الخطأ: {errorCode}");
        //    }
        //}
        private void SaveFingerprintTemplate(string employeeID, int fingerIndex, string template)
        {
            try
            {
                // التحقق من وجود البصمة
                if (IsFingerprintExists(employeeID, fingerIndex))
                {
                    MessageBox.Show("بصمة هذا الإصبع مسجلة بالفعل لهذا الموظف.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
                {
                    string query = @"
                INSERT INTO Fingerprints (EmployeeID, FingerIndex, Template)
                VALUES (@EmployeeID, @FingerIndex, @Template)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@FingerIndex", fingerIndex);
                    cmd.Parameters.AddWithValue("@Template", template);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("تم حفظ البصمة بنجاح!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ البصمة: {ex.Message}");
            }
        }
        //private void SaveFingerprintTemplate(string employeeID, int fingerIndex, string template)
        //{
        //    using (SqlConnection conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
        //    {
        //        string query = @"
        //    INSERT INTO Fingerprints (EmployeeID, FingerIndex, Template)
        //    VALUES (@EmployeeID, @FingerIndex, @Template)";

        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
        //        cmd.Parameters.AddWithValue("@FingerIndex", fingerIndex);
        //        cmd.Parameters.AddWithValue("@Template", template);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                currentEmployeeID = row.Cells["UserID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                cmbPrivilege.SelectedIndex = Convert.ToInt32(row.Cells["Privilege"].Value);
                chbEnabled.Checked = Convert.ToBoolean(row.Cells["Enabled"].Value);
                txtAge.Text = row.Cells["Age"].Value?.ToString();
                txtDepartment.Text = row.Cells["Department"].Value?.ToString();
                txtJobTitle.Text = row.Cells["JobTitle"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtFinancialID.Text = row.Cells["FinancialID"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                cmbGenderType.Text = row.Cells["GenderType"].Value?.ToString();
                cmbEmployeeStatus.Text = row.Cells["EmployeeStatus"].Value?.ToString();
                txtProtectionType.Text = row.Cells["ProtectionType"].Value?.ToString();
                txtCardNumber.Text = row.Cells["CardNumber"].Value?.ToString();
            }
        }

        private void LoadEmployees()
        {
            using (SqlConnection conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
            {
                conn.Open();
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                var dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dgvEmployees.DataSource = dataTable;
            }
        }
        // مثال لزر الحذف
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentEmployeeID == null) return;

            try
            {
                using (var conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
                {
                    // حذف البصمات أولاً
                    new SqlCommand($"DELETE FROM Fingerprints WHERE EmployeeID = '{currentEmployeeID}'", conn).ExecuteNonQuery();
                    // ثم حذف الموظف
                    new SqlCommand($"DELETE FROM Employees WHERE UserID = '{currentEmployeeID}'", conn).ExecuteNonQuery();
                    LoadEmployees();
                    MessageBox.Show("تم الحذف بنجاح!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ: {ex.Message}");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentEmployeeID == null)
            {
                MessageBox.Show("يرجى تحديد موظف من القائمة أولاً!");
                return;
            }

            if (!ValidateInputs())
                return;

            try
            {
                using (var conn = new SqlConnection(new AppSetting().GetConnectionString("cn")))
                {
                    conn.Open();

                    // تحديث بيانات الموظف الأساسية
                    string updateEmployeeQuery = @"
                UPDATE Employees SET 
                    Name = @Name,
                    Password = @Password,
                    Privilege = @Privilege,
                    Enabled = @Enabled,
                    Age = @Age,
                    Department = @Department,
                    JobTitle = @JobTitle,
                    Phone = @Phone,
                    FinancialID = @FinancialID,
                    Address = @Address,
                    GenderType = @GenderType,
                    EmployeeStatus = @EmployeeStatus,
                    ProtectionType = @ProtectionType,
                    CardNumber = @CardNumber
                WHERE UserID = @UserID";

                    using (var cmd = new SqlCommand(updateEmployeeQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentEmployeeID);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Privilege", cmbPrivilege.SelectedIndex);
                        cmd.Parameters.AddWithValue("@Enabled", chbEnabled.Checked);
                        cmd.Parameters.AddWithValue("@Age", string.IsNullOrEmpty(txtAge.Text) ? DBNull.Value : (object)txtAge.Text);
                        cmd.Parameters.AddWithValue("@Department", string.IsNullOrEmpty(txtDepartment.Text) ? DBNull.Value : (object)txtDepartment.Text);
                        cmd.Parameters.AddWithValue("@JobTitle", string.IsNullOrEmpty(txtJobTitle.Text) ? DBNull.Value : (object)txtJobTitle.Text);
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(txtPhone.Text) ? DBNull.Value : (object)txtPhone.Text);
                        cmd.Parameters.AddWithValue("@FinancialID", string.IsNullOrEmpty(txtFinancialID.Text) ? DBNull.Value : (object)txtFinancialID.Text);
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(txtAddress.Text) ? DBNull.Value : (object)txtAddress.Text);
                        cmd.Parameters.AddWithValue("@GenderType", cmbGenderType.Text);
                        cmd.Parameters.AddWithValue("@EmployeeStatus", cmbEmployeeStatus.Text);
                        cmd.Parameters.AddWithValue("@ProtectionType", string.IsNullOrEmpty(txtProtectionType.Text) ? DBNull.Value : (object)txtProtectionType.Text);
                        cmd.Parameters.AddWithValue("@CardNumber", string.IsNullOrEmpty(txtCardNumber.Text) ? DBNull.Value : (object)txtCardNumber.Text);

                        cmd.ExecuteNonQuery();
                    }

                    // تحديث بيانات البصمة إذا لزم الأمر
                    if (chkUpdateFingerprint.Checked) // إذا كان هناك CheckBox لتحديد تحديث البصمة
                    {
                        int fingerIndex = cmbFingerIndex.SelectedIndex + 1;
                        zkDevice.SSR_DelUserTmpExt(1, currentEmployeeID, fingerIndex);
                        zkDevice.StartEnrollEx(currentEmployeeID, fingerIndex, 1);
                    }

                    LoadEmployees();
                    MessageBox.Show("تم التعديل بنجاح!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء التعديل: {ex.Message}");
            }
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
//using System;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Windows.Forms;
//using zkemkeeper; // مكتبة ZKTeco

//namespace Fingerprint1.view
//{
//    public partial class AddEmployeeForm : Form
//    {
//        private CZKEMClass zkDevice;
//        private string currentEnrollingUserID = null; // تعريف المتغير كـ string وقيمته الافتراضية null

//        public AddEmployeeForm()
//        {
//            InitializeComponent();
//            InitializeZKTecoDevice();
//            LoadEmployees();
//            StyleDataGridView(dgvEmployees);

//        }
//        private void StyleDataGridView(DataGridView dgv)
//        {
//            dgv.BackgroundColor = Color.White;
//            dgv.BorderStyle = BorderStyle.None;
//            dgv.RightToLeft = RightToLeft.Yes;
//            dgv.EnableHeadersVisualStyles = false;
//            dgv.AllowUserToAddRows = false;
//            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(87, 87, 178);
//            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
//            dgv.DefaultCellStyle.Font = new Font("Cairo", 10);

//            // Header Style
//            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68);
//            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
//            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Cairo", 11, FontStyle.Bold);
//            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
//            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
//            dgv.ColumnHeadersHeight = 50;

//            // Alternating Row Colors
//            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 250);
//            dgv.RowsDefaultCellStyle.BackColor = Color.White;
//            dgv.DefaultCellStyle.Padding = new Padding(5);
//            dgv.RowTemplate.Height = 40;

//            // Border Style
//            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
//            dgv.GridColor = Color.FromArgb(240, 240, 240);

//            // Selection Style
//            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

//            // Scrollbar Style
//            dgv.ScrollBars = ScrollBars.Both;
//        }
//        private void InitializeZKTecoDevice()
//        {
//            zkDevice = new CZKEMClass();

//            // عنوان IP للجهاز ورقم المنفذ
//            string ipAddress = "150.150.4.201";
//            int port = 4370;

//            // محاولة الاتصال بالجهاز
//            if (zkDevice.Connect_Net(ipAddress, port))
//            {
//                lblMessage.Text = "تم الاتصال بالجهاز بنجاح!";
//            }
//            else
//            {
//                lblMessage.Text = "فشل الاتصال بالجهاز.";
//            }
//        }
//        private void btnExportExcel_Click(object sender, EventArgs e)
//        {
//          //  ExportToExcel();
//        }

//        private void btnWebPrint_Click(object sender, EventArgs e)
//        {
//           // PrintViaWeb();
//        }

//        private void btnDisciplinedReport_Click(object sender, EventArgs e)
//        {
//            //ShowDisciplinedReport();
//        }
//        private void btnAddEmployee_Click(object sender, EventArgs e)
//        {
//            string name = txtName.Text.Trim();
//            string password = txtPassword.Text.Trim();

//            if (string.IsNullOrEmpty(name))
//            {
//                lblMessage.Text = "يرجى إدخال اسم الموظف.";
//                return;
//            }

//            try
//            {
//                //public virtual bool SSR_SetUserInfo(int dwMachineNumber, string dwEnrollNumber, string Name, string Password, int Privilege, bool Enabled);
//                // إضافة الموظف إلى جهاز البصمة
//                string userID = GetNextUserID(); // الحصول على معرف الموظف كنص
//                if (zkDevice.SSR_SetUserInfo(1, userID, name, password, 0, true)) // استخدام userID كنص
//                {
//                    lblMessage.Text = $"تمت إضافة الموظف {name} بنجاح إلى جهاز البصمة.";

//                    // إضافة الموظف إلى قاعدة البيانات
//                    InsertEmployeeToDatabase(userID, name, password);

//                    lblMessage.Text += " وتم حفظه في قاعدة البيانات.";
//                    LoadEmployees(); // تحديث قائمة الموظفين
//                }
//                else
//                {
//                    lblMessage.Text = "فشل إضافة الموظف إلى جهاز البصمة.";
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = $"حدث خطأ: {ex.Message}";
//            }
//        }

//        private void btnEnrollFingerprint_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(currentEnrollingUserID))
//            {
//                lblMessage.Text = "يرجى تحديد موظف لتسجيل بصمته.";
//                return;
//            }

//            // بدء تسجيل البصمة
//            if (zkDevice.StartEnrollEx(currentEnrollingUserID, 0, 1)) // استخدام currentEnrollingUserID كنص
//            {
//                lblMessage.Text = "الرجاء وضع إصبعك على جهاز البصمة...";
//            }
//            else
//            {
//                lblMessage.Text = "فشل بدء تسجيل البصمة.";
//            }
//        }

//        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                // الحصول على رقم الموظف المحدد كنص
//                currentEnrollingUserID = dgvEmployees.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
//                lblMessage.Text = $"تم تحديد الموظف برقم: {currentEnrollingUserID}";
//            }
//        }
//        private string GetNextUserID()
//        {
//            AppSetting setting = new AppSetting();
//            string connectionString = setting.GetConnectionString("cn");

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // استعلام للحصول على أكبر قيمة عددية صالحة في الحقل UserID
//                string query = @"
//            SELECT ISNULL(MAX(CAST(UserID AS INT)), 0) + 1 
//            FROM Employees 
//            WHERE TRY_CAST(UserID AS INT) IS NOT NULL";

//                SqlCommand command = new SqlCommand(query, connection);
//                int nextID = Convert.ToInt32(command.ExecuteScalar());
//                return nextID.ToString(); // تحويل الرقم إلى نص
//            }
//        }
//        //private string GetNextUserID()
//        //{
//        //    AppSetting setting = new AppSetting();
//        //    string connectionString = setting.GetConnectionString("cn");

//        //    using (SqlConnection connection = new SqlConnection(connectionString))
//        //    {
//        //        connection.Open();
//        //        string query = "SELECT ISNULL(MAX(UserID), 0) + 1 FROM Employees";
//        //        SqlCommand command = new SqlCommand(query, connection);
//        //        int nextID = Convert.ToInt32(command.ExecuteScalar());
//        //        return nextID.ToString(); // تحويل الرقم إلى نص
//        //    }
//        //}

//        private void InsertEmployeeToDatabase(string userID, string name, string password)
//        {
//            AppSetting setting = new AppSetting();
//            string connectionString = setting.GetConnectionString("cn");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "INSERT INTO Employees (UserID, Name, Password, Privilege, Enabled) VALUES (@UserID, @Name, @Password, @Privilege, @Enabled)";

//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@UserID", userID); // استخدام userID كنص
//                command.Parameters.AddWithValue("@Name", name);
//                command.Parameters.AddWithValue("@Password", password);
//                command.Parameters.AddWithValue("@Privilege", 0); // 0 يشير إلى موظف عادي
//                command.Parameters.AddWithValue("@Enabled", true);

//                connection.Open();
//                command.ExecuteNonQuery();
//            }
//        }

//        private void LoadEmployees()
//        {
//            AppSetting setting = new AppSetting();
//            string connectionString = setting.GetConnectionString("cn");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                string query = "SELECT UserID, Name, Password FROM Employees";
//                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
//                var dataTable = new System.Data.DataTable();
//                adapter.Fill(dataTable);

//                dgvEmployees.DataSource = dataTable;
//            }
//        }
//    }
//}


