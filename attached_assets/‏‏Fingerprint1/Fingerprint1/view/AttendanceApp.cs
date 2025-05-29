using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using zkemkeeper;

namespace Fingerprint1.view
{
    public partial class AttendanceApp : Form
    {
        private CZKEMClass zkDevice;
        private bool isConnected;

        public AttendanceApp()
        {
            InitializeComponent();
            InitializeZKTecoDevice();
        }

        private void InitializeZKTecoDevice()
        {
            zkDevice = new CZKEMClass();
            string ipAddress = "150.150.4.201";
            int port = 4370;

            isConnected = zkDevice.Connect_Net(ipAddress, port);
            lblMessage.Text = isConnected ? "تم الاتصال بالجهاز بنجاح!" : "فشل الاتصال بالجهاز!";
        }

        //private void btnFetchAttendance_Click(object sender, EventArgs e)
        //{
        //    if (!isConnected)
        //    {
        //        lblMessage.Text = "الجهاز غير متصل!";
        //        return;
        //    }

        //    btnFetchAttendance.Enabled = false;
        //    this.Cursor = Cursors.WaitCursor;

        //    try
        //    {
        //        // إعادة الاتصال بالجهاز
        //        zkDevice.Disconnect();
        //        System.Threading.Thread.Sleep(1000);

        //        if (!zkDevice.Connect_Net("150.150.4.201", 4370))
        //        {
        //            lblMessage.Text = "فشل في إعادة الاتصال بالجهاز";
        //            return;
        //        }

        //        zkDevice.EnableDevice(1, false);
        //        System.Threading.Thread.Sleep(1000);

        //        List<Attendance> attendanceList = new List<Attendance>();
        //        int totalRecords = 0;
        //        int dwWorkCode = 0;

        //        if (zkDevice.ReadGeneralLogData(1))
        //        {
        //            while (zkDevice.SSR_GetGeneralLogData(1,
        //                   out string dwEnrollNumber,
        //                   out int dwVerifyMode,
        //                   out int dwInOutMode,
        //                   out int dwYear,
        //                   out int dwMonth,
        //                   out int dwDay,
        //                   out int dwHour,
        //                   out int dwMinute,
        //                   out int dwSecond,
        //                   ref dwWorkCode))
        //            {
        //                totalRecords++;
        //                lblMessage.Text = $"جاري القراءة... {totalRecords} سجل";
        //                Application.DoEvents();

        //                attendanceList.Add(new Attendance
        //                {
        //                    UserID = dwEnrollNumber,
        //                    DateTime = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond),
        //                    VerificationMode = dwVerifyMode,
        //                    InOutMode = dwInOutMode
        //                });
        //            }

        //            dgvAttendance.DataSource = null;
        //            dgvAttendance.DataSource = attendanceList;
        //            lblMessage.Text = $"تم قراءة {totalRecords} سجل";
        //        }
        //        else
        //        {
        //            int errorCode = 0;
        //            zkDevice.GetLastError(ref errorCode);
        //            MessageBox.Show($"فشل في قراءة البيانات. رمز الخطأ: {errorCode}", "خطأ");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "خطأ");
        //    }
        //    finally
        //    {
        //        zkDevice.EnableDevice(1, true);
        //        zkDevice.Disconnect();
        //        btnFetchAttendance.Enabled = true;
        //        this.Cursor = Cursors.Default;
        //    }
        //}
        private void btnFetchAttendance_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                lblMessage.Text = "الجهاز غير متصل!";
                return;
            }

            btnFetchAttendance.Enabled = false;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // إعادة تهيئة الاتصال
                zkDevice.Disconnect();
                System.Threading.Thread.Sleep(1000);

                if (!zkDevice.Connect_Net("150.150.4.201", 4370))
                {
                    lblMessage.Text = "فشل في الاتصال بالجهاز";
                    return;
                }

                zkDevice.EnableDevice(1, false);
                System.Threading.Thread.Sleep(1000);

                List<Attendance> attendanceList = new List<Attendance>();
                int totalRecords = 0;
                int savedRecords = 0;
                int dwWorkCode = 0;

