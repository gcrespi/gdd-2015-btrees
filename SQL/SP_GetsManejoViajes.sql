/***** GetAeronavesParaCompraList *****/
IF  object_id(N'[THE_BTREES].[GetAeronavesParaCompraList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetAeronavesParaCompraList]
GO

CREATE PROCEDURE [THE_BTREES].[GetAeronavesParaCompraList]		
		
AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT A.AvionID,
			  A.Avion_Matricula AS Matricula,
			  (SELECT TipoSer_Nombre FROM THE_BTREES.TipoServicio WHERE A.Avion_TipoDeServicioRef=TipoServicioID) AS 'Tipo de Servicio',
			  A.Avion_TipoDeServicioRef AS ServicioRef
	   FROM THE_BTREES.Avion A
	   WHERE (A.Avion_FechaDeBajaDefinitiva<GETDATE() OR A.Avion_FechaDeBajaDefinitiva IS NULL)  AND A.Avion_BajaPorFueraDeServicio=0 AND A.Avion_BajaPorVidaUtil=0

	   END
GO

/***** GetRutasAereasParaCompraList *****/
IF  object_id(N'[THE_BTREES].[GetRutasAereasParaCompraList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetRutasAereasParaCompraList]
GO

CREATE PROCEDURE [THE_BTREES].[GetRutasAereasParaCompraList]		

AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT R.RutaAereaID,
			  R.Ruta_Codigo AS 'Codigo de Ruta',
	          (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS 'Ciudad Destino',
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadOrigenRef) AS 'Ciudad Origen',
			  (SELECT TipoSer_Nombre FROM THE_BTREES.TipoServicio WHERE T.TipoServicioRef=TipoServicioID) AS 'Tipo de Servicio',
			  t.TipoServicioRef AS ServicioRef
	   FROM THE_BTREES.RutaAerea R
	   INNER JOIN THE_BTREES.TipoServicioXRutaAerea T ON T.RutaAereaRef=R.RutaAereaID
	   END
GO

/***** AddViaje *****/
IF  object_id(N'[THE_BTREES].[AddViaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddViaje]
GO

CREATE PROCEDURE [THE_BTREES].[AddViaje]	
	@FechaSalida AS DATETIME,
	@FechaLlegada AS DATETIME,
	@FechaLlegadaEst AS DATETIME,
	@Avion AS INT,
	@RutaAerea AS INT	

AS
    BEGIN
	   SET NOCOUNT ON

	   IF (@Avion IN (SELECT Viaje_AvionRef FROM THE_BTREES.Viaje WHERE @FechaSalida BETWEEN Viaje_FechaSalida AND Viaje_FechaLlegada))
			  BEGIN
			  RAISERROR ('Avion Ocupado en otro Viaje', 11,1)
			  RETURN
			  END

	   ELSE	
	   BEGIN
	   INSERT INTO THE_BTREES.Viaje
	           ( Viaje_FechaSalida ,
	             Viaje_FechaLlegada ,
	             Viaje_AvionRef ,
	             Viaje_RutaAereaRef ,
	             Viaje_FechaLlegadaEstimada
	           )
	   VALUES  ( @FechaSalida,
				 @FechaLlegada,
				 @Avion,
				 @RutaAerea,
				 @FechaLlegadaEst
	           )
	   END
	END
GO

