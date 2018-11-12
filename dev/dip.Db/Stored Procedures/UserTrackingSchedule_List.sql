CREATE PROCEDURE [dbo].[UserTrackingSchedule_List]
				@UserId			INT = null
			  , @Xml		XML output
AS
BEGIN
	SET NOCOUNT ON;
	
	SET @Xml = (SELECT (SELECT	   uts.*
						FROM [dbo].[UserTrackingSchedule] AS uts
						WHERE uts.[UserId] = @UserId or @UserId is null or @UserId = 0
						FOR XML RAW('UserTrackingSchedule'), TYPE)
				FOR XML PATH('UserTrackingSchedules'),TYPE)

END