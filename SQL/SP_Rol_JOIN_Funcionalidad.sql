
IF  object_id(N'[THE_BTREES].[TraerRolConFuncionalidades]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerRolConFuncionalidades]
GO

CREATE PROCEDURE THE_BTREES.TraerRolConFuncionalidades
	@RolID INT
AS
	SELECT r.Rol_Nombre, fr.FuncionalidadRef as FuncionalidadRef, r.Rol_Activo FROM THE_BTREES.Roles r 
	JOIN THE_BTREES.FuncionalidadesXRoles fr ON r.RolID = fr.RolRef
	WHERE @RolID = r.RolID
GO

USE GD2C2015
GO

/***** TraerFuncionalidadesDeUsuario *****/
IF  object_id(N'[THE_BTREES].[TraerFuncionalidadesDeUsuario]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerFuncionalidadesDeUsuario]
GO

CREATE PROCEDURE [THE_BTREES].[TraerFuncionalidadesDeUsuario]		
	@usuarioID int
AS
BEGIN
	SELECT f.Funcionalidad_Nombre AS 'Funcionalidad'
	FROM THE_BTREES.RolesXUsuarios ru
	INNER JOIN THE_BTREES.FuncionalidadesXRoles fr ON ru.RolRef = fr.RolRef
	INNER JOIN THE_BTREES.Funcionalidades f ON fr.FuncionalidadRef = f.FuncionalidadID
	WHERE ru.UsuarioRef = @usuarioID
END