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
            this.groupControlCheckIn = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.timeEditCheckInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditCheckInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.groupControlCheckOut = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.timeEditCheckOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditCheckOutEnd = new DevExpress.XtraEditors.TimeEdit();
            this.btnApplyToDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetFromDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCheckIn)).BeginInit();
            this.groupControlCheckIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCheckOut)).BeginInit();
            this.groupControlCheckOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckOutEnd.Properties)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlCheckIn);
            this.layoutControl1.Controls.Add(this.groupControlCheckOut);
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
            this.layoutControl1.Size = new System.Drawing.Size(600, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(600, 450);
            this.Root.TextVisible = false;
            
            // groupControlCheckIn
            this.groupControlCheckIn.Controls.Add(this.layoutControl2);
            this.groupControlCheckIn.Location = new System.Drawing.Point(12, 12);
            this.groupControlCheckIn.Name = "groupControlCheckIn";
            this.groupControlCheckIn.Size = new System.Drawing.Size(576, 120);
            this.groupControlCheckIn.TabIndex = 4;
            this.groupControlCheckIn.Text = "إعدادات أوقات الدخول (Check-In) - من 6:00 إلى 10:59";
            
            // layoutControl2
            this.layoutControl2.Controls.Add(this.timeEditCheckInStart);
            this.layoutControl2.Controls.Add(this.timeEditCheckInEnd);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 23);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(572, 95);
            this.layoutControl2.TabIndex = 0;
            
            // layoutControlGroup1
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(572, 95);
            this.layoutControlGroup1.TextVisible = false;
            
            // timeEditCheckInStart
            this.timeEditCheckInStart.EditValue = new System.DateTime(2023, 1, 1, 6, 0, 0, 0);
            this.timeEditCheckInStart.Location = new System.Drawing.Point(164, 12);
            this.timeEditCheckInStart.Name = "timeEditCheckInStart";
            this.timeEditCheckInStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditCheckInStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditCheckInStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckInStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditCheckInStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckInStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditCheckInStart.Size = new System.Drawing.Size(396, 20);
            this.timeEditCheckInStart.StyleController = this.layoutControl2;
            this.timeEditCheckInStart.TabIndex = 4;
            
            // timeEditCheckInEnd
            this.timeEditCheckInEnd.EditValue = new System.DateTime(2023, 1, 1, 10, 59, 0, 0);
            this.timeEditCheckInEnd.Location = new System.Drawing.Point(164, 36);
            this.timeEditCheckInEnd.Name = "timeEditCheckInEnd";
            this.timeEditCheckInEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditCheckInEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditCheckInEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckInEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditCheckInEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckInEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditCheckInEnd.Size = new System.Drawing.Size(396, 20);
            this.timeEditCheckInEnd.StyleController = this.layoutControl2;
            this.timeEditCheckInEnd.TabIndex = 5;
            
            // Add layout items for check-in times
            var layoutItemCheckInStart = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCheckInStart.Control = this.timeEditCheckInStart;
            layoutItemCheckInStart.Location = new System.Drawing.Point(0, 0);
            layoutItemCheckInStart.Name = "layoutItemCheckInStart";
            layoutItemCheckInStart.Size = new System.Drawing.Size(552, 24);
            layoutItemCheckInStart.Text = "بداية وقت الدخول (من):";
            layoutItemCheckInStart.TextSize = new System.Drawing.Size(149, 13);
            this.layoutControlGroup1.Items.Add(layoutItemCheckInStart);
            
            var layoutItemCheckInEnd = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCheckInEnd.Control = this.timeEditCheckInEnd;
            layoutItemCheckInEnd.Location = new System.Drawing.Point(0, 24);
            layoutItemCheckInEnd.Name = "layoutItemCheckInEnd";
            layoutItemCheckInEnd.Size = new System.Drawing.Size(552, 24);
            layoutItemCheckInEnd.Text = "نهاية وقت الدخول (إلى):";
            layoutItemCheckInEnd.TextSize = new System.Drawing.Size(149, 13);
            this.layoutControlGroup1.Items.Add(layoutItemCheckInEnd);
            
            var emptySpaceCheckIn = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceCheckIn.AllowHotTrack = false;
            emptySpaceCheckIn.Location = new System.Drawing.Point(0, 48);
            emptySpaceCheckIn.Name = "emptySpaceCheckIn";
            emptySpaceCheckIn.Size = new System.Drawing.Size(552, 27);
            emptySpaceCheckIn.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup1.Items.Add(emptySpaceCheckIn);
            
            // groupControlCheckOut
            this.groupControlCheckOut.Controls.Add(this.layoutControl3);
            this.groupControlCheckOut.Location = new System.Drawing.Point(12, 136);
            this.groupControlCheckOut.Name = "groupControlCheckOut";
            this.groupControlCheckOut.Size = new System.Drawing.Size(576, 120);
            this.groupControlCheckOut.TabIndex = 5;
            this.groupControlCheckOut.Text = "إعدادات أوقات الخروج (Check-Out) - من 11:00 إلى 13:00";
            
            // layoutControl3
            this.layoutControl3.Controls.Add(this.timeEditCheckOutStart);
            this.layoutControl3.Controls.Add(this.timeEditCheckOutEnd);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(2, 23);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(572, 95);
            this.layoutControl3.TabIndex = 0;
            
            // layoutControlGroup2
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(572, 95);
            this.layoutControlGroup2.TextVisible = false;
            
            // timeEditCheckOutStart
            this.timeEditCheckOutStart.EditValue = new System.DateTime(2023, 1, 1, 11, 0, 0, 0);
            this.timeEditCheckOutStart.Location = new System.Drawing.Point(164, 12);
            this.timeEditCheckOutStart.Name = "timeEditCheckOutStart";
            this.timeEditCheckOutStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditCheckOutStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditCheckOutStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckOutStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditCheckOutStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckOutStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditCheckOutStart.Size = new System.Drawing.Size(396, 20);
            this.timeEditCheckOutStart.StyleController = this.layoutControl3;
            this.timeEditCheckOutStart.TabIndex = 4;
            
            // timeEditCheckOutEnd
            this.timeEditCheckOutEnd.EditValue = new System.DateTime(2023, 1, 1, 13, 0, 0, 0);
            this.timeEditCheckOutEnd.Location = new System.Drawing.Point(164, 36);
            this.timeEditCheckOutEnd.Name = "timeEditCheckOutEnd";
            this.timeEditCheckOutEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditCheckOutEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditCheckOutEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckOutEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditCheckOutEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditCheckOutEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditCheckOutEnd.Size = new System.Drawing.Size(396, 20);
            this.timeEditCheckOutEnd.StyleController = this.layoutControl3;
            this.timeEditCheckOutEnd.TabIndex = 5;
            
            // Add layout items for check-out times
            var layoutItemCheckOutStart = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCheckOutStart.Control = this.timeEditCheckOutStart;
            layoutItemCheckOutStart.Location = new System.Drawing.Point(0, 0);
            layoutItemCheckOutStart.Name = "layoutItemCheckOutStart";
            layoutItemCheckOutStart.Size = new System.Drawing.Size(552, 24);
            layoutItemCheckOutStart.Text = "بداية وقت الخروج (من):";
            layoutItemCheckOutStart.TextSize = new System.Drawing.Size(149, 13);
            this.layoutControlGroup2.Items.Add(layoutItemCheckOutStart);
            
            var layoutItemCheckOutEnd = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCheckOutEnd.Control = this.timeEditCheckOutEnd;
            layoutItemCheckOutEnd.Location = new System.Drawing.Point(0, 24);
            layoutItemCheckOutEnd.Name = "layoutItemCheckOutEnd";
            layoutItemCheckOutEnd.Size = new System.Drawing.Size(552, 24);
            layoutItemCheckOutEnd.Text = "نهاية وقت الخروج (إلى):";
            layoutItemCheckOutEnd.TextSize = new System.Drawing.Size(149, 13);
            this.layoutControlGroup2.Items.Add(layoutItemCheckOutEnd);
            
            var emptySpaceCheckOut = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceCheckOut.AllowHotTrack = false;
            emptySpaceCheckOut.Location = new System.Drawing.Point(0, 48);
            emptySpaceCheckOut.Name = "emptySpaceCheckOut";
            emptySpaceCheckOut.Size = new System.Drawing.Size(552, 27);
            emptySpaceCheckOut.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup2.Items.Add(emptySpaceCheckOut);
            
            // Buttons
            this.btnApplyToDevice.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnApplyToDevice.Appearance.Options.UseBackColor = true;
            this.btnApplyToDevice.Location = new System.Drawing.Point(12, 260);
            this.btnApplyToDevice.Name = "btnApplyToDevice";
            this.btnApplyToDevice.Size = new System.Drawing.Size(113, 22);
            this.btnApplyToDevice.StyleController = this.layoutControl1;
            this.btnApplyToDevice.TabIndex = 6;
            this.btnApplyToDevice.Text = "تطبيق على الجهاز";
            this.btnApplyToDevice.Click += new System.EventHandler(this.btnApplyToDevice_Click);
            
            this.btnTestSettings.Location = new System.Drawing.Point(129, 260);
            this.btnTestSettings.Name = "btnTestSettings";
            this.btnTestSettings.Size = new System.Drawing.Size(113, 22);
            this.btnTestSettings.StyleController = this.layoutControl1;
            this.btnTestSettings.TabIndex = 7;
            this.btnTestSettings.Text = "اختبار الإعدادات";
            this.btnTestSettings.Click += new System.EventHandler(this.btnTestSettings_Click);
            
            this.btnGetFromDevice.Location = new System.Drawing.Point(246, 260);
            this.btnGetFromDevice.Name = "btnGetFromDevice";
            this.btnGetFromDevice.Size = new System.Drawing.Size(113, 22);
            this.btnGetFromDevice.StyleController = this.layoutControl1;
            this.btnGetFromDevice.TabIndex = 8;
            this.btnGetFromDevice.Text = "قراءة من الجهاز";
            this.btnGetFromDevice.Click += new System.EventHandler(this.btnGetFromDevice_Click);
            
            this.btnReset.Location = new System.Drawing.Point(363, 260);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 22);
            this.btnReset.StyleController = this.layoutControl1;
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "إعادة تعيين";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            this.btnClose.Location = new System.Drawing.Point(480, 260);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "إغلاق";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // Status label
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(12, 286);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(576, 152);
            this.lblStatus.StyleController = this.layoutControl1;
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "جاهز لضبط أوقات الدخول والخروج حسب احتياجاتك";
            
            // Add all items to main layout
            var layoutItemGroup1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGroup1.Control = this.groupControlCheckIn;
            layoutItemGroup1.Location = new System.Drawing.Point(0, 0);
            layoutItemGroup1.Name = "layoutItemGroup1";
            layoutItemGroup1.Size = new System.Drawing.Size(580, 124);
            layoutItemGroup1.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGroup1.TextVisible = false;
            this.Root.Items.Add(layoutItemGroup1);
            
            var layoutItemGroup2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGroup2.Control = this.groupControlCheckOut;
            layoutItemGroup2.Location = new System.Drawing.Point(0, 124);
            layoutItemGroup2.Name = "layoutItemGroup2";
            layoutItemGroup2.Size = new System.Drawing.Size(580, 124);
            layoutItemGroup2.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGroup2.TextVisible = false;
            this.Root.Items.Add(layoutItemGroup2);
            
            var layoutItemApply = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemApply.Control = this.btnApplyToDevice;
            layoutItemApply.Location = new System.Drawing.Point(0, 248);
            layoutItemApply.Name = "layoutItemApply";
            layoutItemApply.Size = new System.Drawing.Size(117, 26);
            layoutItemApply.TextSize = new System.Drawing.Size(0, 0);
            layoutItemApply.TextVisible = false;
            this.Root.Items.Add(layoutItemApply);
            
            var layoutItemTest = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemTest.Control = this.btnTestSettings;
            layoutItemTest.Location = new System.Drawing.Point(117, 248);
            layoutItemTest.Name = "layoutItemTest";
            layoutItemTest.Size = new System.Drawing.Size(117, 26);
            layoutItemTest.TextSize = new System.Drawing.Size(0, 0);
            layoutItemTest.TextVisible = false;
            this.Root.Items.Add(layoutItemTest);
            
            var layoutItemGet = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGet.Control = this.btnGetFromDevice;
            layoutItemGet.Location = new System.Drawing.Point(234, 248);
            layoutItemGet.Name = "layoutItemGet";
            layoutItemGet.Size = new System.Drawing.Size(117, 26);
            layoutItemGet.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGet.TextVisible = false;
            this.Root.Items.Add(layoutItemGet);
            
            var layoutItemReset = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemReset.Control = this.btnReset;
            layoutItemReset.Location = new System.Drawing.Point(351, 248);
            layoutItemReset.Name = "layoutItemReset";
            layoutItemReset.Size = new System.Drawing.Size(117, 26);
            layoutItemReset.TextSize = new System.Drawing.Size(0, 0);
            layoutItemReset.TextVisible = false;
            this.Root.Items.Add(layoutItemReset);
            
            var layoutItemClose = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemClose.Control = this.btnClose;
            layoutItemClose.Location = new System.Drawing.Point(468, 248);
            layoutItemClose.Name = "layoutItemClose";
            layoutItemClose.Size = new System.Drawing.Size(112, 26);
            layoutItemClose.TextSize = new System.Drawing.Size(0, 0);
            layoutItemClose.TextVisible = false;
            this.Root.Items.Add(layoutItemClose);
            
            var layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatus.Control = this.lblStatus;
            layoutItemStatus.Location = new System.Drawing.Point(0, 274);
            layoutItemStatus.Name = "layoutItemStatus";
            layoutItemStatus.Size = new System.Drawing.Size(580, 156);
            layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatus.TextVisible = false;
            this.Root.Items.Add(layoutItemStatus);
            
            // IOTimeControlForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IOTimeControlForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "التحكم في أوقات الدخول والخروج - جهاز البصمة";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCheckIn)).EndInit();
            this.groupControlCheckIn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCheckOut)).EndInit();
            this.groupControlCheckOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditCheckOutEnd.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl groupControlCheckIn;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TimeEdit timeEditCheckInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditCheckInEnd;
        private DevExpress.XtraEditors.GroupControl groupControlCheckOut;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.TimeEdit timeEditCheckOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditCheckOutEnd;
        private DevExpress.XtraEditors.SimpleButton btnApplyToDevice;
        private DevExpress.XtraEditors.SimpleButton btnTestSettings;
        private DevExpress.XtraEditors.SimpleButton btnGetFromDevice;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}