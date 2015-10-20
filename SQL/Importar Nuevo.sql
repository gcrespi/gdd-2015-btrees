/************ INSERT CIUDADES *********35 CIUDADES*****/
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

END

/************ INSERT CLIENTES ***** 2594 CLIENTES *********/
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

/************ INSERT TIPO DE SERVICIOS ****** 3 TIPOS ********/
BEGIN
INSERT INTO dbo.TipoServicio
        ( TipoSer_Nombre ,
          TipoSer_PorcentajeAdicional
        )
SELECT DISTINCT m.Tipo_Servicio,
		1
FROM gd_esquema.Maestra m
END

/************ INSERT AVION ***** 30 AVIONES ********/
BEGIN
INSERT INTO dbo.Avion
        ( Avion_FechaDeAlta ,
          Avion_Modelo ,
          Avion_Matricula ,
          Avion_Fabricante ,
          Avion_TipoDeServicioRef ,
          Avion_BajaPorFueraDeServicio ,
          Avion_BajaPorVidaUtil ,
          Avion_CantidadKgsDisponibles
        )
SELECT DISTINCT GETDATE(),
		m.Aeronave_Modelo,
		m.Aeronave_Matricula,
		m.Aeronave_Fabricante,
		(SELECT t.TipoServicioID FROM dbo.TipoServicio T WHERE t.TipoSer_Nombre = m.Tipo_Servicio),
		0,
		0,
		m.Aeronave_KG_Disponibles				
FROM gd_esquema.Maestra M
END

/************ INSERT BUTACAS ******** 1337 butacas ******/
BEGIN
INSERT INTO dbo.Butaca
        ( Butaca_AvionRef ,
          Butaca_Numero ,
          Butaca_EsVentanilla
        )
SELECT DISTINCT (SELECT AvionID FROM dbo.Avion WHERE Avion_Matricula=m.Aeronave_Matricula),
		m.Butaca_Nro,
		(CASE 
		WHEN  m.Butaca_Tipo='Ventanilla' THEN 1
		ELSE 0
		END) AS tipoButaca
FROM gd_esquema.Maestra m
WHERE m.Butaca_Piso=1
END

/************ INSERT RUTAS AEREAS ****** 68 rutas ********/ ---> UN MISMO CODIGO DE RUTA TIENE DISTINTAS CIUDADES DE ORIGEN Y DESTINO... TURBIO
-- https://groups.google.com/forum/#!topic/gestiondedatos/Q1eg0vCooVE en este link explica que tenemos que guardar todo, y manejarlo nosotros bien con un codigo interno, asi que esto esta bien
-- existen en total 35 codigo de rutas diferentes nomas, pero con el tema de que estna mal las ciudades, se hacen 68
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
FROM RutaAerea t1, (SELECT m.Ruta_Precio_BaseKG AS precioBase,
						   m.Ruta_Codigo AS ruta 
					FROM gd_esquema.Maestra m 
					INNER JOIN dbo.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BaseKG<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BaseKG
					) tabla2
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

/************ INSERT TIPO SERVICIO X RUTA AEREA ***** 68 RUTAS POR TIPO DE SERVICIO *********/
BEGIN
INSERT INTO dbo.TipoServicioXRutaAerea
        ( RutaAereaRef, TipoServicioRef )
SELECT	DISTINCT R.RutaAereaID,
		         T.TipoServicio
FROM dbo.RutaAerea R
INNER JOIN (SELECT DISTINCT M.Ruta_Codigo,
		                    (SELECT CiudadID FROM dbo.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen) AS CiudadOrigenRef,
		                    (SELECT CiudadID FROM dbo.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Destino) AS CiudadDestinoRef,
							(SELECT TipoServicioID FROM dbo.TipoServicio WHERE TipoSer_Nombre=M.Tipo_Servicio) AS TipoServicio
            FROM gd_esquema.Maestra m ) AS T ON T.Ruta_Codigo=R.Ruta_Codigo 
												AND T.CiudadOrigenRef=R.Ruta_CiudadOrigenRef
												AND T.CiudadDestinoRef=R.Ruta_CiudadDestinoRef


/************ INSERT TIPO TARJETA **************/
BEGIN
INSERT INTO dbo.TiposTarjeta
        ( TipoTarj_Descripcion ,
          TipoTarj_CuotasMax
        )
VALUES  ('MasterCard',2),
		('Visa',5),
		('American Express',4)
END

/************ INSERT VIAJE ***** 8510 VIAJES *********/ 
BEGIN
INSERT INTO dbo.Viaje
        ( Viaje_FechaSalida,
          Viaje_FechaLlegada,
          Viaje_AvionRef,
          Viaje_RutaAereaRef,
          Viaje_FechaLlegadaEstimada
        )

SELECT DISTINCT v.FechaSalida,
				v.FechaLLegada,
				v.AvionRef,
				r.RutaAereaID,
				v.Fecha_LLegada_Estimada
FROM dbo.viajes_con_ref V
INNER JOIN dbo.RutaAerea r ON r.Ruta_Codigo = v.Ruta_Codigo 
							  AND r.Ruta_CiudadDestinoRef=v.CiudadDestinoRef 
							  AND r.Ruta_CiudadOrigenRef=v.CiudadOrigenRef
END

/************ INSERT COMPRAS **************/
-- EN IMPORTACION HAY RELACION DE UNO A UNO CON COMPRAS Y PASAJES Y PAQUETES (TIENE EL MISMO CODIGO)
-- CUANDO SE IMPLEMENTE UNA COMPRA PUEDE TENER MAS 
-- DE UN PASAJE O ENCOMIENDA 
INSERT INTO dbo.Compra
        ( Compra_Codigo ,
          Compra_Fecha ,
          Compra_AbonaEnEfectivo ,
          Compra_DNIComprador ,
          Compra_Nombre ,
          Compra_Apellido ,
          Compra_Direccion ,
          Compra_Telefeno ,
          Compra_Mail ,
          Compra_FechaNac
        )
SELECT DISTINCT C.CodigoCompra,
				C.fechaCompra,
				1, --TODOS ABONAN EN EFECTIVO
				C.Cli_Dni,
				C.Cli_Nombre,
				C.Cli_Apellido,
				C.Cli_Dir,
				C.Cli_Telefono,
				C.Cli_Mail,
				C.Cli_Fecha_Nac
FROM dbo.compra_con_ref C

/************ INSERT PASAJES ****** 135658 PASAJES ********/


/************ INSERT ENCOMIENDA *******265646 ENCOMIEDAS*******/
