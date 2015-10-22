/***** GetDestinosMasCompradosList *****/
IF  object_id(N'[GetDestinosMasCompradosList]','P') IS NOT NULL
	DROP PROCEDURE [GetDestinosMasCompradosList]
GO

CREATE PROCEDURE [GetDestinosMasCompradosList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 (SELECT Ciudad_Nombre FROM dbo.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef),
					COUNT(P.PasajeID) AS CantidadDePasajes
	   FROM dbo.Pasaje P
	   INNER JOIN dbo.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
	   INNER JOIN dbo.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   GROUP BY R.Ruta_CiudadDestinoRef
	   ORDER BY COUNT(P.PasajeID) DESC

	   END
GO

/***** GetDestinosMasPasajesCanceladosList *****/
IF  object_id(N'[GetDestinosMasPasajesCanceladosList]','P') IS NOT NULL
	DROP PROCEDURE [GetDestinosMasPasajesCanceladosList]
GO

CREATE PROCEDURE [GetDestinosMasPasajesCanceladosList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 (SELECT Ciudad_Nombre FROM dbo.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef),
					COUNT(C.Cance_PasajeRef) AS CantidadDePasajes
	   FROM dbo.Cancelacion C
	   INNER JOIN dbo.Pasaje P ON P.PasajeID = C.Cance_PasajeRef
	   INNER JOIN dbo.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
	   INNER JOIN dbo.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   GROUP BY R.Ruta_CiudadDestinoRef
	   ORDER BY COUNT(C.Cance_PasajeRef) DESC

	   END
GO

/***** GetAvionesConMasDiasFueraDeServicioList *****/
IF  object_id(N'[GetAvionesConMasDiasFueraDeServicioList]','P') IS NOT NULL
	DROP PROCEDURE [GetAvionesConMasDiasFueraDeServicioList]
GO

CREATE PROCEDURE [GetAvionesConMasDiasFueraDeServicioList]		

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT TOP 5 A.Avion_Matricula,
					F.CantidadDiasFuera
	   FROM dbo.Avion A
	   INNER JOIN (SELECT Q.Fuera_AvionRef,
						  SUM(DATEDIFF(DAY,Q.Fuera_FechaVuelta,Q.Fuera_FechaVuelta)) AS CantidadDiasFuera	 
				  FROM dbo.FueraDeServicio Q
				  GROUP BY Q.Fuera_AvionRef) F ON F.Fuera_AvionRef=A.AvionID
	  ORDER BY CantidadDiasFuera

	  END
GO

