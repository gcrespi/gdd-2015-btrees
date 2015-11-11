

IF  object_id(N'[THE_BTREES].[ExistsNameWithOtherID]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].[ExistsNameWithOtherID]
GO

CREATE FUNCTION THE_BTREES.ExistsNameWithOtherID (@RolID INT, @Nombre VARCHAR(60))
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.Roles 
	WHERE @RolID != RolID AND @Nombre = Rol_Nombre;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO



IF  object_id(N'[THE_BTREES].[codigoRutaYaExistente]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].codigoRutaYaExistente
GO

CREATE FUNCTION THE_BTREES.codigoRutaYaExistente 
	(@CodigoRuta INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.RutaAerea 
	WHERE @CodigoRuta = Ruta_Codigo;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[tieneViajeProgramado]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].tieneViajeProgramado
GO

CREATE FUNCTION THE_BTREES.tieneViajeProgramado 
	(@RutaID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.Viaje 
	WHERE @RutaID = Viaje_RutaAereaRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[tienePasajesVendidos]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].tienePasajesVendidos
GO

CREATE FUNCTION THE_BTREES.tienePasajesVendidos 
	(@RutaID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) 
		FROM THE_BTREES.Pasaje p JOIN
			THE_BTREES.Viaje v ON p.Pasaje_ViajeRef = v.ViajeID			 
	WHERE @RutaID = v.Viaje_RutaAereaRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[tieneEncomiendasVendidas]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].tieneEncomiendasVendidas
GO

CREATE FUNCTION THE_BTREES.tieneEncomiendasVendidas 
	(@RutaID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) 
		FROM THE_BTREES.Encomienda e JOIN
			THE_BTREES.Viaje v ON e.Enco_ViajeRef = v.ViajeID			 
	WHERE @RutaID = v.Viaje_RutaAereaRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[aeronaveTieneViajesAsignados]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].aeronaveTieneViajesAsignados
GO

CREATE FUNCTION THE_BTREES.aeronaveTieneViajesAsignados 
	(@AvionID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) 
		FROM THE_BTREES.Viaje v 
		WHERE @AvionID = v.Viaje_AvionRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[matriculaYaExistente]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].matriculaYaExistente
GO

CREATE FUNCTION THE_BTREES.matriculaYaExistente 
	(@Matricula NVARCHAR(255))
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.Avion 
	WHERE Avion_Matricula = @Matricula;

	IF @Cantidad > 0
		RETURN 1;

	RETURN 0;
END
GO


