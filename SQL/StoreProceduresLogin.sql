/***** CheckearUsuarioAdministrador *****/
IF  object_id(N'[THE_BTREES].[CheckearUsuarioAdministrador]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[CheckearUsuarioAdministrador]
GO

USE [GD2C2015]
GO

CREATE PROCEDURE THE_BTREES.CheckearUsuarioAdministrador
	@Usuario_Nombre NVARCHAR(60),
	@Usuario_Password NVARCHAR(60),
	@UsuarioID INT OUT,
	@Usuario_Intentos_Fallidos TINYINT OUT,
	@Usuario_Wrong_Password BIT OUT
AS 
	DECLARE @Usuario_Actual_Password varchar(max)

	SELECT TOP 1 @UsuarioID = u.UsuarioID, @Usuario_Intentos_Fallidos = u.Usuario_Intentos_Fallidos, @Usuario_Actual_Password = u.Usuario_Password
	FROM THE_BTREES.Usuarios as u JOIN
	THE_BTREES.RolesXUsuarios as ru ON u.UsuarioID = ru.UsuarioRef JOIN
	THE_BTREES.Roles as r ON r.Rol_Activo = ru.RolRef
	WHERE Usuario_Nombre = @Usuario_Nombre AND r.Rol_Nombre = 'Administrador General'
	
	IF @@ROWCOUNT = 0 BEGIN
		SET @UsuarioID = NULL
	END ELSE BEGIN
		IF @Usuario_Actual_Password <> @Usuario_Password BEGIN
			UPDATE THE_BTREES.Usuarios SET Usuario_Intentos_Fallidos = Usuario_Intentos_Fallidos + 1
			WHERE UsuarioID = @UsuarioID

			SET @Usuario_Wrong_Password = 1
		END ELSE BEGIN
			SET @Usuario_Wrong_Password = 0
		END 
	END
GO