using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class PermissionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gridUsers = new DevExpress.XtraGrid.GridControl();
            this.gridViewUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.chkManageUsers = new DevExpress.XtraEditors.CheckEdit();
            this.chkEditTimeSettings = new DevExpress.XtraEditors.CheckEdit();
            this.chkManageDevices = new DevExpress.XtraEditors.CheckEdit();
            this.chkViewReports = new DevExpress.XtraEditors.CheckEdit();
            this.chkViewAttendance = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnAddUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManageUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditTimeSettings.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManageDevices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewReports.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewAttendance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.gridUsers);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.groupControl2);
            this.layoutControl1.Controls.Add(this.btnAddUser);
            this.layoutControl1.Controls.Add(this.btnUpdateUser);
            this.layoutControl1.Controls.Add(this.btnDeleteUser);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(750, 600);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                this.layoutControlItem1,
                this.layoutControlItem2,
                this.layoutControlItem3,
                this.layoutControlItem4,
                this.layoutControlItem5,
                this.layoutControlItem6,
                this.layoutControlItem7,
                this.emptySpaceItem1
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(750, 600);
            this.Root.TextVisible = false;
            
            // gridUsers
            this.gridUsers.Location = new System.Drawing.Point(12, 250);
            this.gridUsers.MainView = this.gridViewUsers;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.Size = new System.Drawing.Size(726, 305);
            this.gridUsers.TabIndex = 4;
            this.gridUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.gridViewUsers
            });
            
            // gridViewUsers
            this.gridViewUsers.GridControl = this.gridUsers;
            this.gridViewUsers.Name = "gridViewUsers";
            this.gridViewUsers.OptionsBehavior.Editable = false;
            this.gridViewUsers.OptionsView.ShowGroupPanel = false;
            this.gridViewUsers.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewUsers_FocusedRowChanged);
            
            // layoutControlItem1
            this.layoutControlItem1.Control = this.gridUsers;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 238);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(730, 309);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            
            // groupControl1
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(726, 100);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "User Information";
            
            // layoutControl2
            this.layoutControl2.Controls.Add(this.txtUsername);
            this.layoutControl2.Controls.Add(this.txtPassword);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 23);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(722, 75);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            
            // layoutControlGroup1
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(722, 75);
            this.layoutControlGroup1.TextVisible = false;
            
            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(76, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(634, 20);
            this.txtUsername.StyleController = this.layoutControl2;
            this.txtUsername.TabIndex = 4;
            
            // Add Username to layout
            var layoutItemUsername = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemUsername.Control = this.txtUsername;
            layoutItemUsername.Location = new System.Drawing.Point(0, 0);
            layoutItemUsername.Name = "layoutItemUsername";
            layoutItemUsername.Size = new System.Drawing.Size(702, 24);
            layoutItemUsername.Text = "Username:";
            layoutItemUsername.TextSize = new System.Drawing.Size(61, 13);
            this.layoutControlGroup1.Items.Add(layoutItemUsername);
            
            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(76, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(634, 20);
            this.txtPassword.StyleController = this.layoutControl2;
            this.txtPassword.TabIndex = 5;
            
            // Add Password to layout
            var layoutItemPassword = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPassword.Control = this.txtPassword;
            layoutItemPassword.Location = new System.Drawing.Point(0, 24);
            layoutItemPassword.Name = "layoutItemPassword";
            layoutItemPassword.Size = new System.Drawing.Size(702, 24);
            layoutItemPassword.Text = "Password:";
            layoutItemPassword.TextSize = new System.Drawing.Size(61, 13);
            this.layoutControlGroup1.Items.Add(layoutItemPassword);
            
            // layoutControlItem2
            this.layoutControlItem2.Control = this.groupControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(730, 104);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            
            // groupControl2
            this.groupControl2.Controls.Add(this.layoutControl3);
            this.groupControl2.Location = new System.Drawing.Point(12, 116);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(726, 130);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Permissions";
            
            // layoutControl3
            this.layoutControl3.Controls.Add(this.chkManageUsers);
            this.layoutControl3.Controls.Add(this.chkEditTimeSettings);
            this.layoutControl3.Controls.Add(this.chkManageDevices);
            this.layoutControl3.Controls.Add(this.chkViewReports);
            this.layoutControl3.Controls.Add(this.chkViewAttendance);
            this.layoutControl3.Controls.Add(this.chkIsAdmin);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(2, 23);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(722, 105);
            this.layoutControl3.TabIndex = 0;
            this.layoutControl3.Text = "layoutControl3";
            
            // layoutControlGroup2
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(722, 105);
            this.layoutControlGroup2.TextVisible = false;
            
            // chkManageUsers
            this.chkManageUsers.Location = new System.Drawing.Point(12, 12);
            this.chkManageUsers.Name = "chkManageUsers";
            this.chkManageUsers.Properties.Caption = "Manage Users";
            this.chkManageUsers.Size = new System.Drawing.Size(345, 20);
            this.chkManageUsers.StyleController = this.layoutControl3;
            this.chkManageUsers.TabIndex = 4;
            
            // Add Manage Users checkbox to layout
            var layoutItemManageUsers = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemManageUsers.Control = this.chkManageUsers;
            layoutItemManageUsers.Location = new System.Drawing.Point(0, 0);
            layoutItemManageUsers.Name = "layoutItemManageUsers";
            layoutItemManageUsers.Size = new System.Drawing.Size(349, 24);
            layoutItemManageUsers.TextSize = new System.Drawing.Size(0, 0);
            layoutItemManageUsers.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemManageUsers);
            
            // chkEditTimeSettings
            this.chkEditTimeSettings.Location = new System.Drawing.Point(12, 36);
            this.chkEditTimeSettings.Name = "chkEditTimeSettings";
            this.chkEditTimeSettings.Properties.Caption = "Edit Time Settings";
            this.chkEditTimeSettings.Size = new System.Drawing.Size(345, 20);
            this.chkEditTimeSettings.StyleController = this.layoutControl3;
            this.chkEditTimeSettings.TabIndex = 5;
            
            // Add Edit Time Settings checkbox to layout
            var layoutItemEditTimeSettings = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemEditTimeSettings.Control = this.chkEditTimeSettings;
            layoutItemEditTimeSettings.Location = new System.Drawing.Point(0, 24);
            layoutItemEditTimeSettings.Name = "layoutItemEditTimeSettings";
            layoutItemEditTimeSettings.Size = new System.Drawing.Size(349, 24);
            layoutItemEditTimeSettings.TextSize = new System.Drawing.Size(0, 0);
            layoutItemEditTimeSettings.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemEditTimeSettings);
            
            // chkManageDevices
            this.chkManageDevices.Location = new System.Drawing.Point(12, 60);
            this.chkManageDevices.Name = "chkManageDevices";
            this.chkManageDevices.Properties.Caption = "Manage Devices";
            this.chkManageDevices.Size = new System.Drawing.Size(345, 20);
            this.chkManageDevices.StyleController = this.layoutControl3;
            this.chkManageDevices.TabIndex = 6;
            
            // Add Manage Devices checkbox to layout
            var layoutItemManageDevices = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemManageDevices.Control = this.chkManageDevices;
            layoutItemManageDevices.Location = new System.Drawing.Point(0, 48);
            layoutItemManageDevices.Name = "layoutItemManageDevices";
            layoutItemManageDevices.Size = new System.Drawing.Size(349, 24);
            layoutItemManageDevices.TextSize = new System.Drawing.Size(0, 0);
            layoutItemManageDevices.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemManageDevices);
            
            // chkViewReports
            this.chkViewReports.Location = new System.Drawing.Point(361, 12);
            this.chkViewReports.Name = "chkViewReports";
            this.chkViewReports.Properties.Caption = "View Reports";
            this.chkViewReports.Size = new System.Drawing.Size(349, 20);
            this.chkViewReports.StyleController = this.layoutControl3;
            this.chkViewReports.TabIndex = 7;
            
            // Add View Reports checkbox to layout
            var layoutItemViewReports = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemViewReports.Control = this.chkViewReports;
            layoutItemViewReports.Location = new System.Drawing.Point(349, 0);
            layoutItemViewReports.Name = "layoutItemViewReports";
            layoutItemViewReports.Size = new System.Drawing.Size(353, 24);
            layoutItemViewReports.TextSize = new System.Drawing.Size(0, 0);
            layoutItemViewReports.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemViewReports);
            
            // chkViewAttendance
            this.chkViewAttendance.Location = new System.Drawing.Point(361, 36);
            this.chkViewAttendance.Name = "chkViewAttendance";
            this.chkViewAttendance.Properties.Caption = "View Attendance";
            this.chkViewAttendance.Size = new System.Drawing.Size(349, 20);
            this.chkViewAttendance.StyleController = this.layoutControl3;
            this.chkViewAttendance.TabIndex = 8;
            
            // Add View Attendance checkbox to layout
            var layoutItemViewAttendance = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemViewAttendance.Control = this.chkViewAttendance;
            layoutItemViewAttendance.Location = new System.Drawing.Point(349, 24);
            layoutItemViewAttendance.Name = "layoutItemViewAttendance";
            layoutItemViewAttendance.Size = new System.Drawing.Size(353, 24);
            layoutItemViewAttendance.TextSize = new System.Drawing.Size(0, 0);
            layoutItemViewAttendance.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemViewAttendance);
            
            // chkIsAdmin
            this.chkIsAdmin.Location = new System.Drawing.Point(361, 60);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Properties.Caption = "Administrator (All Permissions)";
            this.chkIsAdmin.Size = new System.Drawing.Size(349, 20);
            this.chkIsAdmin.StyleController = this.layoutControl3;
            this.chkIsAdmin.TabIndex = 9;
            this.chkIsAdmin.CheckedChanged += new System.EventHandler(this.chkIsAdmin_CheckedChanged);
            
            // Add Is Admin checkbox to layout
            var layoutItemIsAdmin = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemIsAdmin.Control = this.chkIsAdmin;
            layoutItemIsAdmin.Location = new System.Drawing.Point(349, 48);
            layoutItemIsAdmin.Name = "layoutItemIsAdmin";
            layoutItemIsAdmin.Size = new System.Drawing.Size(353, 24);
            layoutItemIsAdmin.TextSize = new System.Drawing.Size(0, 0);
            layoutItemIsAdmin.TextVisible = false;
            this.layoutControlGroup2.Items.Add(layoutItemIsAdmin);
            
            // Add empty space for layout
            var emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new System.Drawing.Point(0, 72);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new System.Drawing.Size(702, 13);
            emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup2.Items.Add(emptySpaceItem2);
            
            // layoutControlItem3
            this.layoutControlItem3.Control = this.groupControl2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(730, 134);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            
            // btnAddUser
            this.btnAddUser.Location = new System.Drawing.Point(12, 559);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(160, 22);
            this.btnAddUser.StyleController = this.layoutControl1;
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            
            // layoutControlItem4
            this.layoutControlItem4.Control = this.btnAddUser;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 547);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(164, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            
            // btnUpdateUser
            this.btnUpdateUser.Location = new System.Drawing.Point(176, 559);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(160, 22);
            this.btnUpdateUser.StyleController = this.layoutControl1;
            this.btnUpdateUser.TabIndex = 8;
            this.btnUpdateUser.Text = "Update User";
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            
            // layoutControlItem5
            this.layoutControlItem5.Control = this.btnUpdateUser;
            this.layoutControlItem5.Location = new System.Drawing.Point(164, 547);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(164, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            
            // btnDeleteUser
            this.btnDeleteUser.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteUser.Appearance.Options.UseBackColor = true;
            this.btnDeleteUser.Location = new System.Drawing.Point(340, 559);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(160, 22);
            this.btnDeleteUser.StyleController = this.layoutControl1;
            this.btnDeleteUser.TabIndex = 9;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            
            // layoutControlItem6
            this.layoutControlItem6.Control = this.btnDeleteUser;
            this.layoutControlItem6.Location = new System.Drawing.Point(328, 547);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(164, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            
            // btnClose
            this.btnClose.Location = new System.Drawing.Point(577, 559);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 22);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            
            // layoutControlItem7
            this.layoutControlItem7.Control = this.btnClose;
            this.layoutControlItem7.Location = new System.Drawing.Point(565, 547);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(165, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            
            // emptySpaceItem1
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(492, 547);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(73, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            
            // PermissionsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 600);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PermissionsForm";
            this.Text = "User Permissions";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManageUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditTimeSettings.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkManageDevices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewReports.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewAttendance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gridUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUsers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.CheckEdit chkManageUsers;
        private DevExpress.XtraEditors.CheckEdit chkEditTimeSettings;
        private DevExpress.XtraEditors.CheckEdit chkManageDevices;
        private DevExpress.XtraEditors.CheckEdit chkViewReports;
        private DevExpress.XtraEditors.CheckEdit chkViewAttendance;
        private DevExpress.XtraEditors.CheckEdit chkIsAdmin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnAddUser;
        private DevExpress.XtraEditors.SimpleButton btnUpdateUser;
        private DevExpress.XtraEditors.SimpleButton btnDeleteUser;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}