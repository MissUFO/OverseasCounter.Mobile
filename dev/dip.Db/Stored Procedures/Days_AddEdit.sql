CREATE PROCEDURE [dbo].[Days_AddEdit]
		   @UserId int
		  ,@CountryId int
		  ,@CountryVisaId int = null
		  ,@Days int = 1
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID INT = 0

	SELECT top(1) @ID = d.[Id] 
	  FROM [dbo].[Days] as d
	WHERE d.[UserId] = @UserId and d.[CountryId] = @CountryId and 
	(d.[CountryVisaId] = @CountryVisaId or (d.[CountryVisaId] is null and @CountryVisaId is null))
	ORDER BY [CreatedOn] DESC
	
	
	IF (@ID IS NOT NULL AND @ID <> 0)
	BEGIN
	-- UPDATE a  record
	UPDATE [dbo].[Days]
	SET [UserId] = @UserId
      ,[CountryId] = @CountryId
      ,[CountryVisaId] = @CountryVisaId
      ,[Days] += @Days
      ,[ModifiedOn] = getdate()
	WHERE Id=@ID
	
	END
	ELSE
	BEGIN
	-- Create a new record
	INSERT INTO [dbo].[Days]
           ([UserId]
           ,[CountryId]
           ,[CountryVisaId]
           ,[Days]
           ,[CreatedOn]
           ,[ModifiedOn])
     VALUES
           (@UserId
           ,@CountryId
           ,@CountryVisaId
           ,@Days
           , GETDATE()
           , GETDATE())

	END 
END