                if (zkDevice.ReadGeneralLogData(1))
                {
                    while (zkDevice.SSR_GetGeneralLogData(1,
                           out string dwEnrollNumber,
                           out int dwVerifyMode,
                           out int dwInOutMode,
                           out int dwYear,
                           out int dwMonth,
                           out int dwDay,
                           out int dwHour,
                           out int dwMinute,
                           out int dwSecond,
                           ref dwWorkCode))
                    {
                        totalRecords++;
                        lblMessage.Text = $"جاري القراءة... {totalRecords} سجل";
                        progressBar1.Value = (totalRecords % 100);
                        Application.DoEvents();

                        DateTime dateTime = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);

                        try
                        {
                            if (!IsRecordExists(dwEnrollNumber, dateTime))
                            {
                                InsertAttendanceToDatabase(dwEnrollNumber, dateTime, dwVerifyMode, dwInOutMode);
                                savedRecords++;

                                attendanceList.Add(new Attendance
                                {
                                    UserID = dwEnrollNumber,
                                    DateTime = dateTime,
                                    VerificationMode = dwVerifyMode,
                                    InOutMode = dwInOutMode
                                });
                            }
                        }
                        catch (Exception dbEx)
                        {
                            MessageBox.Show($"خطأ في حفظ السجل {dwEnrollNumber}: {dbEx.Message}", "خطأ في الحفظ");
                        }
                    }

                    dgvAttendance.DataSource = null;
                    dgvAttendance.DataSource = attendanceList;
                    lblMessage.Text = $"تم قراءة {totalRecords} سجل وحفظ {savedRecords} سجل جديد";
                }
                else
                {
                    int errorCode = 0;
                    zkDevice.GetLastError(ref errorCode);
                    MessageBox.Show($"فشل في قراءة البيانات. رمز الخطأ: {errorCode}", "خطأ");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"خطأ: {ex.Message}";
                MessageBox.Show(ex.ToString(), "Error Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                zkDevice.EnableDevice(1, true);
                zkDevice.Disconnect();
                btnFetchAttendance.Enabled = true;
                progressBar1.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private bool IsRecordExists(string userID, DateTime dateTime)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Attendance WHERE UserID = @UserID AND DateTime = @DateTime";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@DateTime", dateTime);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void InsertAttendanceToDatabase(string userID, DateTime dateTime, int verifyMode, int inOutMode)
        {
            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Attendance (UserID, DateTime, VerificationMode, InOutMode) 
                        VALUES (@UserID, @DateTime, @VerificationMode, @InOutMode)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@DateTime", dateTime);
                command.Parameters.AddWithValue("@VerificationMode", verifyMode);
                command.Parameters.AddWithValue("@InOutMode", inOutMode);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void SaveAttendanceRecords(List<Attendance> records)
        {
            int savedCount = 0;
            foreach (var record in records)
            {
                if (!IsRecordExists(record.UserID, record.DateTime))
                {
                    InsertAttendanceToDatabase(record.UserID, record.DateTime,
                                             record.VerificationMode, record.InOutMode);
                    savedCount++;
                }
            }
            lblMessage.Text = $"تم حفظ {savedCount} سجل من {records.Count} سجل";
        }

      

        public class Attendance
        {
            public string UserID { get; set; }
            public DateTime DateTime { get; set; }
            public int VerificationMode { get; set; }
            public int InOutMode { get; set; }
        }
    }
}

//private bool IsRecordExists(string userID, DateTime dateTime)
//{
//    AppSetting setting = new AppSetting();
//    string connectionString = setting.GetConnectionString("cn");

//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        string query = "SELECT COUNT(*) FROM Attendance_Temp WHERE UserID = @UserID AND DateTime = @DateTime";
//        SqlCommand command = new SqlCommand(query, connection);
//        command.Parameters.AddWithValue("@UserID", userID);
//        command.Parameters.AddWithValue("@DateTime", dateTime);

//        connection.Open();
//        int count = (int)command.ExecuteScalar();
//        return count > 0;
//    }
//}

//private void InsertAttendanceToDatabase(string userID, DateTime dateTime, int verifyMode, int inOutMode)
//{
//    AppSetting setting = new AppSetting();
//    string connectionString = setting.GetConnectionString("cn");

//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        // تم تعديل الاستعلام ليتجاهل عمود LogID لأنه IDENTITY
//        string query = @"INSERT INTO Attendance_Temp (UserID, DateTime, VerificationMode, InOutMode) 
//                VALUES (@UserID, @DateTime, @VerificationMode, @InOutMode)";

