
-- =============================================
-- Author:		Sergio Camillo
-- Create date: 04/11/2023
-- Description:	Insert initial data on users table
-- =============================================
BEGIN TRAN 

USE SmcBase

INSERT INTO Users VALUES (NEWID(), 'Sergio Camillo', 'smc@sergiocamillo.com.br', 'btWDPPNShuv4Zit7WUnw10K77D8=', '1990-11-22 15:31:15.800', 'F271DAA9-3432-4216-8BE2-24B131DA78E1');
-- COMMIT
-- ROLLBACK

