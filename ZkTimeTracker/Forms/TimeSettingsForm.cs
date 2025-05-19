using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Models;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class TimeSettingsForm : XtraForm
    {
        private readonly SettingsService _settingsService;
        private TimeSettings _timeSettings;

        public TimeSettingsForm(SettingsService settingsService)
        {
            InitializeComponent();
            
            _settingsService = settingsService;
            
            // Load current time settings
            LoadTimeSettings();
        }

        private void LoadTimeSettings()
        {
            try
            {
                _timeSettings = _settingsService.GetTimeSettings();
                
                if (_timeSettings == null)
                {
                    // Create default time settings if none exist
                    _timeSettings = new TimeSettings
                    {
                        MorningShiftStart = new TimeSpan(8, 0, 0),
                        MorningShiftEnd = new TimeSpan(12, 0, 0),
                        AfternoonShiftStart = new TimeSpan(13, 0, 0),
                        AfternoonShiftEnd = new TimeSpan(17, 0, 0),
                        LateArrivalThreshold = new TimeSpan(0, 15, 0),
                        EarlyDepartureThreshold = new TimeSpan(0, 15, 0),
                        OvertimeStart = new TimeSpan(17, 30, 0)
                    };
                }
                
                // Populate the time editors
                timeEditMorningStart.Time = DateTime.Today.Add(_timeSettings.MorningShiftStart);
                timeEditMorningEnd.Time = DateTime.Today.Add(_timeSettings.MorningShiftEnd);
                timeEditAfternoonStart.Time = DateTime.Today.Add(_timeSettings.AfternoonShiftStart);
                timeEditAfternoonEnd.Time = DateTime.Today.Add(_timeSettings.AfternoonShiftEnd);
                timeEditLateThreshold.Time = DateTime.Today.Add(_timeSettings.LateArrivalThreshold);
                timeEditEarlyThreshold.Time = DateTime.Today.Add(_timeSettings.EarlyDepartureThreshold);
                timeEditOvertimeStart.Time = DateTime.Today.Add(_timeSettings.OvertimeStart);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading time settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate time settings
                if (timeEditMorningStart.Time >= timeEditMorningEnd.Time)
                {
                    XtraMessageBox.Show("Morning shift start time must be earlier than end time.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (timeEditAfternoonStart.Time >= timeEditAfternoonEnd.Time)
                {
                    XtraMessageBox.Show("Afternoon shift start time must be earlier than end time.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (timeEditMorningEnd.Time > timeEditAfternoonStart.Time)
                {
                    XtraMessageBox.Show("Morning shift end time must be earlier than afternoon shift start time.", 
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Update the time settings object
                _timeSettings.MorningShiftStart = timeEditMorningStart.Time.TimeOfDay;
                _timeSettings.MorningShiftEnd = timeEditMorningEnd.Time.TimeOfDay;
                _timeSettings.AfternoonShiftStart = timeEditAfternoonStart.Time.TimeOfDay;
                _timeSettings.AfternoonShiftEnd = timeEditAfternoonEnd.Time.TimeOfDay;
                _timeSettings.LateArrivalThreshold = timeEditLateThreshold.Time.TimeOfDay;
                _timeSettings.EarlyDepartureThreshold = timeEditEarlyThreshold.Time.TimeOfDay;
                _timeSettings.OvertimeStart = timeEditOvertimeStart.Time.TimeOfDay;
                
                // Save the time settings
                _settingsService.SaveTimeSettings(_timeSettings);
                
                XtraMessageBox.Show("Time settings saved successfully.", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error saving time settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure you want to reset all time settings to default values?", 
                "Confirm Reset", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                // Reset to default values
                timeEditMorningStart.Time = DateTime.Today.Add(new TimeSpan(8, 0, 0));
                timeEditMorningEnd.Time = DateTime.Today.Add(new TimeSpan(12, 0, 0));
                timeEditAfternoonStart.Time = DateTime.Today.Add(new TimeSpan(13, 0, 0));
                timeEditAfternoonEnd.Time = DateTime.Today.Add(new TimeSpan(17, 0, 0));
                timeEditLateThreshold.Time = DateTime.Today.Add(new TimeSpan(0, 15, 0));
                timeEditEarlyThreshold.Time = DateTime.Today.Add(new TimeSpan(0, 15, 0));
                timeEditOvertimeStart.Time = DateTime.Today.Add(new TimeSpan(17, 30, 0));
            }
        }
    }
}