//        SqlCommand command = new SqlCommand(query, connection);
//        command.Parameters.AddWithValue("@UserID", userID);
//        command.Parameters.AddWithValue("@DateTime", dateTime);
//        command.Parameters.AddWithValue("@VerificationMode", verifyMode);
//        command.Parameters.AddWithValue("@InOutMode", inOutMode);

//        connection.Open();
//        command.ExecuteNonQuery();
//    }
//}
//private void btnFetchAttendance_Click(object sender, EventArgs e)
//{
//    if (!isConnected)
//    {
//        lblMessage.Text = "الجهاز غير متصل!";
//        return;
//    }

//    try
//    {
//        zkDevice.EnableDevice(1, false);
//        Thread.Sleep(1000);

//        List<Attendance> attendanceList = new List<Attendance>();

//        // قراءة جميع السجلات من الجهاز
//        if (!zkDevice.ReadAllGLogData(1))
//        {
//            lblMessage.Text = "لا توجد سجلات في الجهاز!";
//            return;
//        }

//        int totalRecords = 0;
//        int validRecords = 0;
//        int isValid = 0;
//        // تقسيم السجلات إلى دفعات
//        int batchSize = 1000; // عدد السجلات في كل دفعة
//        int processedRecords = 0;

//        while (true) // حلقة رئيسية لمعالجة الدفعات
//        {
//            int recordsInBatch = 0;

//            for (int i = 0; i < batchSize; i++)
//            {
//                if (!zkDevice.SSR_GetGeneralLogData(
//                    1,
//                    out string userID,
//                    out int verifyMode,
//                    out int inOutMode,
//                    out int year,
//                    out int month,
//                    out int day,
//                    out int hour,
//                    out int minute,
//                    out int second,
//                    ref  isValid))
//                {
//                    break; // خروج إذا لم تعد هناك سجلات
//                }

//                totalRecords++;
//                recordsInBatch++;

//                Console.WriteLine($"Record {totalRecords}: isValid = {isValid}, UserID = {userID}");

//                if (isValid != 0)
//                {
//                    validRecords++;
//                    DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

//                    if (!IsRecordExists(userID, dateTime))
//                    {
//                        InsertAttendanceToDatabase(userID, dateTime, verifyMode, inOutMode);
//                        attendanceList.Add(new Attendance { UserID = userID, DateTime = dateTime, VerificationMode = verifyMode, InOutMode = inOutMode });
//                    }
//                }
//            }

//            processedRecords += recordsInBatch;

//            // تحديث واجهة المستخدم
//            lblMessage.Invoke((MethodInvoker)(() =>
//            {
//                lblMessage.Text = $"جارٍ المعالجة... ({processedRecords}/{totalRecords})";
//            }));

//            // الخروج إذا لم تعد هناك سجلات
//            if (recordsInBatch < batchSize)
//            {
//                break;
//            }
//        }

//        // تحديث DataGridView
//        dgvAttendance.Invoke((MethodInvoker)(() =>
//        {
//            dgvAttendance.DataSource = null;
//            dgvAttendance.DataSource = attendanceList;
//            dgvAttendance.Refresh();
//        }));

//        lblMessage.Invoke((MethodInvoker)(() =>
//        {
//            lblMessage.Text = $"تم جلب {validRecords} سجل جديد من {totalRecords} سجل.";
//        }));
//    }
//    catch (Exception ex)
//    {
//        lblMessage.Invoke((MethodInvoker)(() =>
//        {
//            lblMessage.Text = $"خطأ: {ex.Message}";
//        }));
//    }
//    finally
//    {
//        zkDevice.EnableDevice(1, true);
//    }
//}
////////////

//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Windows.Forms;
//using zkemkeeper; // مكتبة ZKTeco

//namespace Fingerprint1.view
//{
//    public partial class AttendanceApp : Form
//    {
//        private CZKEMClass zkDevice;

//        public AttendanceApp()
//        {
//            InitializeComponent();
//            InitializeZKTecoDevice();
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
//        private bool CheckDeviceAccess(CZKEMClass zkDevice, string ipAddress, int port)
//        {
//            try
//            {
//                if (!zkDevice.Connect_Net(ipAddress, port))
//                {
//                    lblMessage.Text = "فشل الاتصال بالجهاز";
//                    return false;
//                }

