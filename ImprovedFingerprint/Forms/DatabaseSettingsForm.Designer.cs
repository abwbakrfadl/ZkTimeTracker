using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ImprovedFingerprint.Forms
{
    partial class DatabaseSettingsForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControlConnection = new DevExpress.XtraEditors.GroupControl();
            this.textEditServer = new DevExpress.XtraEditors.TextEdit();
            this.textEditDatabase = new DevExpress.XtraEditors.TextEdit();
            this.checkEditIntegratedSecurity = new DevExpress.XtraEditors.CheckEdit();
            this.textEditUsername = new DevExpress.XtraEditors.TextEdit();
            this.textEditPassword = new DevExpress.XtraEditors.TextEdit();
            this.groupControlPreview = new DevExpress.XtraEditors.GroupControl();
            this.memoEditConnectionString = new DevExpress.XtraEditors.MemoEdit();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlConnection)).BeginInit();
            this.groupControlConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIntegratedSecurity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPreview)).BeginInit();
            this.groupControlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditConnectionString.Properties)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlConnection);
            this.layoutControl1.Controls.Add(this.groupControlPreview);
            this.layoutControl1.Controls.Add(this.btnTestConnection);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(500, 600);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(500, 600);
            this.Root.TextVisible = false;
            
            // Setup Connection Group
            SetupConnectionGroup();
            
            // Setup Preview Group
            SetupPreviewGroup();
            
            // Setup Buttons
            SetupButtons();
            
            // Setup Layout
            SetupLayout();
            
            // DatabaseSettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatabaseSettingsForm";
            this.Text = "إعدادات قاعدة البيانات";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlConnection)).EndInit();
            this.groupControlConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIntegratedSecurity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPreview)).EndInit();
            this.groupControlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditConnectionString.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        
        private void SetupConnectionGroup()
        {
            this.groupControlConnection.Text = "معلومات الاتصال";
            this.groupControlConnection.Location = new System.Drawing.Point(12, 12);
            this.groupControlConnection.Size = new System.Drawing.Size(476, 250);
            this.groupControlConnection.Controls.Add(this.textEditServer);
            this.groupControlConnection.Controls.Add(this.textEditDatabase);
            this.groupControlConnection.Controls.Add(this.checkEditIntegratedSecurity);
            this.groupControlConnection.Controls.Add(this.textEditUsername);
            this.groupControlConnection.Controls.Add(this.textEditPassword);
            
            // Server Name
            var lblServer = new DevExpress.XtraEditors.LabelControl();
            lblServer.Text = "اسم الخادم (Server):";
            lblServer.Location = new System.Drawing.Point(350, 35);
            lblServer.Size = new System.Drawing.Size(110, 13);
            lblServer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlConnection.Controls.Add(lblServer);
            
            this.textEditServer.Location = new System.Drawing.Point(20, 32);
            this.textEditServer.Size = new System.Drawing.Size(320, 20);
            this.textEditServer.Properties.NullText = "localhost أو اسم الخادم";
            this.textEditServer.EditValueChanged += new System.EventHandler(this.textEdit_TextChanged);
            
            // Database Name
            var lblDatabase = new DevExpress.XtraEditors.LabelControl();
            lblDatabase.Text = "اسم قاعدة البيانات:";
            lblDatabase.Location = new System.Drawing.Point(350, 65);
            lblDatabase.Size = new System.Drawing.Size(110, 13);
            lblDatabase.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlConnection.Controls.Add(lblDatabase);
            
            this.textEditDatabase.Location = new System.Drawing.Point(20, 62);
            this.textEditDatabase.Size = new System.Drawing.Size(320, 20);
            this.textEditDatabase.Properties.NullText = "اسم قاعدة البيانات";
            this.textEditDatabase.EditValueChanged += new System.EventHandler(this.textEdit_TextChanged);
            
            // Integrated Security
            this.checkEditIntegratedSecurity.Text = "استخدام مصادقة Windows";
            this.checkEditIntegratedSecurity.Location = new System.Drawing.Point(20, 100);
            this.checkEditIntegratedSecurity.Size = new System.Drawing.Size(440, 19);
            this.checkEditIntegratedSecurity.Properties.Caption = "استخدام مصادقة Windows (Integrated Security)";
            this.checkEditIntegratedSecurity.CheckedChanged += new System.EventHandler(this.checkEditIntegratedSecurity_CheckedChanged);
            
            // Username
            var lblUsername = new DevExpress.XtraEditors.LabelControl();
            lblUsername.Text = "اسم المستخدم:";
            lblUsername.Location = new System.Drawing.Point(350, 135);
            lblUsername.Size = new System.Drawing.Size(110, 13);
            lblUsername.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlConnection.Controls.Add(lblUsername);
            
            this.textEditUsername.Location = new System.Drawing.Point(20, 132);
            this.textEditUsername.Size = new System.Drawing.Size(320, 20);
            this.textEditUsername.Properties.NullText = "اسم المستخدم";
            this.textEditUsername.EditValueChanged += new System.EventHandler(this.textEdit_TextChanged);
            
            // Password
            var lblPassword = new DevExpress.XtraEditors.LabelControl();
            lblPassword.Text = "كلمة المرور:";
            lblPassword.Location = new System.Drawing.Point(350, 165);
            lblPassword.Size = new System.Drawing.Size(110, 13);
            lblPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlConnection.Controls.Add(lblPassword);
            
            this.textEditPassword.Location = new System.Drawing.Point(20, 162);
            this.textEditPassword.Size = new System.Drawing.Size(320, 20);
            this.textEditPassword.Properties.UseSystemPasswordChar = true;
            this.textEditPassword.Properties.NullText = "كلمة المرور";
            this.textEditPassword.EditValueChanged += new System.EventHandler(this.textEdit_TextChanged);
            
            // Note
            var lblNote = new DevExpress.XtraEditors.LabelControl();
            lblNote.Text = "ملاحظة: عند تفعيل مصادقة Windows، لن تحتاج لاسم مستخدم وكلمة مرور";
            lblNote.Location = new System.Drawing.Point(20, 200);
            lblNote.Size = new System.Drawing.Size(440, 30);
            lblNote.Appearance.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Italic);
            lblNote.Appearance.Options.UseFont = true;
            lblNote.Appearance.ForeColor = System.Drawing.Color.Gray;
            lblNote.Appearance.Options.UseTextOptions = true;
            lblNote.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            lblNote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.groupControlConnection.Controls.Add(lblNote);
        }
        
        private void SetupPreviewGroup()
        {
            this.groupControlPreview.Text = "معاينة نص الاتصال";
            this.groupControlPreview.Location = new System.Drawing.Point(12, 270);
            this.groupControlPreview.Size = new System.Drawing.Size(476, 150);
            this.groupControlPreview.Controls.Add(this.memoEditConnectionString);
            
            this.memoEditConnectionString.Location = new System.Drawing.Point(10, 25);
            this.memoEditConnectionString.Size = new System.Drawing.Size(456, 115);
            this.memoEditConnectionString.Properties.ReadOnly = true;
            this.memoEditConnectionString.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memoEditConnectionString.Properties.WordWrap = false;
        }
        
        private void SetupButtons()
        {
            // Test Connection Button
            this.btnTestConnection.Text = "اختبار الاتصال";
            this.btnTestConnection.Location = new System.Drawing.Point(12, 430);
            this.btnTestConnection.Size = new System.Drawing.Size(120, 30);
            this.btnTestConnection.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnTestConnection.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Appearance.Options.UseBackColor = true;
            this.btnTestConnection.Appearance.Options.UseForeColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            
            // Save Button
            this.btnSave.Text = "حفظ";
            this.btnSave.Location = new System.Drawing.Point(280, 430);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            
            // Cancel Button
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Location = new System.Drawing.Point(388, 430);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            
            // Status Label
            this.lblStatus.Text = "جاهز لإعداد قاعدة البيانات";
            this.lblStatus.Location = new System.Drawing.Point(12, 470);
            this.lblStatus.Size = new System.Drawing.Size(476, 110);
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        private void SetupLayout()
        {
            // Add layout items
            var layoutItemConnection = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemConnection.Control = this.groupControlConnection;
            layoutItemConnection.Location = new System.Drawing.Point(0, 0);
            layoutItemConnection.Size = new System.Drawing.Size(480, 254);
            layoutItemConnection.TextSize = new System.Drawing.Size(0, 0);
            layoutItemConnection.TextVisible = false;
            this.Root.Items.Add(layoutItemConnection);
            
            var layoutItemPreview = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemPreview.Control = this.groupControlPreview;
            layoutItemPreview.Location = new System.Drawing.Point(0, 258);
            layoutItemPreview.Size = new System.Drawing.Size(480, 154);
            layoutItemPreview.TextSize = new System.Drawing.Size(0, 0);
            layoutItemPreview.TextVisible = false;
            this.Root.Items.Add(layoutItemPreview);
            
            // Add button layout items
            AddButtonLayoutItem(this.btnTestConnection, 0, 418, 124);
            
            // Add space
            var emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem.AllowHotTrack = false;
            emptySpaceItem.Location = new System.Drawing.Point(128, 418);
            emptySpaceItem.Size = new System.Drawing.Size(140, 34);
            emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            this.Root.Items.Add(emptySpaceItem);
            
            AddButtonLayoutItem(this.btnSave, 272, 418, 104);
            AddButtonLayoutItem(this.btnCancel, 380, 418, 100);
            
            var layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatus.Control = this.lblStatus;
            layoutItemStatus.Location = new System.Drawing.Point(0, 456);
            layoutItemStatus.Size = new System.Drawing.Size(480, 124);
            layoutItemStatus.TextSize = new System.Drawing.Size(0, 0);
            layoutItemStatus.TextVisible = false;
            this.Root.Items.Add(layoutItemStatus);
        }
        
        private void AddButtonLayoutItem(DevExpress.XtraEditors.SimpleButton button, int x, int y, int width)
        {
            var layoutItem = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItem.Control = button;
            layoutItem.Location = new System.Drawing.Point(x, y);
            layoutItem.Size = new System.Drawing.Size(width, 34);
            layoutItem.TextSize = new System.Drawing.Size(0, 0);
            layoutItem.TextVisible = false;
            this.Root.Items.Add(layoutItem);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        
        private DevExpress.XtraEditors.GroupControl groupControlConnection;
        private DevExpress.XtraEditors.TextEdit textEditServer;
        private DevExpress.XtraEditors.TextEdit textEditDatabase;
        private DevExpress.XtraEditors.CheckEdit checkEditIntegratedSecurity;
        private DevExpress.XtraEditors.TextEdit textEditUsername;
        private DevExpress.XtraEditors.TextEdit textEditPassword;
        
        private DevExpress.XtraEditors.GroupControl groupControlPreview;
        private DevExpress.XtraEditors.MemoEdit memoEditConnectionString;
        
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}