USE [NEW_FingerprintDB]
GO
/****** Object:  User [abubakr]    Script Date: 29/05/2025 06:59:34 م ******/
CREATE USER [abubakr] FOR LOGIN [abubakr] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[VerificationMode] [int] NULL,
	[InOutMode] [int] NULL,
 CONSTRAINT [PK_Attendance_Composite] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[DateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeductionSettings]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeductionSettings](
	[SettingID] [int] IDENTITY(1,1) NOT NULL,
	[DeductionSource] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[LastModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[ConditionName] [nvarchar](100) NOT NULL,
	[DiscountAmount] [decimal](10, 2) NOT NULL,
	[DeductionSourceID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[UserID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Privilege] [int] NULL CONSTRAINT [DF_Privilege]  DEFAULT ((0)),
	[Enabled] [bit] NULL CONSTRAINT [DF_Enabled]  DEFAULT ((1)),
	[ProtectionType] [nvarchar](50) NULL,
	[FinancialID] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[GenderType] [nvarchar](20) NULL,
	[EmployeeStatus] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Department] [nvarchar](100) NULL,
	[JobTitle] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[CardNumber] [nvarchar](50) NULL,
	[RegistrationDate] [date] NULL CONSTRAINT [DF_RegistrationDate]  DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSalary]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSalary](
	[SalaryID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[BasicSalary] [decimal](10, 2) NOT NULL DEFAULT ((0)),
	[Bonus] [decimal](10, 2) NOT NULL DEFAULT ((0)),
	[EffectiveDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[IsActive] [bit] NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSchedules]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSchedules](
	[EmployeeScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[ScheduleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fingerprints]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fingerprints](
	[EmployeeID] [nvarchar](50) NOT NULL,
	[FingerIndex] [int] NOT NULL,
	[Template] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[FingerIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holidays](
	[HolidayID] [int] IDENTITY(1,1) NOT NULL,
	[HolidayDate] [date] NULL,
	[HolidayName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[HolidayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Leaves]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leaves](
	[LeaveID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[LeaveDate] [date] NULL,
	[LeaveType] [nvarchar](50) NULL,
	[Reason] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[PermissionDate] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Reason] [nvarchar](max) NULL,
	[Status] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleName] [nvarchar](100) NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[ShiftID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[ShiftID] [int] IDENTITY(1,1) NOT NULL,
	[ShiftName] [nvarchar](50) NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[CheckInGracePeriod] [int] NULL,
	[CheckOutGracePeriod] [int] NULL,
	[CheckInStart] [time](7) NULL,
	[CheckInEnd] [time](7) NULL,
	[ShiftType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ShiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShiftWorkingDays]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShiftWorkingDays](
	[ShiftID] [int] NULL,
	[DayOfWeek] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp_DailyAttendanceReport]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Temp_DailyAttendanceReport](
	[UserID] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[ShiftName] [nvarchar](100) NULL,
	[AttendanceDate] [date] NULL,
	[DayOfWeek] [nvarchar](20) NULL,
	[ScheduledCheckIn] [varchar](20) NULL,
	[ActualCheckIn] [varchar](20) NULL,
	[Status] [nvarchar](100) NULL,
	[LeaveType] [nvarchar](50) NULL,
	[PermissionStatus] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](20) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingDays]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingDays](
	[DayOfWeek] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DayOfWeek] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingDays_Evening]    Script Date: 29/05/2025 06:59:34 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingDays_Evening](
	[DayOfWeek] [nvarchar](50) NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DeductionSettings] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[DeductionSettings] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD FOREIGN KEY([DeductionSourceID])
REFERENCES [dbo].[DeductionSettings] ([SettingID])
GO
ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Employees] ([UserID])
GO
ALTER TABLE [dbo].[EmployeeSchedules]  WITH CHECK ADD FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedules] ([ScheduleID])
GO
ALTER TABLE [dbo].[EmployeeSchedules]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Employees] ([UserID])
GO
ALTER TABLE [dbo].[Fingerprints]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Leaves]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Employees] ([UserID])
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Employees] ([UserID])
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([ShiftID])
REFERENCES [dbo].[Shifts] ([ShiftID])
GO
ALTER TABLE [dbo].[Discounts]  WITH CHECK ADD CHECK  (([DiscountAmount]>=(0)))
GO