//                // Using GetDeviceStatus instead of GetDeviceTime
//                int dwStatus = 0;
//                bool hasAccess = zkDevice.GetDeviceStatus(1, 1, ref dwStatus);

//                if (!hasAccess)
//                {
//                    lblMessage.Text = "ليس لديك صلاحيات كافية للوصول للجهاز";
//                    return false;
//                }

//                lblMessage.Text = "تم التحقق من الصلاحيات بنجاح";
//                return true;
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = $"خطأ في الوصول للجهاز: {ex.Message}";
//                return false;
//            }
//            finally
//            {
//                zkDevice.Disconnect();
//            }
//        }
//        private void btnFetchAttendance_Click(object sender, EventArgs e)
//        {
//            if (!CheckDeviceAccess(zkDevice, "150.150.4.201", 4370))
//            {
//                return;
//            }
//            try
//            {
//                // جلب بيانات الحضور والانصراف الجديدة
//               GetAttendanceData(zkDevice);

//                lblMessage.Text = "تم جلب بيانات الحضور والانصراف بنجاح!";
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = $"حدث خطأ: {ex.Message}";
//            }
//        }

//        private void GetAttendanceData(CZKEMClass zkDevice)
//        {
//            DateTime latestDateTimeInDB = GetLatestDateTimeFromDatabase();
//            string userID = "";
//            int verificationMode = 0;
//            int inOutMode = 0;
//            int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
//            int isValid = 0;

//            zkDevice.EnableDevice(1, false);

//            try
//            {
//                if (!zkDevice.ReadGeneralLogData(1))
//                {
//                    lblMessage.Text = "فشل في قراءة بيانات الحضور";
//                    return;
//                }

//                AppSetting setting = new AppSetting();
//                string connectionString = setting.GetConnectionString("cn");

//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    SqlTransaction transaction = connection.BeginTransaction();

//                    try
//                    {
//                        var attendanceList = new List<Attendance>();
//                        int recordCount = 0;

//                        while (zkDevice.SSR_GetGeneralLogData(1, out userID, out verificationMode, out inOutMode,
//                                                            out year, out month, out day, out hour, out minute, out second, ref isValid))
//                        {
//                            recordCount++;
//                            if (isValid == 1)
//                            {
//                                DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

//                                if (!IsRecordExists(userID, dateTime, connection, transaction))
//                                {
//                                    if (dateTime > latestDateTimeInDB)
//                                    {
//                                        InsertAttendanceToDatabase(userID, dateTime, verificationMode, inOutMode, connection, transaction);

//                                        attendanceList.Add(new Attendance
//                                        {
//                                            UserID = userID,
//                                            DateTime = dateTime,
//                                            VerificationMode = verificationMode,
//                                            InOutMode = inOutMode
//                                        });
//                                    }
//                                }
//                            }
//                        }

//                        transaction.Commit();

//                        this.Invoke((MethodInvoker)delegate
//                        {
//                            dgvAttendance.DataSource = null;
//                            dgvAttendance.DataSource = attendanceList;
//                            lblMessage.Text = $"تم جلب {attendanceList.Count} سجل جديد من {recordCount} سجل تم قراءته";
//                        });
//                    }
//                    catch (Exception ex)
//                    {
//                        transaction.Rollback();
//                        lblMessage.Text = $"حدث خطأ في قاعدة البيانات: {ex.Message}";
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                lblMessage.Text = $"حدث خطأ في الاتصال بالجهاز: {ex.Message}";
//            }
//            finally
//            {
//                zkDevice.EnableDevice(1, true);
//            }
//        }

//        private bool IsRecordExists(string userID, DateTime dateTime, SqlConnection connection, SqlTransaction transaction)
//        {
//            string query = "SELECT COUNT(*) FROM Attendance WHERE UserID = @UserID AND DateTime = @DateTime";

//            using (SqlCommand command = new SqlCommand(query, connection, transaction))
//            {
//                command.Parameters.AddWithValue("@UserID", userID);
//                command.Parameters.AddWithValue("@DateTime", dateTime);

//                int count = (int)command.ExecuteScalar();
//                return count > 0;
//            }
//        }

