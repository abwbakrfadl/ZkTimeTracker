using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace ImprovedFingerprint.Forms
{
    partial class AttendanceReportForm
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
            
            this.groupControlFilters = new DevExpress.XtraEditors.GroupControl();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.comboBoxEmployeeFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            
            this.gridControlAttendance = new DevExpress.XtraGrid.GridControl();
            this.gridViewAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            
            this.groupControlActions = new DevExpress.XtraEditors.GroupControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            
            this.lblStatistics = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFilters)).BeginInit();
            this.groupControlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEmployeeFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlActions)).BeginInit();
            this.groupControlActions.SuspendLayout();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlFilters);
            this.layoutControl1.Controls.Add(this.gridControlAttendance);
            this.layoutControl1.Controls.Add(this.groupControlActions);
            this.layoutControl1.Controls.Add(this.lblStatistics);
            this.layoutControl1.Controls.Add(this.lblStatus);
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
            
            // Setup Filters Group
            SetupFiltersGroup();
            
            // Setup Grid
            SetupGrid();
            
            // Setup Actions Group
            SetupActionsGroup();
            
            // Setup Status Controls
            SetupStatusControls();
            
            // Setup Layout
            SetupLayout();
            
            // AttendanceReportForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AttendanceReportForm";
            this.Text = "تقارير الحضور والانصراف";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlFilters)).EndInit();
            this.groupControlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEmployeeFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlActions)).EndInit();
            this.groupControlActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private void SetupFiltersGroup()
        {
            this.groupControlFilters.Text = "مرشحات التقرير";
            this.groupControlFilters.Location = new System.Drawing.Point(12, 12);
            this.groupControlFilters.Size = new System.Drawing.Size(1176, 80);
            this.groupControlFilters.Controls.Add(this.dateEditFrom);
            this.groupControlFilters.Controls.Add(this.dateEditTo);
            this.groupControlFilters.Controls.Add(this.comboBoxEmployeeFilter);
            this.groupControlFilters.Controls.Add(this.btnFilter);
            this.groupControlFilters.Controls.Add(this.btnRefresh);
            
            // From Date
            var lblFromDate = new DevExpress.XtraEditors.LabelControl();
            lblFromDate.Text = "من تاريخ:";
            lblFromDate.Location = new System.Drawing.Point(1100, 30);
            lblFromDate.Size = new System.Drawing.Size(60, 13);
            this.groupControlFilters.Controls.Add(lblFromDate);
            
            this.dateEditFrom.Location = new System.Drawing.Point(950, 27);
            this.dateEditFrom.Size = new System.Drawing.Size(140, 20);
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            
            // To Date
            var lblToDate = new DevExpress.XtraEditors.LabelControl();
            lblToDate.Text = "إلى تاريخ:";
            lblToDate.Location = new System.Drawing.Point(890, 30);
            lblToDate.Size = new System.Drawing.Size(50, 13);
            this.groupControlFilters.Controls.Add(lblToDate);
            
            this.dateEditTo.Location = new System.Drawing.Point(740, 27);
            this.dateEditTo.Size = new System.Drawing.Size(140, 20);
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            
            // Employee Filter
            var lblEmployee = new DevExpress.XtraEditors.LabelControl();
            lblEmployee.Text = "الموظف:";
            lblEmployee.Location = new System.Drawing.Point(680, 30);
            lblEmployee.Size = new System.Drawing.Size(50, 13);
            this.groupControlFilters.Controls.Add(lblEmployee);
            
            this.comboBoxEmployeeFilter.Location = new System.Drawing.Point(480, 27);
            this.comboBoxEmployeeFilter.Size = new System.Drawing.Size(190, 20);
            this.comboBoxEmployeeFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEmployeeFilter.Properties.Items.Add("جميع الموظفين");
            this.comboBoxEmployeeFilter.SelectedIndex = 0;
            this.comboBoxEmployeeFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmployeeFilter_SelectedIndexChanged);
            
            // Filter Button
            this.btnFilter.Text = "تطبيق المرشح";
            this.btnFilter.Location = new System.Drawing.Point(350, 25);
            this.btnFilter.Size = new System.Drawing.Size(120, 25);
            this.btnFilter.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnFilter.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Appearance.Options.UseBackColor = true;
            this.btnFilter.Appearance.Options.UseForeColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            
            // Refresh Button
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.Location = new System.Drawing.Point(220, 25);
            this.btnRefresh.Size = new System.Drawing.Size(120, 25);
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        }
        
        private void SetupGrid()
        {
            this.gridControlAttendance.Location = new System.Drawing.Point(12, 100);
            this.gridControlAttendance.MainView = this.gridViewAttendance;
            this.gridControlAttendance.Size = new System.Drawing.Size(900, 450);
            this.gridControlAttendance.TabIndex = 0;
            this.gridControlAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewAttendance});
            
            this.gridViewAttendance.GridControl = this.gridControlAttendance;
            this.gridViewAttendance.Name = "gridViewAttendance";
            this.gridViewAttendance.OptionsView.ShowGroupPanel = false;
        }
        
        private void SetupActionsGroup()
        {
            this.groupControlActions.Text = "الإجراءات";
            this.groupControlActions.Location = new System.Drawing.Point(920, 100);
            this.groupControlActions.Size = new System.Drawing.Size(268, 450);
            this.groupControlActions.Controls.Add(this.btnExport);
            this.groupControlActions.Controls.Add(this.btnPrint);
            this.groupControlActions.Controls.Add(this.btnClose);
            
            // Export Button
            this.btnExport.Text = "تصدير إلى Excel";
            this.btnExport.Location = new System.Drawing.Point(20, 30);
            this.btnExport.Size = new System.Drawing.Size(220, 35);
            this.btnExport.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            
            // Print Button
            this.btnPrint.Text = "طباعة";
            this.btnPrint.Location = new System.Drawing.Point(20, 80);
            this.btnPrint.Size = new System.Drawing.Size(220, 35);
            this.btnPrint.Appearance.BackColor = System.Drawing.Color.Purple;
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Appearance.Options.UseBackColor = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            
            // Close Button
            this.btnClose.Text = "إغلاق";
            this.btnClose.Location = new System.Drawing.Point(20, 400);
            this.btnClose.Size = new System.Drawing.Size(220, 35);
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        }
        
        private void SetupStatusControls()
        {
            // Statistics Label
            this.lblStatistics.Location = new System.Drawing.Point(920, 560);
            this.lblStatistics.Size = new System.Drawing.Size(268, 100);
            this.lblStatistics.Text = "إحصائيات الفترة ستظهر هنا";
            this.lblStatistics.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblStatistics.Appearance.Options.UseFont = true;
            this.lblStatistics.Appearance.Options.UseTextOptions = true;
            this.lblStatistics.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblStatistics.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblStatistics.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblStatistics.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            
            // Status Label
            this.lblStatus.Location = new System.Drawing.Point(12, 560);
            this.lblStatus.Size = new System.Drawing.Size(900, 30);
            this.lblStatus.Text = "جاهز لعرض التقارير";
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        private void SetupLayout()
        {
            // Add layout items
            var layoutItemFilters = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemFilters.Control = this.groupControlFilters;
            layoutItemFilters.Location = new System.Drawing.Point(0, 0);
            layoutItemFilters.Size = new System.Drawing.Size(1180, 84);
            layoutItemFilters.TextSize = new System.Drawing.Size(0, 0);
            layoutItemFilters.TextVisible = false;
            this.Root.Items.Add(layoutItemFilters);
            
            var layoutItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemGrid.Control = this.gridControlAttendance;
            layoutItemGrid.Location = new System.Drawing.Point(0, 88);
            layoutItemGrid.Size = new System.Drawing.Size(904, 454);
            layoutItemGrid.TextSize = new System.Drawing.Size(0, 0);
            layoutItemGrid.TextVisible = false;
            this.Root.Items.Add(layoutItemGrid);
            
            var layoutItemActions = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemActions.Control = this.groupControlActions;
            layoutItemActions.Location = new System.Drawing.Point(908, 88);
            layoutItemActions.Size = new System.Drawing.Size(272, 454);
            layoutItemActions.TextSize = new System.Drawing.Size(0, 0);
            layoutItemActions.TextVisible = false;
            this.Root.Items.Add(layoutItemActions);
            
            var layoutItemStatistics = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatistics.Control = this.lblStatistics;
            layoutItemStatistics.Location = new System.Drawing.Point(908, 546);
            layoutItemStatistics.Size = new System.Drawing.Size(272, 134);
            layoutItemStatistics.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatistics.TextVisible = false;
            this.Root.Items.Add(layoutItemStatistics);
            
            var layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatus.Control = this.lblStatus;
            layoutItemStatus.Location = new System.Drawing.Point(0, 546);
            layoutItemStatus.Size = new System.Drawing.Size(904, 134);
            layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatus.TextVisible = false;
            this.Root.Items.Add(layoutItemStatus);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        
        private DevExpress.XtraEditors.GroupControl groupControlFilters;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEmployeeFilter;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        
        private DevExpress.XtraGrid.GridControl gridControlAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAttendance;
        
        private DevExpress.XtraEditors.GroupControl groupControlActions;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        
        private DevExpress.XtraEditors.LabelControl lblStatistics;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}