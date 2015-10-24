INSERT INTO THE_BTREES.Encomienda 
	(
		Enco_KG,
		Enco_Precio,
		Enco_CompraRef,
		Enco_ClienteRespRef,
		Enco_ViajeRef
	)
SELECT DISTINCT	m.Paquete_KG,
				m.Paquete_Precio, 
				c.CompraID,
				cl.ClienteID,
				v.ViajeID
FROM gd_esquema.Maestra m,
	 THE_BTREES.Compra c,
	 THE_BTREES.Cliente cl,
     THE_BTREES.Viaje v,
	 THE_BTREES.Avion a,
	 THE_BTREES.RutaAerea r
WHERE m.Paquete_KG <> 0 AND
	  c.CompraID = m.Paquete_Codigo AND
	  cl.Cliente_DNI = m.Cli_Dni AND 
	  cl.Cliente_Apellido = m.Cli_Apellido AND
	  v.Viaje_AvionRef = a.AvionID AND
	  v.Viaje_RutaAereaRef = r.RutaAereaID AND
	  m.Ruta_Ciudad_Origen = (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID = r.Ruta_CiudadOrigenRef) AND
	  m.Ruta_Ciudad_Destino = (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID = r.Ruta_CiudadDestinoRef) AND
	  a.Avion_Matricula = m.Aeronave_Matricula

	   
