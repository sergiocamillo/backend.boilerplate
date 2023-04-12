IF(SELECT COUNT(*) FROM SYS.objects WHERE NAME = 'uspUserRead') > 0
BEGIN 
	DROP PROCEDURE uspUserRead
END
GO
-- =============================================
-- Author:		Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Read Users
-- =============================================
CREATE PROCEDURE [dbo].[uspUserRead]
	@Name varchar(256) = null,
	@Email varchar(128) = null,
	@ProfileId UNIQUEIDENTIFIER = null
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
		(@Name IS NULL OR u.Name like '%' + @Name + '%') AND
		(@Email IS NULL OR u.Email = @Email) AND
		(@ProfileId IS NULL OR u.ProfileId = @ProfileId) 
END