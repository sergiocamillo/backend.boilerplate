-- =============================================
-- Author:	Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Creating Profile Table
-- =============================================

USE SmcBase

IF (select COUNT(*) from sys.tables where name ='Profiles') > 0 
BEGIN
	DECLARE @FK VARCHAR(64)
	
	 SELECT @FK = NAME FROM SYS.objects WHERE NAME LIKE '%PROFILE%' AND type_desc = 'FOREIGN_KEY_CONSTRAINT'

	 IF(@FK IS NOT NULL)
	 BEGIN
	   -- just a example how to execute and create a dinamic query. I know there is a easier way to remove this FK
		DECLARE @SQL NVARCHAR(512)
		SET @SQL = 'ALTER TABLE Users DROP CONSTRAINT ' + @FK

		EXEC sp_executesql @SQL
	 END
	 
	 DROP TABLE PROFILES

END

CREATE TABLE Profiles 
(
	 Id UNIQUEIDENTIFIER PRIMARY KEY,
	 Description VARCHAR(128) NOT NULL
)