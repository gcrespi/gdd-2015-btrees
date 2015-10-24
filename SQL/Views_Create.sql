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
	   M.Cli_Apellido,
	   M.Cli_Dir,
	   M.Cli_Dni,
	   M.Cli_Fecha_Nac,
	   M.Cli_Mail,
	   M.Cli_Nombre,
	   M.Cli_Telefono	
FROM gd_esquema.Maestra m
GO