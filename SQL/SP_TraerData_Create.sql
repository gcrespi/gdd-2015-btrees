USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[TraerData]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerData]
GO

create PROCEDURE [THE_BTREES].[TraerData]
	( @Tabla nvarchar(20) )
as
	declare @sentencia nvarchar(200)
	set @sentencia='select * from [THE_BTREES].' + @Tabla 
	execute (@sentencia)

GO
