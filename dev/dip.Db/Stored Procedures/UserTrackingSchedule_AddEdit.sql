CREATE PROCEDURE [dbo].[UserTrackingSchedule_AddEdit]
		   @UserId int = null
		  ,@ScheduledHours int = null
		  ,@ScheduledDays int = null
		  ,@ScheduledNotificationId nvarchar(1024) 
		  ,@Enabled int = 1
		  ,@LastRun datetime = null
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID INT = 0

	SELECT top(1) @ID = uts.[Id] 
	  FROM [dbo].[UserTrackingSchedule] as uts
	WHERE uts.[UserId] = @UserId
	
	IF (@ID IS NOT NULL AND @ID <> 0)
	BEGIN
	-- UPDATE a  record
	 UPDATE [dbo].[UserTrackingSchedule]
	 SET [UserId] = @UserId
      ,[ScheduledHours] = ISNULL(@ScheduledHours, ScheduledHours)
      ,[ScheduledDays] = ISNULL(@ScheduledDays, ScheduledDays)
	  ,[ScheduledNotificationId] = ISNULL(@ScheduledNotificationId, ScheduledNotificationId)
	  ,[Enabled] = ISNULL(@Enabled, [Enabled])
      ,[LastRun] = ISNULL(@LastRun, LastRun)
      ,[ModifiedOn] = getdate()
	WHERE Id=@ID

	END
	ELSE
	BEGIN
	-- Create a new record
	INSERT INTO [dbo].[UserTrackingSchedule]
           ([UserId]
           ,[ScheduledHours]
           ,[ScheduledDays]
		   ,[ScheduledNotificationId]
		   ,[Enabled]
           ,[LastRun]
           ,[CreatedOn]
           ,[ModifiedOn])
     VALUES
           (@UserId
           ,@ScheduledHours
           ,@ScheduledDays
		   ,@ScheduledNotificationId
		   ,@Enabled
           ,@LastRun
           , GETDATE()
           , GETDATE())

	END 

END