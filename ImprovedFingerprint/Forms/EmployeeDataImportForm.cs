using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ImprovedFingerprint.Services;
using ImprovedFingerprint.Models;

namespace ImprovedFingerprint.Forms
{
    public partial class EmployeeDataImportForm : XtraForm
    {
        private readonly DeviceService _deviceService;
        private readonly DatabaseService _databaseService;
        private List<Employee> _deviceEmployees;
        private List<Employee> _databaseEmployees;
        private BackgroundWorker _backgroundWorker;

        public EmployeeDataImportForm(DeviceService deviceService)
        {
            InitializeComponent();
            _deviceService = deviceService;
            _databaseService = new DatabaseService();
            
            this.Text = "تحميل بيانات الموظفين من جهاز البصمة";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            
            InitializeBackgroundWorker();
            SetupGridViews();
            LoadData();
        }

        private void InitializeBackgroundWorker()
        {
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void SetupGridViews()
        {
            // إعداد جدول بيانات الجهاز
            gridViewDevice.OptionsView.ShowGroupPanel = false;
            gridViewDevice.OptionsView.ColumnAutoWidth = false;
            gridViewDevice.OptionsSelection.MultiSelect = true;
            gridViewDevice.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            
            // إعداد جدول بيانات قاعدة البيانات
            gridViewDatabase.OptionsView.ShowGroupPanel = false;
            gridViewDatabase.OptionsView.ColumnAutoWidth = false;
            gridViewDatabase.OptionsSelection.MultiSelect = false;
            
            // إعداد الأعمدة
            SetupDeviceGridColumns();
            SetupDatabaseGridColumns();
        }

        private void SetupDeviceGridColumns()
        {
            gridViewDevice.Columns.Clear();
            
            gridViewDevice.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "DeviceUserId",
                Caption = "معرف الجهاز",
                Width = 80,
                Visible = true
            });
            
