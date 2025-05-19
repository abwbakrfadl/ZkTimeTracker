using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class AttendanceMonitorForm
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
            this.gridAttendance = new DevExpress.XtraGrid.GridControl();
            this.gridViewAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.btnApplyFilter = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearFilter = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveToDatabase = new DevExpress.XtraEditors.SimpleButton();
            this.chkAutoRefresh = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRefresh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.gridAttendance);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.panelControl2);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 600);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutControlItem1,
                this.layoutControlItem2,
                this.layoutControlItem3,
                this.layoutControlItem4
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 600);
            this.Root.TextVisible = false;
            
            // gridAttendance
            this.gridAttendance.Location = new System.Drawing.Point(12, 126);
            this.gridAttendance.MainView = this.gridViewAttendance;
            this.gridAttendance.Name = "gridAttendance";
            this.gridAttendance.Size = new System.Drawing.Size(776, 422);
            this.gridAttendance.TabIndex = 4;
            this.gridAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewAttendance
            });
            
            // gridViewAttendance
            this.gridViewAttendance.GridControl = this.gridAttendance;
            this.gridViewAttendance.Name = "gridViewAttendance";
            
            // layoutControlItem1
            this.layoutControlItem1.Control = this.gridAttendance;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 114);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 426);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            
            // panelControl1
            this.panelControl1.Controls.Add(this.layoutControl2);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(776, 60);
            this.panelControl1.TabIndex = 5;
            this.panelControl1.Text = "Filter";
            
            // layoutControl2
            this.layoutControl2.Controls.Add(this.labelControl1);
            this.layoutControl2.Controls.Add(this.txtEmployeeId);
            this.layoutControl2.Controls.Add(this.labelControl2);
            this.layoutControl2.Controls.Add(this.dateFrom);
            this.layoutControl2.Controls.Add(this.labelControl3);
            this.layoutControl2.Controls.Add(this.dateTo);
            this.layoutControl2.Controls.Add(this.btnApplyFilter);
            this.layoutControl2.Controls.Add(this.btnClearFilter);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(772, 56);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            
            // layoutControlGroup1
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(772, 56);
            this.layoutControlGroup1.TextVisible = false;
            
            // labelControl1
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.StyleController = this.layoutControl2;
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Employee ID:";
            
            // Add Employee ID label to layout
            var layoutItemEmployeeIdLabel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemEmployeeIdLabel.Control = this.labelControl1;
            layoutItemEmployeeIdLabel.Location = new System.Drawing.Point(0, 0);
            layoutItemEmployeeIdLabel.Name = "layoutItemEmployeeIdLabel";
            layoutItemEmployeeIdLabel.Size = new System.Drawing.Size(67, 17);
            layoutItemEmployeeIdLabel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemEmployeeIdLabel.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemEmployeeIdLabel);
            
            // txtEmployeeId
            this.txtEmployeeId.Location = new System.Drawing.Point(79, 12);
            this.txtEmployeeId.Name = "txtEmployeeId";
            this.txtEmployeeId.Size = new System.Drawing.Size(75, 20);
            this.txtEmployeeId.StyleController = this.layoutControl2;
            this.txtEmployeeId.TabIndex = 5;
            
            // Add Employee ID control to layout
            var layoutItemEmployeeId = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemEmployeeId.Control = this.txtEmployeeId;
            layoutItemEmployeeId.Location = new System.Drawing.Point(67, 0);
            layoutItemEmployeeId.Name = "layoutItemEmployeeId";
            layoutItemEmployeeId.Size = new System.Drawing.Size(79, 24);
            layoutItemEmployeeId.TextSize = new System.Drawing.Size(0, 0);
            layoutItemEmployeeId.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemEmployeeId);
            
            // labelControl2
            this.labelControl2.Location = new System.Drawing.Point(158, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.StyleController = this.layoutControl2;
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "From:";
            
            // Add From label to layout
            var layoutItemFromLabel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemFromLabel.Control = this.labelControl2;
            layoutItemFromLabel.Location = new System.Drawing.Point(146, 0);
            layoutItemFromLabel.Name = "layoutItemFromLabel";
            layoutItemFromLabel.Size = new System.Drawing.Size(35, 17);
            layoutItemFromLabel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemFromLabel.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemFromLabel);
            
            // dateFrom
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(193, 12);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.dateFrom.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateFrom.Size = new System.Drawing.Size(100, 20);
            this.dateFrom.StyleController = this.layoutControl2;
            this.dateFrom.TabIndex = 7;
            
            // Add From date control to layout
            var layoutItemFromDate = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemFromDate.Control = this.dateFrom;
            layoutItemFromDate.Location = new System.Drawing.Point(181, 0);
            layoutItemFromDate.Name = "layoutItemFromDate";
            layoutItemFromDate.Size = new System.Drawing.Size(104, 24);
            layoutItemFromDate.TextSize = new System.Drawing.Size(0, 0);
            layoutItemFromDate.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemFromDate);
            
            // labelControl3
            this.labelControl3.Location = new System.Drawing.Point(297, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(16, 13);
            this.labelControl3.StyleController = this.layoutControl2;
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "To:";
            
            // Add To label to layout
            var layoutItemToLabel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemToLabel.Control = this.labelControl3;
            layoutItemToLabel.Location = new System.Drawing.Point(285, 0);
            layoutItemToLabel.Name = "layoutItemToLabel";
            layoutItemToLabel.Size = new System.Drawing.Size(20, 17);
            layoutItemToLabel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemToLabel.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemToLabel);
            
            // dateTo
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(317, 12);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.dateTo.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dateTo.Size = new System.Drawing.Size(100, 20);
            this.dateTo.StyleController = this.layoutControl2;
            this.dateTo.TabIndex = 9;
            
            // Add To date control to layout
            var layoutItemToDate = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemToDate.Control = this.dateTo;
            layoutItemToDate.Location = new System.Drawing.Point(305, 0);
            layoutItemToDate.Name = "layoutItemToDate";
            layoutItemToDate.Size = new System.Drawing.Size(104, 24);
            layoutItemToDate.TextSize = new System.Drawing.Size(0, 0);
            layoutItemToDate.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemToDate);
            
            // btnApplyFilter
            this.btnApplyFilter.Location = new System.Drawing.Point(421, 12);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(100, 22);
            this.btnApplyFilter.StyleController = this.layoutControl2;
            this.btnApplyFilter.TabIndex = 10;
            this.btnApplyFilter.Text = "Apply Filter";
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            
            // Add Apply Filter button to layout
            var layoutItemApplyFilter = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemApplyFilter.Control = this.btnApplyFilter;
            layoutItemApplyFilter.Location = new System.Drawing.Point(409, 0);
            layoutItemApplyFilter.Name = "layoutItemApplyFilter";
            layoutItemApplyFilter.Size = new System.Drawing.Size(104, 26);
            layoutItemApplyFilter.TextSize = new System.Drawing.Size(0, 0);
            layoutItemApplyFilter.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemApplyFilter);
            
            // btnClearFilter
            this.btnClearFilter.Location = new System.Drawing.Point(525, 12);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(100, 22);
            this.btnClearFilter.StyleController = this.layoutControl2;
            this.btnClearFilter.TabIndex = 11;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            
            // Add Clear Filter button to layout
            var layoutItemClearFilter = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemClearFilter.Control = this.btnClearFilter;
            layoutItemClearFilter.Location = new System.Drawing.Point(513, 0);
            layoutItemClearFilter.Name = "layoutItemClearFilter";
            layoutItemClearFilter.Size = new System.Drawing.Size(104, 26);
            layoutItemClearFilter.TextSize = new System.Drawing.Size(0, 0);
            layoutItemClearFilter.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemClearFilter);
            
            // Add empty space to the right
            var emptySpaceItemFilter = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItemFilter.AllowHotTrack = false;
            emptySpaceItemFilter.Location = new System.Drawing.Point(617, 0);
            emptySpaceItemFilter.Name = "emptySpaceItemFilter";
            emptySpaceItemFilter.Size = new System.Drawing.Size(135, 26);
            emptySpaceItemFilter.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup1.Items.Add(emptySpaceItemFilter);
            
            // layoutControlItem2
            this.layoutControlItem2.Control = this.panelControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(780, 64);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            
            // panelControl2
            this.panelControl2.Controls.Add(this.layoutControl3);
            this.panelControl2.Location = new System.Drawing.Point(12, 76);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(776, 46);
            this.panelControl2.TabIndex = 6;
            this.panelControl2.Text = "Actions";
            
            // layoutControl3
            this.layoutControl3.Controls.Add(this.btnRefresh);
            this.layoutControl3.Controls.Add(this.btnExport);
            this.layoutControl3.Controls.Add(this.btnSaveToDatabase);
            this.layoutControl3.Controls.Add(this.chkAutoRefresh);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(2, 2);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(772, 42);
            this.layoutControl3.TabIndex = 0;
            this.layoutControl3.Text = "layoutControl3";
            
            // layoutControlGroup2
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(772, 42);
            this.layoutControlGroup2.TextVisible = false;
            
            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 22);
            this.btnRefresh.StyleController = this.layoutControl3;
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            
            // Add Refresh button to layout
            var layoutItemRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemRefresh.Control = this.btnRefresh;
            layoutItemRefresh.Location = new System.Drawing.Point(0, 0);
            layoutItemRefresh.Name = "layoutItemRefresh";
            layoutItemRefresh.Size = new System.Drawing.Size(154, 26);
            layoutItemRefresh.TextSize = new System.Drawing.Size(0, 0);
            layoutItemRefresh.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemRefresh);
            
            // btnExport
            this.btnExport.Location = new System.Drawing.Point(166, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 22);
            this.btnExport.StyleController = this.layoutControl3;
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            
            // Add Export button to layout
            var layoutItemExport = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemExport.Control = this.btnExport;
            layoutItemExport.Location = new System.Drawing.Point(154, 0);
            layoutItemExport.Name = "layoutItemExport";
            layoutItemExport.Size = new System.Drawing.Size(154, 26);
            layoutItemExport.TextSize = new System.Drawing.Size(0, 0);
            layoutItemExport.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemExport);
            
            // btnSaveToDatabase
            this.btnSaveToDatabase.Location = new System.Drawing.Point(320, 12);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(150, 22);
            this.btnSaveToDatabase.StyleController = this.layoutControl3;
            this.btnSaveToDatabase.TabIndex = 6;
            this.btnSaveToDatabase.Text = "Save to Database";
            this.btnSaveToDatabase.Click += new System.EventHandler(this.btnSaveToDatabase_Click);
            
            // Add Save to Database button to layout
            var layoutItemSaveToDatabase = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSaveToDatabase.Control = this.btnSaveToDatabase;
            layoutItemSaveToDatabase.Location = new System.Drawing.Point(308, 0);
            layoutItemSaveToDatabase.Name = "layoutItemSaveToDatabase";
            layoutItemSaveToDatabase.Size = new System.Drawing.Size(154, 26);
            layoutItemSaveToDatabase.TextSize = new System.Drawing.Size(0, 0);
            layoutItemSaveToDatabase.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemSaveToDatabase);
            
            // chkAutoRefresh
            this.chkAutoRefresh.Location = new System.Drawing.Point(474, 12);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Properties.Caption = "Auto Refresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(286, 20);
            this.chkAutoRefresh.StyleController = this.layoutControl3;
            this.chkAutoRefresh.TabIndex = 7;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            
            // Add Auto Refresh check to layout
            var layoutItemAutoRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemAutoRefresh.Control = this.chkAutoRefresh;
            layoutItemAutoRefresh.Location = new System.Drawing.Point(462, 0);
            layoutItemAutoRefresh.Name = "layoutItemAutoRefresh";
            layoutItemAutoRefresh.Size = new System.Drawing.Size(290, 24);
            layoutItemAutoRefresh.TextSize = new System.Drawing.Size(0, 0);
            layoutItemAutoRefresh.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemAutoRefresh);
            
            // layoutControlItem3
            this.layoutControlItem3.Control = this.panelControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(780, 50);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            
            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(12, 552);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(776, 13);
            this.lblStatus.StyleController = this.layoutControl1;
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready";
            
            // layoutControlItem4
            this.layoutControlItem4.Control = this.lblStatus;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 540);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(780, 40);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            
            // AttendanceMonitorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AttendanceMonitorForm";
            this.Text = "Attendance Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttendanceMonitorForm_FormClosing);
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRefresh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAttendance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEmployeeId;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.SimpleButton btnApplyFilter;
        private DevExpress.XtraEditors.SimpleButton btnClearFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnSaveToDatabase;
        private DevExpress.XtraEditors.CheckEdit chkAutoRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}