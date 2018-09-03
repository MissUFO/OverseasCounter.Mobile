CREATE PROCEDURE [logs].[Error_AddEdit]
		   @Id int = null
		  ,@UserId int = null
		  ,@ErrorCode bigint = null
		  ,@ErrorMessage nvarchar(1024) = null
		  ,@StackTrace nvarchar(max) = null
		  ,@CreatedOn datetime = null
		  ,@ModifiedOn datetime = null
AS
BEGIN
	SET NOCOUNT ON;

    IF EXISTS(SELECT 1 FROM [logs].[Error] WHERE UserId = @UserId and (ErrorCode = @ErrorCode or ErrorMessage = @ErrorMessage))
	BEGIN

	-- Update if exists
	   UPDATE [logs].[Error]
	   SET StackTrace = @StackTrace
		  ,ModifiedOn = getdate()
	   WHERE UserId = @UserId and (ErrorCode = @ErrorCode or ErrorMessage = @ErrorMessage)

	END
    ELSE
    BEGIN

		-- Create a new record
		INSERT INTO [logs].[Error]
           ([UserId]
           ,[ErrorCode]
           ,[ErrorMessage]
           ,[StackTrace]
           ,[CreatedOn]
           ,[ModifiedOn])
     VALUES
           (@UserId
           ,@ErrorCode
           ,@ErrorMessage
           ,@StackTrace
           ,ISNULL(@CreatedOn, GETDATE())
		   ,ISNULL(@ModifiedOn, GETDATE()))

	END
END