USE [GD2C2015]
GO

-- Deshabilito la integridad referencial 
EXEC sp_MSForEachTable @command1 = "ALTER TABLE ? NOCHECK CONSTRAINT ALL" 
GO

PRINT 'Command(s) completed successfully.'

DECLARE @C int
SET @C = 1
WHILE @C<20 BEGIN PRINT CHAR(13) SET @C+=1 END
PRINT 'A TODO ESTO NO LE DEN BOLA, ANDA IGUAL'

DECLARE @END bit
SET @END = 0
WHILE @END <> 1 BEGIN	
	BEGIN TRY
		EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"
		SET @END = 1
	END TRY
	BEGIN CATCH
		EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"
	END CATCH 
END
GO

-- Habilitar la integridad referencial
EXEC sp_MSForEachTable @command1 = "ALTER TABLE ? CHECK CONSTRAINT ALL" 
GO