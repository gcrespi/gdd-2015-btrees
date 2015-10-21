CREATE VIEW viajes_con_ref
AS
SELECT DISTINCT m.FechaSalida,
				m.FechaLLegada,
				(SELECT AvionID FROM dbo.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
				m.Ruta_Codigo,
				(SELECT TipoServicioID FROM dbo.TipoServicio WHERE TipoSer_Nombre=m.Tipo_Servicio) AS TipoServicioRef,
				m.Fecha_LLegada_Estimada,
				(SELECT CiudadID FROM dbo.Ciudad WHERE m.Ruta_Ciudad_Destino=Ciudad_Nombre) AS CiudadDestinoRef,
				(SELECT CiudadID FROM dbo.Ciudad WHERE m.Ruta_Ciudad_Origen=Ciudad_Nombre) AS CiudadOrigenRef
FROM gd_esquema.Maestra m
GO