

IF(SELECT COUNT(*) FROM SYS.objects WHERE NAME = 'uspUserUpdate') > 0
BEGIN 
	DROP PROCEDURE uspUserUpdate
END
GO
-- =============================================
-- Author:		Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Update a new User
-- =============================================
CREATE PROCEDURE [dbo].[uspUserUpdate]
	@Id UNIQUEIDENTIFIER,
	@Name varchar(256),
	@Email varchar(128),
	@Password varchar(512), 
	@ProfileId UNIQUEIDENTIFIER,
	@Birthdate Datetime = null
AS
BEGIN
	UPDATE 
		Users 
	SET 
		Name = @Name, 
		Email = @Email, 
		Password = @Password, 
		ProfileId = @ProfileId, 
		BirthDate = @Birthdate
	WHERE 
		ID = @Id
	 
END