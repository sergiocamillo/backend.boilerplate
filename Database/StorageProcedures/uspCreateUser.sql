

IF(SELECT COUNT(*) FROM SYS.objects WHERE NAME = 'uspUserCreate') > 0
BEGIN 
	DROP PROCEDURE uspUserCreate
END
GO
-- =============================================
-- Author:		Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Create a new User
-- =============================================
CREATE PROCEDURE [dbo].[uspUserCreate]
	@Name varchar(256),
	@Email varchar(128),
	@Password varchar(512), 
	@ProfileId UNIQUEIDENTIFIER,
	@Birthdate Datetime = null
AS
BEGIN
	INSERT INTO Users(ID, Name, Email, Password, ProfileId, BirthDate) 
	VALUES (NEWID(), @Name, @Email, @Password, @ProfileId, @Birthdate);

	SELECT SCOPE_IDENTITY() AS InsertedId

END