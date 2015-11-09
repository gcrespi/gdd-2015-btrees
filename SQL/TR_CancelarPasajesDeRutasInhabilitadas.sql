USE [GD2C2015]
GO

IF OBJECT_ID(N'[THE_BTREES].[CancelarRutasInhabilitados]','TR') IS NOT NULL
	DROP TRIGGER [THE_BTREES].CancelarRutasInhabilitados
GO

CREATE TRIGGER THE_BTREES.CancelarRutasInhabilitados
ON THE_BTREES.RutaAerea FOR UPDATE
AS
BEGIN

	SELECT EncomiendaID, PasajeID, CompraRef INTO THE_BTREES.#ItemsCompra
	FROM 
	(
		SELECT EncomiendaID, NULL as PasajeID, Enco_CompraRef AS CompraRef FROM THE_BTREES.Encomienda
		UNION
		SELECT NULL, PasajeID, Pasaje_CompraRef AS CompraRef FROM THE_BTREES.Pasaje
	) ItemsCompra

	INSERT INTO THE_BTREES.Cancelacion (Cance_PasajeRef, Cance_EncomiendaRef, Motivo)
	SELECT i.PasajeID, i.EncomiendaID, 'Baja de la Ruta Aerea asignada.' 
	FROM THE_BTREES.Viaje v 
		JOIN THE_BTREES.Compra c ON c.Compra_ViajeRef = v.ViajeID
		JOIN THE_BTREES.#ItemsCompra i ON i.CompraRef = c.CompraID
		--En realidad fecha de la aplicación WHERE v.Viaje_FechaSalida > GETDATE() AND v.Viaje_RutaAereaRef IN 
		(
			SELECT d.RutaAereaID FROM deleted d
				JOIN inserted as ins ON d.RutaAereaID = ins.RutaAereaID
				WHERE ins.Ruta_Activo = 1 AND d.Ruta_Activo = 0
		)

	DROP TABLE THE_BTREES.#ItemsCompra
END
GO

SELECT c.CompraID 
	FROM THE_BTREES.RutaAerea r
		JOIN THE_BTREES.Viaje v ON r.RutaAereaID = v.Viaje_RutaAereaRef
		JOIN THE_BTREES.Compra c ON c.Compra_ViajeRef = v.ViajeID
	WHERE r.RutaAereaID = 1