USE [GD2C2015]
GO

-- Creo el SP para limpiar la base
CREATE PROCEDURE CleanDatabase
AS
	DECLARE @names varchar(max)
	DECLARE @sql varchar(max)

	-- Deshabilito la integridad referencial 
	EXEC sp_MSForEachTable @command1 = "ALTER TABLE ? NOCHECK CONSTRAINT ALL" 

	--Borro las tablas excepto la maestra
	SELECT @names = coalesce(@names + ', ','') + TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME != 'Maestra' and TABLE_NAME NOT IN(SELECT TABLE_NAME FROM GD2C2015.INFORMATION_SCHEMA.VIEWS)

	SET @sql = 'DROP TABLE ' + @names
	EXEC(@sql)

	--Borro las vistas
	SELECT @names = coalesce(@names + ', ','') + TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.VIEWS

	SET @sql = 'DROP VIEW ' + @names
	EXEC(@sql)

	--Borro los stored procedures
	SELECT @names = coalesce(@names + ', ','') + NAME
	FROM sys.procedures 
	WHERE NAME != 'CleanDatabase' AND NAME NOT LIKE 'sp_%'

	SET @sql = 'DROP PROCEDURE ' + @names
	EXEC(@sql)

	-- Habilitar la integridad referencial
	EXEC sp_MSForEachTable @command1 = "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL" 
GO

-- Hago un algoritmo para que ande a pesar de los errores de FK
PRINT 'Command(s) completed successfully.'

DECLARE @C int
SET @C = 1
WHILE @C<20 BEGIN PRINT CHAR(13) SET @C+=1 END
PRINT 'A TODO ESTO NO LE DEN BOLA....'

DECLARE @END bit
SET @END = 0
WHILE @END <> 1 BEGIN	
	BEGIN TRY
		EXEC CleanDatabase
		SET @END = 1
	END TRY
	BEGIN CATCH
		EXEC CleanDatabase
	END CATCH 
END
GO

DROP PROCEDURE CleanDatabase
GO