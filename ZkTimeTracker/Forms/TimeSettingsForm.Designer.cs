using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class TimeSettingsForm
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
            this.timeEditMorningStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditMorningEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditAfternoonStart = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditAfternoonEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditLateThreshold = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditEarlyThreshold = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditOvertimeStart = new DevExpress.XtraEditors.TimeEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl4 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditAfternoonStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditAfternoonEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditLateThreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEarlyThreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditOvertimeStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).BeginInit();
            this.layoutControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.groupControl2);
            this.layoutControl1.Controls.Add(this.groupControl3);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnReset);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(500, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(500, 450);
            this.Root.TextVisible = false;
            
            // groupControl1
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(476, 120);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Shift Times";
            
            // layoutControl2
            this.layoutControl2.Controls.Add(this.timeEditMorningStart);
            this.layoutControl2.Controls.Add(this.timeEditMorningEnd);
            this.layoutControl2.Controls.Add(this.timeEditAfternoonStart);
            this.layoutControl2.Controls.Add(this.timeEditAfternoonEnd);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 23);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(472, 95);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            
            // layoutControlGroup1
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(472, 95);
            this.layoutControlGroup1.TextVisible = false;
            
            // timeEditMorningStart
            this.timeEditMorningStart.EditValue = new System.DateTime(2023, 1, 1, 8, 0, 0, 0);
            this.timeEditMorningStart.Location = new System.Drawing.Point(134, 12);
            this.timeEditMorningStart.Name = "timeEditMorningStart";
            this.timeEditMorningStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditMorningStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditMorningStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditMorningStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditMorningStart.Size = new System.Drawing.Size(326, 20);
            this.timeEditMorningStart.StyleController = this.layoutControl2;
            this.timeEditMorningStart.TabIndex = 4;
            
            // Add Morning Start to layout
            var layoutItemMorningStart = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemMorningStart.Control = this.timeEditMorningStart;
            layoutItemMorningStart.Location = new System.Drawing.Point(0, 0);
            layoutItemMorningStart.Name = "layoutItemMorningStart";
            layoutItemMorningStart.Size = new System.Drawing.Size(452, 24);
            layoutItemMorningStart.Text = "Morning Shift Start:";
            layoutItemMorningStart.TextSize = new System.Drawing.Size(119, 13);
            this.layoutControlGroup1.Items.Add(layoutItemMorningStart);
            
            // timeEditMorningEnd
            this.timeEditMorningEnd.EditValue = new System.DateTime(2023, 1, 1, 12, 0, 0, 0);
            this.timeEditMorningEnd.Location = new System.Drawing.Point(134, 36);
            this.timeEditMorningEnd.Name = "timeEditMorningEnd";
            this.timeEditMorningEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditMorningEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditMorningEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditMorningEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditMorningEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditMorningEnd.Size = new System.Drawing.Size(326, 20);
            this.timeEditMorningEnd.StyleController = this.layoutControl2;
            this.timeEditMorningEnd.TabIndex = 5;
            
            // Add Morning End to layout
            var layoutItemMorningEnd = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemMorningEnd.Control = this.timeEditMorningEnd;
            layoutItemMorningEnd.Location = new System.Drawing.Point(0, 24);
            layoutItemMorningEnd.Name = "layoutItemMorningEnd";
            layoutItemMorningEnd.Size = new System.Drawing.Size(452, 24);
            layoutItemMorningEnd.Text = "Morning Shift End:";
            layoutItemMorningEnd.TextSize = new System.Drawing.Size(119, 13);
            this.layoutControlGroup1.Items.Add(layoutItemMorningEnd);
            
            // timeEditAfternoonStart
            this.timeEditAfternoonStart.EditValue = new System.DateTime(2023, 1, 1, 13, 0, 0, 0);
            this.timeEditAfternoonStart.Location = new System.Drawing.Point(134, 60);
            this.timeEditAfternoonStart.Name = "timeEditAfternoonStart";
            this.timeEditAfternoonStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditAfternoonStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditAfternoonStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditAfternoonStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditAfternoonStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditAfternoonStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditAfternoonStart.Size = new System.Drawing.Size(326, 20);
            this.timeEditAfternoonStart.StyleController = this.layoutControl2;
            this.timeEditAfternoonStart.TabIndex = 6;
            
            // Add Afternoon Start to layout
            var layoutItemAfternoonStart = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemAfternoonStart.Control = this.timeEditAfternoonStart;
            layoutItemAfternoonStart.Location = new System.Drawing.Point(0, 48);
            layoutItemAfternoonStart.Name = "layoutItemAfternoonStart";
            layoutItemAfternoonStart.Size = new System.Drawing.Size(452, 24);
            layoutItemAfternoonStart.Text = "Afternoon Shift Start:";
            layoutItemAfternoonStart.TextSize = new System.Drawing.Size(119, 13);
            this.layoutControlGroup1.Items.Add(layoutItemAfternoonStart);
            
            // timeEditAfternoonEnd
            this.timeEditAfternoonEnd.EditValue = new System.DateTime(2023, 1, 1, 17, 0, 0, 0);
            this.timeEditAfternoonEnd.Location = new System.Drawing.Point(134, 84);
            this.timeEditAfternoonEnd.Name = "timeEditAfternoonEnd";
            this.timeEditAfternoonEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditAfternoonEnd.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditAfternoonEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditAfternoonEnd.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditAfternoonEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditAfternoonEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditAfternoonEnd.Size = new System.Drawing.Size(326, 20);
            this.timeEditAfternoonEnd.StyleController = this.layoutControl2;
            this.timeEditAfternoonEnd.TabIndex = 7;
            
            // Add Afternoon End to layout
            var layoutItemAfternoonEnd = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemAfternoonEnd.Control = this.timeEditAfternoonEnd;
            layoutItemAfternoonEnd.Location = new System.Drawing.Point(0, 72);
            layoutItemAfternoonEnd.Name = "layoutItemAfternoonEnd";
            layoutItemAfternoonEnd.Size = new System.Drawing.Size(452, 24);
            layoutItemAfternoonEnd.Text = "Afternoon Shift End:";
            layoutItemAfternoonEnd.TextSize = new System.Drawing.Size(119, 13);
            this.layoutControlGroup1.Items.Add(layoutItemAfternoonEnd);
            
            // Add groupControl1 to main layout
            var layoutItemGroup1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGroup1.Control = this.groupControl1;
            layoutItemGroup1.Location = new System.Drawing.Point(0, 0);
            layoutItemGroup1.Name = "layoutItemGroup1";
            layoutItemGroup1.Size = new System.Drawing.Size(480, 124);
            layoutItemGroup1.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGroup1.TextVisible = false;
            this.Root.Items.Add(layoutItemGroup1);
            
            // groupControl2
            this.groupControl2.Controls.Add(this.layoutControl3);
            this.groupControl2.Location = new System.Drawing.Point(12, 136);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(476, 120);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Thresholds";
            
            // layoutControl3
            this.layoutControl3.Controls.Add(this.timeEditLateThreshold);
            this.layoutControl3.Controls.Add(this.timeEditEarlyThreshold);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(2, 23);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(472, 95);
            this.layoutControl3.TabIndex = 0;
            this.layoutControl3.Text = "layoutControl3";
            
            // layoutControlGroup2
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(472, 95);
            this.layoutControlGroup2.TextVisible = false;
            
            // timeEditLateThreshold
            this.timeEditLateThreshold.EditValue = new System.DateTime(2023, 1, 1, 0, 15, 0, 0);
            this.timeEditLateThreshold.Location = new System.Drawing.Point(150, 12);
            this.timeEditLateThreshold.Name = "timeEditLateThreshold";
            this.timeEditLateThreshold.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditLateThreshold.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditLateThreshold.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditLateThreshold.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditLateThreshold.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditLateThreshold.Properties.Mask.EditMask = "HH:mm";
            this.timeEditLateThreshold.Size = new System.Drawing.Size(310, 20);
            this.timeEditLateThreshold.StyleController = this.layoutControl3;
            this.timeEditLateThreshold.TabIndex = 4;
            
            // Add Late Threshold to layout
            var layoutItemLateThreshold = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemLateThreshold.Control = this.timeEditLateThreshold;
            layoutItemLateThreshold.Location = new System.Drawing.Point(0, 0);
            layoutItemLateThreshold.Name = "layoutItemLateThreshold";
            layoutItemLateThreshold.Size = new System.Drawing.Size(452, 24);
            layoutItemLateThreshold.Text = "Late Arrival Threshold:";
            layoutItemLateThreshold.TextSize = new System.Drawing.Size(135, 13);
            this.layoutControlGroup2.Items.Add(layoutItemLateThreshold);
            
            // timeEditEarlyThreshold
            this.timeEditEarlyThreshold.EditValue = new System.DateTime(2023, 1, 1, 0, 15, 0, 0);
            this.timeEditEarlyThreshold.Location = new System.Drawing.Point(150, 36);
            this.timeEditEarlyThreshold.Name = "timeEditEarlyThreshold";
            this.timeEditEarlyThreshold.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditEarlyThreshold.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditEarlyThreshold.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEarlyThreshold.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditEarlyThreshold.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEarlyThreshold.Properties.Mask.EditMask = "HH:mm";
            this.timeEditEarlyThreshold.Size = new System.Drawing.Size(310, 20);
            this.timeEditEarlyThreshold.StyleController = this.layoutControl3;
            this.timeEditEarlyThreshold.TabIndex = 5;
            
            // Add Early Threshold to layout
            var layoutItemEarlyThreshold = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemEarlyThreshold.Control = this.timeEditEarlyThreshold;
            layoutItemEarlyThreshold.Location = new System.Drawing.Point(0, 24);
            layoutItemEarlyThreshold.Name = "layoutItemEarlyThreshold";
            layoutItemEarlyThreshold.Size = new System.Drawing.Size(452, 24);
            layoutItemEarlyThreshold.Text = "Early Departure Threshold:";
            layoutItemEarlyThreshold.TextSize = new System.Drawing.Size(135, 13);
            this.layoutControlGroup2.Items.Add(layoutItemEarlyThreshold);
            
            // Add empty space
            var emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(452, 27);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup2.Items.Add(emptySpaceItem1);
            
            // Add groupControl2 to main layout
            var layoutItemGroup2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGroup2.Control = this.groupControl2;
            layoutItemGroup2.Location = new System.Drawing.Point(0, 124);
            layoutItemGroup2.Name = "layoutItemGroup2";
            layoutItemGroup2.Size = new System.Drawing.Size(480, 124);
            layoutItemGroup2.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGroup2.TextVisible = false;
            this.Root.Items.Add(layoutItemGroup2);
            
            // groupControl3
            this.groupControl3.Controls.Add(this.layoutControl4);
            this.groupControl3.Location = new System.Drawing.Point(12, 260);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(476, 120);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Overtime";
            
            // layoutControl4
            this.layoutControl4.Controls.Add(this.timeEditOvertimeStart);
            this.layoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl4.Location = new System.Drawing.Point(2, 23);
            this.layoutControl4.Name = "layoutControl4";
            this.layoutControl4.Root = this.layoutControlGroup3;
            this.layoutControl4.Size = new System.Drawing.Size(472, 95);
            this.layoutControl4.TabIndex = 0;
            this.layoutControl4.Text = "layoutControl4";
            
            // layoutControlGroup3
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(472, 95);
            this.layoutControlGroup3.TextVisible = false;
            
            // timeEditOvertimeStart
            this.timeEditOvertimeStart.EditValue = new System.DateTime(2023, 1, 1, 17, 30, 0, 0);
            this.timeEditOvertimeStart.Location = new System.Drawing.Point(114, 12);
            this.timeEditOvertimeStart.Name = "timeEditOvertimeStart";
            this.timeEditOvertimeStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.timeEditOvertimeStart.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeEditOvertimeStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditOvertimeStart.Properties.EditFormat.FormatString = "HH:mm";
            this.timeEditOvertimeStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditOvertimeStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditOvertimeStart.Size = new System.Drawing.Size(346, 20);
            this.timeEditOvertimeStart.StyleController = this.layoutControl4;
            this.timeEditOvertimeStart.TabIndex = 4;
            
            // Add Overtime Start to layout
            var layoutItemOvertimeStart = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemOvertimeStart.Control = this.timeEditOvertimeStart;
            layoutItemOvertimeStart.Location = new System.Drawing.Point(0, 0);
            layoutItemOvertimeStart.Name = "layoutItemOvertimeStart";
            layoutItemOvertimeStart.Size = new System.Drawing.Size(452, 24);
            layoutItemOvertimeStart.Text = "Overtime Start:";
            layoutItemOvertimeStart.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlGroup3.Items.Add(layoutItemOvertimeStart);
            
            // Add empty space
            var emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new System.Drawing.Size(452, 51);
            emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup3.Items.Add(emptySpaceItem2);
            
            // Add groupControl3 to main layout
            var layoutItemGroup3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGroup3.Control = this.groupControl3;
            layoutItemGroup3.Location = new System.Drawing.Point(0, 248);
            layoutItemGroup3.Name = "layoutItemGroup3";
            layoutItemGroup3.Size = new System.Drawing.Size(480, 124);
            layoutItemGroup3.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGroup3.TextVisible = false;
            this.Root.Items.Add(layoutItemGroup3);
            
            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Settings";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // Add btnSave to main layout
            var layoutItemSave = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSave.Control = this.btnSave;
            layoutItemSave.Location = new System.Drawing.Point(0, 372);
            layoutItemSave.Name = "layoutItemSave";
            layoutItemSave.Size = new System.Drawing.Size(146, 26);
            layoutItemSave.TextSize = new System.Drawing.Size(0, 0);
            layoutItemSave.TextVisible = false;
            this.Root.Items.Add(layoutItemSave);
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(346, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // Add btnCancel to main layout
            var layoutItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCancel.Control = this.btnCancel;
            layoutItemCancel.Location = new System.Drawing.Point(334, 372);
            layoutItemCancel.Name = "layoutItemCancel";
            layoutItemCancel.Size = new System.Drawing.Size(146, 26);
            layoutItemCancel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemCancel.TextVisible = false;
            this.Root.Items.Add(layoutItemCancel);
            
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(158, 384);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(184, 22);
            this.btnReset.StyleController = this.layoutControl1;
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset to Default";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            // Add btnReset to main layout
            var layoutItemReset = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemReset.Control = this.btnReset;
            layoutItemReset.Location = new System.Drawing.Point(146, 372);
            layoutItemReset.Name = "layoutItemReset";
            layoutItemReset.Size = new System.Drawing.Size(188, 26);
            layoutItemReset.TextSize = new System.Drawing.Size(0, 0);
            layoutItemReset.TextVisible = false;
            this.Root.Items.Add(layoutItemReset);
            
            // Add empty space
            var emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem3.AllowHotTrack = false;
            emptySpaceItem3.Location = new System.Drawing.Point(0, 398);
            emptySpaceItem3.Name = "emptySpaceItem3";
            emptySpaceItem3.Size = new System.Drawing.Size(480, 32);
            emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            this.Root.Items.Add(emptySpaceItem3);
            
            // TimeSettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Time Settings";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditMorningEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditAfternoonStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditAfternoonEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditLateThreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEarlyThreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditOvertimeStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).EndInit();
            this.layoutControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningStart;
        private DevExpress.XtraEditors.TimeEdit timeEditMorningEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditAfternoonStart;
        private DevExpress.XtraEditors.TimeEdit timeEditAfternoonEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditLateThreshold;
        private DevExpress.XtraEditors.TimeEdit timeEditEarlyThreshold;
        private DevExpress.XtraEditors.TimeEdit timeEditOvertimeStart;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraLayout.LayoutControl layoutControl4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
    }
}