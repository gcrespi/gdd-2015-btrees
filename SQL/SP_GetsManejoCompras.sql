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

		SET @Fecha = CAST(@Fecha AS DATE)

	   IF @Fecha = '2000-01-01'
			SET @Fecha=NULL

	   SELECT V.ViajeID,
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadOrigenRef) AS 'Ciudad Origen',
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS 'Ciudad Destino',
			  V.Viaje_FechaSalida AS 'Fecha Salida',
			  V.Viaje_FechaLlegadaEstimada AS 'Fecha LLegada Estimada',
			  T.TipoSer_Nombre AS 'Tipo De Servicio',
			  W.ButacasDisponibles AS 'Cant Butacas Disponibles',
			  '$' + CAST((R.Ruta_PrecioBasePasaje*(1+T.TipoSer_PorcentajeAdicional)) AS varchar) AS 'Precio Pasaje',
			  K.KGDisponibles AS 'Cant KG Disponibles',
			  '$' + CAST(R.Ruta_PrecioBaseKg AS varchar) AS 'Precio por KG'
	   FROM THE_BTREES.Viaje V
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   INNER JOIN THE_BTREES.Avion A ON A.AvionID = V.Viaje_AvionRef AND A.Avion_TipoDeServicioRef=ISNULL(@TipoServicio,a.Avion_TipoDeServicioRef)
	   LEFT JOIN THE_BTREES.Viaje_Pasajes_Vendidos W ON W.Viaje=V.ViajeID
	   LEFT JOIN THE_BTREES.kg_Dispo_Por_Viaje K ON K.ViajeID=V.ViajeID
	   INNER JOIN THE_BTREES.TipoServicio T ON T.TipoServicioID=A.Avion_TipoDeServicioRef
	   WHERE CAST(V.Viaje_FechaSalida AS DATE)=ISNULL(CAST(@Fecha AS DATE),CAST(V.Viaje_FechaSalida AS DATE)) AND 
			 R.Ruta_CiudadDestinoRef=ISNULL(@CiudadDestino,R.Ruta_CiudadDestinoRef) AND 
			 R.Ruta_CiudadOrigenRef=ISNULL(@CiudadOrigen,R.Ruta_CiudadOrigenRef) AND
			 W.ButacasDisponibles>0
	   ORDER BY V.Viaje_FechaSalida
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
	   SELECT B.ButacaID,
			  (CAST(B.Butaca_Numero AS varchar) + (CASE WHEN B.Butaca_EsVentanilla = 1 THEN ' - Ventanilla' 
												   	    WHEN B.Butaca_EsVentanilla = 0 THEN ' - Pasillo' END))  Butaca_Descr
	   FROM THE_BTREES.Butaca B
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID=@Viaje AND Butaca_AvionRef=V.Viaje_AvionRef
	   WHERE B.ButacaID NOT IN (SELECT Pasaje_ButacaRef FROM THE_BTREES.Pasaje WHERE Pasaje_ViajeRef=@Viaje AND Pasaje_CancelacionRef IS NULL)
	   ORDER BY B.Butaca_Numero

	   END
GO

USE [GD2C2015]
GO

/***** GetDatosCliente *****/
IF  object_id(N'[THE_BTREES].[GetDatosCliente]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetDatosCliente]
GO

CREATE PROCEDURE [THE_BTREES].[GetDatosCliente]		
    @nombre AS varchar(50),
	@apellido AS varchar(50),
	@dni AS int
			
AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT ClienteID,
			  Cliente_Nombre,
			  Cliente_Apellido,
			  Cliente_DNI,
			  Cliente_Direccion,
			  Cliente_Telefono,
			  Cliente_Mail,
			  Cliente_FechaNac
	   FROM THE_BTREES.Cliente
	   WHERE Cliente_DNI = @dni AND Cliente_Apellido = @apellido AND Cliente_Nombre = @nombre
	END
GO