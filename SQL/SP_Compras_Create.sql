USE [GD2C2015]
GO

CREATE TYPE [THE_BTREES].[ClienteDT] AS TABLE
(
    ClienteID int,
    Cliente_DNI varchar(15),
    Cliente_Nombre varchar(50),
	Cliente_Apellido varchar(50),
    Cliente_Direccion varchar(100),
    Cliente_Telefono int,
    Cliente_Mail varchar(100),
    Cliente_FechaNac DateTime
)

CREATE TYPE [THE_BTREES].[PasajeroDT] AS TABLE
(
    ClienteID int,
    Cliente_DNI varchar(15),
    Cliente_Nombre varchar(50),
	Cliente_Apellido varchar(50),
    Cliente_Direccion varchar(100),
    Cliente_Telefono int,
    Cliente_Mail varchar(100),
    Cliente_FechaNac DateTime,
	ButacaRef int
)

/***** AddCompra *****/
IF OBJECT_ID(N'[THE_BTREES].[AddCompra]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCompra]
GO

CREATE PROCEDURE [THE_BTREES].[AddCompra]
	@efectivo AS bit,
	@cantCuotas AS tinyint = NULL,
	@tipoTarjeta AS int = NULL,
	@numTarjeta AS varchar(20) = NULL,
	@codSeg AS int = NULL,
	@fechaVenc AS datetime = NULL,
	@dtComprador THE_BTREES.ClienteDT READONLY,
	@compraID int OUTPUT
AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @ClienteID int,
				@Cliente_DNI varchar(15),
				@Cliente_Nombre varchar(50),
				@Cliente_Apellido varchar(50),
				@Cliente_Direccion varchar(100),
				@Cliente_Telefono int,
				@Cliente_Mail varchar(100),
				@Cliente_FechaNac DateTime

		SET @ClienteID = (SELECT ClienteID FROM @dtComprador)
		SET	@Cliente_DNI = (SELECT Cliente_DNI FROM @dtComprador)
		SET	@Cliente_Nombre = (SELECT Cliente_Nombre FROM @dtComprador)
		SET	@Cliente_Apellido = (SELECT Cliente_Apellido FROM @dtComprador)
		SET	@Cliente_Direccion = (SELECT Cliente_Direccion FROM @dtComprador)
		SET	@Cliente_Telefono = (SELECT Cliente_Telefono FROM @dtComprador)
		SET	@Cliente_Mail = (SELECT Cliente_Mail FROM @dtComprador)
		SET	@Cliente_FechaNac = (SELECT Cliente_FechaNac FROM @dtComprador)

		IF @ClienteID = 0
			EXEC THE_BTREES.AddCliente
				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac,
				@ClienteRef = @ClienteID OUTPUT
		ELSE
			EXEC THE_BTREES.UpdateCliente
				@ClienteID,
 				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac

		INSERT INTO THE_BTREES.Compra (
			Compra_Fecha,
			Compra_AbonaEnEfectivo,
			Compra_CantCuotas,
			Compra_TipoTarjetaRef,
			Compra_NumTarjeta,
			Compra_CodSeg,
			Compra_FechaVencimiento,
			Compra_CompradorRef
		)
		VALUES (
			CAST(GETDATE() AS date),
			@efectivo,
			@cantCuotas,
			@tipoTarjeta,
			@numTarjeta,
			@codSeg,
			@fechaVenc,
			@ClienteID
		)	
		
		SET @compraID = SCOPE_IDENTITY()

	END
GO

USE [GD2C2015]
GO

/***** AddEncomienda *****/
IF OBJECT_ID(N'[THE_BTREES].[AddEncomienda]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddEncomienda]
GO

CREATE PROCEDURE [THE_BTREES].[AddEncomienda]
	@kg AS smallint,
	@precio AS numeric(18,2),
	@compraRef AS int,
	@viajeRef AS int,
	@dtResponsable AS THE_BTREES.ClienteDT READONLY
AS 
	SET NOCOUNT ON
	BEGIN
		DECLARE @ClienteID int,
				@Cliente_DNI varchar(15),
				@Cliente_Nombre varchar(50),
				@Cliente_Apellido varchar(50),
				@Cliente_Direccion varchar(100),
				@Cliente_Telefono int,
				@Cliente_Mail varchar(100),
				@Cliente_FechaNac DateTime

		SET @ClienteID = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_DNI = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Nombre = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Apellido = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Direccion = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Telefono = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Mail = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_FechaNac = (SELECT ClienteID FROM @dtResponsable)

		IF @ClienteID = 0
			EXEC THE_BTREES.AddCliente
				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac,
				@ClienteRef = @ClienteID OUTPUT
		ELSE
			EXEC THE_BTREES.UpdateCliente
				@ClienteID,
 				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac

		INSERT INTO THE_BTREES.Encomienda (
			Enco_KG,
			Enco_Precio,
			Enco_CompraRef,
			Enco_ClienteRespRef,
			Enco_ViajeRef
		)
		VALUES (
			@kg,
			@precio,
			@compraRef,
			@ClienteID,
			@viajeRef
		)
	END
GO

USE [GD2C2015]
GO

/***** AddPasaje *****/
IF OBJECT_ID(N'[THE_BTREES].[AddPasaje]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddPasaje]
GO

CREATE PROCEDURE [THE_BTREES].[AddPasaje]
	@precio AS numeric(18,2),
	@compraRef AS int,
	@viajeRef AS int,
	@dtPasajeros AS THE_BTREES.PasajeroDT READONLY
AS 
	SET NOCOUNT ON
	BEGIN
		DECLARE @ClienteID int,
				@Cliente_DNI varchar(15),
				@Cliente_Nombre varchar(50),
				@Cliente_Apellido varchar(50),
				@Cliente_Direccion varchar(100),
				@Cliente_Telefono int,
				@Cliente_Mail varchar(100),
				@Cliente_FechaNac DateTime,
				@ButacaRef int
		DECLARE psj_cursor CURSOR FOR SELECT * FROM @dtPasajeros
		OPEN psj_cursor

		FETCH NEXT FROM psj_cursor 
		INTO @ClienteID,
 			 @Cliente_DNI,
 			 @Cliente_Nombre,
			 @Cliente_Apellido,
			 @Cliente_Direccion,
			 @Cliente_Telefono,
			 @Cliente_Mail,
			 @Cliente_FechaNac,
			 @ButacaRef

		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @ClienteID = 0
				EXEC THE_BTREES.AddCliente
					@Cliente_DNI,
 					@Cliente_Nombre,
					@Cliente_Apellido,
					@Cliente_Direccion,
					@Cliente_Telefono,
					@Cliente_Mail,
					@Cliente_FechaNac,
					@ClienteRef = @ClienteID OUTPUT
			ELSE
				EXEC THE_BTREES.UpdateCliente
					@ClienteID,
 					@Cliente_DNI,
 					@Cliente_Nombre,
					@Cliente_Apellido,
					@Cliente_Direccion,
					@Cliente_Telefono,
					@Cliente_Mail,
					@Cliente_FechaNac

			INSERT INTO THE_BTREES.Pasaje (
				Pasaje_ButacaRef,
				Pasaje_Precio,
				Pasaje_CompraRef,
				Pasaje_ClienteRef,
				Pasaje_ViajeRef
			)
			VALUES (
				@ButacaRef,
				@precio,
				@compraRef,
				@ClienteID,
				@viajeRef
			)

			FETCH NEXT FROM psj_cursor 
			INTO @ClienteID,
 				 @Cliente_DNI,
 				 @Cliente_Nombre,
				 @Cliente_Apellido,
				 @Cliente_Direccion,
				 @Cliente_Telefono,
				 @Cliente_Mail,
				 @Cliente_FechaNac,
				 @ButacaRef
		END
		
		CLOSE psj_cursor;
		DEALLOCATE psj_cursor;	
	END
GO