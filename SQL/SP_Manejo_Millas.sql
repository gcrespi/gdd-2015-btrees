USE GD2C2015
GO

/***** AddTranMillas *****/
IF OBJECT_ID(N'[THE_BTREES].[AddTranMillas]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddTranMillas]
GO

CREATE PROCEDURE [THE_BTREES].[AddTranMillas]
	@Tran_CanjeRef int,
	@Tran_ClienteRef int,
	@Tran_EncomiendaRef	int,
	@Tran_PasajeRef	int,
	@CantidadMillas int,
	@Fecha datetime
AS
BEGIN
	INSERT INTO THE_BTREES.TransaccionesMillas 
	( 
		Tran_CanjeRef,
		Tran_ClienteRef,
		Tran_EncomiendaRef,
		Tran_PasajeRef,
		Tran_CantidadMillas,
		Tran_Fecha
	)
	VALUES
	(
		@Tran_CanjeRef,
		@Tran_ClienteRef,
		@Tran_EncomiendaRef,
		@Tran_PasajeRef,
		@CantidadMillas,
		@Fecha
	)
END
GO

USE GD2C2015
GO

/***** GetCantMillasDisponibles *****/
IF OBJECT_ID(N'[THE_BTREES].[GetCantMillasDisponibles]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetCantMillasDisponibles]
GO

CREATE PROCEDURE [THE_BTREES].[GetCantMillasDisponibles]
	@Apellido varchar(50), 
	@DNI int,
	@Fecha datetime,
	@ClienteRef int OUTPUT,
	@CantMillasDisponibles int OUTPUT
AS
BEGIN
	SELECT @ClienteRef=ClienteID FROM THE_BTREES.Cliente 
	WHERE Cliente_Apellido=@Apellido AND Cliente_DNI=@DNI
	
	DECLARE 
		@Tran_CanjeRef int,
		@CantidadMillas int,
		@Tran_Fecha datetime,
		@CantidadMillasDisponibles int		

	DECLARE cursorTrans CURSOR FOR SELECT M.Tran_CanjeRef, M.Tran_CantidadMillas, M.Tran_Fecha
									FROM THE_BTREES.TransaccionesMillas M
									WHERE M.Tran_ClienteRef = @ClienteRef
	OPEN cursorTrans

	FETCH NEXT FROM cursorTrans
	INTO 
		@Tran_CanjeRef,
		@CantidadMillas,
		@Tran_Fecha

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF DATEDIFF(day,@Tran_Fecha,@Fecha) < 365
		BEGIN
			IF @Tran_CanjeRef IS NULL
			BEGIN
				SET @CantidadMillasDisponibles = @CantidadMillasDisponibles + @CantidadMillas
			END
			ELSE
			BEGIN
				SET @CantidadMillasDisponibles = @CantidadMillasDisponibles - @CantidadMillas
			END
		END

		FETCH NEXT FROM cursorTrans
		INTO 
			@Tran_CanjeRef,
			@CantidadMillas,
			@Tran_Fecha
	END

END