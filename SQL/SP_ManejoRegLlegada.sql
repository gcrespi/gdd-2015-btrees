/***** RegistrarLlegadaViaje *****/
IF  object_id(N'[THE_BTREES].[RegistrarLlegadaViaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[RegistrarLlegadaViaje]
GO

CREATE PROCEDURE [THE_BTREES].[RegistrarLlegadaViaje]		
	@AvionID int,
	@CiudadOrigen SMALLINT,
	@CiudadDestino SMALLINT,
	@FechaLlegada DATETIME,
	@Resultado VARCHAR(100) OUTPUT	
AS
    BEGIN
	   SET NOCOUNT ON

	   DECLARE @RutaAerea SMALLINT
	   DECLARE @DestinoReal SMALLINT
	  
	   SELECT @DestinoReal=R.Ruta_CiudadDestinoRef, @RutaAerea=RutaAereaID 
	   FROM THE_BTREES.Viaje V
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   WHERE V.Viaje_AvionRef=@AvionID AND V.Viaje_FechaSalida BETWEEN DATEADD(HOUR,-24,@FechaLlegada) AND @FechaLlegada 
			 AND R.Ruta_CiudadOrigenRef=@CiudadOrigen
	   
	   IF @DestinoReal IS NULL OR @RutaAerea IS NULL
			 BEGIN
			 SET @Resultado='No existe un viaje con los parametros ingresados'
			 RETURN
			 END
	   
	   UPDATE THE_BTREES.Viaje
	   SET Viaje_FechaLlegada=@FechaLlegada
	   WHERE Viaje_AvionRef=@AvionID AND Viaje_RutaAereaRef=@RutaAerea AND Viaje_FechaSalida BETWEEN DATEADD(HOUR,-24,@FechaLlegada) AND @FechaLlegada 

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