USE [GD2C2015]
GO

/************ INSERT CIUDADES *********35 CIUDADES*****/

INSERT INTO THE_BTREES.Ciudad
        ( Ciudad_Nombre, Ciudad_Activo )
SELECT DISTINCT m.Ruta_Ciudad_Destino,
		1
FROM gd_esquema.Maestra M

INSERT INTO THE_BTREES.Ciudad
        ( Ciudad_Nombre, Ciudad_Activo )
SELECT DISTINCT m.Ruta_Ciudad_Origen,
		1
FROM gd_esquema.Maestra M
WHERE M.Ruta_Ciudad_Origen NOT IN (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad)

GO

/************ INSERT CLIENTES ***** 2594 CLIENTES *********/

INSERT INTO THE_BTREES.Cliente
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
GO

/************ INSERT TIPO DE SERVICIOS ****** 3 TIPOS ********/

INSERT INTO THE_BTREES.TipoServicio
        ( TipoSer_Nombre ,
          TipoSer_PorcentajeAdicional
        )
SELECT DISTINCT m.Tipo_Servicio,
		1
FROM gd_esquema.Maestra m
GO

UPDATE THE_BTREES.TipoServicio
SET TipoSer_PorcentajeAdicional=1.2
WHERE TipoSer_Nombre='Turista'
UPDATE THE_BTREES.TipoServicio
SET TipoSer_PorcentajeAdicional=2
WHERE TipoSer_Nombre='Primera Clase'
UPDATE THE_BTREES.TipoServicio
SET TipoSer_PorcentajeAdicional=1.5
WHERE TipoSer_Nombre='Ejecutivo'



/************ INSERT AVION ***** 30 AVIONES ********/

INSERT INTO THE_BTREES.Avion
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
		(SELECT t.TipoServicioID FROM THE_BTREES.TipoServicio T WHERE t.TipoSer_Nombre = m.Tipo_Servicio),
		0,
		0,
		m.Aeronave_KG_Disponibles				
FROM gd_esquema.Maestra M
GO

/************ INSERT BUTACAS ******** 1337 butacas ******/

INSERT INTO THE_BTREES.Butaca
        ( Butaca_AvionRef ,
          Butaca_Numero ,
          Butaca_EsVentanilla
        )
SELECT DISTINCT (SELECT AvionID FROM THE_BTREES.Avion WHERE Avion_Matricula=m.Aeronave_Matricula),
		m.Butaca_Nro,
		(CASE 
		WHEN  m.Butaca_Tipo='Ventanilla' THEN 1
		ELSE 0
		END) AS tipoButaca
FROM gd_esquema.Maestra m
WHERE m.Butaca_Piso=1
GO

/************ INSERT RUTAS AEREAS ****** 68 rutas ********/ ---> UN MISMO CODIGO DE RUTA TIENE DISTINTAS CIUDADES DE ORIGEN Y DESTINO... TURBIO
-- https://groups.google.com/forum/#!topic/gestiondedatos/Q1eg0vCooVE en este link explica que tenemos que guardar todo, y manejarlo nosotros bien con un codigo interno, asi que esto esta bien
-- existen en total 35 codigo de rutas diferentes nomas, pero con el tema de que estna mal las ciudades, se hacen 68

INSERT INTO THE_BTREES.RutaAerea
        ( Ruta_Codigo ,
          Ruta_CiudadOrigenRef ,
          Ruta_CiudadDestinoRef ,
          Ruta_PrecioBaseKg ,
          Ruta_PrecioBasePasaje ,
          Ruta_Activo
        )
SELECT DISTINCT M.Ruta_Codigo,
		(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen),
		(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Destino),
		0,
		0,
		1
FROM gd_esquema.Maestra m

UPDATE THE_BTREES.RutaAerea
SET Ruta_PrecioBaseKg = tabla2.precioBase
FROM THE_BTREES.RutaAerea t1, (SELECT m.Ruta_Precio_BaseKG AS precioBase,
						   m.Ruta_Codigo AS ruta 
					FROM gd_esquema.Maestra m 
					INNER JOIN THE_BTREES.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BaseKG<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BaseKG
					) tabla2
WHERE t1.Ruta_Codigo = tabla2.ruta