//        private void InsertAttendanceToDatabase(string userID, DateTime dateTime, int verificationMode, int inOutMode, SqlConnection connection, SqlTransaction transaction)
//        {
//            string query = "INSERT INTO Attendance (UserID, DateTime, VerificationMode, InOutMode) VALUES (@UserID, @DateTime, @VerificationMode, @InOutMode)";

//            using (SqlCommand command = new SqlCommand(query, connection, transaction))
//            {
//                command.Parameters.AddWithValue("@UserID", userID);
//                command.Parameters.AddWithValue("@DateTime", dateTime);
//                command.Parameters.AddWithValue("@VerificationMode", verificationMode);
//                command.Parameters.AddWithValue("@InOutMode", inOutMode);

//                try
//                {
//                    command.ExecuteNonQuery();
//                    Console.WriteLine("تم إدراج السجل بنجاح في قاعدة البيانات.");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"حدث خطأ أثناء إدراج البيانات: {ex.Message}");
//                    throw;
//                }
//            }
//        }

//        public class Attendance
//        {
//            public string UserID { get; set; }
//            public DateTime DateTime { get; set; }
//            public int VerificationMode { get; set; }
//            public int InOutMode { get; set; }
//        }
//        private DateTime GetLatestDateTimeFromDatabase()
//        {
//            AppSetting setting = new AppSetting();
//            string connectionString = setting.GetConnectionString("cn");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                string query = "SELECT ISNULL(MAX(DateTime), '1900-01-01') FROM Attendance";

//                SqlCommand command = new SqlCommand(query, connection);

//                try
//                {
//                    connection.Open();
//                    object result = command.ExecuteScalar();
//                    return result == DBNull.Value ? DateTime.MinValue : (DateTime)result;
//                }
//                catch (Exception ex)
//                {
//                    lblMessage.Text = $"خطأ أثناء استخراج آخر تاريخ: {ex.Message}";
//                    return DateTime.MinValue;
//                }
//            }
//        }
//    }
//}
//////////////////////////////////////////////////////////
//        private void GetAttendanceData(CZKEMClass zkDevice)
//        {
//            DateTime latestDateTimeInDB = GetLatestDateTimeFromDatabase();
//            string userID = "";
//            int verificationMode = 0;
//            int inOutMode = 0;
//            int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
//            int isValid = 0;

//            بدء استخراج بيانات الحضور والانصراف
//            zkDevice.ReadAllGLogData(1); // 1 يشير إلى رقم الجهاز

//            AppSetting setting = new AppSetting();
//            string connectionString = setting.GetConnectionString("cn"); using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlTransaction transaction = connection.BeginTransaction();
//                     public virtual bool SSR_GetGeneralLogData(int dwMachineNumber, out string dwEnrollNumber, out int dwVerifyMode, out int dwInOutMode, out int dwYear, out int dwMonth, out int dwDay, out int dwHour, out int dwMinute, out int dwSecond, ref int dwWorkCode);

//                try
//                {
//                    var attendanceList = new List<Attendance>();

//                    while (zkDevice.SSR_GetGeneralLogData(1, out userID, out verificationMode, out inOutMode,
//                                                          out year, out month, out day, out hour, out minute, out second, ref isValid))
//                    {
//                         التحقق مما إذا كانت البيانات صالحة
//                        if (isValid == 1)
//                        {
//                            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

//                            if (!IsRecordExists(userID, dateTime, connection, transaction))
//                            {
//                                if (dateTime > latestDateTimeInDB)
//                                {
//                                    Console.WriteLine($"جدول جديد: User ID: {userID}, DateTime: {dateTime}");

//                                     إدراج السجل في قاعدة البيانات
//                                    InsertAttendanceToDatabase(userID, dateTime, verificationMode, inOutMode, connection, transaction);

//        إضافة السجل إلى القائمة لعرضه في DataGridView
//       attendanceList.Add(new Attendance
//                                    {
//                                        UserID = userID,
//                                        DateTime = dateTime,
//                                        VerificationMode = verificationMode,
//                                        InOutMode = inOutMode
//    });
//                                }
//                                else
//                                {
//                                    Console.WriteLine($"السجل موجود بالفعل في قاعدة البيانات: User ID: {userID}, DateTime: {dateTime}");
//                                }
//                            }
//                        }


//                    }

//                     التزام المعاملة بعد الانتهاء
//                    transaction.Commit();

