using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class DeviceManagementForm
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
            this.groupDevice = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlDevice = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupDevice = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtDeviceID = new DevExpress.XtraEditors.TextEdit();
            this.txtFirmwareVersion = new DevExpress.XtraEditors.TextEdit();
            this.chkSound = new DevExpress.XtraEditors.CheckEdit();
            this.txtDeviceLanguage = new DevExpress.XtraEditors.TextEdit();
            this.btnGetDeviceInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetDeviceInfo = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupActions = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlActions = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupActions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnSyncTime = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnableDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisableDevice = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupStatus = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlStatus = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroupStatus = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblStatusValue = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDevice)).BeginInit();
            this.groupDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDevice)).BeginInit();
            this.layoutControlDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmwareVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSound.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupActions)).BeginInit();
            this.groupActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlActions)).BeginInit();
            this.layoutControlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupStatus)).BeginInit();
            this.groupStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlStatus)).BeginInit();
            this.layoutControlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupDevice);
            this.layoutControl1.Controls.Add(this.groupActions);
            this.layoutControl1.Controls.Add(this.groupStatus);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(600, 500);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutControlItem1,
                this.layoutControlItem2,
                this.layoutControlItem3,
                this.layoutControlItem4,
                this.emptySpaceItem1
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(600, 500);
            this.Root.TextVisible = false;
            
            // groupDevice
            this.groupDevice.Controls.Add(this.layoutControlDevice);
            this.groupDevice.Location = new System.Drawing.Point(12, 12);
            this.groupDevice.Name = "groupDevice";
            this.groupDevice.Size = new System.Drawing.Size(576, 180);
            this.groupDevice.Text = "Device Information";
            this.groupDevice.TabIndex = 4;
            
            // layoutControlDevice
            this.layoutControlDevice.Controls.Add(this.txtDeviceID);
            this.layoutControlDevice.Controls.Add(this.txtFirmwareVersion);
            this.layoutControlDevice.Controls.Add(this.chkSound);
            this.layoutControlDevice.Controls.Add(this.txtDeviceLanguage);
            this.layoutControlDevice.Controls.Add(this.btnGetDeviceInfo);
            this.layoutControlDevice.Controls.Add(this.btnSetDeviceInfo);
            this.layoutControlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlDevice.Location = new System.Drawing.Point(2, 23);
            this.layoutControlDevice.Name = "layoutControlDevice";
            this.layoutControlDevice.Root = this.layoutControlGroupDevice;
            this.layoutControlDevice.Size = new System.Drawing.Size(572, 155);
            this.layoutControlDevice.TabIndex = 0;
            this.layoutControlDevice.Text = "layoutControl2";
            
            // layoutControlGroupDevice
            this.layoutControlGroupDevice.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupDevice.GroupBordersVisible = false;
            this.layoutControlGroupDevice.Name = "layoutControlGroupDevice";
            this.layoutControlGroupDevice.Size = new System.Drawing.Size(572, 155);
            this.layoutControlGroupDevice.TextVisible = false;
            
            // txtDeviceID
            this.txtDeviceID.Location = new System.Drawing.Point(122, 12);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(438, 20);
            this.txtDeviceID.StyleController = this.layoutControlDevice;
            this.txtDeviceID.TabIndex = 4;
            
            // Add Device ID control to layout
            var layoutItemDeviceID = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDeviceID.Control = this.txtDeviceID;
            layoutItemDeviceID.Location = new System.Drawing.Point(0, 0);
            layoutItemDeviceID.Name = "layoutItemDeviceID";
            layoutItemDeviceID.Size = new System.Drawing.Size(552, 24);
            layoutItemDeviceID.Text = "Device ID:";
            layoutItemDeviceID.TextSize = new System.Drawing.Size(107, 13);
            this.layoutControlGroupDevice.Items.Add(layoutItemDeviceID);
            
            // txtFirmwareVersion
            this.txtFirmwareVersion.Location = new System.Drawing.Point(122, 36);
            this.txtFirmwareVersion.Name = "txtFirmwareVersion";
            this.txtFirmwareVersion.Properties.ReadOnly = true;
            this.txtFirmwareVersion.Size = new System.Drawing.Size(438, 20);
            this.txtFirmwareVersion.StyleController = this.layoutControlDevice;
            this.txtFirmwareVersion.TabIndex = 5;
            
            // Add Firmware Version control to layout
            var layoutItemFirmwareVersion = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemFirmwareVersion.Control = this.txtFirmwareVersion;
            layoutItemFirmwareVersion.Location = new System.Drawing.Point(0, 24);
            layoutItemFirmwareVersion.Name = "layoutItemFirmwareVersion";
            layoutItemFirmwareVersion.Size = new System.Drawing.Size(552, 24);
            layoutItemFirmwareVersion.Text = "Firmware Version:";
            layoutItemFirmwareVersion.TextSize = new System.Drawing.Size(107, 13);
            this.layoutControlGroupDevice.Items.Add(layoutItemFirmwareVersion);
            
            // chkSound
            this.chkSound.Location = new System.Drawing.Point(122, 60);
            this.chkSound.Name = "chkSound";
            this.chkSound.Properties.Caption = "";
            this.chkSound.Size = new System.Drawing.Size(438, 20);
            this.chkSound.StyleController = this.layoutControlDevice;
            this.chkSound.TabIndex = 6;
            
            // Add Sound control to layout
            var layoutItemSound = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSound.Control = this.chkSound;
            layoutItemSound.Location = new System.Drawing.Point(0, 48);
            layoutItemSound.Name = "layoutItemSound";
            layoutItemSound.Size = new System.Drawing.Size(552, 24);
            layoutItemSound.Text = "Sound Enabled:";
            layoutItemSound.TextSize = new System.Drawing.Size(107, 13);
            this.layoutControlGroupDevice.Items.Add(layoutItemSound);
            
            // txtDeviceLanguage
            this.txtDeviceLanguage.Location = new System.Drawing.Point(122, 84);
            this.txtDeviceLanguage.Name = "txtDeviceLanguage";
            this.txtDeviceLanguage.Size = new System.Drawing.Size(438, 20);
            this.txtDeviceLanguage.StyleController = this.layoutControlDevice;
            this.txtDeviceLanguage.TabIndex = 7;
            
            // Add Device Language control to layout
            var layoutItemDeviceLanguage = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDeviceLanguage.Control = this.txtDeviceLanguage;
            layoutItemDeviceLanguage.Location = new System.Drawing.Point(0, 72);
            layoutItemDeviceLanguage.Name = "layoutItemDeviceLanguage";
            layoutItemDeviceLanguage.Size = new System.Drawing.Size(552, 24);
            layoutItemDeviceLanguage.Text = "Device Language:";
            layoutItemDeviceLanguage.TextSize = new System.Drawing.Size(107, 13);
            this.layoutControlGroupDevice.Items.Add(layoutItemDeviceLanguage);
            
            // btnGetDeviceInfo
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(12, 108);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(273, 22);
            this.btnGetDeviceInfo.StyleController = this.layoutControlDevice;
            this.btnGetDeviceInfo.TabIndex = 8;
            this.btnGetDeviceInfo.Text = "Get Device Info";
            this.btnGetDeviceInfo.Click += new System.EventHandler(this.btnGetDeviceInfo_Click);
            
            // Add Get Device Info button to layout
            var layoutItemGetDeviceInfo = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGetDeviceInfo.Control = this.btnGetDeviceInfo;
            layoutItemGetDeviceInfo.Location = new System.Drawing.Point(0, 96);
            layoutItemGetDeviceInfo.Name = "layoutItemGetDeviceInfo";
            layoutItemGetDeviceInfo.Size = new System.Drawing.Size(277, 26);
            layoutItemGetDeviceInfo.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGetDeviceInfo.TextVisible = false;
            this.layoutControlGroupDevice.Items.Add(layoutItemGetDeviceInfo);
            
            // btnSetDeviceInfo
            this.btnSetDeviceInfo.Location = new System.Drawing.Point(289, 108);
            this.btnSetDeviceInfo.Name = "btnSetDeviceInfo";
            this.btnSetDeviceInfo.Size = new System.Drawing.Size(271, 22);
            this.btnSetDeviceInfo.StyleController = this.layoutControlDevice;
            this.btnSetDeviceInfo.TabIndex = 9;
            this.btnSetDeviceInfo.Text = "Set Device Info";
            this.btnSetDeviceInfo.Click += new System.EventHandler(this.btnSetDeviceInfo_Click);
            
            // Add Set Device Info button to layout
            var layoutItemSetDeviceInfo = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSetDeviceInfo.Control = this.btnSetDeviceInfo;
            layoutItemSetDeviceInfo.Location = new System.Drawing.Point(277, 96);
            layoutItemSetDeviceInfo.Name = "layoutItemSetDeviceInfo";
            layoutItemSetDeviceInfo.Size = new System.Drawing.Size(275, 26);
            layoutItemSetDeviceInfo.TextSize = new System.Drawing.Size(0, 0);
            layoutItemSetDeviceInfo.TextVisible = false;
            this.layoutControlGroupDevice.Items.Add(layoutItemSetDeviceInfo);
            
            // layoutControlItem1
            this.layoutControlItem1.Control = this.groupDevice;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(580, 184);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            
            // groupActions
            this.groupActions.Controls.Add(this.layoutControlActions);
            this.groupActions.Location = new System.Drawing.Point(12, 196);
            this.groupActions.Name = "groupActions";
            this.groupActions.Size = new System.Drawing.Size(576, 156);
            this.groupActions.Text = "Device Actions";
            this.groupActions.TabIndex = 5;
            
            // layoutControlActions
            this.layoutControlActions.Controls.Add(this.btnSyncTime);
            this.layoutControlActions.Controls.Add(this.btnEnableDevice);
            this.layoutControlActions.Controls.Add(this.btnDisableDevice);
            this.layoutControlActions.Controls.Add(this.btnClearData);
            this.layoutControlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlActions.Location = new System.Drawing.Point(2, 23);
            this.layoutControlActions.Name = "layoutControlActions";
            this.layoutControlActions.Root = this.layoutControlGroupActions;
            this.layoutControlActions.Size = new System.Drawing.Size(572, 131);
            this.layoutControlActions.TabIndex = 0;
            this.layoutControlActions.Text = "layoutControl3";
            
            // layoutControlGroupActions
            this.layoutControlGroupActions.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupActions.GroupBordersVisible = false;
            this.layoutControlGroupActions.Name = "layoutControlGroupActions";
            this.layoutControlGroupActions.Size = new System.Drawing.Size(572, 131);
            this.layoutControlGroupActions.TextVisible = false;
            
            // btnSyncTime
            this.btnSyncTime.Location = new System.Drawing.Point(12, 12);
            this.btnSyncTime.Name = "btnSyncTime";
            this.btnSyncTime.Size = new System.Drawing.Size(548, 22);
            this.btnSyncTime.StyleController = this.layoutControlActions;
            this.btnSyncTime.TabIndex = 4;
            this.btnSyncTime.Text = "Synchronize Device Time with System Time";
            this.btnSyncTime.Click += new System.EventHandler(this.btnSyncTime_Click);
            
            // Add Sync Time button to layout
            var layoutItemSyncTime = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSyncTime.Control = this.btnSyncTime;
            layoutItemSyncTime.Location = new System.Drawing.Point(0, 0);
            layoutItemSyncTime.Name = "layoutItemSyncTime";
            layoutItemSyncTime.Size = new System.Drawing.Size(552, 26);
            layoutItemSyncTime.TextSize = new System.Drawing.Size(0, 0);
            layoutItemSyncTime.TextVisible = false;
            this.layoutControlGroupActions.Items.Add(layoutItemSyncTime);
            
            // btnEnableDevice
            this.btnEnableDevice.Location = new System.Drawing.Point(12, 38);
            this.btnEnableDevice.Name = "btnEnableDevice";
            this.btnEnableDevice.Size = new System.Drawing.Size(269, 22);
            this.btnEnableDevice.StyleController = this.layoutControlActions;
            this.btnEnableDevice.TabIndex = 5;
            this.btnEnableDevice.Text = "Enable Device";
            this.btnEnableDevice.Click += new System.EventHandler(this.btnEnableDevice_Click);
            
            // Add Enable Device button to layout
            var layoutItemEnableDevice = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemEnableDevice.Control = this.btnEnableDevice;
            layoutItemEnableDevice.Location = new System.Drawing.Point(0, 26);
            layoutItemEnableDevice.Name = "layoutItemEnableDevice";
            layoutItemEnableDevice.Size = new System.Drawing.Size(273, 26);
            layoutItemEnableDevice.TextSize = new System.Drawing.Size(0, 0);
            layoutItemEnableDevice.TextVisible = false;
            this.layoutControlGroupActions.Items.Add(layoutItemEnableDevice);
            
            // btnDisableDevice
            this.btnDisableDevice.Location = new System.Drawing.Point(285, 38);
            this.btnDisableDevice.Name = "btnDisableDevice";
            this.btnDisableDevice.Size = new System.Drawing.Size(275, 22);
            this.btnDisableDevice.StyleController = this.layoutControlActions;
            this.btnDisableDevice.TabIndex = 6;
            this.btnDisableDevice.Text = "Disable Device";
            this.btnDisableDevice.Click += new System.EventHandler(this.btnDisableDevice_Click);
            
            // Add Disable Device button to layout
            var layoutItemDisableDevice = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDisableDevice.Control = this.btnDisableDevice;
            layoutItemDisableDevice.Location = new System.Drawing.Point(273, 26);
            layoutItemDisableDevice.Name = "layoutItemDisableDevice";
            layoutItemDisableDevice.Size = new System.Drawing.Size(279, 26);
            layoutItemDisableDevice.TextSize = new System.Drawing.Size(0, 0);
            layoutItemDisableDevice.TextVisible = false;
            this.layoutControlGroupActions.Items.Add(layoutItemDisableDevice);
            
            // btnClearData
            this.btnClearData.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnClearData.Appearance.Options.UseBackColor = true;
            this.btnClearData.Location = new System.Drawing.Point(12, 64);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(548, 22);
            this.btnClearData.StyleController = this.layoutControlActions;
            this.btnClearData.TabIndex = 7;
            this.btnClearData.Text = "Clear All Attendance Data from Device";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            
            // Add Clear Data button to layout
            var layoutItemClearData = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemClearData.Control = this.btnClearData;
            layoutItemClearData.Location = new System.Drawing.Point(0, 52);
            layoutItemClearData.Name = "layoutItemClearData";
            layoutItemClearData.Size = new System.Drawing.Size(552, 26);
            layoutItemClearData.TextSize = new System.Drawing.Size(0, 0);
            layoutItemClearData.TextVisible = false;
            this.layoutControlGroupActions.Items.Add(layoutItemClearData);
            
            // Add empty space to the bottom of actions layout
            var emptySpaceItemActions = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItemActions.AllowHotTrack = false;
            emptySpaceItemActions.Location = new System.Drawing.Point(0, 78);
            emptySpaceItemActions.Name = "emptySpaceItemActions";
            emptySpaceItemActions.Size = new System.Drawing.Size(552, 33);
            emptySpaceItemActions.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroupActions.Items.Add(emptySpaceItemActions);
            
            // layoutControlItem2
            this.layoutControlItem2.Control = this.groupActions;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 184);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(580, 160);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            
            // groupStatus
            this.groupStatus.Controls.Add(this.layoutControlStatus);
            this.groupStatus.Location = new System.Drawing.Point(12, 356);
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(576, 95);
            this.groupStatus.Text = "Status";
            this.groupStatus.TabIndex = 6;
            
            // layoutControlStatus
            this.layoutControlStatus.Controls.Add(this.lblStatus);
            this.layoutControlStatus.Controls.Add(this.lblStatusValue);
            this.layoutControlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlStatus.Location = new System.Drawing.Point(2, 23);
            this.layoutControlStatus.Name = "layoutControlStatus";
            this.layoutControlStatus.Root = this.layoutControlGroupStatus;
            this.layoutControlStatus.Size = new System.Drawing.Size(572, 70);
            this.layoutControlStatus.TabIndex = 0;
            this.layoutControlStatus.Text = "layoutControl4";
            
            // layoutControlGroupStatus
            this.layoutControlGroupStatus.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupStatus.GroupBordersVisible = false;
            this.layoutControlGroupStatus.Name = "layoutControlGroupStatus";
            this.layoutControlGroupStatus.Size = new System.Drawing.Size(572, 70);
            this.layoutControlGroupStatus.TextVisible = false;
            
            // lblStatus
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 13);
            this.lblStatus.StyleController = this.layoutControlStatus;
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            
            // Add Status label to layout
            var layoutItemStatusLabel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatusLabel.Control = this.lblStatus;
            layoutItemStatusLabel.Location = new System.Drawing.Point(0, 0);
            layoutItemStatusLabel.Name = "layoutItemStatusLabel";
            layoutItemStatusLabel.Size = new System.Drawing.Size(79, 17);
            layoutItemStatusLabel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatusLabel.TextVisible = false;
            this.layoutControlGroupStatus.Items.Add(layoutItemStatusLabel);
            
            // lblStatusValue
            this.lblStatusValue.Location = new System.Drawing.Point(91, 12);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(469, 13);
            this.lblStatusValue.StyleController = this.layoutControlStatus;
            this.lblStatusValue.TabIndex = 5;
            this.lblStatusValue.Text = "Ready";
            
            // Add Status Value label to layout
            var layoutItemStatusValue = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatusValue.Control = this.lblStatusValue;
            layoutItemStatusValue.Location = new System.Drawing.Point(79, 0);
            layoutItemStatusValue.Name = "layoutItemStatusValue";
            layoutItemStatusValue.Size = new System.Drawing.Size(473, 17);
            layoutItemStatusValue.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatusValue.TextVisible = false;
            this.layoutControlGroupStatus.Items.Add(layoutItemStatusValue);
            
            // Add empty space below status labels
            var emptySpaceItemStatus = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItemStatus.AllowHotTrack = false;
            emptySpaceItemStatus.Location = new System.Drawing.Point(0, 17);
            emptySpaceItemStatus.Name = "emptySpaceItemStatus";
            emptySpaceItemStatus.Size = new System.Drawing.Size(552, 33);
            emptySpaceItemStatus.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroupStatus.Items.Add(emptySpaceItemStatus);
            
            // layoutControlItem3
            this.layoutControlItem3.Control = this.groupStatus;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 344);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(580, 99);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            
            // btnClose
            this.btnClose.Location = new System.Drawing.Point(513, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // layoutControlItem4
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(501, 443);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(79, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            
            // emptySpaceItem1
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 443);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(501, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            
            // DeviceManagementForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.layoutControl1);
            this.Name = "DeviceManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Device Management";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupDevice)).EndInit();
            this.groupDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDevice)).EndInit();
            this.layoutControlDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmwareVersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSound.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeviceLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupActions)).EndInit();
            this.groupActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlActions)).EndInit();
            this.layoutControlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupStatus)).EndInit();
            this.groupStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlStatus)).EndInit();
            this.layoutControlStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl groupDevice;
        private DevExpress.XtraLayout.LayoutControl layoutControlDevice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupDevice;
        private DevExpress.XtraEditors.TextEdit txtDeviceID;
        private DevExpress.XtraEditors.TextEdit txtFirmwareVersion;
        private DevExpress.XtraEditors.CheckEdit chkSound;
        private DevExpress.XtraEditors.TextEdit txtDeviceLanguage;
        private DevExpress.XtraEditors.SimpleButton btnGetDeviceInfo;
        private DevExpress.XtraEditors.SimpleButton btnSetDeviceInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GroupControl groupActions;
        private DevExpress.XtraLayout.LayoutControl layoutControlActions;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupActions;
        private DevExpress.XtraEditors.SimpleButton btnSyncTime;
        private DevExpress.XtraEditors.SimpleButton btnEnableDevice;
        private DevExpress.XtraEditors.SimpleButton btnDisableDevice;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.GroupControl groupStatus;
        private DevExpress.XtraLayout.LayoutControl layoutControlStatus;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupStatus;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblStatusValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}