UPDATE THE_BTREES.RutaAerea
SET Ruta_PrecioBasePasaje = tabla2.precioBase
FROM THE_BTREES.RutaAerea t1, (SELECT Ruta_Precio_BasePasaje AS precioBase,m.Ruta_Codigo AS ruta FROM gd_esquema.Maestra m 
					INNER JOIN THE_BTREES.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BasePasaje<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BasePasaje
					)  tabla2
WHERE t1.Ruta_Codigo = tabla2.ruta
GO

/************ INSERT TIPO SERVICIO X RUTA AEREA ***** 68 RUTAS POR TIPO DE SERVICIO *********/

INSERT INTO THE_BTREES.TipoServicioXRutaAerea
        ( RutaAereaRef, TipoServicioRef )
SELECT	DISTINCT R.RutaAereaID,
		         T.TipoServicio
FROM THE_BTREES.RutaAerea R
INNER JOIN (SELECT DISTINCT M.Ruta_Codigo,
		                    (SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen) AS CiudadOrigenRef,
		                    (SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Destino) AS CiudadDestinoRef,
							(SELECT TipoServicioID FROM THE_BTREES.TipoServicio WHERE TipoSer_Nombre=M.Tipo_Servicio) AS TipoServicio
            FROM gd_esquema.Maestra m ) AS T ON T.Ruta_Codigo=R.Ruta_Codigo 
												AND T.CiudadOrigenRef=R.Ruta_CiudadOrigenRef
												AND T.CiudadDestinoRef=R.Ruta_CiudadDestinoRef
GO

/************ INSERT TIPO TARJETA **************/

INSERT INTO THE_BTREES.TiposTarjeta
        ( TipoTarj_Descripcion ,
          TipoTarj_CuotasMax
        )
VALUES  ('MasterCard',2),
		('Visa',5),
		('American Express',4)
GO

/************ INSERT VIAJE ***** 8510 VIAJES *********/ 

INSERT INTO THE_BTREES.Viaje
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
FROM THE_BTREES.viajes_con_ref v 
INNER JOIN THE_BTREES.RutaAerea r ON r.Ruta_Codigo = v.Ruta_Codigo 
							  AND r.Ruta_CiudadDestinoRef=v.CiudadDestinoRef 
							  AND r.Ruta_CiudadOrigenRef=v.CiudadOrigenRef
GO

/************ INSERT COMPRAS **************/
-- EN IMPORTACION HAY RELACION DE UNO A UNO CON COMPRAS Y PASAJES Y PAQUETES (TIENE EL MISMO CODIGO)
-- CUANDO SE IMPLEMENTE UNA COMPRA PUEDE TENER MAS 
-- DE UN PASAJE O ENCOMIENDA 
SET IDENTITY_INSERT THE_BTREES.Compra ON
INSERT INTO THE_BTREES.Compra
        ( CompraID ,
		  Compra_Fecha ,
          Compra_AbonaEnEfectivo ,
          Compra_CompradorRef
        )
SELECT DISTINCT C.CodigoCompra ,
				C.fechaCompra,
				1, --TODOS ABONAN EN EFECTIVO
				C.CompradorRef
FROM THE_BTREES.compra_con_ref C
SET IDENTITY_INSERT THE_BTREES.Compra OFF
GO


/************ INSERT PASAJES ****** 265646 PASAJES ********/
INSERT INTO THE_BTREES.Pasaje
        ( Pasaje_ClienteRef ,
          Pasaje_CompraRef ,
          Pasaje_Precio ,
          Pasaje_ButacaRef ,
          Pasaje_ViajeRef
        )  
SELECT DISTINCT (SELECT ClienteID FROM THE_BTREES.Cliente WHERE Cliente_DNI=M.Cli_Dni AND Cliente_Apellido=M.Cli_Apellido),
				M.Pasaje_Codigo,
				M.Pasaje_Precio,
				(SELECT ButacaID FROM THE_BTREES.Butaca WHERE Butaca_AvionRef=A.AvionID AND Butaca_Numero=M.Butaca_Nro), 
				V.ViajeID
