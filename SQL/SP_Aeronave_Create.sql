USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[AutoCrear_Butacas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].AutoCrear_Butacas
GO

CREATE PROCEDURE THE_BTREES.AutoCrear_Butacas
	@AvionID INT,
	@Butacas_Pasillo INT,
	@Butacas_Ventana INT
AS
	BEGIN TRAN
	DECLARE @Butaca_nro INT
	SET @Butaca_nro = 1
	DECLARE @VALUES1 NVARCHAR(MAX)
	
	SET @VALUES1 = '(' + CAST(@AvionID AS NVARCHAR) + ',0,0)'
	WHILE @Butacas_Pasillo > @Butaca_nro
	BEGIN
		SET @VALUES1 = @VALUES1 + ',(' + CAST(@AvionID AS NVARCHAR) + ',' + CAST(@Butaca_nro AS NVARCHAR) + ',0)'
		SET @Butaca_nro = @Butaca_nro + 1;
	END;

	DECLARE @LastPasillo INT
	SET @LastPasillo = @Butaca_nro
	SET @Butaca_nro = 0
	DECLARE @VALUES2 NVARCHAR(MAX)
	SET @VALUES2 = ''
	WHILE @Butacas_Ventana > @Butaca_nro
	BEGIN
		SET @VALUES2 = @VALUES2 + ',(' + CAST(@AvionID AS NVARCHAR) + ',' + CAST(@Butaca_nro + @LastPasillo AS NVARCHAR) + ',1)'
		SET @Butaca_nro = @Butaca_nro + 1;
	END;

	EXEC ('INSERT INTO THE_BTREES.Butaca (Butaca_AvionRef, Butaca_Numero, Butaca_EsVentanilla) VALUES ' + @VALUES1 + @VALUES2)
	COMMIT TRAN
GO


