using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zkemkeeper;

namespace Fingerprint1.view
{
   
        public partial class SetGroupTZApp : Form
        {
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        private bool bAddControl = true;
        private bool bIsConnected;
        private TextBox txtIP;
        private Label lblState;
        private Label label112;
        private Button btnConnect;
        private TextBox txtPort;
        private Label label111;
        private TabPage tabPage2;
        private int iMachineNumber = 1;
        private TabControl tabControl;
        public SetGroupTZApp()
            {
                InitializeComponent();
            InitializeComponent1();
            //CZKEMClass zkem = new CZKEMClass();
            //bool isConnected = zkem.Connect_Net("150.150.4.201", 4370);
            //lblMessage.Text = isConnected ? "متصل بالجهاز" : "فشل الاتصال";

            //if (!isConnected)
            //{
            //    Console.WriteLine("فشل الاتصال بالجهاز.");
            //    return;
            //}

            //Console.WriteLine("تم الاتصال بالجهاز بنجاح.");


        }
        private void InitializeComponent1()
        {
            // Initialize the form
            this.Text = "تطبيق الاتصال";
          //  this.Size = new Size(1300, 150);

            this.tabControl = new TabControl();
            this.tabControl.Location = new Point(10, 10);
            this.tabControl.Size = new Size(1280, 150);
            this.tabControl.Name = "tabControl";
            // TextBox for IP Address
            this.txtIP = new TextBox();
            this.txtIP.Location = new Point(853, 10);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new Size(148, 26);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "192.168.1.201";

            // Label for State
            this.lblState = new Label();
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = Color.Crimson;
            this.lblState.Location = new Point(232, 14);
            this.lblState.Name = "lblState";
            this.lblState.Size = new Size(214, 18);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "الحالة الحالية: غير متصل";

            // Label for Port Number
            this.label112 = new Label();
            this.label2.AutoSize = true;
            this.label112.Location = new Point(739, 13);
            this.label112.Name = "label112";
            this.label112.Size = new Size(87, 18);
            this.label112.TabIndex = 9;
            this.label112.Text = "رقم المنفذ:";

            // Button for Connect
            this.btnConnect = new Button();
            this.btnConnect.Location = new Point(529, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new Size(96, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "اتصال";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new EventHandler(this.btnConnect_Click);

            // TextBox for Port
            this.txtPort = new TextBox();
            this.txtPort.Location = new Point(671, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new Size(62, 26);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "4370";

            // Label for IP Address
            this.label111 = new Label();
            this.label111.AutoSize = true;
            this.label111.Location = new Point(1011, 13);
            this.label111.Name = "label111";
            this.label111.Size = new Size(99, 18);
            this.label111.TabIndex = 8;
            this.label111.Text = "عنوان الأيبي:";

            // TabPage for additional settings
            this.tabPage2 = new TabPage();
            this.tabPage2.BackColor = Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.txtIP);
            this.tabPage2.Controls.Add(this.lblState);
            this.tabPage2.Controls.Add(this.label112);
            this.tabPage2.Controls.Add(this.btnConnect);
            this.tabPage2.Controls.Add(this.txtPort);
            this.tabPage2.Controls.Add(this.label111);
            this.tabPage2.ForeColor = Color.DarkBlue;
            this.tabPage2.Location = new Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new Padding(3);
            this.tabPage2.Size = new Size(1247, 47);
            this.tabPage2.TabIndex = 1;

            // Add controls to the form

            // Add TabPage to TabControl
            this.tabControl.TabPages.Add(this.tabPage2);

            // Add TabControl to the form
            this.Controls.Add(this.tabControl);
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
                    this.axCZKEM1.Disconnect();
                    this.bIsConnected = false;
                    this.btnConnect.Text = " اتصال";
                    this.lblState.Text = "Current State:فصل الاتصال";
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.bIsConnected = this.axCZKEM1.Connect_Net(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text));
                    if (this.bIsConnected)
                    {
                        this.btnConnect.Text = "فصل الاتصال";
                        this.btnConnect.Refresh();
                        this.lblState.Text = "Current State:اتصال";
                        this.iMachineNumber = 1;
                        this.axCZKEM1.RegEvent(this.iMachineNumber, (int)ushort.MaxValue);
                    }
                    else
                    {
                        this.axCZKEM1.GetLastError(ref dwErrorCode);
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
                            this.axCZKEM1.Disconnect();
                            this.bIsConnected = false;
                            this.btnConnect.Text = "Connect";
                            this.lblState.Text = "Current State:DisConnected";
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            this.bIsConnected = this.axCZKEM1.Connect_Net(this.txtIP.Text, Convert.ToInt32(this.txtPort.Text));
                            if (this.bIsConnected)
                            {
                                this.btnConnect.Text = "DisConnect";
                                this.btnConnect.Refresh();
                                this.lblState.Text = "Current State:Connected";
                                this.iMachineNumber = 1;
                                if (!this.axCZKEM1.RegEvent(this.iMachineNumber, (int)ushort.MaxValue))
                                    ;
                            }
                            else
                            {
                                this.axCZKEM1.GetLastError(ref dwErrorCode);
                                int num4 = (int)MessageBox.Show("غير قادر على توصيل الجهاز ، رمز الخطأ=" + dwErrorCode.ToString(), "Error");
                            }
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        //static int CalculateTimeDifference(int startHour, int startMinute, int endHour, int endMinute)
        //{
        //    // حساب وقت البداية بالثواني منذ منتصف الليل
        //    int startTimeInSeconds = startHour * 3600 + startMinute * 60;

        //    // حساب وقت النهاية بالثواني منذ منتصف الليل
        //    int endTimeInSeconds = endHour * 3600 + endMinute * 60;

        //    string combinedValue = startTimeInSeconds.ToString() + endTimeInSeconds.ToString();


        //    return int.Parse(combinedValue);
        //}
        static Int64 CalculateTimeDifference(int startHour, int startMinute, int endHour, int endMinute)
        {
            // حساب وقت البداية بالثواني منذ منتصف الليل
            int startTimeInSeconds = startHour * 3600 + startMinute * 60;

            // حساب وقت النهاية بالثواني منذ منتصف الليل
            int endTimeInSeconds = endHour * 3600 + endMinute * 60;

            // حساب الفرق الزمني
            string combinedValue = startTimeInSeconds.ToString() + endTimeInSeconds.ToString();
           // Console.WriteLine($"Tz1: {combinedValue}");
            return Int64.Parse(combinedValue);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // قراءة المدخلات باستخدام int.TryParse
                if (!int.TryParse(txtGroupNo.Text, out int groupNo))
                {
                    MessageBox.Show("رقم المجموعة غير صحيح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtTz11.Text, out int tz11) ||
                    !int.TryParse(txtTz12.Text, out int tz12) ||
                    !int.TryParse(txtTz13.Text, out int tz13) ||
                    !int.TryParse(txtTz14.Text, out int tz14) ||
                    !int.TryParse(txtTz21.Text, out int tz21) ||
                    !int.TryParse(txtTz22.Text, out int tz22) ||
                    !int.TryParse(txtTz23.Text, out int tz23) ||
                    !int.TryParse(txtTz24.Text, out int tz24) ||
                    !int.TryParse(txtTz31.Text, out int tz31) ||
                    !int.TryParse(txtTz32.Text, out int tz32) ||
                    !int.TryParse(txtTz33.Text, out int tz33) ||
                    !int.TryParse(txtTz34.Text, out int tz34))
                {
                    MessageBox.Show("أحد الحقول الزمنية غير صحيح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // حساب الفرق الزمني

                //int tz11 = int.Parse(txtTz11.Text);
                //int tz12 = int.Parse(txtTz12.Text);
            


                Int64 Tz1 = CalculateTimeDifference(tz11, tz12, tz13, tz14);
              
                Int64 Tz2 = CalculateTimeDifference(tz21, tz22, tz23, tz24);
                Int64 Tz3 = CalculateTimeDifference(tz31, tz32, tz33, tz34);

                bool validHoliday = chkValidHoliday.Checked;
                int verifyStyle = cmbVerifyStyle.SelectedIndex + 1; // Assuming 1-based index

                    // عرض النتائج
                    txtTz1.Text = Tz1.ToString();
                    txtTz2.Text = Tz2.ToString();
                    txtTz3.Text = Tz3.ToString();


                // tz1 = int.Parse(txtTz1.Text);
                //int tz2 = int.Parse(txtTz2.Text);
                //int tz3 = int.Parse(txtTz3.Text);

                // Call the SetGroupTZ function
                CZKEMClass zkem = new CZKEMClass();
                bool result = zkem.SSR_SetGroupTZ(1, groupNo, (int)Tz1, (int)Tz2, (int)Tz3, validHoliday ? 1 : 0, verifyStyle);

                if (result)
                {
                    MessageBox.Show("تم حفظ الإعدادات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء حفظ الإعدادات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                zkem.Disconnect();
                MessageBox.Show("تم قطع الاتصال بالجهاز.");


              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"2حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // private void btnSave_Click(object sender, EventArgs e)

        //try
        //{
        //    // Read Inputs
        //    int groupNo = int.Parse(txtGroupNo.Text);
        //    int tz11 = int.Parse(txtTz11.Text);
        //    int tz12 = int.Parse(txtTz12.Text);
        //    int tz13 = int.Parse(txtTz13.Text);
        //    int tz14 = int.Parse(txtTz14.Text);

        //    int tz21 = int.Parse(txtTz21.Text);
        //    int tz22 = int.Parse(txtTz22.Text);
        //    int tz23 = int.Parse(txtTz23.Text);
        //    int tz24 = int.Parse(txtTz24.Text);

        //    int tz31 = int.Parse(txtTz31.Text);
        //    int tz32 = int.Parse(txtTz32.Text);
        //    int tz33 = int.Parse(txtTz33.Text);
        //    int tz34 = int.Parse(txtTz34.Text);

        //    //CalculateTimeZone
        //    int tz1 = CalculateTimeZone(tz11, tz12, tz13, tz14);
        //    int tz2 = CalculateTimeZone(tz21, tz22, tz23, tz24);
        //    int tz3 = CalculateTimeZone(tz31, tz32, tz33, tz34);

        //    bool validHoliday = chkValidHoliday.Checked;
        //    int verifyStyle = cmbVerifyStyle.SelectedIndex + 1; // Assuming 1-based index


        //txtTz1.Text = tz1.ToString();
        //txtTz2.Text = tz2.ToString();
        //txtTz3.Text = tz3.ToString();
        //// Call the SetGroupTZ function
        //CZKEMClass zkem = new CZKEMClass();
        //  bool result = zkem.SSR_SetGroupTZ(1, groupNo, tz1, tz2, tz3, validHoliday ? 1 : 0, verifyStyle);

        //if (result)
        //{
        //    MessageBox.Show("تم حفظ الإعدادات بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //else
        //{
        //    MessageBox.Show("حدث خطأ أثناء حفظ الإعدادات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //}
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"2حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        // }

        private void txtTz11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz11.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz12.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz13.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz14.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTz21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz21.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz22.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz23.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz24.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }


        private void txtTz31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz31.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz32.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz33.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void txtTz34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // منع الإدخال
                return;
            }

            // منع الكتابة إذا كان النص يحتوي بالفعل على رقمين
            if (txtTz34.Text.Length >= 2 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

      
    }
    }

