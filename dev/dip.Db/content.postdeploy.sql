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
SET IDENTITY_INSERT [auth].[User] ON 

GO
INSERT [auth].[User] ([Id], [Email], [Password], [FirstName], [LastName], [MiddleName], [Photo], [PhoneNumber], [Status], [CreatedOn], [ModifiedOn], [LastLoginOn]) VALUES (1, N'smetaninatv@yandex.ru', N'1', N'Татьяна', N'Сметанина', NULL, NULL, N'+79031222341', 1, CAST(N'2018-08-12T12:40:26.357' AS DateTime), CAST(N'2018-08-12T12:40:26.357' AS DateTime), CAST(N'2018-11-12T12:20:01.970' AS DateTime))
GO
INSERT [auth].[User] ([Id], [Email], [Password], [FirstName], [LastName], [MiddleName], [Photo], [PhoneNumber], [Status], [CreatedOn], [ModifiedOn], [LastLoginOn]) VALUES (5, N'test@mail.ru', N'1', N'User', N'Test', NULL, NULL, N' 79031222341', 1, CAST(N'2018-11-12T13:28:01.657' AS DateTime), CAST(N'2018-11-12T13:28:01.657' AS DateTime), CAST(N'2018-11-12T14:20:08.810' AS DateTime))
GO
SET IDENTITY_INSERT [auth].[User] OFF
GO
SET IDENTITY_INSERT [dict].[Country] ON 

GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (1, N'Россия', N'RU', CAST(N'2018-08-15T05:26:48.080' AS DateTime), CAST(N'2018-08-15T05:26:48.080' AS DateTime))
GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (2, N'Великобритания', N'UK', CAST(N'2018-08-15T05:27:02.630' AS DateTime), CAST(N'2018-08-15T05:27:02.630' AS DateTime))
GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (3, N'США', N'US', CAST(N'2018-08-15T05:27:13.490' AS DateTime), CAST(N'2018-08-15T05:27:13.490' AS DateTime))
GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (4, N' Уганда', N'ug', CAST(N'2018-11-03T15:00:12.750' AS DateTime), CAST(N'2018-11-03T15:00:12.750' AS DateTime))
GO
INSERT [dict].[Country] ([Id], [Name], [Code], [CreatedOn], [ModifiedOn]) VALUES (5, N'Canada', N'CA', CAST(N'2018-11-11T15:26:57.053' AS DateTime), CAST(N'2018-11-11T16:01:37.477' AS DateTime))
GO
SET IDENTITY_INSERT [dict].[Country] OFF
GO
SET IDENTITY_INSERT [map].[UserCountry] ON 

GO
INSERT [map].[UserCountry] ([Id], [UserId], [CountryId], [IsDefault], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 1, 1, CAST(N'2018-10-12T16:44:35.133' AS DateTime), CAST(N'2018-10-12T16:44:35.133' AS DateTime))
GO
INSERT [map].[UserCountry] ([Id], [UserId], [CountryId], [IsDefault], [CreatedOn], [ModifiedOn]) VALUES (3, 1, 5, 0, CAST(N'2018-11-11T15:26:57.070' AS DateTime), CAST(N'2018-11-11T16:01:37.507' AS DateTime))
GO
SET IDENTITY_INSERT [map].[UserCountry] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTrackingSchedule] ON 

