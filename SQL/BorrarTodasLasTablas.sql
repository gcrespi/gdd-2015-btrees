USE [GD2C2015]
GO

CREATE PROCEDURE THE_BTREES.NO_CHECK_CONSTRAINS
AS 
	DECLARE @sql varchar(max)
	DECLARE tables_in_schema CURSOR FOR 
	SELECT TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'THE_BTREES' and TABLE_TYPE = 'BASE TABLE';

	DECLARE @table_name varchar(max)

	OPEN tables_in_schema 

	FETCH tables_in_schema INTO @table_name 

	WHILE (@@FETCH_STATUS = 0) 
	BEGIN 
		SET @sql = 'ALTER TABLE ' + @table_name + ' NOCHECK CONSTRAINT ALL'
		EXEC(@sql)

		FETCH tables_in_schema INTO @table_name
	END 

	CLOSE tables_in_schema 
	DEALLOCATE tables_in_schema 
GO

-- Creo el SP para limpiar la base
CREATE PROCEDURE [THE_BTREES].CleanDatabase
AS
	DECLARE @names varchar(max)
	DECLARE @sql varchar(max)

	-- Deshabilito la integridad referencial de las tablas a borrar
	EXEC THE_BTREES.NO_CHECK_CONSTRAINS

	--Borro las tablas excepto la maestra
	SELECT @names = coalesce(@names + ', ','') + '[THE_BTREES].' + TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'THE_BTREES' and TABLE_TYPE = 'BASE TABLE'

	SET @sql = 'DROP TABLE ' + @names
	EXEC(@sql)

	--Borro las vistas
	SELECT @names = coalesce(@names + ', ','') + '[THE_BTREES].' + TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.VIEWS
	WHERE TABLE_SCHEMA = 'THE_BTREES'

	SET @sql = 'DROP VIEW ' + @names
	EXEC(@sql)

	--Borro los stored procedures
	SELECT @names = coalesce(@names + ', ','') + '[THE_BTREES].' + p.NAME
	FROM GD2C2015.sys.procedures p, GD2C2015.sys.schemas s
	WHERE s.schema_id = p.schema_id AND p.NAME != 'CleanDatabase' AND s.name = 'THE_BTREES'
	
	SET @sql = 'DROP PROCEDURE ' + @names
	EXEC(@sql)

GO

-- Hago un algoritmo para que ande a pesar de los errores de FK
PRINT 'Command(s) completed successfully.'

DECLARE @C int
SET @C = 1
WHILE @C<20 BEGIN PRINT CHAR(13) SET @C+=1 END
PRINT 'A TODO ESTO NO LE DEN BOLA....'

DECLARE @END bit
SET @END = 0
	BEGIN TRY
		EXEC [THE_BTREES].CleanDatabase
		SET @END = 1
	END TRY
	BEGIN CATCH
		PRINT 'ERROR'
	END CATCH 
GO

DROP PROCEDURE [THE_BTREES].CleanDatabase
GO

DROP PROCEDURE [THE_BTREES].NO_CHECK_CONSTRAINS
GO