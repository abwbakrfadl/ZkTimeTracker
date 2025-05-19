using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class DeviceManagementForm : XtraForm
    {
        private readonly DeviceService _deviceService;

        public DeviceManagementForm(DeviceService deviceService)
        {
            InitializeComponent();
            _deviceService = deviceService;
            
            LoadDeviceInfo();
        }

        private async void LoadDeviceInfo()
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnGetDeviceInfo.Enabled = false;
            lblStatusValue.Text = "Loading device information...";

            try
            {
                var deviceInfo = await Task.Run(() => _deviceService.GetDeviceInfo());
                
                txtDeviceID.Text = deviceInfo.DeviceID.ToString();
                txtFirmwareVersion.Text = deviceInfo.FirmwareVersion;
                chkSound.Checked = deviceInfo.SoundEnabled;
                txtDeviceLanguage.Text = deviceInfo.Language.ToString();
                
                lblStatusValue.Text = "Device information loaded successfully.";
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error loading device information.";
                XtraMessageBox.Show($"Error getting device information: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGetDeviceInfo.Enabled = true;
            }
        }

        private async void btnGetDeviceInfo_Click(object sender, EventArgs e)
        {
            await LoadDeviceInfoAsync();
        }

        private async Task LoadDeviceInfoAsync()
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnGetDeviceInfo.Enabled = false;
            lblStatusValue.Text = "Loading device information...";

            try
            {
                var deviceInfo = await Task.Run(() => _deviceService.GetDeviceInfo());
                
                txtDeviceID.Text = deviceInfo.DeviceID.ToString();
                txtFirmwareVersion.Text = deviceInfo.FirmwareVersion;
                chkSound.Checked = deviceInfo.SoundEnabled;
                txtDeviceLanguage.Text = deviceInfo.Language.ToString();
                
                lblStatusValue.Text = "Device information loaded successfully.";
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error loading device information.";
                XtraMessageBox.Show($"Error getting device information: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGetDeviceInfo.Enabled = true;
            }
        }

        private async void btnSetDeviceInfo_Click(object sender, EventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDeviceID.Text, out int deviceId))
            {
                XtraMessageBox.Show("Device ID must be a valid number.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnSetDeviceInfo.Enabled = false;
            lblStatusValue.Text = "Setting device information...";

            try
            {
                bool success = await Task.Run(() => _deviceService.SetDeviceInfo(
                    deviceId,
                    chkSound.Checked,
                    txtDeviceLanguage.Text));
                
                if (success)
                {
                    lblStatusValue.Text = "Device information updated successfully.";
                    XtraMessageBox.Show("Device information updated successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatusValue.Text = "Failed to update device information.";
                    XtraMessageBox.Show("Failed to update device information.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error setting device information.";
                XtraMessageBox.Show($"Error setting device information: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSetDeviceInfo.Enabled = true;
            }
        }

        private async void btnSyncTime_Click(object sender, EventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnSyncTime.Enabled = false;
            lblStatusValue.Text = "Synchronizing time...";

            try
            {
                bool success = await Task.Run(() => _deviceService.SetDeviceTime(DateTime.Now));
                
                if (success)
                {
                    lblStatusValue.Text = "Time synchronized successfully.";
                    XtraMessageBox.Show("Time synchronized successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatusValue.Text = "Failed to synchronize time.";
                    XtraMessageBox.Show("Failed to synchronize time.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error synchronizing time.";
                XtraMessageBox.Show($"Error synchronizing time: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSyncTime.Enabled = true;
            }
        }

        private async void btnEnableDevice_Click(object sender, EventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnEnableDevice.Enabled = false;
            lblStatusValue.Text = "Enabling device...";

            try
            {
                bool success = await Task.Run(() => _deviceService.EnableDevice(true));
                
                if (success)
                {
                    lblStatusValue.Text = "Device enabled successfully.";
                    XtraMessageBox.Show("Device enabled successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Update button states
                    btnEnableDevice.Enabled = false;
                    btnDisableDevice.Enabled = true;
                }
                else
                {
                    lblStatusValue.Text = "Failed to enable device.";
                    XtraMessageBox.Show("Failed to enable device.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEnableDevice.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error enabling device.";
                XtraMessageBox.Show($"Error enabling device: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEnableDevice.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnDisableDevice_Click(object sender, EventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnDisableDevice.Enabled = false;
            lblStatusValue.Text = "Disabling device...";

            try
            {
                bool success = await Task.Run(() => _deviceService.EnableDevice(false));
                
                if (success)
                {
                    lblStatusValue.Text = "Device disabled successfully.";
                    XtraMessageBox.Show("Device disabled successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Update button states
                    btnDisableDevice.Enabled = false;
                    btnEnableDevice.Enabled = true;
                }
                else
                {
                    lblStatusValue.Text = "Failed to disable device.";
                    XtraMessageBox.Show("Failed to disable device.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDisableDevice.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error disabling device.";
                XtraMessageBox.Show($"Error disabling device: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDisableDevice.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnClearData_Click(object sender, EventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Not connected to any device.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = XtraMessageBox.Show("Are you sure you want to clear all attendance data? This action cannot be undone.",
                "Confirm Data Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
            if (confirmResult != DialogResult.Yes)
                return;

            Cursor = Cursors.WaitCursor;
            btnClearData.Enabled = false;
            lblStatusValue.Text = "Clearing attendance data...";

            try
            {
                bool success = await Task.Run(() => _deviceService.ClearData());
                
                if (success)
                {
                    lblStatusValue.Text = "Attendance data cleared successfully.";
                    XtraMessageBox.Show("Attendance data cleared successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatusValue.Text = "Failed to clear attendance data.";
                    XtraMessageBox.Show("Failed to clear attendance data.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatusValue.Text = "Error clearing attendance data.";
                XtraMessageBox.Show($"Error clearing attendance data: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnClearData.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}