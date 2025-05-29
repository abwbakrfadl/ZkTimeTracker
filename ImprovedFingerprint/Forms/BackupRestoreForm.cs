using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ImprovedFingerprint.Services;

namespace ImprovedFingerprint.Forms
{
    public partial class BackupRestoreForm : XtraForm
    {
        private readonly BackupService _backupService;
        private bool _operationInProgress = false;

        public BackupRestoreForm()
        {
            InitializeComponent();
            _backupService = new BackupService();
            
            this.Text = "النسخ الاحتياطية واستعادة البيانات";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterParent;
            
            SetupEvents();
            LoadDefaultSettings();
        }

        private void SetupEvents()
        {
            _backupService.ProgressChanged += BackupService_ProgressChanged;
            _backupService.StatusChanged += BackupService_StatusChanged;
        }

        private void LoadDefaultSettings()
        {
            // إعداد مسار النسخ الاحتياطية الافتراضي
            var defaultBackupPath = Path.Combine(Application.StartupPath, "Backups");
            if (!Directory.Exists(defaultBackupPath))
            {
                Directory.CreateDirectory(defaultBackupPath);
            }

            var currentDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            textEditBackupPath.Text = Path.Combine(defaultBackupPath, $"FingerprintDB_Backup_{currentDate}.bak");
            
            // تحديث قائمة النسخ الاحتياطية الموجودة
            RefreshBackupList();
        }

