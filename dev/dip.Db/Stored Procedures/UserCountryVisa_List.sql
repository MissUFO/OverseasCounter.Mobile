CREATE PROCEDURE [map].[UserCountryVisa_List]
				@UserId		   INT
			  , @CountryId	   INT
			  , @Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	 
							 ucv.*
							,(SELECT c.*
										FROM [dict].[Country] AS c
										WHERE c.[Id] = ucv.[CountryId]
										FOR XML RAW('Country'), TYPE) 
							,(SELECT cfp.*
										FROM [dict].[CountryFinancialPeriod] AS cfp
										WHERE cfp.[CountryId] = ucv.[CountryId]
										FOR XML RAW('CountryFinancialPeriod'), TYPE) 
							,(SELECT d.*
										FROM [dbo].[Days] AS d
										WHERE d.[CountryId]=ucv.[CountryId] and d.[UserId] = uc.[UserId]
										FOR XML RAW('Days'), TYPE) 
							,(SELECT (SELECT  cv.*
										FROM [map].[UserCountryVisa] as ucv2 
											join [dict].[CountryVisa] cv ON cv.[CountryId] = ucv.[CountryId] and cv.[Id] = ucv.[VisaId]
										WHERE ucv2.[Id] = ucv.[Id]
										FOR XML RAW('CountryVisa'), TYPE) 
							FOR XML PATH('CountryVisas'),TYPE)
					FROM [map].[UserCountryVisa] AS ucv
						join [map].[UserCountry] uc ON uc.[UserId] = @UserId and uc.[CountryId] = ucv.[CountryId]
					WHERE ucv.[UserId] = @UserId and ucv.[CountryId] = @CountryId
					FOR XML RAW('UserCountryVisa'), TYPE) 
				FOR XML PATH('UserCountryVisas'),TYPE)
						

END