using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ImprovedFingerprint.Services;
using ImprovedFingerprint.Models;

namespace ImprovedFingerprint.Forms
{
    public partial class AttendanceReportForm : XtraForm
    {
        private readonly DatabaseService _databaseService;
        private List<AttendanceRecord> _attendanceRecords;

        public AttendanceReportForm(DatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            
            this.Text = "تقارير الحضور والانصراف";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.WindowState = FormWindowState.Maximized;
            
            SetupGrid();
            SetupDateFilters();
            LoadAttendanceData();
        }

        private void SetupGrid()
        {
            gridViewAttendance.OptionsView.ShowGroupPanel = false;
            gridViewAttendance.OptionsView.ColumnAutoWidth = false;
            gridViewAttendance.OptionsSelection.MultiSelect = false;
            
            SetupGridColumns();
        }

        private void SetupGridColumns()
        {
            gridViewAttendance.Columns.Clear();
            
            gridViewAttendance.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "EmployeeNumber",
                Caption = "رقم الموظف",
                Width = 100,
                Visible = true
            });
            
            gridViewAttendance.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "EmployeeName",
                Caption = "اسم الموظف",
                Width = 200,
                Visible = true
            });
            
            gridViewAttendance.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "AttendanceDateTime",
                Caption = "تاريخ ووقت التسجيل",
                Width = 150,
                Visible = true
            });
            
            var typeColumn = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "Type",
                Caption = "نوع التسجيل",
                Width = 100,
                Visible = true
            };
            typeColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            typeColumn.DisplayFormat.Format = new DevExpress.Utils.FormatInfo
            {
                FormatType = DevExpress.Utils.FormatType.Custom
            };
            gridViewAttendance.Columns.Add(typeColumn);
            
            gridViewAttendance.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "Shift",
                Caption = "الوردية",
                Width = 100,
                Visible = true
            });
            
            var sourceColumn = new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "Source",
                Caption = "المصدر",
                Width = 80,
                Visible = true
            };
            sourceColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridViewAttendance.Columns.Add(sourceColumn);
            
            gridViewAttendance.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "DeviceId",
                Caption = "معرف الجهاز",
                Width = 120,
                Visible = true
            });
            
            gridViewAttendance.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "Notes",
                Caption = "ملاحظات",
                Width = 150,
                Visible = true
            });

            // إعداد تنسيق العرض للأعمدة
            gridViewAttendance.CustomColumnDisplayText += GridViewAttendance_CustomColumnDisplayText;
        }

        private void GridViewAttendance_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Type")
            {
                if (e.Value is AttendanceType type)
                {
                    e.DisplayText = type == AttendanceType.CheckIn ? "دخول" : "خروج";
                }
            }
            else if (e.Column.FieldName == "Source")
            {
                if (e.Value is AttendanceSource source)
                {
                    e.DisplayText = source == AttendanceSource.Device ? "جهاز البصمة" : "إدخال يدوي";
                }
            }
        }

        private void SetupDateFilters()
        {
            // تعيين التواريخ الافتراضية (آخر 30 يوم)
            dateEditFrom.DateTime = DateTime.Now.AddDays(-30);
            dateEditTo.DateTime = DateTime.Now;
        }

        private void LoadAttendanceData()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري تحميل بيانات الحضور...";
                Application.DoEvents();

                var fromDate = dateEditFrom.DateTime.Date;
                var toDate = dateEditTo.DateTime.Date;

                _attendanceRecords = _databaseService.GetAttendanceRecords(fromDate, toDate);
                gridControlAttendance.DataSource = _attendanceRecords;

                UpdateStatistics();
                lblStatus.Text = $"تم تحميل {_attendanceRecords.Count} سجل حضور";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في تحميل البيانات";
                XtraMessageBox.Show($"خطأ في تحميل بيانات الحضور: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void UpdateStatistics()
        {
            if (_attendanceRecords == null)
                return;

            var totalRecords = _attendanceRecords.Count;
            var checkInCount = 0;
            var checkOutCount = 0;
            var deviceRecords = 0;
            var manualRecords = 0;

            foreach (var record in _attendanceRecords)
            {
                if (record.Type == AttendanceType.CheckIn)
                    checkInCount++;
                else
                    checkOutCount++;

                if (record.Source == AttendanceSource.Device)
                    deviceRecords++;
                else
                    manualRecords++;
            }

            var stats = $@"إحصائيات الفترة:
• إجمالي السجلات: {totalRecords}
• سجلات الدخول: {checkInCount}
• سجلات الخروج: {checkOutCount}
• من جهاز البصمة: {deviceRecords}
• إدخال يدوي: {manualRecords}";

            lblStatistics.Text = stats;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateEditFrom.DateTime > dateEditTo.DateTime)
                {
                    XtraMessageBox.Show("تاريخ البداية يجب أن يكون أقل من أو يساوي تاريخ النهاية", 
                        "خطأ في التواريخ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var daysDifference = (dateEditTo.DateTime - dateEditFrom.DateTime).Days;
                if (daysDifference > 90)
                {
                    var result = XtraMessageBox.Show(
                        "الفترة المحددة أكثر من 90 يوم. قد يستغرق التحميل وقتاً طويلاً. هل تريد المتابعة؟",
                        "تأكيد الفترة الطويلة",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                LoadAttendanceData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تطبيق المرشح: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_attendanceRecords == null || _attendanceRecords.Count == 0)
                {
                    XtraMessageBox.Show("لا توجد بيانات للتصدير", "لا توجد بيانات",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv";
                    saveDialog.DefaultExt = "xlsx";
                    saveDialog.FileName = $"تقرير_الحضور_{DateTime.Now:yyyy-MM-dd}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor = Cursors.WaitCursor;
                        lblStatus.Text = "جاري تصدير البيانات...";
                        Application.DoEvents();

                        if (saveDialog.FileName.EndsWith(".xlsx"))
                        {
                            gridViewAttendance.ExportToXlsx(saveDialog.FileName);
                        }
                        else
                        {
                            gridViewAttendance.ExportToCsv(saveDialog.FileName);
                        }

                        lblStatus.Text = "تم تصدير البيانات بنجاح";
                        XtraMessageBox.Show("تم تصدير التقرير بنجاح", "نجح التصدير",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في تصدير البيانات";
                XtraMessageBox.Show($"خطأ في تصدير التقرير: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (_attendanceRecords == null || _attendanceRecords.Count == 0)
                {
                    XtraMessageBox.Show("لا توجد بيانات للطباعة", "لا توجد بيانات",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "جاري تحضير التقرير للطباعة...";
                Application.DoEvents();

                gridControlAttendance.ShowRibbonPrintPreview();
                lblStatus.Text = "تم فتح معاينة الطباعة";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في معاينة الطباعة";
                XtraMessageBox.Show($"خطأ في معاينة الطباعة: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxEmployeeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // يمكن إضافة تصفية حسب الموظف هنا
            ApplyEmployeeFilter();
        }

        private void ApplyEmployeeFilter()
        {
            try
            {
                if (_attendanceRecords == null)
                    return;

                var selectedEmployee = comboBoxEmployeeFilter.SelectedItem?.ToString();
                
                if (string.IsNullOrEmpty(selectedEmployee) || selectedEmployee == "جميع الموظفين")
                {
                    gridControlAttendance.DataSource = _attendanceRecords;
                }
                else
                {
                    var filteredRecords = _attendanceRecords.FindAll(r => 
                        r.EmployeeName?.Contains(selectedEmployee) == true ||
                        r.EmployeeNumber?.Contains(selectedEmployee) == true);
                    
                    gridControlAttendance.DataSource = filteredRecords;
                }

                gridViewAttendance.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تطبيق تصفية الموظف: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}