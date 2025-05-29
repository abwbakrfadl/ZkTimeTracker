using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using ImprovedFingerprint.Helpers;

namespace ImprovedFingerprint.Services
{
    public class BackupService
    {
        private readonly string _connectionString;

        public BackupService()
        {
            _connectionString = AppSettings.GetConnectionString("cn");
        }

        public event EventHandler<ProgressEventArgs> ProgressChanged;
        public event EventHandler<string> StatusChanged;

        public async Task<bool> CreateBackupAsync(string backupPath, string databaseName = "NEW_FingerprintDB")
        {
            try
            {
                OnStatusChanged("بدء عملية إنشاء النسخة الاحتياطية...");
                OnProgressChanged(10);

                // التأكد من وجود المجلد
                var directory = Path.GetDirectoryName(backupPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                OnStatusChanged("جاري الاتصال بقاعدة البيانات...");
                OnProgressChanged(20);

                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    
                    OnStatusChanged("جاري إنشاء النسخة الاحتياطية...");
                    OnProgressChanged(30);

                    var backupQuery = $@"
                        BACKUP DATABASE [{databaseName}] 
                        TO DISK = @BackupPath
                        WITH FORMAT, INIT, 
                        NAME = N'{databaseName}-Full Database Backup', 
                        SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                    using (var command = new SqlCommand(backupQuery, connection))
                    {
                        command.CommandTimeout = 300; // 5 دقائق
                        command.Parameters.AddWithValue("@BackupPath", backupPath);

                        // تتبع التقدم من خلال رسائل SQL Server
                        connection.InfoMessage += (sender, e) =>
                        {
                            if (e.Message.Contains("percent"))
                            {
                                // استخراج نسبة التقدم من رسالة SQL Server
                                var parts = e.Message.Split(' ');
                                foreach (var part in parts)
                                {
                                    if (part.Contains("percent"))
                                    {
                                        var percentText = part.Replace("percent", "").Replace(".", "");
                                        if (int.TryParse(percentText, out int percent))
                                        {
                                            OnProgressChanged(30 + (percent * 60 / 100));
                                            OnStatusChanged($"جاري إنشاء النسخة الاحتياطية... {percent}%");
                                        }
                                        break;
                                    }
                                }
                            }
                        };

                        await command.ExecuteNonQueryAsync();
                    }
                }

                OnProgressChanged(95);
                OnStatusChanged("جاري التحقق من النسخة الاحتياطية...");

                // التحقق من إنشاء الملف بنجاح
                if (File.Exists(backupPath))
                {
                    var fileInfo = new FileInfo(backupPath);
                    if (fileInfo.Length > 0)
                    {
                        OnProgressChanged(100);
                        OnStatusChanged($"تم إنشاء النسخة الاحتياطية بنجاح. حجم الملف: {FormatFileSize(fileInfo.Length)}");
                        return true;
                    }
                }

                throw new Exception("فشل في إنشاء ملف النسخة الاحتياطية");
            }
            catch (Exception ex)
            {
                OnStatusChanged($"خطأ في إنشاء النسخة الاحتياطية: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> RestoreBackupAsync(string backupPath, string databaseName = "NEW_FingerprintDB")
        {
            try
            {
                OnStatusChanged("بدء عملية استعادة النسخة الاحتياطية...");
                OnProgressChanged(10);

                // التحقق من وجود ملف النسخة الاحتياطية
                if (!File.Exists(backupPath))
                {
                    throw new FileNotFoundException("ملف النسخة الاحتياطية غير موجود");
                }

                OnStatusChanged("جاري الاتصال بقاعدة البيانات...");
                OnProgressChanged(20);

                // الحصول على connection string للخادم بدون تحديد قاعدة البيانات
                var builder = new SqlConnectionStringBuilder(_connectionString);
                var serverConnectionString = $"Data Source={builder.DataSource};Integrated Security={builder.IntegratedSecurity}";
                if (!builder.IntegratedSecurity)
                {
                    serverConnectionString += $";User ID={builder.UserID};Password={builder.Password}";
                }

                using (var connection = new SqlConnection(serverConnectionString))
                {
                    await connection.OpenAsync();

                    OnStatusChanged("جاري إعداد قاعدة البيانات للاستعادة...");
                    OnProgressChanged(30);

                    // قطع جميع الاتصالات النشطة بقاعدة البيانات
                    var killConnectionsQuery = $@"
                        IF EXISTS (SELECT name FROM sys.databases WHERE name = N'{databaseName}')
                        BEGIN
                            ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                        END";

                    using (var command = new SqlCommand(killConnectionsQuery, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }

                    OnStatusChanged("جاري استعادة قاعدة البيانات...");
                    OnProgressChanged(40);

                    // استعادة قاعدة البيانات
                    var restoreQuery = $@"
                        RESTORE DATABASE [{databaseName}] 
                        FROM DISK = @BackupPath
                        WITH REPLACE, STATS = 10";

                    using (var command = new SqlCommand(restoreQuery, connection))
                    {
                        command.CommandTimeout = 600; // 10 دقائق
                        command.Parameters.AddWithValue("@BackupPath", backupPath);

                        // تتبع التقدم من خلال رسائل SQL Server
                        connection.InfoMessage += (sender, e) =>
                        {
                            if (e.Message.Contains("percent"))
                            {
                                var parts = e.Message.Split(' ');
                                foreach (var part in parts)
                                {
                                    if (part.Contains("percent"))
                                    {
                                        var percentText = part.Replace("percent", "").Replace(".", "");
                                        if (int.TryParse(percentText, out int percent))
                                        {
                                            OnProgressChanged(40 + (percent * 50 / 100));
                                            OnStatusChanged($"جاري استعادة قاعدة البيانات... {percent}%");
                                        }
                                        break;
                                    }
                                }
                            }
                        };

                        await command.ExecuteNonQueryAsync();
                    }

                    OnStatusChanged("جاري إعادة تعيين وضع قاعدة البيانات...");
                    OnProgressChanged(95);

                    // إعادة تعيين قاعدة البيانات لوضع المستخدمين المتعددين
                    var multiUserQuery = $"ALTER DATABASE [{databaseName}] SET MULTI_USER";
                    using (var command = new SqlCommand(multiUserQuery, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }

                OnProgressChanged(100);
                OnStatusChanged("تم استعادة النسخة الاحتياطية بنجاح");
                return true;
            }
            catch (Exception ex)
            {
                OnStatusChanged($"خطأ في استعادة النسخة الاحتياطية: {ex.Message}");
                throw;
            }
        }

        public bool ValidateBackupFile(string backupPath)
        {
            try
            {
                if (!File.Exists(backupPath))
                    return false;

                // فحص بسيط لصحة ملف النسخة الاحتياطية
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var validateQuery = @"
                        RESTORE HEADERONLY 
                        FROM DISK = @BackupPath";

                    using (var command = new SqlCommand(validateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BackupPath", backupPath);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public BackupInfo GetBackupInfo(string backupPath)
        {
            try
            {
                if (!File.Exists(backupPath))
                    return null;

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var infoQuery = @"
                        RESTORE HEADERONLY 
                        FROM DISK = @BackupPath";

                    using (var command = new SqlCommand(infoQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BackupPath", backupPath);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var fileInfo = new FileInfo(backupPath);
                                
                                return new BackupInfo
                                {
                                    DatabaseName = reader["DatabaseName"].ToString(),
                                    BackupStartDate = Convert.ToDateTime(reader["BackupStartDate"]),
                                    BackupFinishDate = Convert.ToDateTime(reader["BackupFinishDate"]),
                                    BackupSize = Convert.ToInt64(reader["BackupSize"]),
                                    CompressedBackupSize = Convert.ToInt64(reader["CompressedBackupSize"]),
                                    FilePath = backupPath,
                                    FileSize = fileInfo.Length,
                                    ServerName = reader["ServerName"].ToString(),
                                    DatabaseVersion = reader["DatabaseVersion"].ToString()
                                };
                            }
                        }
                    }
                }

                return null;
            }
            catch
            {
                return null;
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

        protected virtual void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(this, new ProgressEventArgs(progress));
        }

        protected virtual void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(this, status);
        }
    }

    public class ProgressEventArgs : EventArgs
    {
        public int Progress { get; }

        public ProgressEventArgs(int progress)
        {
            Progress = progress;
        }
    }

    public class BackupInfo
    {
        public string DatabaseName { get; set; }
        public DateTime BackupStartDate { get; set; }
        public DateTime BackupFinishDate { get; set; }
        public long BackupSize { get; set; }
        public long CompressedBackupSize { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ServerName { get; set; }
        public string DatabaseVersion { get; set; }
    }
}