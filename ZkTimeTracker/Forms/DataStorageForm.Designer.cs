using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class DataStorageForm
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnGenerateReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateRecordType = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteRecords = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl4 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblTotalRecords = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckInCount = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckOutCount = new DevExpress.XtraEditors.LabelControl();
            this.lblUnknownCount = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).BeginInit();
            this.layoutControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.gridAttendance);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.panelControl2);
            this.layoutControl1.Controls.Add(this.panelControl3);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Controls.Add(this.btnClose);
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
                this.layoutControlItem4,
                this.layoutControlItem5,
                this.layoutControlItem6,
                this.emptySpaceItem1
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 600);
            this.Root.TextVisible = false;
            
            // gridAttendance
            this.gridAttendance.Location = new System.Drawing.Point(12, 172);
            this.gridAttendance.MainView = this.gridViewAttendance;
            this.gridAttendance.Name = "gridAttendance";
            this.gridAttendance.Size = new System.Drawing.Size(776, 376);
            this.gridAttendance.TabIndex = 4;
            this.gridAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewAttendance
            });
            
            // gridViewAttendance
            this.gridViewAttendance.GridControl = this.gridAttendance;
            this.gridViewAttendance.Name = "gridViewAttendance";
            
            // layoutControlItem1
            this.layoutControlItem1.Control = this.gridAttendance;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 160);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 380);
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
            this.layoutControl3.Controls.Add(this.btnExport);
            this.layoutControl3.Controls.Add(this.btnGenerateReport);
            this.layoutControl3.Controls.Add(this.btnUpdateRecordType);
            this.layoutControl3.Controls.Add(this.btnDeleteRecords);
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
            
            // btnExport
            this.btnExport.Location = new System.Drawing.Point(12, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(177, 22);
            this.btnExport.StyleController = this.layoutControl3;
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            
            // btnGenerateReport
            this.btnGenerateReport.Location = new System.Drawing.Point(193, 12);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(176, 22);
            this.btnGenerateReport.StyleController = this.layoutControl3;
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            
            // btnUpdateRecordType
            this.btnUpdateRecordType.Location = new System.Drawing.Point(373, 12);
            this.btnUpdateRecordType.Name = "btnUpdateRecordType";
            this.btnUpdateRecordType.Size = new System.Drawing.Size(178, 22);
            this.btnUpdateRecordType.StyleController = this.layoutControl3;
            this.btnUpdateRecordType.TabIndex = 6;
            this.btnUpdateRecordType.Text = "Update Record Type";
            this.btnUpdateRecordType.Click += new System.EventHandler(this.btnUpdateRecordType_Click);
            
            // btnDeleteRecords
            this.btnDeleteRecords.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteRecords.Appearance.Options.UseBackColor = true;
            this.btnDeleteRecords.Location = new System.Drawing.Point(555, 12);
            this.btnDeleteRecords.Name = "btnDeleteRecords";
            this.btnDeleteRecords.Size = new System.Drawing.Size(205, 22);
            this.btnDeleteRecords.StyleController = this.layoutControl3;
            this.btnDeleteRecords.TabIndex = 7;
            this.btnDeleteRecords.Text = "Delete Selected Records";
            this.btnDeleteRecords.Click += new System.EventHandler(this.btnDeleteRecords_Click);
            
            // Add buttons to the actions layout
            var layoutItemExport = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemExport.Control = this.btnExport;
            layoutItemExport.Location = new System.Drawing.Point(0, 0);
            layoutItemExport.Name = "layoutItemExport";
            layoutItemExport.Size = new System.Drawing.Size(181, 26);
            layoutItemExport.TextSize = new System.Drawing.Size(0, 0);
            layoutItemExport.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemExport);
            
            var layoutItemGenerateReport = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGenerateReport.Control = this.btnGenerateReport;
            layoutItemGenerateReport.Location = new System.Drawing.Point(181, 0);
            layoutItemGenerateReport.Name = "layoutItemGenerateReport";
            layoutItemGenerateReport.Size = new System.Drawing.Size(180, 26);
            layoutItemGenerateReport.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGenerateReport.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemGenerateReport);
            
            var layoutItemUpdateRecordType = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemUpdateRecordType.Control = this.btnUpdateRecordType;
            layoutItemUpdateRecordType.Location = new System.Drawing.Point(361, 0);
            layoutItemUpdateRecordType.Name = "layoutItemUpdateRecordType";
            layoutItemUpdateRecordType.Size = new System.Drawing.Size(182, 26);
            layoutItemUpdateRecordType.TextSize = new System.Drawing.Size(0, 0);
            layoutItemUpdateRecordType.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemUpdateRecordType);
            
            var layoutItemDeleteRecords = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDeleteRecords.Control = this.btnDeleteRecords;
            layoutItemDeleteRecords.Location = new System.Drawing.Point(543, 0);
            layoutItemDeleteRecords.Name = "layoutItemDeleteRecords";
            layoutItemDeleteRecords.Size = new System.Drawing.Size(209, 26);
            layoutItemDeleteRecords.TextSize = new System.Drawing.Size(0, 0);
            layoutItemDeleteRecords.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemDeleteRecords);
            
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
            this.layoutControlItem4.Size = new System.Drawing.Size(780, 17);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            
            // btnClose
            this.btnClose.Location = new System.Drawing.Point(713, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // layoutControlItem5
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(701, 552);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(79, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            
            // emptySpaceItem1
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 557);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(701, 21);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            
            // panelControl3
            this.panelControl3.Controls.Add(this.layoutControl4);
            this.panelControl3.Location = new System.Drawing.Point(12, 126);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(776, 42);
            this.panelControl3.TabIndex = 9;
            this.panelControl3.Text = "Statistics";
            
            // layoutControl4
            this.layoutControl4.Controls.Add(this.lblTotalRecords);
            this.layoutControl4.Controls.Add(this.lblCheckInCount);
            this.layoutControl4.Controls.Add(this.lblCheckOutCount);
            this.layoutControl4.Controls.Add(this.lblUnknownCount);
            this.layoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl4.Location = new System.Drawing.Point(2, 2);
            this.layoutControl4.Name = "layoutControl4";
            this.layoutControl4.Root = this.layoutControlGroup3;
            this.layoutControl4.Size = new System.Drawing.Size(772, 38);
            this.layoutControl4.TabIndex = 0;
            this.layoutControl4.Text = "layoutControl4";
            
            // layoutControlGroup3
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(772, 38);
            this.layoutControlGroup3.TextVisible = false;
            
            // lblTotalRecords
            this.lblTotalRecords.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecords.Appearance.Options.UseFont = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(12, 12);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(165, 13);
            this.lblTotalRecords.StyleController = this.layoutControl4;
            this.lblTotalRecords.TabIndex = 4;
            this.lblTotalRecords.Text = "Total Records: 0";
            
            // lblCheckInCount
            this.lblCheckInCount.Location = new System.Drawing.Point(181, 12);
            this.lblCheckInCount.Name = "lblCheckInCount";
            this.lblCheckInCount.Size = new System.Drawing.Size(165, 13);
            this.lblCheckInCount.StyleController = this.layoutControl4;
            this.lblCheckInCount.TabIndex = 5;
            this.lblCheckInCount.Text = "Check-ins: 0";
            
            // lblCheckOutCount
            this.lblCheckOutCount.Location = new System.Drawing.Point(350, 12);
            this.lblCheckOutCount.Name = "lblCheckOutCount";
            this.lblCheckOutCount.Size = new System.Drawing.Size(165, 13);
            this.lblCheckOutCount.StyleController = this.layoutControl4;
            this.lblCheckOutCount.TabIndex = 6;
            this.lblCheckOutCount.Text = "Check-outs: 0";
            
            // lblUnknownCount
            this.lblUnknownCount.Location = new System.Drawing.Point(519, 12);
            this.lblUnknownCount.Name = "lblUnknownCount";
            this.lblUnknownCount.Size = new System.Drawing.Size(241, 13);
            this.lblUnknownCount.StyleController = this.layoutControl4;
            this.lblUnknownCount.TabIndex = 7;
            this.lblUnknownCount.Text = "Unknown: 0";
            
            // Add labels to statistics layout
            var layoutItemTotalRecords = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemTotalRecords.Control = this.lblTotalRecords;
            layoutItemTotalRecords.Location = new System.Drawing.Point(0, 0);
            layoutItemTotalRecords.Name = "layoutItemTotalRecords";
            layoutItemTotalRecords.Size = new System.Drawing.Size(169, 17);
            layoutItemTotalRecords.TextSize = new System.Drawing.Size(0, 0);
            layoutItemTotalRecords.TextVisible = false;
            this.layoutControlGroup3.Items.Add(layoutItemTotalRecords);
            
            var layoutItemCheckInCount = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCheckInCount.Control = this.lblCheckInCount;
            layoutItemCheckInCount.Location = new System.Drawing.Point(169, 0);
            layoutItemCheckInCount.Name = "layoutItemCheckInCount";
            layoutItemCheckInCount.Size = new System.Drawing.Size(169, 17);
            layoutItemCheckInCount.TextSize = new System.Drawing.Size(0, 0);
            layoutItemCheckInCount.TextVisible = false;
            this.layoutControlGroup3.Items.Add(layoutItemCheckInCount);
            
            var layoutItemCheckOutCount = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCheckOutCount.Control = this.lblCheckOutCount;
            layoutItemCheckOutCount.Location = new System.Drawing.Point(338, 0);
            layoutItemCheckOutCount.Name = "layoutItemCheckOutCount";
            layoutItemCheckOutCount.Size = new System.Drawing.Size(169, 17);
            layoutItemCheckOutCount.TextSize = new System.Drawing.Size(0, 0);
            layoutItemCheckOutCount.TextVisible = false;
            this.layoutControlGroup3.Items.Add(layoutItemCheckOutCount);
            
            var layoutItemUnknownCount = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemUnknownCount.Control = this.lblUnknownCount;
            layoutItemUnknownCount.Location = new System.Drawing.Point(507, 0);
            layoutItemUnknownCount.Name = "layoutItemUnknownCount";
            layoutItemUnknownCount.Size = new System.Drawing.Size(245, 17);
            layoutItemUnknownCount.TextSize = new System.Drawing.Size(0, 0);
            layoutItemUnknownCount.TextVisible = false;
            this.layoutControlGroup3.Items.Add(layoutItemUnknownCount);
            
            // Add empty space
            var emptySpaceItemStatistics = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItemStatistics.AllowHotTrack = false;
            emptySpaceItemStatistics.Location = new System.Drawing.Point(0, 17);
            emptySpaceItemStatistics.Name = "emptySpaceItemStatistics";
            emptySpaceItemStatistics.Size = new System.Drawing.Size(752, 1);
            emptySpaceItemStatistics.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup3.Items.Add(emptySpaceItemStatistics);
            
            // layoutControlItem6
            this.layoutControlItem6.Control = this.panelControl3;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 114);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(780, 46);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            
            // DataStorageForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.layoutControl1);
            this.Name = "DataStorageForm";
            this.Text = "Data Storage";
            
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).EndInit();
            this.layoutControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnGenerateReport;
        private DevExpress.XtraEditors.SimpleButton btnUpdateRecordType;
        private DevExpress.XtraEditors.SimpleButton btnDeleteRecords;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraLayout.LayoutControl layoutControl4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.LabelControl lblTotalRecords;
        private DevExpress.XtraEditors.LabelControl lblCheckInCount;
        private DevExpress.XtraEditors.LabelControl lblCheckOutCount;
        private DevExpress.XtraEditors.LabelControl lblUnknownCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}