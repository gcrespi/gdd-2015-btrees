USE [GD2C2015]
GO

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
	@Usuario_Activo BIT OUT,
	@Usuario_Wrong_Password BIT OUT
AS 
	DECLARE @Usuario_Intentos_Fallidos TINYINT
	DECLARE @Usuario_Actual_Password VARBINARY(64)

	SET @UsuarioID = 0
	SET @Usuario_Activo = 0
	SET @Usuario_Wrong_Password = 0

	SET @Usuario_Intentos_Fallidos = 0

	SELECT TOP 1 @UsuarioID = u.UsuarioID, @Usuario_Activo = u.Usuario_Activo, @Usuario_Intentos_Fallidos = u.Usuario_Intentos_Fallidos, @Usuario_Actual_Password = CAST(u.Usuario_Password AS VARBINARY(64))
	FROM THE_BTREES.Usuarios as u JOIN
	THE_BTREES.RolesXUsuarios as ru ON u.UsuarioID = ru.UsuarioRef JOIN
	THE_BTREES.Roles as r ON r.Rol_Activo = ru.RolRef
	WHERE Usuario_Nombre = @Usuario_Nombre AND r.Rol_Nombre = 'Administrador General'
	
	IF @@ROWCOUNT > 0 BEGIN
		IF @Usuario_Actual_Password <> HASHBYTES('SHA2_256', @Usuario_Password) BEGIN
			SET @Usuario_Intentos_Fallidos = @Usuario_Intentos_Fallidos + 1 

			IF @Usuario_Intentos_Fallidos >= 3 BEGIN
				
				UPDATE THE_BTREES.Usuarios SET 
					Usuario_Intentos_Fallidos = @Usuario_Intentos_Fallidos, 
					Usuario_Activo = 0
				WHERE UsuarioID = @UsuarioID

				SET @Usuario_Activo = 0
			END ELSE BEGIN

				UPDATE THE_BTREES.Usuarios SET 
					Usuario_Intentos_Fallidos = @Usuario_Intentos_Fallidos
				WHERE UsuarioID = @UsuarioID
			END

			SET @Usuario_Wrong_Password = 1
		END ELSE BEGIN
			
			UPDATE THE_BTREES.Usuarios SET 
				Usuario_Intentos_Fallidos = 0, 
				Usuario_Activo = 1
			WHERE UsuarioID = @UsuarioID
		END
	END
	GO