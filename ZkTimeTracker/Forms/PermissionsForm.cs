using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ZKTecoAttendanceSystem.Models;
using ZKTecoAttendanceSystem.Services;
using ZKTecoAttendanceSystem.Utils;

namespace ZKTecoAttendanceSystem.Forms
{
    public partial class PermissionsForm : XtraForm
    {
        private readonly UserService _userService;
        private List<User> _users;

        public PermissionsForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            _users = new List<User>();
            
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                _users = _userService.GetAllUsers();
                gridUsers.DataSource = _users;
                gridUsers.RefreshDataSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading users: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                XtraMessageBox.Show("Username cannot be empty.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                XtraMessageBox.Show("Password cannot be empty.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Check if username already exists
                if (_userService.UserExists(txtUsername.Text))
                {
                    XtraMessageBox.Show("Username already exists.", "Duplicate User", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create user with permissions
                var user = new User
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    CanManageUsers = chkManageUsers.Checked,
                    CanEditTimeSettings = chkEditTimeSettings.Checked,
                    CanManageDevices = chkManageDevices.Checked,
                    CanViewReports = chkViewReports.Checked,
                    CanViewAttendance = chkViewAttendance.Checked,
                    IsAdmin = chkIsAdmin.Checked
                };

                _userService.AddUser(user);
                
                XtraMessageBox.Show("User added successfully.", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Reset form fields
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkManageUsers.Checked = false;
                chkEditTimeSettings.Checked = false;
                chkManageDevices.Checked = false;
                chkViewReports.Checked = false;
                chkViewAttendance.Checked = false;
                chkIsAdmin.Checked = false;
                
                // Refresh grid
                LoadUsers();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error adding user: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (gridViewUsers.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Please select a user to update.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRowHandle = gridViewUsers.GetSelectedRows()[0];
            if (selectedRowHandle < 0)
                return;

            var selectedUser = gridViewUsers.GetRow(selectedRowHandle) as User;
            if (selectedUser == null)
                return;

            // Update user permissions based on checkboxes
            selectedUser.CanManageUsers = chkManageUsers.Checked;
            selectedUser.CanEditTimeSettings = chkEditTimeSettings.Checked;
            selectedUser.CanManageDevices = chkManageDevices.Checked;
            selectedUser.CanViewReports = chkViewReports.Checked;
            selectedUser.CanViewAttendance = chkViewAttendance.Checked;
            selectedUser.IsAdmin = chkIsAdmin.Checked;

            // Update password if provided
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                selectedUser.Password = txtPassword.Text;
            }

            try
            {
                _userService.UpdateUser(selectedUser);
                
                XtraMessageBox.Show("User updated successfully.", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Reset form fields
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkManageUsers.Checked = false;
                chkEditTimeSettings.Checked = false;
                chkManageDevices.Checked = false;
                chkViewReports.Checked = false;
                chkViewAttendance.Checked = false;
                chkIsAdmin.Checked = false;
                
                // Refresh grid
                LoadUsers();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error updating user: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (gridViewUsers.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Please select a user to delete.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRowHandle = gridViewUsers.GetSelectedRows()[0];
            if (selectedRowHandle < 0)
                return;

            var selectedUser = gridViewUsers.GetRow(selectedRowHandle) as User;
            if (selectedUser == null)
                return;

            // Don't allow deletion of the current user or admin if not an admin
            if (selectedUser.Username == _userService.CurrentUser.Username)
            {
                XtraMessageBox.Show("You cannot delete your own account.", "Operation Not Allowed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Don't allow deletion of admin users if not an admin
            if (selectedUser.IsAdmin && !_userService.CurrentUser.IsAdmin)
            {
                XtraMessageBox.Show("You need to be an administrator to delete admin accounts.", 
                    "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm deletion
            var result = XtraMessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?", 
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.DeleteUser(selectedUser.Id);
                    
                    XtraMessageBox.Show("User deleted successfully.", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Refresh grid
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error deleting user: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridViewUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                var selectedUser = gridViewUsers.GetRow(e.FocusedRowHandle) as User;
                if (selectedUser != null)
                {
                    // Populate form fields with selected user's data
                    txtUsername.Text = selectedUser.Username;
                    txtPassword.Text = string.Empty; // Don't show the password
                    chkManageUsers.Checked = selectedUser.CanManageUsers;
                    chkEditTimeSettings.Checked = selectedUser.CanEditTimeSettings;
                    chkManageDevices.Checked = selectedUser.CanManageDevices;
                    chkViewReports.Checked = selectedUser.CanViewReports;
                    chkViewAttendance.Checked = selectedUser.CanViewAttendance;
                    chkIsAdmin.Checked = selectedUser.IsAdmin;
                }
            }
        }

        private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            // If admin is checked, enable all permissions
            if (chkIsAdmin.Checked)
            {
                chkManageUsers.Checked = true;
                chkEditTimeSettings.Checked = true;
                chkManageDevices.Checked = true;
                chkViewReports.Checked = true;
                chkViewAttendance.Checked = true;
                
                // Disable individual checkboxes as admin has all permissions
                chkManageUsers.Enabled = false;
                chkEditTimeSettings.Enabled = false;
                chkManageDevices.Enabled = false;
                chkViewReports.Enabled = false;
                chkViewAttendance.Enabled = false;
            }
            else
            {
                // Re-enable individual checkboxes when admin is unchecked
                chkManageUsers.Enabled = true;
                chkEditTimeSettings.Enabled = true;
                chkManageDevices.Enabled = true;
                chkViewReports.Enabled = true;
                chkViewAttendance.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}