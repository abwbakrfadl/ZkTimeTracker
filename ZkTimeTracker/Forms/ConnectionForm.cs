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
        private ConnectionSettings _connectionSettings;

        public ConnectionForm(DeviceService deviceService)
        {
            InitializeComponent();
            
            _deviceService = deviceService;
            
            // Load saved connection settings
            LoadConnectionSettings();
        }

        private void LoadConnectionSettings()
        {
            try
            {
                var settingsService = new SettingsService();
                _connectionSettings = settingsService.GetConnectionSettings();
                
                if (_connectionSettings != null)
                {
                    txtIPAddress.Text = _connectionSettings.IPAddress;
                    txtPort.Text = _connectionSettings.Port.ToString();
                    txtPassword.Text = _connectionSettings.Password;
                    chkAutoConnect.Checked = _connectionSettings.AutoConnect;
                }
                else
                {
                    // Default settings
                    txtIPAddress.Text = "192.168.1.201";
                    txtPort.Text = "4370";
                    txtPassword.Text = "";
                    chkAutoConnect.Checked = false;
                    
                    _connectionSettings = new ConnectionSettings
                    {
                        IPAddress = txtIPAddress.Text,
                        Port = int.Parse(txtPort.Text),
                        Password = txtPassword.Text,
                        AutoConnect = chkAutoConnect.Checked
                    };
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading connection settings: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
            {
                XtraMessageBox.Show("Please enter the device IP address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPort.Text) || !int.TryParse(txtPort.Text, out _))
            {
                XtraMessageBox.Show("Please enter a valid port number.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Update connection settings
                _connectionSettings.IPAddress = txtIPAddress.Text;
                _connectionSettings.Port = int.Parse(txtPort.Text);
                _connectionSettings.Password = txtPassword.Text;
                _connectionSettings.AutoConnect = chkAutoConnect.Checked;

                // Save settings
                var settingsService = new SettingsService();
                settingsService.SaveConnectionSettings(_connectionSettings);

                // Connect to device
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Connecting to device...";
                Application.DoEvents();

                bool connected = _deviceService.Connect(
                    _connectionSettings.IPAddress, 
                    _connectionSettings.Port, 
                    _connectionSettings.Password);

                if (connected)
                {
                    lblStatus.Text = "Connected successfully.";
                    XtraMessageBox.Show("Connected to device successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblStatus.Text = "Failed to connect to device.";
                    XtraMessageBox.Show("Failed to connect to device. Please check your settings and try again.", 
                        "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error connecting to device.";
                XtraMessageBox.Show($"Error connecting to device: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIPAddress.Text))
            {
                XtraMessageBox.Show("Please enter the device IP address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPort.Text) || !int.TryParse(txtPort.Text, out _))
            {
                XtraMessageBox.Show("Please enter a valid port number.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Test connection
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Testing connection...";
                Application.DoEvents();

                bool connected = _deviceService.TestConnection(
                    txtIPAddress.Text, 
                    int.Parse(txtPort.Text), 
                    txtPassword.Text);

                if (connected)
                {
                    lblStatus.Text = "Connection test successful.";
                    XtraMessageBox.Show("Connection test successful.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Connection test failed.";
                    XtraMessageBox.Show("Connection test failed. Please check your settings and try again.", 
                        "Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error testing connection.";
                XtraMessageBox.Show($"Error testing connection: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Scanning network for devices...";
                Application.DoEvents();

                var deviceList = _deviceService.ScanNetwork();

                if (deviceList.Count > 0)
                {
                    lblStatus.Text = $"Found {deviceList.Count} devices on the network.";
                    
                    // Show device selection form
                    var deviceSelectionForm = new DeviceSelectionForm(deviceList);
                    if (deviceSelectionForm.ShowDialog() == DialogResult.OK)
                    {
                        var selectedDevice = deviceSelectionForm.SelectedDevice;
                        if (selectedDevice != null)
                        {
                            txtIPAddress.Text = selectedDevice.IPAddress;
                            txtPort.Text = selectedDevice.Port.ToString();
                        }
                    }
                }
                else
                {
                    lblStatus.Text = "No devices found on the network.";
                    XtraMessageBox.Show("No devices found on the network.", "Scan Results", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error scanning network.";
                XtraMessageBox.Show($"Error scanning network: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }

    // Nested class for device selection
    public class DeviceSelectionForm : XtraForm
    {
        private ComboBoxEdit comboBoxDevices;
        private SimpleButton btnSelect;
        private SimpleButton btnCancel;
        private LayoutControl layoutControl1;
        private LayoutControlGroup Root;

        private readonly List<DeviceInfo> _deviceList;
        public DeviceInfo SelectedDevice { get; private set; }

        public DeviceSelectionForm(List<DeviceInfo> deviceList)
        {
            InitializeComponent();
            _deviceList = deviceList;
            
            // Populate the combobox with device information
            foreach (var device in _deviceList)
            {
                comboBoxDevices.Properties.Items.Add($"{device.IPAddress}:{device.Port} - {device.DeviceName}");
            }
            
            if (comboBoxDevices.Properties.Items.Count > 0)
            {
                comboBoxDevices.SelectedIndex = 0;
            }
        }

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.comboBoxDevices = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDevices.Properties)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.comboBoxDevices);
            this.layoutControl1.Controls.Add(this.btnSelect);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(400, 120);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(400, 120);
            this.Root.TextVisible = false;
            
            // comboBoxDevices
            this.comboBoxDevices.Location = new System.Drawing.Point(101, 12);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            this.comboBoxDevices.Size = new System.Drawing.Size(287, 20);
            this.comboBoxDevices.StyleController = this.layoutControl1;
            this.comboBoxDevices.TabIndex = 4;
            
            // Add device combobox to layout
            var layoutItemDevices = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemDevices.Control = this.comboBoxDevices;
            layoutItemDevices.Location = new System.Drawing.Point(0, 0);
            layoutItemDevices.Name = "layoutItemDevices";
            layoutItemDevices.Size = new System.Drawing.Size(380, 24);
            layoutItemDevices.Text = "Select Device:";
            layoutItemDevices.TextSize = new System.Drawing.Size(85, 13);
            this.Root.Items.Add(layoutItemDevices);
            
            // btnSelect
            this.btnSelect.Location = new System.Drawing.Point(12, 36);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(185, 22);
            this.btnSelect.StyleController = this.layoutControl1;
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            
            // Add Select button to layout
            var layoutItemSelect = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemSelect.Control = this.btnSelect;
            layoutItemSelect.Location = new System.Drawing.Point(0, 24);
            layoutItemSelect.Name = "layoutItemSelect";
            layoutItemSelect.Size = new System.Drawing.Size(189, 26);
            layoutItemSelect.TextSize = new System.Drawing.Size(0, 0);
            layoutItemSelect.TextVisible = false;
            this.Root.Items.Add(layoutItemSelect);
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(201, 36);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(187, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // Add Cancel button to layout
            var layoutItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCancel.Control = this.btnCancel;
            layoutItemCancel.Location = new System.Drawing.Point(189, 24);
            layoutItemCancel.Name = "layoutItemCancel";
            layoutItemCancel.Size = new System.Drawing.Size(191, 26);
            layoutItemCancel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemCancel.TextVisible = false;
            this.Root.Items.Add(layoutItemCancel);
            
            // Add empty space
            var emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem.AllowHotTrack = false;
            emptySpaceItem.Location = new System.Drawing.Point(0, 50);
            emptySpaceItem.Name = "emptySpaceItem";
            emptySpaceItem.Size = new System.Drawing.Size(380, 50);
            emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            this.Root.Items.Add(emptySpaceItem);
            
            // DeviceSelectionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 120);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Device";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDevices.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (comboBoxDevices.SelectedIndex >= 0 && comboBoxDevices.SelectedIndex < _deviceList.Count)
            {
                SelectedDevice = _deviceList[comboBoxDevices.SelectedIndex];
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                XtraMessageBox.Show("Please select a device from the list.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}