using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class IOTimeControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            
            // Morning Shift Controls
            this.groupControlMorning = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlMorning = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupMorning = new DevExpress.XtraLayout.LayoutControlGroup();
            this.timeEditMorningInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningOutEnd = new DevExpress.XtraEditors.TimeEdit();
            
            // Evening Shift Controls
            this.groupControlEvening = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlEvening = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupEvening = new DevExpress.XtraLayout.LayoutControlGroup();
            this.timeEditEveningInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningOutEnd = new DevExpress.XtraEditors.TimeEdit();
            
            // Night Shift Controls
            this.groupControlNight = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlNight = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupNight = new DevExpress.XtraLayout.LayoutControlGroup();
            this.timeEditNightInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightOutEnd = new DevExpress.XtraEditors.TimeEdit();
            
            // Buttons and Status
            this.btnApplyToDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetFromDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            
            // Begin Init for all controls
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMorning)).BeginInit();
            this.groupControlMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMorning)).BeginInit();
            this.layoutControlMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMorning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutEnd.Properties)).BeginInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEvening)).BeginInit();
            this.groupControlEvening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEvening)).BeginInit();
            this.layoutControlEvening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEvening)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutEnd.Properties)).BeginInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNight)).BeginInit();
            this.groupControlNight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNight)).BeginInit();
            this.layoutControlNight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupNight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutEnd.Properties)).BeginInit();
            
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlMorning);
            this.layoutControl1.Controls.Add(this.groupControlEvening);
            this.layoutControl1.Controls.Add(this.groupControlNight);
            this.layoutControl1.Controls.Add(this.btnApplyToDevice);
            this.layoutControl1.Controls.Add(this.btnTestSettings);
            this.layoutControl1.Controls.Add(this.btnGetFromDevice);
            this.layoutControl1.Controls.Add(this.btnReset);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(700, 600);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(700, 600);
            this.Root.TextVisible = false;
            
            // groupControlMorning
            this.groupControlMorning.Controls.Add(this.layoutControlMorning);
            this.groupControlMorning.Location = new System.Drawing.Point(12, 12);
            this.groupControlMorning.Name = "groupControlMorning";
            this.groupControlMorning.Size = new System.Drawing.Size(676, 150);
            this.groupControlMorning.TabIndex = 4;
            this.groupControlMorning.Text = "🌅 الفترة الصباحية (6:00 - 13:00)";
            
            // layoutControlMorning
            this.layoutControlMorning.Controls.Add(this.timeEditMorningInStart);
            this.layoutControlMorning.Controls.Add(this.timeEditMorningInEnd);
            this.layoutControlMorning.Controls.Add(this.timeEditMorningOutStart);
            this.layoutControlMorning.Controls.Add(this.timeEditMorningOutEnd);
            this.layoutControlMorning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMorning.Location = new System.Drawing.Point(2, 23);
            this.layoutControlMorning.Name = "layoutControlMorning";
            this.layoutControlMorning.Root = this.layoutControlGroupMorning;
            this.layoutControlMorning.Size = new System.Drawing.Size(672, 125);
            this.layoutControlMorning.TabIndex = 0;
            
            // layoutControlGroupMorning
            this.layoutControlGroupMorning.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupMorning.GroupBordersVisible = false;
            this.layoutControlGroupMorning.Name = "layoutControlGroupMorning";
            this.layoutControlGroupMorning.Size = new System.Drawing.Size(672, 125);
            this.layoutControlGroupMorning.TextVisible = false;
            
            // Morning time edits
            SetupTimeEdit(this.timeEditMorningInStart, new System.DateTime(2023, 1, 1, 6, 0, 0), 200, 12, 260, 20, this.layoutControlMorning);
            SetupTimeEdit(this.timeEditMorningInEnd, new System.DateTime(2023, 1, 1, 10, 59, 0), 200, 36, 260, 20, this.layoutControlMorning);
            SetupTimeEdit(this.timeEditMorningOutStart, new System.DateTime(2023, 1, 1, 11, 0, 0), 200, 60, 260, 20, this.layoutControlMorning);
            SetupTimeEdit(this.timeEditMorningOutEnd, new System.DateTime(2023, 1, 1, 13, 0, 0), 200, 84, 260, 20, this.layoutControlMorning);
            
            // Add layout items for morning
            AddLayoutItem(this.layoutControlGroupMorning, this.timeEditMorningInStart, "بداية الدخول الصباحي:", 0, 0, 652, 24);
            AddLayoutItem(this.layoutControlGroupMorning, this.timeEditMorningInEnd, "نهاية الدخول الصباحي:", 0, 24, 652, 24);
            AddLayoutItem(this.layoutControlGroupMorning, this.timeEditMorningOutStart, "بداية الخروج الصباحي:", 0, 48, 652, 24);
            AddLayoutItem(this.layoutControlGroupMorning, this.timeEditMorningOutEnd, "نهاية الخروج الصباحي:", 0, 72, 652, 24);
            
            // groupControlEvening
            this.groupControlEvening.Controls.Add(this.layoutControlEvening);
            this.groupControlEvening.Location = new System.Drawing.Point(12, 166);
            this.groupControlEvening.Name = "groupControlEvening";
            this.groupControlEvening.Size = new System.Drawing.Size(676, 150);
            this.groupControlEvening.TabIndex = 5;
            this.groupControlEvening.Text = "🌆 الفترة المسائية (14:00 - 21:00)";
            
            // layoutControlEvening
            this.layoutControlEvening.Controls.Add(this.timeEditEveningInStart);
            this.layoutControlEvening.Controls.Add(this.timeEditEveningInEnd);
            this.layoutControlEvening.Controls.Add(this.timeEditEveningOutStart);
            this.layoutControlEvening.Controls.Add(this.timeEditEveningOutEnd);
            this.layoutControlEvening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlEvening.Location = new System.Drawing.Point(2, 23);
            this.layoutControlEvening.Name = "layoutControlEvening";
            this.layoutControlEvening.Root = this.layoutControlGroupEvening;
            this.layoutControlEvening.Size = new System.Drawing.Size(672, 125);
            this.layoutControlEvening.TabIndex = 0;
            
            // layoutControlGroupEvening
            this.layoutControlGroupEvening.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupEvening.GroupBordersVisible = false;
            this.layoutControlGroupEvening.Name = "layoutControlGroupEvening";
            this.layoutControlGroupEvening.Size = new System.Drawing.Size(672, 125);
            this.layoutControlGroupEvening.TextVisible = false;
            
            // Evening time edits
            SetupTimeEdit(this.timeEditEveningInStart, new System.DateTime(2023, 1, 1, 14, 0, 0), 200, 12, 260, 20, this.layoutControlEvening);
            SetupTimeEdit(this.timeEditEveningInEnd, new System.DateTime(2023, 1, 1, 18, 59, 0), 200, 36, 260, 20, this.layoutControlEvening);
            SetupTimeEdit(this.timeEditEveningOutStart, new System.DateTime(2023, 1, 1, 19, 0, 0), 200, 60, 260, 20, this.layoutControlEvening);
            SetupTimeEdit(this.timeEditEveningOutEnd, new System.DateTime(2023, 1, 1, 21, 0, 0), 200, 84, 260, 20, this.layoutControlEvening);
            
            // Add layout items for evening
            AddLayoutItem(this.layoutControlGroupEvening, this.timeEditEveningInStart, "بداية الدخول المسائي:", 0, 0, 652, 24);
            AddLayoutItem(this.layoutControlGroupEvening, this.timeEditEveningInEnd, "نهاية الدخول المسائي:", 0, 24, 652, 24);
            AddLayoutItem(this.layoutControlGroupEvening, this.timeEditEveningOutStart, "بداية الخروج المسائي:", 0, 48, 652, 24);
            AddLayoutItem(this.layoutControlGroupEvening, this.timeEditEveningOutEnd, "نهاية الخروج المسائي:", 0, 72, 652, 24);
            
            // groupControlNight
            this.groupControlNight.Controls.Add(this.layoutControlNight);
            this.groupControlNight.Location = new System.Drawing.Point(12, 320);
            this.groupControlNight.Name = "groupControlNight";
            this.groupControlNight.Size = new System.Drawing.Size(676, 150);
            this.groupControlNight.TabIndex = 6;
            this.groupControlNight.Text = "🌙 الفترة الليلية (22:00 - 05:00)";
            
            // layoutControlNight
            this.layoutControlNight.Controls.Add(this.timeEditNightInStart);
            this.layoutControlNight.Controls.Add(this.timeEditNightInEnd);
            this.layoutControlNight.Controls.Add(this.timeEditNightOutStart);
            this.layoutControlNight.Controls.Add(this.timeEditNightOutEnd);
            this.layoutControlNight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlNight.Location = new System.Drawing.Point(2, 23);
            this.layoutControlNight.Name = "layoutControlNight";
            this.layoutControlNight.Root = this.layoutControlGroupNight;
            this.layoutControlNight.Size = new System.Drawing.Size(672, 125);
            this.layoutControlNight.TabIndex = 0;
            
            // layoutControlGroupNight
            this.layoutControlGroupNight.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupNight.GroupBordersVisible = false;
            this.layoutControlGroupNight.Name = "layoutControlGroupNight";
            this.layoutControlGroupNight.Size = new System.Drawing.Size(672, 125);
            this.layoutControlGroupNight.TextVisible = false;
            
            // Night time edits
            SetupTimeEdit(this.timeEditNightInStart, new System.DateTime(2023, 1, 1, 22, 0, 0), 200, 12, 260, 20, this.layoutControlNight);
            SetupTimeEdit(this.timeEditNightInEnd, new System.DateTime(2023, 1, 1, 2, 59, 0), 200, 36, 260, 20, this.layoutControlNight);
            SetupTimeEdit(this.timeEditNightOutStart, new System.DateTime(2023, 1, 1, 3, 0, 0), 200, 60, 260, 20, this.layoutControlNight);
            SetupTimeEdit(this.timeEditNightOutEnd, new System.DateTime(2023, 1, 1, 5, 0, 0), 200, 84, 260, 20, this.layoutControlNight);
            
            // Add layout items for night
            AddLayoutItem(this.layoutControlGroupNight, this.timeEditNightInStart, "بداية الدخول الليلي:", 0, 0, 652, 24);
            AddLayoutItem(this.layoutControlGroupNight, this.timeEditNightInEnd, "نهاية الدخول الليلي:", 0, 24, 652, 24);
            AddLayoutItem(this.layoutControlGroupNight, this.timeEditNightOutStart, "بداية الخروج الليلي:", 0, 48, 652, 24);
            AddLayoutItem(this.layoutControlGroupNight, this.timeEditNightOutEnd, "نهاية الخروج الليلي:", 0, 72, 652, 24);
            
            // Buttons
            SetupButton(this.btnApplyToDevice, "تطبيق على الجهاز", 12, 474, 130, 22, System.Drawing.Color.FromArgb(0, 192, 0));
            SetupButton(this.btnTestSettings, "اختبار الإعدادات", 146, 474, 130, 22, System.Drawing.Color.Blue);
            SetupButton(this.btnGetFromDevice, "قراءة من الجهاز", 280, 474, 130, 22, System.Drawing.Color.Orange);
            SetupButton(this.btnReset, "إعادة تعيين", 414, 474, 130, 22, System.Drawing.Color.Red);
            SetupButton(this.btnClose, "إغلاق", 548, 474, 140, 22, System.Drawing.Color.Gray);
            
            // Status label
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(12, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(676, 88);
            this.lblStatus.StyleController = this.layoutControl1;
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "جاهز لضبط أوقات الدخول والخروج للفترات الثلاث";
            
            // Add all items to main layout
            AddMainLayoutItem(this.groupControlMorning, 0, 0, 680, 154);
            AddMainLayoutItem(this.groupControlEvening, 0, 154, 680, 154);
            AddMainLayoutItem(this.groupControlNight, 0, 308, 680, 154);
            AddMainLayoutItem(this.btnApplyToDevice, 0, 462, 134, 26);
            AddMainLayoutItem(this.btnTestSettings, 134, 462, 134, 26);
            AddMainLayoutItem(this.btnGetFromDevice, 268, 462, 134, 26);
            AddMainLayoutItem(this.btnReset, 402, 462, 134, 26);
            AddMainLayoutItem(this.btnClose, 536, 462, 144, 26);
            AddMainLayoutItem(this.lblStatus, 0, 488, 680, 92);
            
            // IOTimeControlForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOTimeControlForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "التحكم في أوقات الدخول والخروج - الفترات الثلاث";
            
            // End Init for all controls
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMorning)).EndInit();
            this.groupControlMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMorning)).EndInit();
            this.layoutControlMorning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupMorning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutEnd.Properties)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEvening)).EndInit();
            this.groupControlEvening.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlEvening)).EndInit();
            this.layoutControlEvening.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEvening)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutEnd.Properties)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNight)).EndInit();
            this.groupControlNight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNight)).EndInit();
            this.layoutControlNight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupNight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutEnd.Properties)).EndInit();
            
            this.ResumeLayout(false);
        }
        
        private void SetupTimeEdit(DevExpress.XtraEditors.TimeEdit timeEdit, System.DateTime defaultTime, int x, int y, int width, int height, DevExpress.XtraLayout.LayoutControl parent)
        {
            timeEdit.EditValue = defaultTime;
            timeEdit.Location = new System.Drawing.Point(x, y);
            timeEdit.Name = timeEdit.Name ?? "timeEdit";
            timeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            timeEdit.Properties.DisplayFormat.FormatString = "HH:mm";
            timeEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEdit.Properties.EditFormat.FormatString = "HH:mm";
            timeEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEdit.Properties.Mask.EditMask = "HH:mm";
            timeEdit.Size = new System.Drawing.Size(width, height);
            timeEdit.StyleController = parent;
            timeEdit.TabIndex = 0;
        }
        
        private void SetupButton(DevExpress.XtraEditors.SimpleButton button, string text, int x, int y, int width, int height, System.Drawing.Color backColor)
        {
            button.Appearance.BackColor = backColor;
            button.Appearance.Options.UseBackColor = true;
            button.Location = new System.Drawing.Point(x, y);
            button.Name = button.Name ?? "button";
            button.Size = new System.Drawing.Size(width, height);
            button.StyleController = this.layoutControl1;
            button.TabIndex = 0;
            button.Text = text;
        }
        
        private void AddLayoutItem(DevExpress.XtraLayout.LayoutControlGroup group, System.Windows.Forms.Control control, string text, int x, int y, int width, int height)
        {
            var layoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItem.Control = control;
            layoutItem.Location = new System.Drawing.Point(x, y);
            layoutItem.Name = $"layoutItem{control.Name}";
            layoutItem.Size = new System.Drawing.Size(width, height);
            layoutItem.Text = text;
            layoutItem.TextSize = new System.Drawing.Size(180, 13);
            group.Items.Add(layoutItem);
        }
        
        private void AddMainLayoutItem(System.Windows.Forms.Control control, int x, int y, int width, int height)
        {
            var layoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItem.Control = control;
            layoutItem.Location = new System.Drawing.Point(x, y);
            layoutItem.Name = $"layoutItem{control.Name}";
            layoutItem.Size = new System.Drawing.Size(width, height);
            layoutItem.TextSize = new System.Drawing.Size(0, 0);
            layoutItem.TextVisible = false;
            this.Root.Items.Add(layoutItem);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        
        // Morning Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlMorning;
        private DevExpress.XtraLayout.LayoutControl layoutControlMorning;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupMorning;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningOutEnd;
        
        // Evening Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlEvening;
        private DevExpress.XtraLayout.LayoutControl layoutControlEvening;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupEvening;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningOutEnd;
        
        // Night Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlNight;
        private DevExpress.XtraLayout.LayoutControl layoutControlNight;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupNight;
        private DevExpress.XtraEditors.TimeEdit timeEditNightInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditNightInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditNightOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditNightOutEnd;
        
        // Common Controls
        private DevExpress.XtraEditors.SimpleButton btnApplyToDevice;
        private DevExpress.XtraEditors.SimpleButton btnTestSettings;
        private DevExpress.XtraEditors.SimpleButton btnGetFromDevice;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}