FROM gd_esquema.Maestra M
INNER JOIN THE_BTREES.TipoServicio T ON T.TipoSer_Nombre=M.Tipo_Servicio
INNER JOIN THE_BTREES.Avion A ON M.Aeronave_Matricula=A.Avion_Matricula 
INNER JOIN (SELECT R.RutaAereaID,
				   R.Ruta_Codigo,
				   W.TipoServicioRef,
				   R.Ruta_CiudadOrigenRef
			FROM THE_BTREES.RutaAerea R
			INNER JOIN THE_BTREES.TipoServicioXRutaAerea W ON W.RutaAereaRef = R.RutaAereaID
			) B ON B.Ruta_Codigo=M.Ruta_Codigo AND B.TipoServicioRef=T.TipoServicioID 
			AND B.Ruta_CiudadOrigenRef=(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen)
INNER JOIN THE_BTREES.Viaje V ON V.Viaje_AvionRef=A.AvionID AND V.Viaje_FechaLlegada=M.FechaLLegada 
						  AND V.Viaje_RutaAereaRef=B.RutaAereaID
WHERE Pasaje_Codigo<>0 

/************ INSERT ENCOMIENDA ******* 135658 ENCOMIEDAS*******/

INSERT INTO THE_BTREES.Encomienda 
	(
		Enco_KG,
		Enco_Precio,
		Enco_CompraRef,
		Enco_ClienteRespRef,
		Enco_ViajeRef
	)
SELECT DISTINCT m.Paquete_KG,
				m.Paquete_Precio,
				M.Paquete_Codigo,
				(SELECT ClienteID FROM THE_BTREES.Cliente WHERE Cliente_DNI=M.Cli_Dni AND Cliente_Apellido=M.Cli_Apellido),
				V.ViajeID
FROM gd_esquema.Maestra M
INNER JOIN THE_BTREES.TipoServicio T ON T.TipoSer_Nombre=M.Tipo_Servicio
INNER JOIN THE_BTREES.Avion A ON M.Aeronave_Matricula=A.Avion_Matricula 
INNER JOIN (SELECT R.RutaAereaID,
				   R.Ruta_Codigo,
				   W.TipoServicioRef,
				   R.Ruta_CiudadOrigenRef
			FROM THE_BTREES.RutaAerea R
			INNER JOIN THE_BTREES.TipoServicioXRutaAerea W ON W.RutaAereaRef = R.RutaAereaID
			) B ON B.Ruta_Codigo=M.Ruta_Codigo AND B.TipoServicioRef=T.TipoServicioID 
			AND B.Ruta_CiudadOrigenRef=(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen)
INNER JOIN THE_BTREES.Viaje V ON V.Viaje_AvionRef=A.AvionID AND V.Viaje_FechaLlegada=M.FechaLLegada 
						 	  AND V.Viaje_RutaAereaRef=B.RutaAereaID
WHERE Paquete_Codigo<>0 

/************ INSERT Usuarios ******* *******/
BEGIN TRAN
INSERT INTO THE_BTREES.Funcionalidades (Funcionalidad_Nombre) VALUES 
	('ABM de Rol'),
	('Login y seguridad'),
	('Registro de Usuario'),
	('ABM de Ciudad'),
	('ABM de Ruta Aérea'),
	('ABM de Aeronave'),
	('Generación de Viaje'),
	('Registro de llegada a Destino'),
	('Compra de pasaje/encomienda'),
	('Devolución/Cancelación de pasaje y/o encomienda'),
	('Canje de millas'),
	('Consulta de millas de pasajero frecuente'),
	('Listado Estadístico')

INSERT INTO THE_BTREES.Roles (Rol_Nombre, Rol_Activo) VALUES 
	('Administrador General', 1),
	('Cliente', 1)

INSERT INTO THE_BTREES.Usuarios (Usuario_Nombre, Usuario_Password, Usuario_Intentos_Fallidos, Usuario_Activo) VALUES 
	('admin',  HASHBYTES('SHA2_256', N'w23e'), 0, 1)

INSERT INTO THE_BTREES.RolesXUsuarios (UsuarioRef, RolRef) VALUES 
	(1, 1)

INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, FuncionalidadRef) VALUES 
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(1, 5),
	(1, 6),
	(1, 7),
	(1, 8),
	(1, 9),
	(1, 10),
	(1, 11),
	(1, 12),
	(1, 13),
	(2, 1)
COMMIT TRAN
GO

