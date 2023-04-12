
-- =============================================
-- Author:		Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Insert initial data on Profiles table
-- =============================================
BEGIN TRAN 

USE SmcBase

INSERT INTO PROFILES VALUES ('F271DAA9-3432-4216-8BE2-24B131DA78E1', 'Administrator');
GO
INSERT INTO PROFILES VALUES  ('BF07BC89-CF02-43A5-BD84-BA38B1BD8808', 'Customer');

-- COMMIT
-- ROLLBACK

