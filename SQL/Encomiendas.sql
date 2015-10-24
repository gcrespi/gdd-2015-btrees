INSERT INTO Encomienda 
	(
		Enco_KG,
		Enco_Precio,
		Enco_CompraRef,
		Enco_ClienteRespRef,
		Enco_ViajeRef
	)
SELECT DISTINCT	Paquete_KG,
				Paquete_Precio, 
				(SELECT CompraID FROM Compra WHERE CompraID = m.Paquete_Codigo),
--				(SELECT ClienteID FROM Cliente WHERE Cliente_DNI = Cli_Dni AND Cliente_Apellido = Cli_Apellido)
				(SELECT ViajeID FROM Viaje v, Avion a WHERE v.Viaje_AvionRef = a.AvionID AND
															v.Viaje_FechaSalida = m.FechaSalida AND
															a.Avion_Matricula = m.Aeronave_Matricula)

FROM gd_esquema.Maestra m
WHERE Paquete_KG <> 0