            gridViewDevice.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "EmployeeNumber",
                Caption = "رقم الموظف",
                Width = 100,
                Visible = true
            });
            
            gridViewDevice.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "FullName",
                Caption = "اسم الموظف",
                Width = 200,
                Visible = true
            });
            
            gridViewDevice.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "IsActive",
                Caption = "نشط",
                Width = 60,
                Visible = true
            });
        }

        private void SetupDatabaseGridColumns()
        {
            gridViewDatabase.Columns.Clear();
            
            gridViewDatabase.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "EmployeeNumber",
                Caption = "رقم الموظف",
                Width = 100,
                Visible = true
            });
            
            gridViewDatabase.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "FullName",
                Caption = "اسم الموظف",
                Width = 200,
                Visible = true
            });
            
            gridViewDatabase.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "Department",
                Caption = "القسم",
                Width = 120,
                Visible = true
            });
            
            gridViewDatabase.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "Position",
                Caption = "المنصب",
                Width = 120,
                Visible = true
            });
            
            gridViewDatabase.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "HireDate",
                Caption = "تاريخ التوظيف",
                Width = 100,
                Visible = true
            });
            
            gridViewDatabase.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn
            {
                FieldName = "IsActive",
                Caption = "نشط",
                Width = 60,
                Visible = true
            });
        }

        private async void LoadData()
        {
            try
            {
                SetControlsEnabled(false);
                lblStatus.Text = "جاري تحميل البيانات...";
                progressBarControl.Properties.ShowTitle = true;
                progressBarControl.Properties.PercentView = true;
                
                // تحميل بيانات قاعدة البيانات أولاً
                await Task.Run(() =>
                {
                    _databaseEmployees = _databaseService.GetAllEmployees();
                });
                
                gridControlDatabase.DataSource = _databaseEmployees;
                lblDatabaseCount.Text = $"عدد الموظفين في قاعدة البيانات: {_databaseEmployees.Count}";
                
                // بدء تحميل بيانات الجهاز في الخلفية
                if (!_backgroundWorker.IsBusy)
                {
                    _backgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "خطأ في تحميل البيانات";
                XtraMessageBox.Show($"خطأ في تحميل البيانات: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetControlsEnabled(true);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!_deviceService.IsConnected)
                {
                    e.Result = "Device not connected";
                    return;
                }

                _backgroundWorker.ReportProgress(10, "جاري الاتصال بجهاز البصمة...");
                
                _backgroundWorker.ReportProgress(30, "جاري قراءة بيانات الموظفين من الجهاز...");
                _deviceEmployees = _deviceService.GetAllEmployees();
                
                _backgroundWorker.ReportProgress(80, "جاري معالجة البيانات...");
                
                // إضافة معلومات إضافية للموظفين
                foreach (var employee in _deviceEmployees)
                {
                    employee.HireDate = DateTime.Now;
                    employee.CreatedDate = DateTime.Now;
                    employee.IsActive = true;
                    
                    if (_backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                
                _backgroundWorker.ReportProgress(100, "تم الانتهاء من تحميل البيانات");
                e.Result = "Success";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarControl.Position = e.ProgressPercentage;
            if (e.UserState != null)
            {
                lblStatus.Text = e.UserState.ToString();
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    lblStatus.Text = "تم إلغاء العملية";
                }
                else if (e.Error != null)
                {
                    lblStatus.Text = "خطأ في تحميل بيانات الجهاز";
                    XtraMessageBox.Show($"خطأ في تحميل بيانات الجهاز: {e.Error.Message}", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var result = e.Result.ToString();
                    if (result == "Device not connected")
                    {
                        lblStatus.Text = "جهاز البصمة غير متصل";
                        XtraMessageBox.Show("الرجاء الاتصال بجهاز البصمة أولاً", "لا يوجد اتصال",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (result == "Success")
                    {
                        gridControlDevice.DataSource = _deviceEmployees;
                        lblDeviceCount.Text = $"عدد الموظفين في الجهاز: {_deviceEmployees?.Count ?? 0}";
                        lblStatus.Text = "تم تحميل بيانات الموظفين من الجهاز بنجاح";
                        
                        // إظهار إحصائيات المقارنة
                        ShowComparisonStats();
                    }
                    else
                    {
                        lblStatus.Text = "خطأ غير متوقع";
                        XtraMessageBox.Show($"خطأ: {result}", "خطأ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                SetControlsEnabled(true);
                progressBarControl.Position = 0;
            }
        }

        private void ShowComparisonStats()
        {
            if (_deviceEmployees == null || _databaseEmployees == null)
                return;

            var deviceNumbers = _deviceEmployees.Select(e => e.EmployeeNumber).ToHashSet();
            var databaseNumbers = _databaseEmployees.Select(e => e.EmployeeNumber).ToHashSet();
            
            var newInDevice = deviceNumbers.Except(databaseNumbers).Count();
            var existingInBoth = deviceNumbers.Intersect(databaseNumbers).Count();
            var onlyInDatabase = databaseNumbers.Except(deviceNumbers).Count();
            
            var stats = $@"إحصائيات المقارنة:
• موظفين جدد في الجهاز: {newInDevice}
• موظفين موجودين في كلاهما: {existingInBoth}
• موظفين فقط في قاعدة البيانات: {onlyInDatabase}";
            
            lblComparisonStats.Text = stats;
        }

        private void btnImportSelected_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = gridViewDevice.GetSelectedRows();
                if (selectedRows.Length == 0)
                {
                    XtraMessageBox.Show("الرجاء اختيار الموظفين المراد استيرادهم", "لا يوجد اختيار",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedEmployees = new List<Employee>();
                foreach (var rowHandle in selectedRows)
                {
                    if (rowHandle >= 0)
                    {
                        var employee = gridViewDevice.GetRow(rowHandle) as Employee;
                        if (employee != null)
                        {
                            selectedEmployees.Add(employee);
                        }
                    }
                }

                if (selectedEmployees.Count == 0)
                {
                    XtraMessageBox.Show("لم يتم العثور على موظفين صالحين للاستيراد", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = XtraMessageBox.Show(
                    $"هل تريد استيراد {selectedEmployees.Count} موظف إلى قاعدة البيانات؟",
                    "تأكيد الاستيراد",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ImportEmployees(selectedEmployees);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في استيراد الموظفين: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportEmployees(List<Employee> employees)
        {
            try
            {
                SetControlsEnabled(false);
                progressBarControl.Properties.Maximum = employees.Count;
                progressBarControl.Position = 0;
                
                int successCount = 0;
                int skipCount = 0;
                int errorCount = 0;
                var errors = new List<string>();

                foreach (var employee in employees)
                {
                    try
                    {
                        lblStatus.Text = $"جاري استيراد الموظف: {employee.FullName}";
                        Application.DoEvents();

                        // التحقق من وجود الموظف
                        if (_databaseService.EmployeeExists(employee.EmployeeNumber))
                        {
                            skipCount++;
                            lblStatus.Text = $"تم تخطي الموظف {employee.FullName} - موجود مسبقاً";
                        }
                        else
                        {
                            // إضافة معلومات افتراضية
                            employee.Department = "غير محدد";
                            employee.Position = "موظف";
                            employee.HireDate = DateTime.Now;
                            employee.CreatedDate = DateTime.Now;
                            employee.IsActive = true;

                            if (_databaseService.InsertEmployee(employee))
                            {
                                successCount++;
                            }
                            else
                            {
                                errorCount++;
                                errors.Add($"فشل في إضافة الموظف: {employee.FullName}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        errors.Add($"خطأ في استيراد {employee.FullName}: {ex.Message}");
                    }
                    
                    progressBarControl.Position++;
                }

                // إعادة تحميل بيانات قاعدة البيانات
                _databaseEmployees = _databaseService.GetAllEmployees();
                gridControlDatabase.DataSource = _databaseEmployees;
                lblDatabaseCount.Text = $"عدد الموظفين في قاعدة البيانات: {_databaseEmployees.Count}";
                
                // إظهار تقرير النتائج
                ShowImportResults(successCount, skipCount, errorCount, errors);
                
                // تحديث الإحصائيات
                ShowComparisonStats();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في عملية الاستيراد: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetControlsEnabled(true);
                progressBarControl.Position = 0;
                lblStatus.Text = "انتهت عملية الاستيراد";
            }
        }

        private void ShowImportResults(int successCount, int skipCount, int errorCount, List<string> errors)
        {
            var message = $@"نتائج عملية الاستيراد:

• تم استيراد {successCount} موظف بنجاح
• تم تخطي {skipCount} موظف (موجودين مسبقاً)
• فشل في استيراد {errorCount} موظف";

            if (errors.Count > 0 && errors.Count <= 5)
            {
                message += "\n\nالأخطاء:\n" + string.Join("\n", errors);
            }
            else if (errors.Count > 5)
            {
                message += $"\n\nعدد الأخطاء: {errors.Count} (أول 5 أخطاء):\n" + 
                          string.Join("\n", errors.Take(5));
            }

            var icon = errorCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information;
            XtraMessageBox.Show(message, "نتائج الاستيراد", MessageBoxButtons.OK, icon);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridViewDevice.SelectAll();
            lblStatus.Text = $"تم اختيار جميع الموظفين ({gridViewDevice.DataRowCount})";
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            gridViewDevice.ClearSelection();
            lblStatus.Text = "تم إلغاء اختيار جميع الموظفين";
        }

        private void btnSelectNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (_deviceEmployees == null || _databaseEmployees == null)
                    return;

                gridViewDevice.ClearSelection();
                
                var databaseNumbers = _databaseEmployees.Select(e => e.EmployeeNumber).ToHashSet();
                int selectedCount = 0;

                for (int i = 0; i < gridViewDevice.DataRowCount; i++)
                {
                    var employee = gridViewDevice.GetRow(i) as Employee;
                    if (employee != null && !databaseNumbers.Contains(employee.EmployeeNumber))
                    {
                        gridViewDevice.SelectRow(i);
                        selectedCount++;
                    }
                }

                lblStatus.Text = $"تم اختيار {selectedCount} موظف جديد";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في اختيار الموظفين الجدد: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("هل تريد إعادة تحميل البيانات من الجهاز؟\nقد يستغرق هذا بعض الوقت.",
                "تأكيد إعادة التحميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoadData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_backgroundWorker.IsBusy)
            {
                var result = XtraMessageBox.Show("جاري تحميل البيانات. هل تريد إلغاء العملية والإغلاق؟",
                    "تأكيد الإغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _backgroundWorker.CancelAsync();
                }
                else
                {
                    return;
                }
            }

            Close();
        }

        private void SetControlsEnabled(bool enabled)
        {
            btnImportSelected.Enabled = enabled;
            btnSelectAll.Enabled = enabled;
            btnSelectNone.Enabled = enabled;
            btnSelectNew.Enabled = enabled;
            btnRefresh.Enabled = enabled;
            gridControlDevice.Enabled = enabled;
            gridControlDatabase.Enabled = enabled;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_backgroundWorker?.IsBusy == true)
            {
                _backgroundWorker.CancelAsync();
            }
            
            _backgroundWorker?.Dispose();
            base.OnFormClosing(e);
        }
    }
}