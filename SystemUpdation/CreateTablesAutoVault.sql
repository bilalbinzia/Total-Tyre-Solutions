
-----------------------------------------------------
USE [AutoVault]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[State]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Initial] [varchar](5) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[City]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_City] ON [dbo].[City] 
(
	[Name] ASC,
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZipCode]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ZipCode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
	[CityID] [int] NULL,
	[ZipID] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ZipCode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PayWeekStartOn]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PayWeekStartOn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PayWeekStartOn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Warehouse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoCode] [varchar](max) NULL,
	[CoName] [varchar](max) NULL,
	[CoAddress] [varchar](max) NULL,
	[CoPhone] [varchar](max) NULL,
	[CoFax] [varchar](max) NULL,
	[CoEmail] [varchar](max) NULL,
	[CoType] [varchar](max) NULL,
	[CoFinYearStrMonth] [int] NULL,
	[BarNo] [varchar](100) NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
	[CityID] [int] NULL,
	[ZipCode] [int] NULL,
	[AreaCode] [int] NULL,
	[AreaCode1] [int] NULL,
	[AreaCode2] [int] NULL,
	[After8hrsRegular] [bit] NULL,
	[After8hrsTime] [bit] NULL,
	[After8hrsDTime] [bit] NULL,
	[After10hrsRegular] [bit] NULL,
	[After10hrsTime] [bit] NULL,
	[After10hrsDTime] [bit] NULL,
	[After12hrsRegular] [bit] NULL,
	[After12hrsTime] [bit] NULL,
	[After12hrsDTime] [bit] NULL,
	[AfterhrsADay] [int] NULL,
	[AfterhrsADayRegular] [bit] NULL,
	[AfterhrsADayTime] [bit] NULL,
	[AfterhrsADayDTime] [bit] NULL,
	[HolidayhrsRegular] [bit] NULL,
	[HolidayhrsTime] [bit] NULL,
	[HolidayhrsDTime] [bit] NULL,
	[PayWeekStartOn] [int] NULL,
	[RoundPunchesTo] [int] NULL,
	[PickupVehicleTime] [datetime2](7) NULL,
	[NoOfBays] [int] NULL,
	[IsOverTime] [bit] NULL,
	[OverTimerHrs] [decimal](18, 0) NULL,
	[IsHolidayPaid] [bit] NULL,
	[IsMonday] [bit] NULL,
	[MondayTimeStart] [datetime2](7) NULL,
	[MondayTimeEnd] [datetime2](7) NULL,
	[MondayHrs] [decimal](18, 2) NULL,
	[IsTuesday] [bit] NULL,
	[TuesdayTimeStart] [datetime2](7) NULL,
	[TuesdayTimeEnd] [datetime2](7) NULL,
	[TuesdayHrs] [decimal](18, 2) NULL,
	[IsWednesday] [bit] NULL,
	[WednesdayTimeStart] [datetime2](7) NULL,
	[WednesdayTimeEnd] [datetime2](7) NULL,
	[WednesdayHrs] [decimal](18, 2) NULL,
	[IsThursday] [bit] NULL,
	[ThursdayTimeStart] [datetime2](7) NULL,
	[ThursdayTimeEnd] [datetime2](7) NULL,
	[ThursdayHrs] [decimal](18, 2) NULL,
	[IsFriday] [bit] NULL,
	[FridayTimeStart] [datetime2](7) NULL,
	[FridayTimeEnd] [datetime2](7) NULL,
	[FridayHrs] [decimal](18, 2) NULL,
	[IsSaturday] [bit] NULL,
	[SaturdayTimeStart] [datetime2](7) NULL,
	[SaturdayTimeEnd] [datetime2](7) NULL,
	[SaturdayHrs] [decimal](18, 2) NULL,
	[IsSunday] [bit] NULL,
	[SundayTimeStart] [datetime2](7) NULL,
	[SundayTimeEnd] [datetime2](7) NULL,
	[SundayHrs] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](250) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[CompanyLogo] [image] NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LaborDepartment]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LaborDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[DepartmentColor] [varchar](50) NOT NULL,
	[DfltHrs] [int] NOT NULL,
	[SortingOrder] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_LaborDepartment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeComBaseOn]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeComBaseOn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_EmployeeComBaseOn] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NULL,
	[GroupLevel] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](50) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoID] [int] NULL,
	[StoreID] [int] NULL,
	[DepartmentID] [int] NULL,
	[LaborDepID] [int] NULL,
	[UserGroupID] [int] NULL,
	[Initial] [char](3) NULL,
	[RegDate] [date] NULL,
	[Name] [varchar](50) NULL,
	[Phone1] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[IsMech] [bit] NULL,
	[IsSalRep] [bit] NULL,
	[LaborCommPer] [decimal](18, 2) NULL,
	[PartsCommPer] [decimal](18, 2) NULL,
	[CommisionBaseOn] [int] NULL,
	[Wages] [decimal](18, 0) NULL,
	[IsLogin] [bit] NULL,
	[LoginID] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[IsOverTime] [bit] NULL,
	[OverTimerHrs] [decimal](18, 0) NULL,
	[IsHolidayPaid] [bit] NULL,
	[IsMonday] [bit] NULL,
	[MondayTimeStart] [datetime2](7) NULL,
	[MondayTimeEnd] [datetime2](7) NULL,
	[MondayHrs] [decimal](18, 2) NULL,
	[IsTuesday] [bit] NULL,
	[TuesdayTimeStart] [datetime2](7) NULL,
	[TuesdayTimeEnd] [datetime2](7) NULL,
	[TuesdayHrs] [decimal](18, 2) NULL,
	[IsWednesday] [bit] NULL,
	[WednesdayTimeStart] [datetime2](7) NULL,
	[WednesdayTimeEnd] [datetime2](7) NULL,
	[WednesdayHrs] [decimal](18, 2) NULL,
	[IsThursday] [bit] NULL,
	[ThursdayTimeStart] [datetime2](7) NULL,
	[ThursdayTimeEnd] [datetime2](7) NULL,
	[ThursdayHrs] [decimal](18, 2) NULL,
	[IsFriday] [bit] NULL,
	[FridayTimeStart] [datetime2](7) NULL,
	[FridayTimeEnd] [datetime2](7) NULL,
	[FridayHrs] [decimal](18, 2) NULL,
	[IsSaturday] [bit] NULL,
	[SaturdayTimeStart] [datetime2](7) NULL,
	[SaturdayTimeEnd] [datetime2](7) NULL,
	[SaturdayHrs] [decimal](18, 2) NULL,
	[IsSunday] [bit] NULL,
	[SundayTimeStart] [datetime2](7) NULL,
	[SundayTimeEnd] [datetime2](7) NULL,
	[SundayHrs] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CNIC' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Initial'
