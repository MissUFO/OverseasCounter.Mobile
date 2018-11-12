
CREATE PROCEDURE [auth].[User_AddEdit]
		   @UserId int = null
		  ,@Email nvarchar(255)
		  ,@Password nvarchar(255) = null
		  ,@FirstName nvarchar(255) = null
		  ,@LastName nvarchar(255) = null
		  ,@MiddleName nvarchar(255) = null
		  ,@Photo image = null
		  ,@PhoneNumber nvarchar(50) = null
		  ,@Status bit = 1
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID INT = 0

	SELECT @ID = usr.[Id]
	  FROM [auth].[User] as usr
	WHERE (@UserId is not null and @UserId > 0 and usr.[Id] = @UserId) or usr.[Email] = @Email 
	
	IF (@ID IS NOT NULL AND @ID <> 0)
	BEGIN
	-- Update record
	UPDATE [auth].[User]
	   SET [Email] = @Email
		  ,[FirstName] = ISNULL(@FirstName, FirstName)
		  ,[LastName] = ISNULL(@LastName, LastName)
		  ,[MiddleName] = ISNULL(@MiddleName, MiddleName)
		  ,[Password] = ISNULL(@Password, Password)
		  ,[Photo] = ISNULL(@Photo, Photo)
		  ,[PhoneNumber] = ISNULL(@PhoneNumber, PhoneNumber)
		  ,[Status] = @Status
		  ,[LastLoginOn] = GETDATE()
	 WHERE Id=@ID

	END
	ELSE
	BEGIN
	-- Create a new record
	INSERT INTO [auth].[User]
           ([Email]
		   ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[MiddleName]
		   ,[Photo]
           ,[PhoneNumber]
           ,[Status]
           ,[CreatedOn]
           ,[ModifiedOn]
           ,[LastLoginOn])
     VALUES
           (@Email
		   ,@Password
           ,@FirstName
           ,@LastName
           ,@MiddleName
		   ,@Photo
           ,@PhoneNumber
           ,@Status
           , GETDATE()
           , GETDATE()
           , GETDATE())
	
	-- Create tracking schdule
	SELECT @ID = usr.[Id]
	  FROM [auth].[User] as usr
	WHERE usr.[Email] = @Email
	
	INSERT INTO [dbo].[UserTrackingSchedule]
           ([UserId]
           ,[ScheduledHours]
           ,[ScheduledDays]
           ,[LastRun]
           ,[CreatedOn]
           ,[ModifiedOn])
     VALUES
           (@ID
           ,24
           ,1
           ,null
           ,GETDATE()
           ,GETDATE())

	END

END