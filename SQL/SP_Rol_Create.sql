USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[IntList]','U') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[CheckearUsuarioAdministrador]
GO

CREATE TYPE [dbo].[IntList] AS TABLE(
    [Item] [INT] NOT NULL
)
GO


IF  object_id(N'[THE_BTREES].[Crear_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[CheckearUsuarioAdministrador]
GO

CREATE PROCEDURE THE_BTREES.Crear_Rol
	@Rol_Nombre VARCHAR(60),
	@funcionalidadesSeleccionadas INTLIST READONLY,
	@FuncionalidadRef INT
AS

	INSERT INTO THE_BTREES.Roles (Rol_Nombre, Rol_Activo) VALUES (@Rol_Nombre, 1)
	DECLARE @RolRef tinyint

	SET  @RolRef = SCOPE_IDENTITY()

	INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, funcionalidadRef) 
	SELECT @RolRef, Item FROM @funcionalidadesSeleccionadas
GO