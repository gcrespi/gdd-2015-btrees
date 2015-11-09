USE [GD2C2015]
GO

CREATE VIEW THE_BTREES.viajes_con_ref
AS
SELECT DISTINCT m.FechaSalida,
				m.FechaLLegada,
				(SELECT AvionID FROM THE_BTREES.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
				m.Ruta_Codigo,
				(SELECT TipoServicioID FROM THE_BTREES.TipoServicio WHERE TipoSer_Nombre=m.Tipo_Servicio) AS TipoServicioRef,
				m.Fecha_LLegada_Estimada,
				(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE m.Ruta_Ciudad_Destino=Ciudad_Nombre) AS CiudadDestinoRef,
				(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE m.Ruta_Ciudad_Origen=Ciudad_Nombre) AS CiudadOrigenRef
FROM gd_esquema.Maestra m
GO

CREATE VIEW THE_BTREES.compra_con_ref
AS
SELECT DISTINCT (SELECT AvionID FROM THE_BTREES.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
	   (CASE 
			WHEN M.Pasaje_Codigo<>0 THEN M.Pasaje_FechaCompra
			ELSE M.Paquete_FechaCompra
			END) AS fechaCompra,
	   (CASE 
	   	   WHEN M.Pasaje_Codigo<>0 THEN M.Pasaje_Codigo
		   ELSE M.Paquete_Codigo
		   END) AS CodigoCompra,
	   m.FechaLLegada,
	   m.FechaSalida,
	   m.Fecha_LLegada_Estimada,
	   c.ClienteID AS CompradorRef
FROM gd_esquema.Maestra m, THE_BTREES.Cliente c
WHERE m.Cli_Dni = c.Cliente_DNI AND m.Cli_Apellido = c.Cliente_Apellido
GO

CREATE VIEW THE_BTREES.Viaje_Pasajes_Vendidos
AS
SELECT P.Pasaje_ViajeRef AS Viaje,
	   B.CantidadDeButacas,
	   B.CantidadDeButacas -  COUNT(P.PasajeID) AS ButacasDisponibles
FROM THE_BTREES.Pasaje P
INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
INNER JOIN (SELECT Butaca_AvionRef AS Avion,
					COUNT(ButacaID) AS CantidadDeButacas
            FROM THE_BTREES.Butaca
			GROUP BY Butaca_AvionRef) B ON V.Viaje_AvionRef=B.Avion
WHERE P.Pasaje_CancelacionRef IS NULL
GROUP BY P.Pasaje_ViajeRef,B.CantidadDeButacas
GO

CREATE VIEW THE_BTREES.kg_Dispo_Por_Viaje
AS
	   SELECT v.ViajeID,
			  A.Avion_CantidadKgsDisponibles AS KSTotales,
			 (A.Avion_CantidadKgsDisponibles-(SUM(E.Enco_KG))) AS KGDisponibles
	   FROM THE_BTREES.Avion A
	   INNER JOIN THE_BTREES.Viaje V ON A.AvionID=V.Viaje_AvionRef
	   INNER JOIN THE_BTREES.Encomienda E ON E.Enco_ViajeRef=V.ViajeID
	   WHERE E.Enco_CancelacionRef IS NULL
	   GROUP BY E.Enco_ViajeRef,A.Avion_CantidadKgsDisponibles,V.ViajeID

GO


