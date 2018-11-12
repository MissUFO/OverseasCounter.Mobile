-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [map].[UserCountryVisa_AddEdit]
	   @UserId int
	  ,@CountryId int
      ,@Name nvarchar(255)
      ,@Code nvarchar(50)
      ,@Description nvarchar(1024) = null
      ,@DateStart datetime
      ,@DateEnd datetime
      ,@CountFirstDay bit = 1
      ,@CountLastDay bit = 1
      ,@TargetDays int = 30
      ,@SpecialTime nvarchar(10) = null
	  ,@AllowNotification bit = 1
AS
BEGIN
	
SET NOCOUNT ON;

DECLARE @ID INT = 0

SELECT top(1) @ID = c.[Id]
	FROM [dict].[CountryVisa] as c
WHERE c.[CountryId]= @CountryId and (c.[Code] = @Code or c.[Name] = @Name)
	
IF (@ID IS NOT NULL AND @ID <> 0)
BEGIN

	-- Update country visa info

   UPDATE [dict].[CountryVisa]
   SET [Name] = @Name
      ,[Code] = @Code
      ,[Description] = @Description
      ,[DateStart] = @DateStart
      ,[DateEnd] = @DateEnd
      ,[CountFirstDay] = @CountFirstDay
      ,[CountLastDay] = @CountLastDay
      ,[TargetDays] = @TargetDays
      ,[SpecialTime] = @SpecialTime
  WHERE [Id] = @ID
   
   ----------------------
END
ELSE
BEGIN
   -- Insert new country visa

   INSERT INTO [dict].[CountryVisa]
           ([CountryId]
           ,[Name]
           ,[Code]
           ,[Description]
           ,[DateStart]
           ,[DateEnd]
           ,[CountFirstDay]
           ,[CountLastDay]
           ,[TargetDays]
           ,[SpecialTime])
     VALUES
           (@CountryId
           ,@Name
           ,@Code
           ,@Description
           ,@DateStart
           ,@DateEnd
           ,@CountFirstDay
           ,@CountLastDay
           ,@TargetDays
           ,@SpecialTime)

   SELECT top(1) @ID = c.[Id]
	FROM [dict].[CountryVisa] as c
   WHERE c.[CountryId]= @CountryId and (c.[Code] = @Code or c.[Name] = @Name)


	--------------------
END

-- setup user to country relationships

DECLARE @UCID INT = 0

SELECT @UCID = uc.[Id]
	FROM [map].[UserCountryVisa] as uc
WHERE uc.[VisaId] = @ID and uc.[UserId]=@UserId

IF (@UCID IS NOT NULL AND @UCID <> 0)
BEGIN

UPDATE [map].[UserCountryVisa]
   SET [UserId] = @UserId
      ,[VisaId] = @ID
      ,[CountryId] = @CountryId
      ,[AllowNotification] = @AllowNotification
      ,[ModifiedOn] = getdate()
 WHERE [Id] = @UCID

END
ELSE
BEGIN

INSERT INTO [map].[UserCountryVisa]
           ([UserId]
           ,[VisaId]
           ,[CountryId]
           ,[AllowNotification]
           ,[CreatedOn]
           ,[ModifiedOn])
     VALUES
           (@UserId
           ,@ID
           ,@CountryId
           ,@AllowNotification
           ,getdate()
           ,getdate())


END
-------------------------------------

END