//                     عرض البيانات في DataGridView
//                    dgvAttendance.DataSource = attendanceList;
//                }
//                catch (Exception ex)
//                {
//                     التراجع عن المعاملة في حالة حدوث خطأ
//                    transaction.Rollback();
//lblMessage.Text = $"حدث خطأ: {ex.Message}";
//                }
//            }
//        }

//        private bool IsRecordExists(string userID, DateTime dateTime, SqlConnection connection, SqlTransaction transaction)
//{
//    string query = "SELECT COUNT(*) FROM Attendance WHERE UserID = @UserID AND DateTime = @DateTime";

//    using (SqlCommand command = new SqlCommand(query, connection, transaction))
//    {
//        command.Parameters.AddWithValue("@UserID", userID);
//        command.Parameters.AddWithValue("@DateTime", dateTime);

//        int count = (int)command.ExecuteScalar();
//        return count > 0;
//    }
//}



//private void InsertAttendanceToDatabase(string userID, DateTime dateTime, int verificationMode, int inOutMode, SqlConnection connection, SqlTransaction transaction)
//{
//    string query = "INSERT INTO Attendance (UserID, DateTime, VerificationMode, InOutMode) VALUES (@UserID, @DateTime, @VerificationMode, @InOutMode)";

//    using (SqlCommand command = new SqlCommand(query, connection, transaction))
//    {
//        command.Parameters.AddWithValue("@UserID", userID);
//        command.Parameters.AddWithValue("@DateTime", dateTime);
//        command.Parameters.AddWithValue("@VerificationMode", verificationMode);
//        command.Parameters.AddWithValue("@InOutMode", inOutMode);

//        try
//        {
//            command.ExecuteNonQuery();
//            Console.WriteLine("تم إدراج السجل بنجاح في قاعدة البيانات.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"حدث خطأ أثناء إدراج البيانات: {ex.Message}");
//        }
//    }
//}



//public class Attendance
//{
//    public string UserID { get; set; }
//    public DateTime DateTime { get; set; }
//    public int VerificationMode { get; set; }
//    public int InOutMode { get; set; }
//}


//private void btnFetchAttendance_Click(object sender, EventArgs e)
//{
//    if (!isConnected)
//    {
//        lblMessage.Text = "الجهاز غير متصل!";
//        return;
//    }

//    try
//    {
//        zkDevice.EnableDevice(1, false); // تعطيل الجهاز أثناء القراءة
//        Thread.Sleep(1000); // تأخير للتأكد من تهيئة الجهاز

//        List<Attendance> attendanceList = new List<Attendance>();

//        // قراءة جميع السجلات
//        if (!zkDevice.ReadAllGLogData(1))
//        {
//            lblMessage.Text = "لا توجد سجلات في الجهاز!";
//            return;
//        }

//        int recordCount = 0;
//        int invalidRecords = 0;
//        int isValid = 0;

//        while (zkDevice.SSR_GetGeneralLogData(1, out string userID, out int verifyMode, out int inOutMode,
//                                              out int year, out int month, out int day, out int hour, out int minute, out int second, ref isValid))
//        {
//            Console.WriteLine($"UserID: {userID}, isValid: {isValid}");
//            recordCount++;
//            if (isValid == 0)
//            {
//                DateTime dateTime = new DateTime(year, month, day, hour, minute, second);

//                // تجنب السجلات المكررة
//                if (!IsRecordExists(userID, dateTime))
//                {
//                    //InsertAttendanceToDatabase(userID, dateTime, verifyMode, inOutMode);
//                    //attendanceList.Add(new Attendance { UserID = userID, DateTime = dateTime, VerificationMode = verifyMode, InOutMode = inOutMode });
//                }
//            }
//            else
//            {
//                invalidRecords++;
//            }
//        }

//        // تحديث واجهة المستخدم
//        dgvAttendance.DataSource = attendanceList;
//        lblMessage.Text = $"تم جلب {attendanceList.Count} سجل جديد من {recordCount} سجل (وتم تجاهل {invalidRecords} سجل غير صالح).";
//    }
//    catch (Exception ex)
//    {
//        lblMessage.Text = $"حدث خطأ: {ex.Message}";
//    }
//    finally
//    {
//        zkDevice.EnableDevice(1, true); // إعادة تفعيل الجهاز
//    }
//}










