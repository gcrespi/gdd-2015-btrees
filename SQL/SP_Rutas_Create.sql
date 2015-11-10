USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[Deshabilitar_Ruta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Deshabilitar_Ruta]
GO

IF  object_id(N'[THE_BTREES].[Modificar_Ruta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Modificar_Ruta]
GO

IF  object_id(N'[THE_BTREES].[Crear_Ruta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Crear_Ruta]
GO


CREATE PROCEDURE THE_BTREES.Crear_Ruta
	@Ruta_Codigo numeric(18, 0),
	@Ruta_CiudadOrigenRef SMALLINT,
	@Ruta_CiudadDestinoRef SMALLINT,
	@Ruta_PrecioBaseKg numeric(18, 2),
	@Ruta_PrecioBasePasaje numeric(18, 2),
	@Ruta_Activo BIT,
	@ServiciosSeleccionados [THE_BTREES].[IntList] READONLY
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.RutaAerea(Ruta_Codigo, Ruta_CiudadOrigenRef, Ruta_CiudadDestinoRef, Ruta_PrecioBaseKg, Ruta_PrecioBasePasaje, Ruta_Activo) VALUES
	 (@Ruta_Codigo, @Ruta_CiudadOrigenRef, @Ruta_CiudadDestinoRef, @Ruta_PrecioBaseKg, @Ruta_PrecioBasePasaje, @Ruta_Activo)

	DECLARE @RutaRef tinyint

	SET  @RutaRef = SCOPE_IDENTITY()

	INSERT INTO THE_BTREES.TipoServicioXRutaAerea (RutaAereaRef, TipoServicioRef) 
	SELECT @RutaRef, Item FROM @ServiciosSeleccionados
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Modificar_Ruta
	@RutaAereaID INT,
	@Ruta_Codigo numeric(18, 0),
	@Ruta_CiudadOrigenRef SMALLINT,
	@Ruta_CiudadDestinoRef SMALLINT,
	@Ruta_PrecioBaseKg numeric(18, 2),
	@Ruta_PrecioBasePasaje numeric(18, 2),
	@Ruta_Activo BIT,
	@ServiciosSeleccionados [THE_BTREES].[IntList] READONLY
AS
	BEGIN TRAN
	UPDATE THE_BTREES.RutaAerea SET 
		Ruta_CiudadOrigenRef = @Ruta_CiudadOrigenRef, Ruta_CiudadDestinoRef = @Ruta_CiudadDestinoRef, 
		Ruta_PrecioBaseKg = @Ruta_PrecioBaseKg, Ruta_PrecioBasePasaje = @Ruta_PrecioBasePasaje, Ruta_Activo = @Ruta_Activo
	 WHERE @RutaAereaID = RutaAereaID

	 DELETE FROM THE_BTREES.TipoServicioXRutaAerea WHERE @RutaAereaID = RutaAereaRef

	 INSERT INTO THE_BTREES.TipoServicioXRutaAerea (RutaAereaRef, TipoServicioRef)
		SELECT @RutaAereaID, Item FROM @ServiciosSeleccionados
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Deshabilitar_Ruta
	@RutaAereaID INT
AS
	UPDATE THE_BTREES.RutaAerea SET Ruta_Activo = 0 WHERE @RutaAereaID = RutaAereaID
GO

IF  object_id(N'[THE_BTREES].[Listar_Rutas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Listar_Rutas]
GO

create PROCEDURE [THE_BTREES].[Listar_Rutas]
	( @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='SELECT DISTINCT r.RutaAereaID, r.Ruta_Codigo, co.Ciudad_Nombre, cd.Ciudad_Nombre, r.Ruta_PrecioBasePasaje, r.Ruta_PrecioBaseKg, r.Ruta_Activo '
	+ 'FROM THE_BTREES.RutaAerea r, THE_BTREES.Ciudad co, THE_BTREES.Ciudad cd, THE_BTREES.TipoServicioXRutaAerea ts ' 
	+ 'WHERE r.Ruta_CiudadOrigenRef = co.CiudadID AND r.Ruta_CiudadDestinoRef = cd.CiudadID AND ts.RutaAereaRef = r.RutaAereaID'
	+ @WhereClause
	+ 'ORDER BY r.RutaAereaID'
	execute (@sentencia)
GO


IF  object_id(N'[THE_BTREES].[TraerRutaConServicios]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerRutaConServicios]
GO

CREATE PROCEDURE THE_BTREES.TraerRutaConServicios
	@RutaID INT
AS
	SELECT r.Ruta_Codigo, r.Ruta_CiudadOrigenRef, r.Ruta_CiudadDestinoRef, r.Ruta_PrecioBasePasaje, r.Ruta_PrecioBaseKg, r.Ruta_Activo, ts.TipoServicioRef 
	FROM THE_BTREES.RutaAerea r, THE_BTREES.Ciudad co, THE_BTREES.Ciudad cd, THE_BTREES.TipoServicioXRutaAerea ts 
	WHERE r.Ruta_CiudadOrigenRef = co.CiudadID AND r.Ruta_CiudadDestinoRef = cd.CiudadID AND ts.RutaAereaRef = r.RutaAereaID AND @RutaID = RutaAereaID
GO


IF OBJECT_ID(N'[THE_BTREES].[CancelarRutasInhabilitados]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].CancelarRutasInhabilitados
GO

CREATE PROCEDURE THE_BTREES.CancelarRutasInhabilitados
	@RutaID INT,
	@FechaActual DATE
AS
BEGIN

	-- Sin terminar todavía

	SELECT DISTINCT CompraRef INTO THE_BTREES.#ItemsCompra
	FROM 
	(
		SELECT Enco_ViajeRef as ViajeRef, Enco_CompraRef AS CompraRef FROM THE_BTREES.Encomienda
		UNION
		SELECT Pasaje_ViajeRef as ViajeRef, Pasaje_CompraRef AS CompraRef FROM THE_BTREES.Pasaje
	) ItemsCompra

	INSERT INTO THE_BTREES.Cancelacion (Cance_CompraRef, Cance_Fecha, Motivo)
	SELECT i.PasajeID, @FechaActual, 'Baja de la Ruta Aerea asignada.' 
	FROM THE_BTREES.Viaje v 
		JOIN THE_BTREES.Compra c ON c.Compra_ViajeRef = v.ViajeID
		JOIN THE_BTREES.#ItemsCompra i ON i.CompraRef = c.CompraID
		--En realidad fecha de la aplicación WHERE v.Viaje_FechaSalida > GETDATE() AND v.Viaje_RutaAereaRef IN 
		(
			SELECT d.RutaAereaID FROM deleted d
				JOIN inserted as ins ON d.RutaAereaID = ins.RutaAereaID
				WHERE ins.Ruta_Activo = 1 AND d.Ruta_Activo = 0
		)

	DROP TABLE THE_BTREES.#ItemsCompra
	
	-- Sin terminar todavía
END
GO