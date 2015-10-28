
DROP PROC THE_BTREES.TraerRolConFuncionalidades
	
GO

CREATE PROCEDURE THE_BTREES.TraerRolConFuncionalidades
	@RolID INT
AS
	SELECT r.Rol_Nombre, fr.FuncionalidadRef as FuncionalidadRef, r.Rol_Activo FROM THE_BTREES.Roles r 
	JOIN THE_BTREES.FuncionalidadesXRoles fr ON r.RolID = fr.RolRef
	WHERE @RolID = r.RolID
GO

