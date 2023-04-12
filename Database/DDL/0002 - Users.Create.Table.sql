
-- =============================================
-- Author: Sergio Camillo
-- Create date: 04/11/2023
-- Description: Creating  Users Table
-- =============================================
USE SmcBase

IF (select COUNT(*) from sys.tables where name ='Users') > 0 
BEGIN
	DROP TABLE Users
END

CREATE TABLE Users 
(
	 Id UNIQUEIDENTIFIER PRIMARY KEY,
	 Name VARCHAR(256) NOT NULL, 
	 Email VARCHAR(128) NOT NULL, 
	 Password VARCHAR(512) NOT NULL,
	 BirthDate Datetime NULL,
	 ProfileId UNIQUEIDENTIFIER
)

ALTER TABLE Users ADD FOREIGN KEY(ProfileId) REFERENCES Profiles(Id)