USE [GD2C2015]
GO

/***** AddCliente *****/
IF OBJECT_ID(N'[THE_BTREES].[AddCliente]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCliente]
GO

CREATE PROCEDURE [THE_BTREES].[AddCliente]
	@Cliente_DNI varchar(15),
	@Cliente_Nombre varchar(50),
	@Cliente_Apellido varchar(50),
	@Cliente_Direccion varchar(100),
	@Cliente_Telefono int,
	@Cliente_Mail varchar(100),
	@Cliente_FechaNac DateTime,
	@ClienteRef int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO THE_BTREES.Cliente(
			Cliente_DNI,
			Cliente_Nombre,
			Cliente_Apellido,
			Cliente_Direccion,
			Cliente_Telefono,
			Cliente_Mail,
			Cliente_FechaNac
		)
		VALUES (
 			 @Cliente_DNI,
 			 @Cliente_Nombre,
			 @Cliente_Apellido,
			 @Cliente_Direccion,
			 @Cliente_Telefono,
			 @Cliente_Mail,
			 @Cliente_FechaNac
		)	
		
		SET @ClienteRef = SCOPE_IDENTITY()
END		
GO

USE [GD2C2015]
GO

/***** UpdateCliente *****/
IF OBJECT_ID(N'[THE_BTREES].[UpdateCliente]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[UpdateCliente]
GO

CREATE PROCEDURE [THE_BTREES].[UpdateCliente]
	@ClienteID int,
	@Cliente_DNI varchar(15),
	@Cliente_Nombre varchar(50),
	@Cliente_Apellido varchar(50),
	@Cliente_Direccion varchar(100),
	@Cliente_Telefono int,
	@Cliente_Mail varchar(100),
	@Cliente_FechaNac DateTime	
AS
BEGIN
	SET NOCOUNT ON
	UPDATE THE_BTREES.Cliente 
	SET Cliente_DNI = @Cliente_DNI,
		Cliente_Nombre = @Cliente_Nombre,
		Cliente_Apellido = @Cliente_Apellido,
		Cliente_Direccion = @Cliente_Direccion,
		Cliente_Telefono = @Cliente_Telefono,
		Cliente_Mail = @Cliente_Mail,
		Cliente_FechaNac = @Cliente_FechaNac
	WHERE ClienteID = @ClienteID
END		
GO