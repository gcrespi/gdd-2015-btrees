
IF OBJECT_ID(N'[THE_BTREES].[RemoverRolesInhabilitados]','TR') IS NOT NULL
	DROP TRIGGER [THE_BTREES].[RemoverRolesInhabilitados]
GO

CREATE TRIGGER THE_BTREES.RemoverRolesInhabilitados
ON THE_BTREES.Roles FOR UPDATE
AS
BEGIN
	DELETE FROM THE_BTREES.RolesXUsuarios WHERE RolRef IN 
	(
		SELECT i.RolID FROM inserted i 
			JOIN deleted d ON d.RolID = i.RolID
			WHERE d.Rol_Activo = 1 AND i.Rol_Activo = 0 
	)
END
GO