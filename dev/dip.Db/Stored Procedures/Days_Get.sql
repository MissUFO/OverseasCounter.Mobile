CREATE PROCEDURE [dbo].[Days_Get]
		   @UserId	   int
		  ,@CountryId  int
		  ,@CountryVisaId int = null
		  ,@Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;

	SET @Xml = (SELECT (SELECT d.*
						FROM [dbo].[Days] AS d
						WHERE d.[UserId]=@UserId and d.[CountryId]=@CountryId and (d.[CountryVisaId]=@CountryVisaId or @CountryVisaId is null or @CountryVisaId=0)
						FOR XML RAW('Day'), TYPE) 
				FOR XML PATH('Days'),TYPE)		

END