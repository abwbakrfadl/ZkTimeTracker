using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace ImprovedFingerprint.Forms
{
    partial class EmployeeDataImportForm
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
            
            // Device Data Group
            this.groupControlDevice = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDevice = new DevExpress.XtraGrid.GridControl();
            this.gridViewDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDeviceCount = new DevExpress.XtraEditors.LabelControl();
            
            // Database Data Group
            this.groupControlDatabase = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDatabase = new DevExpress.XtraGrid.GridControl();
            this.gridViewDatabase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDatabaseCount = new DevExpress.XtraEditors.LabelControl();
            
            // Control Buttons
            this.btnImportSelected = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectNone = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            
            // Status Controls
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblComparisonStats = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDevice)).BeginInit();
            this.groupControlDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDatabase)).BeginInit();
            this.groupControlDatabase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlDevice);
            this.layoutControl1.Controls.Add(this.groupControlDatabase);
            this.layoutControl1.Controls.Add(this.btnImportSelected);
            this.layoutControl1.Controls.Add(this.btnSelectAll);
            this.layoutControl1.Controls.Add(this.btnSelectNone);
            this.layoutControl1.Controls.Add(this.btnSelectNew);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Controls.Add(this.progressBarControl);
            this.layoutControl1.Controls.Add(this.lblComparisonStats);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1200, 700);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1200, 700);
            this.Root.TextVisible = false;
            
            // Setup Device Group
            SetupDeviceGroup();
            
            // Setup Database Group
            SetupDatabaseGroup();
            
            // Setup Buttons
            SetupButtons();
            
            // Setup Status Controls
            SetupStatusControls();
            
            // Setup Layout
            SetupLayout();
            
            // EmployeeDataImportForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "EmployeeDataImportForm";
            this.Text = "تحميل بيانات الموظفين من جهاز البصمة";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDevice)).EndInit();
            this.groupControlDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDatabase)).EndInit();
            this.groupControlDatabase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        
        private void SetupDeviceGroup()
        {
            this.groupControlDevice.Text = "📱 بيانات الموظفين في جهاز البصمة";
            this.groupControlDevice.Location = new System.Drawing.Point(12, 12);
            this.groupControlDevice.Size = new System.Drawing.Size(580, 400);
            this.groupControlDevice.Controls.Add(this.gridControlDevice);
            this.groupControlDevice.Controls.Add(this.lblDeviceCount);
            
            // Grid Control Device
            this.gridControlDevice.Location = new System.Drawing.Point(5, 25);
            this.gridControlDevice.MainView = this.gridViewDevice;
            this.gridControlDevice.Size = new System.Drawing.Size(570, 350);
            this.gridControlDevice.TabIndex = 0;
            this.gridControlDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewDevice});
            
            // Grid View Device
            this.gridViewDevice.GridControl = this.gridControlDevice;
            this.gridViewDevice.Name = "gridViewDevice";
            this.gridViewDevice.OptionsView.ShowGroupPanel = false;
            this.gridViewDevice.OptionsSelection.MultiSelect = true;
            this.gridViewDevice.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            
            // Device Count Label
            this.lblDeviceCount.Location = new System.Drawing.Point(5, 380);
            this.lblDeviceCount.Size = new System.Drawing.Size(570, 13);
            this.lblDeviceCount.Text = "عدد الموظفين في الجهاز: 0";
            this.lblDeviceCount.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDeviceCount.Appearance.Options.UseFont = true;
        }
        
        private void SetupDatabaseGroup()
        {
            this.groupControlDatabase.Text = "🗄️ بيانات الموظفين في قاعدة البيانات";
            this.groupControlDatabase.Location = new System.Drawing.Point(600, 12);
            this.groupControlDatabase.Size = new System.Drawing.Size(580, 400);
            this.groupControlDatabase.Controls.Add(this.gridControlDatabase);
            this.groupControlDatabase.Controls.Add(this.lblDatabaseCount);
            
            // Grid Control Database
            this.gridControlDatabase.Location = new System.Drawing.Point(5, 25);
            this.gridControlDatabase.MainView = this.gridViewDatabase;
            this.gridControlDatabase.Size = new System.Drawing.Size(570, 350);
            this.gridControlDatabase.TabIndex = 0;
            this.gridControlDatabase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewDatabase});
            
            // Grid View Database
            this.gridViewDatabase.GridControl = this.gridControlDatabase;
            this.gridViewDatabase.Name = "gridViewDatabase";
            this.gridViewDatabase.OptionsView.ShowGroupPanel = false;
            
            // Database Count Label
            this.lblDatabaseCount.Location = new System.Drawing.Point(5, 380);
            this.lblDatabaseCount.Size = new System.Drawing.Size(570, 13);
            this.lblDatabaseCount.Text = "عدد الموظفين في قاعدة البيانات: 0";
            this.lblDatabaseCount.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDatabaseCount.Appearance.Options.UseFont = true;
        }
        
        private void SetupButtons()
        {
            // Import Selected Button
            this.btnImportSelected.Text = "استيراد المختارين";
            this.btnImportSelected.Location = new System.Drawing.Point(12, 420);
            this.btnImportSelected.Size = new System.Drawing.Size(120, 30);
            this.btnImportSelected.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnImportSelected.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnImportSelected.Appearance.Options.UseBackColor = true;
            this.btnImportSelected.Appearance.Options.UseForeColor = true;
            this.btnImportSelected.Click += new System.EventHandler(this.btnImportSelected_Click);
            
            // Select All Button
            this.btnSelectAll.Text = "اختيار الكل";
            this.btnSelectAll.Location = new System.Drawing.Point(140, 420);
            this.btnSelectAll.Size = new System.Drawing.Size(100, 30);
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            
            // Select None Button
            this.btnSelectNone.Text = "إلغاء الكل";
            this.btnSelectNone.Location = new System.Drawing.Point(248, 420);
            this.btnSelectNone.Size = new System.Drawing.Size(100, 30);
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            
            // Select New Button
            this.btnSelectNew.Text = "اختيار الجدد";
            this.btnSelectNew.Location = new System.Drawing.Point(356, 420);
            this.btnSelectNew.Size = new System.Drawing.Size(100, 30);
            this.btnSelectNew.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnSelectNew.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSelectNew.Appearance.Options.UseBackColor = true;
            this.btnSelectNew.Appearance.Options.UseForeColor = true;
            this.btnSelectNew.Click += new System.EventHandler(this.btnSelectNew_Click);
            
            // Refresh Button
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.Location = new System.Drawing.Point(464, 420);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // Close Button
            this.btnClose.Text = "إغلاق";
            this.btnClose.Location = new System.Drawing.Point(1080, 420);
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        }
        
        private void SetupStatusControls()
        {
            // Status Label
            this.lblStatus.Text = "جاري تحميل البيانات...";
            this.lblStatus.Location = new System.Drawing.Point(12, 460);
            this.lblStatus.Size = new System.Drawing.Size(1168, 20);
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            
            // Progress Bar
            this.progressBarControl.Location = new System.Drawing.Point(12, 490);
            this.progressBarControl.Size = new System.Drawing.Size(1168, 20);
            this.progressBarControl.Properties.ShowTitle = true;
            this.progressBarControl.Properties.PercentView = true;
            
            // Comparison Stats Label
            this.lblComparisonStats.Text = "إحصائيات المقارنة ستظهر هنا بعد تحميل البيانات";
            this.lblComparisonStats.Location = new System.Drawing.Point(12, 520);
            this.lblComparisonStats.Size = new System.Drawing.Size(1168, 160);
            this.lblComparisonStats.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblComparisonStats.Appearance.Options.UseFont = true;
            this.lblComparisonStats.Appearance.Options.UseTextOptions = true;
            this.lblComparisonStats.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblComparisonStats.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblComparisonStats.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblComparisonStats.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        private void SetupLayout()
        {
            // Add layout items
            var layoutItemDevice = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDevice.Control = this.groupControlDevice;
            layoutItemDevice.Location = new System.Drawing.Point(0, 0);
            layoutItemDevice.Size = new System.Drawing.Size(584, 404);
            layoutItemDevice.TextSize = new System.Drawing.Size(0, 0);
            layoutItemDevice.TextVisible = false;
            this.Root.Items.Add(layoutItemDevice);
            
            var layoutItemDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDatabase.Control = this.groupControlDatabase;
            layoutItemDatabase.Location = new System.Drawing.Point(588, 0);
            layoutItemDatabase.Size = new System.Drawing.Size(584, 404);
            layoutItemDatabase.TextSize = new System.Drawing.Size(0, 0);
            layoutItemDatabase.TextVisible = false;
            this.Root.Items.Add(layoutItemDatabase);
            
            // Add button layout items
            AddButtonLayoutItem(this.btnImportSelected, 0, 408, 124);
            AddButtonLayoutItem(this.btnSelectAll, 128, 408, 104);
            AddButtonLayoutItem(this.btnSelectNone, 236, 408, 104);
            AddButtonLayoutItem(this.btnSelectNew, 344, 408, 104);
            AddButtonLayoutItem(this.btnRefresh, 452, 408, 104);
            
            // Add space
            var emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem.AllowHotTrack = false;
            emptySpaceItem.Location = new System.Drawing.Point(560, 408);
            emptySpaceItem.Size = new System.Drawing.Size(516, 34);
            emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            this.Root.Items.Add(emptySpaceItem);
            
            AddButtonLayoutItem(this.btnClose, 1076, 408, 104);
            
            // Add status layout items
            var layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatus.Control = this.lblStatus;
            layoutItemStatus.Location = new System.Drawing.Point(0, 448);
            layoutItemStatus.Size = new System.Drawing.Size(1172, 24);
            layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatus.TextVisible = false;
            this.Root.Items.Add(layoutItemStatus);
            
            var layoutItemProgress = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemProgress.Control = this.progressBarControl;
            layoutItemProgress.Location = new System.Drawing.Point(0, 476);
            layoutItemProgress.Size = new System.Drawing.Size(1172, 28);
            layoutItemProgress.TextSize = new System.Drawing.Size(0, 0);
            layoutItemProgress.TextVisible = false;
            this.Root.Items.Add(layoutItemProgress);
            
            var layoutItemStats = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStats.Control = this.lblComparisonStats;
            layoutItemStats.Location = new System.Drawing.Point(0, 508);
            layoutItemStats.Size = new System.Drawing.Size(1172, 164);
            layoutItemStats.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStats.TextVisible = false;
            this.Root.Items.Add(layoutItemStats);
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
        
        private DevExpress.XtraEditors.GroupControl groupControlDevice;
        private DevExpress.XtraGrid.GridControl gridControlDevice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDevice;
        private DevExpress.XtraEditors.LabelControl lblDeviceCount;
        
        private DevExpress.XtraEditors.GroupControl groupControlDatabase;
        private DevExpress.XtraGrid.GridControl gridControlDatabase;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDatabase;
        private DevExpress.XtraEditors.LabelControl lblDatabaseCount;
        
        private DevExpress.XtraEditors.SimpleButton btnImportSelected;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectNone;
        private DevExpress.XtraEditors.SimpleButton btnSelectNew;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl lblComparisonStats;
    }
}