USE [GD2C2015]
GO

/***** GetPasajesDeCompraList *****/
IF  object_id(N'[THE_BTREES].[GetPasajesDeCompraList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetPasajesDeCompraList]
GO

CREATE PROCEDURE [THE_BTREES].[GetPasajesDeCompraList]		
    @CompraID AS INT
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT P.PasajeID AS 'Codigo de Pasaje',
			  (SELECT Cliente_Nombre FROM THE_BTREES.Cliente WHERE ClienteID=P.Pasaje_ClienteRef) AS Cliente,
			  (SELECT Butaca_Numero FROM THE_BTREES.Butaca WHERE ButacaID=P.Pasaje_ButacaRef) AS 'Numero de Butaca',
			  P.Pasaje_Precio AS Precio
	   FROM THE_BTREES.Pasaje P
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef 
	   WHERE P.Pasaje_CompraRef=@CompraID AND P.Pasaje_CancelacionRef IS NULL AND V.Viaje_FechaSalida>GETDATE()
	   ORDER BY P.PasajeID
	   END
GO

USE [GD2C2015]
GO

/***** GetEncomiendaKGCompra *****/
IF  object_id(N'[THE_BTREES].[GetEncomiendaKGCompra]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetEncomiendaKGCompra]
GO

CREATE PROCEDURE [THE_BTREES].[GetEncomiendaKGCompra]		
    @CompraID AS INT,
	@CantKg AS SMALLINT OUTPUT
	
AS
    BEGIN
	   SET NOCOUNT ON	
	   
	   DECLARE @kg SMALLINT
	   SELECT @kg=E.Enco_KG
	   FROM THE_BTREES.Encomienda E
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = E.Enco_ViajeRef 
	   WHERE E.Enco_CompraRef=@CompraID AND Enco_CancelacionRef IS NULL AND V.Viaje_FechaSalida>GETDATE()

	   SELECT @CantKg=ISNULL(@kg,0)
	   
	   END
GO

/***** AddCancelacion *****/
IF  object_id(N'[THE_BTREES].[AddCancelacion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCancelacion]
GO

CREATE PROCEDURE [THE_BTREES].[AddCancelacion]		
    @CancelID AS INT OUTPUT,
	@CompraID AS INT,
	@Motivo AS VARCHAR(50),
	@CancelEco bit
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   INSERT INTO THE_BTREES.Cancelacion
	           ( Cance_CompraRef ,
	             Cance_Fecha ,
	             Motivo
	           )
	   VALUES  ( @CompraID,
	             GETDATE(),
	             @Motivo
	           )
	   
	   SET @CancelID=SCOPE_IDENTITY()

	   IF @CancelEco=1
		 BEGIN
			UPDATE THE_BTREES.Encomienda
			SET Enco_CancelacionRef=@CancelID
			WHERE Enco_CompraRef=@CompraID
		 RETURN
		 END		   
	   END
GO

/***** CancelarPasaje *****/
IF  object_id(N'[THE_BTREES].[CancelarPasaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[CancelarPasaje]
GO

CREATE PROCEDURE [THE_BTREES].[CancelarPasaje]		
    @CancelID AS INT,
	@PasajeID AS INT
	
AS
    BEGIN
	   SET NOCOUNT ON	

    	UPDATE THE_BTREES.Pasaje
	    SET Pasaje_CancelacionRef=@CancelID
	    WHERE PasajeID=@PasajeID
  
	   END
GO