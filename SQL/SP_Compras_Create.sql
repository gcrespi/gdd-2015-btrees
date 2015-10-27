USE [GD2C2015]
GO

/***** AddCompra *****/
IF OBJECT_ID(N'[THE_BTREES].[AddCompra]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCompra]
GO

CREATE PROCEDURE [THE_BTREES].[AddCompra]
	@efectivo AS bit,
	@cantCuotas AS tinyint,
	@tipoTarjeta AS int,
	@dni AS int,
	@nombre AS varchar(50),
	@apellido AS varchar(50),
	@direccion AS varchar(100),
	@telefono AS varchar(50),
	@mail AS varchar(100),
	@fechaNac AS datetime,
	@numTarjeta AS varchar(20),
	@codSeg AS int,
	@fechaVenc AS datetime,
	@compraID int OUTPUT
AS
	BEGIN
		SET NOCOUNT ON
		INSERT INTO THE_BTREES.Compra (
			Compra_Fecha,
			Compra_AbonaEnEfectivo,
			Compra_CantCuotas,
			Compra_TipoTarjetaRef,
			Compra_DNIComprador,
			Compra_Nombre,
			Compra_Apellido,
			Compra_Direccion,
			Compra_Telefono,
			Compra_Mail,
			Compra_FechaNac,
			Compra_NumTarjeta,
			Compra_CodSeg,
			Compra_FechaVencimiento
		)
		VALUES (
			CAST(GETDATE() AS date),
			@efectivo,
			@cantCuotas,
			@tipoTarjeta,
			@dni,
			@nombre,
			@apellido,
			@direccion,
			@telefono,
			@mail,
			@fechaNac,
			@numTarjeta,
			@codSeg,
			@fechaVenc
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
	@clienteRef AS int,
	@viajeRef AS int
AS 
	SET NOCOUNT ON
	BEGIN
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
			@clienteRef,
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
	@butacaRef AS int,
	@precio AS numeric(18,2),
	@compraRef AS int,
	@clienteRef AS int,
	@viajeRef AS int
AS 
	SET NOCOUNT ON
	BEGIN
		INSERT INTO THE_BTREES.Pasaje (
			Pasaje_ButacaRef,
			Pasaje_Precio,
			Pasaje_CompraRef,
			Pasaje_ClienteRef,
			Pasaje_ViajeRef
		)
		VALUES (
			@butacaRef,
			@precio,
			@compraRef,
			@clienteRef,
			@viajeRef
		)
	END
GO