IF  object_id(N'[THE_BTREES].[Listar_Aviones]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].Listar_Aviones
GO

create PROCEDURE [THE_BTREES].Listar_Aviones
	( @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia=
	'SELECT DISTINCT a.AvionID, a.Avion_Matricula, a.Avion_Fabricante, a.Avion_Modelo, s.TipoSer_Nombre, COUNT(*) Butacas, a.Avion_CantidadKgsDisponibles,
				a.Avion_FechaDeAlta, a.Avion_BajaPorFueraDeServicio, a.Avion_BajaPorVidaUtil, a.Avion_FechaDeBajaDefinitiva
	FROM THE_BTREES.Avion a
		JOIN THE_BTREES.Butaca b ON a.AvionID = b.Butaca_AvionRef 
		JOIN THE_BTREES.TipoServicio s ON a.Avion_TipoDeServicioRef = s.TipoServicioID '  + @WhereClause + 
	'GROUP BY a.AvionID, a.Avion_Matricula, a.Avion_Modelo, a.Avion_Fabricante, s.TipoSer_Nombre, a.Avion_CantidadKgsDisponibles,
			a.Avion_FechaDeAlta, a.Avion_BajaPorFueraDeServicio, a.Avion_BajaPorVidaUtil, a.Avion_FechaDeBajaDefinitiva'
	execute (@sentencia)
GO


IF  object_id(N'[THE_BTREES].[Crear_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].Crear_Avion
GO

CREATE PROCEDURE THE_BTREES.Crear_Avion
	@Avion_FechaDeAlta DATE, 
	@Avion_Modelo NVARCHAR(255), 
	@Avion_Matricula NVARCHAR(255), 
	@Avion_Fabricante NVARCHAR(255), 
	@Avion_TipoDeServicioRef TINYINT, 
	@Avion_CantidadKgsDisponibles NUMERIC(18,0),
	@Butacas_Pasillo INT,
	@Butacas_Ventana INT
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.Avion (Avion_FechaDeAlta, Avion_Modelo, Avion_Matricula, Avion_Fabricante, Avion_TipoDeServicioRef, Avion_BajaPorFueraDeServicio,
								Avion_BajaPorVidaUtil, Avion_FechaDeBajaDefinitiva, Avion_CantidadKgsDisponibles) VALUES 
		(@Avion_FechaDeAlta, @Avion_Modelo, @Avion_Matricula, @Avion_Fabricante, @Avion_TipoDeServicioRef, 0, 0, NULL, @Avion_CantidadKgsDisponibles)
	
	DECLARE @AvionID INT
	SET @AvionID = SCOPE_IDENTITY()

	EXEC THE_BTREES.AutoCrear_Butacas @AvionID, @Butacas_Pasillo, @Butacas_Ventana;
	COMMIT TRAN
GO

IF  object_id(N'[THE_BTREES].[NotInBetween24h]','fn') IS NOT NULL
	DROP FUNCTION [THE_BTREES].[NotInBetween24h]
GO

CREATE FUNCTION [THE_BTREES].[NotInBetween24h]
	(@fecha datetime, @AvionID int)
	RETURNS BIT
AS
BEGIN
	DECLARE @Fecha24 datetime
	DECLARE cursorFechas CURSOR FOR SELECT v.Viaje_FechaSalida FROM THE_BTREES.Viaje v WHERE v.Viaje_AvionRef = @AvionID
	OPEN cursorFechas
	FETCH NEXT FROM cursorFEchas INTO @Fecha24	

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @fecha BETWEEN @Fecha24-24 AND @Fecha24+24 RETURN 0
		FETCH NEXT FROM cursorFEchas 
		INTO @Fecha24
	END
	RETURN 1
END
GO


IF  object_id(N'[THE_BTREES].[VerificarSiHayAvionParaReemplazar]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[VerificarSiHayAvionParaReemplazar]
GO

CREATE PROCEDURE [THE_BTREES].[VerificarSiHayAvionParaReemplazar]
	@AvionAReemplazarID int,
	@FechaActual datetime,
	@AvionCandidatoID int OUTPUT
AS
BEGIN
	SET @AvionCandidatoID = 0
	SELECT TOP 1 @AvionCandidatoID = a.AvionID
	FROM THE_BTREES.Avion a 
	WHERE a.AvionID != @AvionAReemplazarID
	  AND a.Avion_Modelo=(SELECT r.Avion_Modelo FROM THE_BTREES.Avion r WHERE r.AvionID=@AvionAReemplazarID) 
	  AND a.Avion_Fabricante=(SELECT r.Avion_Fabricante FROM THE_BTREES.Avion r WHERE r.AvionID=@AvionAReemplazarID)
	  AND a.Avion_TipoDeServicioRef=(SELECT r.Avion_TipoDeServicioRef FROM THE_BTREES.Avion r WHERE r.AvionID=@AvionAReemplazarID)  
	  AND (SELECT COUNT(*) FROM THE_BTREES.Viaje v WHERE v.Viaje_AvionRef=@AvionAReemplazarID AND v.Viaje_FechaSalida>@FechaActual) = 
		  (SELECT COUNT(*)
		   FROM THE_BTREES.Viaje v2 
		   WHERE v2.Viaje_AvionRef=@AvionAReemplazarID
			 AND v2.Viaje_FechaSalida>@FechaActual
	         AND THE_BTREES.NotInBetween24h(v2.Viaje_FechaSalida, a.AvionID) = 1)
END
GO

IF  object_id(N'[THE_BTREES].[DarDeBaja_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarDeBaja_Avion
GO

CREATE PROCEDURE THE_BTREES.DarDeBaja_Avion
	@AvionID INT,
	@Avion_FechaDeBajaDefinitiva DATE,
	@AvionATranspasar INT
AS
BEGIN	
	DECLARE @CompraID int,
			@CancelacionRef int

	DECLARE cursorCancelacion CURSOR FOR SELECT DISTINCT c.CompraID 
										 FROM THE_BTREES.Compra c 
										 INNER JOIN (
													 SELECT p.Pasaje_CompraRef AS CompreRef
													 FROM THE_BTREES.Pasaje p INNER JOIN THE_BTREES.Viaje v ON p.Pasaje_ViajeRef=v.ViajeID
									   				 WHERE v.Viaje_AvionRef=@AvionID AND v.Viaje_FechaSalida>@Avion_FechaDeBajaDefinitiva
													 UNION
													 SELECT e.Enco_CompraRef AS ComprRef  
													 FROM THE_BTREES.Encomienda e INNER JOIN THE_BTREES.Viaje v ON e.Enco_ViajeRef=v.ViajeID
									   				 WHERE v.Viaje_AvionRef=@AvionID AND v.Viaje_FechaSalida>@Avion_FechaDeBajaDefinitiva
													 ) r
									     ON c.CompraID = r.CompreRef

	BEGIN TRAN
	OPEN cursorCancelacion
	FETCH NEXT FROM cursorCancelacion INTO @CompraID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO THE_BTREES.Cancelacion 
		(
			Cance_CompraRef,Cance_Fecha,Motivo
		)
		VALUES
		(
			@CompraID,@Avion_FechaDeBajaDefinitiva,'Baja de la Ruta Aerea asignada.'
		)
		SET @CancelacionRef = SCOPE_IDENTITY()
		
		UPDATE THE_BTREES.Pasaje
		SET Pasaje_CancelacionRef=@CancelacionRef 
		WHERE Pasaje_CompraRef=@CompraID

		UPDATE THE_BTREES.Encomienda
		SET Enco_CancelacionRef=@CancelacionRef
		WHERE Enco_CompraRef=@CompraID

		FETCH NEXT FROM cursorCancelacion INTO @CompraID
	END

	IF @AvionATranspasar IS NOT NULL
	BEGIN
		UPDATE THE_BTREES.Viaje 
		SET Viaje_AvionRef=@AvionATranspasar
		WHERE Viaje_AvionRef=@AvionID AND Viaje_FechaSalida>@Avion_FechaDeBajaDefinitiva
	END

	UPDATE THE_BTREES.Avion SET Avion_BajaPorVidaUtil = 1, @Avion_FechaDeBajaDefinitiva = Avion_FechaDeBajaDefinitiva WHERE @AvionID = AvionID

	COMMIT TRAN
END
GO


IF  object_id(N'[THE_BTREES].[Modificar_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].Modificar_Avion
GO

CREATE PROCEDURE THE_BTREES.Modificar_Avion
	@AvionID INT,
	@Avion_FechaDeAlta DATE, 
	@Avion_Modelo NVARCHAR(255), 
	@Avion_Matricula NVARCHAR(255), 
	@Avion_Fabricante NVARCHAR(255), 
	@Avion_TipoDeServicioRef TINYINT, 
	@Avion_CantidadKgsDisponibles NUMERIC(18,0),
	@Butacas_Pasillo INT,
	@Butacas_Ventana INT
AS

	BEGIN TRAN
	UPDATE THE_BTREES.Avion SET Avion_FechaDeAlta = @Avion_FechaDeAlta , Avion_Modelo = @Avion_Modelo, Avion_Matricula = @Avion_Matricula, Avion_Fabricante = @Avion_Fabricante,
								Avion_TipoDeServicioRef = @Avion_TipoDeServicioRef,
								Avion_CantidadKgsDisponibles = @Avion_CantidadKgsDisponibles
	WHERE @AvionID = AvionID

	DELETE FROM THE_BTREES.Butaca WHERE @AvionID = Butaca_AvionRef

	EXEC THE_BTREES.AutoCrear_Butacas @AvionID, @Butacas_Pasillo, @Butacas_Ventana;
	COMMIT TRAN
GO



IF  object_id(N'[THE_BTREES].[TraerAvionConServicioYButacas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].TraerAvionConServicioYButacas
GO

CREATE PROCEDURE THE_BTREES.TraerAvionConServicioYButacas
	@AvionID INT
AS
	SELECT TOP 1 AvionID, Avion_Matricula, Avion_Fabricante, Avion_Modelo, Avion_TipoDeServicioRef, Avion_FechaDeAlta, 
				(SELECT COUNT(*) FROM THE_BTREES.Butaca WHERE @AvionID = Butaca_AvionRef AND Butaca_EsVentanilla = 0) Butacas_Pasillo, 
				(SELECT COUNT(*) FROM THE_BTREES.Butaca WHERE @AvionID = Butaca_AvionRef AND Butaca_EsVentanilla = 1) Butacas_Ventanilla, 
				Avion_CantidadKgsDisponibles, Avion_BajaPorVidaUtil, Avion_BajaPorFueraDeServicio
	FROM THE_BTREES.Avion WHERE @AvionID = AvionID
GO

IF  object_id(N'[THE_BTREES].[TraerUltimoFueraDeServicioAvion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].TraerUltimoFueraDeServicioAvion
GO

CREATE PROCEDURE THE_BTREES.TraerUltimoFueraDeServicioAvion
	@AvionID INT
AS
	SELECT TOP 1 Fuera_FechaFuera, FueraDeServicioId
	FROM THE_BTREES.FueraDeServicio WHERE @AvionID = Fuera_AvionRef
	ORDER BY Fuera_FechaFuera DESC
GO


IF  object_id(N'[THE_BTREES].[DarFueraServicio_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarFueraServicio_Avion
GO

CREATE PROCEDURE THE_BTREES.DarFueraServicio_Avion
	@AvionID INT,
	@Avion_FechaFueraServicio DATE
AS
	BEGIN TRAN
		UPDATE THE_BTREES.Avion SET Avion_BajaPorFueraDeServicio = 1 WHERE @AvionID = AvionID
		INSERT INTO THE_BTREES.FueraDeServicio (Fuera_AvionRef, Fuera_FechaFuera) VALUES (@AvionID, @Avion_FechaFueraServicio)
	COMMIT TRAN
GO


IF  object_id(N'[THE_BTREES].[DarReinicioServicio_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarReinicioServicio_Avion
GO

CREATE PROCEDURE THE_BTREES.DarReinicioServicio_Avion
	@AvionID INT,
	@Avion_FechaReinicioServicio DATE,
	@FueraDeServicioId INT
AS
	BEGIN TRAN
		UPDATE THE_BTREES.Avion SET Avion_BajaPorFueraDeServicio = 0 WHERE @AvionID = AvionID
		UPDATE THE_BTREES.FueraDeServicio SET Fuera_FechaVuelta = @Avion_FechaReinicioServicio WHERE FueraDeServicioId = @FueraDeServicioId
	COMMIT TRAN
GO
