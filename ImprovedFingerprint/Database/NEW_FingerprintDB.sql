-- نظام إدارة البصمة - قاعدة البيانات المحسنة
-- ZKTeco U350 Fingerprint Management System
-- تاريخ الإنشاء: 2024
-- الإصدار: 2.0

-- إنشاء قاعدة البيانات
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'NEW_FingerprintDB')
BEGIN
    CREATE DATABASE [NEW_FingerprintDB]
    COLLATE Arabic_CI_AS
END
GO

USE [NEW_FingerprintDB]
GO

-- ==========================================
-- جدول الموظفين (Employees)
-- ==========================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[Employees] (
        [EmployeeId] INT IDENTITY(1,1) NOT NULL,
        [EmployeeNumber] NVARCHAR(50) NOT NULL,
        [FullName] NVARCHAR(100) NOT NULL,
        [Department] NVARCHAR(100) NULL,
        [Position] NVARCHAR(100) NULL,
        [HireDate] DATETIME NOT NULL,
        [PhoneNumber] NVARCHAR(20) NULL,
        [Email] NVARCHAR(100) NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [DeviceUserId] INT NOT NULL,
        [FingerprintTemplate] VARBINARY(MAX) NULL,
        [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
        [ModifiedDate] DATETIME NULL,
        [Notes] NVARCHAR(500) NULL,
        [Shift] NVARCHAR(50) NULL,
        
        CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
        CONSTRAINT [UK_Employees_EmployeeNumber] UNIQUE ([EmployeeNumber]),
        CONSTRAINT [UK_Employees_DeviceUserId] UNIQUE ([DeviceUserId])
    )
    
    -- إنشاء الفهارس
    CREATE NONCLUSTERED INDEX [IX_Employees_FullName] ON [dbo].[Employees] ([FullName])
    CREATE NONCLUSTERED INDEX [IX_Employees_Department] ON [dbo].[Employees] ([Department])
    CREATE NONCLUSTERED INDEX [IX_Employees_IsActive] ON [dbo].[Employees] ([IsActive])
END
GO

-- ==========================================
-- جدول سجلات الحضور (AttendanceRecords)
-- ==========================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='AttendanceRecords' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[AttendanceRecords] (
        [RecordId] INT IDENTITY(1,1) NOT NULL,
        [EmployeeId] INT NULL,
        [EmployeeNumber] NVARCHAR(50) NOT NULL,
        [EmployeeName] NVARCHAR(100) NULL,
        [AttendanceDateTime] DATETIME NOT NULL,
        [Type] INT NOT NULL, -- 0=CheckIn, 1=CheckOut
        [Source] INT NOT NULL DEFAULT 0, -- 0=Device, 1=Manual
        [DeviceId] NVARCHAR(50) NULL,
        [Notes] NVARCHAR(500) NULL,
        [IsProcessed] BIT NOT NULL DEFAULT 0,
        [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
        [Shift] NVARCHAR(50) NULL,
        [WorkingHours] TIME NULL,
        [IsLate] BIT NOT NULL DEFAULT 0,
        [IsEarlyLeave] BIT NOT NULL DEFAULT 0,
        [LateMinutes] INT NULL,
        [EarlyLeaveMinutes] INT NULL,
        
        CONSTRAINT [PK_AttendanceRecords] PRIMARY KEY CLUSTERED ([RecordId] ASC),
        CONSTRAINT [FK_AttendanceRecords_Employees] FOREIGN KEY ([EmployeeId]) 
            REFERENCES [dbo].[Employees] ([EmployeeId]) ON DELETE SET NULL
    )
    
    -- إنشاء الفهارس
    CREATE NONCLUSTERED INDEX [IX_AttendanceRecords_EmployeeNumber] ON [dbo].[AttendanceRecords] ([EmployeeNumber])
    CREATE NONCLUSTERED INDEX [IX_AttendanceRecords_AttendanceDateTime] ON [dbo].[AttendanceRecords] ([AttendanceDateTime])
    CREATE NONCLUSTERED INDEX [IX_AttendanceRecords_Type] ON [dbo].[AttendanceRecords] ([Type])
    CREATE NONCLUSTERED INDEX [IX_AttendanceRecords_IsProcessed] ON [dbo].[AttendanceRecords] ([IsProcessed])
    CREATE NONCLUSTERED INDEX [IX_AttendanceRecords_Date_Employee] ON [dbo].[AttendanceRecords] 
        ([AttendanceDateTime], [EmployeeNumber]) INCLUDE ([Type], [Source])
END
GO

-- ==========================================
-- جدول إعدادات الأوقات (TimeSettings)
-- ==========================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TimeSettings' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[TimeSettings] (
        [SettingId] INT IDENTITY(1,1) NOT NULL,
        [ShiftName] NVARCHAR(100) NOT NULL,
        [CheckInStartTime] TIME NOT NULL,
        [CheckInEndTime] TIME NOT NULL,
        [CheckOutStartTime] TIME NOT NULL,
        [CheckOutEndTime] TIME NOT NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
        [ModifiedDate] DATETIME NULL,
        [Notes] NVARCHAR(500) NULL,
        
        CONSTRAINT [PK_TimeSettings] PRIMARY KEY CLUSTERED ([SettingId] ASC)
    )
    
    -- إدراج الإعدادات الافتراضية للفترات الثلاث
    INSERT INTO [dbo].[TimeSettings] 
        ([ShiftName], [CheckInStartTime], [CheckInEndTime], [CheckOutStartTime], [CheckOutEndTime], [Notes])
    VALUES 
        (N'الوردية الصباحية', '06:00:00', '10:59:00', '11:00:00', '13:00:00', N'الفترة الصباحية من 6:00 إلى 13:00'),
        (N'الوردية المسائية', '14:00:00', '18:59:00', '19:00:00', '21:00:00', N'الفترة المسائية من 14:00 إلى 21:00'),
        (N'الوردية الليلية', '22:00:00', '02:59:00', '03:00:00', '05:00:00', N'الفترة الليلية من 22:00 إلى 05:00 - تمتد لليوم التالي')
END
GO

-- ==========================================
-- جدول أنواع المستخدمين (UserType)
-- ==========================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='UserType' AND xtype='U')
BEGIN
    CREATE TABLE [dbo].[UserType] (
        [UserId] INT IDENTITY(1,1) NOT NULL,
        [Username] NVARCHAR(50) NOT NULL,
        [Password] NVARCHAR(100) NOT NULL,
        [Role] NVARCHAR(50) NOT NULL,
        [FullName] NVARCHAR(100) NOT NULL,
        [IsActive] BIT NOT NULL DEFAULT 1,
        [CreatedDate] DATETIME NOT NULL DEFAULT GETDATE(),
        [LastLoginDate] DATETIME NULL,
        
        CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([UserId] ASC),
        CONSTRAINT [UK_UserType_Username] UNIQUE ([Username])
    )
    
    -- إدراج المستخدم الافتراضي
    INSERT INTO [dbo].[UserType] ([Username], [Password], [Role], [FullName])
    VALUES ('admin', 'admin123', N'مدير النظام', N'مدير النظام')
END
GO

PRINT N'تم إنشاء قاعدة البيانات وجميع الكائنات بنجاح'
PRINT N'Database NEW_FingerprintDB created successfully with all objects'
GO