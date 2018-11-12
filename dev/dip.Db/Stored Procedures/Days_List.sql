CREATE PROCEDURE [dbo].[Days_List]
		   @UserId				int = null
		  ,@CountryId			int = null
		  ,@CountryVisaId	    int = null
		  ,@Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT d.*
						FROM [dbo].[Days] AS d
						WHERE 
						(d.[UserId] = @UserId  or @UserId is null or  @UserId = 0) and 
						(d.[CountryId] = @CountryId or @CountryId is null or  @CountryId = 0) and 
						(d.[CountryVisaId] = @CountryVisaId  or @CountryVisaId is null or @CountryVisaId = 0)
						FOR XML RAW('Day'), TYPE) 
				FOR XML PATH('Days'),TYPE)		

END