/************ INSERT CIUDADES **************/
BEGIN
INSERT INTO dbo.Ciudad
        ( Ciudad_Nombre, Ciudad_Activo )
SELECT DISTINCT m.Ruta_Ciudad_Destino,
		1
FROM gd_esquema.Maestra M

INSERT INTO dbo.Ciudad
        ( Ciudad_Nombre, Ciudad_Activo )
SELECT DISTINCT m.Ruta_Ciudad_Origen,
		1
FROM gd_esquema.Maestra M
WHERE M.Ruta_Ciudad_Origen NOT IN (SELECT Ciudad_Nombre FROM dbo.Ciudad)

SELECT * FROM dbo.Ciudad
END

/************ INSERT CLIENTES **************/
BEGIN
INSERT INTO dbo.Cliente
        ( Cliente_Nombre ,
          Cliente_Apellido ,
          Cliente_DNI ,
          Cliente_Direccion ,
          Cliente_Telefono ,
          Cliente_Mail ,
          Cliente_FechaNac
        )
SELECT DISTINCT M.Cli_Nombre,
		M.Cli_Apellido,
		M.Cli_Dni,
		M.Cli_Dir,
		M.Cli_Telefono,
		M.Cli_Mail,
		M.Cli_Fecha_Nac
FROM gd_esquema.Maestra M
END

/************ INSERT TIPO DE SERVICIOS **************/
BEGIN
INSERT INTO dbo.TipoServicio
        ( TipoSer_Nombre ,
          TipoSer_PorcentajeAdicional
        )
SELECT DISTINCT m.Tipo_Servicio,
		1
FROM gd_esquema.Maestra m
END

/************ INSERT AVION **************/
BEGIN
INSERT INTO dbo.Avion
        ( Avion_FechaDeAlta ,
          Avion_Numero ,
          Avion_Modelo ,
          Avion_Matricula ,
          Avion_Fabricante ,
          Avion_TipoDeServicioRef ,
          Avion_BajaPorFueraDeServicio ,
          Avion_BajaPorVidaUtil ,
          Avion_CantidadButacas ,
          Avion_CantidadKgsDisponibles
        )
SELECT DISTINCT GETDATE(),
		1,
		m.Aeronave_Modelo,
		m.Aeronave_Matricula,
		m.Aeronave_Fabricante,
		(SELECT t.TipoServicioID FROM dbo.TipoServicio T WHERE t.TipoSer_Nombre = m.Tipo_Servicio),
		0,
		0,
		0,	
		m.Aeronave_KG_Disponibles				
FROM gd_esquema.Maestra M
END

/************ INSERT BUTACAS **************/
BEGIN
INSERT INTO dbo.Butaca
        ( Butaca_AvionRef ,
          Butaca_Numero ,
          Butaca_EsVentanilla ,
          Butaca_Piso ,
          Butaca_estaOcupada
        )
SELECT (SELECT AvionID FROM dbo.Avion WHERE Avion_Matricula=m.Aeronave_Matricula),
		m.Butaca_Nro,
		(CASE 
		WHEN  m.Butaca_Tipo='Ventanilla' THEN 1
		ELSE 0
		END) AS tipoButaca,
		m.Butaca_Piso,
		1
FROM gd_esquema.Maestra m
WHERE m.Butaca_Nro<>0 AND m.Butaca_Tipo<>'0'
END

/************ INSERT CANT DE BUTACAS EN AVION **************/
BEGIN
BEGIN TRANSACTION
UPDATE dbo.Avion SET
	Avion_CantidadButacas = (SELECT COUNT(*) FROM dbo.Butaca b WHERE B.Butaca_AvionRef = AvionID)
COMMIT
END

/************ INSERT RUTAS AEREAS **************/ ---> UN MISMO CODIGO DE RUTA TIENE DISTINTAS CIUDADES DE ORIGEN Y DESTINO... TURBIO
BEGIN
INSERT INTO dbo.RutaAerea
        ( Ruta_Codigo ,
          Ruta_CiudadOrigenRef ,
          Ruta_CiudadDestinoRef ,
          Ruta_PrecioBaseKg ,
          Ruta_PrecioBasePasaje ,
          Ruta_Activo
        )
SELECT DISTINCT M.Ruta_Codigo,
		(SELECT CiudadID FROM dbo.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen),
		(SELECT CiudadID FROM dbo.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Destino),
		0,
		0,
		1
FROM gd_esquema.Maestra m

BEGIN TRANSACTION
UPDATE dbo.RutaAerea
SET Ruta_PrecioBaseKg = tabla2.precioBase
FROM RutaAerea t1, (SELECT Ruta_Precio_BaseKG AS precioBase,m.Ruta_Codigo AS ruta FROM gd_esquema.Maestra m 
					INNER JOIN dbo.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BaseKG<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BaseKG
					)  tabla2
WHERE t1.Ruta_Codigo = tabla2.ruta
COMMIT

BEGIN TRANSACTION
UPDATE dbo.RutaAerea
SET Ruta_PrecioBasePasaje = tabla2.precioBase
FROM RutaAerea t1, (SELECT Ruta_Precio_BasePasaje AS precioBase,m.Ruta_Codigo AS ruta FROM gd_esquema.Maestra m 
					INNER JOIN dbo.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BasePasaje<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BasePasaje
					)  tabla2
WHERE t1.Ruta_Codigo = tabla2.ruta
COMMIT

END

/************ INSERT TIPO SERVICIO X RUTA AEREA **************/
BEGIN
INSERT INTO dbo.TipoServicioXRutaAerea
        ( RutaAereaRef, TipoServicioRef )
SELECT	DISTINCT R.RutaAereaID,
		T.TipoServicioID
FROM gd_esquema.Maestra M
INNER JOIN dbo.RutaAerea R ON R.Ruta_Codigo = M.Ruta_Codigo 
INNER JOIN dbo.TipoServicio T ON T.TipoSer_Nombre=M.Tipo_Servicio
END

/************ INSERT TIPO TARJETA DE CREDITO **************/
BEGIN
INSERT INTO dbo.TipoTarjetaDeCredito
        ( TipoTC_CantCuotas ,
          TipoTC_Nombre
        )
VALUES  (2,'MasterCard'),
		(5,'Visa'),
		(4,'American Express')
END

/************ INSERT VIAJE **************/ 
BEGIN
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

INSERT INTO dbo.Viaje
        ( Viaje_FechaSalida ,
          Viaje_FechaLlegada ,
          Viaje_AvionRef ,
          Viaje_RutaAereaRef ,
          Viaje_Activo ,
          Viaje_FechaLlegadaEstimada
        )

SELECT DISTINCT v.FechaSalida,
				v.FechaLLegada,
				v.AvionRef,
				r.RutaAereaID,
				1,
				v.Fecha_LLegada_Estimada
FROM dbo.viajes_con_ref V
INNER JOIN dbo.RutaAerea r ON r.Ruta_Codigo = v.Ruta_Codigo AND r.Ruta_CiudadDestinoRef=v.CiudadDestinoRef AND r.Ruta_CiudadOrigenRef=v.CiudadOrigenRef
INNER JOIN dbo.TipoServicioXRutaAerea ta ON ta.TipoServicioRef=v.TipoServicioRef AND ta.RutaAereaRef=r.RutaAereaID
END

/************ INSERT COMPRAS **************/

/************ INSERT PASAJES **************/

/************ INSERT PAQUETES **************/

