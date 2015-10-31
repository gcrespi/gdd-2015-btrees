USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[TraerData]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerData]
GO

create PROCEDURE [THE_BTREES].[TraerData]
	( @Tabla nvarchar(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='select * from [THE_BTREES].' + @Tabla 
	execute (@sentencia)

GO


IF  object_id(N'[THE_BTREES].[TraerDataConFiltros]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerDataConFiltros]
GO

create PROCEDURE [THE_BTREES].[TraerDataConFiltros]
	( @Tabla nvarchar(MAX), @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='select * FROM ' + @Tabla + ' ' + @WhereClause
	execute (@sentencia)
GO