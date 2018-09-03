CREATE PROCEDURE [conf].[Settings_List]
				@Xml		   XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   setting.[Id]
								  ,setting.[Key]
								  ,setting.[Value]
								  ,setting.[CreatedOn]
								  ,setting.[ModifiedOn]
						FROM [conf].[Settings] AS setting
						ORDER BY setting.[Key] asc
						FOR XML RAW('Settings'), TYPE)
				FOR XML PATH('Settings'),TYPE)

END