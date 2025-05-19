using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

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
            DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
            DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
            DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
            DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
            this.btnConnectionSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnTimeSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeviceManagement = new DevExpress.XtraBars.BarButtonItem();
            this.btnAttendanceMonitor = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataStorage = new DevExpress.XtraBars.BarButtonItem();
            this.btnPermissions = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.lblStatus = new DevExpress.XtraBars.BarStaticItem();
            this.lblConnectionInfo = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            
            // ribbonPageGroup1
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Connection";
            
            // ribbonPageGroup2
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Settings";
            
            // ribbonPageGroup3
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Attendance";
            
            // ribbonPageGroup4
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "System";
            
            // btnConnectionSettings
            this.btnConnectionSettings.Caption = "Connection Settings";
            this.btnConnectionSettings.Id = 1;
            this.btnConnectionSettings.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile("pack://application:,,,/DevExpress.Images.v22.2;component/Images/RichEdit/ServerMode.svg");
            this.btnConnectionSettings.Name = "btnConnectionSettings";
            this.btnConnectionSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnectionSettings_ItemClick);
            
            // btnTimeSettings
            this.btnTimeSettings.Caption = "Time Settings";
            this.btnTimeSettings.Id = 2;
            this.btnTimeSettings.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile("pack://application:,,,/DevExpress.Images.v22.2;component/Images/Schedule/Time.svg");
            this.btnTimeSettings.Name = "btnTimeSettings";
            this.btnTimeSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTimeSettings_ItemClick);
            
            // btnDeviceManagement
            this.btnDeviceManagement.Caption = "Device Management";
            this.btnDeviceManagement.Id = 3;
            this.btnDeviceManagement.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile("pack://application:,,,/DevExpress.Images.v22.2;component/Images/Setup/Device.svg");
            this.btnDeviceManagement.Name = "btnDeviceManagement";
            this.btnDeviceManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeviceManagement_ItemClick);
            
            // btnAttendanceMonitor
            this.btnAttendanceMonitor.Caption = "Attendance Monitor";
            this.btnAttendanceMonitor.Id = 4;
            this.btnAttendanceMonitor.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile("pack://application:,,,/DevExpress.Images.v22.2;component/Images/Business%20Objects/BO_Customer.svg");
            this.btnAttendanceMonitor.Name = "btnAttendanceMonitor";
            this.btnAttendanceMonitor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAttendanceMonitor_ItemClick);
            
            // btnDataStorage
            this.btnDataStorage.Caption = "Data Storage";
            this.btnDataStorage.Id = 5;
            this.btnDataStorage.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile("pack://application:,,,/DevExpress.Images.v22.2;component/Images/Data/Database.svg");
            this.btnDataStorage.Name = "btnDataStorage";
            this.btnDataStorage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataStorage_ItemClick);
            
            // btnPermissions
            this.btnPermissions.Caption = "User Permissions";
            this.btnPermissions.Id = 6;
            this.btnPermissions.ImageOptions.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile("pack://application:,,,/DevExpress.Images.v22.2;component/Images/Security/Security.svg");
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPermissions_ItemClick);
            
            // ribbonControl
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbonControl.ExpandCollapseItem,
                this.btnConnectionSettings,
                this.btnTimeSettings,
                this.btnDeviceManagement,
                this.btnAttendanceMonitor,
                this.btnDataStorage,
                this.btnPermissions,
                this.lblStatus,
                this.lblConnectionInfo
            });
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 9;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPage1
            });
            this.ribbonControl.Size = new System.Drawing.Size(1000, 158);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            
            // ribbonPage1
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                ribbonPageGroup1,
                ribbonPageGroup2,
                ribbonPageGroup3,
                ribbonPageGroup4
            });
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Main";
            
            // Add items to groups
            ribbonPageGroup1.ItemLinks.Add(this.btnConnectionSettings);
            ribbonPageGroup2.ItemLinks.Add(this.btnTimeSettings);
            ribbonPageGroup2.ItemLinks.Add(this.btnDeviceManagement);
            ribbonPageGroup3.ItemLinks.Add(this.btnAttendanceMonitor);
            ribbonPageGroup3.ItemLinks.Add(this.btnDataStorage);
            ribbonPageGroup4.ItemLinks.Add(this.btnPermissions);
            
            // defaultLookAndFeel1
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2019 Colorful";
            
            // lblStatus
            this.lblStatus.Caption = "Status: Disconnected";
            this.lblStatus.Id = 7;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            
            // lblConnectionInfo
            this.lblConnectionInfo.Caption = "Last connection: None";
            this.lblConnectionInfo.Id = 8;
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            
            // ribbonStatusBar
            this.ribbonStatusBar.ItemLinks.Add(this.lblStatus);
            this.ribbonStatusBar.ItemLinks.Add(this.lblConnectionInfo);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 678);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1000, 22);
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "ZKTeco Attendance System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem btnConnectionSettings;
        private DevExpress.XtraBars.BarButtonItem btnTimeSettings;
        private DevExpress.XtraBars.BarButtonItem btnDeviceManagement;
        private DevExpress.XtraBars.BarButtonItem btnAttendanceMonitor;
        private DevExpress.XtraBars.BarButtonItem btnDataStorage;
        private DevExpress.XtraBars.BarButtonItem btnPermissions;
        private DevExpress.XtraBars.BarStaticItem lblStatus;
        private DevExpress.XtraBars.BarStaticItem lblConnectionInfo;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
    }
}