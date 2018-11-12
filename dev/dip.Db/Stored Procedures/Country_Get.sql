CREATE PROCEDURE [dict].[Country_Get]
			 @Id		   INT
			,@Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT c.*
							  
							  ,(SELECT cfp.*
												FROM [dict].[CountryFinancialPeriod] AS cfp
												WHERE cfp.[CountryId]=c.[Id]
								FOR XML RAW('CountryFinancialPeriod'), TYPE) 
							  ,(SELECT d.*
										FROM [dbo].[Days] AS d
										WHERE d.[CountryId]=c.[Id]
										FOR XML RAW('Days'), TYPE) 
							,(SELECT (SELECT  cv.*
										FROM [dict].[CountryVisa] cv
										WHERE cv.[CountryId]=c.[Id]
										FOR XML RAW('CountryVisa'), TYPE) 
							FOR XML PATH('CountryVisas'),TYPE)
				FROM [dict].[Country] AS c
				WHERE c.Id=@Id
				ORDER BY c.[Name] ASC
				
				FOR XML RAW('Country'), TYPE) 
		FOR XML PATH('Countries'),TYPE)

END