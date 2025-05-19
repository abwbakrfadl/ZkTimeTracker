using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ZKTecoAttendanceSystem.Forms
{
    partial class ConnectionForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtIPAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.chkAutoConnect = new DevExpress.XtraEditors.CheckEdit();
            this.btnScan = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoConnect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.btnConnect);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnTestConnection);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(450, 300);
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
                this.emptySpaceItem1,
                this.layoutControlItem5
            });
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(450, 300);
            this.Root.TextVisible = false;
            
            // groupControl1
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(426, 188);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Connection Settings";
            
            // layoutControl2
            this.layoutControl2.Controls.Add(this.txtIPAddress);
            this.layoutControl2.Controls.Add(this.txtPort);
            this.layoutControl2.Controls.Add(this.txtPassword);
            this.layoutControl2.Controls.Add(this.chkAutoConnect);
            this.layoutControl2.Controls.Add(this.btnScan);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 23);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(422, 163);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            
            // layoutControlGroup1
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(422, 163);
            this.layoutControlGroup1.TextVisible = false;
            
            // txtIPAddress
            this.txtIPAddress.Location = new System.Drawing.Point(99, 12);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(217, 20);
            this.txtIPAddress.StyleController = this.layoutControl2;
            this.txtIPAddress.TabIndex = 4;
            
            // Add IP Address to layout
            var layoutItemIPAddress = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemIPAddress.Control = this.txtIPAddress;
            layoutItemIPAddress.Location = new System.Drawing.Point(0, 0);
            layoutItemIPAddress.Name = "layoutItemIPAddress";
            layoutItemIPAddress.Size = new System.Drawing.Size(308, 24);
            layoutItemIPAddress.Text = "IP Address:";
            layoutItemIPAddress.TextSize = new System.Drawing.Size(83, 13);
            this.layoutControlGroup1.Items.Add(layoutItemIPAddress);
            
            // txtPort
            this.txtPort.Location = new System.Drawing.Point(99, 36);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(311, 20);
            this.txtPort.StyleController = this.layoutControl2;
            this.txtPort.TabIndex = 5;
            
            // Add Port to layout
            var layoutItemPort = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPort.Control = this.txtPort;
            layoutItemPort.Location = new System.Drawing.Point(0, 24);
            layoutItemPort.Name = "layoutItemPort";
            layoutItemPort.Size = new System.Drawing.Size(402, 24);
            layoutItemPort.Text = "Port:";
            layoutItemPort.TextSize = new System.Drawing.Size(83, 13);
            this.layoutControlGroup1.Items.Add(layoutItemPort);
            
            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(99, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(311, 20);
            this.txtPassword.StyleController = this.layoutControl2;
            this.txtPassword.TabIndex = 6;
            
            // Add Password to layout
            var layoutItemPassword = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPassword.Control = this.txtPassword;
            layoutItemPassword.Location = new System.Drawing.Point(0, 48);
            layoutItemPassword.Name = "layoutItemPassword";
            layoutItemPassword.Size = new System.Drawing.Size(402, 24);
            layoutItemPassword.Text = "Password:";
            layoutItemPassword.TextSize = new System.Drawing.Size(83, 13);
            this.layoutControlGroup1.Items.Add(layoutItemPassword);
            
            // chkAutoConnect
            this.chkAutoConnect.Location = new System.Drawing.Point(12, 84);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Properties.Caption = "Auto-connect when application starts";
            this.chkAutoConnect.Size = new System.Drawing.Size(398, 20);
            this.chkAutoConnect.StyleController = this.layoutControl2;
            this.chkAutoConnect.TabIndex = 7;
            
            // Add Auto-connect checkbox to layout
            var layoutItemAutoConnect = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemAutoConnect.Control = this.chkAutoConnect;
            layoutItemAutoConnect.Location = new System.Drawing.Point(0, 72);
            layoutItemAutoConnect.Name = "layoutItemAutoConnect";
            layoutItemAutoConnect.Size = new System.Drawing.Size(402, 24);
            layoutItemAutoConnect.TextSize = new System.Drawing.Size(0, 0);
            layoutItemAutoConnect.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemAutoConnect);
            
            // btnScan
            this.btnScan.Location = new System.Drawing.Point(320, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(90, 22);
            this.btnScan.StyleController = this.layoutControl2;
            this.btnScan.TabIndex = 8;
            this.btnScan.Text = "Scan Network";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            
            // Add Scan button to layout
            var layoutItemScan = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemScan.Control = this.btnScan;
            layoutItemScan.Location = new System.Drawing.Point(308, 0);
            layoutItemScan.Name = "layoutItemScan";
            layoutItemScan.Size = new System.Drawing.Size(94, 24);
            layoutItemScan.TextSize = new System.Drawing.Size(0, 0);
            layoutItemScan.TextVisible = false;
            this.layoutControlGroup1.Items.Add(layoutItemScan);
            
            // Add empty space
            var emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem2.AllowHotTrack = false;
            emptySpaceItem2.Location = new System.Drawing.Point(0, 96);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new System.Drawing.Size(402, 47);
            emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlGroup1.Items.Add(emptySpaceItem2);
            
            // layoutControlItem1
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(430, 192);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            
            // btnConnect
            this.btnConnect.Location = new System.Drawing.Point(12, 204);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 22);
            this.btnConnect.StyleController = this.layoutControl1;
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            
            // layoutControlItem2
            this.layoutControlItem2.Control = this.btnConnect;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(145, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(297, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // layoutControlItem3
            this.layoutControlItem3.Control = this.btnCancel;
            this.layoutControlItem3.Location = new System.Drawing.Point(285, 192);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(145, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            
            // btnTestConnection
            this.btnTestConnection.Location = new System.Drawing.Point(157, 204);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(136, 22);
            this.btnTestConnection.StyleController = this.layoutControl1;
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            
            // layoutControlItem4
            this.layoutControlItem4.Control = this.btnTestConnection;
            this.layoutControlItem4.Location = new System.Drawing.Point(145, 192);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(140, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            
            // lblStatus
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 230);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(426, 13);
            this.lblStatus.StyleController = this.layoutControl1;
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Ready";
            
            // layoutControlItem5
            this.layoutControlItem5.Control = this.lblStatus;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 218);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(430, 17);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            
            // emptySpaceItem1
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 235);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(430, 45);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            
            // ConnectionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Device Connection";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoConnect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtIPAddress;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.CheckEdit chkAutoConnect;
        private DevExpress.XtraEditors.SimpleButton btnScan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}