/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dict].[Country] ON 

GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (1, N'Россия', N'RU', CAST(N'2018-08-15T05:26:48.080' AS DateTime), CAST(N'2018-08-15T05:26:48.080' AS DateTime))
GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (2, N'Великобритания', N'UK', CAST(N'2018-08-15T05:27:02.630' AS DateTime), CAST(N'2018-08-15T05:27:02.630' AS DateTime))
GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (3, N'США', N'US', CAST(N'2018-08-15T05:27:13.490' AS DateTime), CAST(N'2018-08-15T05:27:13.490' AS DateTime))
GO
SET IDENTITY_INSERT [dict].[Country] OFF
GO
SET IDENTITY_INSERT [dict].[CountryVisaType] ON 

GO
INSERT [dict].[CountryVisaType] ([Id], [CountryId], [Name], [Code], [Description], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (1, 1, N'Резиденство РФ', N'RUS', N'Подсчет производится по календарному году с 1 января по 31 декабря. День вьезда и выезда считается днем, проведенным в РФ.', 1, 1, 183, NULL)
GO
INSERT [dict].[CountryVisaType] ([Id], [CountryId], [Name], [Code], [Description], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (3, 2, N'Налоговое резидентство UK (90 дней)', N'UK90', N'Подсчет дней производится по полуночам, проведенным в UK по местному времени и ведется с 6 апреля текущего года по 5 апреля следующего года.', 1, 1, 90, N'00:00:00')
GO
INSERT [dict].[CountryVisaType] ([Id], [CountryId], [Name], [Code], [Description], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (4, 2, N'Налоговое резидентство UK (120 дней)', N'UK120', N'Подсчет дней производится по полуночам, проведенным в UK по местному времени и ведется с 6 апреля текущего года по 5 апреля следующего года.', 1, 1, 120, N'00:00:00')
GO
INSERT [dict].[CountryVisaType] ([Id], [CountryId], [Name], [Code], [Description], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (5, 2, N'Налоговое резидентство UK (180 дней)', N'UK180', N'Подсчет дней производится по полуночам, проведенным в UK по местному времени и ведется с 6 апреля текущего года по 5 апреля следующего года.', 1, 1, 180, N'00:00:00')
GO
SET IDENTITY_INSERT [dict].[CountryVisaType] OFF
GO
SET IDENTITY_INSERT [auth].[User] ON 

GO
INSERT [auth].[User] ([Id], [Email], [Password], [FirstName], [LastName], [MiddleName], [Photo], [PhoneNumber], [Status], [CreatedOn], [ModifiedOn], [LastLoginOn]) VALUES (1, N'smetaninatv@yandex.ru', N'1', N'Татьяна', N'Сметанина', NULL, NULL, N'+79031222341', 1, CAST(N'2018-08-12T12:40:26.357' AS DateTime), CAST(N'2018-08-12T12:40:26.357' AS DateTime), CAST(N'2018-08-15T07:53:18.893' AS DateTime))
GO
SET IDENTITY_INSERT [auth].[User] OFF
GO
SET IDENTITY_INSERT [map].[UserCountryVisa] ON 

GO
INSERT [map].[UserCountryVisa] ([Id], [UserId], [VisaTypeId], [AllowNotification], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 1, 1, NULL, NULL)
GO
INSERT [map].[UserCountryVisa] ([Id], [UserId], [VisaTypeId], [AllowNotification], [CreatedOn], [ModifiedOn]) VALUES (2, 1, 2, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [map].[UserCountryVisa] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTrackingSchedule] ON 

GO
INSERT [dbo].[UserTrackingSchedule] ([Id], [UserId], [ScheduledHours], [ScheduledDays], [LastRun], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 4, 1, CAST(N'2018-08-12T12:00:00.000' AS DateTime), CAST(N'2018-08-12T13:06:50.730' AS DateTime), CAST(N'2018-08-12T13:06:50.730' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserTrackingSchedule] OFF
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (0, N'Undefined')
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (1, N'Login')
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (2, N'Logoff')
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (3, N'ChangeSettings')
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (4, N'ChangeLocation')
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (5, N'Unauthorized')
GO
INSERT [enum].[LogActionType] ([Id], [Name]) VALUES (100, N'Exception')
GO
SET IDENTITY_INSERT [dict].[CountryFinancialPeriod] ON 

GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (2, 2, CAST(N'2018-04-06T00:00:00.000' AS DateTime), CAST(N'2018-04-05T00:00:00.000' AS DateTime))
GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (3, 3, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dict].[CountryFinancialPeriod] OFF
GO