        private void RefreshBackupList()
        {
            try
            {
                listBoxControlBackups.Items.Clear();
                
                var backupFolder = Path.Combine(Application.StartupPath, "Backups");
                if (Directory.Exists(backupFolder))
                {
                    var backupFiles = Directory.GetFiles(backupFolder, "*.bak");
                    
                    foreach (var file in backupFiles)
                    {
                        var fileInfo = new FileInfo(file);
                        var displayText = $"{fileInfo.Name} - {fileInfo.LastWriteTime:yyyy/MM/dd HH:mm} - {FormatFileSize(fileInfo.Length)}";
                        listBoxControlBackups.Items.Add(displayText, file);
                    }
                }
                
                if (listBoxControlBackups.Items.Count == 0)
                {
                    listBoxControlBackups.Items.Add("لا توجد نسخ احتياطية");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في تحميل قائمة النسخ الاحتياطية: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreateBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (_operationInProgress)
                {
                    XtraMessageBox.Show("يوجد عملية جارية، الرجاء الانتظار", "عملية جارية",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var backupPath = textEditBackupPath.Text.Trim();
                if (string.IsNullOrEmpty(backupPath))
                {
                    XtraMessageBox.Show("الرجاء تحديد مسار النسخة الاحتياطية", "مسار مطلوب",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التأكد من امتداد الملف
                if (!backupPath.EndsWith(".bak"))
                {
                    backupPath += ".bak";
                    textEditBackupPath.Text = backupPath;
                }

                // التحقق من وجود الملف مسبقاً
                if (File.Exists(backupPath))
                {
                    var result = XtraMessageBox.Show(
                        "الملف موجود مسبقاً. هل تريد استبداله؟",
                        "تأكيد الاستبدال",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                        return;
                }

                SetOperationInProgress(true);
                
                var success = await _backupService.CreateBackupAsync(backupPath);
                
                if (success)
                {
                    RefreshBackupList();
                    XtraMessageBox.Show("تم إنشاء النسخة الاحتياطية بنجاح", "نجح الحفظ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // تحديث مسار النسخة التالية
                    var currentDate = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    var directory = Path.GetDirectoryName(backupPath);
                    textEditBackupPath.Text = Path.Combine(directory, $"FingerprintDB_Backup_{currentDate}.bak");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في إنشاء النسخة الاحتياطية: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetOperationInProgress(false);
            }
        }

        private async void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (_operationInProgress)
                {
                    XtraMessageBox.Show("يوجد عملية جارية، الرجاء الانتظار", "عملية جارية",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var restorePath = textEditRestorePath.Text.Trim();
                if (string.IsNullOrEmpty(restorePath))
                {
                    XtraMessageBox.Show("الرجاء تحديد ملف النسخة الاحتياطية للاستعادة", "ملف مطلوب",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(restorePath))
                {
                    XtraMessageBox.Show("ملف النسخة الاحتياطية غير موجود", "ملف غير موجود",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // التحقق من صحة ملف النسخة الاحتياطية
                lblRestoreStatus.Text = "جاري التحقق من صحة ملف النسخة الاحتياطية...";
                Application.DoEvents();

                if (!_backupService.ValidateBackupFile(restorePath))
                {
                    XtraMessageBox.Show("ملف النسخة الاحتياطية تالف أو غير صحيح", "ملف غير صحيح",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // تحذير من فقدان البيانات الحالية
                var warningResult = XtraMessageBox.Show(
                    "تحذير: ستؤدي عملية الاستعادة إلى حذف جميع البيانات الحالية واستبدالها ببيانات النسخة الاحتياطية.\n\nهل تريد المتابعة؟",
                    "تحذير - فقدان البيانات",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (warningResult == DialogResult.No)
                    return;

                // تأكيد إضافي
                var confirmResult = XtraMessageBox.Show(
                    "هل أنت متأكد من أنك تريد استعادة هذه النسخة الاحتياطية؟\nلا يمكن التراجع عن هذه العملية.",
                    "تأكيد الاستعادة",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.No)
                    return;

                SetOperationInProgress(true);

                var success = await _backupService.RestoreBackupAsync(restorePath);

                if (success)
                {
                    XtraMessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح.\nسيتم إعادة تشغيل التطبيق الآن.", 
                        "نجحت الاستعادة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // إعادة تشغيل التطبيق
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في استعادة النسخة الاحتياطية: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetOperationInProgress(false);
            }
        }

        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "ملفات النسخ الاحتياطية (*.bak)|*.bak";
                saveDialog.DefaultExt = "bak";
                saveDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Backups");
                saveDialog.FileName = $"FingerprintDB_Backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.bak";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    textEditBackupPath.Text = saveDialog.FileName;
                }
            }
        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "ملفات النسخ الاحتياطية (*.bak)|*.bak";
                openDialog.InitialDirectory = Path.Combine(Application.StartupPath, "Backups");

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    textEditRestorePath.Text = openDialog.FileName;
                    ShowBackupInfo(openDialog.FileName);
                }
            }
        }

        private void listBoxControlBackups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxControlBackups.SelectedItem != null && listBoxControlBackups.SelectedValue != null)
            {
                var selectedPath = listBoxControlBackups.SelectedValue.ToString();
                textEditRestorePath.Text = selectedPath;
                ShowBackupInfo(selectedPath);
            }
        }

        private void ShowBackupInfo(string backupPath)
        {
            try
            {
                var backupInfo = _backupService.GetBackupInfo(backupPath);
                if (backupInfo != null)
                {
                    var info = $@"معلومات النسخة الاحتياطية:

قاعدة البيانات: {backupInfo.DatabaseName}
تاريخ بدء النسخ: {backupInfo.BackupStartDate:yyyy/MM/dd HH:mm:ss}
تاريخ انتهاء النسخ: {backupInfo.BackupFinishDate:yyyy/MM/dd HH:mm:ss}
حجم النسخة: {FormatFileSize(backupInfo.BackupSize)}
حجم الملف: {FormatFileSize(backupInfo.FileSize)}
اسم الخادم: {backupInfo.ServerName}";

                    memoEditBackupInfo.Text = info;
                }
                else
                {
                    memoEditBackupInfo.Text = "لا يمكن قراءة معلومات النسخة الاحتياطية";
                }
            }
            catch (Exception ex)
            {
                memoEditBackupInfo.Text = $"خطأ في قراءة معلومات النسخة: {ex.Message}";
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            RefreshBackupList();
        }

        private void btnDeleteBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxControlBackups.SelectedItem == null || listBoxControlBackups.SelectedValue == null)
                {
                    XtraMessageBox.Show("الرجاء اختيار نسخة احتياطية للحذف", "لا يوجد اختيار",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedPath = listBoxControlBackups.SelectedValue.ToString();
                var fileName = Path.GetFileName(selectedPath);

                var result = XtraMessageBox.Show(
                    $"هل تريد حذف النسخة الاحتياطية: {fileName}؟\nلا يمكن التراجع عن هذه العملية.",
                    "تأكيد الحذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    File.Delete(selectedPath);
                    RefreshBackupList();
                    memoEditBackupInfo.Text = "تم حذف النسخة الاحتياطية";
                    textEditRestorePath.Text = "";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطأ في حذف النسخة الاحتياطية: {ex.Message}", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackupService_ProgressChanged(object sender, ProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BackupService_ProgressChanged(sender, e)));
                return;
            }

            progressBarControlOperation.Position = e.Progress;
        }

        private void BackupService_StatusChanged(object sender, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => BackupService_StatusChanged(sender, status)));
                return;
            }

            lblBackupStatus.Text = status;
            lblRestoreStatus.Text = status;
        }

        private void SetOperationInProgress(bool inProgress)
        {
            _operationInProgress = inProgress;
            
            btnCreateBackup.Enabled = !inProgress;
            btnRestoreBackup.Enabled = !inProgress;
            btnBrowseBackup.Enabled = !inProgress;
            btnBrowseRestore.Enabled = !inProgress;
            btnDeleteBackup.Enabled = !inProgress;
            btnRefreshList.Enabled = !inProgress;
            
            progressBarControlOperation.Visible = inProgress;
            
            if (!inProgress)
            {
                progressBarControlOperation.Position = 0;
                lblBackupStatus.Text = "جاهز لإنشاء نسخة احتياطية";
                lblRestoreStatus.Text = "جاهز لاستعادة نسخة احتياطية";
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "بايت", "كيلوبايت", "ميجابايت", "جيجابايت" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_operationInProgress)
            {
                var result = XtraMessageBox.Show(
                    "يوجد عملية جارية. هل تريد إلغاء العملية والإغلاق؟",
                    "تأكيد الإغلاق",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_operationInProgress)
            {
                e.Cancel = true;
                btnClose_Click(null, null);
                return;
            }

            base.OnFormClosing(e);
        }
    }
}