using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ZKTecoAttendanceSystem.Services;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class LoginForm : XtraForm
    {
        private readonly UserService _userService;
        private int _failedAttempts = 0;
        private const int MaxFailedAttempts = 5;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
            
            // Check if we have any users in the system
            if (!_userService.HasAnyUsers())
            {
                var result = XtraMessageBox.Show(
                    "No users found in the system. Would you like to create an administrator account?",
                    "First Time Setup",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // Show admin creation form
                    var createAdminForm = new CreateAdminForm();
                    if (createAdminForm.ShowDialog() == DialogResult.OK)
                    {
                        XtraMessageBox.Show(
                            "Administrator account created successfully. Please log in with your new credentials.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show("Please enter both username and password.", "Login Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check if max failed attempts reached
                if (_failedAttempts >= MaxFailedAttempts)
                {
                    XtraMessageBox.Show(
                        "Maximum login attempts reached. Please try again later.",
                        "Account Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                // Perform login
                var loginSuccess = _userService.Login(txtUsername.Text, txtPassword.Text);
                
                if (loginSuccess)
                {
                    // Login successful
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    // Login failed
                    _failedAttempts++;
                    int remainingAttempts = MaxFailedAttempts - _failedAttempts;
                    
                    XtraMessageBox.Show(
                        $"Invalid username or password. You have {remainingAttempts} attempts remaining.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Login error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }

    // Nested class for creating admin account
    public class CreateAdminForm : XtraForm
    {
        private TextEdit txtUsername;
        private TextEdit txtPassword;
        private TextEdit txtConfirmPassword;
        private SimpleButton btnCreate;
        private SimpleButton btnCancel;
        private LayoutControl layoutControl1;
        private LayoutControlGroup Root;

        public CreateAdminForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.txtUsername);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.txtConfirmPassword);
            this.layoutControl1.Controls.Add(this.btnCreate);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(400, 180);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(400, 180);
            this.Root.TextVisible = false;
            
            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(116, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(272, 20);
            this.txtUsername.StyleController = this.layoutControl1;
            this.txtUsername.TabIndex = 4;
            
            // Add Username to layout
            var layoutItemUsername = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemUsername.Control = this.txtUsername;
            layoutItemUsername.Location = new System.Drawing.Point(0, 0);
            layoutItemUsername.Name = "layoutItemUsername";
            layoutItemUsername.Size = new System.Drawing.Size(380, 24);
            layoutItemUsername.Text = "Username:";
            layoutItemUsername.TextSize = new System.Drawing.Size(101, 13);
            this.Root.Items.Add(layoutItemUsername);
            
            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(116, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(272, 20);
            this.txtPassword.StyleController = this.layoutControl1;
            this.txtPassword.TabIndex = 5;
            
            // Add Password to layout
            var layoutItemPassword = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPassword.Control = this.txtPassword;
            layoutItemPassword.Location = new System.Drawing.Point(0, 24);
            layoutItemPassword.Name = "layoutItemPassword";
            layoutItemPassword.Size = new System.Drawing.Size(380, 24);
            layoutItemPassword.Text = "Password:";
            layoutItemPassword.TextSize = new System.Drawing.Size(101, 13);
            this.Root.Items.Add(layoutItemPassword);
            
            // txtConfirmPassword
            this.txtConfirmPassword.Location = new System.Drawing.Point(116, 60);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.PasswordChar = '*';
            this.txtConfirmPassword.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(272, 20);
            this.txtConfirmPassword.StyleController = this.layoutControl1;
            this.txtConfirmPassword.TabIndex = 6;
            
            // Add Confirm Password to layout
            var layoutItemConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemConfirmPassword.Control = this.txtConfirmPassword;
            layoutItemConfirmPassword.Location = new System.Drawing.Point(0, 48);
            layoutItemConfirmPassword.Name = "layoutItemConfirmPassword";
            layoutItemConfirmPassword.Size = new System.Drawing.Size(380, 24);
            layoutItemConfirmPassword.Text = "Confirm Password:";
            layoutItemConfirmPassword.TextSize = new System.Drawing.Size(101, 13);
            this.Root.Items.Add(layoutItemConfirmPassword);
            
            // btnCreate
            this.btnCreate.Location = new System.Drawing.Point(12, 84);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(185, 22);
            this.btnCreate.StyleController = this.layoutControl1;
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create Administrator";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            
            // Add Create button to layout
            var layoutItemCreate = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCreate.Control = this.btnCreate;
            layoutItemCreate.Location = new System.Drawing.Point(0, 72);
            layoutItemCreate.Name = "layoutItemCreate";
            layoutItemCreate.Size = new System.Drawing.Size(189, 26);
            layoutItemCreate.TextSize = new System.Drawing.Size(0, 0);
            layoutItemCreate.TextVisible = false;
            this.Root.Items.Add(layoutItemCreate);
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(201, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(187, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // Add Cancel button to layout
            var layoutItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemCancel.Control = this.btnCancel;
            layoutItemCancel.Location = new System.Drawing.Point(189, 72);
            layoutItemCancel.Name = "layoutItemCancel";
            layoutItemCancel.Size = new System.Drawing.Size(191, 26);
            layoutItemCancel.TextSize = new System.Drawing.Size(0, 0);
            layoutItemCancel.TextVisible = false;
            this.Root.Items.Add(layoutItemCancel);
            
            // Add empty space item
            var emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem.AllowHotTrack = false;
            emptySpaceItem.Location = new System.Drawing.Point(0, 98);
            emptySpaceItem.Name = "emptySpaceItem";
            emptySpaceItem.Size = new System.Drawing.Size(380, 62);
            emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            this.Root.Items.Add(emptySpaceItem);
            
            // CreateAdminForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Administrator Account";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                XtraMessageBox.Show("Username cannot be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                XtraMessageBox.Show("Password fields cannot be empty.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                XtraMessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create admin user
                var userService = new UserService();
                var adminUser = new Models.User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    IsAdmin = true,
                    CanEditTimeSettings = true,
                    CanManageDevices = true,
                    CanManageUsers = true,
                    CanViewAttendance = true,
                    CanViewReports = true
                };

                userService.AddUser(adminUser);
                
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error creating admin account: {ex.Message}", "Error",
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