using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemUsers = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemTimeSettings = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemDeviceManagement = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemAttendanceMonitor = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemDataStorage = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAbout = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisconnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpacer1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpacer2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpacer3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
            
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            
            // navBarControl
            this.navBarControl.ActiveGroup = this.navBarGroup1;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
                this.navBarGroup1,
                this.navBarGroup2});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
                this.navBarItemUsers,
                this.navBarItemTimeSettings,
                this.navBarItemDeviceManagement,
                this.navBarItemAttendanceMonitor,
                this.navBarItemDataStorage});
            this.navBarControl.Location = new System.Drawing.Point(0, 78);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 200;
            this.navBarControl.Size = new System.Drawing.Size(200, 522);
            this.navBarControl.TabIndex = 0;
            this.navBarControl.Text = "navBarControl1";
            
            // navBarGroup1
            this.navBarGroup1.Caption = "Settings";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
                new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemUsers),
                new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemTimeSettings)});
            this.navBarGroup1.Name = "navBarGroup1";
            
            // navBarItemUsers
            this.navBarItemUsers.Caption = "User Management";
            this.navBarItemUsers.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItemUsers.ImageOptions.SvgImage")));
            this.navBarItemUsers.Name = "navBarItemUsers";
            this.navBarItemUsers.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemUsers_LinkClicked);
            
            // navBarItemTimeSettings
            this.navBarItemTimeSettings.Caption = "Time Settings";
            this.navBarItemTimeSettings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItemTimeSettings.ImageOptions.SvgImage")));
            this.navBarItemTimeSettings.Name = "navBarItemTimeSettings";
            this.navBarItemTimeSettings.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemTimeSettings_LinkClicked);
            
            // navBarGroup2
            this.navBarGroup2.Caption = "Device";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
                new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDeviceManagement),
                new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAttendanceMonitor),
                new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemDataStorage)});
            this.navBarGroup2.Name = "navBarGroup2";
            
            // navBarItemDeviceManagement
            this.navBarItemDeviceManagement.Caption = "Device Management";
            this.navBarItemDeviceManagement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItemDeviceManagement.ImageOptions.SvgImage")));
            this.navBarItemDeviceManagement.Name = "navBarItemDeviceManagement";
            this.navBarItemDeviceManagement.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDeviceManagement_LinkClicked);
            
            // navBarItemAttendanceMonitor
            this.navBarItemAttendanceMonitor.Caption = "Attendance Monitor";
            this.navBarItemAttendanceMonitor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItemAttendanceMonitor.ImageOptions.SvgImage")));
            this.navBarItemAttendanceMonitor.Name = "navBarItemAttendanceMonitor";
            this.navBarItemAttendanceMonitor.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAttendanceMonitor_LinkClicked);
            
            // navBarItemDataStorage
            this.navBarItemDataStorage.Caption = "Data & Reports";
            this.navBarItemDataStorage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navBarItemDataStorage.ImageOptions.SvgImage")));
            this.navBarItemDataStorage.Name = "navBarItemDataStorage";
            this.navBarItemDataStorage.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemDataStorage_LinkClicked);
            
            // panelControl1
            this.panelControl1.Controls.Add(this.btnExit);
            this.panelControl1.Controls.Add(this.btnAbout);
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.btnDisconnect);
            this.panelControl1.Controls.Add(this.btnConnect);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1000, 78);
            this.panelControl1.TabIndex = 1;
            
            // btnExit
            this.btnExit.Appearance.Options.UseTextOptions = true;
            this.btnExit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnExit.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(325, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 60);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            
            // btnAbout
            this.btnAbout.Appearance.Options.UseTextOptions = true;
            this.btnAbout.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnAbout.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnAbout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.ImageOptions.Image")));
            this.btnAbout.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAbout.Location = new System.Drawing.Point(249, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(70, 60);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            
            // btnLogout
            this.btnLogout.Appearance.Options.UseTextOptions = true;
            this.btnLogout.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnLogout.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnLogout.Location = new System.Drawing.Point(173, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(70, 60);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            
            // btnDisconnect
            this.btnDisconnect.Appearance.Options.UseTextOptions = true;
            this.btnDisconnect.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnDisconnect.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisconnect.ImageOptions.Image")));
            this.btnDisconnect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnDisconnect.Location = new System.Drawing.Point(97, 12);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(70, 60);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            
            // btnConnect
            this.btnConnect.Appearance.Options.UseTextOptions = true;
            this.btnConnect.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnConnect.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnConnect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.ImageOptions.Image")));
            this.btnConnect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnConnect.Location = new System.Drawing.Point(21, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(70, 60);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            
            // panelControl2
            this.panelControl2.Controls.Add(this.pictureBox1);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(200, 78);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(800, 522);
            this.panelControl2.TabIndex = 2;
            
            // pictureBox1
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(325, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            
            // labelControl1
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(100, 327);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(600, 50);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ZKTeco Attendance System";
            
            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblConnectionStatus,
                this.lblSpacer1,
                this.lblUserName,
                this.lblSpacer2,
                this.lblUserRole,
                this.lblSpacer3,
                this.lblDateTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 600);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            
            // lblConnectionStatus
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(88, 17);
            this.lblConnectionStatus.Text = "Not connected";
            
            // lblSpacer1
            this.lblSpacer1.Name = "lblSpacer1";
            this.lblSpacer1.Size = new System.Drawing.Size(10, 17);
            this.lblSpacer1.Text = "|";
            
            // lblUserName
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(39, 17);
            this.lblUserName.Text = "User: ";
            
            // lblSpacer2
            this.lblSpacer2.Name = "lblSpacer2";
            this.lblSpacer2.Size = new System.Drawing.Size(10, 17);
            this.lblSpacer2.Text = "|";
            
            // lblUserRole
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(36, 17);
            this.lblUserRole.Text = "Role: ";
            
            // lblSpacer3
            this.lblSpacer3.Name = "lblSpacer3";
            this.lblSpacer3.Size = new System.Drawing.Size(10, 17);
            this.lblSpacer3.Text = "|";
            
            // lblDateTime
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(118, 17);
            this.lblDateTime.Text = "2023-01-01 00:00:00";
            
            // timerStatusUpdate
            this.timerStatusUpdate.Enabled = true;
            this.timerStatusUpdate.Interval = 1000;
            this.timerStatusUpdate.Tick += new System.EventHandler(this.timerStatusUpdate_Tick);
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 622);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZKTeco Attendance System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private NavBarControl navBarControl;
        private NavBarGroup navBarGroup1;
        private NavBarItem navBarItemUsers;
        private NavBarItem navBarItemTimeSettings;
        private NavBarGroup navBarGroup2;
        private NavBarItem navBarItemDeviceManagement;
        private NavBarItem navBarItemAttendanceMonitor;
        private NavBarItem navBarItemDataStorage;
        private PanelControl panelControl1;
        private SimpleButton btnExit;
        private SimpleButton btnAbout;
        private SimpleButton btnLogout;
        private SimpleButton btnDisconnect;
        private SimpleButton btnConnect;
        private PanelControl panelControl2;
        private PictureBox pictureBox1;
        private LabelControl labelControl1;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblConnectionStatus;
        private ToolStripStatusLabel lblSpacer1;
        private ToolStripStatusLabel lblUserName;
        private ToolStripStatusLabel lblSpacer2;
        private ToolStripStatusLabel lblUserRole;
        private ToolStripStatusLabel lblSpacer3;
        private ToolStripStatusLabel lblDateTime;
        private Timer timerStatusUpdate;
    }
}