using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fingerprint1.view
{
    public partial class SchedulesForm : Form
    {
      //  private string connectionString = "Server=DESKTOP-3F7NFV1\\ABUBAKR;Database=NEW_FingerprintDB;Integrated Security=True;";

        public class ShiftItem
        {
            public int ShiftID { get; set; }
            public string ShiftName { get; set; }
        }
       // هاذا يخزن الايدي حق الفتره الي اختارها لكي يخزنه واضافه للوارديه ولي ايام الاسبوع 


        public SchedulesForm()
        {
            InitializeComponent();
            LoadSchedules();
            LoadShifts();



        dataveiw();
        AddIconColumn(); // إضافة العمود الجديد
            dgvSchedules.CellPainting += DgvShifts_CellPainting; // ربط حدث الرسم
            }

        // دالة إضافة العمود الجديد
        private void AddIconColumn()
        {
            DataGridViewImageColumn iconCol = new DataGridViewImageColumn();
            iconCol.HeaderText = "";
            iconCol.Width = 20; // تحديد العرض المطلوب
            iconCol.ImageLayout = DataGridViewImageCellLayout.Normal;
            dgvSchedules.Columns.Insert(0, iconCol); // إدراجه كأول عمود
        }

        // حدث رسم الأيقونة
        private void DgvShifts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex >= 0 && !dgvSchedules.Rows[e.RowIndex].IsNewRow)
        {
            e.PaintBackground(e.CellBounds, true);

            // الحصول على اسم الفترة
            string ScheduleName = dgvSchedules.Rows[e.RowIndex].Cells["ScheduleName"].Value?.ToString() ?? "";
            char firstChar = string.IsNullOrEmpty(ScheduleName) ? '?' : ScheduleName[0];

            // توليد اللون
            Color circleColor = GenerateColor(ScheduleName);

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
    private void dataveiw()
        {

            dgvSchedules.DataBindingComplete += (sender, e) =>
            {
                // SELECT ShiftID, ShiftName, StartTime, EndTime, CheckInGracePeriod, CheckOutGracePeriod, CheckInStart, CheckInEnd
                // إخفاء العمود DiscountID
                if (dgvSchedules.Columns.Contains("ScheduleID"))
                    dgvSchedules.Columns["ScheduleID"].HeaderText = "معرف الواردية";
                if (dgvSchedules.Columns.Contains("ShiftID"))
                    dgvSchedules.Columns["ShiftID"].Visible = false;
                // تغيير عناوين الأعمدة
                if (dgvSchedules.Columns.Count > 0)
                {
                    // العمود الأول (الأيقونة) - عرض ثابت
                    dgvSchedules.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvSchedules.Columns[0].Width = 50; // عرض ثابت

                    // باقي الأعمدة - ملء المساحة
                    for (int i = 1; i < dgvSchedules.Columns.Count; i++)
                    {
                        dgvSchedules.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

                // تغيير عناوين الأعمدة
                if (dgvSchedules.Columns.Contains("ScheduleName"))
                { dgvSchedules.Columns["ScheduleName"].HeaderText = "اسم الواردية"; }

                if (dgvSchedules.Columns.Contains("StartDate"))
                    dgvSchedules.Columns["StartDate"].HeaderText = "تاريخ بدء الوردية";

                if (dgvSchedules.Columns.Contains("EndDate"))
                    dgvSchedules.Columns["EndDate"].HeaderText = "تاريخ انتهاء الوردية ";
                if (dgvSchedules.Columns.Contains("ShiftName"))
                    dgvSchedules.Columns["ShiftName"].HeaderText = "نوع الفترة ";
                

            };
            dgvSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvSchedules.Font = new Font("Arial", 11);
            dgvSchedules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //dgvSchedules.Size = new Size(ClientSize.Width - 40, ClientSize.Height - 110);
            dgvSchedules.ReadOnly = true;
            dgvSchedules.BackgroundColor = Color.White;
            dgvSchedules.BorderStyle = BorderStyle.None;
            dgvSchedules.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSchedules.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSchedules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedules.Dock = DockStyle.Bottom;
           dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedules.RightToLeft = RightToLeft.Yes;

           // dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // تنسيق رأس الجدول
            dgvSchedules.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgvSchedules.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSchedules.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            dgvSchedules.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSchedules.ColumnHeadersHeight = 40;

            // تنسيق الصفوف
            dgvSchedules.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 65, 89);
            dgvSchedules.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSchedules.DefaultCellStyle.Padding = new Padding(5);
            dgvSchedules.RowTemplate.Height = 35;

            dgvSchedules.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);

        }
        private void LoadSchedules()
        {
            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    using (var adapter = new SqlDataAdapter(
                        @"SELECT s.ScheduleID, s.ScheduleName, s.StartDate, s.EndDate, sh.ShiftID, sh.ShiftName 
                      FROM Schedules s
                      INNER JOIN Shifts sh ON s.ShiftID = sh.ShiftID", connection))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSchedules.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الجداول: {ex.Message}");
            }
        }
        //هاذا عرض الوارديات  في الجدول 
        private void LoadShifts()
        {

            try
            {
                cmbShifts.Items.Clear();
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("SELECT ShiftID, ShiftName FROM Shifts", connection))
                    {
                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbShifts.Items.Add(new ShiftItem
                                {
                                    ShiftID = reader.GetInt32(0),
                                    ShiftName = reader.GetString(1)
                                });
                            }
                        }
                    }
                    cmbShifts.DisplayMember = "ShiftName";
                    cmbShifts.ValueMember = "ShiftID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الفترات: {ex.Message}");
            }
            }
        


        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSchedules.Rows[e.RowIndex];
            txtScheduleName.Text = row.Cells["ScheduleName"].Value?.ToString() ?? "";
            dtpStartDate.Value = (DateTime)(row.Cells["StartDate"].Value ?? DateTime.Now);
            dtpEndDate.Value = (DateTime)(row.Cells["EndDate"].Value ?? DateTime.Now);

            var shiftId = (int)row.Cells["ShiftID"].Value;
            foreach (ShiftItem item in cmbShifts.Items)
            {
                if (item.ShiftID == shiftId)
                {
                    cmbShifts.SelectedItem = item;
                    LoadWorkingDays(shiftId);
                    break;
                }
            }
        }
      
        private void LoadWorkingDays(int shiftId)
        {
            checkedListBoxDays.Items.Clear();
            string[] days = { "الأحد", "الاثنين", "الثلاثاء", "الأربعاء", "الخميس", "الجمعة", "السبت" };
            checkedListBoxDays.Items.AddRange(days);

            try
            {
                AppSetting setting = new AppSetting();
                string connectionString = setting.GetConnectionString("cn");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(
                    "SELECT DayOfWeek FROM ShiftWorkingDays WHERE ShiftID = @shiftId", connection))
                    {
                        cmd.Parameters.AddWithValue("@shiftId", shiftId);
                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var day = reader.GetString(0);
                                var index = Array.IndexOf(days, day);
                                if (index >= 0) checkedListBoxDays.SetItemChecked(index, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في تحميل الأيام: {ex.Message}");
            }
        }
        // هاذا يعرض لي اسماء الايام 
      private void btnAdd_Click(object sender, EventArgs e)
{
    if (cmbShifts.SelectedItem == null)
    {
        MessageBox.Show("اختر فترة زمنية");
        return;
    }

    var shift = (ShiftItem)cmbShifts.SelectedItem;

            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction()) // يجب أن تكون داخل نطاق الاتصال
                    {
                        try
                        {
                            // إضافة Schedule
                            var cmdInsert = new SqlCommand(
                                @"INSERT INTO Schedules (ScheduleName, StartDate, EndDate, ShiftID)
                      VALUES (@name, @start, @end, @shiftId);
                      SELECT SCOPE_IDENTITY();",
                                connection,
                                transaction);

                            cmdInsert.Parameters.AddWithValue("@name", txtScheduleName.Text);
                            cmdInsert.Parameters.AddWithValue("@start", dtpStartDate.Value.Date);
                            cmdInsert.Parameters.AddWithValue("@end", dtpEndDate.Value.Date);
                            cmdInsert.Parameters.AddWithValue("@shiftId", shift.ShiftID);

                            var scheduleId = Convert.ToInt32(cmdInsert.ExecuteScalar());

                            // إضافة الأيام
                            SaveWorkingDays(shift.ShiftID, connection, transaction);

                            transaction.Commit();
                            LoadSchedules();
                            MessageBox.Show("تمت الإضافة بنجاح");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"خطأ في الإضافة: {ex.Message}");
                        }
                    }
                }
            
}
        // داله الحفظ -الاضافة 
        private void SaveWorkingDays(int shiftId, SqlConnection connection, SqlTransaction transaction)
        {
            var cmdDelete = new SqlCommand(
                "DELETE FROM ShiftWorkingDays WHERE ShiftID = @shiftId",
                connection, transaction);
            cmdDelete.Parameters.AddWithValue("@shiftId", shiftId);
            cmdDelete.ExecuteNonQuery();

            foreach (string day in checkedListBoxDays.CheckedItems)
            {
                var cmdInsert = new SqlCommand(
                    "INSERT INTO ShiftWorkingDays (ShiftID, DayOfWeek) VALUES (@shiftId, @day)",
                    connection, transaction);
                cmdInsert.Parameters.AddWithValue("@shiftId", shiftId);
                cmdInsert.Parameters.AddWithValue("@day", day);
                cmdInsert.ExecuteNonQuery();
            }
        }
      //  داله  اضافة الايام 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 0 || cmbShifts.SelectedItem == null)
            {
                MessageBox.Show("اختر عنصرًا للتعديل");
                return;
            }

            var shift = (ShiftItem)cmbShifts.SelectedItem;
            var scheduleId = (int)dgvSchedules.SelectedRows[0].Cells["ScheduleID"].Value;

            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            
                {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var cmdUpdate = new SqlCommand(
                            @"UPDATE Schedules 
                    SET ScheduleName = @name, 
                        StartDate = @start, 
                        EndDate = @end, 
                        ShiftID = @shiftId 
                    WHERE ScheduleID = @id",
                            connection,
                            transaction);

                        cmdUpdate.Parameters.AddWithValue("@name", txtScheduleName.Text);
                        cmdUpdate.Parameters.AddWithValue("@start", dtpStartDate.Value.Date);
                        cmdUpdate.Parameters.AddWithValue("@end", dtpEndDate.Value.Date);
                        cmdUpdate.Parameters.AddWithValue("@shiftId", shift.ShiftID);
                        cmdUpdate.Parameters.AddWithValue("@id", scheduleId);

                        cmdUpdate.ExecuteNonQuery();

                        SaveWorkingDays(shift.ShiftID, connection, transaction);

                        transaction.Commit();
                        LoadSchedules();
                        MessageBox.Show("تم التحديث بنجاح");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"خطأ في التحديث: {ex.Message}");
                    }
                }
            }
        }
       // داله التعديل 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 0)
            {
                MessageBox.Show("اختر عنصرًا للحذف");
                return;
            }

            var scheduleId = (int)dgvSchedules.SelectedRows[0].Cells["ScheduleID"].Value;
            var shiftId = (int)dgvSchedules.SelectedRows[0].Cells["ShiftID"].Value;

            AppSetting setting = new AppSetting();
            string connectionString = setting.GetConnectionString("cn");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction()) // 2. بدء المعاملة بعد فتح الاتصال
                {
                    try
                    {
                        // 3. حذف الأيام المرتبطة أولاً (إن كانت تابعة للجدول)
                        var cmdDeleteDays = new SqlCommand(
                            "DELETE FROM ShiftWorkingDays WHERE ShiftID = @shiftId",
                            connection,
                            transaction);
                        cmdDeleteDays.Parameters.AddWithValue("@shiftId", shiftId);
                        cmdDeleteDays.ExecuteNonQuery();

                        // 4. حذف الجدول الرئيسي
                        var cmdDelete = new SqlCommand(
                            "DELETE FROM Schedules WHERE ScheduleID = @id",
                            connection,
                            transaction);
                        cmdDelete.Parameters.AddWithValue("@id", scheduleId);
                        cmdDelete.ExecuteNonQuery();

                        transaction.Commit();
                        LoadSchedules();
                        MessageBox.Show("تم الحذف بنجاح");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"خطأ في الحذف: {ex.Message}");
                    }
                }
            }
        }
        //داله الحذف 
    }
}