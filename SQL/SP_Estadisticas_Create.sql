USE [GD2C2015]
GO

/***** GetDestinosMasCompradosList *****/
IF  object_id(N'[THE_BTREES].[GetDestinosMasCompradosList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetDestinosMasCompradosList]
GO

CREATE PROCEDURE [THE_BTREES].[GetDestinosMasCompradosList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef),
					COUNT(P.PasajeID) AS CantidadDePasajes
	   FROM THE_BTREES.Pasaje P
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   GROUP BY R.Ruta_CiudadDestinoRef
	   ORDER BY COUNT(P.PasajeID) DESC

	   END
GO

/***** GetDestinosConAvionesMasVaciosList *****/
IF  object_id(N'[THE_BTREES].[GetDestinosConAvionesMasVaciosList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetDestinosConAvionesMasVaciosList]
GO

CREATE PROCEDURE [THE_BTREES].[GetDestinosConAvionesMasVaciosList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef),
				 (SUM(Y.CantButacas) - COUNT(P.Pasaje_ButacaRef)) AS ButacasSinComprar  
	   FROM THE_BTREES.Pasaje P
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
	   INNER JOIN (SELECT A.AvionID,
				          COUNT(B.ButacaID) AS CantButacas
			      FROM THE_BTREES.Avion A
			      INNER JOIN THE_BTREES.Butaca B ON B.Butaca_AvionRef = A.AvionID
			      GROUP BY A.AvionID) Y ON Y.AvionID=V.Viaje_AvionRef
       INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
       GROUP BY R.Ruta_CiudadDestinoRef
       ORDER BY (SUM(Y.CantButacas) - COUNT(P.Pasaje_ButacaRef)) DESC
	   
	  END
GO

/***** GetDestinosMasPasajesCanceladosList *****/
IF  object_id(N'[THE_BTREES].[GetDestinosMasPasajesCanceladosList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetDestinosMasPasajesCanceladosList]
GO

CREATE PROCEDURE [THE_BTREES].[GetDestinosMasPasajesCanceladosList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef),
					COUNT(C.Cance_PasajeRef) AS CantidadDePasajes
	   FROM THE_BTREES.Cancelacion C
	   INNER JOIN THE_BTREES.Pasaje P ON P.PasajeID = C.Cance_PasajeRef
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   GROUP BY R.Ruta_CiudadDestinoRef
	   ORDER BY COUNT(C.Cance_PasajeRef) DESC

	   END
GO

/***** GetAvionesConMasDiasFueraDeServicioList *****/
IF  object_id(N'[THE_BTREES].[GetAvionesConMasDiasFueraDeServicioList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetAvionesConMasDiasFueraDeServicioList]
GO

CREATE PROCEDURE [THE_BTREES].[GetAvionesConMasDiasFueraDeServicioList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 A.Avion_Matricula,
					F.CantidadDiasFuera
	   FROM THE_BTREES.Avion A
	   INNER JOIN (SELECT Q.Fuera_AvionRef,
						  SUM(DATEDIFF(DAY,Q.Fuera_FechaVuelta,Q.Fuera_FechaVuelta)) AS CantidadDiasFuera	 
				  FROM THE_BTREES.FueraDeServicio Q
				  GROUP BY Q.Fuera_AvionRef) F ON F.Fuera_AvionRef=A.AvionID
	  ORDER BY CantidadDiasFuera

	  END
GO

