using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ZKTecoAttendanceSystem.Models;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class DataStorageForm : XtraForm
    {
        private readonly AttendanceService _attendanceService;
        private readonly List<AttendanceRecord> _records;

        public DataStorageForm()
        {
            InitializeComponent();
            _attendanceService = new AttendanceService();
            _records = new List<AttendanceRecord>();

            // Initialize date filter
            dateFrom.DateTime = DateTime.Today.AddDays(-7);
            dateTo.DateTime = DateTime.Today.AddDays(1).AddSeconds(-1);

            // Initialize grids
            InitializeGrid();
            LoadData();
        }

        private void InitializeGrid()
        {
            // Setup Grid View options
            gridViewAttendance.OptionsBehavior.Editable = false;
            gridViewAttendance.OptionsView.ShowGroupPanel = false;
            gridViewAttendance.OptionsView.ShowIndicator = false;

            // Setup conditional formatting for record type
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

        private void LoadData()
        {
            Cursor = Cursors.WaitCursor;
            lblStatus.Text = "Loading attendance data...";

            try
            {
                var employeeId = string.IsNullOrEmpty(txtEmployeeId.Text) ? 
                    (int?)null : Convert.ToInt32(txtEmployeeId.Text);

                var records = _attendanceService.GetAttendanceRecords(
                    dateFrom.DateTime,
                    dateTo.DateTime,
                    employeeId);

                gridAttendance.DataSource = records;
                
                lblStatus.Text = $"Loaded {records.Count} records.";
                lblTotalRecords.Text = $"Total Records: {records.Count}";
                
                // Analyze attendance data
                var checkInCount = 0;
                var checkOutCount = 0;
                var unknownCount = 0;
                
                foreach (var record in records)
                {
                    switch (record.RecordType)
                    {
                        case AttendanceType.CheckIn:
                            checkInCount++;
                            break;
                        case AttendanceType.CheckOut:
                            checkOutCount++;
                            break;
                        case AttendanceType.Unknown:
                            unknownCount++;
                            break;
                    }
                }
                
                lblCheckInCount.Text = $"Check-ins: {checkInCount}";
                lblCheckOutCount.Text = $"Check-outs: {checkOutCount}";
                lblUnknownCount.Text = $"Unknown: {unknownCount}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error loading data from database.";
                XtraMessageBox.Show($"Error loading attendance data: {ex.Message}", "Database Error", 
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
            dateFrom.DateTime = DateTime.Today.AddDays(-7);
            dateTo.DateTime = DateTime.Today.AddDays(1).AddSeconds(-1);
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv";
                saveFileDialog.Title = "Export Attendance Data";
                saveFileDialog.FileName = $"Attendance_Export_{DateTime.Now:yyyyMMdd_HHmmss}";

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

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Generate Attendance Report";
                saveFileDialog.FileName = $"Attendance_Report_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    lblStatus.Text = "Generating report...";

                    string filePath = saveFileDialog.FileName;
                    
                    // Export to PDF
                    gridViewAttendance.ExportToPdf(filePath);

                    lblStatus.Text = "Report generated successfully.";
                    XtraMessageBox.Show("Report generated successfully.", "Report Generation Complete", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error generating report.";
                XtraMessageBox.Show($"Error generating report: {ex.Message}", "Report Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnUpdateRecordType_Click(object sender, EventArgs e)
        {
            if (gridViewAttendance.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Please select at least one record to update.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedIndex = gridViewAttendance.FocusedRowHandle;
            if (selectedIndex < 0)
            {
                XtraMessageBox.Show("Please select a valid record to update.", "Invalid Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var record = gridViewAttendance.GetRow(selectedIndex) as AttendanceRecord;
            if (record == null)
            {
                XtraMessageBox.Show("Cannot retrieve selected record data.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show popup to select the new record type
            UpdateRecordTypeForm updateForm = new UpdateRecordTypeForm(record.RecordType);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    lblStatus.Text = "Updating record type...";

                    bool success = _attendanceService.UpdateAttendanceRecordType(
                        record.Id, 
                        updateForm.SelectedRecordType);

                    if (success)
                    {
                        lblStatus.Text = "Record type updated successfully.";
                        XtraMessageBox.Show("Record type updated successfully.", "Update Complete", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Refresh data
                        LoadData();
                    }
                    else
                    {
                        lblStatus.Text = "Failed to update record type.";
                        XtraMessageBox.Show("Failed to update record type.", "Update Failed", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error updating record type.";
                    XtraMessageBox.Show($"Error updating record type: {ex.Message}", "Database Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnDeleteRecords_Click(object sender, EventArgs e)
        {
            if (gridViewAttendance.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Please select at least one record to delete.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = XtraMessageBox.Show(
                "Are you sure you want to delete the selected record(s)? This action cannot be undone.",
                "Confirm Deletion", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    lblStatus.Text = "Deleting records...";

                    var selectedRows = gridViewAttendance.GetSelectedRows();
                    var recordIds = new List<int>();

                    foreach (var rowHandle in selectedRows)
                    {
                        if (rowHandle >= 0)
                        {
                            var record = gridViewAttendance.GetRow(rowHandle) as AttendanceRecord;
                            if (record != null)
                            {
                                recordIds.Add(record.Id);
                            }
                        }
                    }

                    int deletedCount = _attendanceService.DeleteAttendanceRecords(recordIds);

                    lblStatus.Text = $"Deleted {deletedCount} records successfully.";
                    XtraMessageBox.Show($"Successfully deleted {deletedCount} records.", "Deletion Complete", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh data
                    LoadData();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error deleting records.";
                    XtraMessageBox.Show($"Error deleting records: {ex.Message}", "Database Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}