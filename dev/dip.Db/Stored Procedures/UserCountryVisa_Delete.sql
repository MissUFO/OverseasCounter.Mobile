CREATE PROCEDURE [map].[UserCountryVisa_Delete]
			  @UserId		   INT
			 ,@VisaId	       INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE FROM [dbo].[Days]
      WHERE [UserId] = @UserId and [CountryVisaId] = @VisaId

	DELETE FROM [map].[UserCountryVisa]
      WHERE [UserId] = @UserId and [VisaId] = @VisaId

END