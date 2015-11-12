/***** RegistrarLlegadaViaje *****/
IF  object_id(N'[THE_BTREES].[RegistrarLlegadaViaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[RegistrarLlegadaViaje]
GO

CREATE PROCEDURE [THE_BTREES].[RegistrarLlegadaViaje]		
	@AvionID int,
	@CiudadOrigen SMALLINT,
	@CiudadDestino SMALLINT,
	@FechaLlegada DATETIME,
	@FechaActual DATETIME,
	@Resultado VARCHAR(100) OUTPUT	
AS
    BEGIN
	   SET NOCOUNT ON

	   DECLARE @RutaAerea SMALLINT
	   DECLARE @DestinoReal SMALLINT
	   DECLARE @ViajeID INT
	   DECLARE @FechaLlegadatab DATETIME
	  
	   SELECT @DestinoReal=R.Ruta_CiudadDestinoRef, @RutaAerea=RutaAereaID, @ViajeID=V.ViajeID, @FechaLlegadatab=v.Viaje_FechaLlegada 
	   FROM THE_BTREES.Viaje V
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   WHERE V.Viaje_AvionRef=@AvionID AND V.Viaje_FechaSalida BETWEEN DATEADD(HOUR,-24,@FechaLlegada) AND @FechaLlegada 
			 AND R.Ruta_CiudadOrigenRef=@CiudadOrigen
	   
	   IF @DestinoReal IS NULL OR @RutaAerea IS NULL
			 BEGIN
			 SET @Resultado='No existe un viaje con los parametros ingresados'
			 RETURN
			 END

	   IF @FechaLlegadatab IS NOT NULL
		BEGIN
		SET @Resultado='La llegada del viaje ya se encontraba registrada'
		RETURN
		END
	   
	   UPDATE THE_BTREES.Viaje
	   SET Viaje_FechaLlegada=@FechaLlegada
	   WHERE ViajeID=@ViajeID

	   INSERT INTO THE_BTREES.TransaccionesMillas
	   ( Tran_CanjeRef ,Tran_ClienteRef ,Tran_EncomiendaRef ,Tran_PasajeRef ,Tran_CantidadMillas ,Tran_Fecha)
	   SELECT NULL, Pasaje_ClienteRef,NULL,PasajeID,CAST(CAST(Pasaje_Precio AS FLOAT)/10 AS INT),@FechaActual 
	   FROM THE_BTREES.Pasaje P
	   WHERE P.Pasaje_ViajeRef=@ViajeID

	   INSERT INTO THE_BTREES.TransaccionesMillas
	   ( Tran_CanjeRef ,Tran_ClienteRef ,Tran_EncomiendaRef ,Tran_PasajeRef ,Tran_CantidadMillas ,Tran_Fecha)
	   SELECT NULL, E.Enco_ClienteRespRef,E.EncomiendaID,NULL,CAST(CAST(Enco_Precio AS FLOAT)/10 AS INT),@FechaActual 
	   FROM THE_BTREES.Encomienda E
	   WHERE E.Enco_ViajeRef=@ViajeID
	   
	   IF @CiudadDestino=@DestinoReal
			BEGIN
			SET @Resultado='El avion arribo a la ciudad que le correspondía'
			END
		ELSE
			BEGIN
			SET @Resultado= 'El avión arribo a una ciudad erronea. Debia llegar a ' + (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=@DestinoReal)
			END
		
	   END
GO