IF(SELECT COUNT(*) FROM SYS.objects WHERE NAME = 'uspUserLogin') > 0
BEGIN 
	DROP PROCEDURE uspUserLogin
END
GO
-- =============================================
-- Author:		Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Read Users
-- =============================================
CREATE PROCEDURE [dbo].[uspUserLogin]
	@Email varchar(128),
	@Password varchar(512)
AS
BEGIN
	SELECT 
		u.Id,
		u.Name,
		u.Email,
		u.BirthDate,
		u.ProfileId,
		p.Description
	FROM 
		Users u inner join 
		Profiles p on (u.ProfileId = p.Id)
	WHERE 
		Email = @Email AND
		Password = @Password
END