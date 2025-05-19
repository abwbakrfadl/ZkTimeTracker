using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Services;
using ZKTecoAttendanceSystem.Utils;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class MainForm : RibbonForm
    {
        private readonly DeviceService _deviceService;
        private readonly SettingsService _settingsService;
        private readonly UserService _userService;

        public MainForm()
        {
            InitializeComponent();
            
            _deviceService = new DeviceService();
            _settingsService = new SettingsService();
            _userService = new UserService();
            
            LoadLastConnectionSettings();
            UpdateConnectionStatus();
        }

        private void LoadLastConnectionSettings()
        {
            try
            {
                var settings = _settingsService.GetDeviceSettings();
                if (settings != null)
                {
                    _deviceService.DeviceIP = settings.IPAddress;
                    _deviceService.DevicePort = settings.Port;
                    lblConnectionInfo.Caption = $"Last connection: {settings.IPAddress}:{settings.Port}";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateConnectionStatus()
        {
            if (_deviceService.IsConnected)
            {
                lblStatus.Caption = "Status: Connected";
                lblStatus.Appearance.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Caption = "Status: Disconnected";
                lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnConnectionSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            var connectionForm = new ConnectionForm(_deviceService);
            if (connectionForm.ShowDialog() == DialogResult.OK)
            {
                UpdateConnectionStatus();
                LoadLastConnectionSettings();
            }
        }

        private void btnTimeSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckUserPermission(PermissionType.EditTimeSettings))
                return;
                
            var timeSettingsForm = new TimeSettingsForm(_settingsService);
            timeSettingsForm.ShowDialog();
        }

        private void btnDeviceManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Please connect to a device first.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var deviceManagementForm = new DeviceManagementForm(_deviceService);
            deviceManagementForm.ShowDialog();
        }

        private void btnAttendanceMonitor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!_deviceService.IsConnected)
            {
                XtraMessageBox.Show("Please connect to a device first.", "No Connection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var attendanceMonitorForm = new AttendanceMonitorForm(_deviceService, _settingsService);
            attendanceMonitorForm.ShowDialog();
        }

        private void btnDataStorage_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dataStorageForm = new DataStorageForm();
            dataStorageForm.ShowDialog();
        }

        private void btnPermissions_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckUserPermission(PermissionType.ManageUsers))
                return;
                
            var permissionsForm = new PermissionsForm(_userService);
            permissionsForm.ShowDialog();
        }
        
        private bool CheckUserPermission(PermissionType permission)
        {
            if (!_userService.CurrentUserHasPermission(permission))
            {
                XtraMessageBox.Show("You do not have permission to access this feature.", 
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_deviceService.IsConnected)
            {
                _deviceService.Disconnect();
            }
        }
    }
}