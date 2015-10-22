/***** GetClientesList *****/
IF  object_id(N'[GetClientesList]','P') IS NOT NULL
	DROP PROCEDURE [GetClientesList]
GO

CREATE PROCEDURE [GetClientesList]		
    @Id AS INT,
    @Nombre AS VARCHAR,
	@Apellido AS VARCHAR,
	@DNI AS VARCHAR,
	@AñoNac AS INT
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT C.ClienteID,
	          C.Cliente_Nombre,
			  C.Cliente_Apellido,
			  C.Cliente_DNI,
			  C.Cliente_Direccion,
			  C.Cliente_Telefono,
			  C.Cliente_FechaNac,
			  C.Cliente_Mail	
	   FROM Cliente C
	   WHERE C.ClienteID=ISNULL(@Id,C.ClienteID) AND C.Cliente_Nombre=ISNULL(@Nombre,C.Cliente_Nombre)	 
	   AND C.Cliente_Apellido=ISNULL(@Apellido,C.Cliente_Apellido) AND C.Cliente_DNI=ISNULL(@DNI,C.Cliente_DNI)
	   AND YEAR(C.Cliente_FechaNac)=ISNULL(@AñoNac,YEAR(C.Cliente_FechaNac))
	   ORDER BY Cliente_Apellido,Cliente_DNI
	   END
GO

/***** GetAvionesList *****/
IF  object_id(N'[GetAvionesList]','P') IS NOT NULL
	DROP PROCEDURE [GetAvionesList]
GO

CREATE PROCEDURE [GetAvionesList]		
    @Id AS INT,
    @Matricula AS VARCHAR,
	@Fabricante AS VARCHAR,
	@TipoServicioRef AS TINYINT	
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT A.AvionID, 
	          A.Avion_Matricula,
			  A.Avion_Modelo,
			  A.Avion_Fabricante,
			  (SELECT TipoSer_Nombre FROM dbo.TipoServicio WHERE TipoServicioID=A.Avion_TipoDeServicioRef) AS TipoServicio,
			  A.Avion_CantidadKgsDisponibles,
			  A.Avion_FechaDeAlta AS FechaAlta,
			  A.Avion_BajaPorFueraDeServicio,
			  A.Avion_BajaPorVidaUtil,
			  A.Avion_FechaDeBajaDefinitiva	
	   FROM dbo.Avion A
	   WHERE A.AvionID=ISNULL(@Id,A.AvionID) AND A.Avion_Matricula=ISNULL(@Matricula,A.Avion_Matricula)	 
	   AND A.Avion_Fabricante=ISNULL(@Fabricante,A.Avion_Fabricante) AND A.Avion_TipoDeServicioRef=ISNULL(@TipoServicioRef,A.Avion_TipoDeServicioRef)
	   ORDER BY Avion_Matricula,Avion_TipoDeServicioRef
	   END
GO

/***** GetRutasList *****/
IF  OBJECT_ID(N'[GetRutasList]','P') IS NOT NULL
	DROP PROCEDURE [GetRutasList]
GO

CREATE PROCEDURE [GetRutasList]		
    @Id AS INT,
    @Codigo AS NUMERIC,
	@CiudadOrigen AS SMALLINT,
	@CiudadDestino AS SMALLINT

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT R.RutaAereaID,
			  R.Ruta_Codigo,
			  (SELECT Ciudad_Nombre FROM dbo.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS CiudadOrigen,
			  (SELECT Ciudad_Nombre FROM dbo.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS CiudadDestino,
			  R.Ruta_PrecioBasePasaje,
			  R.Ruta_PrecioBaseKg,
			  R.Ruta_Activo
	   FROM dbo.RutaAerea R
	   WHERE R.RutaAereaID=ISNULL(@Id,R.RutaAereaID) AND R.Ruta_Codigo=ISNULL(@Codigo,R.Ruta_Codigo)	 
	   AND R.Ruta_CiudadOrigenRef=ISNULL(@CiudadOrigen,R.Ruta_CiudadOrigenRef) AND R.Ruta_CiudadDestinoRef=ISNULL(@CiudadDestino,R.Ruta_CiudadDestinoRef)
	   ORDER BY Ruta_Codigo
	   END
GO

/**STORES PARA LLENAR LOS COMBOS DE LAS COSAS -> KEY,VALUE**/
/***** GetTipoServicios *****/
IF  OBJECT_ID(N'[GetTipoServicios]','P') IS NOT NULL
	DROP PROCEDURE [GetTipoServicios]
GO

CREATE PROCEDURE [GetTipoServicios]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT T.TipoServicioID,
			  T.TipoSer_Nombre
	   FROM dbo.TipoServicio T
	   ORDER BY T.TipoSer_Nombre
	   END
GO

/***** GetCiudades *****/
IF  OBJECT_ID(N'[GetCiudades]','P') IS NOT NULL
	DROP PROCEDURE [GetCiudades]
GO

CREATE PROCEDURE [GetCiudades]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT C.CiudadID,
			  C.Ciudad_Nombre
	   FROM dbo.Ciudad C
	   ORDER BY C.Ciudad_Nombre
	   END
GO

/***** GetTiposTarjeta *****/
IF  OBJECT_ID(N'[GetTiposTarjeta]','P') IS NOT NULL
	DROP PROCEDURE [GetTiposTarjeta]
GO

CREATE PROCEDURE [GetTiposTarjeta]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT T.TipoTarjetaID,
			  T.TipoTarj_Descripcion
	   FROM dbo.TiposTarjeta T
	   ORDER BY T.TipoTarj_Descripcion
	   END
GO





