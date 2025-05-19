using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using ZKTecoAttendanceSystem.Models;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class AttendanceMonitorForm : XtraForm
    {
        private readonly DeviceService _deviceService;
        private readonly SettingsService _settingsService;
        private readonly AttendanceService _attendanceService;
        private System.Timers.Timer _refreshTimer;
        private List<AttendanceRecord> _attendanceRecords;

        public AttendanceMonitorForm(DeviceService deviceService, SettingsService settingsService)
        {
            InitializeComponent();
            
            _deviceService = deviceService;
            _settingsService = settingsService;
            _attendanceService = new AttendanceService();
            _attendanceRecords = new List<AttendanceRecord>();
            
            // Setup the grid
            InitializeGrid();
            
            // Initialize date filters
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today.AddDays(1).AddSeconds(-1);
            
            // Setup timer for auto refresh
            _refreshTimer = new System.Timers.Timer(10000); // 10 seconds
            _refreshTimer.Elapsed += OnTimerElapsed;
            
            // Load initial data
            LoadData();
        }

        private void InitializeGrid()
        {
            // Setup Grid View options
            gridViewAttendance.OptionsBehavior.Editable = false;
            gridViewAttendance.OptionsView.ShowGroupPanel = false;
            gridViewAttendance.OptionsView.ShowIndicator = false;
            
            // Setup columns display settings
            if (gridViewAttendance.Columns["EmployeeId"] != null)
                gridViewAttendance.Columns["EmployeeId"].Caption = "Employee ID";
            
            if (gridViewAttendance.Columns["RecordTime"] != null)
            {
                gridViewAttendance.Columns["RecordTime"].Caption = "Record Time";
                gridViewAttendance.Columns["RecordTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridViewAttendance.Columns["RecordTime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            }
            
            if (gridViewAttendance.Columns["RecordType"] != null)
                gridViewAttendance.Columns["RecordType"].Caption = "Record Type";
            
            // Setup conditional formatting
            gridViewAttendance.RowStyle += GridViewAttendance_RowStyle;
        }

        private void GridViewAttendance_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var record = gridViewAttendance.GetRow(e.RowHandle) as AttendanceRecord;
                if (record != null)
                {
                    if (record.RecordType == AttendanceType.CheckIn)
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (record.RecordType == AttendanceType.CheckOut)
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        e.Appearance.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                // Must invoke to UI thread
                BeginInvoke(new Action(() => LoadData()));
            }
        }

        private void LoadData()
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            lblStatus.Text = "Loading attendance data...";

            try
            {
                // Get attendance records from device
                var newRecords = _deviceService.GetAttendanceRecords();
                
                // Apply date range filter
                var filteredRecords = new List<AttendanceRecord>();
                foreach (var record in newRecords)
                {
                    if (record.RecordTime >= dateFrom.DateTime && record.RecordTime <= dateTo.DateTime)
                    {
                        if (!string.IsNullOrEmpty(txtEmployeeId.Text))
                        {
                            if (record.EmployeeId.ToString() == txtEmployeeId.Text)
                            {
                                filteredRecords.Add(record);
                            }
                        }
                        else
                        {
                            filteredRecords.Add(record);
                        }
                    }
                }
                
                // Classify records based on time settings
                var timeSettings = _settingsService.GetTimeSettings();
                if (timeSettings != null)
                {
                    foreach (var record in filteredRecords)
                    {
                        record.RecordType = _attendanceService.ClassifyAttendanceRecord(record, timeSettings);
                    }
                }
                
                _attendanceRecords = filteredRecords;
                gridAttendance.DataSource = _attendanceRecords;
                gridAttendance.RefreshDataSource();
                
                lblStatus.Text = $"Loaded {_attendanceRecords.Count} records. Last updated: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading attendance data.";
                XtraMessageBox.Show($"Error retrieving attendance records: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Set up save dialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv";
                saveFileDialog.Title = "Export Attendance Data";
                saveFileDialog.FileName = $"Attendance_{DateTime.Now:yyyyMMdd_HHmmss}";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    lblStatus.Text = "Exporting data...";
                    
                    string filePath = saveFileDialog.FileName;
                    string extension = System.IO.Path.GetExtension(filePath).ToLower();
                    
                    if (extension == ".xlsx")
                    {
                        gridViewAttendance.ExportToXlsx(filePath);
                    }
                    else if (extension == ".csv")
                    {
                        gridViewAttendance.ExportToCsv(filePath);
                    }
                    
                    lblStatus.Text = "Data exported successfully.";
                    XtraMessageBox.Show("Data exported successfully.", "Export Complete", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error exporting data.";
                XtraMessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Text = string.Empty;
            dateFrom.DateTime = DateTime.Today;
            dateTo.DateTime = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadData();
        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            if (_attendanceRecords.Count == 0)
            {
                XtraMessageBox.Show("No records to save.", "No Data", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Saving records to database...";
                
                int savedCount = _attendanceService.SaveAttendanceRecords(_attendanceRecords);
                
                lblStatus.Text = $"Saved {savedCount} records to database.";
                XtraMessageBox.Show($"Successfully saved {savedCount} attendance records to database.", "Save Complete", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error saving records to database.";
                XtraMessageBox.Show($"Error saving records to database: {ex.Message}", "Database Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
            {
                _refreshTimer.Start();
            }
            else
            {
                _refreshTimer.Stop();
            }
        }

        private void AttendanceMonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up timer
            if (_refreshTimer != null)
            {
                _refreshTimer.Stop();
                _refreshTimer.Dispose();
            }
        }
    }
}