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


IF  object_id(N'[THE_BTREES].[DarDeBaja_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarDeBaja_Avion
GO

CREATE PROCEDURE THE_BTREES.DarDeBaja_Avion
	@AvionID INT,
	@Avion_FechaDeBajaDefinitiva DATE
AS
	UPDATE THE_BTREES.Avion SET Avion_BajaPorVidaUtil = 1, @Avion_FechaDeBajaDefinitiva = Avion_FechaDeBajaDefinitiva WHERE @AvionID = AvionID
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
				Avion_CantidadKgsDisponibles, Avion_BajaPorVidaUtil
	FROM THE_BTREES.Avion WHERE @AvionID = AvionID
GO
