CREATE PROCEDURE [auth].[User_Get]
				@Id			   INT
			  , @Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   usr.[Id]
								  ,usr.[Email]
								  ,usr.[Password]
								  ,usr.[FirstName]
								  ,usr.[LastName]
								  ,usr.[MiddleName]
								  ,cast(cast(usr.[Photo] as varbinary(max)) as varchar(max)) as Photo
								  ,usr.[PhoneNumber]
								  ,usr.[Status]
								  ,usr.[CreatedOn]
								  ,usr.[ModifiedOn]
								  ,usr.[LastLoginOn]
								  ,(SELECT	 
										   uts.[Id]
										  ,uts.[UserId]
										  ,uts.[ScheduledHours]
										  ,uts.[ScheduledDays]
										  ,uts.[LastRun]
										  ,uts.[CreatedOn]
										  ,uts.[ModifiedOn]
										FROM [dbo].[UserTrackingSchedule] AS uts
										WHERE uts.[UserId] = usr.[Id]
										FOR XML RAW('UserTrackingSchedule'), TYPE) 
								  ,(SELECT (SELECT	 
											   ucv.[Id]
											  ,ucv.[UserId]
											  ,ucv.[VisaTypeId]
											  ,ucv.[AllowNotification]
											  ,ucv.[CreatedOn]
											  ,ucv.[ModifiedOn]
											  ,(SELECT d.*
												FROM [dbo].[Days] AS d
												WHERE d.[UserCountryVisaId]=ucv.[Id]
												FOR XML RAW('Days'), TYPE) 
											  ,(SELECT  cvt.*
													   ,(SELECT	 c.*
															,(SELECT cfp.*
															  FROM [dict].[CountryFinancialPeriod] AS cfp
															  WHERE cfp.[CountryId]=c.[Id]
															  FOR XML RAW('CountryFinancialPeriod'), TYPE) 
														 FROM [dict].[Country] AS c
													     WHERE c.[Id]=cvt.[CountryId]
														 FOR XML RAW('Country'), TYPE) 
												FROM [dict].[CountryVisaType] AS cvt
												WHERE cvt.[Id]=ucv.[VisaTypeId]
											    FOR XML RAW('CountryVisaType'), TYPE) 
										FROM [map].[UserCountryVisa] AS ucv
										WHERE ucv.[UserId] = usr.[Id]
										FOR XML RAW('UserCountryVisa'), TYPE) 
								   FOR XML PATH('UserCountryVisas'),TYPE)
						FROM [auth].[User] AS usr
						WHERE usr.[Id]=@Id
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)

END