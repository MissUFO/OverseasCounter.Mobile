CREATE PROCEDURE [dict].[Country_List]
			    @UserId		   INT = null
			  , @Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
		SET @Xml = (SELECT (SELECT	 
							 ucv.UserId
							,ucv.CountryId as Id
							,c.Name
							,c.Code
							,uc.IsDefault
							,uc.CreatedOn
							,uc.ModifiedOn
							,(SELECT cfp.*
										FROM [dict].[CountryFinancialPeriod] AS cfp
										WHERE cfp.[CountryId]=c.[Id]
										FOR XML RAW('CountryFinancialPeriod'), TYPE) 
							,(SELECT d.*
										FROM [dbo].[Days] AS d
										WHERE d.[CountryId]=c.[Id] and (d.[UserId] = @UserId or @UserId is null or @UserId = 0)
										FOR XML RAW('Days'), TYPE) 
							,(SELECT (SELECT  cv.*
										FROM [map].[UserCountryVisa] as ucv2 
											join [dict].[CountryVisa] cv ON cv.[CountryId]=ucv.[CountryId] and cv.[Id]=ucv2.[VisaId]
										WHERE ucv2.[UserId]=ucv.[UserId] and ucv2.[CountryId]=ucv.[CountryId]
										FOR XML RAW('CountryVisa'), TYPE) 
							FOR XML PATH('CountryVisas'),TYPE)
					FROM [map].[UserCountry] AS ucv
						join [dict].[Country] c ON c.[Id]=ucv.[CountryId]
						left join [map].[UserCountry] uc ON uc.[UserId] = @UserId and uc.[CountryId]=c.[Id]
					WHERE (ucv.[UserId] = @UserId or @UserId is null or @UserId = 0)
					FOR XML RAW('Country'), TYPE) 
				FOR XML PATH('Countries'),TYPE)

END