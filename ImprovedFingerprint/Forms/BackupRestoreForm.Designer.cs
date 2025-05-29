using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ImprovedFingerprint.Forms
{
    partial class BackupRestoreForm
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
            
            // Backup Section
            this.groupControlBackup = new DevExpress.XtraEditors.GroupControl();
            this.textEditBackupPath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateBackup = new DevExpress.XtraEditors.SimpleButton();
            this.lblBackupStatus = new DevExpress.XtraEditors.LabelControl();
            
            // Restore Section
            this.groupControlRestore = new DevExpress.XtraEditors.GroupControl();
            this.textEditRestorePath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowseRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestoreBackup = new DevExpress.XtraEditors.SimpleButton();
            this.lblRestoreStatus = new DevExpress.XtraEditors.LabelControl();
            
            // Backup List Section
            this.groupControlBackupList = new DevExpress.XtraEditors.GroupControl();
            this.listBoxControlBackups = new DevExpress.XtraEditors.ListBoxControl();
            this.btnRefreshList = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteBackup = new DevExpress.XtraEditors.SimpleButton();
            
            // Backup Info Section
            this.groupControlBackupInfo = new DevExpress.XtraEditors.GroupControl();
            this.memoEditBackupInfo = new DevExpress.XtraEditors.MemoEdit();
            
            // Progress and Close
            this.progressBarControlOperation = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBackup)).BeginInit();
            this.groupControlBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlRestore)).BeginInit();
            this.groupControlRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRestorePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBackupList)).BeginInit();
            this.groupControlBackupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlBackups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBackupInfo)).BeginInit();
            this.groupControlBackupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditBackupInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlOperation.Properties)).BeginInit();
            this.SuspendLayout();
            
            // layoutControl1
            this.layoutControl1.Controls.Add(this.groupControlBackup);
            this.layoutControl1.Controls.Add(this.groupControlRestore);
            this.layoutControl1.Controls.Add(this.groupControlBackupList);
            this.layoutControl1.Controls.Add(this.groupControlBackupInfo);
            this.layoutControl1.Controls.Add(this.progressBarControlOperation);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(900, 700);
            this.layoutControl1.TabIndex = 0;
            
            // Root
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(900, 700);
            this.Root.TextVisible = false;
            
            // Setup sections
            SetupBackupSection();
            SetupRestoreSection();
            SetupBackupListSection();
            SetupBackupInfoSection();
            SetupProgressAndClose();
            SetupLayout();
            
            // BackupRestoreForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "BackupRestoreForm";
            this.Text = "النسخ الاحتياطية واستعادة البيانات";
            
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBackup)).EndInit();
            this.groupControlBackup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackupPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlRestore)).EndInit();
            this.groupControlRestore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditRestorePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBackupList)).EndInit();
            this.groupControlBackupList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlBackups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlBackupInfo)).EndInit();
            this.groupControlBackupInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEditBackupInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControlOperation.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        
        private void SetupBackupSection()
        {
            this.groupControlBackup.Text = "💾 إنشاء نسخة احتياطية";
            this.groupControlBackup.Location = new System.Drawing.Point(12, 12);
            this.groupControlBackup.Size = new System.Drawing.Size(876, 120);
            this.groupControlBackup.Controls.Add(this.textEditBackupPath);
            this.groupControlBackup.Controls.Add(this.btnBrowseBackup);
            this.groupControlBackup.Controls.Add(this.btnCreateBackup);
            this.groupControlBackup.Controls.Add(this.lblBackupStatus);
            
            // Path TextEdit
            var lblBackupPath = new DevExpress.XtraEditors.LabelControl();
            lblBackupPath.Text = "مسار النسخة الاحتياطية:";
            lblBackupPath.Location = new System.Drawing.Point(700, 30);
            lblBackupPath.Size = new System.Drawing.Size(150, 13);
            lblBackupPath.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlBackup.Controls.Add(lblBackupPath);
            
            this.textEditBackupPath.Location = new System.Drawing.Point(150, 27);
            this.textEditBackupPath.Size = new System.Drawing.Size(540, 20);
            this.textEditBackupPath.Properties.NullText = "اختر مسار حفظ النسخة الاحتياطية";
            
            // Browse Button
            this.btnBrowseBackup.Text = "استعراض";
            this.btnBrowseBackup.Location = new System.Drawing.Point(50, 25);
            this.btnBrowseBackup.Size = new System.Drawing.Size(90, 25);
            this.btnBrowseBackup.Click += new System.EventHandler(this.btnBrowseBackup_Click);
            
            // Create Backup Button
            this.btnCreateBackup.Text = "إنشاء نسخة احتياطية";
            this.btnCreateBackup.Location = new System.Drawing.Point(600, 60);
            this.btnCreateBackup.Size = new System.Drawing.Size(200, 35);
            this.btnCreateBackup.Appearance.BackColor = System.Drawing.Color.Green;
            this.btnCreateBackup.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCreateBackup.Appearance.Options.UseBackColor = true;
            this.btnCreateBackup.Appearance.Options.UseForeColor = true;
            this.btnCreateBackup.Click += new System.EventHandler(this.btnCreateBackup_Click);
            
            // Status Label
            this.lblBackupStatus.Text = "جاهز لإنشاء نسخة احتياطية";
            this.lblBackupStatus.Location = new System.Drawing.Point(20, 70);
            this.lblBackupStatus.Size = new System.Drawing.Size(570, 20);
            this.lblBackupStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBackupStatus.Appearance.Options.UseFont = true;
            this.lblBackupStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        private void SetupRestoreSection()
        {
            this.groupControlRestore.Text = "🔄 استعادة نسخة احتياطية";
            this.groupControlRestore.Location = new System.Drawing.Point(12, 140);
            this.groupControlRestore.Size = new System.Drawing.Size(876, 120);
            this.groupControlRestore.Controls.Add(this.textEditRestorePath);
            this.groupControlRestore.Controls.Add(this.btnBrowseRestore);
            this.groupControlRestore.Controls.Add(this.btnRestoreBackup);
            this.groupControlRestore.Controls.Add(this.lblRestoreStatus);
            
            // Path TextEdit
            var lblRestorePath = new DevExpress.XtraEditors.LabelControl();
            lblRestorePath.Text = "ملف النسخة الاحتياطية:";
            lblRestorePath.Location = new System.Drawing.Point(700, 30);
            lblRestorePath.Size = new System.Drawing.Size(150, 13);
            lblRestorePath.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.groupControlRestore.Controls.Add(lblRestorePath);
            
            this.textEditRestorePath.Location = new System.Drawing.Point(150, 27);
            this.textEditRestorePath.Size = new System.Drawing.Size(540, 20);
            this.textEditRestorePath.Properties.NullText = "اختر ملف النسخة الاحتياطية للاستعادة";
            
            // Browse Button
            this.btnBrowseRestore.Text = "استعراض";
            this.btnBrowseRestore.Location = new System.Drawing.Point(50, 25);
            this.btnBrowseRestore.Size = new System.Drawing.Size(90, 25);
            this.btnBrowseRestore.Click += new System.EventHandler(this.btnBrowseRestore_Click);
            
            // Restore Button
            this.btnRestoreBackup.Text = "استعادة النسخة الاحتياطية";
            this.btnRestoreBackup.Location = new System.Drawing.Point(600, 60);
            this.btnRestoreBackup.Size = new System.Drawing.Size(200, 35);
            this.btnRestoreBackup.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnRestoreBackup.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRestoreBackup.Appearance.Options.UseBackColor = true;
            this.btnRestoreBackup.Appearance.Options.UseForeColor = true;
            this.btnRestoreBackup.Click += new System.EventHandler(this.btnRestoreBackup_Click);
            
            // Status Label
            this.lblRestoreStatus.Text = "جاهز لاستعادة نسخة احتياطية";
            this.lblRestoreStatus.Location = new System.Drawing.Point(20, 70);
            this.lblRestoreStatus.Size = new System.Drawing.Size(570, 20);
            this.lblRestoreStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblRestoreStatus.Appearance.Options.UseFont = true;
            this.lblRestoreStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
        }
        
        private void SetupBackupListSection()
        {
            this.groupControlBackupList.Text = "📋 النسخ الاحتياطية المتاحة";
            this.groupControlBackupList.Location = new System.Drawing.Point(12, 268);
            this.groupControlBackupList.Size = new System.Drawing.Size(430, 350);
            this.groupControlBackupList.Controls.Add(this.listBoxControlBackups);
            this.groupControlBackupList.Controls.Add(this.btnRefreshList);
            this.groupControlBackupList.Controls.Add(this.btnDeleteBackup);
            
            // ListBox
            this.listBoxControlBackups.Location = new System.Drawing.Point(10, 25);
            this.listBoxControlBackups.Size = new System.Drawing.Size(410, 280);
            this.listBoxControlBackups.SelectedIndexChanged += new System.EventHandler(this.listBoxControlBackups_SelectedIndexChanged);
            
            // Refresh Button
            this.btnRefreshList.Text = "تحديث القائمة";
            this.btnRefreshList.Location = new System.Drawing.Point(320, 310);
            this.btnRefreshList.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshList.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btnRefreshList.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefreshList.Appearance.Options.UseBackColor = true;
            this.btnRefreshList.Appearance.Options.UseForeColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            
            // Delete Button
            this.btnDeleteBackup.Text = "حذف المحدد";
            this.btnDeleteBackup.Location = new System.Drawing.Point(210, 310);
            this.btnDeleteBackup.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteBackup.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnDeleteBackup.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBackup.Appearance.Options.UseBackColor = true;
            this.btnDeleteBackup.Appearance.Options.UseForeColor = true;
            this.btnDeleteBackup.Click += new System.EventHandler(this.btnDeleteBackup_Click);
        }
        
        private void SetupBackupInfoSection()
        {
            this.groupControlBackupInfo.Text = "ℹ️ معلومات النسخة الاحتياطية";
            this.groupControlBackupInfo.Location = new System.Drawing.Point(450, 268);
            this.groupControlBackupInfo.Size = new System.Drawing.Size(438, 350);
            this.groupControlBackupInfo.Controls.Add(this.memoEditBackupInfo);
            
            // Memo Edit
            this.memoEditBackupInfo.Location = new System.Drawing.Point(10, 25);
            this.memoEditBackupInfo.Size = new System.Drawing.Size(418, 315);
            this.memoEditBackupInfo.Properties.ReadOnly = true;
            this.memoEditBackupInfo.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.memoEditBackupInfo.Text = "اختر نسخة احتياطية من القائمة لعرض معلوماتها";
        }
        
        private void SetupProgressAndClose()
        {
            // Progress Bar
            this.progressBarControlOperation.Location = new System.Drawing.Point(12, 630);
            this.progressBarControlOperation.Size = new System.Drawing.Size(760, 25);
            this.progressBarControlOperation.Properties.ShowTitle = true;
            this.progressBarControlOperation.Properties.PercentView = true;
            this.progressBarControlOperation.Visible = false;
            
            // Close Button
            this.btnClose.Text = "إغلاق";
            this.btnClose.Location = new System.Drawing.Point(780, 630);
            this.btnClose.Size = new System.Drawing.Size(108, 25);
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        }
        
        private void SetupLayout()
        {
            // Add layout items
            var layoutItemBackup = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemBackup.Control = this.groupControlBackup;
            layoutItemBackup.Location = new System.Drawing.Point(0, 0);
            layoutItemBackup.Size = new System.Drawing.Size(880, 124);
            layoutItemBackup.TextSize = new System.Drawing.Size(0, 0);
            layoutItemBackup.TextVisible = false;
            this.Root.Items.Add(layoutItemBackup);
            
            var layoutItemRestore = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemRestore.Control = this.groupControlRestore;
            layoutItemRestore.Location = new System.Drawing.Point(0, 128);
            layoutItemRestore.Size = new System.Drawing.Size(880, 124);
            layoutItemRestore.TextSize = new System.Drawing.Size(0, 0);
            layoutItemRestore.TextVisible = false;
            this.Root.Items.Add(layoutItemRestore);
            
            var layoutItemBackupList = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemBackupList.Control = this.groupControlBackupList;
            layoutItemBackupList.Location = new System.Drawing.Point(0, 256);
            layoutItemBackupList.Size = new System.Drawing.Size(434, 354);
            layoutItemBackupList.TextSize = new System.Drawing.Size(0, 0);
            layoutItemBackupList.TextVisible = false;
            this.Root.Items.Add(layoutItemBackupList);
            
            var layoutItemBackupInfo = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemBackupInfo.Control = this.groupControlBackupInfo;
            layoutItemBackupInfo.Location = new System.Drawing.Point(438, 256);
            layoutItemBackupInfo.Size = new System.Drawing.Size(442, 354);
            layoutItemBackupInfo.TextSize = new System.Drawing.Size(0, 0);
            layoutItemBackupInfo.TextVisible = false;
            this.Root.Items.Add(layoutItemBackupInfo);
            
            var layoutItemProgress = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemProgress.Control = this.progressBarControlOperation;
            layoutItemProgress.Location = new System.Drawing.Point(0, 614);
            layoutItemProgress.Size = new System.Drawing.Size(768, 33);
            layoutItemProgress.TextSize = new System.Drawing.Size(0, 0);
            layoutItemProgress.TextVisible = false;
            this.Root.Items.Add(layoutItemProgress);
            
            var layoutItemClose = new DevExpress.XtraLayout.LayoutControlItem();
            layoutItemClose.Control = this.btnClose;
            layoutItemClose.Location = new System.Drawing.Point(772, 614);
            layoutItemClose.Size = new System.Drawing.Size(108, 33);
            layoutItemClose.TextSize = new System.Drawing.Size(0, 0);
            layoutItemClose.TextVisible = false;
            this.Root.Items.Add(layoutItemClose);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        
        private DevExpress.XtraEditors.GroupControl groupControlBackup;
        private DevExpress.XtraEditors.TextEdit textEditBackupPath;
        private DevExpress.XtraEditors.SimpleButton btnBrowseBackup;
        private DevExpress.XtraEditors.SimpleButton btnCreateBackup;
        private DevExpress.XtraEditors.LabelControl lblBackupStatus;
        
        private DevExpress.XtraEditors.GroupControl groupControlRestore;
        private DevExpress.XtraEditors.TextEdit textEditRestorePath;
        private DevExpress.XtraEditors.SimpleButton btnBrowseRestore;
        private DevExpress.XtraEditors.SimpleButton btnRestoreBackup;
        private DevExpress.XtraEditors.LabelControl lblRestoreStatus;
        
        private DevExpress.XtraEditors.GroupControl groupControlBackupList;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlBackups;
        private DevExpress.XtraEditors.SimpleButton btnRefreshList;
        private DevExpress.XtraEditors.SimpleButton btnDeleteBackup;
        
        private DevExpress.XtraEditors.GroupControl groupControlBackupInfo;
        private DevExpress.XtraEditors.MemoEdit memoEditBackupInfo;
        
        private DevExpress.XtraEditors.ProgressBarControl progressBarControlOperation;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}