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
            this.timeEditMorningInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningOutEnd = new DevExpress.XtraEditors.TimeEdit();
            this.labelMorningInStart = new DevExpress.XtraEditors.LabelControl();
            this.labelMorningInEnd = new DevExpress.XtraEditors.LabelControl();
            this.labelMorningOutStart = new DevExpress.XtraEditors.LabelControl();
            this.labelMorningOutEnd = new DevExpress.XtraEditors.LabelControl();
            
            // Evening Shift Controls
            this.groupControlEvening = new DevExpress.XtraEditors.GroupControl();
            this.timeEditEveningInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEveningOutEnd = new DevExpress.XtraEditors.TimeEdit();
            this.labelEveningInStart = new DevExpress.XtraEditors.LabelControl();
            this.labelEveningInEnd = new DevExpress.XtraEditors.LabelControl();
            this.labelEveningOutStart = new DevExpress.XtraEditors.LabelControl();
            this.labelEveningOutEnd = new DevExpress.XtraEditors.LabelControl();
            
            // Night Shift Controls
            this.groupControlNight = new DevExpress.XtraEditors.GroupControl();
            this.timeEditNightInStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightInEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightOutStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditNightOutEnd = new DevExpress.XtraEditors.TimeEdit();
            this.labelNightInStart = new DevExpress.XtraEditors.LabelControl();
            this.labelNightInEnd = new DevExpress.XtraEditors.LabelControl();
            this.labelNightOutStart = new DevExpress.XtraEditors.LabelControl();
            this.labelNightOutEnd = new DevExpress.XtraEditors.LabelControl();
            
            // Buttons and Status
            this.btnApplyToDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetFromDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            // Layout items
            this.layoutItemMorning = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemEvening = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemNight = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemApply = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemTest = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemGet = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemReset = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemClose = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            
            // Begin init for time edits
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutEnd.Properties)).BeginInit();
            
            // Begin init for groups
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMorning)).BeginInit();
            this.groupControlMorning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEvening)).BeginInit();
            this.groupControlEvening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNight)).BeginInit();
            this.groupControlNight.SuspendLayout();
            
            // Begin init for layout items
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMorning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEvening)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStatus)).BeginInit();
            
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
            this.layoutControl1.Size = new System.Drawing.Size(700, 580);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemMorning,
                this.layoutItemEvening,
                this.layoutItemNight,
                this.layoutItemApply,
                this.layoutItemTest,
                this.layoutItemGet,
                this.layoutItemReset,
                this.layoutItemClose,
                this.layoutItemStatus});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(700, 580);
            this.Root.TextVisible = false;
            
            // groupControlMorning
            this.groupControlMorning.Controls.Add(this.timeEditMorningInStart);
            this.groupControlMorning.Controls.Add(this.timeEditMorningInEnd);
            this.groupControlMorning.Controls.Add(this.timeEditMorningOutStart);
            this.groupControlMorning.Controls.Add(this.timeEditMorningOutEnd);
            this.groupControlMorning.Controls.Add(this.labelMorningInStart);
            this.groupControlMorning.Controls.Add(this.labelMorningInEnd);
            this.groupControlMorning.Controls.Add(this.labelMorningOutStart);
            this.groupControlMorning.Controls.Add(this.labelMorningOutEnd);
            this.groupControlMorning.Location = new System.Drawing.Point(12, 12);
            this.groupControlMorning.Name = "groupControlMorning";
            this.groupControlMorning.Size = new System.Drawing.Size(676, 130);
            this.groupControlMorning.TabIndex = 4;
            this.groupControlMorning.Text = "🌅 الفترة الصباحية (6:00 - 13:00)";
            
            // Morning time edits and labels
            this.labelMorningInStart.Location = new System.Drawing.Point(500, 30);
            this.labelMorningInStart.Name = "labelMorningInStart";
            this.labelMorningInStart.Size = new System.Drawing.Size(120, 13);
            this.labelMorningInStart.TabIndex = 0;
            this.labelMorningInStart.Text = "بداية الدخول الصباحي:";
            
            this.timeEditMorningInStart.EditValue = new System.DateTime(2023, 1, 1, 6, 0, 0);
            this.timeEditMorningInStart.Location = new System.Drawing.Point(350, 27);
            this.timeEditMorningInStart.Name = "timeEditMorningInStart";
            this.timeEditMorningInStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditMorningInStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditMorningInStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningInStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditMorningInStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningInStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditMorningInStart.Size = new System.Drawing.Size(120, 20);
            this.timeEditMorningInStart.TabIndex = 1;
            
            this.labelMorningInEnd.Location = new System.Drawing.Point(500, 55);
            this.labelMorningInEnd.Name = "labelMorningInEnd";
            this.labelMorningInEnd.Size = new System.Drawing.Size(120, 13);
            this.labelMorningInEnd.TabIndex = 2;
            this.labelMorningInEnd.Text = "نهاية الدخول الصباحي:";
            
            this.timeEditMorningInEnd.EditValue = new System.DateTime(2023, 1, 1, 10, 59, 0);
            this.timeEditMorningInEnd.Location = new System.Drawing.Point(350, 52);
            this.timeEditMorningInEnd.Name = "timeEditMorningInEnd";
            this.timeEditMorningInEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditMorningInEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditMorningInEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningInEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditMorningInEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningInEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditMorningInEnd.Size = new System.Drawing.Size(120, 20);
            this.timeEditMorningInEnd.TabIndex = 3;
            
            this.labelMorningOutStart.Location = new System.Drawing.Point(200, 30);
            this.labelMorningOutStart.Name = "labelMorningOutStart";
            this.labelMorningOutStart.Size = new System.Drawing.Size(120, 13);
            this.labelMorningOutStart.TabIndex = 4;
            this.labelMorningOutStart.Text = "بداية الخروج الصباحي:";
            
            this.timeEditMorningOutStart.EditValue = new System.DateTime(2023, 1, 1, 11, 0, 0);
            this.timeEditMorningOutStart.Location = new System.Drawing.Point(50, 27);
            this.timeEditMorningOutStart.Name = "timeEditMorningOutStart";
            this.timeEditMorningOutStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditMorningOutStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditMorningOutStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningOutStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditMorningOutStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningOutStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditMorningOutStart.Size = new System.Drawing.Size(120, 20);
            this.timeEditMorningOutStart.TabIndex = 5;
            
            this.labelMorningOutEnd.Location = new System.Drawing.Point(200, 55);
            this.labelMorningOutEnd.Name = "labelMorningOutEnd";
            this.labelMorningOutEnd.Size = new System.Drawing.Size(120, 13);
            this.labelMorningOutEnd.TabIndex = 6;
            this.labelMorningOutEnd.Text = "نهاية الخروج الصباحي:";
            
            this.timeEditMorningOutEnd.EditValue = new System.DateTime(2023, 1, 1, 13, 0, 0);
            this.timeEditMorningOutEnd.Location = new System.Drawing.Point(50, 52);
            this.timeEditMorningOutEnd.Name = "timeEditMorningOutEnd";
            this.timeEditMorningOutEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditMorningOutEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditMorningOutEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningOutEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditMorningOutEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningOutEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditMorningOutEnd.Size = new System.Drawing.Size(120, 20);
            this.timeEditMorningOutEnd.TabIndex = 7;
            
            // groupControlEvening
            this.groupControlEvening.Controls.Add(this.timeEditEveningInStart);
            this.groupControlEvening.Controls.Add(this.timeEditEveningInEnd);
            this.groupControlEvening.Controls.Add(this.timeEditEveningOutStart);
            this.groupControlEvening.Controls.Add(this.timeEditEveningOutEnd);
            this.groupControlEvening.Controls.Add(this.labelEveningInStart);
            this.groupControlEvening.Controls.Add(this.labelEveningInEnd);
            this.groupControlEvening.Controls.Add(this.labelEveningOutStart);
            this.groupControlEvening.Controls.Add(this.labelEveningOutEnd);
            this.groupControlEvening.Location = new System.Drawing.Point(12, 146);
            this.groupControlEvening.Name = "groupControlEvening";
            this.groupControlEvening.Size = new System.Drawing.Size(676, 130);
            this.groupControlEvening.TabIndex = 5;
            this.groupControlEvening.Text = "🌆 الفترة المسائية (14:00 - 21:00)";
            
            // Evening time edits and labels - Similar setup as morning
            this.labelEveningInStart.Location = new System.Drawing.Point(500, 30);
            this.labelEveningInStart.Name = "labelEveningInStart";
            this.labelEveningInStart.Size = new System.Drawing.Size(120, 13);
            this.labelEveningInStart.TabIndex = 0;
            this.labelEveningInStart.Text = "بداية الدخول المسائي:";
            
            this.timeEditEveningInStart.EditValue = new System.DateTime(2023, 1, 1, 14, 0, 0);
            this.timeEditEveningInStart.Location = new System.Drawing.Point(350, 27);
            this.timeEditEveningInStart.Name = "timeEditEveningInStart";
            this.timeEditEveningInStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEveningInStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditEveningInStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningInStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditEveningInStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningInStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditEveningInStart.Size = new System.Drawing.Size(120, 20);
            this.timeEditEveningInStart.TabIndex = 1;
            
            this.labelEveningInEnd.Location = new System.Drawing.Point(500, 55);
            this.labelEveningInEnd.Name = "labelEveningInEnd";
            this.labelEveningInEnd.Size = new System.Drawing.Size(120, 13);
            this.labelEveningInEnd.TabIndex = 2;
            this.labelEveningInEnd.Text = "نهاية الدخول المسائي:";
            
            this.timeEditEveningInEnd.EditValue = new System.DateTime(2023, 1, 1, 18, 59, 0);
            this.timeEditEveningInEnd.Location = new System.Drawing.Point(350, 52);
            this.timeEditEveningInEnd.Name = "timeEditEveningInEnd";
            this.timeEditEveningInEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEveningInEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditEveningInEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningInEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditEveningInEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningInEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditEveningInEnd.Size = new System.Drawing.Size(120, 20);
            this.timeEditEveningInEnd.TabIndex = 3;
            
            this.labelEveningOutStart.Location = new System.Drawing.Point(200, 30);
            this.labelEveningOutStart.Name = "labelEveningOutStart";
            this.labelEveningOutStart.Size = new System.Drawing.Size(120, 13);
            this.labelEveningOutStart.TabIndex = 4;
            this.labelEveningOutStart.Text = "بداية الخروج المسائي:";
            
            this.timeEditEveningOutStart.EditValue = new System.DateTime(2023, 1, 1, 19, 0, 0);
            this.timeEditEveningOutStart.Location = new System.Drawing.Point(50, 27);
            this.timeEditEveningOutStart.Name = "timeEditEveningOutStart";
            this.timeEditEveningOutStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEveningOutStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditEveningOutStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningOutStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditEveningOutStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningOutStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditEveningOutStart.Size = new System.Drawing.Size(120, 20);
            this.timeEditEveningOutStart.TabIndex = 5;
            
            this.labelEveningOutEnd.Location = new System.Drawing.Point(200, 55);
            this.labelEveningOutEnd.Name = "labelEveningOutEnd";
            this.labelEveningOutEnd.Size = new System.Drawing.Size(120, 13);
            this.labelEveningOutEnd.TabIndex = 6;
            this.labelEveningOutEnd.Text = "نهاية الخروج المسائي:";
            
            this.timeEditEveningOutEnd.EditValue = new System.DateTime(2023, 1, 1, 21, 0, 0);
            this.timeEditEveningOutEnd.Location = new System.Drawing.Point(50, 52);
            this.timeEditEveningOutEnd.Name = "timeEditEveningOutEnd";
            this.timeEditEveningOutEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEveningOutEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditEveningOutEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningOutEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditEveningOutEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEveningOutEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditEveningOutEnd.Size = new System.Drawing.Size(120, 20);
            this.timeEditEveningOutEnd.TabIndex = 7;
            
            // groupControlNight
            this.groupControlNight.Controls.Add(this.timeEditNightInStart);
            this.groupControlNight.Controls.Add(this.timeEditNightInEnd);
            this.groupControlNight.Controls.Add(this.timeEditNightOutStart);
            this.groupControlNight.Controls.Add(this.timeEditNightOutEnd);
            this.groupControlNight.Controls.Add(this.labelNightInStart);
            this.groupControlNight.Controls.Add(this.labelNightInEnd);
            this.groupControlNight.Controls.Add(this.labelNightOutStart);
            this.groupControlNight.Controls.Add(this.labelNightOutEnd);
            this.groupControlNight.Location = new System.Drawing.Point(12, 280);
            this.groupControlNight.Name = "groupControlNight";
            this.groupControlNight.Size = new System.Drawing.Size(676, 130);
            this.groupControlNight.TabIndex = 6;
            this.groupControlNight.Text = "🌙 الفترة الليلية (22:00 - 05:00)";
            
            // Night time edits and labels - Similar setup as morning
            this.labelNightInStart.Location = new System.Drawing.Point(500, 30);
            this.labelNightInStart.Name = "labelNightInStart";
            this.labelNightInStart.Size = new System.Drawing.Size(120, 13);
            this.labelNightInStart.TabIndex = 0;
            this.labelNightInStart.Text = "بداية الدخول الليلي:";
            
            this.timeEditNightInStart.EditValue = new System.DateTime(2023, 1, 1, 22, 0, 0);
            this.timeEditNightInStart.Location = new System.Drawing.Point(350, 27);
            this.timeEditNightInStart.Name = "timeEditNightInStart";
            this.timeEditNightInStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditNightInStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditNightInStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightInStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditNightInStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightInStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditNightInStart.Size = new System.Drawing.Size(120, 20);
            this.timeEditNightInStart.TabIndex = 1;
            
            this.labelNightInEnd.Location = new System.Drawing.Point(500, 55);
            this.labelNightInEnd.Name = "labelNightInEnd";
            this.labelNightInEnd.Size = new System.Drawing.Size(120, 13);
            this.labelNightInEnd.TabIndex = 2;
            this.labelNightInEnd.Text = "نهاية الدخول الليلي:";
            
            this.timeEditNightInEnd.EditValue = new System.DateTime(2023, 1, 1, 2, 59, 0);
            this.timeEditNightInEnd.Location = new System.Drawing.Point(350, 52);
            this.timeEditNightInEnd.Name = "timeEditNightInEnd";
            this.timeEditNightInEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditNightInEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditNightInEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightInEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditNightInEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightInEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditNightInEnd.Size = new System.Drawing.Size(120, 20);
            this.timeEditNightInEnd.TabIndex = 3;
            
            this.labelNightOutStart.Location = new System.Drawing.Point(200, 30);
            this.labelNightOutStart.Name = "labelNightOutStart";
            this.labelNightOutStart.Size = new System.Drawing.Size(120, 13);
            this.labelNightOutStart.TabIndex = 4;
            this.labelNightOutStart.Text = "بداية الخروج الليلي:";
            
            this.timeEditNightOutStart.EditValue = new System.DateTime(2023, 1, 1, 3, 0, 0);
            this.timeEditNightOutStart.Location = new System.Drawing.Point(50, 27);
            this.timeEditNightOutStart.Name = "timeEditNightOutStart";
            this.timeEditNightOutStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditNightOutStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditNightOutStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightOutStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditNightOutStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightOutStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditNightOutStart.Size = new System.Drawing.Size(120, 20);
            this.timeEditNightOutStart.TabIndex = 5;
            
            this.labelNightOutEnd.Location = new System.Drawing.Point(200, 55);
            this.labelNightOutEnd.Name = "labelNightOutEnd";
            this.labelNightOutEnd.Size = new System.Drawing.Size(120, 13);
            this.labelNightOutEnd.TabIndex = 6;
            this.labelNightOutEnd.Text = "نهاية الخروج الليلي:";
            
            this.timeEditNightOutEnd.EditValue = new System.DateTime(2023, 1, 1, 5, 0, 0);
            this.timeEditNightOutEnd.Location = new System.Drawing.Point(50, 52);
            this.timeEditNightOutEnd.Name = "timeEditNightOutEnd";
            this.timeEditNightOutEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditNightOutEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditNightOutEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightOutEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditNightOutEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditNightOutEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditNightOutEnd.Size = new System.Drawing.Size(120, 20);
            this.timeEditNightOutEnd.TabIndex = 7;
            
            // Buttons
            this.btnApplyToDevice.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            this.btnApplyToDevice.Appearance.Options.UseBackColor = true;
            this.btnApplyToDevice.Location = new System.Drawing.Point(12, 414);
            this.btnApplyToDevice.Name = "btnApplyToDevice";
            this.btnApplyToDevice.Size = new System.Drawing.Size(130, 22);
            this.btnApplyToDevice.StyleController = this.layoutControl1;
            this.btnApplyToDevice.TabIndex = 7;
            this.btnApplyToDevice.Text = "تطبيق على الجهاز";
            this.btnApplyToDevice.Click += new System.EventHandler(this.btnApplyToDevice_Click);
            
            this.btnTestSettings.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnTestSettings.Appearance.Options.UseBackColor = true;
            this.btnTestSettings.Location = new System.Drawing.Point(146, 414);
            this.btnTestSettings.Name = "btnTestSettings";
            this.btnTestSettings.Size = new System.Drawing.Size(130, 22);
            this.btnTestSettings.StyleController = this.layoutControl1;
            this.btnTestSettings.TabIndex = 8;
            this.btnTestSettings.Text = "اختبار الإعدادات";
            this.btnTestSettings.Click += new System.EventHandler(this.btnTestSettings_Click);
            
            this.btnGetFromDevice.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnGetFromDevice.Appearance.Options.UseBackColor = true;
            this.btnGetFromDevice.Location = new System.Drawing.Point(280, 414);
            this.btnGetFromDevice.Name = "btnGetFromDevice";
            this.btnGetFromDevice.Size = new System.Drawing.Size(130, 22);
            this.btnGetFromDevice.StyleController = this.layoutControl1;
            this.btnGetFromDevice.TabIndex = 9;
            this.btnGetFromDevice.Text = "قراءة من الجهاز";
            this.btnGetFromDevice.Click += new System.EventHandler(this.btnGetFromDevice_Click);
            
            this.btnReset.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnReset.Appearance.Options.UseBackColor = true;
            this.btnReset.Location = new System.Drawing.Point(414, 414);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 22);
            this.btnReset.StyleController = this.layoutControl1;
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "إعادة تعيين";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Location = new System.Drawing.Point(548, 414);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "إغلاق";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // Status label
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(12, 440);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(676, 128);
            this.lblStatus.StyleController = this.layoutControl1;
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "جاهز لضبط أوقات الدخول والخروج للفترات الثلاث";
            
            // Layout items
            this.layoutItemMorning.Control = this.groupControlMorning;
            this.layoutItemMorning.Location = new System.Drawing.Point(0, 0);
            this.layoutItemMorning.Name = "layoutItemMorning";
            this.layoutItemMorning.Size = new System.Drawing.Size(680, 134);
            this.layoutItemMorning.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemMorning.TextVisible = false;
            
            this.layoutItemEvening.Control = this.groupControlEvening;
            this.layoutItemEvening.Location = new System.Drawing.Point(0, 134);
            this.layoutItemEvening.Name = "layoutItemEvening";
            this.layoutItemEvening.Size = new System.Drawing.Size(680, 134);
            this.layoutItemEvening.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemEvening.TextVisible = false;
            
            this.layoutItemNight.Control = this.groupControlNight;
            this.layoutItemNight.Location = new System.Drawing.Point(0, 268);
            this.layoutItemNight.Name = "layoutItemNight";
            this.layoutItemNight.Size = new System.Drawing.Size(680, 134);
            this.layoutItemNight.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemNight.TextVisible = false;
            
            this.layoutItemApply.Control = this.btnApplyToDevice;
            this.layoutItemApply.Location = new System.Drawing.Point(0, 402);
            this.layoutItemApply.Name = "layoutItemApply";
            this.layoutItemApply.Size = new System.Drawing.Size(134, 26);
            this.layoutItemApply.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemApply.TextVisible = false;
            
            this.layoutItemTest.Control = this.btnTestSettings;
            this.layoutItemTest.Location = new System.Drawing.Point(134, 402);
            this.layoutItemTest.Name = "layoutItemTest";
            this.layoutItemTest.Size = new System.Drawing.Size(134, 26);
            this.layoutItemTest.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemTest.TextVisible = false;
            
            this.layoutItemGet.Control = this.btnGetFromDevice;
            this.layoutItemGet.Location = new System.Drawing.Point(268, 402);
            this.layoutItemGet.Name = "layoutItemGet";
            this.layoutItemGet.Size = new System.Drawing.Size(134, 26);
            this.layoutItemGet.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemGet.TextVisible = false;
            
            this.layoutItemReset.Control = this.btnReset;
            this.layoutItemReset.Location = new System.Drawing.Point(402, 402);
            this.layoutItemReset.Name = "layoutItemReset";
            this.layoutItemReset.Size = new System.Drawing.Size(134, 26);
            this.layoutItemReset.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemReset.TextVisible = false;
            
            this.layoutItemClose.Control = this.btnClose;
            this.layoutItemClose.Location = new System.Drawing.Point(536, 402);
            this.layoutItemClose.Name = "layoutItemClose";
            this.layoutItemClose.Size = new System.Drawing.Size(144, 26);
            this.layoutItemClose.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemClose.TextVisible = false;
            
            this.layoutItemStatus.Control = this.lblStatus;
            this.layoutItemStatus.Location = new System.Drawing.Point(0, 428);
            this.layoutItemStatus.Name = "layoutItemStatus";
            this.layoutItemStatus.Size = new System.Drawing.Size(680, 132);
            this.layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemStatus.TextVisible = false;
            
            // IOTimeControlForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 580);
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
            
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningOutEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEveningOutEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightInEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditNightOutEnd.Properties)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMorning)).EndInit();
            this.groupControlMorning.ResumeLayout(false);
            this.groupControlMorning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlEvening)).EndInit();
            this.groupControlEvening.ResumeLayout(false);
            this.groupControlEvening.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlNight)).EndInit();
            this.groupControlNight.ResumeLayout(false);
            this.groupControlNight.PerformLayout();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMorning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEvening)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStatus)).EndInit();
            
            this.ResumeLayout(false);
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
        private DevExpress.XtraEditors.LabelControl labelMorningInStart;
        private DevExpress.XtraEditors.LabelControl labelMorningInEnd;
        private DevExpress.XtraEditors.LabelControl labelMorningOutStart;
        private DevExpress.XtraEditors.LabelControl labelMorningOutEnd;
        
        // Evening Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlEvening;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEveningOutEnd;
        private DevExpress.XtraEditors.LabelControl labelEveningInStart;
        private DevExpress.XtraEditors.LabelControl labelEveningInEnd;
        private DevExpress.XtraEditors.LabelControl labelEveningOutStart;
        private DevExpress.XtraEditors.LabelControl labelEveningOutEnd;
        
        // Night Shift Controls
        private DevExpress.XtraEditors.GroupControl groupControlNight;
        private DevExpress.XtraEditors.TimeEdit timeEditNightInStart;
        private DevExpress.XtraEditors.TimeEdit timeEditNightInEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditNightOutStart;
        private DevExpress.XtraEditors.TimeEdit timeEditNightOutEnd;
        private DevExpress.XtraEditors.LabelControl labelNightInStart;
        private DevExpress.XtraEditors.LabelControl labelNightInEnd;
        private DevExpress.XtraEditors.LabelControl labelNightOutStart;
        private DevExpress.XtraEditors.LabelControl labelNightOutEnd;
        
        // Common Controls
        private DevExpress.XtraEditors.SimpleButton btnApplyToDevice;
        private DevExpress.XtraEditors.SimpleButton btnTestSettings;
        private DevExpress.XtraEditors.SimpleButton btnGetFromDevice;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        
        // Layout Items
        private DevExpress.XtraLayout.LayoutControlItem layoutItemMorning;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemEvening;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNight;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemApply;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemTest;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemGet;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemReset;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemStatus;
    }
}