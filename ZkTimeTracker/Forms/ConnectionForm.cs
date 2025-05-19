using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Models;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class ConnectionForm : XtraForm
    {
        private readonly DeviceService _deviceService;
        private readonly SettingsService _settingsService;

        public ConnectionForm(DeviceService deviceService)
        {
            InitializeComponent();
            
            _deviceService = deviceService;
            _settingsService = new SettingsService();
            
            LoadSavedSettings();
        }

        private void LoadSavedSettings()
        {
            try
            {
                var settings = _settingsService.GetDeviceSettings();
                if (settings != null)
                {
                    txtIPAddress.Text = settings.IPAddress;
                    txtPort.Text = settings.Port.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIPAddress.Text) || string.IsNullOrWhiteSpace(txtPort.Text))
            {
                XtraMessageBox.Show("Please enter IP address and port.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port))
            {
                XtraMessageBox.Show("Port must be a valid number.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            btnTestConnection.Enabled = false;
            lblConnectionStatus.Text = "Testing connection...";
            lblConnectionStatus.ForeColor = System.Drawing.Color.Blue;
            
            try
            {
                bool connected = _deviceService.Connect(txtIPAddress.Text, port);
                
                if (connected)
                {
                    lblConnectionStatus.Text = "Connection successful!";
                    lblConnectionStatus.ForeColor = System.Drawing.Color.Green;
                    
                    // Keep connected for use in the main form
                }
                else
                {
                    lblConnectionStatus.Text = "Connection failed!";
                    lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblConnectionStatus.Text = "Connection error!";
                lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
                XtraMessageBox.Show($"Error connecting to device: {ex.Message}", "Connection Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnTestConnection.Enabled = true;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIPAddress.Text) || string.IsNullOrWhiteSpace(txtPort.Text))
            {
                XtraMessageBox.Show("Please enter IP address and port.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPort.Text, out int port))
            {
                XtraMessageBox.Show("Port must be a valid number.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var settings = new DeviceSettings
                {
                    IPAddress = txtIPAddress.Text,
                    Port = port
                };
                
                _settingsService.SaveDeviceSettings(settings);
                
                XtraMessageBox.Show("Settings saved successfully.", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error saving settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}