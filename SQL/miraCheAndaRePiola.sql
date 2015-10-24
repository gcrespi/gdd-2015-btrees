use gd2c2015
go

SET IDENTITY_INSERT THE_BTREES.Compra ON
INSERT INTO THE_BTREES.Compra
        ( CompraID ,
		  Compra_Fecha ,
          Compra_AbonaEnEfectivo ,
          Compra_DNIComprador ,
          Compra_Nombre ,
          Compra_Apellido ,
          Compra_Direccion ,
          Compra_Telefeno ,
          Compra_Mail ,
          Compra_FechaNac
        )
SELECT DISTINCT C.CodigoCompra ,
				C.fechaCompra,
				1, --TODOS ABONAN EN EFECTIVO
				C.Cli_Dni,
				C.Cli_Nombre,
				C.Cli_Apellido,
				C.Cli_Dir,
				C.Cli_Telefono,
				C.Cli_Mail,
				C.Cli_Fecha_Nac
FROM THE_BTREES.compra_con_ref C
SET IDENTITY_INSERT THE_BTREES.Compra OFF
GO

INSERT INTO THE_BTREES.Compra
        ( Compra_Fecha ,
          Compra_AbonaEnEfectivo ,
          Compra_DNIComprador ,
          Compra_Nombre ,
          Compra_Apellido ,
          Compra_Direccion ,
          Compra_Telefeno ,
          Compra_Mail ,
          Compra_FechaNac
        )
VALUES ( 
		 GETDATE(),
		 1,
		 38,
		 'santi',
		 'groso',
		 '123',
		 '123',
		 'santi_groso@gmail.com',
		 GETDATE()
		)
GO

SELECT * 
FROM THE_BTREES.Compra c
ORDER BY c.CompraID DESC