GO
INSERT [dbo].[UserTrackingSchedule] ([Id], [UserId], [ScheduledHours], [ScheduledDays], [ScheduledNotificationId], [Enabled], [LastRun], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 4, 1, NULL, 1, CAST(N'2018-11-12T13:00:00.000' AS DateTime), CAST(N'2018-08-12T13:06:50.730' AS DateTime), CAST(N'2018-11-12T07:45:02.950' AS DateTime))
GO
INSERT [dbo].[UserTrackingSchedule] ([Id], [UserId], [ScheduledHours], [ScheduledDays], [ScheduledNotificationId], [Enabled], [LastRun], [CreatedOn], [ModifiedOn]) VALUES (2, 5, 24, 1, NULL, 1, NULL, CAST(N'2018-11-12T13:28:01.690' AS DateTime), CAST(N'2018-11-12T13:28:01.690' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserTrackingSchedule] OFF
GO
SET IDENTITY_INSERT [dbo].[Days] ON 

GO
INSERT [dbo].[Days] ([Id], [UserId], [CountryId], [CountryVisaId], [Days], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 5, 6, 6, CAST(N'2018-11-12T08:05:26.820' AS DateTime), CAST(N'2018-11-12T08:06:43.697' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Days] OFF
GO
SET IDENTITY_INSERT [dict].[CountryVisa] ON 

GO
INSERT [dict].[CountryVisa] ([Id], [CountryId], [Name], [Code], [Description], [DateStart], [DateEnd], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (1, 1, N'Резиденство РФ', N'RUS', N'Подсчет производится по календарному году с 1 января по 31 декабря. День вьезда и выезда считается днем, проведенным в РФ.', CAST(N'2018-10-07T11:16:18.447' AS DateTime), CAST(N'2018-10-07T11:16:18.447' AS DateTime), 1, 1, 183, NULL)
GO
INSERT [dict].[CountryVisa] ([Id], [CountryId], [Name], [Code], [Description], [DateStart], [DateEnd], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (3, 2, N'Налоговое резидентство UK (90 дней)', N'UK90', N'Подсчет дней производится по полуночам, проведенным в UK по местному времени и ведется с 6 апреля текущего года по 5 апреля следующего года.', CAST(N'2018-10-07T11:16:18.447' AS DateTime), CAST(N'2018-10-07T11:16:18.447' AS DateTime), 1, 1, 90, N'00:00:00')
GO
INSERT [dict].[CountryVisa] ([Id], [CountryId], [Name], [Code], [Description], [DateStart], [DateEnd], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (4, 2, N'Налоговое резидентство UK (120 дней)', N'UK120', N'Подсчет дней производится по полуночам, проведенным в UK по местному времени и ведется с 6 апреля текущего года по 5 апреля следующего года.', CAST(N'2018-10-07T11:16:18.447' AS DateTime), CAST(N'2018-10-07T11:16:18.447' AS DateTime), 1, 1, 120, N'00:00:00')
GO
INSERT [dict].[CountryVisa] ([Id], [CountryId], [Name], [Code], [Description], [DateStart], [DateEnd], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (5, 2, N'Налоговое резидентство UK (180 дней)', N'UK180', N'Подсчет дней производится по полуночам, проведенным в UK по местному времени и ведется с 6 апреля текущего года по 5 апреля следующего года.', CAST(N'2018-10-07T11:16:18.447' AS DateTime), CAST(N'2018-10-07T11:16:18.447' AS DateTime), 1, 1, 180, N'00:00:00')
GO
INSERT [dict].[CountryVisa] ([Id], [CountryId], [Name], [Code], [Description], [DateStart], [DateEnd], [CountFirstDay], [CountLastDay], [TargetDays], [SpecialTime]) VALUES (6, 5, N'Виза в Канаду', N'CA30', NULL, CAST(N'2018-10-01T00:00:00.000' AS DateTime), CAST(N'2019-01-28T00:00:00.000' AS DateTime), 1, 1, 30, N'')
GO
SET IDENTITY_INSERT [dict].[CountryVisa] OFF
GO
SET IDENTITY_INSERT [map].[UserCountryVisa] ON 

GO
INSERT [map].[UserCountryVisa] ([Id], [UserId], [VisaId], [CountryId], [AllowNotification], [CreatedOn], [ModifiedOn]) VALUES (1, 1, 1, 1, 1, NULL, NULL)
GO
INSERT [map].[UserCountryVisa] ([Id], [UserId], [VisaId], [CountryId], [AllowNotification], [CreatedOn], [ModifiedOn]) VALUES (2, 1, 2, 1, 1, NULL, NULL)
GO
INSERT [map].[UserCountryVisa] ([Id], [UserId], [VisaId], [CountryId], [AllowNotification], [CreatedOn], [ModifiedOn]) VALUES (3, 1, 6, 5, 1, CAST(N'2018-11-12T04:07:02.203' AS DateTime), CAST(N'2018-11-12T04:08:15.830' AS DateTime))
GO
SET IDENTITY_INSERT [map].[UserCountryVisa] OFF
GO
SET IDENTITY_INSERT [dict].[CountryFinancialPeriod] ON 

GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (2, 2, CAST(N'2018-04-06T00:00:00.000' AS DateTime), CAST(N'2018-04-05T00:00:00.000' AS DateTime))
GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (3, 3, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (4, 4, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime))
GO
INSERT [dict].[CountryFinancialPeriod] ([Id], [CountryId], [DateStart], [DateEnd]) VALUES (5, 5, CAST(N'2018-01-01T00:00:00.000' AS DateTime), CAST(N'2018-12-30T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dict].[CountryFinancialPeriod] OFF
GO
SET IDENTITY_INSERT [conf].[Settings] ON 

GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (1, N'CONTACT_EMAIL', N'info@overseascalculator.com', CAST(N'2018-08-28T17:48:58.550' AS DateTime), CAST(N'2018-08-28T17:48:58.550' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (2, N'CONTACT_PHONE', N'+7(903)122-23-41', CAST(N'2018-08-28T17:49:16.313' AS DateTime), CAST(N'2018-08-28T17:49:16.313' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (3, N'CONTACT_URL', N'http://overseascalculator.com', CAST(N'2018-08-28T17:49:19.957' AS DateTime), CAST(N'2018-08-28T17:49:19.957' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (4, N'GOOGLE_GEOCODING_API_KEY', N'AIzaSyCziO9o5MpWPhM2PdZLQzePa0-Hwz7WR2I', CAST(N'2018-09-10T13:51:50.140' AS DateTime), CAST(N'2018-09-10T13:51:50.140' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (5, N'GOOGLE_GEOCODING_API_URL', N'https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={2}', CAST(N'2018-09-10T13:55:43.470' AS DateTime), CAST(N'2018-09-10T13:55:43.470' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (6, N'USER_API_LOGIN_URL', N'https://daysinplace.azurewebsites.net/api/user/logIn?login={0}&password={1}', CAST(N'2018-09-16T07:21:34.767' AS DateTime), CAST(N'2018-09-16T07:21:34.767' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (7, N'USER_API_GET_URL', N'https://daysinplace.azurewebsites.net/api/user/get?id={0}', CAST(N'2018-09-16T07:21:43.797' AS DateTime), CAST(N'2018-09-16T07:21:43.797' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (8, N'USER_API_LOGOFF_URL', N'https://daysinplace.azurewebsites.net/api/user/logoff?id={0}', CAST(N'2018-09-16T07:22:32.160' AS DateTime), CAST(N'2018-09-16T07:22:32.160' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (9, N'SETTINGS_API_GETBYKEY_URL', N'https://daysinplace.azurewebsites.net/api/settings/getByKey?key={0}', CAST(N'2018-09-16T07:24:16.283' AS DateTime), CAST(N'2018-09-16T07:24:16.283' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (10, N'SETTINGS_API_LIST_URL', N'https://daysinplace.azurewebsites.net/api/settings/list', CAST(N'2018-09-16T07:24:29.080' AS DateTime), CAST(N'2018-09-16T07:24:29.080' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (11, N'DAYS_API_ADD_URL', NULL, CAST(N'2018-09-16T07:25:54.033' AS DateTime), CAST(N'2018-09-16T07:25:54.033' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (12, N'DAYS_API_GETBYUSERCOUNTRY_URL', NULL, CAST(N'2018-09-16T07:26:38.457' AS DateTime), CAST(N'2018-09-16T07:26:38.457' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (13, N'COUNTRY_API_ADD_URL', NULL, CAST(N'2018-09-16T07:27:03.580' AS DateTime), CAST(N'2018-09-16T07:27:03.580' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (14, N'COUNTRY_API_DELETE_URL', NULL, CAST(N'2018-09-16T07:27:17.627' AS DateTime), CAST(N'2018-09-16T07:27:17.627' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (15, N'VISA_API_ADD_URL', NULL, CAST(N'2018-09-16T07:27:36.097' AS DateTime), CAST(N'2018-09-16T07:27:36.097' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (16, N'VISA_API_DELETE_URL', NULL, CAST(N'2018-09-16T07:27:48.533' AS DateTime), CAST(N'2018-09-16T07:27:48.533' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (17, N'VISA_API_GETBYCOUNTRY_URL', NULL, CAST(N'2018-09-16T07:28:01.923' AS DateTime), CAST(N'2018-09-16T07:28:01.923' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (18, N'VISA_API_LIST_URL', NULL, CAST(N'2018-09-16T07:28:16.160' AS DateTime), CAST(N'2018-09-16T07:28:16.160' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (19, N'COUNTRY_API_LIST_URL', NULL, CAST(N'2018-09-16T07:28:48.533' AS DateTime), CAST(N'2018-09-16T07:28:48.533' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (20, N'LOG_API_ADD_URL', N'https://daysinplace.azurewebsites.net/api/log/add', CAST(N'2018-09-16T07:29:15.720' AS DateTime), CAST(N'2018-09-16T07:29:15.720' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (21, N'ERROR_API_ADD_URL', N'https://daysinplace.azurewebsites.net/api/error/add', CAST(N'2018-10-05T16:50:45.717' AS DateTime), CAST(N'2018-10-05T16:50:45.717' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (22, N'DAYS_API_GETBYCOUNTRYVISA_URL', NULL, CAST(N'2018-10-07T11:08:46.983' AS DateTime), CAST(N'2018-10-07T11:08:46.983' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (23, N'DAYS_API_COUNTRIESVISASLIST_URL', NULL, CAST(N'2018-10-07T11:26:07.290' AS DateTime), CAST(N'2018-10-07T11:26:07.290' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (24, N'VISA_API_EDIT_URL', NULL, CAST(N'2018-10-07T11:29:24.187' AS DateTime), CAST(N'2018-10-07T11:29:24.187' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (25, N'USER_API_CREATE_URL', N'https://daysinplace.azurewebsites.net/api/user/create', CAST(N'2018-10-07T12:02:37.800' AS DateTime), CAST(N'2018-10-07T12:02:37.800' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (26, N'USER_API_UPDATE_URL', N'https://daysinplace.azurewebsites.net/api/user/update', CAST(N'2018-10-07T12:02:49.020' AS DateTime), CAST(N'2018-10-07T12:02:49.020' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (27, N'USER_API_CHANGEPICTURE_URL', N'https://daysinplace.azurewebsites.net/api/user/update', CAST(N'2018-10-07T12:03:08.393' AS DateTime), CAST(N'2018-10-07T12:03:08.393' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (28, N'USER_API_CHANGEPASSWORD_URL', N'https://daysinplace.azurewebsites.net/api/user/update', CAST(N'2018-10-07T12:03:48.833' AS DateTime), CAST(N'2018-10-07T12:03:48.833' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (29, N'USER_API_CHANGEPHONE_URL', N'https://daysinplace.azurewebsites.net/api/user/update', CAST(N'2018-10-07T12:04:00.380' AS DateTime), CAST(N'2018-10-07T12:04:00.380' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (30, N'USER_API_CHANGELOGIN_URL', N'https://daysinplace.azurewebsites.net/api/user/update', CAST(N'2018-10-07T12:04:10.020' AS DateTime), CAST(N'2018-10-07T12:04:10.020' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (31, N'NOTIFICATION_CONFIRMATION', N'В данный момент, ваша страна - {0}?', CAST(N'2018-10-21T09:24:55.903' AS DateTime), CAST(N'2018-10-21T09:24:55.903' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (32, N'NOTIFICATION_PUSH_TITLE', N'Проверка местоположения', CAST(N'2018-10-21T09:28:25.783' AS DateTime), CAST(N'2018-10-21T09:28:25.783' AS DateTime))
GO
INSERT [conf].[Settings] ([Id], [Key], [Value], [CreatedOn], [ModifiedOn]) VALUES (33, N'NOTIFICATION_PUSH_DESCRIPTION', N'Подтверждение вашего местоположения для приложения "Калькулятор мигранта". При открытии этого уведомления, произойдет автоматический подсчет дней по месту текущего прибывания.', CAST(N'2018-10-21T09:29:20.567' AS DateTime), CAST(N'2018-10-21T09:29:20.567' AS DateTime))
GO
SET IDENTITY_INSERT [conf].[Settings] OFF
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