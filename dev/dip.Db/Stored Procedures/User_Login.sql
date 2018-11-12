
CREATE PROCEDURE [auth].[User_Login]
				@Email	       nvarchar(255)
			  , @Password	   nvarchar(255)
			  , @Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID INT

	SELECT @ID = usr.[Id]
	  FROM [auth].[User] as usr
	WHERE usr.[Email] = @Email and usr.[Password] = @Password and usr.[Status] = 1
	
	---- update last login date -----

    UPDATE [auth].[User]
		SET LastLoginOn = GETDATE()
	WHERE Id = @ID

	----------------------------------

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
								  ,(SELECT (SELECT
										uts.*
										FROM [dbo].[UserTrackingSchedule] AS uts
										WHERE uts.[UserId] = usr.[Id]
										ORDER BY uts.CreatedOn ASC
										FOR XML RAW('UserTrackingSchedule'), TYPE) 
								   FOR XML PATH('UserTrackingSchedules'),TYPE)
								  ,(SELECT (SELECT	 
											   ucv.*
											  ,(SELECT d.*
												FROM [dbo].[Days] AS d
												WHERE d.[CountryVisaId]=ucv.[VisaId] and d.[CountryId] = ucv.[CountryId]
												FOR XML RAW('Days'), TYPE) 
											  ,(SELECT  cvt.*
												FROM [dict].[CountryVisa] AS cvt
												WHERE cvt.[Id]=ucv.[VisaId]
												FOR XML RAW('CountryVisa'), TYPE) 
											  ,(SELECT  c.*
												FROM [dict].[Country] AS c
												WHERE c.[Id]=ucv.[CountryId]
												FOR XML RAW('Country'), TYPE) 
											  ,(SELECT cfp.*
												FROM [dict].[CountryFinancialPeriod] AS cfp
												WHERE cfp.[CountryId]=ucv.[CountryId]
												FOR XML RAW('CountryFinancialPeriod'), TYPE) 
										FROM [map].[UserCountryVisa] AS ucv
										WHERE ucv.[UserId] = usr.[Id]
										FOR XML RAW('UserCountryVisa'), TYPE) 
								   FOR XML PATH('UserCountryVisas'),TYPE)
						FROM [auth].[User] AS usr
						WHERE usr.[Id]=@ID
						FOR XML RAW('User'), TYPE)
				FOR XML PATH('Users'),TYPE)

END