USE [GD2C2015]
GO

/***** GetEstadisticaSelecionada *****/
IF  object_id(N'[THE_BTREES].[GetEstadisticaSelecionada]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetEstadisticaSelecionada]
GO

CREATE PROCEDURE [THE_BTREES].[GetEstadisticaSelecionada]		
	@Opcion AS INT,
	@Semestre AS INT,
	@Año AS INT
AS
    BEGIN
	   SET NOCOUNT ON	

       DECLARE @Desde AS DATE
	   DECLARE @Hasta AS DATE

	   IF @Semestre=1
			BEGIN
			SET @Desde=DATEFROMPARTS(@Año,1,1)
			SET @Hasta=DATEFROMPARTS(@Año,6,30)
			END
		ELSE
			BEGIN
			SET @Desde=DATEFROMPARTS(@Año,7,1)
			SET @Hasta=DATEFROMPARTS(@Año,12,31)
			END

	    IF @Opcion=1
			BEGIN
				SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS Ciudad,
							COUNT(P.PasajeID) AS 'Cantidad de Pasajes'
				FROM THE_BTREES.Pasaje P
				INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
				INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
				WHERE V.Viaje_FechaLlegada BETWEEN @Desde AND @Hasta 
				GROUP BY R.Ruta_CiudadDestinoRef
				ORDER BY COUNT(P.PasajeID) DESC
		 RETURN
		 END

		 ELSE IF @Opcion=2
			 BEGIN
				SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS Ciudad,
						 (SUM(Y.CantButacas) - COUNT(P.Pasaje_ButacaRef)) AS 'Cant Butacas Sin Comprar'  
				FROM THE_BTREES.Pasaje P
				INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
				INNER JOIN (SELECT A.AvionID,
								    COUNT(B.ButacaID) AS CantButacas
							 FROM THE_BTREES.Avion A
							 INNER JOIN THE_BTREES.Butaca B ON B.Butaca_AvionRef = A.AvionID
							GROUP BY A.AvionID) Y ON Y.AvionID=V.Viaje_AvionRef
				INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
				WHERE V.Viaje_FechaLlegada BETWEEN @Desde AND @Hasta 
				GROUP BY R.Ruta_CiudadDestinoRef
				ORDER BY (SUM(Y.CantButacas) - COUNT(P.Pasaje_ButacaRef)) DESC
		 RETURN
		 END

		 ELSE IF @Opcion=3
		 BEGIN
			SELECT TOP 5 (SELECT Cliente_Nombre FROM THE_BTREES.Cliente WHERE ClienteID=M.Tran_ClienteRef) AS Cliente,
			       SUM(M.CantMillas) AS 'Cantidad de millas disponibles'
			FROM (SELECT E.Tran_ClienteRef,
    					 (CASE 
						  WHEN E.Tran_CanjeRef IS NULL THEN E.Tran_CantidadMillas
						  ELSE 0-E.Tran_CantidadMillas
						  END) AS CantMillas
				  FROM THE_BTREES.TransaccionesMillas E ) M 
			GROUP BY M.Tran_ClienteRef
			ORDER BY SUM(M.CantMillas) DESC
		 RETURN
		 END

		 ELSE IF @Opcion=4
		 BEGIN
				SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS Ciudad,
						COUNT(P.PasajeID) AS 'Cant Pasajes Cancelados'
				FROM THE_BTREES.Pasaje P
				INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
				INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
			    WHERE V.Viaje_FechaLlegada BETWEEN @Desde AND @Hasta AND Pasaje_CancelacionRef IS NOT NULL
			    GROUP BY R.Ruta_CiudadDestinoRef
				ORDER BY COUNT(P.PasajeID) DESC				
		 RETURN
		 END

		 ELSE
		 BEGIN
		 	   SELECT TOP 5 A.Avion_Matricula AS 'Matricula',
				    	F.CantidadDiasFuera AS 'Cant Dias Fuera de Servicio'
			  FROM THE_BTREES.Avion A
			  INNER JOIN (SELECT Q.Fuera_AvionRef,
								 SUM(DATEDIFF(DAY,Q.Fuera_FechaVuelta,Q.Fuera_FechaVuelta)) AS CantidadDiasFuera	 
						  FROM THE_BTREES.FueraDeServicio Q
						  WHERE Q.Fuera_FechaFuera BETWEEN @Desde AND @Hasta 
						  GROUP BY Q.Fuera_AvionRef) F ON F.Fuera_AvionRef=A.AvionID
			  ORDER BY CantidadDiasFuera DESC
		 RETURN
		 END
	   END
GO