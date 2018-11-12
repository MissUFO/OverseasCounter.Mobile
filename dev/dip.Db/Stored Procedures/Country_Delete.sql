CREATE PROCEDURE [dict].[Country_Delete]
			  @UserId		   INT
			 ,@CountryId	   INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM [dbo].[Days]
      WHERE [UserId] = @UserId and [CountryId] = @CountryId

	DELETE FROM [map].[UserCountry]
      WHERE [UserId] = @UserId and [CountryId] = @CountryId

END