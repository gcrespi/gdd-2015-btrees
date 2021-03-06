USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[Deshabilitar_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Deshabilitar_Rol]
GO

IF  object_id(N'[THE_BTREES].[Modificar_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Modificar_Rol]
GO

IF  object_id(N'[THE_BTREES].[Crear_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Crear_Rol]
GO

IF TYPE_ID(N'[THE_BTREES].[IntList]') IS NOT NULL
	DROP TYPE [THE_BTREES].[IntList]
GO



CREATE TYPE [THE_BTREES].[IntList] AS TABLE(
    [Item] [INT] NOT NULL
)
GO

CREATE PROCEDURE THE_BTREES.Crear_Rol
	@Rol_Nombre VARCHAR(60),
	@Rol_Activo BIT,
	@funcionalidadesSeleccionadas [THE_BTREES].[IntList] READONLY
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.Roles (Rol_Nombre, Rol_Activo) VALUES (@Rol_Nombre, @Rol_Activo)
	DECLARE @RolRef tinyint

	SET  @RolRef = SCOPE_IDENTITY()

	INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, funcionalidadRef) 
	SELECT @RolRef, Item FROM @funcionalidadesSeleccionadas
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Modificar_Rol
	@RolID INT,
	@Rol_Nombre VARCHAR(60),
	@funcionalidadesSeleccionadas [THE_BTREES].[IntList] READONLY,
	@Rol_Activo BIT
AS
	BEGIN TRAN
	UPDATE THE_BTREES.Roles SET 
		Rol_Activo = @Rol_Activo, 
		Rol_Nombre = @Rol_Nombre
	 WHERE @RolID = RolID

	 DELETE FROM THE_BTREES.FuncionalidadesXRoles WHERE @RolID = RolRef

	 INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, FuncionalidadRef)
		SELECT @RolID, Item FROM @funcionalidadesSeleccionadas
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Deshabilitar_Rol
	@RolID INT
AS
	UPDATE THE_BTREES.Roles SET Rol_Activo = 0 WHERE @RolID = RolID
GO

IF  object_id(N'[THE_BTREES].[Listar_Roles]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Listar_Roles]
GO

create PROCEDURE [THE_BTREES].[Listar_Roles]
	( @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='SELECT DISTINCT r.RolID, r.Rol_Nombre, r.Rol_Activo FROM THE_BTREES.Roles r, THE_BTREES.FuncionalidadesXRoles fr WHERE r.RolID = fr.RolRef ' + @WhereClause
	execute (@sentencia)

GO

