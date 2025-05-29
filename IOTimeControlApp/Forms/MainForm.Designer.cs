using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace IOTimeControlApp.Forms
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControlMain = new DevExpress.XtraEditors.GroupControl();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpenTimeControl = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            
            // Layout items
            this.layoutItemMain = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemConnect = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemTimeControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemExit = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).BeginInit();
            this.groupControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTimeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlMain);
            this.layoutControl1.Controls.Add(this.btnConnect);
            this.layoutControl1.Controls.Add(this.btnOpenTimeControl);
            this.layoutControl1.Controls.Add(this.btnExit);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 600);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutItemMain,
                this.layoutItemConnect,
                this.layoutItemTimeControl,
                this.layoutItemExit,
                this.layoutItemStatus,
                this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 600);
            this.Root.TextVisible = false;
            
            // groupControlMain
            this.groupControlMain.Controls.Add(this.lblTitle);
            this.groupControlMain.Controls.Add(this.lblDescription);
            this.groupControlMain.Location = new System.Drawing.Point(12, 12);
            this.groupControlMain.Name = "groupControlMain";
            this.groupControlMain.Size = new System.Drawing.Size(776, 200);
            this.groupControlMain.TabIndex = 4;
            this.groupControlMain.Text = "نظام التحكم في أوقات الدخول والخروج";
            
            // lblTitle
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Appearance.Options.UseTextOptions = true;
            this.lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTitle.Location = new System.Drawing.Point(50, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(676, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "برنامج التحكم في أوقات الدخول والخروج لجهاز البصمة U350";
            
            // lblDescription
            this.lblDescription.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDescription.Appearance.Options.UseFont = true;
            this.lblDescription.Appearance.Options.UseTextOptions = true;
            this.lblDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDescription.Location = new System.Drawing.Point(50, 80);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(676, 100);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = @"هذا البرنامج يتيح لك التحكم في أوقات الدخول والخروج للفترات الثلاث:

🌅 الفترة الصباحية: دخول 6:00-10:59، خروج 11:00-13:00
🌆 الفترة المسائية: دخول 14:00-18:59، خروج 19:00-21:00  
🌙 الفترة الليلية: دخول 22:00-02:59، خروج 03:00-05:00

يرجى الاتصال بجهاز البصمة أولاً ثم فتح شاشة التحكم في الأوقات";
            
            // btnConnect
            this.btnConnect.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnConnect.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnConnect.Appearance.Options.UseBackColor = true;
            this.btnConnect.Appearance.Options.UseFont = true;
            this.btnConnect.Location = new System.Drawing.Point(12, 250);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(250, 40);
            this.btnConnect.StyleController = this.layoutControl1;
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "اتصال بجهاز البصمة";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            
            // btnOpenTimeControl
            this.btnOpenTimeControl.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnOpenTimeControl.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenTimeControl.Appearance.Options.UseBackColor = true;
            this.btnOpenTimeControl.Appearance.Options.UseFont = true;
            this.btnOpenTimeControl.Enabled = false;
            this.btnOpenTimeControl.Location = new System.Drawing.Point(275, 250);
            this.btnOpenTimeControl.Name = "btnOpenTimeControl";
            this.btnOpenTimeControl.Size = new System.Drawing.Size(250, 40);
            this.btnOpenTimeControl.StyleController = this.layoutControl1;
            this.btnOpenTimeControl.TabIndex = 6;
            this.btnOpenTimeControl.Text = "فتح شاشة التحكم في الأوقات";
            this.btnOpenTimeControl.Click += new System.EventHandler(this.btnOpenTimeControl_Click);
            
            // btnExit
            this.btnExit.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(538, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(250, 40);
            this.btnExit.StyleController = this.layoutControl1;
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "إغلاق البرنامج";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            
            // lblStatus
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(12, 320);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(776, 30);
            this.lblStatus.StyleController = this.layoutControl1;
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "غير متصل بجهاز البصمة";
            
            // Layout items
            this.layoutItemMain.Control = this.groupControlMain;
            this.layoutItemMain.Location = new System.Drawing.Point(0, 0);
            this.layoutItemMain.Name = "layoutItemMain";
            this.layoutItemMain.Size = new System.Drawing.Size(780, 204);
            this.layoutItemMain.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemMain.TextVisible = false;
            
            this.layoutItemConnect.Control = this.btnConnect;
            this.layoutItemConnect.Location = new System.Drawing.Point(0, 238);
            this.layoutItemConnect.Name = "layoutItemConnect";
            this.layoutItemConnect.Size = new System.Drawing.Size(254, 44);
            this.layoutItemConnect.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemConnect.TextVisible = false;
            
            this.layoutItemTimeControl.Control = this.btnOpenTimeControl;
            this.layoutItemTimeControl.Location = new System.Drawing.Point(263, 238);
            this.layoutItemTimeControl.Name = "layoutItemTimeControl";
            this.layoutItemTimeControl.Size = new System.Drawing.Size(254, 44);
            this.layoutItemTimeControl.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemTimeControl.TextVisible = false;
            
            this.layoutItemExit.Control = this.btnExit;
            this.layoutItemExit.Location = new System.Drawing.Point(526, 238);
            this.layoutItemExit.Name = "layoutItemExit";
            this.layoutItemExit.Size = new System.Drawing.Size(254, 44);
            this.layoutItemExit.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemExit.TextVisible = false;
            
            this.layoutItemStatus.Control = this.lblStatus;
            this.layoutItemStatus.Location = new System.Drawing.Point(0, 308);
            this.layoutItemStatus.Name = "layoutItemStatus";
            this.layoutItemStatus.Size = new System.Drawing.Size(780, 34);
            this.layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemStatus.TextVisible = false;
            
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 204);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(780, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام التحكم في أوقات الدخول والخروج - جهاز البصمة";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMain)).EndInit();
            this.groupControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTimeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl groupControlMain;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnOpenTimeControl;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        
        private DevExpress.XtraLayout.LayoutControlItem layoutItemMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemConnect;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemTimeControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemExit;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemStatus;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}