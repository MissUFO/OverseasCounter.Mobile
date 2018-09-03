CREATE PROCEDURE [conf].[Settings_GetByKey]
				@Key			   nvarchar(255)
			  , @Xml			   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   setting.[Id]
								  ,setting.[Key]
								  ,setting.[Value]
								  ,setting.[CreatedOn]
								  ,setting.[ModifiedOn]
						FROM [conf].[Settings] AS setting
						WHERE setting.[Key] = @Key
						FOR XML RAW('Setting'), TYPE)
				FOR XML PATH('Settings'),TYPE)

END