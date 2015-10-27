USE [GD2C2015]
GO

/***** GetViajesDisponiblesList *****/
IF  object_id(N'[THE_BTREES].[GetViajesDisponiblesList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetViajesDisponiblesList]
GO

CREATE PROCEDURE [THE_BTREES].[GetViajesDisponiblesList]		
    @TipoServicio AS TINYINT,
	@Fecha AS DATETIME,
	@CiudadDestino AS SMALLINT,
	@CiudadOrigen AS SMALLINT
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   IF @TipoServicio=0 
			SET @TipoServicio=NULL

	   IF @CiudadDestino=0 
			SET @CiudadDestino=NULL

	   IF @CiudadOrigen=0 
			SET @CiudadOrigen=NULL

	   IF CAST(@Fecha AS DATE)= CAST('2000-01-01' AS DATE)
			SET @Fecha=NULL

	   SELECT V.ViajeID,
			  A.Avion_Matricula AS Avión,
			  (SELECT TipoSer_Nombre FROM THE_BTREES.TipoServicio WHERE TipoServicioID=A.Avion_TipoDeServicioRef) AS 'Tipo De Servicio',
			  V.Viaje_FechaSalida AS 'Fecha Salida',
			  V.Viaje_FechaLlegadaEstimada AS 'Fecha LLegada Estimada',
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadOrigenRef) AS 'Ciudad Origen',
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS 'Ciudad Destino',
			  W.ButacasDisponibles AS 'Cant Butacas Disponibles',
			  K.KGDisponibles AS 'Cant KG Disponibles'
	   FROM THE_BTREES.Viaje V
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   INNER JOIN THE_BTREES.Avion A ON A.AvionID = V.Viaje_AvionRef AND A.Avion_TipoDeServicioRef=ISNULL(@TipoServicio,a.Avion_TipoDeServicioRef)
	   INNER JOIN THE_BTREES.Viaje_Pasajes_Vendidos W ON W.Viaje=V.ViajeID
	   INNER JOIN THE_BTREES.kg_Dispo_Por_Viaje K ON K.ViajeID=V.ViajeID
	   WHERE V.Viaje_FechaSalida=ISNULL(@Fecha,V.Viaje_FechaSalida) AND R.Ruta_CiudadDestinoRef=ISNULL(@CiudadDestino,R.Ruta_CiudadDestinoRef) 
			AND R.Ruta_CiudadOrigenRef=ISNULL(@CiudadOrigen,R.Ruta_CiudadOrigenRef) AND W.ButacasDisponibles>0
	   ORDER BY V.Viaje_FechaLlegada
	   END
GO

USE [GD2C2015]
GO

/***** GetButacasDisponiblesViajeList *****/
IF  object_id(N'[THE_BTREES].[GetButacasDisponiblesViajeList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetButacasDisponiblesViajeList]
GO

CREATE PROCEDURE [THE_BTREES].[GetButacasDisponiblesViajeList]		
    @Viaje AS INT
			
AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT B.Butaca_Numero,
			  B.Butaca_EsVentanilla
	   FROM THE_BTREES.Butaca B
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID=@Viaje AND Butaca_AvionRef=V.Viaje_AvionRef
	   WHERE B.ButacaID NOT IN (SELECT ButacaID FROM THE_BTREES.Pasaje WHERE Pasaje_ViajeRef=@Viaje AND Pasaje_CancelacionRef IS NULL)

	   END
GO
