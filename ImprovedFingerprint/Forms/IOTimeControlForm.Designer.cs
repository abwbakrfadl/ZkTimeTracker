using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ImprovedFingerprint.Forms
{
    partial class IOTimeControlForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            
            // Morning Shift Controls
            this.groupControlMorning = new DevExpress.XtraEditors.GroupControl();
            this.timeEditMorningInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningOutEnd = new DevExpress.XtraEditors.TimeEdit();
            
            // Evening Shift Controls
            this.groupControlEvening = new DevExpress.XtraEditors.GroupControl();
            this.timeEditEveningInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningOutEnd = new DevExpress.XtraEditors.TimeEdit();
            
            // Night Shift Controls
            this.groupControlNight = new DevExpress.XtraEditors.GroupControl();
            this.timeEditNightInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightOutEnd = new DevExpress.XtraEditors.TimeEdit();
            
            // Buttons
            this.btnApplyToDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadFromDatabase = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMorning)).BeginInit();
            this.groupControlMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEvening)).BeginInit();
            this.groupControlEvening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNight)).BeginInit();
            this.groupControlNight.SuspendLayout();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlMorning);
            this.layoutControl1.Controls.Add(this.groupControlEvening);
            this.layoutControl1.Controls.Add(this.groupControlNight);
            this.layoutControl1.Controls.Add(this.btnApplyToDevice);
            this.layoutControl1.Controls.Add(this.btnTestSettings);
            this.layoutControl1.Controls.Add(this.btnLoadFromDatabase);
            this.layoutControl1.Controls.Add(this.btnReset);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 650);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 650);
            this.Root.TextVisible = false;
            
            // Setup Groups and Controls
            SetupMorningGroup();
            SetupEveningGroup();
            SetupNightGroup();
            SetupButtons();
            SetupLayout();
            
            // IOTimeControlForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOTimeControlForm";
            this.Text = "ضبط أوقات الدخول والخروج - الفترات الثلاث";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMorning)).EndInit();
            this.groupControlMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEvening)).EndInit();
            this.groupControlEvening.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNight)).EndInit();
            this.groupControlNight.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private void SetupMorningGroup()
        {
            this.groupControlMorning.Text = "🌅 الفترة الصباحية (6:00 - 13:00)";
            this.groupControlMorning.Location = new System.Drawing.Point(12, 12);
            this.groupControlMorning.Size = new System.Drawing.Size(776, 140);
            
            SetupTimeEditInGroup(this.timeEditMorningInStart, "بداية الدخول الصباحي:", 20, 30, this.groupControlMorning);
            SetupTimeEditInGroup(this.timeEditMorningInEnd, "نهاية الدخول الصباحي:", 20, 60, this.groupControlMorning);
            SetupTimeEditInGroup(this.timeEditMorningOutStart, "بداية الخروج الصباحي:", 400, 30, this.groupControlMorning);
            SetupTimeEditInGroup(this.timeEditMorningOutEnd, "نهاية الخروج الصباحي:", 400, 60, this.groupControlMorning);
        }
        
        private void SetupEveningGroup()
        {
            this.groupControlEvening.Text = "🌆 الفترة المسائية (14:00 - 21:00)";
            this.groupControlEvening.Location = new System.Drawing.Point(12, 156);
            this.groupControlEvening.Size = new System.Drawing.Size(776, 140);
            
            SetupTimeEditInGroup(this.timeEditEveningInStart, "بداية الدخول المسائي:", 20, 30, this.groupControlEvening);
            SetupTimeEditInGroup(this.timeEditEveningInEnd, "نهاية الدخول المسائي:", 20, 60, this.groupControlEvening);
            SetupTimeEditInGroup(this.timeEditEveningOutStart, "بداية الخروج المسائي:", 400, 30, this.groupControlEvening);
            SetupTimeEditInGroup(this.timeEditEveningOutEnd, "نهاية الخروج المسائي:", 400, 60, this.groupControlEvening);
        }
        
        private void SetupNightGroup()
        {
            this.groupControlNight.Text = "🌙 الفترة الليلية (22:00 - 05:00)";
            this.groupControlNight.Location = new System.Drawing.Point(12, 300);
            this.groupControlNight.Size = new System.Drawing.Size(776, 140);
            
            SetupTimeEditInGroup(this.timeEditNightInStart, "بداية الدخول الليلي:", 20, 30, this.groupControlNight);
            SetupTimeEditInGroup(this.timeEditNightInEnd, "نهاية الدخول الليلي:", 20, 60, this.groupControlNight);
            SetupTimeEditInGroup(this.timeEditNightOutStart, "بداية الخروج الليلي:", 400, 30, this.groupControlNight);
            SetupTimeEditInGroup(this.timeEditNightOutEnd, "نهاية الخروج الليلي:", 400, 60, this.groupControlNight);
        }
        
        private void SetupTimeEditInGroup(DevExpress.XtraEditors.TimeEdit timeEdit, string labelText, int x, int y, DevExpress.XtraEditors.GroupControl parent)
        {
            var label = new DevExpress.XtraEditors.LabelControl();
            label.Text = labelText;
            label.Location = new System.Drawing.Point(x + 150, y + 3);
            label.Size = new System.Drawing.Size(140, 13);
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            parent.Controls.Add(label);
            
            timeEdit.Location = new System.Drawing.Point(x, y);
            timeEdit.Size = new System.Drawing.Size(140, 20);
            timeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            timeEdit.Properties.DisplayFormat.FormatString = "HH:mm";
            timeEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEdit.Properties.EditFormat.FormatString = "HH:mm";
            timeEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEdit.Properties.Mask.EditMask = "HH:mm";
            parent.Controls.Add(timeEdit);
        }
        
        private void SetupButtons()
        {
            this.btnApplyToDevice.Text = "تطبيق على الجهاز";
            this.btnApplyToDevice.Location = new System.Drawing.Point(12, 450);
            this.btnApplyToDevice.Size = new System.Drawing.Size(150, 30);
            this.btnApplyToDevice.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnApplyToDevice.Appearance.Options.UseBackColor = true;
            this.btnApplyToDevice.Click += new System.EventHandler(this.btnApplyToDevice_Click);
            
            this.btnTestSettings.Text = "اختبار الإعدادات";
            this.btnTestSettings.Location = new System.Drawing.Point(170, 450);
            this.btnTestSettings.Size = new System.Drawing.Size(150, 30);
            this.btnTestSettings.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnTestSettings.Appearance.Options.UseBackColor = true;
            this.btnTestSettings.Click += new System.EventHandler(this.btnTestSettings_Click);
            
            this.btnLoadFromDatabase.Text = "تحميل من قاعدة البيانات";
            this.btnLoadFromDatabase.Location = new System.Drawing.Point(328, 450);
            this.btnLoadFromDatabase.Size = new System.Drawing.Size(150, 30);
            this.btnLoadFromDatabase.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnLoadFromDatabase.Appearance.Options.UseBackColor = true;
            this.btnLoadFromDatabase.Click += new System.EventHandler(this.btnLoadFromDatabase_Click);
            
            this.btnReset.Text = "إعادة تعيين";
            this.btnReset.Location = new System.Drawing.Point(486, 450);
            this.btnReset.Size = new System.Drawing.Size(150, 30);
            this.btnReset.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnReset.Appearance.Options.UseBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            this.btnClose.Text = "إغلاق";
            this.btnClose.Location = new System.Drawing.Point(644, 450);
            this.btnClose.Size = new System.Drawing.Size(144, 30);
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        }
        
        private void SetupLayout()
        {
            this.lblStatus.Text = "جاهز لضبط أوقات الدخول والخروج للفترات الثلاث";
            this.lblStatus.Location = new System.Drawing.Point(12, 490);
            this.lblStatus.Size = new System.Drawing.Size(776, 140);
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            
            // Add layout items
            var layoutItemMorning = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemMorning.Control = this.groupControlMorning;
            layoutItemMorning.Location = new System.Drawing.Point(0, 0);
            layoutItemMorning.Size = new System.Drawing.Size(780, 144);
            layoutItemMorning.TextSize = new System.Drawing.Size(0, 0);
            layoutItemMorning.TextVisible = false;
            this.Root.Items.Add(layoutItemMorning);
            
            var layoutItemEvening = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemEvening.Control = this.groupControlEvening;
            layoutItemEvening.Location = new System.Drawing.Point(0, 144);
            layoutItemEvening.Size = new System.Drawing.Size(780, 144);
            layoutItemEvening.TextSize = new System.Drawing.Size(0, 0);
            layoutItemEvening.TextVisible = false;
            this.Root.Items.Add(layoutItemEvening);
            
            var layoutItemNight = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemNight.Control = this.groupControlNight;
            layoutItemNight.Location = new System.Drawing.Point(0, 288);
            layoutItemNight.Size = new System.Drawing.Size(780, 144);
            layoutItemNight.TextSize = new System.Drawing.Size(0, 0);
            layoutItemNight.TextVisible = false;
            this.Root.Items.Add(layoutItemNight);
            
            // Add button layout items
            AddButtonLayoutItem(this.btnApplyToDevice, 0, 438, 154);
            AddButtonLayoutItem(this.btnTestSettings, 158, 438, 154);
            AddButtonLayoutItem(this.btnLoadFromDatabase, 316, 438, 154);
            AddButtonLayoutItem(this.btnReset, 474, 438, 154);
            AddButtonLayoutItem(this.btnClose, 632, 438, 148);
            
            var layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatus.Control = this.lblStatus;
            layoutItemStatus.Location = new System.Drawing.Point(0, 472);
            layoutItemStatus.Size = new System.Drawing.Size(780, 158);
            layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatus.TextVisible = false;
            this.Root.Items.Add(layoutItemStatus);
        }
        
        private void AddButtonLayoutItem(DevExpress.XtraEditors.SimpleButton button, int x, int y, int width)
        {
            var layoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItem.Control = button;
            layoutItem.Location = new System.Drawing.Point(x, y);
            layoutItem.Size = new System.Drawing.Size(width, 34);
            layoutItem.TextSize = new System.Drawing.Size(0, 0);
            layoutItem.TextVisible = false;
            this.Root.Items.Add(layoutItem);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        
        // Morning Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlMorning;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningOutEnd;
        
        // Evening Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlEvening;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningOutEnd;
        
        // Night Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlNight;
        private DevExpress.XtraEditors.TimeEdit timeEditNightInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditNightInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditNightOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditNightOutEnd;
        
        // Common Controls
        private DevExpress.XtraEditors.SimpleButton btnApplyToDevice;
        private DevExpress.XtraEditors.SimpleButton btnTestSettings;
        private DevExpress.XtraEditors.SimpleButton btnLoadFromDatabase;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}