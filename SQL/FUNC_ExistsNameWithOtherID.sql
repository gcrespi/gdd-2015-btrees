
DROP FUNCTION THE_BTREES.ExistsNameWithOtherID
	
GO

CREATE FUNCTION THE_BTREES.ExistsNameWithOtherID (@RolID INT, @Nombre VARCHAR(60))
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.Roles 
	WHERE @RolID != RolID AND @Nombre = Rol_Nombre;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

