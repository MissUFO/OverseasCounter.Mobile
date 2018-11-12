CREATE PROCEDURE [dbo].[UserTrackingSchedule_Get]
				@Id			INT
			  , @Xml		XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   uts.*
						FROM [dbo].[UserTrackingSchedule] AS uts
						WHERE uts.[Id] = @Id
						FOR XML RAW('UserTrackingSchedule'), TYPE)
				FOR XML PATH('UserTrackingSchedules'),TYPE)

END