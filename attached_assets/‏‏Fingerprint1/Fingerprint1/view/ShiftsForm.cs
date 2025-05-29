using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class ShiftsForm : Form
    {
       // private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

    
            // ... الكود الحالي ...

            public ShiftsForm()
            {
                InitializeComponent();
                LoadShifts();
                dataveiw();
                AddIconColumn(); // إضافة العمود الجديد
                dgvShifts.CellPainting += DgvShifts_CellPainting; // ربط حدث الرسم
            }

        // دالة إضافة العمود الجديد
        private void AddIconColumn()
        {
            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.HeaderText = "";
            iconCol.Width = 50; // تحديد العرض المطلوب
            iconCol.ImageLayout = DataGridViewImageCellLayout.Normal;
            dgvShifts.Columns.Insert(0, iconCol); // إدراجه كأول عمود
        }

        // حدث رسم الأيقونة
        private void DgvShifts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && !dgvShifts.Rows[e.RowIndex].IsNewRow)
            {
                e.PaintBackground(e.CellBounds, true);

                // الحصول على اسم الفترة
                string shiftName = dgvShifts.Rows[e.RowIndex].Cells["ShiftName"].Value?.ToString() ?? "";
                char firstChar = string.IsNullOrEmpty(shiftName) ? '?' : shiftName[0];

                // توليد اللون
                Color circleColor = GenerateColor(shiftName);

                // رسم الدائرة -------------------------------------------
                using (SolidBrush brush = new SolidBrush(circleColor))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    // تحديد حجم الدائرة (بناءً على أصغر قيمة بين العرض والارتفاع)
                    int circleDiameter = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 8;

                    // حساب الإحداثيات لجعل الدائرة في المنتصف
                    int x = e.CellBounds.Left + (e.CellBounds.Width - circleDiameter) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - circleDiameter) / 2;

                    // رسم الدائرة
                    e.Graphics.FillEllipse(brush, x, y, circleDiameter, circleDiameter);
                }

                // رسم الحرف ---------------------------------------------
                using (Font font = new Font("Arial", 10, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat();
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    // تحديد المستطيل المركزي (نفس مكان الدائرة)
                    Rectangle rect = new Rectangle(
                        e.CellBounds.Left,
                        e.CellBounds.Top,
                        e.CellBounds.Width,
                        e.CellBounds.Height
                    );

                    // رسم الحرف في المنتصف تمامًا
                    e.Graphics.DrawString(
                        firstChar.ToString().ToUpper(),
                        font,
                        textBrush,
                        rect,
                        sf
                    );
                }

                e.Handled = true;
            }
        }

        // توليد لون ثابت من الاسم
        private Color GenerateColor(string input)
        {
            Random rand = new Random(input.GetHashCode());

            // توليد درجة لونية (Hue) بين 0 و 360
            float hue = rand.Next(0, 360);

            // إبقاء التشبع (Saturation) واللمعان (Lightness) ثابتين
            return FromHsl(hue, 0.7f, 0.6f);
        }

        // دالة لتحويل HSL إلى Color
        private Color FromHsl(float h, float s, float l)
        {
            float q = l < 0.5f ? l * (1 + s) : l + s - l * s;
            float p = 2 * l - q;

            float r = HueToRgb(p, q, h + 120f);
            float g = HueToRgb(p, q, h);
            float b = HueToRgb(p, q, h - 120f);

            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        private float HueToRgb(float p, float q, float t)
        {
            if (t < 0) t += 360;
            if (t > 360) t -= 360;

            if (t < 60) return p + (q - p) * t / 60;
            if (t < 180) return q;
            if (t < 240) return p + (q - p) * (240 - t) / 60;
            return p;
        }
        // ... باقي الكود الحالي ...

        private void dataveiw()
        {
            
            dgvShifts.DataBindingComplete += (sender, e) =>
            {
               // SELECT ShiftID, ShiftName, StartTime, EndTime, CheckInGracePeriod, CheckOutGracePeriod, CheckInStart, CheckInEnd
                // إخفاء العمود DiscountID
                if (dgvShifts.Columns.Contains("ShiftID"))
                    dgvShifts.Columns["ShiftID"].Visible = false;

                // تغيير عناوين الأعمدة
                if (dgvShifts.Columns.Contains("ShiftName"))
                {
                    dgvShifts.Columns["ShiftName"].HeaderText = "اسم الفترة";
                }
                if (dgvShifts.Columns.Count > 0)
                {
                    // العمود الأول (الأيقونة) - عرض ثابت
                    dgvShifts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvShifts.Columns[0].Width = 50; // عرض ثابت

                    // باقي الأعمدة - ملء المساحة
                    for (int i = 1; i < dgvShifts.Columns.Count; i++)
                    {
                        dgvShifts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

                if (dgvShifts.Columns.Contains("StartTime"))
                    dgvShifts.Columns["StartTime"].HeaderText = " وقت بدء العمل ";

                if (dgvShifts.Columns.Contains("EndTime"))
                    dgvShifts.Columns["EndTime"].HeaderText = "وقت انتهاء العمل ";
                if (dgvShifts.Columns.Contains("CheckInGracePeriod"))
                    dgvShifts.Columns["CheckInGracePeriod"].HeaderText = "سماحية الحضور ";
                if (dgvShifts.Columns.Contains("CheckOutGracePeriod"))
                    dgvShifts.Columns["CheckOutGracePeriod"].HeaderText = " سماحية الانصراف";
                if (dgvShifts.Columns.Contains("CheckInStart"))
                    dgvShifts.Columns["CheckInStart"].HeaderText = "بداية فترة الحضور ";
                if (dgvShifts.Columns.Contains("CheckInEnd"))
                    dgvShifts.Columns["CheckInEnd"].HeaderText = "نهاية فترة الانصراف ";
                //if (dgvShifts.Columns.Contains("DiscountAmount"))
                //{
                //    dgvShifts.Columns["DiscountAmount"].HeaderText = "مبلغ الخصم";
                //   // dgvShifts.Columns["DiscountAmount"].DefaultCellStyle.Format = "N2";
                //}
            };
            dgvShifts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvShifts.Font = new Font("Arial", 11);
            dgvShifts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //dgvShifts.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvShifts.ReadOnly = true;
            dgvShifts.BackgroundColor = Color.White;
            dgvShifts.BorderStyle = BorderStyle.None;
            dgvShifts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvShifts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvShifts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShifts.Dock = DockStyle.Bottom;
            dgvShifts. AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShifts.RightToLeft = RightToLeft.Yes;

            // تنسيق رأس الجدول
            dgvShifts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvShifts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvShifts.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvShifts.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvShifts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvShifts.ColumnHeadersHeight = 40;

            // تنسيق الصفوف
            dgvShifts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvShifts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvShifts.DefaultCellStyle.Padding = new Padding(5);
            dgvShifts.RowTemplate.Height = 35;
            
            dgvShifts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);

        }
      

        private void LoadShifts()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ShiftID, ShiftName, StartTime, EndTime, CheckInGracePeriod, CheckOutGracePeriod, CheckInStart, CheckInEnd FROM Shifts";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    dgvShifts.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحميل الفترات: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Shifts (ShiftName, StartTime, EndTime, CheckInGracePeriod, CheckOutGracePeriod, CheckInStart, CheckInEnd)
                        VALUES (@ShiftName, @StartTime, @EndTime, @CheckInGracePeriod, @CheckOutGracePeriod, @CheckInStart, @CheckInEnd)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShiftName", txtShiftName.Text);
                    command.Parameters.AddWithValue("@StartTime", TimeSpan.Parse(txtStartTime.Text));
                    command.Parameters.AddWithValue("@EndTime", TimeSpan.Parse(txtEndTime.Text));
                    command.Parameters.AddWithValue("@CheckInGracePeriod", int.Parse(txtCheckInGracePeriod.Text));
                    command.Parameters.AddWithValue("@CheckOutGracePeriod", int.Parse(txtCheckOutGracePeriod.Text));
                    command.Parameters.AddWithValue("@CheckInStart", TimeSpan.Parse(txtCheckInStart.Text));
                    command.Parameters.AddWithValue("@CheckInEnd", TimeSpan.Parse(txtCheckInEnd.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تمت إضافة الفترة بنجاح!");
                LoadShifts(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء إضافة الفترة: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvShifts.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد فترة لتعديلها.");
                return;
            }

            try
            {
                int shiftID = Convert.ToInt32(dgvShifts.SelectedRows[0].Cells["ShiftID"].Value);

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Shifts
                        SET ShiftName = @ShiftName,
                            StartTime = @StartTime,
                            EndTime = @EndTime,
                            CheckInGracePeriod = @CheckInGracePeriod,
                            CheckOutGracePeriod = @CheckOutGracePeriod,
                            CheckInStart = @CheckInStart,
                            CheckInEnd = @CheckInEnd
                        WHERE ShiftID = @ShiftID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShiftID", shiftID);
                    command.Parameters.AddWithValue("@ShiftName", txtShiftName.Text);
                    command.Parameters.AddWithValue("@StartTime", TimeSpan.Parse(txtStartTime.Text));
                    command.Parameters.AddWithValue("@EndTime", TimeSpan.Parse(txtEndTime.Text));
                    command.Parameters.AddWithValue("@CheckInGracePeriod", int.Parse(txtCheckInGracePeriod.Text));
                    command.Parameters.AddWithValue("@CheckOutGracePeriod", int.Parse(txtCheckOutGracePeriod.Text));
                    command.Parameters.AddWithValue("@CheckInStart", TimeSpan.Parse(txtCheckInStart.Text));
                    command.Parameters.AddWithValue("@CheckInEnd", TimeSpan.Parse(txtCheckInEnd.Text));

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم تحديث الفترة بنجاح!");
                LoadShifts(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث الفترة: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShifts.SelectedRows.Count == 0)
            {
                MessageBox.Show("يرجى تحديد فترة لحذفها.");
                return;
            }

            try
            {
                int shiftID = Convert.ToInt32(dgvShifts.SelectedRows[0].Cells["ShiftID"].Value);

                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Shifts WHERE ShiftID = @ShiftID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ShiftID", shiftID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("تم حذف الفترة بنجاح!");
                LoadShifts(); // تحديث الجدول
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حذف الفترة: {ex.Message}");
            }
        }

        private void dgvShifts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvShifts.Rows[e.RowIndex];
                txtShiftName.Text = selectedRow.Cells["ShiftName"].Value.ToString();
                txtStartTime.Text = ((TimeSpan)selectedRow.Cells["StartTime"].Value).ToString(@"hh\:mm");
                txtEndTime.Text = ((TimeSpan)selectedRow.Cells["EndTime"].Value).ToString(@"hh\:mm");
                txtCheckInGracePeriod.Text = selectedRow.Cells["CheckInGracePeriod"].Value.ToString();
                txtCheckOutGracePeriod.Text = selectedRow.Cells["CheckOutGracePeriod"].Value.ToString();
                txtCheckInStart.Text = ((TimeSpan)selectedRow.Cells["CheckInStart"].Value).ToString(@"hh\:mm");
                txtCheckInEnd.Text = ((TimeSpan)selectedRow.Cells["CheckInEnd"].Value).ToString(@"hh\:mm");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadShifts();
        }

    }
}