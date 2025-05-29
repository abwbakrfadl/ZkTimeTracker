using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace ImprovedFingerprint.Forms
{
    partial class MainForm
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnConnectDevice = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisconnectDevice = new DevExpress.XtraBars.BarButtonItem();
            this.btnTimeControl = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportEmployees = new DevExpress.XtraBars.BarButtonItem();
            this.btnAttendanceReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnSyncData = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeviceInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnDatabaseSettings = new DevExpress.XtraBars.BarButtonItem();
            this.btnAbout = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            
            this.ribbonPageDevice = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupConnection = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            
            this.ribbonPageData = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupImport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupReports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            
            this.ribbonPageSettings = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupApplication = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.lblDeviceStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblDatabaseStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblDeviceInfo = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            
            // ribbonControl1
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbonControl1.ExpandCollapseItem,
                this.btnConnectDevice,
                this.btnDisconnectDevice,
                this.btnTimeControl,
                this.btnImportEmployees,
                this.btnAttendanceReport,
                this.btnSyncData,
                this.btnDeviceInfo,
                this.btnDatabaseSettings,
                this.btnAbout,
                this.btnExit});
                
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPageDevice,
                this.ribbonPageData,
                this.ribbonPageSettings});
            this.ribbonControl1.Size = new System.Drawing.Size(1200, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            
            // Setup Buttons
            SetupRibbonButtons();
            
            // Setup Pages and Groups
            SetupRibbonPages();
            
            // ribbonStatusBar1
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 600);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1200, 23);
            
            // Setup Status Bar
            SetupStatusBar();
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.lblDeviceStatus);
            this.Controls.Add(this.lblDatabaseStatus);
            this.Controls.Add(this.lblDeviceInfo);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "نظام إدارة البصمة - ZKTeco U350";
            
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private void SetupRibbonButtons()
        {
            // Device Connection Buttons
            this.btnConnectDevice.Caption = "الاتصال بالجهاز";
            this.btnConnectDevice.Id = 1;
            this.btnConnectDevice.ImageOptions.SvgImage = GetConnectIcon();
            this.btnConnectDevice.LargeImageOptions.SvgImage = GetConnectIcon();
            this.btnConnectDevice.Name = "btnConnectDevice";
            this.btnConnectDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnectDevice_ItemClick);
            
            this.btnDisconnectDevice.Caption = "قطع الاتصال";
            this.btnDisconnectDevice.Id = 2;
            this.btnDisconnectDevice.ImageOptions.SvgImage = GetDisconnectIcon();
            this.btnDisconnectDevice.LargeImageOptions.SvgImage = GetDisconnectIcon();
            this.btnDisconnectDevice.Name = "btnDisconnectDevice";
            this.btnDisconnectDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDisconnectDevice_ItemClick);
            
            // Device Management Buttons
            this.btnTimeControl.Caption = "ضبط الأوقات";
            this.btnTimeControl.Id = 3;
            this.btnTimeControl.ImageOptions.SvgImage = GetTimeIcon();
            this.btnTimeControl.LargeImageOptions.SvgImage = GetTimeIcon();
            this.btnTimeControl.Name = "btnTimeControl";
            this.btnTimeControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTimeControl_ItemClick);
            
            this.btnDeviceInfo.Caption = "معلومات الجهاز";
            this.btnDeviceInfo.Id = 7;
            this.btnDeviceInfo.ImageOptions.SvgImage = GetInfoIcon();
            this.btnDeviceInfo.LargeImageOptions.SvgImage = GetInfoIcon();
            this.btnDeviceInfo.Name = "btnDeviceInfo";
            this.btnDeviceInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeviceInfo_ItemClick);
            
            // Data Management Buttons
            this.btnImportEmployees.Caption = "استيراد الموظفين";
            this.btnImportEmployees.Id = 4;
            this.btnImportEmployees.ImageOptions.SvgImage = GetImportIcon();
            this.btnImportEmployees.LargeImageOptions.SvgImage = GetImportIcon();
            this.btnImportEmployees.Name = "btnImportEmployees";
            this.btnImportEmployees.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportEmployees_ItemClick);
            
            this.btnSyncData.Caption = "مزامنة البيانات";
            this.btnSyncData.Id = 6;
            this.btnSyncData.ImageOptions.SvgImage = GetSyncIcon();
            this.btnSyncData.LargeImageOptions.SvgImage = GetSyncIcon();
            this.btnSyncData.Name = "btnSyncData";
            this.btnSyncData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSyncData_ItemClick);
            
            // Reports Button
            this.btnAttendanceReport.Caption = "تقارير الحضور";
            this.btnAttendanceReport.Id = 5;
            this.btnAttendanceReport.ImageOptions.SvgImage = GetReportIcon();
            this.btnAttendanceReport.LargeImageOptions.SvgImage = GetReportIcon();
            this.btnAttendanceReport.Name = "btnAttendanceReport";
            this.btnAttendanceReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAttendanceReport_ItemClick);
            
            // Settings Buttons
            this.btnDatabaseSettings.Caption = "إعدادات قاعدة البيانات";
            this.btnDatabaseSettings.Id = 8;
            this.btnDatabaseSettings.ImageOptions.SvgImage = GetDatabaseIcon();
            this.btnDatabaseSettings.LargeImageOptions.SvgImage = GetDatabaseIcon();
            this.btnDatabaseSettings.Name = "btnDatabaseSettings";
            this.btnDatabaseSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDatabaseSettings_ItemClick);
            
            // Application Buttons
            this.btnAbout.Caption = "حول البرنامج";
            this.btnAbout.Id = 9;
            this.btnAbout.ImageOptions.SvgImage = GetAboutIcon();
            this.btnAbout.LargeImageOptions.SvgImage = GetAboutIcon();
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAbout_ItemClick);
            
            this.btnExit.Caption = "خروج";
            this.btnExit.Id = 10;
            this.btnExit.ImageOptions.SvgImage = GetExitIcon();
            this.btnExit.LargeImageOptions.SvgImage = GetExitIcon();
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
        }
        
        private void SetupRibbonPages()
        {
            // Device Page
            this.ribbonPageDevice.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonPageGroupConnection,
                this.ribbonPageGroupManagement});
            this.ribbonPageDevice.Name = "ribbonPageDevice";
            this.ribbonPageDevice.Text = "إدارة الجهاز";
            
            this.ribbonPageGroupConnection.ItemLinks.Add(this.btnConnectDevice);
            this.ribbonPageGroupConnection.ItemLinks.Add(this.btnDisconnectDevice);
            this.ribbonPageGroupConnection.Name = "ribbonPageGroupConnection";
            this.ribbonPageGroupConnection.Text = "الاتصال";
            
            this.ribbonPageGroupManagement.ItemLinks.Add(this.btnTimeControl);
            this.ribbonPageGroupManagement.ItemLinks.Add(this.btnDeviceInfo);
            this.ribbonPageGroupManagement.Name = "ribbonPageGroupManagement";
            this.ribbonPageGroupManagement.Text = "الإدارة";
            
            // Data Page
            this.ribbonPageData.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonPageGroupImport,
                this.ribbonPageGroupReports});
            this.ribbonPageData.Name = "ribbonPageData";
            this.ribbonPageData.Text = "إدارة البيانات";
            
            this.ribbonPageGroupImport.ItemLinks.Add(this.btnImportEmployees);
            this.ribbonPageGroupImport.ItemLinks.Add(this.btnSyncData);
            this.ribbonPageGroupImport.Name = "ribbonPageGroupImport";
            this.ribbonPageGroupImport.Text = "الاستيراد والمزامنة";
            
            this.ribbonPageGroupReports.ItemLinks.Add(this.btnAttendanceReport);
            this.ribbonPageGroupReports.Name = "ribbonPageGroupReports";
            this.ribbonPageGroupReports.Text = "التقارير";
            
            // Settings Page
            this.ribbonPageSettings.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonPageGroupSystem,
                this.ribbonPageGroupApplication});
            this.ribbonPageSettings.Name = "ribbonPageSettings";
            this.ribbonPageSettings.Text = "الإعدادات";
            
            this.ribbonPageGroupSystem.ItemLinks.Add(this.btnDatabaseSettings);
            this.ribbonPageGroupSystem.Name = "ribbonPageGroupSystem";
            this.ribbonPageGroupSystem.Text = "النظام";
            
            this.ribbonPageGroupApplication.ItemLinks.Add(this.btnAbout);
            this.ribbonPageGroupApplication.ItemLinks.Add(this.btnExit);
            this.ribbonPageGroupApplication.Name = "ribbonPageGroupApplication";
            this.ribbonPageGroupApplication.Text = "التطبيق";
        }
        
        private void SetupStatusBar()
        {
            // Device Status
            this.lblDeviceStatus.Location = new System.Drawing.Point(12, 200);
            this.lblDeviceStatus.Size = new System.Drawing.Size(300, 20);
            this.lblDeviceStatus.Text = "جهاز البصمة: غير متصل";
            this.lblDeviceStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeviceStatus.Appearance.Options.UseFont = true;
            
            // Database Status
            this.lblDatabaseStatus.Location = new System.Drawing.Point(320, 200);
            this.lblDatabaseStatus.Size = new System.Drawing.Size(300, 20);
            this.lblDatabaseStatus.Text = "قاعدة البيانات: غير متصلة";
            this.lblDatabaseStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseStatus.Appearance.Options.UseFont = true;
            
            // Device Info
            this.lblDeviceInfo.Location = new System.Drawing.Point(12, 230);
            this.lblDeviceInfo.Size = new System.Drawing.Size(1160, 60);
            this.lblDeviceInfo.Text = "لا يوجد معلومات جهاز";
            this.lblDeviceInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDeviceInfo.Appearance.Options.UseFont = true;
            this.lblDeviceInfo.Appearance.Options.UseTextOptions = true;
            this.lblDeviceInfo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDeviceInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        // SVG Icon Methods (simplified versions)
        private DevExpress.Utils.Svg.SvgImage GetConnectIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("connect.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetDisconnectIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("disconnect.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetTimeIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("time.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetImportIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("import.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetReportIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("report.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetSyncIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("sync.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetInfoIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("info.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetDatabaseIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("database.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetAboutIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("about.svg", typeof(MainForm).Assembly);
        }
        
        private DevExpress.Utils.Svg.SvgImage GetExitIcon()
        {
            return DevExpress.Utils.Svg.SvgImage.FromResources("exit.svg", typeof(MainForm).Assembly);
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnConnectDevice;
        private DevExpress.XtraBars.BarButtonItem btnDisconnectDevice;
        private DevExpress.XtraBars.BarButtonItem btnTimeControl;
        private DevExpress.XtraBars.BarButtonItem btnImportEmployees;
        private DevExpress.XtraBars.BarButtonItem btnAttendanceReport;
        private DevExpress.XtraBars.BarButtonItem btnSyncData;
        private DevExpress.XtraBars.BarButtonItem btnDeviceInfo;
        private DevExpress.XtraBars.BarButtonItem btnDatabaseSettings;
        private DevExpress.XtraBars.BarButtonItem btnAbout;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageDevice;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupConnection;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupManagement;
        
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupReports;
        
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupApplication;
        
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraEditors.LabelControl lblDeviceStatus;
        private DevExpress.XtraEditors.LabelControl lblDatabaseStatus;
        private DevExpress.XtraEditors.LabelControl lblDeviceInfo;
    }
}