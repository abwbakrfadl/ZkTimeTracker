using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ImprovedFingerprint.Forms
{
    partial class DeviceConnectionForm
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
            this.textEditIP = new DevExpress.XtraEditors.TextEdit();
            this.spinEditPort = new DevExpress.XtraEditors.SpinEdit();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnTestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.groupControlConnection = new DevExpress.XtraEditors.GroupControl();
            this.labelControlInstructions = new DevExpress.XtraEditors.LabelControl();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlConnection)).BeginInit();
            this.groupControlConnection.SuspendLayout();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlConnection);
            this.layoutControl1.Controls.Add(this.btnConnect);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnTestConnection);
            this.layoutControl1.Controls.Add(this.lblStatus);
            this.layoutControl1.Controls.Add(this.labelControlInstructions);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(450, 350);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(450, 350);
            this.Root.TextVisible = false;
            
            // Setup Connection Group
            SetupConnectionGroup();
            
            // Setup Buttons
            SetupButtons();
            
            // Setup Status and Instructions
            SetupStatusControls();
            
            // Setup Layout
            SetupLayout();
            
            // DeviceConnectionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceConnectionForm";
            this.Text = "الاتصال بجهاز البصمة";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlConnection)).EndInit();
            this.groupControlConnection.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private void SetupConnectionGroup()
        {
            this.groupControlConnection.Text = "معلومات الاتصال";
            this.groupControlConnection.Location = new System.Drawing.Point(12, 50);
            this.groupControlConnection.Size = new System.Drawing.Size(426, 120);
            this.groupControlConnection.Controls.Add(this.textEditIP);
            this.groupControlConnection.Controls.Add(this.spinEditPort);
            
            // IP Address TextEdit
            var labelIP = new DevExpress.XtraEditors.LabelControl();
            labelIP.Text = "عنوان IP للجهاز:";
            labelIP.Location = new System.Drawing.Point(320, 35);
            labelIP.Size = new System.Drawing.Size(90, 13);
            labelIP.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlConnection.Controls.Add(labelIP);
            
            this.textEditIP.Location = new System.Drawing.Point(20, 32);
            this.textEditIP.Size = new System.Drawing.Size(290, 20);
            this.textEditIP.Properties.Mask.EditMask = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
            this.textEditIP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEditIP.Properties.NullText = "مثال: 192.168.1.201";
            
            // Port SpinEdit
            var labelPort = new DevExpress.XtraEditors.LabelControl();
            labelPort.Text = "رقم المنفذ (Port):";
            labelPort.Location = new System.Drawing.Point(320, 65);
            labelPort.Size = new System.Drawing.Size(90, 13);
            labelPort.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlConnection.Controls.Add(labelPort);
            
            this.spinEditPort.Location = new System.Drawing.Point(20, 62);
            this.spinEditPort.Size = new System.Drawing.Size(290, 20);
            this.spinEditPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPort.Properties.IsFloatValue = false;
            this.spinEditPort.Properties.Mask.EditMask = "N00";
            this.spinEditPort.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinEditPort.Properties.MaxValue = new decimal(new int[] { 65535, 0, 0, 0 });
            
            // Default Values Note
            var labelNote = new DevExpress.XtraEditors.LabelControl();
            labelNote.Text = "القيم الافتراضية: IP = 192.168.1.201, Port = 4370";
            labelNote.Location = new System.Drawing.Point(20, 90);
            labelNote.Size = new System.Drawing.Size(390, 13);
            labelNote.Appearance.Font = new System.Drawing.Font("Tahoma", 7.5F, System.Drawing.FontStyle.Italic);
            labelNote.Appearance.Options.UseFont = true;
            labelNote.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.groupControlConnection.Controls.Add(labelNote);
        }
        
        private void SetupButtons()
        {
            // Test Connection Button
            this.btnTestConnection.Text = "اختبار الاتصال";
            this.btnTestConnection.Location = new System.Drawing.Point(12, 180);
            this.btnTestConnection.Size = new System.Drawing.Size(120, 30);
            this.btnTestConnection.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnTestConnection.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Appearance.Options.UseBackColor = true;
            this.btnTestConnection.Appearance.Options.UseForeColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            
            // Connect Button
            this.btnConnect.Text = "اتصال";
            this.btnConnect.Location = new System.Drawing.Point(220, 180);
            this.btnConnect.Size = new System.Drawing.Size(100, 30);
            this.btnConnect.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnConnect.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Appearance.Options.UseBackColor = true;
            this.btnConnect.Appearance.Options.UseForeColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            
            // Cancel Button
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.Location = new System.Drawing.Point(330, 180);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        }
        
        private void SetupStatusControls()
        {
            // Instructions Label
            this.labelControlInstructions.Text = "أدخل عنوان IP ورقم المنفذ لجهاز البصمة ZKTeco U350";
            this.labelControlInstructions.Location = new System.Drawing.Point(12, 12);
            this.labelControlInstructions.Size = new System.Drawing.Size(426, 30);
            this.labelControlInstructions.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControlInstructions.Appearance.Options.UseFont = true;
            this.labelControlInstructions.Appearance.Options.UseTextOptions = true;
            this.labelControlInstructions.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControlInstructions.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControlInstructions.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControlInstructions.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            
            // Status Label
            this.lblStatus.Text = "جاهز للاتصال";
            this.lblStatus.Location = new System.Drawing.Point(12, 220);
            this.lblStatus.Size = new System.Drawing.Size(426, 110);
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblStatus.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        private void SetupLayout()
        {
            // Add layout items
            var layoutItemInstructions = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemInstructions.Control = this.labelControlInstructions;
            layoutItemInstructions.Location = new System.Drawing.Point(0, 0);
            layoutItemInstructions.Size = new System.Drawing.Size(430, 38);
            layoutItemInstructions.TextSize = new System.Drawing.Size(0, 0);
            layoutItemInstructions.TextVisible = false;
            this.Root.Items.Add(layoutItemInstructions);
            
            var layoutItemConnection = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemConnection.Control = this.groupControlConnection;
            layoutItemConnection.Location = new System.Drawing.Point(0, 38);
            layoutItemConnection.Size = new System.Drawing.Size(430, 124);
            layoutItemConnection.TextSize = new System.Drawing.Size(0, 0);
            layoutItemConnection.TextVisible = false;
            this.Root.Items.Add(layoutItemConnection);
            
            // Add button layout items
            AddButtonLayoutItem(this.btnTestConnection, 0, 168, 124);
            
            // Add space
            var emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            emptySpaceItem.AllowHotTrack = false;
            emptySpaceItem.Location = new System.Drawing.Point(128, 168);
            emptySpaceItem.Size = new System.Drawing.Size(80, 34);
            emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            this.Root.Items.Add(emptySpaceItem);
            
            AddButtonLayoutItem(this.btnConnect, 212, 168, 104);
            AddButtonLayoutItem(this.btnCancel, 320, 168, 110);
            
            var layoutItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemStatus.Control = this.lblStatus;
            layoutItemStatus.Location = new System.Drawing.Point(0, 206);
            layoutItemStatus.Size = new System.Drawing.Size(430, 124);
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
        private DevExpress.XtraEditors.TextEdit textEditIP;
        private DevExpress.XtraEditors.SpinEdit spinEditPort;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnTestConnection;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.GroupControl groupControlConnection;
        private DevExpress.XtraEditors.LabelControl labelControlInstructions;
    }
}