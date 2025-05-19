using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Services;
using ZKTecoAttendanceSystem.Utils;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class MainForm : XtraForm
    {
        private readonly DeviceService _deviceService;
        private readonly SettingsService _settingsService;
        private readonly UserService _userService;

        private bool _isConnected = false;

        public MainForm()
        {
            InitializeComponent();
            
            // Initialize services
            _deviceService = new DeviceService();
            _settingsService = new SettingsService();
            _userService = new UserService();
            
            // Show login form at startup
            ShowLoginForm();
            
            // Check if auto-connect is enabled
            var connectionSettings = _settingsService.GetConnectionSettings();
            if (connectionSettings != null && connectionSettings.AutoConnect)
            {
                ConnectToDevice(connectionSettings.IPAddress, connectionSettings.Port, connectionSettings.Password);
            }
            
            // Update UI based on user permissions
            UpdateUIBasedOnPermissions();
            
            // Update status
            UpdateStatusBar();
        }

        private void ShowLoginForm()
        {
            // Show login form
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                // If login is canceled or unsuccessful, exit the application
                Application.Exit();
                return;
            }
            
            // Update user information in the status bar
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            if (_userService.CurrentUser != null)
            {
                lblUserName.Text = $"User: {_userService.CurrentUser.Username}";
                lblUserRole.Text = _userService.CurrentUser.IsAdmin ? "Role: Administrator" : "Role: User";
            }
            else
            {
                lblUserName.Text = "User: Not logged in";
                lblUserRole.Text = "Role: None";
            }
        }

        private void UpdateUIBasedOnPermissions()
        {
            if (_userService.CurrentUser == null)
                return;

            var user = _userService.CurrentUser;
            
            // Update menu item visibility based on user permissions
            navBarItemUsers.Visible = user.IsAdmin || user.CanManageUsers;
            navBarItemTimeSettings.Visible = user.IsAdmin || user.CanEditTimeSettings;
            navBarItemDeviceManagement.Visible = user.IsAdmin || user.CanManageDevices;
            navBarItemAttendanceMonitor.Visible = user.IsAdmin || user.CanViewAttendance;
            navBarItemDataStorage.Visible = user.IsAdmin || user.CanViewReports;
            
            // Update buttons visibility based on user permissions
            btnConnect.Enabled = user.IsAdmin || user.CanManageDevices;
            btnDisconnect.Enabled = user.IsAdmin || user.CanManageDevices;
        }

        private void UpdateStatusBar()
        {
            lblConnectionStatus.Text = _isConnected ? "Connected to device" : "Not connected";
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ConnectToDevice(string ipAddress, int port, string password)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                statusStrip.Items[0].Text = "Connecting to device...";
                Application.DoEvents();

                bool success = _deviceService.Connect(ipAddress, port, password);
                
                _isConnected = success;
                
                if (success)
                {
                    statusStrip.Items[0].Text = "Connected to device successfully.";
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
                else
                {
                    statusStrip.Items[0].Text = "Failed to connect to device.";
                    XtraMessageBox.Show("Failed to connect to device. Please check your settings and try again.",
                        "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                statusStrip.Items[0].Text = "Error connecting to device.";
                XtraMessageBox.Show($"Error connecting to device: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                UpdateStatusBar();
            }
        }

        private void DisconnectFromDevice()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                statusStrip.Items[0].Text = "Disconnecting from device...";
                Application.DoEvents();

                bool success = _deviceService.Disconnect();
                
                _isConnected = !success;
                
                if (success)
                {
                    statusStrip.Items[0].Text = "Disconnected from device successfully.";
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                }
                else
                {
                    statusStrip.Items[0].Text = "Failed to disconnect from device.";
                    XtraMessageBox.Show("Failed to disconnect from device.",
                        "Disconnection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                statusStrip.Items[0].Text = "Error disconnecting from device.";
                XtraMessageBox.Show($"Error disconnecting from device: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                UpdateStatusBar();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectionForm connectionForm = new ConnectionForm(_deviceService);
            if (connectionForm.ShowDialog() == DialogResult.OK)
            {
                _isConnected = _deviceService.IsConnected;
                UpdateStatusBar();
                btnConnect.Enabled = !_isConnected;
                btnDisconnect.Enabled = _isConnected;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromDevice();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_deviceService.IsConnected)
            {
                var result = XtraMessageBox.Show("You are still connected to the device. Do you want to disconnect before exiting?",
                    "Confirm Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (result == DialogResult.Cancel)
                    return;
                
                if (result == DialogResult.Yes)
                    DisconnectFromDevice();
            }
            
            Application.Exit();
        }

        private void timerStatusUpdate_Tick(object sender, EventArgs e)
        {
            // Update status bar time
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_deviceService.IsConnected)
            {
                var result = XtraMessageBox.Show("You are still connected to the device. Do you want to disconnect before exiting?",
                    "Confirm Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                
                if (result == DialogResult.Yes)
                    DisconnectFromDevice();
            }
        }

        private void navBarItemUsers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Check permission
            if (!_userService.CurrentUser.CanManageUsers && !_userService.CurrentUser.IsAdmin)
            {
                XtraMessageBox.Show("You do not have permission to access this function.",
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Show user permissions form
            PermissionsForm permissionsForm = new PermissionsForm(_userService);
            permissionsForm.ShowDialog();
        }

        private void navBarItemTimeSettings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Check permission
            if (!_userService.CurrentUser.CanEditTimeSettings && !_userService.CurrentUser.IsAdmin)
            {
                XtraMessageBox.Show("You do not have permission to access this function.",
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Show time settings form
            TimeSettingsForm timeSettingsForm = new TimeSettingsForm(_settingsService);
            timeSettingsForm.ShowDialog();
        }

        private void navBarItemDeviceManagement_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Check permission
            if (!_userService.CurrentUser.CanManageDevices && !_userService.CurrentUser.IsAdmin)
            {
                XtraMessageBox.Show("You do not have permission to access this function.",
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check connection
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Please connect to a device first.",
                    "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Show device management form
            DeviceManagementForm deviceManagementForm = new DeviceManagementForm(_deviceService);
            deviceManagementForm.ShowDialog();
        }

        private void navBarItemAttendanceMonitor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Check permission
            if (!_userService.CurrentUser.CanViewAttendance && !_userService.CurrentUser.IsAdmin)
            {
                XtraMessageBox.Show("You do not have permission to access this function.",
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check connection
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Please connect to a device first.",
                    "No Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Show attendance monitor form
            AttendanceMonitorForm attendanceMonitorForm = new AttendanceMonitorForm(_deviceService, _settingsService);
            attendanceMonitorForm.ShowDialog();
        }

        private void navBarItemDataStorage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Check permission
            if (!_userService.CurrentUser.CanViewReports && !_userService.CurrentUser.IsAdmin)
            {
                XtraMessageBox.Show("You do not have permission to access this function.",
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Show data storage form
            DataStorageForm dataStorageForm = new DataStorageForm();
            dataStorageForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Confirm logout
            var result = XtraMessageBox.Show("Are you sure you want to log out?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.No)
                return;
            
            // Disconnect from device if connected
            if (_deviceService.IsConnected)
            {
                var disconnectResult = XtraMessageBox.Show("You are still connected to the device. Do you want to disconnect before logging out?",
                    "Device Connected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (disconnectResult == DialogResult.Yes)
                    DisconnectFromDevice();
            }
            
            // Clear current user
            _userService.Logout();
            
            // Show login form again
            ShowLoginForm();
            
            // Update UI
            UpdateUIBasedOnPermissions();
            UpdateStatusBar();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show(
                "ZKTeco Attendance System\n\n" +
                "Version: 1.0.0\n" +
                "Copyright © 2023\n\n" +
                "A management software for ZKTeco fingerprint devices.\n" +
                "Designed to configure attendance time periods and manage\n" +
                "attendance data with SQL Server integration.",
                "About ZKTeco Attendance System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}