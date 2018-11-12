-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dict].[Country_AddEdit]
	 @UserId int
	,@Name nvarchar(255)
    ,@Code nvarchar(5)
	,@FinancialPeriodDateStart datetime = null
    ,@FinancialPeriodDateEnd datetime = null
	,@IsDefault bit = 0
AS
BEGIN
	
SET NOCOUNT ON;

DECLARE @ID INT = 0

SELECT @ID = c.[Id]
	FROM [dict].[Country] as c
WHERE c.[Code] = @Code
	
IF (@ID IS NOT NULL AND @ID <> 0)
BEGIN

	-- Update country info

   UPDATE [dict].[Country]
   SET [Name] =  ISNULL(@Name, [Name])
      ,[Code] =  ISNULL(@Code, [Code])
      ,[ModifiedOn] = getdate()
   WHERE [Id]=@ID

   DECLARE @FPID INT = 0

   SELECT @FPID = fp.[Id]
	  FROM [dict].[CountryFinancialPeriod] as fp
   WHERE fp.[CountryId] = @ID

   IF (@FPID IS NOT NULL AND @FPID <> 0)
   BEGIN
	   UPDATE [dict].[CountryFinancialPeriod]
	   SET [DateStart] = ISNULL(@FinancialPeriodDateStart, [DateStart])
		  ,[DateEnd] = ISNULL(@FinancialPeriodDateEnd, [DateEnd])
	   WHERE [CountryId]=@ID
   END
   ELSE
   BEGIN
	   INSERT INTO [dict].[CountryFinancialPeriod]
			   ([CountryId]
			   ,[DateStart]
			   ,[DateEnd])
		 VALUES
			   (@ID
			   ,ISNULL(@FinancialPeriodDateStart, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0) )
			   ,ISNULL(@FinancialPeriodDateEnd, DATEADD (dd, -1, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) +1, 0)) ))
   END
   ----------------------
END
ELSE
BEGIN
   -- Insert new country

   INSERT INTO [dict].[Country]
           ([Name]
           ,[Code]
           ,[CreatedOn]
           ,[ModifiedOn])
     VALUES
           (@Name
           ,@Code
           ,getdate()
           ,getdate())

    SELECT @ID = c.[Id]
	  FROM [dict].[Country] as c
	WHERE c.[Code] = @Code

	INSERT INTO [dict].[CountryFinancialPeriod]
           ([CountryId]
           ,[DateStart]
           ,[DateEnd])
     VALUES
           (@ID
           ,ISNULL(@FinancialPeriodDateStart, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0) )
           ,ISNULL(@FinancialPeriodDateEnd, DATEADD (dd, -1, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) +1, 0)) ))
	--------------------
END

-- keep only one default country for user
IF (@IsDefault = 1)
BEGIN
	UPDATE [map].[UserCountry]
	SET [IsDefault] = 0
	WHERE [UserId] = @UserId and [CountryId] <> @ID
END

-- setup user to country relationships

DECLARE @UCID INT = 0

SELECT @UCID = uc.[Id]
	FROM [map].[UserCountry] as uc
WHERE uc.[CountryId] = @ID and uc.[UserId]=@UserId

IF (@UCID IS NOT NULL AND @UCID <> 0)
BEGIN
UPDATE [map].[UserCountry]
SET 
    [IsDefault] = @IsDefault
    ,[ModifiedOn] = getdate()
WHERE [Id] = @UCID
END
ELSE
BEGIN
INSERT INTO [map].[UserCountry]
        ([UserId]
        ,[CountryId]
        ,[IsDefault]
        ,[CreatedOn]
        ,[ModifiedOn])
    VALUES
        (@UserId
        ,@ID
        ,@IsDefault
        ,getdate()
        ,getdate())
END
-------------------------------------

END