GO
/****** Object:  Table [dbo].[EmployeeLeave]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeLeave](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[LeaveDate] [date] NULL,
	[LeaveStatus] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeAttendance]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeAttendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[AttendanceDate] [date] NULL,
	[CheckIn] [time](7) NULL,
	[CheckOut] [time](7) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_TeacherAttendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleMake](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleColor]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleColor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_VehicleColor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleYear]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleYear](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_VehicleYearModel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleTransmission]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleTransmission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_VehicleTransmission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseBay]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseBay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseBay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WorkOrderAutoNo]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorkOrderAutoNo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WorkOrderAutoNo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseSettings]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseSettings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BackColor] [int] NULL,
	[ForeColor] [int] NULL,
	[BackgroundPix] [image] NULL,
	[UseSSL] [bit] NULL,
	[UseStartTLS] [bit] NULL,
	[UsethefollowinginsteadoftheEmailServerdefinednintheSetuptab] [bit] NULL,
	[UseWorldpactoorderparts] [bit] NULL,
	[SetWorldpactoExportratherthanExportOrderandmanuallyexporttheitems] [bit] NULL,
	[UseNexparttoorderparts] [bit] NULL,
	[UseEpicortoorderparts] [bit] NULL,
	[PrintWindshieldStickers] [bit] NULL,
	[GodexPrinter] [bit] NULL,
	[CognitiveDLX] [bit] NULL,
	[OlderDelSolLX] [bit] NULL,
	[Normallyprintpricesonlabels] [bit] NULL,
	[PrintPortraitWide] [bit] NULL,
	[UseAllDataOnline] [bit] NULL,
	[AlloworderingpartsthroughTABS] [bit] NULL,
	[UseTireWarehousestocheckstockandorderatPOS] [bit] NULL,
	[ConvertimportedtexttoUpperCase] [bit] NULL,
	[ShowQOHfromlastimportinVenderCatalog] [bit] NULL,
	[DontcreateVendorInvoiceswhenimportingparts] [bit] NULL,
	[Usedefaultmarkupforpriceswhenorderingparts] [bit] NULL,
	[UseRealTimeLaborGuideinstedofInfotraxx] [bit] NULL,
	[UseUPSWorldShip] [bit] NULL,
	[UseiPaytomakesendAmPacpaymentinformation] [bit] NULL,
	[DisabletheCarfaxfeature] [bit] NULL,
	[DisabletheCarfaxRecallNoticenotification] [bit] NULL,
	[UseCashDrawer] [bit] NULL,
	[Openforchecks] [bit] NULL,
	[Alwaysopendrawer] [bit] NULL,
	[Prompttoretryopeningdrawer] [bit] NULL,
	[UseSignaturePadwhenprintingWorkorders] [bit] NULL,
	[UseSignaturePadwhenprintingInvoices] [bit] NULL,
	[UseEasyPay] [bit] NULL,
	[StreamlinedInterface] [bit] NULL,
	[ShowWheelInfobyDefaultintheModelGuide] [bit] NULL,
	[SchedulebyMechanic] [bit] NULL,
	[UsevehiclesfrombothUSACanada] [bit] NULL,
	[TabletModeThiscomputerisaTabletPC] [bit] NULL,
	[Nevershowothercustomersvehicles] [bit] NULL,
	[ShowCompanyNamebeforeFirstLastName] [bit] NULL,
	[GiveWOMessagesonPaymentsonAcct] [bit] NULL,
	[AcceptNoChecksbydefaultfornewcustomers] [bit] NULL,
	[DontautomaticallyprintAdjustmentsandROAs] [bit] NULL,
	[ShowallstoresbydefaultwhenviewingCustomers] [bit] NULL,
	[DisableAutoApplybuttonwhenmakingpayments] [bit] NULL,
	[KeepanOutsidePartAuditTrail] [bit] NULL,
	[DontcreateVendorBillsfromwithinaWorkorder] [bit] NULL,
	[NormallycreateVendorBillswithOutsideParts] [bit] NULL,
	[NormallyputBillscreatedfromOutsidePartsonHold] [bit] NULL,
	[AllowcreatingBillsinaWorkorderbeforeInvoicing] [bit] NULL,
	[IgnoreFutureBillswhenageingVendors] [bit] NULL,
	[WhenpayingBillsshowBillsonHold] [bit] NULL,
	[AllowdeletionofpostedBillsnonaccountingonly] [bit] NULL,
	[Reagevendorsbyinvoicedatenotduedate] [bit] NULL,
	[UseaseparateGLpostingdateforBills] [bit] NULL,
	[MaketheOutsidePriceMatrixLinear] [bit] NULL,
	[ReportonVendorsseparatelyateachstore] [bit] NULL,
	[Dontshowpackagesbydefaultwhensearching] [bit] NULL,
	[CreateRecommendedServicefromredandyellowInspectionlines] [bit] NULL,
	[WhensendingDeclinedServicestotheWorkordersendFirstLineonly] [bit] NULL,
	[DontautomaticallyprinttheInspectionSheetwiththefinalInvoice] [bit] NULL,
	[AlwaysPrinttheMechanicInspectionSheetwiththeWorkorder] [bit] NULL,
	[UsericonretherthanGoodOKBad] [bit] NULL,
	[Startnewinspectionswithlinesblankuninspectedratherthangreeninspected] [bit] NULL,
	[PrinttheWorkordernumberontheStatements] [bit] NULL,
	[Ageeachstoreseparatelyratherthanconsolidatingstatements] [bit] NULL,
	[ReagecustomerbyduedatenotInvoicedate] [bit] NULL,
	[UseFutureDuewhenAging] [bit] NULL,
	[PrintBalanceForwardnotOpenItemStatements] [bit] NULL,
	[HideCustomerNumberonCustomerStatements] [bit] NULL,
	[HidePaymentBreakdownonCustomerStatements] [bit] NULL,
	[UseAlternateAddress] [bit] NULL,
	[UseChargeltProCreditDebitCardService] [bit] NULL,
	[Tracknoncommissionablelabor] [bit] NULL,
	[days30overdue] [bit] NULL,
	[days60overdue] [bit] NULL,
	[days90overdue] [bit] NULL,
	[Neverwarn] [bit] NULL,
	[NormallyPostInventoryAdjustmentstoGL] [bit] NULL,
	[BaseInventoryPricesonProfitratherthanMarkup] [bit] NULL,
	[BaseReorderingonQuantityonhandnotAvailable] [bit] NULL,
	[HideTypeatfirstwhensearchingforInventory] [bit] NULL,
	[NormallyShowCostwheninvoicing] [bit] NULL,
	[DontclearItemSearchboxeswhileinaWO] [bit] NULL,
	[BaseMarginonCatalogCostnotAverageCost] [bit] NULL,
	[NormallyhideobsoleteiteminInventoryEntry] [bit] NULL,
	[PostDiscountedAmountstoInventoryHistory] [bit] NULL,
	[Normallyadjustinventorycostsaccordingtothefreight] [bit] NULL,
	[WithClaimsforcecosttoequalprice] [bit] NULL,
	[Dontallowdeletionofitemsifthereisaquantityonhand] [bit] NULL,
	[OnlyshowthecurrentstoreininventoryHistorytab] [bit] NULL,
	[StartnewAdjustmentbatchonopeningtheInvwindow] [bit] NULL,
	[NormallyupdateCatalogCostsonPOsAdjustments] [bit] NULL,
	[NormallycopyCatalogCoststoallstoreswhensaving] [bit] NULL,
	[DontadjustWOcostwhenorderingstockeditemsinaWO] [bit] NULL,
	[UseLastCostnotCatalogCostonPOsAdjustments] [bit] NULL,
	[AdjustCostofGoodsSoldwhensellingbeforereceiving] [bit] NULL,
	[DisablecreatingaBillfromaPO] [bit] NULL,
	[TrackQuantitiesatBinLocations] [bit] NULL,
	[ShopCopy] [bit] NULL,
	[CustomerCopy] [bit] NULL,
	[StoreCopy] [bit] NULL,
	[PreviewWorkordersandInvoicesinsteadofprintingmultiplecopies] [bit] NULL,
	[LeaveCompanyNameblankonWorkorderandInvoices] [bit] NULL,
	[EmailCustomerswithValidEmailAddressesCopiesofInvoices] [bit] NULL,
	[AllowFaxingwithinternalfaxmodemOlderWindowsversionsonly] [bit] NULL,
	[AllowforalongCompanyNameuseasmallerfont] [bit] NULL,
	[ShowManufacturerPartinsteadofBrand] [bit] NULL,
	[PrintCustomerContactonWorkorderandInvoice] [bit] NULL,
	[PrintaspecialpagewithWorkorders] [bit] NULL,
	[PrintaspecialpagewithInvoices] [bit] NULL,
	[TopofInvoice] [bit] NULL,
	[MiddleofInvoice] [bit] NULL,
	[BottomofInvoice] [bit] NULL,
	[PrintSaleCategoriesSummary] [bit] NULL,
	[PrintItemGroupSummary] [bit] NULL,
	[PrintSaleCategoriesSubtotals] [bit] NULL,
	[PrintSalesRepsMechanics] [bit] NULL,
	[PrintPaymentsBills] [bit] NULL,
	[PrintNewCustomers] [bit] NULL,
	[PrintBankingSummary] [bit] NULL,
	[NormallyDONTposttoQuickBooksattheendoftheday] [bit] NULL,
	[SendTermswhenpostingBillstoQuickBooksTermswiththesamenamemustbesetupthere] [bit] NULL,
	[UseGeneralLedgerClasses] [bit] NULL,
	[ShowAccountNumbersontheTrialBalance] [bit] NULL,
	[MergethePeceiptsonAccountjournalwiththeSalesjournal] [bit] NULL,
	[IncludeablanklineattheendofPeachtreesGeneralcsv] [bit] NULL,
	[ConsolidatelinesonTireQuotes] [bit] NULL,
	[Printlnvoicelinesinalargerfont] [bit] NULL,
	[PrintTorqueonWorkordersandinvoices] [bit] NULL,
	[PrintthestandardPickuptimeonallnewWOs] [bit] NULL,
	[DontprintthecustomersbalanceonInvoices] [bit] NULL,
	[ReversecostofitemaddtoendofDescription] [bit] NULL,
	[RequireaPasswordtoprintorsaveaWorkorder] [bit] NULL,
	[HidephonenumberonShopCopy] [bit] NULL,
	[HideCodecolumn] [bit] NULL,
	[HidetheTimePrinted] [bit] NULL,
	[ChangetaxratewithoutchangingSaleCat] [bit] NULL,
	[RequireResaleNumberifnotpayingsalestax] [bit] NULL,
	[Taxitemsafterthediscounts] [bit] NULL,
	[SeparatetaxesCanadianGSTPST] [bit] NULL,
	[DonttaxFETifFETisusedforsomethingelse] [bit] NULL,
	[LeavethevehicleblankonnewWorkorders] [bit] NULL,
	[Fillinlicenseplatewhensavingifblank] [bit] NULL,
	[UseNOColorCodesinSalesEntry] [bit] NULL,
	[DisabletheTotalbutton] [bit] NULL,
	[DontrecalculateAvailablewhenInvoicing] [bit] NULL,
	[Nocopynegateoldinvoicesifcantchangedate] [bit] NULL,
	[Checkforduplicateplates] [bit] NULL,
	[Usefirstshippingaddressifitexists] [bit] NULL,
	[RequirecustomerentryrightstochangeSalesCat] [bit] NULL,
	[RequireaCreditMgrpwtochangeSalesCat] [bit] NULL,
	[RequireenteringthemileagetosaveWorkorder] [bit] NULL,
	[RequireselectingasalesreptosaveWorkorderorInvoice] [bit] NULL,
	[RequireaMechaniconallWorkorderLinesbeforesaving] [bit] NULL,
	[RequireaMechaniconallWorkorderLinesbeforeInvoicing] [bit] NULL,
	[RequireReferredbyfornewcustomerstoInvoice] [bit] NULL,
	[RequireenteringEmailaddressfornewcustomers] [bit] NULL,
	[RequireSelectingaCashiertoInvoice] [bit] NULL,
	[Dontfillintheamountonaccountwheninvoicing] [bit] NULL,
	[AllowChangingpricesonnondiscountableitems] [bit] NULL,
	[Allowchangingcostsonstockeditemsnotrecommended] [bit] NULL,
	[ChangepricelevelwithoutchangingSalesCat] [bit] NULL,
	[DontletMechanicbeselectedforentireWorkorder] [bit] NULL,
	[Dontwarnwhenstartinga2ndWOforaCustomer] [bit] NULL,
	[UpperLowerCaseforCityonZipCodeLookup] [bit] NULL,
	[Allowsalesrepstoselectnoncommissionlines] [bit] NULL,
	[Dontallowmechanicstoselectnoncommissionllines] [bit] NULL,
	[DontallowchangingrepifassignedinCustomerEntry] [bit] NULL,
	[Dontallowchangingdescriptiononpartsandtires] [bit] NULL,
	[Promptfortirepressurewheninvoicing] [bit] NULL,
	[ApplyentireinvoicetomainSalesRep] [bit] NULL,
	[DontallowchangingpricesintheInventorySearchwindow] [bit] NULL,
	[UsethepriceleveloftheSalecategoryratherthanthecustomerspricelevel] [bit] NULL,
	[Dontallowmarkingjobsasdonebeforeinvoicing] [bit] NULL,
	[ToInvoice] [bit] NULL,
	[ToSave] [bit] NULL,
	[Tosave2] [bit] NULL,
	[RequirePassword] [bit] NULL,
	[Vendor] [bit] NULL,
	[Reference] [bit] NULL,
	[Costs] [bit] NULL,
	[Resizetofit] [bit] NULL,
	[OptionalUseSSl] [bit] NULL,
	[OptionalUseStartTLS] [bit] NULL,
	[SMTPHostName] [text] NULL,
	[SMTPpassword] [text] NULL,
	[SMPTport] [text] NULL,
	[SMTPUserName] [text] NULL,
	[EmailFromAddress] [text] NULL,
	[EmailReplyToAddress] [text] NULL,
	[EmailHeloHost] [text] NULL,
	[TemplateForNewCustomer] [int] NULL,
	[TemplateForReminderEmails] [int] NULL,
	[PostcardsNewCustPostcard] [int] NULL,
	[PostcardsReminderCustPostcard] [int] NULL,
	[VehicleStatusNone] [text] NULL,
	[VehicleStatusAppointment] [text] NULL,
	[VehicleStatusArrived] [text] NULL,
	[VehicleStatusInProgress] [text] NULL,
	[VehicleStatusOnHold] [text] NULL,
	[VehicleStatusCompleted] [text] NULL,
	[OptionalSMTPHostName] [text] NULL,
	[OptionalSMPTPort] [text] NULL,
	[OptionalSMTPUserName] [text] NULL,
	[OptionalSMTPPassword] [text] NULL,
	[OptionalEmailFromAddress] [text] NULL,
	[OptionalEmailReplyToAddress] [text] NULL,
	[OptionalEmailHeloHost] [text] NULL,
	[EmailPostcardsTextMessagingAddress] [text] NULL,
	[WorldpacVendorforWorldpacPurchasing] [int] NULL,
	[WorldpacListeningPort] [int] NULL,
	[nexpartNameOfSupplier] [text] NULL,
	[nexpartSelectAVendor] [int] NULL,
	[nexpartLogin] [text] NULL,
	[nexpartPassword] [text] NULL,
	[nexpartURL] [text] NULL,
	[nexpartOrderOfPreference] [int] NULL,
	[napaVendor] [int] NULL,
	[napaStoreId] [int] NULL,
	[napaPassword] [text] NULL,
	[epicorUserId] [nchar](10) NULL,
	[epicorPassword] [nchar](10) NULL,
	[NameofStickerPrinter] [nchar](10) NULL,
	[NameOfComputerWithPrinter] [nchar](10) NULL,
	[MostCommonGradeOfOil] [nchar](10) NULL,
	[PrinterTextOffset] [nchar](10) NULL,
	[ReturnAfterHowManyMiles] [int] NULL,
	[Months] [int] NULL,
	[BarcodeNameOfPrinter] [text] NULL,
	[BarcodeComputerWithPrinter] [text] NULL,
	[DefaultMessageForTheLabel] [text] NULL,
	[LaborGuidAllDataOnlineLoginName] [varchar](50) NULL,
	[LaborGuidAllDataOnlinePassword] [text] NULL,
	[LaborGuidIdentifixLoginName] [varchar](50) NULL,
	[LaborGuidIdentifixPassword] [text] NULL,
	[LaborGuidPathForRealTimeLaborGuide] [text] NULL,
	[LaborGuidThePathOfMitchellsESTHISTFolder] [text] NULL,
	[Carquest] [text] NULL,
	[CarquestLoginName] [text] NULL,
	[CarquestLoginPassword] [text] NULL,
	[CarquestVendor] [int] NULL,
	[MyAutoServiceAppointmentUserId] [varchar](50) NULL,
	[MyAutoServiceAppointmentPassword] [text] NULL,
	[LaborInventoryItemforImportedLines] [int] NULL,
	[LaborInventoryItemforImportedLinesPersentToAdd] [int] NULL,
	[OutsidePartForImportedLines] [int] NULL,
	[OutsidePartForImportedLinesPersentToAdd] [int] NULL,
	[BillwhatCustomer] [int] NULL,
	[SignaturePadSelectionBox] [int] NULL,
	[DefaultVehicleNotes] [text] NULL,
	[RecommendedServiceHeader] [text] NULL,
	[RecommendedServiceFooter] [text] NULL,
	[AlternateRemitToAddressCompanyName] [text] NULL,
	[AlternateRemitToAddress] [text] NULL,
	[FinanceChangeAnnualPercentageRate] [int] NULL,
	[FinanceChangeMinimumCharge] [text] NULL,
	[FinanceChangeTermsfortheFinanceCharge] [int] NULL,
	[FinanceChangeForAccountsHowFarBehind] [int] NULL,
	[IfBalanceIs30DaysOld] [text] NULL,
	[IfBalanceIs60DaysOld] [text] NULL,
	[IfBalanceIs90DaysOld] [text] NULL,
	[IfBalanceIs120AndMoreDaysOld] [text] NULL,
	[CreditCard] [text] NULL,
	[TypeOfCard] [int] NULL,
	[Description] [text] NULL,
	[Fee] [int] NULL,
	[Swipe] [int] NULL,
	[CreditCard1Active] [bit] NULL,
	[CreditCard1] [text] NULL,
	[TypeOfCard1] [int] NULL,
	[Description1] [text] NULL,
	[Fee1] [int] NULL,
	[Swipe1] [int] NULL,
	[CreditCard2Active] [bit] NULL,
	[CreditCard2] [text] NULL,
	[TypeOfCard2] [int] NULL,
	[Description2] [text] NULL,
	[Fee2] [int] NULL,
	[Swipe2] [int] NULL,
	[CreditCard3Active] [bit] NULL,
	[CreditCard3] [text] NULL,
	[TypeOfCard3] [int] NULL,
	[Description3] [text] NULL,
	[Fee3] [int] NULL,
	[Swipe3] [int] NULL,
	[CreditCard4Active] [bit] NULL,
	[CreditCard4] [text] NULL,
	[TypeOfCard4] [int] NULL,
	[Description4] [text] NULL,
	[Fee4] [int] NULL,
	[Swipe4] [int] NULL,
	[CreditCard5Active] [bit] NULL,
	[CreditCard5] [text] NULL,
	[TypeOfCard5] [int] NULL,
	[Description5] [text] NULL,
	[Fee5] [int] NULL,
	[Swipe5] [int] NULL,
	[CreditCard6Active] [bit] NULL,
	[CreditCard6] [text] NULL,
	[TypeOfCard6] [int] NULL,
	[Description6] [text] NULL,
	[Fee6] [int] NULL,
	[Swipe6] [int] NULL,
	[CreditCard7Active] [bit] NULL,
	[CreditCardSalesBankAccount] [int] NULL,
	[CreditCardCashDepositGLAcct] [int] NULL,
	[CreditCardPurchasesBankAccount] [int] NULL,
	[DisclaimerForInvoicesOnly1] [text] NULL,
	[DisclaimerForInvoicesOnly2] [text] NULL,
	[CustomerDefaultCashTerms] [int] NULL,
	[CustomerDefaultChgCustTerms] [int] NULL,
	[CustomerDefaultVendTerms] [int] NULL,
	[CustomerDefaultTaxCategory] [int] NULL,
	[CustomerDefaultCashSalesCat] [int] NULL,
	[CustomerDefaultChgSalesCat] [int] NULL,
	[CashDrawerDesiredAmount] [text] NULL,
	[CurrentCashDrawer] [text] NULL,
	[RequireManagementOverrideToInvoiceWhenItWillTakeThemOverTheirCreditLimitByAmount] [int] NULL,
	[RequireManagementOverrideToInvoiceWhenItWillTakeThemOverTheirCreditLimitPersentage] [int] NULL,
	[SaleSettingCashCustomer] [int] NULL,
	[SaleSettingMechanicTracking] [int] NULL,
	[SaleSettingVerbageForDeclinedButton] [text] NULL,
	[SaleSettingRequireAnOverrideIfThereAreOpenChargesOverdueAtLeast] [int] NULL,
	[InventoryAutomaticShopSupplies] [int] NULL,
	[InventoryVerbageForInstalling] [text] NULL,
	[InventorySubtotalItem] [int] NULL,
	[InventoryOnInventoryAdjustmentsUse] [nchar](10) NULL,
	[InventoryHeadingForSecondaryInventorySearchColumn] [text] NULL,
	[InventoryStandardRoundingMethodOverriddenByItemGroups] [int] NULL,
	[InventorySortInventoryBy] [int] NULL,
	[InventorySortPurchaseOrdersBy] [int] NULL,
	[InventoryOutsideTireSurcharge] [int] NULL,
	[InvoiceColor1] [text] NULL,
	[InvoiceColor2] [text] NULL,
	[InvoiceColor3] [text] NULL,
	[InvoiceColor4] [text] NULL,
	[InvoiceHideCat1] [bit] NULL,
	[InvoiceHideCat2] [bit] NULL,
	[InvoiceHideCat3] [bit] NULL,
	[InvoiceHideCat4] [bit] NULL,
	[InvoiceWorkorders1] [text] NULL,
	[InvoiceWorkorders2] [text] NULL,
	[InvoiceWorkorders3] [text] NULL,
	[InvoiceWorkorders4] [text] NULL,
	[InvoiceShop1] [bit] NULL,
	[InvoiceShop2] [bit] NULL,
	[InvoiceShop3] [bit] NULL,
	[InvoiceShop4] [bit] NULL,
	[InvoiceCashInvoice1] [text] NULL,
	[InvoiceCashInvoice2] [text] NULL,
	[InvoiceCashInvoice3] [text] NULL,
	[InvoiceCashInvoice4] [text] NULL,
	[InvoiceChargeInvoices1] [text] NULL,
	[InvoiceChargeInvoices2] [text] NULL,
	[InvoiceChargeInvoices3] [text] NULL,
	[InvoiceChargeInvoices4] [text] NULL,
	[InvoicePrintaSpecialPageWithWorkorders] [nchar](10) NULL,
	[InvoicePrintaSpecialPageWithInvoices] [nchar](10) NULL,
	[InvoiceHeadingForTaxableSubtotal] [text] NULL,
	[InvoiceHeadingForEstimatedSubtotal] [text] NULL,
	[InvoiceHeadingForMakeAndModel] [text] NULL,
	[InvoiceHeadingForFET] [text] NULL,
	[InvoiceFloridaStorageFee] [int] NULL,
	[InvoiceFloridaDiagnosticFee] [int] NULL,
	[InvoiceFloridaHourlyRate] [int] NULL,
	[InvoiceStyle] [int] NULL,
	[DailyReporton] [int] NULL,
	[DailyFirstmonthoftheDailyReportsFiscalYear] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseThemes]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseThemes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BackColor] [varchar](50) NULL,
	[ForeColor] [varchar](50) NULL,
	[BackImage] [image] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseThemes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseServices]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseServices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[PackageWithTax] [decimal](18, 2) NULL,
	[ShowInButton] [bit] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseServices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRptM]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRptM](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[S1] [varchar](max) NULL,
	[S2] [varchar](max) NULL,
	[S3] [varchar](max) NULL,
	[S4] [varchar](max) NULL,
	[S5] [varchar](max) NULL,
	[S6] [varchar](max) NULL,
	[S7] [varchar](max) NULL,
	[S8] [varchar](max) NULL,
	[S9] [varchar](max) NULL,
	[S10] [varchar](max) NULL,
	[S11] [varchar](max) NULL,
	[S12] [varchar](max) NULL,
	[S13] [varchar](max) NULL,
	[S14] [varchar](max) NULL,
	[S15] [varchar](max) NULL,
	[S16] [varchar](max) NULL,
	[S17] [varchar](max) NULL,
	[S18] [varchar](max) NULL,
	[S19] [varchar](max) NULL,
	[S20] [varchar](max) NULL,
	[S21] [varchar](max) NULL,
	[S22] [varchar](max) NULL,
	[S23] [varchar](max) NULL,
	[S24] [varchar](max) NULL,
	[S25] [varchar](max) NULL,
	[S26] [varchar](max) NULL,
	[S27] [varchar](max) NULL,
	[S28] [varchar](max) NULL,
	[S29] [varchar](max) NULL,
	[S30] [varchar](max) NULL,
	[S31] [varchar](max) NULL,
	[S32] [varchar](max) NULL,
	[S33] [varchar](max) NULL,
	[S34] [varchar](max) NULL,
	[S35] [varchar](max) NULL,
	[S36] [varchar](max) NULL,
	[S37] [varchar](max) NULL,
	[S38] [varchar](max) NULL,
	[S39] [varchar](max) NULL,
	[S40] [varchar](max) NULL,
	[S41] [varchar](max) NULL,
	[S42] [varchar](max) NULL,
	[S43] [varchar](max) NULL,
	[S44] [varchar](max) NULL,
	[S45] [varchar](max) NULL,
	[S46] [varchar](max) NULL,
	[S47] [varchar](max) NULL,
	[S48] [varchar](max) NULL,
	[S49] [varchar](max) NULL,
	[S50] [varchar](max) NULL,
	[N1] [numeric](18, 0) NULL,
	[N2] [numeric](18, 0) NULL,
	[N3] [numeric](18, 0) NULL,
	[N4] [numeric](18, 0) NULL,
	[N5] [numeric](18, 0) NULL,
	[N6] [numeric](18, 0) NULL,
	[N7] [numeric](18, 0) NULL,
	[N8] [numeric](18, 0) NULL,
	[N9] [numeric](18, 0) NULL,
	[N10] [numeric](18, 0) NULL,
	[N11] [numeric](18, 0) NULL,
	[N12] [numeric](18, 0) NULL,
	[N13] [numeric](18, 0) NULL,
	[N14] [numeric](18, 0) NULL,
	[N15] [numeric](18, 0) NULL,
	[N16] [numeric](18, 0) NULL,
	[N17] [numeric](18, 0) NULL,
	[N18] [numeric](18, 0) NULL,
	[N19] [numeric](18, 0) NULL,
	[N20] [numeric](18, 0) NULL,
	[N21] [numeric](18, 0) NULL,
	[N22] [numeric](18, 0) NULL,
	[N23] [numeric](18, 0) NULL,
	[N24] [numeric](18, 0) NULL,
	[N25] [numeric](18, 0) NULL,
	[N26] [numeric](18, 0) NULL,
	[N27] [numeric](18, 0) NULL,
	[N28] [numeric](18, 0) NULL,
	[N29] [numeric](18, 0) NULL,
	[N30] [numeric](18, 0) NULL,
	[D1] [decimal](18, 2) NULL,
	[D2] [decimal](18, 2) NULL,
	[D3] [decimal](18, 2) NULL,
	[D4] [decimal](18, 2) NULL,
	[D5] [decimal](18, 2) NULL,
	[D6] [decimal](18, 2) NULL,
	[D7] [decimal](18, 2) NULL,
	[D8] [decimal](18, 2) NULL,
	[D9] [decimal](18, 2) NULL,
	[D10] [decimal](18, 2) NULL,
	[D11] [decimal](18, 2) NULL,
	[D12] [decimal](18, 2) NULL,
	[D13] [decimal](18, 2) NULL,
	[D14] [decimal](18, 2) NULL,
	[D15] [decimal](18, 2) NULL,
	[D16] [decimal](18, 2) NULL,
	[D17] [decimal](18, 2) NULL,
	[D18] [decimal](18, 2) NULL,
	[D19] [decimal](18, 2) NULL,
	[D20] [decimal](18, 2) NULL,
	[Date1] [datetime] NULL,
	[Date2] [datetime] NULL,
	[Date3] [datetime] NULL,
	[Date4] [datetime] NULL,
	[Date5] [datetime] NULL,
	[Date6] [datetime] NULL,
	[Date7] [datetime] NULL,
	[Date8] [datetime] NULL,
	[Date9] [datetime] NULL,
	[Date10] [datetime] NULL,
	[I1] [int] NULL,
	[I2] [int] NULL,
	[I3] [int] NULL,
	[I4] [int] NULL,
	[I5] [int] NULL,
	[I6] [int] NULL,
	[I7] [int] NULL,
	[I8] [int] NULL,
	[I9] [int] NULL,
	[I10] [int] NULL,
	[I11] [int] NULL,
	[I12] [int] NULL,
	[I13] [int] NULL,
	[I14] [int] NULL,
	[I15] [int] NULL,
	[I16] [int] NULL,
	[I17] [int] NULL,
	[I18] [int] NULL,
	[I19] [int] NULL,
	[I20] [int] NULL,
	[DocNo] [varchar](50) NULL,
 CONSTRAINT [PK_tblRptM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormWiseRights]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormWiseRights](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [varchar](150) NOT NULL,
	[ControlName] [varchar](150) NULL,
	[AddRights] [int] NOT NULL,
	[EditRights] [int] NOT NULL,
	[DeleteRights] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](50) NULL,
	[IsLocked] [bit] NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_FormWiseRights] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeePic]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeePic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[Pic] [image] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[Active] [bit] NULL,
	[AddDate] [datetime] NULL,
	[AddUserID] [int] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](50) NULL,
	[IsLocked] [bit] NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_TeacherPic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemPriceLevel]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemPriceLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PriceLevel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemPriceHistory]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemPriceHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemPriceDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemManufacturer]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemManufacturer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemManufacturer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemGroupType]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemGroupType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemGroupType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccTransaction]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccTransaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TrnsDate] [datetime] NULL,
	[TrnsAccID] [int] NULL,
	[TrnsDetails] [varchar](150) NULL,
	[TrnsDr] [decimal](18, 2) NULL,
	[TrnsCr] [decimal](18, 2) NULL,
	[TrnsType] [char](5) NULL,
	[TblName] [varchar](50) NULL,
	[TblID] [int] NULL,
	[SupID] [int] NULL,
	[CusID] [int] NULL,
	[EmpID] [int] NULL,
	[AddDate] [datetime] NULL,
	[AddUserID] [int] NULL,
	[Comments] [varchar](150) NULL,
	[DocNo] [varchar](50) NULL,
	[TrnsVrNo] [varchar](50) NULL,
 CONSTRAINT [PK_AccTransaction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GeneralJournal]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneralJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TotalDr] [decimal](18, 2) NULL,
	[TotalCr] [decimal](18, 2) NULL,
	[AmountModeBy] [char](2) NULL,
	[CustomerID] [int] NULL,
	[SupplierID] [int] NULL,
	[EmployeeID] [int] NULL,
	[VDate] [date] NULL,
	[VType] [char](3) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](250) NULL,
	[IsLocked] [bit] NOT NULL,
	[TrnsVrNo] [varchar](15) NULL,
	[DocNo] [varchar](50) NULL,
	[CoFinEndYear] [int] NULL,
	[Remarks] [varchar](150) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_GeneralJournals] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Customer/Supplier/Other' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GeneralJournal', @level2type=N'COLUMN',@level2name=N'AmountModeBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GeneralJournal', @level2type=N'COLUMN',@level2name=N'VType'
GO
/****** Object:  Table [dbo].[Account]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccID] [int] NULL,
	[AccName] [varchar](50) NULL,
	[AccTypeID] [int] NULL,
	[AccLevel] [int] NULL,
	[RelatedToPNL] [bit] NULL,
	[TransferAllowed] [bit] NULL,
	[CannotDelete] [bit] NULL,
	[CannotDirectEntry] [bit] NULL,
	[Remarks] [varchar](150) NULL,
	[Active] [bit] NULL,
	[AddDate] [datetime] NULL,
	[AddUserID] [int] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](50) NULL,
	[IsLocked] [bit] NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
	[DocNo] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiscountTypes]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiscountTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_DiscountTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiscountMonth]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiscountMonth](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_DiscountMonth] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DiscountDayOfThe]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DiscountDayOfThe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_DiscountDayOfThe] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleTaxAuthority]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleTaxAuthority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaxCode] [varchar](50) NULL,
	[Description] [varchar](50) NOT NULL,
	[PartsRate] [decimal](18, 2) NULL,
	[LaborRate] [decimal](18, 2) NULL,
	[CustomSaleTax] [varchar](10) NULL,
	[CustomPartsRate] [decimal](18, 2) NULL,
	[CustomLaborRate] [decimal](18, 2) NULL,
	[CutOffAmount] [decimal](18, 2) NULL,
	[CutOffRate] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_SaleTaxAuthority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RptDetail]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RptDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](250) NULL,
	[RptName] [varchar](250) NULL,
	[RptPerameter1] [varchar](150) NULL,
	[RptPerameter2] [varchar](150) NULL,
	[RptPerameter3] [varchar](150) NULL,
	[RptPerameter4] [varchar](150) NULL,
	[RptPerameter5] [varchar](150) NULL,
	[RptPerameter6] [varchar](150) NULL,
	[RptPerameter7] [varchar](150) NULL,
	[RptPerameter8] [varchar](150) NULL,
	[RptPerameter9] [varchar](150) NULL,
	[RptPerameter10] [varchar](150) NULL,
	[RptDate1] [date] NULL,
	[RptDate2] [date] NULL,
	[RptDate3] [date] NULL,
	[RptDate4] [date] NULL,
	[RptDate5] [date] NULL,
	[DocNo] [varchar](50) NULL,
	[CompanyLogo] [image] NULL,
 CONSTRAINT [PK_RptDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoundingMethod]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoundingMethod](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_RoundingMethod] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReferredBy]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReferredBy](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_RefferedBy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseOrderAutoNo]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseOrderAutoNo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PurchaseOrderAutoNo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SpiffsType]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpiffsType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_SpiffsType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShipVia]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShipVia](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ShipVia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShippingMethods]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShippingMethods](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Description] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ShippingMethods] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemType]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[POSDetail]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POSDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Com_port] [varchar](max) NOT NULL,
	[Com_port1] [varchar](max) NOT NULL,
	[Com_port2] [varchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[AddUserID] [int] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](50) NULL,
	[IsLocked] [bit] NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentMode]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentMode](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PaymentMode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OilViscosities]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OilViscosities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_OilViscosities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MechHours]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MechHours](
	[ID] [int] NOT NULL,
 CONSTRAINT [PK_MechHours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginActivity]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginActivity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[IsLogin] [bit] NULL,
	[LoginDate] [datetime] NULL,
	[DocNo] [varchar](50) NULL,
	[POSID] [int] NULL,
 CONSTRAINT [PK_tblLoginActivity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogActivity]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogActivity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[TblName] [varchar](150) NULL,
	[RecID] [int] NULL,
	[IsAdd] [bit] NULL,
	[IsEdit] [bit] NULL,
	[IsDelete] [bit] NULL,
	[ActivityDate] [datetime] NULL,
	[DocNo] [varchar](50) NULL,
	[POSID] [int] NULL,
 CONSTRAINT [PK_tblLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CutOffDay]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CutOffDay](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_CutOffDay] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InventoryStock]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InventoryStock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[POSItemID] [int] NULL,
	[Qty] [numeric](18, 0) NULL,
	[SchemeQty] [int] NULL,
	[SampleQty] [int] NULL,
	[EmptyQty] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSStock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Holidays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[HolidayDate] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Holidays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[getNextWorkOrderAutoNo]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getNextWorkOrderAutoNo] (
    @AddUserID INT,
    @NextAutoNo INT OUTPUT
) AS
BEGIN
    INSERT INTO [dbo].[WorkOrderAutoNo] 
	   ([Name] ,[Active] ,[AddDate] ,[AddUserID] ,[Comments] ,[IsLocked] ,[Remarks]) 
	VALUES ('NewWorkOrderAutoNo' ,1 ,GETDATE() ,@AddUserID ,'NewWorkOrderAutoNo' ,1 ,'NewWorkOrderAutoNo' )
 
    SET @NextAutoNo = SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[getNextPurchaseOrderAutoNo]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[getNextPurchaseOrderAutoNo] (
    @AddUserID INT,
    @NextAutoNo INT OUTPUT
) AS
BEGIN
    INSERT INTO [dbo].[PurchaseOrderAutoNo] 
	   ([Name] ,[Active] ,[AddDate] ,[AddUserID] ,[Comments] ,[IsLocked] ,[Remarks]) 
	VALUES ('NewPurchaseOrderAutoNo' ,1 ,GETDATE() ,@AddUserID ,'NewPurchaseOrderAutoNo' ,1 ,'NewPurchaseOrderAutoNo' )
 
    SET @NextAutoNo = SCOPE_IDENTITY();
END;
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GRNDate] [date] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[PaymentMode] [char](2) NOT NULL,
	[TotalPalate] [int] NULL,
	[TotalPacks] [int] NULL,
	[TotalUnits] [int] NULL,
	[TotalUnitQty] [int] NULL,
	[TotalEmptyQty] [int] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[NetAmount] [decimal](18, 2) NULL,
	[CashPayment] [decimal](18, 2) NULL,
	[Balance] [decimal](18, 2) NULL,
	[VehicleNo] [varchar](50) NULL,
	[PaymentDate] [datetime] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[POID] [int] NULL,
	[InvoiceNo] [varchar](50) NULL,
	[GatePass] [varchar](50) NULL,
	[ReturnEmpty] [int] NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSGRN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleTaxRates]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleTaxRates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TaxCode] [varchar](50) NULL,
	[Description] [varchar](50) NOT NULL,
	[PartsRate] [decimal](18, 2) NULL,
	[LaborRate] [decimal](18, 2) NULL,
	[CustomSaleTax] [varchar](10) NULL,
	[CustomPartsRate] [decimal](18, 2) NULL,
	[CustomLaborRate] [decimal](18, 2) NULL,
	[CutOffAmount] [decimal](18, 2) NULL,
	[CutOffRate] [decimal](18, 2) NULL,
	[SaleTaxAuthorityID1] [int] NULL,
	[SaleTaxAuthorityID2] [int] NULL,
	[SaleTaxAuthorityID3] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_SaleTaxRates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Terms]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Terms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[IsCash] [bit] NULL,
	[IsVendorOnly] [bit] NULL,
	[DiscountTypeID] [int] NULL,
	[IsDueByDate] [bit] NULL,
	[DueByDayOfTheD1] [int] NULL,
	[DueByMonthD1] [int] NULL,
	[IsDueByDays] [bit] NULL,
	[DueByDaysD1] [int] NULL,
	[DueByDescription] [varchar](100) NULL,
	[Discount1] [int] NULL,
	[IsDiscount1ByDate] [bit] NULL,
	[Discount1DayOfTheD1] [int] NULL,
	[Discount1MonthD1] [int] NULL,
	[IsDiscount1ByDays] [bit] NULL,
	[Discount1ByDaysD1] [int] NULL,
	[IsDiscount1DontUse] [bit] NULL,
	[Discount1Description] [varchar](100) NULL,
	[Discount2] [int] NULL,
	[IsDiscount2ByDate] [bit] NULL,
	[Discount2DayOfTheD1] [int] NULL,
	[Discount2MonthD1] [int] NULL,
	[IsDiscount2ByDays] [bit] NULL,
	[Discount2ByDaysD1] [int] NULL,
	[IsDiscount2DontUse] [bit] NULL,
	[Discount2Description] [varchar](100) NULL,
	[Discount3] [int] NULL,
	[IsDiscount3ByDate] [bit] NULL,
	[Discount3DayOfTheD1] [int] NULL,
	[Discount3MonthD1] [int] NULL,
	[IsDiscount3ByDays] [bit] NULL,
	[Discount3ByDaysD1] [int] NULL,
	[IsDiscount3DontUse] [bit] NULL,
	[Discount3Description] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Terms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyCash]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DailyCash](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[mDate] [date] NULL,
	[mAccID] [int] NULL,
	[m5000N1] [int] NULL,
	[m1000N2] [int] NULL,
	[m500N3] [int] NULL,
	[m100N4] [int] NULL,
	[m50N5] [int] NULL,
	[m20N2] [int] NULL,
	[m10N1] [int] NULL,
	[mCoins] [int] NULL,
	[mRemarks] [varchar](250) NULL,
	[mCashLedgerBalance] [decimal](18, 2) NULL,
	[mDiff] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
 CONSTRAINT [PK_DailyCash] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[GroupTypeID] [int] NULL,
	[IsCosted] [bit] NULL,
	[RoundingMethodID] [int] NULL,
	[MinimumMarkups] [decimal](18, 2) NULL,
	[AssetAcctID] [int] NULL,
	[SalesAcctID] [int] NULL,
	[CGSAcctID] [int] NULL,
	[RetailMarkup] [decimal](18, 2) NULL,
	[CommercialMarkup] [decimal](18, 2) NULL,
	[WholesaleMarkup] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom1] [int] NULL,
	[OutsidePartMarkups1] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom2] [int] NULL,
	[OutsidePartMarkups2] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom3] [int] NULL,
	[OutsidePartMarkups3] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom4] [int] NULL,
	[OutsidePartMarkups4] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom5] [int] NULL,
	[OutsidePartMarkups5] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom6] [int] NULL,
	[OutsidePartMarkups6] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom7] [int] NULL,
	[OutsidePartMarkups7] [decimal](18, 2) NULL,
	[OutsidePartMarkupsFrom8] [int] NULL,
	[OutsidePartMarkups8] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRptD]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRptD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NULL,
	[S1] [varchar](max) NULL,
	[S2] [varchar](max) NULL,
	[S3] [varchar](max) NULL,
	[S4] [varchar](max) NULL,
	[S5] [varchar](max) NULL,
	[S6] [varchar](max) NULL,
	[S7] [varchar](max) NULL,
	[S8] [varchar](max) NULL,
	[S9] [varchar](max) NULL,
	[S10] [varchar](max) NULL,
	[S11] [varchar](max) NULL,
	[S12] [varchar](max) NULL,
	[S13] [varchar](max) NULL,
	[S14] [varchar](max) NULL,
	[S15] [varchar](max) NULL,
	[S16] [varchar](max) NULL,
	[S17] [varchar](max) NULL,
	[S18] [varchar](max) NULL,
	[S19] [varchar](max) NULL,
	[S20] [varchar](max) NULL,
	[S21] [varchar](max) NULL,
	[S22] [varchar](max) NULL,
	[S23] [varchar](max) NULL,
	[S24] [varchar](max) NULL,
	[S25] [varchar](max) NULL,
	[S26] [varchar](max) NULL,
	[S27] [varchar](max) NULL,
	[S28] [varchar](max) NULL,
	[S29] [varchar](max) NULL,
	[S30] [varchar](max) NULL,
	[S31] [varchar](max) NULL,
	[S32] [varchar](max) NULL,
	[S33] [varchar](max) NULL,
	[S34] [varchar](max) NULL,
	[S35] [varchar](max) NULL,
	[S36] [varchar](max) NULL,
	[S37] [varchar](max) NULL,
	[S38] [varchar](max) NULL,
	[S39] [varchar](max) NULL,
	[S40] [varchar](max) NULL,
	[S41] [varchar](max) NULL,
	[S42] [varchar](max) NULL,
	[S43] [varchar](max) NULL,
	[S44] [varchar](max) NULL,
	[S45] [varchar](max) NULL,
	[S46] [varchar](max) NULL,
	[S47] [varchar](max) NULL,
	[S48] [varchar](max) NULL,
	[S49] [varchar](max) NULL,
	[S50] [varchar](max) NULL,
	[N1] [numeric](18, 0) NULL,
	[N2] [numeric](18, 0) NULL,
	[N3] [numeric](18, 0) NULL,
	[N4] [numeric](18, 0) NULL,
	[N5] [numeric](18, 0) NULL,
	[N6] [numeric](18, 0) NULL,
	[N7] [numeric](18, 0) NULL,
	[N8] [numeric](18, 0) NULL,
	[N9] [numeric](18, 0) NULL,
	[N10] [numeric](18, 0) NULL,
	[N11] [numeric](18, 0) NULL,
	[N12] [numeric](18, 0) NULL,
	[N13] [numeric](18, 0) NULL,
	[N14] [numeric](18, 0) NULL,
	[N15] [numeric](18, 0) NULL,
	[N16] [numeric](18, 0) NULL,
	[N17] [numeric](18, 0) NULL,
	[N18] [numeric](18, 0) NULL,
	[N19] [numeric](18, 0) NULL,
	[N20] [numeric](18, 0) NULL,
	[N21] [numeric](18, 0) NULL,
	[N22] [numeric](18, 0) NULL,
	[N23] [numeric](18, 0) NULL,
	[N24] [numeric](18, 0) NULL,
	[N25] [numeric](18, 0) NULL,
	[N26] [numeric](18, 0) NULL,
	[N27] [numeric](18, 0) NULL,
	[N28] [numeric](18, 0) NULL,
	[N29] [numeric](18, 0) NULL,
	[N30] [numeric](18, 0) NULL,
	[D1] [decimal](18, 2) NULL,
	[D2] [decimal](18, 2) NULL,
	[D3] [decimal](18, 2) NULL,
	[D4] [decimal](18, 2) NULL,
	[D5] [decimal](18, 2) NULL,
	[D6] [decimal](18, 2) NULL,
	[D7] [decimal](18, 2) NULL,
	[D8] [decimal](18, 2) NULL,
	[D9] [decimal](18, 2) NULL,
	[D10] [decimal](18, 2) NULL,
	[D11] [decimal](18, 2) NULL,
	[D12] [decimal](18, 2) NULL,
	[D13] [decimal](18, 2) NULL,
	[D14] [decimal](18, 2) NULL,
	[D15] [decimal](18, 2) NULL,
	[D16] [decimal](18, 2) NULL,
	[D17] [decimal](18, 2) NULL,
	[D18] [decimal](18, 2) NULL,
	[D19] [decimal](18, 2) NULL,
	[D20] [decimal](18, 2) NULL,
	[Date1] [datetime] NULL,
	[Date2] [datetime] NULL,
	[Date3] [datetime] NULL,
	[Date4] [datetime] NULL,
	[Date5] [datetime] NULL,
	[Date6] [datetime] NULL,
	[Date7] [datetime] NULL,
	[Date8] [datetime] NULL,
	[Date9] [datetime] NULL,
	[Date10] [datetime] NULL,
	[I1] [int] NULL,
	[I2] [int] NULL,
	[I3] [int] NULL,
	[I4] [int] NULL,
	[I5] [int] NULL,
	[I6] [int] NULL,
	[I7] [int] NULL,
	[I8] [int] NULL,
	[I9] [int] NULL,
	[I10] [int] NULL,
	[I11] [int] NULL,
	[I12] [int] NULL,
	[I13] [int] NULL,
	[I14] [int] NULL,
	[I15] [int] NULL,
	[I16] [int] NULL,
	[I17] [int] NULL,
	[I18] [int] NULL,
	[I19] [int] NULL,
	[I20] [int] NULL,
	[DocNo] [varchar](50) NULL,
 CONSTRAINT [PK_tblRptD_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 09/25/2019 12:30:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleModel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MakeID] [int] NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_VehicleBrand] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleSubModel]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleSubModel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MakeID] [int] NULL,
	[ModelID] [int] NULL,
	[Name] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_VehicleSubModel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleCategory]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NULL,
	[Name] [varchar](50) NULL,
	[ItemPriceLevelID] [int] NULL,
	[SaleTaxRateID] [int] NULL,
	[IsDontExpandTirePackages] [bit] NULL,
	[IsDefault] [bit] NULL,
	[WorkorderMessage] [varchar](150) NULL,
	[StatementMessage] [varchar](150) NULL,
	[InvoiceMessage] [varchar](150) NULL,
	[ThankYouEmail] [varchar](150) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_SalesCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NULL,
	[POSItemID] [int] NULL,
	[Ufactor] [char](1) NULL,
	[ReceiveQty] [int] NULL,
	[PurchasePrice] [decimal](18, 2) NULL,
	[SalePrice] [decimal](18, 2) NULL,
	[WholeSalePrice] [decimal](18, 2) NULL,
	[DiscPercent] [decimal](18, 2) NULL,
	[DiscAmount] [decimal](18, 2) NULL,
	[STRateActive] [bit] NULL,
	[STPercent] [decimal](18, 2) NULL,
	[STAmount] [decimal](18, 2) NULL,
	[NRate] [decimal](18, 2) NULL,
	[SchemeQty] [int] NULL,
	[ReplaceQty] [int] NULL,
	[SampleQty] [int] NULL,
	[FOC] [int] NULL,
	[EmptyQty] [int] NULL,
	[MfgDate] [date] NULL,
	[ExpiryDate] [date] NULL,
	[BatchNo] [varchar](50) NULL,
	[PalletQty] [int] NULL,
	[DistributerIncentive] [decimal](18, 2) NULL,
	[TotalUnitQty] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSGRNDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VehicleSpecification]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VehicleSpecification](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[YearID] [int] NULL,
	[MakeID] [int] NULL,
	[ModelID] [int] NULL,
	[SubModelID] [int] NULL,
	[FrontTireSize] [varchar](50) NULL,
	[RearTireSize] [varchar](50) NULL,
	[TirePressure] [varchar](50) NULL,
	[RimSize] [varchar](50) NULL,
	[BoltPattern] [varchar](50) NULL,
	[WheelFasteners] [varchar](50) NULL,
	[EngineSize] [varchar](50) NULL,
	[HorsePower] [varchar](50) NULL,
	[CenterBore] [varchar](50) NULL,
	[ThreadSize] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_VehicleSpecification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[RegDate] [date] NULL,
	[Email] [varchar](150) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[AlterPhone] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
	[CityID] [int] NULL,
	[ZipCode] [int] NULL,
	[FederalNo] [varchar](50) NULL,
	[TermsID] [int] NULL,
	[CutOffDayID] [int] NULL,
	[ContactPersonName] [varchar](150) NULL,
	[ContactPersonPhone] [varchar](50) NULL,
	[ContactPersonEmail] [varchar](50) NULL,
	[BillingAddress] [varchar](250) NULL,
	[BillingCountryID] [int] NULL,
	[BillingStateID] [int] NULL,
	[BillingCityID] [int] NULL,
	[BillingZipCode] [int] NULL,
	[IsBillingAddressForCheque] [bit] NULL,
	[Notes] [varchar](250) NULL,
	[IsOutsidePartPurchases] [bit] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseDepartment]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseDepartment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ManagerID] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CreditCards]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CreditCards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[VendorID] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_CreditCards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Configuration]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configuration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[ctrName] [varchar](150) NOT NULL,
	[ctrBackColor] [varchar](50) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](250) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseStore](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Location] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [int] NOT NULL,
	[POID] [int] NOT NULL,
	[PODate] [date] NOT NULL,
	[Reference] [varchar](150) NULL,
	[Notes] [varchar](150) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[LastReceivedDate] [date] NULL,
	[LastReceivedBy] [int] NULL,
	[IsDone] [bit] NULL,
	[WarehouseID] [int] NULL,
	[StoreID] [int] NULL,
	[TotalAmountOrder] [decimal](18, 2) NULL,
	[TotalAmountReceived] [decimal](18, 2) NULL,
	[TotalAmountBilled] [decimal](18, 2) NULL,
	[TotalQtyOrder] [int] NULL,
	[TotalQtyReceived] [int] NULL,
	[TotalQtyBilled] [int] NULL,
	[IsProcessed] [bit] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[POR]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PODate] [date] NULL,
	[VendorID] [int] NULL,
	[Notes] [varchar](50) NULL,
	[IsVoid] [bit] NULL,
	[OrderQty] [int] NULL,
	[OrderByID] [int] NULL,
	[IsReceived] [bit] NULL,
	[ReceivedDate] [date] NULL,
	[Discount] [decimal](18, 2) NULL,
	[DiscBillAmount] [decimal](18, 2) NULL,
	[StoreID] [int] NULL,
	[ReceivedQty] [int] NULL,
	[BillAmount] [decimal](18, 2) NULL,
	[ReceivedByID] [int] NULL,
	[IsPaid] [bit] NULL,
	[BillDate] [date] NULL,
	[PaymentModeID] [int] NULL,
	[BillByID] [int] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[AccountID] [int] NULL,
	[PendingQty] [int] NULL,
	[PendingAmount] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseHolidays]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseHolidays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[HolidayID] [int] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[IsClosed] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseHolidays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseChores]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseChores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseChores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseTiming]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseTiming](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[Days] [varchar](50) NOT NULL,
	[TimeStart] [time](7) NOT NULL,
	[TimeEnd] [time](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseTiming] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseStoreRack]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseStoreRack](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StoreID] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Location] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Rack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [date] NULL,
	[Code] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[IsCustomer] [bit] NULL,
	[IsCompany] [bit] NULL,
	[Address] [varchar](250) NULL,
	[ContactPerson] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[CountryID] [int] NULL,
	[StateID] [int] NULL,
	[CityID] [int] NULL,
	[ZipCode] [int] NULL,
	[StoreID] [int] NULL,
	[Phone1] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[Phone3] [varchar](50) NULL,
	[Phone4] [varchar](50) NULL,
	[Notes] [varchar](250) NULL,
	[WOMsg] [varchar](250) NULL,
	[IsShowMsgOnInvoice] [bit] NULL,
	[IsReqPONo] [bit] NULL,
	[IsPayFET] [bit] NULL,
	[IsCheckAccepted] [bit] NULL,
	[IsMail] [bit] NULL,
	[IsNoAutomaticSupplies] [bit] NULL,
	[PartDisPer] [decimal](18, 0) NULL,
	[LaborDisPer] [decimal](18, 0) NULL,
	[Deposit] [decimal](18, 2) NULL,
	[Resale] [decimal](18, 2) NULL,
	[ResaleDate] [date] NULL,
	[SaleCategoryID] [int] NULL,
	[SaleTaxRateID] [int] NULL,
	[PriceLevelID] [int] NULL,
	[ReferredByID] [int] NULL,
	[SaleTermID] [int] NULL,
	[CreditLimits] [decimal](18, 0) NULL,
	[ShipViaID] [int] NULL,
	[IsFinanceCharges] [bit] NULL,
	[IsBadDebt] [bit] NULL,
	[IsPrintStatement] [bit] NULL,
	[IsNeverReAge] [bit] NULL,
	[IsNationalAccount] [bit] NULL,
	[VendorID] [int] NULL,
	[ShippingName] [varchar](150) NULL,
	[ShippingAddress] [varchar](150) NULL,
	[ShippingStateID] [int] NULL,
	[ShippingCityID] [int] NULL,
	[ShippingZipCode] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GeneralJournalDetail]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GeneralJournalDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NULL,
	[Remarks] [varchar](250) NULL,
	[Paidto] [int] NULL,
	[TotalDr] [decimal](18, 2) NULL,
	[TotalCr] [decimal](18, 2) NULL,
	[Active] [bit] NULL,
	[AddDate] [datetime] NULL,
	[AddUserID] [int] NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
	[DocNo] [varchar](50) NULL,
 CONSTRAINT [PK_GeneralJournalDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[BankAccounts]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankAccounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [date] NOT NULL,
	[AccountID] [int] NULL,
	[BankName] [varchar](50) NOT NULL,
	[AccNo] [varchar](50) NOT NULL,
	[AccTitle] [varchar](50) NOT NULL,
	[Description] [varchar](150) NOT NULL,
	[LastReconciled] [date] NULL,
	[BankSMTBeginning] [decimal](18, 2) NULL,
	[BankSMTEnding] [decimal](18, 2) NULL,
	[StoreID] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Item]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [date] NULL,
	[ItemSize] [varchar](50) NULL,
	[Catalog] [varchar](50) NULL,
	[Name] [varchar](max) NULL,
	[ItemTypeID] [int] NULL,
	[ItemGroupID] [int] NULL,
	[NextLinkItemID] [int] NULL,
	[VendorID] [int] NULL,
	[ManufacturerID] [int] NULL,
	[Location] [varchar](50) NULL,
	[BoltPattern] [varchar](50) NULL,
	[ManufacturerNo] [varchar](50) NULL,
	[VenderPartNo] [varchar](50) NULL,
	[IsVendorManufacture] [bit] NULL,
	[IsNoDisc] [bit] NULL,
	[IsNotShared] [bit] NULL,
	[IsObsolete] [bit] NULL,
	[IsRepComm] [bit] NULL,
	[IsOutsideItem] [bit] NULL,
	[IsMechComm] [bit] NULL,
	[IsCosted] [bit] NULL,
	[IsTaxable] [bit] NULL,
	[IsRetread] [bit] NULL,
	[IsStocked] [bit] NULL,
	[IsUseFET] [bit] NULL,
	[UnitWeight] [numeric](18, 2) NULL,
	[CatalogCost] [decimal](18, 2) NULL,
	[LastCost] [decimal](18, 2) NULL,
	[AverageCost] [decimal](18, 2) NULL,
	[FET] [decimal](18, 2) NULL,
	[RetailPercent] [decimal](18, 2) NULL,
	[RetailPrice] [decimal](18, 2) NULL,
	[CommercialPercent] [decimal](18, 2) NULL,
	[CommercialPrice] [decimal](18, 2) NULL,
	[WholesalePercent] [decimal](18, 2) NULL,
	[WholesalePrice] [decimal](18, 2) NULL,
	[ReOrderMin] [int] NULL,
	[ReOrderMax] [int] NULL,
	[StoreID] [int] NULL,
	[RackID] [int] NULL,
	[DataKeywords] [varchar](50) NULL,
	[NAPAKeywords] [varchar](50) NULL,
	[AutoWareCode] [varchar](50) NULL,
	[UPCCode] [varchar](50) NULL,
	[IsSpiffsTemporary] [bit] NULL,
	[SpiffsTypeID] [int] NULL,
	[SpiffsDollarAmount] [decimal](18, 2) NULL,
	[SpiffsPercent] [int] NULL,
	[SpiffsDateFrom] [date] NULL,
	[SpiffsDateTo] [date] NULL,
	[IsTemporaryDiscount] [bit] NULL,
	[TemporaryDiscountDateFrom] [date] NULL,
	[TemporaryDiscountDateTo] [date] NULL,
	[TemporaryDiscountedRetail] [decimal](18, 2) NULL,
	[TemporaryDiscountedCommercial] [decimal](18, 2) NULL,
	[TemporaryDiscountedWholesale] [decimal](18, 2) NULL,
	[PostCard] [varchar](250) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSItemDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vehicle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [datetime] NULL,
	[LicensePlate] [varchar](50) NULL,
	[StateID] [int] NULL,
	[VehicleYearID] [int] NULL,
	[VehicleMakeID] [int] NULL,
	[VehicleModelID] [int] NULL,
	[VehicleColorID] [int] NULL,
	[VehicleSubModelID] [int] NULL,
	[CustomerID] [int] NULL,
	[VehicleTransmissionID] [int] NULL,
	[VIN] [varchar](50) NULL,
	[FleetNumber] [varchar](50) NULL,
	[Mileage] [numeric](18, 0) NULL,
	[IsNotesToWO] [bit] NULL,
	[EngineSize] [varchar](50) NULL,
	[DateProduced] [datetime] NULL,
	[PlateDate] [datetime] NULL,
	[TireSize1] [varchar](50) NULL,
	[TireSize2] [numeric](18, 0) NULL,
	[RimWidth] [varchar](50) NULL,
	[Torque] [varchar](50) NULL,
	[LugPattern] [varchar](50) NULL,
	[FrontPSI] [numeric](18, 0) NULL,
	[RearPSI] [numeric](18, 0) NULL,
	[IsOwner] [bit] NULL,
	[InvoiceHeading1] [varchar](50) NULL,
	[InvoiceValue1] [varchar](50) NULL,
	[InvoiceHeading2] [varchar](50) NULL,
	[InvoiceValue2] [varchar](50) NULL,
	[InvoiceHeading3] [varchar](50) NULL,
	[InvoiceValue3] [varchar](50) NULL,
	[InvoiceHeading4] [varchar](50) NULL,
	[InvoiceValue4] [varchar](50) NULL,
	[InvoiceHeading5] [varchar](50) NULL,
	[InvoiceValue5] [varchar](50) NULL,
	[InvoiceHeading6] [varchar](50) NULL,
	[InvoiceValue6] [varchar](50) NULL,
	[Note] [text] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorkOrder](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RegDate] [date] NULL,
	[WorkOrderNo] [int] NULL,
	[Notes] [varchar](150) NULL,
	[IsQutation] [bit] NULL,
	[IsWorkOrder] [bit] NULL,
	[IsCustomerOrder] [bit] NULL,
	[CustomerID] [int] NULL,
	[IsNoVehicle] [bit] NULL,
	[VehicleID] [int] NULL,
	[VIN] [varchar](50) NULL,
	[Mileage] [numeric](18, 0) NULL,
	[MileageOut] [numeric](18, 0) NULL,
	[PONo] [varchar](50) NULL,
	[SaleRepID] [int] NULL,
	[MechID] [int] NULL,
	[ReferredByID] [int] NULL,
	[SaleCategoryID] [int] NULL,
	[PriceLevelID] [int] NULL,
	[SaleTaxRateID] [int] NULL,
	[SaleTermID] [int] NULL,
	[ShipViaID] [int] NULL,
	[WarehouseBayID] [int] NULL,
	[CreatedByID] [int] NULL,
	[PartsPrice] [decimal](18, 2) NULL,
	[LaborPrice] [decimal](18, 2) NULL,
	[OtherPrice] [decimal](18, 2) NULL,
	[FET] [decimal](18, 2) NULL,
	[Taxable] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[PartDisPer] [decimal](18, 0) NULL,
	[LaborDisPer] [decimal](18, 0) NULL,
	[Total] [decimal](18, 2) NULL,
	[PickupDate] [date] NULL,
	[PickupTime] [datetime2](7) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSSale] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WorkOrderDetail]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorkOrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NULL,
	[ItemID] [int] NULL,
	[ServiceID] [int] NULL,
	[SaleQty] [int] NULL,
	[Hour] [decimal](18, 2) NULL,
	[SalePrice] [decimal](18, 2) NULL,
	[Cost] [decimal](18, 2) NULL,
	[SaleAmount] [decimal](18, 2) NULL,
	[DiscPer] [decimal](18, 2) NULL,
	[DiscAmount] [decimal](18, 2) NULL,
	[SaleFET] [decimal](18, 2) NULL,
	[Tax] [decimal](18, 2) NULL,
	[Total] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_POSSaleDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PORDetail]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PORDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[ItemID] [int] NULL,
	[OrderQty] [int] NULL,
	[ReceivedQty] [int] NULL,
	[PendingQty] [int] NULL,
	[CurrentPrice] [decimal](18, 2) NULL,
	[CurrentFET] [decimal](18, 2) NULL,
	[RetailPercent] [decimal](18, 2) NULL,
	[RetailPrice] [decimal](18, 2) NULL,
	[CommercialPercent] [decimal](18, 2) NULL,
	[CommercialPrice] [decimal](18, 2) NULL,
	[WholesalePercent] [decimal](18, 2) NULL,
	[WholesalePrice] [decimal](18, 2) NULL,
	[OrderAmount] [decimal](18, 2) NULL,
	[BillQty] [int] NULL,
	[BillAmount] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PORDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WarehouseServicesDetail]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WarehouseServicesDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[ItemID] [int] NULL,
	[Qty] [int] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_WarehouseServicesDetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemStock]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemStock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[StoreID] [int] NOT NULL,
	[WarehouseID] [int] NOT NULL,
	[Qty] [numeric](18, 0) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemStock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NULL,
	[ItemID] [int] NULL,
	[QtyOrdrd] [int] NULL,
	[PrevOrdrd] [int] NULL,
	[QtyRcvd] [int] NULL,
	[PrevRcvd] [int] NULL,
	[QtyBilled] [int] NULL,
	[PrevBilled] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[FET] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_PurchaseOrderDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Trigger [PurchaseOrderDetails_trigger]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[PurchaseOrderDetails_trigger]
   ON  [dbo].[PurchaseOrderDetails]
   AFTER INSERT, DELETE, UPDATE
AS 
BEGIN
	DECLARE		
		 @ItemID  int        
		,@StoreID int		
		,@WarehouseID int
				
		,@AddUserID int
		,@ModifyUserID int
		
        ,@OldQty numeric(18,0)
        ,@NewQty numeric(18,0)
        ,@DelQty numeric(18,0)
        
		,@Comments varchar(150);			
	
	--//////--------------------------
	SELECT   @ItemID = i.[ItemID]
			,@StoreID = [PO].[StoreID]
			,@WarehouseID = [PO].WarehouseID
			
		    ,@AddUserID = i.AddUserID
			,@ModifyUserID = i.ModifyUserID
		
			,@OldQty = 0
			,@NewQty = i.[PrevRcvd]
			,@DelQty = 0
	FROM inserted i
	Left Join [dbo].[PurchaseOrder] [PO] ON i.MID = [PO].ID
	
	----//////--for INSERT----------------------------------
	If exists (Select * from inserted) and not exists(Select * from deleted)
	begin
		set @Comments = 'Add Quantity from PO';
		If exists (Select * from [dbo].[ItemStock] where [ItemID] = @ItemID)
		begin
			select @OldQty = (Select ISNULL([Qty],0) from [dbo].[ItemStock] where [ItemID] = @ItemID);			
			--////------------------------------------------------
			UPDATE [dbo].[ItemStock]
			   SET [Qty] = (isnull(@OldQty,0) + isnull(@NewQty,0))			      
				  ,[Active] = 1
				  ,[ModifyDate] = GETDATE()
				  ,[ModifyUserID] = @AddUserID
				  ,[Comments] = @Comments
			 WHERE [ItemID] = @ItemID
		end
		else
		begin
			--////------------------------------------------------
			INSERT INTO [dbo].[ItemStock]
				([ItemID] ,[StoreID] ,[WarehouseID] ,[Qty],[Active],[AddDate],[AddUserID],[Comments])
			VALUES
				(@ItemID ,@StoreID ,@WarehouseID,@NewQty, 1, GETDATE(),@AddUserID ,@Comments)
			--////------------------------------------------------
		end
		--////------------------------------------------------
	end	
	----//////--for DELETE----------------------------------
	If exists(select * from deleted) and not exists(Select * from inserted)
	begin
		SELECT  @ItemID = d.[ItemID] 
				,@DelQty = d.[PrevRcvd]				
				,@AddUserID = d.[AddUserID]
		FROM deleted d		
			
		set @Comments = 'Update Quantity from PO';
		If exists (Select * from [dbo].[ItemStock] where [ItemID] = @ItemID)
		begin
			select @OldQty = (Select isnull([Qty],0) from [dbo].[ItemStock] where [ItemID] = @ItemID)			
			--////------------------------------------------------
			UPDATE [dbo].[ItemStock]
			   SET  [Qty] = (isnull(@OldQty,0) - isnull(@DelQty,0))				  
				  ,[Active] = 1
				  ,[ModifyDate] = GETDATE()
				  ,[ModifyUserID] = @AddUserID
				  ,[Comments] = @Comments
			 WHERE [ItemID] = @ItemID
			--////------------------------------------------------
		end		
	end
	----//////--for UPDATE----------------------------------
	if EXISTS(SELECT * FROM INSERTED) and exists (SELECT * FROM DELETED)
	begin
		SELECT  @ItemID = d.[ItemID] 				
				,@DelQty = d.[PrevRcvd]				
				,@AddUserID = d.[AddUserID]
		FROM deleted d
		--//---------------------------------
		SELECT  @ItemID = i.[ItemID] 				
				,@NewQty = i.[PrevRcvd]				
				,@AddUserID = i.[AddUserID]
		FROM inserted i
		--//---------------------------------
			
		set @Comments = 'Update Quantity from PO';
		If exists (Select * from [dbo].[ItemStock] where [ItemID] = @ItemID)
		begin
			select @OldQty = (Select [Qty] from [dbo].[ItemStock] where [ItemID] = @ItemID)			
			--////------------------------------------------------
			UPDATE [dbo].[ItemStock]
			   SET [Qty] = ((isnull(@OldQty,0)-isnull(@DelQty,0)))+(isnull(@NewQty,0))					
					,[Active] = 1
					,[ModifyDate] = GETDATE()
					,[ModifyUserID] = @AddUserID				  
					,[Comments] = @Comments				  
			 WHERE [ItemID] = @ItemID
			--////------------------------------------------------
		end		
		--////------------------------------------------------
	end	
END
GO
/****** Object:  Table [dbo].[ItemVendors]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemVendors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[VendorID] [int] NOT NULL,
	[VendorPartNo] [varchar](50) NULL,
	[CatalogCost] [decimal](18, 2) NULL,
	[Notes] [varchar](250) NULL,
	[IsMainVendor] [bit] NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_ItemVendors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[getItemIDByCatalog]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getItemIDByCatalog] (
    @ItemCatalog varchar(50),
    @ID INT OUTPUT
) AS
BEGIN
    SET @ID = (SELECT [ID] FROM [dbo].[Item] Where [Catalog] = @ItemCatalog);
END;
GO
/****** Object:  Table [dbo].[CustomerVehicles]    Script Date: 09/25/2019 12:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerVehicles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[VehicleID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[AddUserID] [int] NOT NULL,
	[ModifyUserID] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[Comments] [varchar](150) NULL,
	[IsLocked] [bit] NOT NULL,
	[DocNo] [varchar](50) NULL,
	[Remarks] [varchar](150) NULL,
	[CoFinEndYear] [int] NULL,
	[TrnsVrNo] [varchar](10) NULL,
	[TrnsJrRef] [varchar](5) NULL,
 CONSTRAINT [PK_CustomerVehicles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_EmployeeAttendance_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeeAttendance] ADD  CONSTRAINT [DF_EmployeeAttendance_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_EmployeeLeave_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeeLeave] ADD  CONSTRAINT [DF_EmployeeLeave_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_FormWiseRights_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[FormWiseRights] ADD  CONSTRAINT [DF_FormWiseRights_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_EmployeePic_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeePic] ADD  CONSTRAINT [DF_EmployeePic_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_EmployeePic_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeePic] ADD  CONSTRAINT [DF_EmployeePic_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_EmployeeComBaseOn_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeeComBaseOn] ADD  CONSTRAINT [DF_EmployeeComBaseOn_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_EmployeeComBaseOn_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeeComBaseOn] ADD  CONSTRAINT [DF_EmployeeComBaseOn_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_CutOffDay_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[CutOffDay] ADD  CONSTRAINT [DF_CutOffDay_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_CutOffDay_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[CutOffDay] ADD  CONSTRAINT [DF_CutOffDay_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PriceLevel_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemPriceLevel] ADD  CONSTRAINT [DF_PriceLevel_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PriceLevel_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemPriceLevel] ADD  CONSTRAINT [DF_PriceLevel_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemPriceDetail_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemPriceHistory] ADD  CONSTRAINT [DF_ItemPriceDetail_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemPriceDetail_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemPriceHistory] ADD  CONSTRAINT [DF_ItemPriceDetail_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemManufacturer_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemManufacturer] ADD  CONSTRAINT [DF_ItemManufacturer_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemManufacturer_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemManufacturer] ADD  CONSTRAINT [DF_ItemManufacturer_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemGroupType_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemGroupType] ADD  CONSTRAINT [DF_ItemGroupType_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemGroupType_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemGroupType] ADD  CONSTRAINT [DF_ItemGroupType_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_GeneralJournals_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[GeneralJournal] ADD  CONSTRAINT [DF_GeneralJournals_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_GeneralJournals_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[GeneralJournal] ADD  CONSTRAINT [DF_GeneralJournals_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Account_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Account_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Country_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Country_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_DiscountTypes_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[DiscountTypes] ADD  CONSTRAINT [DF_DiscountTypes_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_DiscountTypes_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[DiscountTypes] ADD  CONSTRAINT [DF_DiscountTypes_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_DiscountMonth_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[DiscountMonth] ADD  CONSTRAINT [DF_DiscountMonth_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_DiscountMonth_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[DiscountMonth] ADD  CONSTRAINT [DF_DiscountMonth_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_DiscountDayOfThe_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[DiscountDayOfThe] ADD  CONSTRAINT [DF_DiscountDayOfThe_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_DiscountDayOfThe_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[DiscountDayOfThe] ADD  CONSTRAINT [DF_DiscountDayOfThe_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleMaker_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleMake] ADD  CONSTRAINT [DF_VehicleMaker_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleMaker_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleMake] ADD  CONSTRAINT [DF_VehicleMaker_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_SaleTaxAuthority_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[SaleTaxAuthority] ADD  CONSTRAINT [DF_SaleTaxAuthority_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_SaleTaxAuthority_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[SaleTaxAuthority] ADD  CONSTRAINT [DF_SaleTaxAuthority_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_UserGroups_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[UserGroups] ADD  CONSTRAINT [DF_UserGroups_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_UserGroups_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[UserGroups] ADD  CONSTRAINT [DF_UserGroups_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_SpiffsType_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[SpiffsType] ADD  CONSTRAINT [DF_SpiffsType_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_SpiffsType_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[SpiffsType] ADD  CONSTRAINT [DF_SpiffsType_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ShipVia_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ShipVia] ADD  CONSTRAINT [DF_ShipVia_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ShipVia_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ShipVia] ADD  CONSTRAINT [DF_ShipVia_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ShippingMethods_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ShippingMethods] ADD  CONSTRAINT [DF_ShippingMethods_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ShippingMethods_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ShippingMethods] ADD  CONSTRAINT [DF_ShippingMethods_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_RoundingMethod_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[RoundingMethod] ADD  CONSTRAINT [DF_RoundingMethod_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_RoundingMethod_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[RoundingMethod] ADD  CONSTRAINT [DF_RoundingMethod_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_RefferedBy_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ReferredBy] ADD  CONSTRAINT [DF_RefferedBy_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_RefferedBy_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ReferredBy] ADD  CONSTRAINT [DF_RefferedBy_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PurchaseOrderAutoNo_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[PurchaseOrderAutoNo] ADD  CONSTRAINT [DF_PurchaseOrderAutoNo_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PurchaseOrderAutoNo_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[PurchaseOrderAutoNo] ADD  CONSTRAINT [DF_PurchaseOrderAutoNo_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_POSDetail_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[POSDetail] ADD  CONSTRAINT [DF_POSDetail_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PayWeekStartOn_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[PayWeekStartOn] ADD  CONSTRAINT [DF_PayWeekStartOn_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PayWeekStartOn_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[PayWeekStartOn] ADD  CONSTRAINT [DF_PayWeekStartOn_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PaymentMode_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[PaymentMode] ADD  CONSTRAINT [DF_PaymentMode_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PaymentMode_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[PaymentMode] ADD  CONSTRAINT [DF_PaymentMode_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_OilViscosities_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[OilViscosities] ADD  CONSTRAINT [DF_OilViscosities_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_OilViscosities_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[OilViscosities] ADD  CONSTRAINT [DF_OilViscosities_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemType_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemType] ADD  CONSTRAINT [DF_ItemType_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemType_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[ItemType] ADD  CONSTRAINT [DF_ItemType_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_POSStock_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[InventoryStock] ADD  CONSTRAINT [DF_POSStock_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_POSStock_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[InventoryStock] ADD  CONSTRAINT [DF_POSStock_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Holidays_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[Holidays] ADD  CONSTRAINT [DF_Holidays_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Holidays_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[Holidays] ADD  CONSTRAINT [DF_Holidays_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WorkOrderAutoNo_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WorkOrderAutoNo] ADD  CONSTRAINT [DF_WorkOrderAutoNo_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_WorkOrderAutoNo_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WorkOrderAutoNo] ADD  CONSTRAINT [DF_WorkOrderAutoNo_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_SystemSettings_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseSettings] ADD  CONSTRAINT [DF_SystemSettings_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_SystemSettings_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseSettings] ADD  CONSTRAINT [DF_SystemSettings_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseThemes_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseThemes] ADD  CONSTRAINT [DF_WarehouseThemes_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_WarehouseThemes_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseThemes] ADD  CONSTRAINT [DF_WarehouseThemes_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleYearModel_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleYear] ADD  CONSTRAINT [DF_VehicleYearModel_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleYearModel_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleYear] ADD  CONSTRAINT [DF_VehicleYearModel_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleTransmission_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleTransmission] ADD  CONSTRAINT [DF_VehicleTransmission_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleTransmission_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleTransmission] ADD  CONSTRAINT [DF_VehicleTransmission_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseBay_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseBay] ADD  CONSTRAINT [DF_WarehouseBay_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_WarehouseBay_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseBay] ADD  CONSTRAINT [DF_WarehouseBay_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseServices_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[WarehouseServices] ADD  CONSTRAINT [DF_WarehouseServices_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleBrand_Active]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleModel] ADD  CONSTRAINT [DF_VehicleBrand_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleBrand_IsLocked]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleModel] ADD  CONSTRAINT [DF_VehicleBrand_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_POSGRN_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF_POSGRN_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_POSGRN_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF_POSGRN_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_State_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_State_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[State] ADD  CONSTRAINT [DF_State_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_SaleTaxRates_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleTaxRates] ADD  CONSTRAINT [DF_SaleTaxRates_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_SaleTaxRates_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleTaxRates] ADD  CONSTRAINT [DF_SaleTaxRates_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Terms_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms] ADD  CONSTRAINT [DF_Terms_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Terms_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms] ADD  CONSTRAINT [DF_Terms_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_DailyCash_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[DailyCash] ADD  CONSTRAINT [DF_DailyCash_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemGroup_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup] ADD  CONSTRAINT [DF_ItemGroup_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemGroup_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup] ADD  CONSTRAINT [DF_ItemGroup_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_City_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_City_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[City] ADD  CONSTRAINT [DF_City_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_SalesCategory_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleCategory] ADD  CONSTRAINT [DF_SalesCategory_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_SalesCategory_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleCategory] ADD  CONSTRAINT [DF_SalesCategory_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_POSGRNDetail_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseDetail] ADD  CONSTRAINT [DF_POSGRNDetail_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_POSGRNDetail_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseDetail] ADD  CONSTRAINT [DF_POSGRNDetail_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleSubModel_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSubModel] ADD  CONSTRAINT [DF_VehicleSubModel_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleSubModel_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSubModel] ADD  CONSTRAINT [DF_VehicleSubModel_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Supplier_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF_Supplier_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Supplier_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor] ADD  CONSTRAINT [DF_Supplier_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleSpecification_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSpecification] ADD  CONSTRAINT [DF_VehicleSpecification_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleSpecification_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSpecification] ADD  CONSTRAINT [DF_VehicleSpecification_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ZipCode_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ZipCode] ADD  CONSTRAINT [DF_ZipCode_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ZipCode_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ZipCode] ADD  CONSTRAINT [DF_ZipCode_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_CreditCards_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CreditCards] ADD  CONSTRAINT [DF_CreditCards_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_CreditCards_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CreditCards] ADD  CONSTRAINT [DF_CreditCards_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Department_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseDepartment] ADD  CONSTRAINT [DF_Department_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_CompanyInfo_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF_CompanyInfo_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Employee_IsLogin]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_IsLogin]  DEFAULT ((1)) FOR [IsLogin]
GO
/****** Object:  Default [DF_Teacher_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Teacher_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_LaborDepartment_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[LaborDepartment] ADD  CONSTRAINT [DF_LaborDepartment_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Configuration_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Configuration] ADD  CONSTRAINT [DF_Configuration_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseHolidays_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseHolidays] ADD  CONSTRAINT [DF_WarehouseHolidays_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseChores_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseChores] ADD  CONSTRAINT [DF_WarehouseChores_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseTiming_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseTiming] ADD  CONSTRAINT [DF_WarehouseTiming_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PurchaseOrder_TotalAmountOrder]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_TotalAmountOrder]  DEFAULT ((0)) FOR [TotalAmountOrder]
GO
/****** Object:  Default [DF_PurchaseOrder_TotalAmountReceived]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_TotalAmountReceived]  DEFAULT ((0)) FOR [TotalAmountReceived]
GO
/****** Object:  Default [DF_PurchaseOrder_TotalAmountBilled]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_TotalAmountBilled]  DEFAULT ((0)) FOR [TotalAmountBilled]
GO
/****** Object:  Default [DF_PurchaseOrder_TotalQtyOrder]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_TotalQtyOrder]  DEFAULT ((0)) FOR [TotalQtyOrder]
GO
/****** Object:  Default [DF_PurchaseOrder_TotalQtyReceived]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_TotalQtyReceived]  DEFAULT ((0)) FOR [TotalQtyReceived]
GO
/****** Object:  Default [DF_PurchaseOrder_TotalQtyBilled]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_TotalQtyBilled]  DEFAULT ((0)) FOR [TotalQtyBilled]
GO
/****** Object:  Default [DF_PurchaseOrder_IsProcessed]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_IsProcessed]  DEFAULT ((0)) FOR [IsProcessed]
GO
/****** Object:  Default [DF_PurchaseOrder_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PurchaseOrder_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_POR_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR] ADD  CONSTRAINT [DF_POR_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_POR_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR] ADD  CONSTRAINT [DF_POR_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Branch_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseStore] ADD  CONSTRAINT [DF_Branch_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Customer_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Customer_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_BankAccounts_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[BankAccounts] ADD  CONSTRAINT [DF_BankAccounts_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_BankAccounts_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[BankAccounts] ADD  CONSTRAINT [DF_BankAccounts_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PORDetail_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PORDetail] ADD  CONSTRAINT [DF_PORDetail_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PORDetail_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PORDetail] ADD  CONSTRAINT [DF_PORDetail_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_Item_ReOrderMin]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_ReOrderMin]  DEFAULT ((0)) FOR [ReOrderMin]
GO
/****** Object:  Default [DF_Item_ReOrderMax]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_ReOrderMax]  DEFAULT ((0)) FOR [ReOrderMax]
GO
/****** Object:  Default [DF_POSItemDetail_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_POSItemDetail_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_POSItemDetail_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_POSItemDetail_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_POSSale_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder] ADD  CONSTRAINT [DF_POSSale_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_POSSale_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder] ADD  CONSTRAINT [DF_POSSale_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_VehicleRegistration_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_VehicleRegistration_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_VehicleRegistration_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle] ADD  CONSTRAINT [DF_VehicleRegistration_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_WarehouseServicesDetail_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseServicesDetail] ADD  CONSTRAINT [DF_WarehouseServicesDetail_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemVendors_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemVendors] ADD  CONSTRAINT [DF_ItemVendors_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemVendors_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemVendors] ADD  CONSTRAINT [DF_ItemVendors_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_QtyOrdrd]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_QtyOrdrd]  DEFAULT ((0)) FOR [QtyOrdrd]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_PrevOrdrd]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_PrevOrdrd]  DEFAULT ((0)) FOR [PrevOrdrd]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_QtyRcvd]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_QtyRcvd]  DEFAULT ((0)) FOR [QtyRcvd]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_PrevRcvd]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_PrevRcvd]  DEFAULT ((0)) FOR [PrevRcvd]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_QtyBilled]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_QtyBilled]  DEFAULT ((0)) FOR [QtyBilled]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_PrevBilled]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_PrevBilled]  DEFAULT ((0)) FOR [PrevBilled]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_Cost]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_Cost]  DEFAULT ((0)) FOR [Cost]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_FET]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_FET]  DEFAULT ((0)) FOR [FET]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_Amount]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_PurchaseOrderDetails_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  CONSTRAINT [DF_PurchaseOrderDetails_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_ItemStock_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemStock] ADD  CONSTRAINT [DF_ItemStock_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_ItemStock_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemStock] ADD  CONSTRAINT [DF_ItemStock_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_CustomerVehicles_Active]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CustomerVehicles] ADD  CONSTRAINT [DF_CustomerVehicles_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_CustomerVehicles_IsLocked]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CustomerVehicles] ADD  CONSTRAINT [DF_CustomerVehicles_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  ForeignKey [FK_EmployeeAttendance_Employee]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeeAttendance]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAttendance_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[EmployeeAttendance] CHECK CONSTRAINT [FK_EmployeeAttendance_Employee]
GO
/****** Object:  ForeignKey [FK_EmployeeLeave_Employee]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[EmployeeLeave]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeLeave_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[EmployeeLeave] CHECK CONSTRAINT [FK_EmployeeLeave_Employee]
GO
/****** Object:  ForeignKey [FK_GeneralJournal_Employee]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[GeneralJournal]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournal_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[GeneralJournal] CHECK CONSTRAINT [FK_GeneralJournal_Employee]
GO
/****** Object:  ForeignKey [FK_tblRptD_tblRptM]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[tblRptD]  WITH CHECK ADD  CONSTRAINT [FK_tblRptD_tblRptM] FOREIGN KEY([MID])
REFERENCES [dbo].[tblRptM] ([ID])
GO
ALTER TABLE [dbo].[tblRptD] CHECK CONSTRAINT [FK_tblRptD_tblRptM]
GO
/****** Object:  ForeignKey [FK_VehicleModel_VehicleMake]    Script Date: 09/25/2019 12:30:38 ******/
ALTER TABLE [dbo].[VehicleModel]  WITH CHECK ADD  CONSTRAINT [FK_VehicleModel_VehicleMake] FOREIGN KEY([MakeID])
REFERENCES [dbo].[VehicleMake] ([ID])
GO
ALTER TABLE [dbo].[VehicleModel] CHECK CONSTRAINT [FK_VehicleModel_VehicleMake]
GO
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country]
GO
/****** Object:  ForeignKey [FK_SaleTaxRates_SaleTaxAuthority]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleTaxRates]  WITH CHECK ADD  CONSTRAINT [FK_SaleTaxRates_SaleTaxAuthority] FOREIGN KEY([SaleTaxAuthorityID1])
REFERENCES [dbo].[SaleTaxAuthority] ([ID])
GO
ALTER TABLE [dbo].[SaleTaxRates] CHECK CONSTRAINT [FK_SaleTaxRates_SaleTaxAuthority]
GO
/****** Object:  ForeignKey [FK_SaleTaxRates_SaleTaxAuthority1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleTaxRates]  WITH CHECK ADD  CONSTRAINT [FK_SaleTaxRates_SaleTaxAuthority1] FOREIGN KEY([SaleTaxAuthorityID2])
REFERENCES [dbo].[SaleTaxAuthority] ([ID])
GO
ALTER TABLE [dbo].[SaleTaxRates] CHECK CONSTRAINT [FK_SaleTaxRates_SaleTaxAuthority1]
GO
/****** Object:  ForeignKey [FK_SaleTaxRates_SaleTaxAuthority2]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleTaxRates]  WITH CHECK ADD  CONSTRAINT [FK_SaleTaxRates_SaleTaxAuthority2] FOREIGN KEY([SaleTaxAuthorityID3])
REFERENCES [dbo].[SaleTaxAuthority] ([ID])
GO
ALTER TABLE [dbo].[SaleTaxRates] CHECK CONSTRAINT [FK_SaleTaxRates_SaleTaxAuthority2]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountDayOfThe]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountDayOfThe] FOREIGN KEY([DueByDayOfTheD1])
REFERENCES [dbo].[DiscountDayOfThe] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountDayOfThe]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountDayOfThe1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountDayOfThe1] FOREIGN KEY([Discount1DayOfTheD1])
REFERENCES [dbo].[DiscountDayOfThe] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountDayOfThe1]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountDayOfThe2]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountDayOfThe2] FOREIGN KEY([Discount2DayOfTheD1])
REFERENCES [dbo].[DiscountDayOfThe] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountDayOfThe2]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountDayOfThe3]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountDayOfThe3] FOREIGN KEY([Discount3DayOfTheD1])
REFERENCES [dbo].[DiscountDayOfThe] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountDayOfThe3]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountMonth]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountMonth] FOREIGN KEY([DueByMonthD1])
REFERENCES [dbo].[DiscountMonth] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountMonth]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountMonth1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountMonth1] FOREIGN KEY([Discount1MonthD1])
REFERENCES [dbo].[DiscountMonth] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountMonth1]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountMonth2]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountMonth2] FOREIGN KEY([Discount2MonthD1])
REFERENCES [dbo].[DiscountMonth] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountMonth2]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountMonth3]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountMonth3] FOREIGN KEY([Discount3MonthD1])
REFERENCES [dbo].[DiscountMonth] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountMonth3]
GO
/****** Object:  ForeignKey [FK_Terms_DiscountTypes]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Terms]  WITH CHECK ADD  CONSTRAINT [FK_Terms_DiscountTypes] FOREIGN KEY([DiscountTypeID])
REFERENCES [dbo].[DiscountTypes] ([ID])
GO
ALTER TABLE [dbo].[Terms] CHECK CONSTRAINT [FK_Terms_DiscountTypes]
GO
/****** Object:  ForeignKey [FK_DailyCash_Account]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[DailyCash]  WITH CHECK ADD  CONSTRAINT [FK_DailyCash_Account] FOREIGN KEY([mAccID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[DailyCash] CHECK CONSTRAINT [FK_DailyCash_Account]
GO
/****** Object:  ForeignKey [FK_ItemGroup_Account]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup]  WITH CHECK ADD  CONSTRAINT [FK_ItemGroup_Account] FOREIGN KEY([AssetAcctID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[ItemGroup] CHECK CONSTRAINT [FK_ItemGroup_Account]
GO
/****** Object:  ForeignKey [FK_ItemGroup_Account1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup]  WITH CHECK ADD  CONSTRAINT [FK_ItemGroup_Account1] FOREIGN KEY([SalesAcctID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[ItemGroup] CHECK CONSTRAINT [FK_ItemGroup_Account1]
GO
/****** Object:  ForeignKey [FK_ItemGroup_Account2]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup]  WITH CHECK ADD  CONSTRAINT [FK_ItemGroup_Account2] FOREIGN KEY([CGSAcctID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[ItemGroup] CHECK CONSTRAINT [FK_ItemGroup_Account2]
GO
/****** Object:  ForeignKey [FK_ItemGroup_ItemGroupType]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup]  WITH CHECK ADD  CONSTRAINT [FK_ItemGroup_ItemGroupType] FOREIGN KEY([GroupTypeID])
REFERENCES [dbo].[ItemGroupType] ([ID])
GO
ALTER TABLE [dbo].[ItemGroup] CHECK CONSTRAINT [FK_ItemGroup_ItemGroupType]
GO
/****** Object:  ForeignKey [FK_ItemGroup_RoundingMethod]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemGroup]  WITH CHECK ADD  CONSTRAINT [FK_ItemGroup_RoundingMethod] FOREIGN KEY([RoundingMethodID])
REFERENCES [dbo].[RoundingMethod] ([ID])
GO
ALTER TABLE [dbo].[ItemGroup] CHECK CONSTRAINT [FK_ItemGroup_RoundingMethod]
GO
/****** Object:  ForeignKey [FK_City_Country]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
/****** Object:  ForeignKey [FK_City_State]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO
/****** Object:  ForeignKey [FK_SaleCategory_ItemPriceLevel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleCategory]  WITH CHECK ADD  CONSTRAINT [FK_SaleCategory_ItemPriceLevel] FOREIGN KEY([ItemPriceLevelID])
REFERENCES [dbo].[ItemPriceLevel] ([ID])
GO
ALTER TABLE [dbo].[SaleCategory] CHECK CONSTRAINT [FK_SaleCategory_ItemPriceLevel]
GO
/****** Object:  ForeignKey [FK_SaleCategory_SaleTaxRates]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[SaleCategory]  WITH CHECK ADD  CONSTRAINT [FK_SaleCategory_SaleTaxRates] FOREIGN KEY([SaleTaxRateID])
REFERENCES [dbo].[SaleTaxRates] ([ID])
GO
ALTER TABLE [dbo].[SaleCategory] CHECK CONSTRAINT [FK_SaleCategory_SaleTaxRates]
GO
/****** Object:  ForeignKey [FK_POSGRNDetail_POSGRN]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_POSGRNDetail_POSGRN] FOREIGN KEY([MID])
REFERENCES [dbo].[Purchase] ([ID])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_POSGRNDetail_POSGRN]
GO
/****** Object:  ForeignKey [FK_VehicleSubModel_VehicleMake]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSubModel]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSubModel_VehicleMake] FOREIGN KEY([MakeID])
REFERENCES [dbo].[VehicleMake] ([ID])
GO
ALTER TABLE [dbo].[VehicleSubModel] CHECK CONSTRAINT [FK_VehicleSubModel_VehicleMake]
GO
/****** Object:  ForeignKey [FK_VehicleSubModel_VehicleModel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSubModel]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSubModel_VehicleModel] FOREIGN KEY([ModelID])
REFERENCES [dbo].[VehicleModel] ([ID])
GO
ALTER TABLE [dbo].[VehicleSubModel] CHECK CONSTRAINT [FK_VehicleSubModel_VehicleModel]
GO
/****** Object:  ForeignKey [FK_Vendor_City]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_City]
GO
/****** Object:  ForeignKey [FK_Vendor_City1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_City1] FOREIGN KEY([BillingCityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_City1]
GO
/****** Object:  ForeignKey [FK_Vendor_Country]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Country]
GO
/****** Object:  ForeignKey [FK_Vendor_Country1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Country1] FOREIGN KEY([BillingCountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Country1]
GO
/****** Object:  ForeignKey [FK_Vendor_CutOffDay]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_CutOffDay] FOREIGN KEY([CutOffDayID])
REFERENCES [dbo].[CutOffDay] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_CutOffDay]
GO
/****** Object:  ForeignKey [FK_Vendor_State]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_State]
GO
/****** Object:  ForeignKey [FK_Vendor_State1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_State1] FOREIGN KEY([BillingStateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_State1]
GO
/****** Object:  ForeignKey [FK_Vendor_Terms]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Terms] FOREIGN KEY([TermsID])
REFERENCES [dbo].[Terms] ([ID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Terms]
GO
/****** Object:  ForeignKey [FK_VehicleSpecification_VehicleMake]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSpecification]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSpecification_VehicleMake] FOREIGN KEY([MakeID])
REFERENCES [dbo].[VehicleMake] ([ID])
GO
ALTER TABLE [dbo].[VehicleSpecification] CHECK CONSTRAINT [FK_VehicleSpecification_VehicleMake]
GO
/****** Object:  ForeignKey [FK_VehicleSpecification_VehicleModel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSpecification]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSpecification_VehicleModel] FOREIGN KEY([ModelID])
REFERENCES [dbo].[VehicleModel] ([ID])
GO
ALTER TABLE [dbo].[VehicleSpecification] CHECK CONSTRAINT [FK_VehicleSpecification_VehicleModel]
GO
/****** Object:  ForeignKey [FK_VehicleSpecification_VehicleSubModel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSpecification]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSpecification_VehicleSubModel] FOREIGN KEY([SubModelID])
REFERENCES [dbo].[VehicleSubModel] ([ID])
GO
ALTER TABLE [dbo].[VehicleSpecification] CHECK CONSTRAINT [FK_VehicleSpecification_VehicleSubModel]
GO
/****** Object:  ForeignKey [FK_VehicleSpecification_VehicleYear]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[VehicleSpecification]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSpecification_VehicleYear] FOREIGN KEY([YearID])
REFERENCES [dbo].[VehicleYear] ([ID])
GO
ALTER TABLE [dbo].[VehicleSpecification] CHECK CONSTRAINT [FK_VehicleSpecification_VehicleYear]
GO
/****** Object:  ForeignKey [FK_ZipCode_City]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ZipCode]  WITH CHECK ADD  CONSTRAINT [FK_ZipCode_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[ZipCode] CHECK CONSTRAINT [FK_ZipCode_City]
GO
/****** Object:  ForeignKey [FK_ZipCode_Country]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ZipCode]  WITH CHECK ADD  CONSTRAINT [FK_ZipCode_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[ZipCode] CHECK CONSTRAINT [FK_ZipCode_Country]
GO
/****** Object:  ForeignKey [FK_ZipCode_State]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ZipCode]  WITH CHECK ADD  CONSTRAINT [FK_ZipCode_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[ZipCode] CHECK CONSTRAINT [FK_ZipCode_State]
GO
/****** Object:  ForeignKey [FK_CreditCards_Vendor]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CreditCards]  WITH CHECK ADD  CONSTRAINT [FK_CreditCards_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[CreditCards] CHECK CONSTRAINT [FK_CreditCards_Vendor]
GO
/****** Object:  ForeignKey [FK_Department_Employee]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseDepartment]  WITH CHECK ADD  CONSTRAINT [FK_Department_Employee] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[WarehouseDepartment] CHECK CONSTRAINT [FK_Department_Employee]
GO
/****** Object:  ForeignKey [FK_Department_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseDepartment]  WITH CHECK ADD  CONSTRAINT [FK_Department_Warehouse] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[WarehouseDepartment] CHECK CONSTRAINT [FK_Department_Warehouse]
GO
/****** Object:  ForeignKey [FK_Warehouse_City]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_City]
GO
/****** Object:  ForeignKey [FK_Warehouse_Country]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_Country]
GO
/****** Object:  ForeignKey [FK_Warehouse_PayWeekStartOn]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_PayWeekStartOn] FOREIGN KEY([PayWeekStartOn])
REFERENCES [dbo].[PayWeekStartOn] ([ID])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_PayWeekStartOn]
GO
/****** Object:  ForeignKey [FK_Warehouse_State]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_State]
GO
/****** Object:  ForeignKey [FK_Warehouse_ZipCode]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_ZipCode] FOREIGN KEY([ZipCode])
REFERENCES [dbo].[ZipCode] ([ID])
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_ZipCode]
GO
/****** Object:  ForeignKey [FK_Employee_CompanyInfo]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_CompanyInfo] FOREIGN KEY([CoID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_CompanyInfo]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[WarehouseDepartment] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_Employee_EmployeeComBaseOn]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeComBaseOn] FOREIGN KEY([CommisionBaseOn])
REFERENCES [dbo].[EmployeeComBaseOn] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeComBaseOn]
GO
/****** Object:  ForeignKey [FK_Employee_LaborDepartment]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_LaborDepartment] FOREIGN KEY([LaborDepID])
REFERENCES [dbo].[LaborDepartment] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_LaborDepartment]
GO
/****** Object:  ForeignKey [FK_Employee_UserGroups]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_UserGroups] FOREIGN KEY([UserGroupID])
REFERENCES [dbo].[UserGroups] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_UserGroups]
GO
/****** Object:  ForeignKey [FK_LaborDepartment_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[LaborDepartment]  WITH CHECK ADD  CONSTRAINT [FK_LaborDepartment_Warehouse] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[LaborDepartment] CHECK CONSTRAINT [FK_LaborDepartment_Warehouse]
GO
/****** Object:  ForeignKey [FK_Configuration_CompanyInfo]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Configuration]  WITH CHECK ADD  CONSTRAINT [FK_Configuration_CompanyInfo] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[Configuration] CHECK CONSTRAINT [FK_Configuration_CompanyInfo]
GO
/****** Object:  ForeignKey [FK_WarehouseHolidays_Holidays]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseHolidays]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseHolidays_Holidays] FOREIGN KEY([HolidayID])
REFERENCES [dbo].[Holidays] ([ID])
GO
ALTER TABLE [dbo].[WarehouseHolidays] CHECK CONSTRAINT [FK_WarehouseHolidays_Holidays]
GO
/****** Object:  ForeignKey [FK_WarehouseHolidays_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseHolidays]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseHolidays_Warehouse] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[WarehouseHolidays] CHECK CONSTRAINT [FK_WarehouseHolidays_Warehouse]
GO
/****** Object:  ForeignKey [FK_WarehouseChores_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseChores]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseChores_Warehouse] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[WarehouseChores] CHECK CONSTRAINT [FK_WarehouseChores_Warehouse]
GO
/****** Object:  ForeignKey [FK_WarehouseTiming_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseTiming]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseTiming_Warehouse] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[WarehouseTiming] CHECK CONSTRAINT [FK_WarehouseTiming_Warehouse]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_Employee]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Employee] FOREIGN KEY([LastReceivedBy])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Employee]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_PurchaseOrder]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_PurchaseOrder] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_PurchaseOrder]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_PurchaseOrderAutoNo]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_PurchaseOrderAutoNo] FOREIGN KEY([POID])
REFERENCES [dbo].[PurchaseOrderAutoNo] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_PurchaseOrderAutoNo]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Warehouse] FOREIGN KEY([WarehouseID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Warehouse]
GO
/****** Object:  ForeignKey [FK_PurchaseOrder_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_POR_Employee]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR]  WITH CHECK ADD  CONSTRAINT [FK_POR_Employee] FOREIGN KEY([OrderByID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[POR] CHECK CONSTRAINT [FK_POR_Employee]
GO
/****** Object:  ForeignKey [FK_POR_Employee1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR]  WITH CHECK ADD  CONSTRAINT [FK_POR_Employee1] FOREIGN KEY([ReceivedByID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[POR] CHECK CONSTRAINT [FK_POR_Employee1]
GO
/****** Object:  ForeignKey [FK_POR_Employee2]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR]  WITH CHECK ADD  CONSTRAINT [FK_POR_Employee2] FOREIGN KEY([BillByID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[POR] CHECK CONSTRAINT [FK_POR_Employee2]
GO
/****** Object:  ForeignKey [FK_POR_PaymentMode]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR]  WITH CHECK ADD  CONSTRAINT [FK_POR_PaymentMode] FOREIGN KEY([PaymentModeID])
REFERENCES [dbo].[PaymentMode] ([ID])
GO
ALTER TABLE [dbo].[POR] CHECK CONSTRAINT [FK_POR_PaymentMode]
GO
/****** Object:  ForeignKey [FK_POR_Vendor]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR]  WITH CHECK ADD  CONSTRAINT [FK_POR_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[POR] CHECK CONSTRAINT [FK_POR_Vendor]
GO
/****** Object:  ForeignKey [FK_POR_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[POR]  WITH CHECK ADD  CONSTRAINT [FK_POR_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[POR] CHECK CONSTRAINT [FK_POR_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_WarehouseStore_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseStore]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseStore_Warehouse] FOREIGN KEY([MID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[WarehouseStore] CHECK CONSTRAINT [FK_WarehouseStore_Warehouse]
GO
/****** Object:  ForeignKey [FK_WarehouseStoreRack_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseStoreRack]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseStoreRack_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[WarehouseStoreRack] CHECK CONSTRAINT [FK_WarehouseStoreRack_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_GeneralJournalDetail_Account]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[GeneralJournalDetail]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournalDetail_Account] FOREIGN KEY([Paidto])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[GeneralJournalDetail] CHECK CONSTRAINT [FK_GeneralJournalDetail_Account]
GO
/****** Object:  ForeignKey [FK_GeneralJournalDetail_GeneralJournal]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[GeneralJournalDetail]  WITH CHECK ADD  CONSTRAINT [FK_GeneralJournalDetail_GeneralJournal] FOREIGN KEY([MID])
REFERENCES [dbo].[GeneralJournal] ([ID])
GO
ALTER TABLE [dbo].[GeneralJournalDetail] CHECK CONSTRAINT [FK_GeneralJournalDetail_GeneralJournal]
GO
/****** Object:  ForeignKey [FK_Customer_City]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
GO
/****** Object:  ForeignKey [FK_Customer_City1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City1] FOREIGN KEY([ShippingCityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City1]
GO
/****** Object:  ForeignKey [FK_Customer_Country]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Country]
GO
/****** Object:  ForeignKey [FK_Customer_PriceLevel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_PriceLevel] FOREIGN KEY([PriceLevelID])
REFERENCES [dbo].[ItemPriceLevel] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_PriceLevel]
GO
/****** Object:  ForeignKey [FK_Customer_ReferredBy]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ReferredBy] FOREIGN KEY([ReferredByID])
REFERENCES [dbo].[ReferredBy] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ReferredBy]
GO
/****** Object:  ForeignKey [FK_Customer_SalesCategory]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_SalesCategory] FOREIGN KEY([SaleCategoryID])
REFERENCES [dbo].[SaleCategory] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_SalesCategory]
GO
/****** Object:  ForeignKey [FK_Customer_SaleTaxRates]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_SaleTaxRates] FOREIGN KEY([SaleTaxRateID])
REFERENCES [dbo].[SaleTaxRates] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_SaleTaxRates]
GO
/****** Object:  ForeignKey [FK_Customer_ShipVia]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ShipVia] FOREIGN KEY([ShipViaID])
REFERENCES [dbo].[ShipVia] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ShipVia]
GO
/****** Object:  ForeignKey [FK_Customer_State]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_State]
GO
/****** Object:  ForeignKey [FK_Customer_State1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_State1] FOREIGN KEY([ShippingStateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_State1]
GO
/****** Object:  ForeignKey [FK_Customer_Terms]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Terms] FOREIGN KEY([SaleTermID])
REFERENCES [dbo].[Terms] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Terms]
GO
/****** Object:  ForeignKey [FK_Customer_Vendor]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Vendor]
GO
/****** Object:  ForeignKey [FK_Customer_Vendor1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Vendor1] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Vendor1]
GO
/****** Object:  ForeignKey [FK_Customer_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_Customer_ZipCode]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ZipCode] FOREIGN KEY([ZipCode])
REFERENCES [dbo].[ZipCode] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ZipCode]
GO
/****** Object:  ForeignKey [FK_Customer_ZipCode1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ZipCode1] FOREIGN KEY([ShippingZipCode])
REFERENCES [dbo].[ZipCode] ([ID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ZipCode1]
GO
/****** Object:  ForeignKey [FK_BankAccounts_Account]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[BankAccounts]  WITH CHECK ADD  CONSTRAINT [FK_BankAccounts_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[BankAccounts] CHECK CONSTRAINT [FK_BankAccounts_Account]
GO
/****** Object:  ForeignKey [FK_BankAccounts_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[BankAccounts]  WITH CHECK ADD  CONSTRAINT [FK_BankAccounts_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[BankAccounts] CHECK CONSTRAINT [FK_BankAccounts_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_WorkOrderDetail_Item]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrderDetail_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[WorkOrderDetail] CHECK CONSTRAINT [FK_WorkOrderDetail_Item]
GO
/****** Object:  ForeignKey [FK_WorkOrderDetail_WarehouseServices]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrderDetail_WarehouseServices] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[WarehouseServices] ([ID])
GO
ALTER TABLE [dbo].[WorkOrderDetail] CHECK CONSTRAINT [FK_WorkOrderDetail_WarehouseServices]
GO
/****** Object:  ForeignKey [FK_WorkOrderDetail_WorkOrder]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrderDetail_WorkOrder] FOREIGN KEY([MID])
REFERENCES [dbo].[WorkOrder] ([ID])
GO
ALTER TABLE [dbo].[WorkOrderDetail] CHECK CONSTRAINT [FK_WorkOrderDetail_WorkOrder]
GO
/****** Object:  ForeignKey [FK_PORDetail_Item]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PORDetail]  WITH CHECK ADD  CONSTRAINT [FK_PORDetail_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[PORDetail] CHECK CONSTRAINT [FK_PORDetail_Item]
GO
/****** Object:  ForeignKey [FK_PORDetail_POR]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PORDetail]  WITH CHECK ADD  CONSTRAINT [FK_PORDetail_POR] FOREIGN KEY([MID])
REFERENCES [dbo].[POR] ([ID])
GO
ALTER TABLE [dbo].[PORDetail] CHECK CONSTRAINT [FK_PORDetail_POR]
GO
/****** Object:  ForeignKey [FK_Item_ItemGroup]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_ItemGroup] FOREIGN KEY([ItemGroupID])
REFERENCES [dbo].[ItemGroup] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_ItemGroup]
GO
/****** Object:  ForeignKey [FK_Item_ItemManufacturer]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_ItemManufacturer] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[ItemManufacturer] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_ItemManufacturer]
GO
/****** Object:  ForeignKey [FK_Item_ItemType]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_ItemType] FOREIGN KEY([ItemTypeID])
REFERENCES [dbo].[ItemType] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_ItemType]
GO
/****** Object:  ForeignKey [FK_Item_SpiffsType]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_SpiffsType] FOREIGN KEY([SpiffsTypeID])
REFERENCES [dbo].[SpiffsType] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_SpiffsType]
GO
/****** Object:  ForeignKey [FK_Item_Vendor]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Vendor]
GO
/****** Object:  ForeignKey [FK_Item_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_Item_WarehouseStoreRack]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_WarehouseStoreRack] FOREIGN KEY([RackID])
REFERENCES [dbo].[WarehouseStoreRack] ([ID])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_WarehouseStoreRack]
GO
/****** Object:  ForeignKey [FK_WorkOrder_Customer]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Customer]
GO
/****** Object:  ForeignKey [FK_WorkOrder_Employee]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Employee] FOREIGN KEY([SaleRepID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Employee]
GO
/****** Object:  ForeignKey [FK_WorkOrder_Employee1]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Employee1] FOREIGN KEY([MechID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Employee1]
GO
/****** Object:  ForeignKey [FK_WorkOrder_Employee2]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Employee2] FOREIGN KEY([CreatedByID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Employee2]
GO
/****** Object:  ForeignKey [FK_WorkOrder_ItemPriceLevel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_ItemPriceLevel] FOREIGN KEY([PriceLevelID])
REFERENCES [dbo].[ItemPriceLevel] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_ItemPriceLevel]
GO
/****** Object:  ForeignKey [FK_WorkOrder_ReferredBy]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_ReferredBy] FOREIGN KEY([ReferredByID])
REFERENCES [dbo].[ReferredBy] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_ReferredBy]
GO
/****** Object:  ForeignKey [FK_WorkOrder_SaleCategory]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_SaleCategory] FOREIGN KEY([SaleCategoryID])
REFERENCES [dbo].[SaleCategory] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_SaleCategory]
GO
/****** Object:  ForeignKey [FK_WorkOrder_SaleTaxRates]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_SaleTaxRates] FOREIGN KEY([SaleTaxRateID])
REFERENCES [dbo].[SaleTaxRates] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_SaleTaxRates]
GO
/****** Object:  ForeignKey [FK_WorkOrder_ShipVia]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_ShipVia] FOREIGN KEY([ShipViaID])
REFERENCES [dbo].[ShipVia] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_ShipVia]
GO
/****** Object:  ForeignKey [FK_WorkOrder_Terms]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Terms] FOREIGN KEY([SaleTermID])
REFERENCES [dbo].[Terms] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Terms]
GO
/****** Object:  ForeignKey [FK_WorkOrder_Vehicle]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Vehicle] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicle] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Vehicle]
GO
/****** Object:  ForeignKey [FK_WorkOrder_WarehouseBay]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_WarehouseBay] FOREIGN KEY([WarehouseBayID])
REFERENCES [dbo].[WarehouseBay] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_WarehouseBay]
GO
/****** Object:  ForeignKey [FK_WorkOrder_WorkOrderAutoNo]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_WorkOrderAutoNo] FOREIGN KEY([WorkOrderNo])
REFERENCES [dbo].[WorkOrderAutoNo] ([ID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_WorkOrderAutoNo]
GO
/****** Object:  ForeignKey [FK_Vehicle_Customer]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Customer]
GO
/****** Object:  ForeignKey [FK_Vehicle_State]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_State]
GO
/****** Object:  ForeignKey [FK_Vehicle_VehicleColor]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleColor] FOREIGN KEY([VehicleColorID])
REFERENCES [dbo].[VehicleColor] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleColor]
GO
/****** Object:  ForeignKey [FK_Vehicle_VehicleMake]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleMake] FOREIGN KEY([VehicleMakeID])
REFERENCES [dbo].[VehicleMake] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleMake]
GO
/****** Object:  ForeignKey [FK_Vehicle_VehicleModel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleModel] FOREIGN KEY([VehicleModelID])
REFERENCES [dbo].[VehicleModel] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleModel]
GO
/****** Object:  ForeignKey [FK_Vehicle_VehicleSubModel]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleSubModel] FOREIGN KEY([VehicleSubModelID])
REFERENCES [dbo].[VehicleSubModel] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleSubModel]
GO
/****** Object:  ForeignKey [FK_Vehicle_VehicleTransmission]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleTransmission] FOREIGN KEY([VehicleTransmissionID])
REFERENCES [dbo].[VehicleTransmission] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleTransmission]
GO
/****** Object:  ForeignKey [FK_Vehicle_VehicleYear]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleYear] FOREIGN KEY([VehicleYearID])
REFERENCES [dbo].[VehicleYear] ([ID])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_VehicleYear]
GO
/****** Object:  ForeignKey [FK_WarehouseServicesDetail_Item]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseServicesDetail]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseServicesDetail_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[WarehouseServicesDetail] CHECK CONSTRAINT [FK_WarehouseServicesDetail_Item]
GO
/****** Object:  ForeignKey [FK_WarehouseServicesDetail_WarehouseServices]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[WarehouseServicesDetail]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseServicesDetail_WarehouseServices] FOREIGN KEY([MID])
REFERENCES [dbo].[WarehouseServices] ([ID])
GO
ALTER TABLE [dbo].[WarehouseServicesDetail] CHECK CONSTRAINT [FK_WarehouseServicesDetail_WarehouseServices]
GO
/****** Object:  ForeignKey [FK_ItemVendors_Item]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemVendors]  WITH CHECK ADD  CONSTRAINT [FK_ItemVendors_Item] FOREIGN KEY([MID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[ItemVendors] CHECK CONSTRAINT [FK_ItemVendors_Item]
GO
/****** Object:  ForeignKey [FK_PurchaseOrderDetails_Item]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetails_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_PurchaseOrderDetails_Item]
GO
/****** Object:  ForeignKey [FK_PurchaseOrderDetails_PurchaseOrder]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetails_PurchaseOrder] FOREIGN KEY([MID])
REFERENCES [dbo].[PurchaseOrder] ([ID])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_PurchaseOrderDetails_PurchaseOrder]
GO
/****** Object:  ForeignKey [FK_ItemStock_Item]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemStock]  WITH CHECK ADD  CONSTRAINT [FK_ItemStock_Item] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Item] ([ID])
GO
ALTER TABLE [dbo].[ItemStock] CHECK CONSTRAINT [FK_ItemStock_Item]
GO
/****** Object:  ForeignKey [FK_ItemStock_Warehouse]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemStock]  WITH CHECK ADD  CONSTRAINT [FK_ItemStock_Warehouse] FOREIGN KEY([WarehouseID])
REFERENCES [dbo].[Warehouse] ([ID])
GO
ALTER TABLE [dbo].[ItemStock] CHECK CONSTRAINT [FK_ItemStock_Warehouse]
GO
/****** Object:  ForeignKey [FK_ItemStock_WarehouseStore]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[ItemStock]  WITH CHECK ADD  CONSTRAINT [FK_ItemStock_WarehouseStore] FOREIGN KEY([StoreID])
REFERENCES [dbo].[WarehouseStore] ([ID])
GO
ALTER TABLE [dbo].[ItemStock] CHECK CONSTRAINT [FK_ItemStock_WarehouseStore]
GO
/****** Object:  ForeignKey [FK_CustomerVehicles_Customer]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CustomerVehicles]  WITH CHECK ADD  CONSTRAINT [FK_CustomerVehicles_Customer] FOREIGN KEY([MID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[CustomerVehicles] CHECK CONSTRAINT [FK_CustomerVehicles_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerVehicles_Vehicle]    Script Date: 09/25/2019 12:30:41 ******/
ALTER TABLE [dbo].[CustomerVehicles]  WITH CHECK ADD  CONSTRAINT [FK_CustomerVehicles_Vehicle] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[Vehicle] ([ID])
GO
ALTER TABLE [dbo].[CustomerVehicles] CHECK CONSTRAINT [FK_CustomerVehicles_Vehicle]
GO
