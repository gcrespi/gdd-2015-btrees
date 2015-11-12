/***** GetProductosDisponibles *****/
IF  object_id(N'[THE_BTREES].[GetProductosDisponibles]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetProductosDisponibles]
GO

CREATE PROCEDURE [THE_BTREES].[GetProductosDisponibles]		
	@CantMillas int
AS
    BEGIN
	   SET NOCOUNT ON

	   SELECT ProductoID,
			  Producto_Descripcion,
		      Producto_Stock,
			  Producto_Millas			   
	   FROM THE_BTREES.Producto
	   WHERE Producto_Millas<=@CantMillas AND Producto_Stock>0
	
	   END
GO

/***** AddCanjeProducto *****/
IF  object_id(N'[THE_BTREES].[AddCanjeProducto]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCanjeProducto]
GO

CREATE PROCEDURE [THE_BTREES].[AddCanjeProducto]
	@ClienteID INT,
	@ProductoID INT,
	@MillasCanje INT,
	@CantProducto INT,
	@Fecha DATETIME 		
AS
    BEGIN
	   SET NOCOUNT ON

	   INSERT INTO THE_BTREES.Canje
	           ( Canje_ClienteRef ,
	             Canje_ProductoRef ,
	             Canje_CantidadProducto ,
	             Canje_Fecha
	           )
	   VALUES  ( @ClienteID,
	             @ProductoID , 
	             @CantProducto , 
	             @Fecha
	           )
	   
		DECLARE @CanjeID INT
		SET @CanjeID=SCOPE_IDENTITY()

		UPDATE THE_BTREES.Producto
		SET Producto_Stock=Producto_Stock-@CantProducto
		WHERE ProductoID=@ProductoID

		INSERT INTO THE_BTREES.TransaccionesMillas
		        ( Tran_CanjeRef ,
		          Tran_ClienteRef ,
		          Tran_EncomiendaRef ,
		          Tran_PasajeRef ,
		          Tran_CantidadMillas ,
		          Tran_Fecha
		        )
		VALUES  ( @CanjeID , 
		          @ClienteID , 
		          NULL , 
		          NULL , 
		          @MillasCanje ,
				  @Fecha
		        )	
	   END
GO