USE [GD2C2015]
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
	@funcionalidadesSeleccionadas [THE_BTREES].[IntList] READONLY
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.Roles (Rol_Nombre, Rol_Activo) VALUES (@Rol_Nombre, 1)
	DECLARE @RolRef tinyint

	SET  @RolRef = SCOPE_IDENTITY()

	INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, funcionalidadRef) 
	SELECT @RolRef, Item FROM @funcionalidadesSeleccionadas
	COMMIT TRAN
GO