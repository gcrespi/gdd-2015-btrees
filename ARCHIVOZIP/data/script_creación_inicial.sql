/****************************************************************************************************************************/
/*PROCEDIMIENTOS Y FUNCIONES PARA BORRAR TODO LO QUE PUDIERA EXISTIR EN LA BASE DE DATOS*/

USE [GD2C2015]
GO

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'THE_BTREES')) 
BEGIN
    EXEC ('CREATE SCHEMA THE_BTREES')
END
GO

CREATE PROCEDURE THE_BTREES.NO_CHECK_CONSTRAINS
AS 
	DECLARE @sql varchar(max)
	DECLARE tables_in_schema CURSOR FOR 
	SELECT f.name, Object_NAME(f.parent_object_id)
	FROM sys.foreign_keys AS f JOIN
	sys.schemas AS s ON s.schema_id = f.schema_id
	WHERE s.name = 'THE_BTREES'

	DECLARE @table_name varchar(max)
	DECLARE @fk_name varchar(max)

	OPEN tables_in_schema 

	FETCH tables_in_schema INTO  @fk_name, @table_name

	WHILE (@@FETCH_STATUS = 0) 
	BEGIN 
		SET @sql = 'ALTER TABLE THE_BTREES.' + @table_name + ' DROP CONSTRAINT ' + @fk_name
		EXEC(@sql)

		FETCH tables_in_schema INTO  @fk_name, @table_name
	END 

	CLOSE tables_in_schema 
	DEALLOCATE tables_in_schema 
GO

-- Creo el SP para limpiar la base
CREATE PROCEDURE [THE_BTREES].CleanDatabase
AS
	DECLARE @names_sp varchar(max)
	DECLARE @names_func varchar(max)
	DECLARE @names_veiws varchar(max)
	DECLARE @names_tables varchar(max)
	DECLARE @names_types varchar(max)
	DECLARE @names_triggers varchar(max)

	DECLARE @sql varchar(max)

	--Borro los triggers
	SELECT @names_triggers = coalesce(@names_triggers + ', ','') + '[THE_BTREES].' + t.NAME
	FROM GD2C2015.sys.objects t, GD2C2015.sys.schemas s
	WHERE s.schema_id = t.schema_id AND s.name = 'THE_BTREES' AND  t.type = 'TR'
	
	SET @sql = 'DROP TRIGGER ' + @names_triggers
	EXEC(@sql)

	--Borro los stored procedures
	SELECT @names_sp = coalesce(@names_sp + ', ','') + '[THE_BTREES].' + p.NAME
	FROM GD2C2015.sys.procedures p, GD2C2015.sys.schemas s
	WHERE s.schema_id = p.schema_id AND p.NAME != 'CleanDatabase' AND p.NAME != 'NO_CHECK_CONSTRAINS' AND s.name = 'THE_BTREES'
	
	SET @sql = 'DROP PROCEDURE ' + @names_sp
	EXEC(@sql)

	--Borro las functions
	SELECT @names_func = coalesce(@names_func + ', ','') + '[THE_BTREES].' + f.NAME
	FROM GD2C2015.sys.objects f, GD2C2015.sys.schemas s
	WHERE s.schema_id = f.schema_id AND s.name = 'THE_BTREES' AND  f.type IN ('FN', 'IF', 'TF')
	
	SET @sql = 'DROP FUNCTION ' + @names_func
	EXEC(@sql)


	--Borro las vistas
	SELECT @names_veiws = coalesce(@names_veiws + ', ','') + '[THE_BTREES].' + TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.VIEWS
	WHERE TABLE_SCHEMA = 'THE_BTREES'

	SET @sql = 'DROP VIEW ' + @names_veiws
	EXEC(@sql)

	-- Deshabilito la integridad referencial de las tablas a borrar
	EXEC THE_BTREES.NO_CHECK_CONSTRAINS

	--Borro las tablas excepto la maestra
	SELECT @names_tables = coalesce(@names_tables + ', ','') + '[THE_BTREES].' + TABLE_NAME
	FROM GD2C2015.INFORMATION_SCHEMA.TABLES
	WHERE TABLE_SCHEMA = 'THE_BTREES' and TABLE_TYPE = 'BASE TABLE'

	SET @sql = 'DROP TABLE ' + @names_tables
	EXEC(@sql)

	--Borro los User define types
	SELECT @names_types = coalesce( @names_types + ' DROP TYPE ','DROP TYPE ') + '[THE_BTREES].' + t.NAME
	FROM GD2C2015.sys.types t, GD2C2015.sys.schemas s
	WHERE s.schema_id = t.schema_id AND s.name = 'THE_BTREES'

	SET @sql = @names_types
	EXEC(@sql)
GO

DECLARE @ok bit
SET @ok = 0
begin TRAN
	EXEC [THE_BTREES].CleanDatabase
	SET @ok = 1
COMMIT TRAN

DROP PROCEDURE [THE_BTREES].CleanDatabase
DROP PROCEDURE [THE_BTREES].NO_CHECK_CONSTRAINS	

IF @ok = 1 
DROP SCHEMA THE_BTREES
GO

/****************************************************************************************************************************/
/*CREACION DE TODAS LAS TABLAS CON SUS CORRESPONDIENTES RELACIONES Y CONSTRAINTS*/

USE [GD2C2015]
GO

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'THE_BTREES')) 
BEGIN
    EXEC ('CREATE SCHEMA THE_BTREES')
END
GO


/****** Object:  Table [THE_BTREES].[Avion]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [THE_BTREES].[Avion](
	[AvionID] [int] IDENTITY(1,1) NOT NULL,
	[Avion_FechaDeAlta] [date] NOT NULL,
	[Avion_Modelo] [nvarchar](255) NOT NULL,
	[Avion_Matricula] [nvarchar](255) NOT NULL,
	[Avion_Fabricante] [nvarchar](255) NOT NULL,
	[Avion_TipoDeServicioRef] [tinyint] NOT NULL,
	[Avion_BajaPorFueraDeServicio] [bit] NOT NULL,
	[Avion_BajaPorVidaUtil] [bit] NOT NULL,
	[Avion_FechaDeBajaDefinitiva] [date] NULL,
	[Avion_CantidadKgsDisponibles] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Avion] PRIMARY KEY CLUSTERED 
(
	[AvionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Matricula] UNIQUE NONCLUSTERED 
(
	[Avion_Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Butaca]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[Butaca](
	[ButacaID] [int] IDENTITY(1,1) NOT NULL,
	[Butaca_AvionRef] [int] NOT NULL,
	[Butaca_Numero] [int] NOT NULL,
	[Butaca_EsVentanilla] [bit] NOT NULL,
 CONSTRAINT [PK_Butaca] PRIMARY KEY CLUSTERED 
(
	[ButacaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UniqueButacaAvion] UNIQUE NONCLUSTERED 
(
	[Butaca_Numero] ASC,
	[Butaca_AvionRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Cancelacion]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [THE_BTREES].[Cancelacion](
	[CancelacionID] [INT] IDENTITY(1,1) NOT NULL,
	[Cance_CompraRef] [INT] NOT NULL,
	[Cance_Fecha] [DATE] NOT NULL,
	[Motivo] [VARCHAR](50) NOT NULL,
 CONSTRAINT [PK_Cancelacion] PRIMARY KEY CLUSTERED 
(
	[CancelacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [THE_BTREES].[Canje]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[Canje](
	[CanjeID] [int] IDENTITY(1,1) NOT NULL,
	[Canje_ClienteRef] [int] NOT NULL,
	[Canje_ProductoRef] [int] NOT NULL,
	[Canje_CantidadProducto] [int] NOT NULL,
	[Canje_Fecha] DATETIME NOT NULL,
 CONSTRAINT [PK_Canje] PRIMARY KEY CLUSTERED 
(
	[CanjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Ciudad]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[Ciudad](
	[CiudadID] [smallint] IDENTITY(1,1) NOT NULL,
	[Ciudad_Nombre] [nvarchar](255) NOT NULL,
	[Ciudad_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CiudadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Cliente]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [THE_BTREES].[Cliente](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_Nombre] [varchar](50) NOT NULL,
	[Cliente_Apellido] [varchar](50) NOT NULL,
	[Cliente_DNI] [varchar](15) NOT NULL,
	[Cliente_Direccion] [varchar](100) NOT NULL,
	[Cliente_Telefono] [int] NOT NULL,
	[Cliente_Mail] [varchar](100) NULL,
	[Cliente_FechaNac] [datetime] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [THE_BTREES].[Compra]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [THE_BTREES].[Compra](
	[CompraID] [int] IDENTITY(1,1) NOT NULL,
	[Compra_Fecha] [datetime] NOT NULL,
	[Compra_AbonaEnEfectivo] [bit] NOT NULL,
	[Compra_CantCuotas] [tinyint] NULL,
	[Compra_TipoTarjetaRef] [int] NULL,
	[Compra_CompradorRef] [int] NOT NULL,
	[Compra_NumTarjeta] [varchar](20) NULL,
	[Compra_CodSeg] [int] NULL,
	[Compra_FechaVencimiento] [date] NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [THE_BTREES].[Encomienda]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[Encomienda](
	[EncomiendaID] [int] IDENTITY(1,1) NOT NULL,
	[Enco_KG] [smallint] NOT NULL,
	[Enco_Precio] [numeric](18, 2) NOT NULL,
	[Enco_CompraRef] [int] NOT NULL,
	[Enco_ClienteRespRef] [int] NOT NULL,
	[Enco_ViajeRef] [int] NOT NULL,
	[Enco_CancelacionRef] [INT] NULL,
 CONSTRAINT [PK_Paquete] PRIMARY KEY CLUSTERED 
(
	[EncomiendaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[FueraDeServicio]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[FueraDeServicio](
	[FueraDeServicioId] [int] IDENTITY(1,1) NOT NULL,
	[Fuera_AvionRef] [int] NOT NULL,
	[Fuera_FechaFuera] [date] NOT NULL,
	[Fuera_FechaVuelta] [date],
 CONSTRAINT [PK_FueraDeServicio] PRIMARY KEY CLUSTERED 
(
	[FueraDeServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Pasaje]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[Pasaje](
	[PasajeID] [int] IDENTITY(1,1) NOT NULL,
	[Pasaje_ClienteRef] [int] NOT NULL,
	[Pasaje_CompraRef] [int] NOT NULL,
	[Pasaje_Precio] [nchar](10) NOT NULL,
	[Pasaje_ButacaRef] [int] NOT NULL,
	[Pasaje_ViajeRef] [int] NOT NULL,
    [Pasaje_CancelacionRef] [INT] NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[PasajeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Producto]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [THE_BTREES].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Producto_Stock] [int] NOT NULL,
	[Producto_Descripcion] [varchar](50) NOT NULL,
	[Producto_Millas] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [THE_BTREES].[RutaAerea]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[RutaAerea](
	[RutaAereaID] [int] IDENTITY(1,1) NOT NULL,
	[Ruta_Codigo] [numeric](18, 0) NOT NULL,
	[Ruta_CiudadOrigenRef] [smallint] NOT NULL,
	[Ruta_CiudadDestinoRef] [smallint] NOT NULL,
	[Ruta_PrecioBaseKg] [numeric](18, 2) NOT NULL,
	[Ruta_PrecioBasePasaje] [numeric](18, 2) NOT NULL,
	[Ruta_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_RutaAerea] PRIMARY KEY CLUSTERED 
(
	[RutaAereaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[TipoServicio]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[TipoServicio](
	[TipoServicioID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TipoSer_Nombre] [nvarchar](255) NOT NULL,
	[TipoSer_PorcentajeAdicional] [int] NOT NULL,
 CONSTRAINT [PK_TipoServicio] PRIMARY KEY CLUSTERED 
(
	[TipoServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[TipoServicioXRutaAerea]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[TipoServicioXRutaAerea](
	[RutaAereaRef] [int] NOT NULL,
	[TipoServicioRef] [tinyint] NOT NULL,
 CONSTRAINT [PK_TipoServicioXRutaAerea] PRIMARY KEY CLUSTERED 
(
	[RutaAereaRef] ASC,
	[TipoServicioRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[TiposTarjeta]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [THE_BTREES].[TiposTarjeta](
	[TipoTarjetaID] [int] IDENTITY(1,1) NOT NULL,
	[TipoTarj_Descripcion] [varchar](50) NOT NULL,
	[TipoTarj_CuotasMax] [int] NOT NULL,
 CONSTRAINT [PK_TiposTarjeta] PRIMARY KEY CLUSTERED 
(
	[TipoTarjetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [THE_BTREES].[TransaccionesMillas]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[TransaccionesMillas](
	[TransaccionId] [int] IDENTITY(1,1) NOT NULL,
	[Tran_CanjeRef] [int] NULL,
	[Tran_ClienteRef] [int] NOT NULL,
	[Tran_EncomiendaRef] [int] NULL,
	[Tran_PasajeRef] [int] NULL,
	[Tran_CantidadMillas] [int] NOT NULL,
	[Tran_Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_TransaccionesMillas] PRIMARY KEY CLUSTERED 
(
	[TransaccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [THE_BTREES].[Viaje]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [THE_BTREES].[Viaje](
	[ViajeID] [int] IDENTITY(1,1) NOT NULL,
	[Viaje_FechaSalida] [datetime] NOT NULL,
	[Viaje_FechaLlegada] [datetime] NULL,
	[Viaje_AvionRef] [int] NOT NULL,
	[Viaje_RutaAereaRef] [int] NOT NULL,
	[Viaje_FechaLlegadaEstimada] [datetime] NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[ViajeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [THE_BTREES].[Avion]  WITH CHECK ADD  CONSTRAINT [FK_Avion_TipoServicio] FOREIGN KEY([Avion_TipoDeServicioRef])
REFERENCES [THE_BTREES].[TipoServicio] ([TipoServicioID])
GO
ALTER TABLE [THE_BTREES].[Avion] CHECK CONSTRAINT [FK_Avion_TipoServicio]
GO
ALTER TABLE [THE_BTREES].[Butaca]  WITH CHECK ADD  CONSTRAINT [FK_Butaca_Avion] FOREIGN KEY([Butaca_AvionRef])
REFERENCES [THE_BTREES].[Avion] ([AvionID])
GO
ALTER TABLE [THE_BTREES].[Butaca] CHECK CONSTRAINT [FK_Butaca_Avion]
GO
ALTER TABLE [THE_BTREES].[Cancelacion]  WITH CHECK ADD  CONSTRAINT [FK_Cancelacion_Compra] FOREIGN KEY([Cance_CompraRef])
REFERENCES [THE_BTREES].[Compra] ([CompraID])
GO
ALTER TABLE [THE_BTREES].[Cancelacion] CHECK CONSTRAINT [FK_Cancelacion_Compra]
GO
ALTER TABLE [THE_BTREES].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Cliente] FOREIGN KEY([Canje_ClienteRef])
REFERENCES [THE_BTREES].[Cliente] ([ClienteID])
GO
ALTER TABLE [THE_BTREES].[Canje] CHECK CONSTRAINT [FK_Canje_Cliente]
GO
ALTER TABLE [THE_BTREES].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Producto] FOREIGN KEY([Canje_ProductoRef])
REFERENCES [THE_BTREES].[Producto] ([ProductoID])
GO
ALTER TABLE [THE_BTREES].[Canje] CHECK CONSTRAINT [FK_Canje_Producto]
GO
ALTER TABLE [THE_BTREES].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_TipoTarjetaDeCredito] FOREIGN KEY([Compra_TipoTarjetaRef])
REFERENCES [THE_BTREES].[TiposTarjeta] ([TipoTarjetaID])
GO
ALTER TABLE [THE_BTREES].[Compra] CHECK CONSTRAINT [FK_Compra_TipoTarjetaDeCredito]
GO
ALTER TABLE [THE_BTREES].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Cliente] FOREIGN KEY([Enco_ClienteRespRef])
REFERENCES [THE_BTREES].[Cliente] ([ClienteID])
GO
ALTER TABLE [THE_BTREES].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Cliente]
GO
ALTER TABLE [THE_BTREES].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Compra] FOREIGN KEY([Enco_CompraRef])
REFERENCES [THE_BTREES].[Compra] ([CompraID])
GO
ALTER TABLE [THE_BTREES].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Compra]
GO
ALTER TABLE [THE_BTREES].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Viaje] FOREIGN KEY([Enco_ViajeRef])
REFERENCES [THE_BTREES].[Viaje] ([ViajeID])
GO
ALTER TABLE [THE_BTREES].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Viaje]
GO
ALTER TABLE [THE_BTREES].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Cancelacion] FOREIGN KEY([Enco_CancelacionRef])
REFERENCES [THE_BTREES].[Cancelacion] ([CancelacionID])
GO
ALTER TABLE [THE_BTREES].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Cancelacion]
GO
ALTER TABLE [THE_BTREES].[FueraDeServicio]  WITH CHECK ADD  CONSTRAINT [FK_FueraDeServicio_Avion] FOREIGN KEY([Fuera_AvionRef])
REFERENCES [THE_BTREES].[Avion] ([AvionID])
GO
ALTER TABLE [THE_BTREES].[FueraDeServicio] CHECK CONSTRAINT [FK_FueraDeServicio_Avion]
GO
ALTER TABLE [THE_BTREES].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Butaca] FOREIGN KEY([Pasaje_ButacaRef])
REFERENCES [THE_BTREES].[Butaca] ([ButacaID])
GO
ALTER TABLE [THE_BTREES].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Butaca]
GO
ALTER TABLE [THE_BTREES].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cliente] FOREIGN KEY([Pasaje_ClienteRef])
REFERENCES [THE_BTREES].[Cliente] ([ClienteID])
GO
ALTER TABLE [THE_BTREES].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cliente]
GO
ALTER TABLE [THE_BTREES].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Compra] FOREIGN KEY([Pasaje_CompraRef])
REFERENCES [THE_BTREES].[Compra] ([CompraID])
GO
ALTER TABLE [THE_BTREES].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Compra]
GO
ALTER TABLE [THE_BTREES].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([Pasaje_ViajeRef])
REFERENCES [THE_BTREES].[Viaje] ([ViajeID])
GO
ALTER TABLE [THE_BTREES].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cancelacion] FOREIGN KEY([Pasaje_CancelacionRef])
REFERENCES [THE_BTREES].[Cancelacion] ([CancelacionID])
GO
ALTER TABLE [THE_BTREES].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cancelacion]
GO
ALTER TABLE [THE_BTREES].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Viaje]
GO
ALTER TABLE [THE_BTREES].[RutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_RutaAerea_CiudadDestino] FOREIGN KEY([Ruta_CiudadDestinoRef])
REFERENCES [THE_BTREES].[Ciudad] ([CiudadID])
GO
ALTER TABLE [THE_BTREES].[RutaAerea] CHECK CONSTRAINT [FK_RutaAerea_CiudadDestino]
GO
ALTER TABLE [THE_BTREES].[RutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_RutaAerea_CiudadOrigen] FOREIGN KEY([Ruta_CiudadOrigenRef])
REFERENCES [THE_BTREES].[Ciudad] ([CiudadID])
GO
ALTER TABLE [THE_BTREES].[RutaAerea] CHECK CONSTRAINT [FK_RutaAerea_CiudadOrigen]
GO
ALTER TABLE [THE_BTREES].[TipoServicioXRutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_TipoServicioXRutaAerea_RutaAerea] FOREIGN KEY([RutaAereaRef])
REFERENCES [THE_BTREES].[RutaAerea] ([RutaAereaID])
GO
ALTER TABLE [THE_BTREES].[TipoServicioXRutaAerea] CHECK CONSTRAINT [FK_TipoServicioXRutaAerea_RutaAerea]
GO
ALTER TABLE [THE_BTREES].[TipoServicioXRutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_TipoServicioXRutaAerea_TipoServicio] FOREIGN KEY([TipoServicioRef])
REFERENCES [THE_BTREES].[TipoServicio] ([TipoServicioID])
GO
ALTER TABLE [THE_BTREES].[TipoServicioXRutaAerea] CHECK CONSTRAINT [FK_TipoServicioXRutaAerea_TipoServicio]
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Canje] FOREIGN KEY([Tran_CanjeRef])
REFERENCES [THE_BTREES].[Canje] ([CanjeID])
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Canje]
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Cliente] FOREIGN KEY([Tran_ClienteRef])
REFERENCES [THE_BTREES].[Cliente] ([ClienteID])
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Cliente]
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Encomienda] FOREIGN KEY([Tran_EncomiendaRef])
REFERENCES [THE_BTREES].[Encomienda] ([EncomiendaID])
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Encomienda]
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Pasaje] FOREIGN KEY([Tran_PasajeRef])
REFERENCES [THE_BTREES].[Pasaje] ([PasajeID])
GO
ALTER TABLE [THE_BTREES].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Pasaje]
GO
ALTER TABLE [THE_BTREES].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Avion] FOREIGN KEY([Viaje_AvionRef])
REFERENCES [THE_BTREES].[Avion] ([AvionID])
GO
ALTER TABLE [THE_BTREES].[Viaje] CHECK CONSTRAINT [FK_Viaje_Avion]
GO
ALTER TABLE [THE_BTREES].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_RutaAerea] FOREIGN KEY([Viaje_RutaAereaRef])
REFERENCES [THE_BTREES].[RutaAerea] ([RutaAereaID])
GO
ALTER TABLE [THE_BTREES].[Viaje] CHECK CONSTRAINT [FK_Viaje_RutaAerea]
GO


BEGIN TRAN
CREATE TABLE [THE_BTREES].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario_Nombre] [varchar](60) NOT NULL,
	[Usuario_Password] [varchar](64) NOT NULL,
	[Usuario_Intentos_Fallidos] [tinyint] NOT NULL,
	[Usuario_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Usuario_Nombre] UNIQUE NONCLUSTERED 
(
	[Usuario_Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [THE_BTREES].[Roles](
	[RolID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Rol_Nombre] [varchar](60) NOT NULL,
	[Rol_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Rol_Nombre] UNIQUE NONCLUSTERED 
(
	[Rol_Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [THE_BTREES].[Funcionalidades](
	[FuncionalidadID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Funcionalidad_Nombre] [varchar](60) NOT NULL,
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[FuncionalidadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Unique_Funcionalidad_Nombre] UNIQUE NONCLUSTERED 
(
	[Funcionalidad_Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [THE_BTREES].[RolesXUsuarios](
	[UsuarioRef] [int] NOT NULL,
	[RolRef] [tinyint] NOT NULL,
 CONSTRAINT [PK_RolesXUsuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioRef] ASC,
	[RolRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [THE_BTREES].[FuncionalidadesXRoles](
	[RolRef] [tinyint] NOT NULL,
	[FuncionalidadRef] [tinyint] NOT NULL,
 CONSTRAINT [PK_FuncionalidadesXRoles] PRIMARY KEY CLUSTERED 
(
	[RolRef] ASC,
	[FuncionalidadRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [THE_BTREES].[RolesXUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuarios_Usuarios] FOREIGN KEY([UsuarioRef])
REFERENCES [THE_BTREES].[Usuarios] ([UsuarioID])
ALTER TABLE [THE_BTREES].[RolesXUsuarios] CHECK CONSTRAINT [FK_RolesXUsuarios_Usuarios]

ALTER TABLE [THE_BTREES].[RolesXUsuarios]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuarios_Roles] FOREIGN KEY([RolRef])
REFERENCES [THE_BTREES].[Roles] ([RolID])
ALTER TABLE [THE_BTREES].[RolesXUsuarios] CHECK CONSTRAINT [FK_RolesXUsuarios_Roles]

ALTER TABLE [THE_BTREES].[FuncionalidadesXRoles]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesXRoles_Roles] FOREIGN KEY([RolRef])
REFERENCES [THE_BTREES].[Roles] ([RolID])
ALTER TABLE [THE_BTREES].[FuncionalidadesXRoles] CHECK CONSTRAINT [FK_FuncionalidadesXRoles_Roles]

ALTER TABLE [THE_BTREES].[FuncionalidadesXRoles]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesXRoles_Funcionalidades] FOREIGN KEY([FuncionalidadRef])
REFERENCES [THE_BTREES].[Funcionalidades] ([FuncionalidadID])
ALTER TABLE [THE_BTREES].[FuncionalidadesXRoles] CHECK CONSTRAINT [FK_FuncionalidadesXRoles_Funcionalidades]
COMMIT TRAN
GO


/****************************************************************************************************************************/
/*CREACION DE VISTAS QUE SERAN UTILIZADAS PARA FACILITAR LA IMPORTACION O EN ALGUNOS STORED PROCEDURES*/

USE [GD2C2015]
GO

CREATE VIEW THE_BTREES.viajes_con_ref
AS
SELECT DISTINCT m.FechaSalida,
				m.FechaLLegada,
				(SELECT AvionID FROM THE_BTREES.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
				m.Ruta_Codigo,
				(SELECT TipoServicioID FROM THE_BTREES.TipoServicio WHERE TipoSer_Nombre=m.Tipo_Servicio) AS TipoServicioRef,
				m.Fecha_LLegada_Estimada,
				(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE m.Ruta_Ciudad_Destino=Ciudad_Nombre) AS CiudadDestinoRef,
				(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE m.Ruta_Ciudad_Origen=Ciudad_Nombre) AS CiudadOrigenRef
FROM gd_esquema.Maestra m
GO

CREATE VIEW THE_BTREES.compra_con_ref
AS
SELECT DISTINCT (SELECT AvionID FROM THE_BTREES.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
	   (CASE 
			WHEN M.Pasaje_Codigo<>0 THEN M.Pasaje_FechaCompra
			ELSE M.Paquete_FechaCompra
			END) AS fechaCompra,
	   (CASE 
	   	   WHEN M.Pasaje_Codigo<>0 THEN M.Pasaje_Codigo
		   ELSE M.Paquete_Codigo
		   END) AS CodigoCompra,
	   m.FechaLLegada,
	   m.FechaSalida,
	   m.Fecha_LLegada_Estimada,
	   c.ClienteID AS CompradorRef
FROM gd_esquema.Maestra m, THE_BTREES.Cliente c
WHERE m.Cli_Dni = c.Cliente_DNI AND m.Cli_Apellido = c.Cliente_Apellido
GO

CREATE VIEW THE_BTREES.Viaje_Pasajes_Vendidos
AS
SELECT V.ViajeID AS Viaje,
	   B.CantidadDeButacas,
	   B.CantidadDeButacas -  COUNT(P.PasajeID) AS ButacasDisponibles
FROM THE_BTREES.Pasaje P
RIGHT JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
RIGHT JOIN (SELECT Butaca_AvionRef AS Avion,
					COUNT(ButacaID) AS CantidadDeButacas
            FROM THE_BTREES.Butaca
			GROUP BY Butaca_AvionRef) B ON V.Viaje_AvionRef=B.Avion
WHERE P.Pasaje_CancelacionRef IS NULL
GROUP BY V.ViajeID,B.CantidadDeButacas
GO

CREATE VIEW THE_BTREES.kg_Dispo_Por_Viaje
AS
	   SELECT v.ViajeID,
			  A.Avion_CantidadKgsDisponibles AS KSTotales,
			 (A.Avion_CantidadKgsDisponibles-(SUM(ISNULL(E.Enco_KG,0)))) AS KGDisponibles
	   FROM THE_BTREES.Avion A
	   INNER JOIN THE_BTREES.Viaje V ON A.AvionID=V.Viaje_AvionRef
	   LEFT JOIN THE_BTREES.Encomienda E ON E.Enco_ViajeRef=V.ViajeID
	   WHERE E.Enco_CancelacionRef IS NULL
	   GROUP BY E.Enco_ViajeRef,A.Avion_CantidadKgsDisponibles,V.ViajeID

GO

/****************************************************************************************************************************/
/*CREACION DEL PROCEDURE QUE SE USARA PARA MANEJAR LAS ESTADISTICAS*/

USE [GD2C2015]
GO

/***** GetEstadisticaSelecionada *****/
IF  object_id(N'[THE_BTREES].[GetEstadisticaSelecionada]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetEstadisticaSelecionada]
GO

CREATE PROCEDURE [THE_BTREES].[GetEstadisticaSelecionada]		
	@Opcion AS INT,
	@Semestre AS INT,
	@Año AS INT
AS
    BEGIN
	   SET NOCOUNT ON	

       DECLARE @Desde AS DATE
	   DECLARE @Hasta AS DATE

	   IF @Semestre=1
			BEGIN
			SET @Desde=DATEFROMPARTS(@Año,1,1)
			SET @Hasta=DATEFROMPARTS(@Año,6,30)
			END
		ELSE
			BEGIN
			SET @Desde=DATEFROMPARTS(@Año,7,1)
			SET @Hasta=DATEFROMPARTS(@Año,12,31)
			END

	    IF @Opcion=1
			BEGIN
				SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS Ciudad,
							COUNT(P.PasajeID) AS 'Cantidad de Pasajes'
				FROM THE_BTREES.Pasaje P
				INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
				INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
				WHERE V.Viaje_FechaLlegada BETWEEN @Desde AND @Hasta 
				GROUP BY R.Ruta_CiudadDestinoRef
				ORDER BY COUNT(P.PasajeID) DESC
		 RETURN
		 END

		 ELSE IF @Opcion=2
			 BEGIN
				SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS Ciudad,
						 (SUM(Y.CantButacas) - COUNT(P.Pasaje_ButacaRef)) AS 'Cant Butacas Sin Comprar'  
				FROM THE_BTREES.Pasaje P
				INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
				INNER JOIN (SELECT A.AvionID,
								    COUNT(B.ButacaID) AS CantButacas
							 FROM THE_BTREES.Avion A
							 INNER JOIN THE_BTREES.Butaca B ON B.Butaca_AvionRef = A.AvionID
							GROUP BY A.AvionID) Y ON Y.AvionID=V.Viaje_AvionRef
				INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
				WHERE V.Viaje_FechaLlegada BETWEEN @Desde AND @Hasta 
				GROUP BY R.Ruta_CiudadDestinoRef
				ORDER BY (SUM(Y.CantButacas) - COUNT(P.Pasaje_ButacaRef)) DESC
		 RETURN
		 END

		 ELSE IF @Opcion=3
		 BEGIN
			SELECT TOP 5 (SELECT Cliente_Nombre FROM THE_BTREES.Cliente WHERE ClienteID=M.Tran_ClienteRef) AS Cliente,
			       SUM(M.CantMillas) AS 'Cantidad de millas disponibles'
			FROM (SELECT E.Tran_ClienteRef,
    					 (CASE 
						  WHEN E.Tran_CanjeRef IS NULL THEN E.Tran_CantidadMillas
						  ELSE 0-E.Tran_CantidadMillas
						  END) AS CantMillas
				  FROM THE_BTREES.TransaccionesMillas E ) M 
			GROUP BY M.Tran_ClienteRef
			ORDER BY SUM(M.CantMillas) DESC
		 RETURN
		 END

		 ELSE IF @Opcion=4
		 BEGIN
				SELECT TOP 5 (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS Ciudad,
						COUNT(P.PasajeID) AS 'Cant Pasajes Cancelados'
				FROM THE_BTREES.Pasaje P
				INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef
				INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
			    WHERE V.Viaje_FechaLlegada BETWEEN @Desde AND @Hasta AND Pasaje_CancelacionRef IS NOT NULL
			    GROUP BY R.Ruta_CiudadDestinoRef
				ORDER BY COUNT(P.PasajeID) DESC				
		 RETURN
		 END

		 ELSE
		 BEGIN
		 	   SELECT TOP 5 A.Avion_Matricula AS 'Matricula',
				    	F.CantidadDiasFuera AS 'Cant Dias Fuera de Servicio'
			  FROM THE_BTREES.Avion A
			  INNER JOIN (SELECT Q.Fuera_AvionRef,
								 SUM(DATEDIFF(DAY,Q.Fuera_FechaVuelta,Q.Fuera_FechaVuelta)) AS CantidadDiasFuera	 
						  FROM THE_BTREES.FueraDeServicio Q
						  WHERE Q.Fuera_FechaFuera BETWEEN @Desde AND @Hasta 
						  GROUP BY Q.Fuera_AvionRef) F ON F.Fuera_AvionRef=A.AvionID
			  ORDER BY CantidadDiasFuera DESC
		 RETURN
		 END
	   END
GO


/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE GENERICOS QUE SE USARAN DESDE VARIAS PANTALLAS*/

USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[TraerData]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerData]
GO

create PROCEDURE [THE_BTREES].[TraerData]
	( @Tabla nvarchar(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='select * from [THE_BTREES].' + @Tabla 
	execute (@sentencia)

GO


IF  object_id(N'[THE_BTREES].[TraerDataConFiltros]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerDataConFiltros]
GO

create PROCEDURE [THE_BTREES].[TraerDataConFiltros]
	( @Tabla nvarchar(MAX), @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='select * FROM ' + @Tabla + ' ' + @WhereClause
	execute (@sentencia)
GO

/***** GetClientesList *****/
IF  object_id(N'[THE_BTREES].[GetClientesList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetClientesList]
GO

CREATE PROCEDURE [THE_BTREES].[GetClientesList]		
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
IF  object_id(N'[THE_BTREES].[GetAvionesList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetAvionesList]
GO

CREATE PROCEDURE [THE_BTREES].[GetAvionesList]		
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
			  (SELECT TipoSer_Nombre FROM THE_BTREES.TipoServicio WHERE TipoServicioID=A.Avion_TipoDeServicioRef) AS TipoServicio,
			  A.Avion_CantidadKgsDisponibles,
			  A.Avion_FechaDeAlta AS FechaAlta,
			  A.Avion_BajaPorFueraDeServicio,
			  A.Avion_BajaPorVidaUtil,
			  A.Avion_FechaDeBajaDefinitiva	
	   FROM THE_BTREES.Avion A
	   WHERE A.AvionID=ISNULL(@Id,A.AvionID) AND A.Avion_Matricula=ISNULL(@Matricula,A.Avion_Matricula)	 
	   AND A.Avion_Fabricante=ISNULL(@Fabricante,A.Avion_Fabricante) AND A.Avion_TipoDeServicioRef=ISNULL(@TipoServicioRef,A.Avion_TipoDeServicioRef)
	   ORDER BY Avion_Matricula,Avion_TipoDeServicioRef
	   END
GO

/***** GetRutasList *****/
IF  OBJECT_ID(N'[THE_BTREES].[GetRutasList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetRutasList]
GO

CREATE PROCEDURE [THE_BTREES].[GetRutasList]		
    @Id AS INT,
    @Codigo AS NUMERIC,
	@CiudadOrigen AS SMALLINT,
	@CiudadDestino AS SMALLINT

AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT R.RutaAereaID,
			  R.Ruta_Codigo,
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS CiudadOrigen,
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS CiudadDestino,
			  R.Ruta_PrecioBasePasaje,
			  R.Ruta_PrecioBaseKg,
			  R.Ruta_Activo
	   FROM THE_BTREES.RutaAerea R
	   WHERE R.RutaAereaID=ISNULL(@Id,R.RutaAereaID) AND R.Ruta_Codigo=ISNULL(@Codigo,R.Ruta_Codigo)	 
	   AND R.Ruta_CiudadOrigenRef=ISNULL(@CiudadOrigen,R.Ruta_CiudadOrigenRef) AND R.Ruta_CiudadDestinoRef=ISNULL(@CiudadDestino,R.Ruta_CiudadDestinoRef)
	   ORDER BY Ruta_Codigo
	   END
GO

/**STORES PARA LLENAR LOS COMBOS DE LAS COSAS -> KEY,VALUE**/
/***** GetTipoServicios *****/
IF  OBJECT_ID(N'[THE_BTREES].[GetTipoServicios]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetTipoServicios]
GO

CREATE PROCEDURE [THE_BTREES].[GetTipoServicios]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT T.TipoServicioID,
			  T.TipoSer_Nombre
	   FROM THE_BTREES.TipoServicio T
	   ORDER BY T.TipoSer_Nombre
	   END
GO

/***** GetCiudades *****/
IF  OBJECT_ID(N'[THE_BTREES].[GetCiudades]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetCiudades]
GO

CREATE PROCEDURE [THE_BTREES].[GetCiudades]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT C.CiudadID,
			  C.Ciudad_Nombre
	   FROM THE_BTREES.Ciudad C
	   ORDER BY C.Ciudad_Nombre
	   END
GO

/***** GetTiposTarjeta *****/
IF  OBJECT_ID(N'[THE_BTREES].[GetTiposTarjeta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetTiposTarjeta]
GO

CREATE PROCEDURE [THE_BTREES].[GetTiposTarjeta]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT T.TipoTarjetaID,
			  T.TipoTarj_Descripcion
	   FROM THE_BTREES.TiposTarjeta T
	   ORDER BY T.TipoTarj_Descripcion
	   END
GO

/***** GetAvionesMatricula *****/
IF  OBJECT_ID(N'[THE_BTREES].[GetAvionesMatricula]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetAvionesMatricula]
GO

CREATE PROCEDURE [THE_BTREES].[GetAvionesMatricula]		
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT A.AvionID,
			  A.Avion_Matricula
	   FROM THE_BTREES.Avion A
	   ORDER BY A.Avion_Matricula
	   END
GO



/****************************************************************************************************************************/
/*CREACION DEL PROCEDURE PARA EL MANJEO DEL LOGIN*/

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

/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LAS COMPRAS*/

/***** GetAeronavesParaCompraList *****/
IF  object_id(N'[THE_BTREES].[GetAeronavesParaCompraList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetAeronavesParaCompraList]
GO

CREATE PROCEDURE [THE_BTREES].[GetAeronavesParaCompraList]	
	@Fecha AS DATETIME	
		
AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT A.AvionID,
			  A.Avion_Matricula AS Matricula,
			  (SELECT TipoSer_Nombre FROM THE_BTREES.TipoServicio WHERE A.Avion_TipoDeServicioRef=TipoServicioID) AS 'Tipo de Servicio',
			  A.Avion_TipoDeServicioRef AS ServicioRef
	   FROM THE_BTREES.Avion A
	   WHERE (A.Avion_FechaDeBajaDefinitiva<@Fecha OR A.Avion_FechaDeBajaDefinitiva IS NULL)  AND A.Avion_BajaPorFueraDeServicio=0 AND A.Avion_BajaPorVidaUtil=0

	   END
GO

/***** GetRutasAereasParaCompraList *****/
IF  object_id(N'[THE_BTREES].[GetRutasAereasParaCompraList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetRutasAereasParaCompraList]
GO

CREATE PROCEDURE [THE_BTREES].[GetRutasAereasParaCompraList]		

AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT R.RutaAereaID,
			  R.Ruta_Codigo AS 'Codigo de Ruta',
	          (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS 'Ciudad Destino',
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadOrigenRef) AS 'Ciudad Origen',
			  (SELECT TipoSer_Nombre FROM THE_BTREES.TipoServicio WHERE T.TipoServicioRef=TipoServicioID) AS 'Tipo de Servicio',
			  t.TipoServicioRef AS ServicioRef
	   FROM THE_BTREES.RutaAerea R
	   INNER JOIN THE_BTREES.TipoServicioXRutaAerea T ON T.RutaAereaRef=R.RutaAereaID
	   END
GO

/***** AddViaje *****/
IF  object_id(N'[THE_BTREES].[AddViaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddViaje]
GO

CREATE PROCEDURE [THE_BTREES].[AddViaje]	
	@FechaSalida AS DATETIME,
	@FechaLlegadaEst AS DATETIME,
	@Avion AS INT,
	@RutaAerea AS INT	

AS
    BEGIN
	   SET NOCOUNT ON

	   IF (@Avion IN (SELECT Viaje_AvionRef FROM THE_BTREES.Viaje WHERE @FechaSalida BETWEEN Viaje_FechaSalida AND Viaje_FechaLlegadaEstimada))
			  BEGIN
			  RAISERROR ('Avion Ocupado en otro Viaje', 11,1)
			  RETURN
			  END

	   ELSE	
	   BEGIN
	   INSERT INTO THE_BTREES.Viaje
	           ( Viaje_FechaSalida ,
	             Viaje_AvionRef ,
	             Viaje_RutaAereaRef ,
	             Viaje_FechaLlegadaEstimada
	           )
	   VALUES  ( @FechaSalida,
				 @Avion,
				 @RutaAerea,
				 @FechaLlegadaEst
	           )
	   END
	END
GO


/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LOS VIAJES*/

USE [GD2C2015]
GO

/***** GetViajesDisponiblesList *****/
IF  object_id(N'[THE_BTREES].[GetViajesDisponiblesList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetViajesDisponiblesList]
GO

CREATE PROCEDURE [THE_BTREES].[GetViajesDisponiblesList]		
    @TipoServicio AS TINYINT,
	@Fecha AS DATETIME,
	@CiudadDestino AS SMALLINT,
	@CiudadOrigen AS SMALLINT
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   IF @TipoServicio=0 
			SET @TipoServicio=NULL

	   IF @CiudadDestino=0 
			SET @CiudadDestino=NULL

	   IF @CiudadOrigen=0 
			SET @CiudadOrigen=NULL

		SET @Fecha = CAST(@Fecha AS DATE)

	   IF @Fecha = '2000-01-01'
			SET @Fecha=NULL

	   SELECT V.ViajeID,
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadOrigenRef) AS 'Ciudad Origen',
			  (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=R.Ruta_CiudadDestinoRef) AS 'Ciudad Destino',
			  V.Viaje_FechaSalida AS 'Fecha Salida',
			  V.Viaje_FechaLlegadaEstimada AS 'Fecha LLegada Estimada',
			  T.TipoSer_Nombre AS 'Tipo De Servicio',
			  W.ButacasDisponibles AS 'Cant Butacas Disponibles',
			  '$' + CAST((R.Ruta_PrecioBasePasaje*(1+T.TipoSer_PorcentajeAdicional)) AS varchar) AS 'Precio Pasaje',
			  K.KGDisponibles AS 'Cant KG Disponibles',
			  '$' + CAST(R.Ruta_PrecioBaseKg AS varchar) AS 'Precio por KG'
	   FROM THE_BTREES.Viaje V
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   INNER JOIN THE_BTREES.Avion A ON A.AvionID = V.Viaje_AvionRef AND A.Avion_TipoDeServicioRef=ISNULL(@TipoServicio,a.Avion_TipoDeServicioRef)
	   LEFT JOIN THE_BTREES.Viaje_Pasajes_Vendidos W ON W.Viaje=V.ViajeID
	   LEFT JOIN THE_BTREES.kg_Dispo_Por_Viaje K ON K.ViajeID=V.ViajeID
	   INNER JOIN THE_BTREES.TipoServicio T ON T.TipoServicioID=A.Avion_TipoDeServicioRef
	   WHERE CAST(V.Viaje_FechaSalida AS DATE)=ISNULL(CAST(@Fecha AS DATE),CAST(V.Viaje_FechaSalida AS DATE)) AND 
			 R.Ruta_CiudadDestinoRef=ISNULL(@CiudadDestino,R.Ruta_CiudadDestinoRef) AND 
			 R.Ruta_CiudadOrigenRef=ISNULL(@CiudadOrigen,R.Ruta_CiudadOrigenRef) AND
			 W.ButacasDisponibles>0
	   ORDER BY V.Viaje_FechaSalida
	   END
GO

USE [GD2C2015]
GO

/***** GetButacasDisponiblesViajeList *****/
IF  object_id(N'[THE_BTREES].[GetButacasDisponiblesViajeList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetButacasDisponiblesViajeList]
GO

CREATE PROCEDURE [THE_BTREES].[GetButacasDisponiblesViajeList]		
    @Viaje AS INT
			
AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT B.ButacaID,
			  (CAST(B.Butaca_Numero AS varchar) + (CASE WHEN B.Butaca_EsVentanilla = 1 THEN ' - Ventanilla' 
												   	    WHEN B.Butaca_EsVentanilla = 0 THEN ' - Pasillo' END))  Butaca_Descr
	   FROM THE_BTREES.Butaca B
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID=@Viaje AND Butaca_AvionRef=V.Viaje_AvionRef
	   WHERE B.ButacaID NOT IN (SELECT Pasaje_ButacaRef FROM THE_BTREES.Pasaje WHERE Pasaje_ViajeRef=@Viaje AND Pasaje_CancelacionRef IS NULL)
	   ORDER BY B.Butaca_Numero

	   END
GO

USE [GD2C2015]
GO

/***** GetDatosCliente *****/
IF  object_id(N'[THE_BTREES].[GetDatosCliente]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetDatosCliente]
GO

CREATE PROCEDURE [THE_BTREES].[GetDatosCliente]		
    @nombre AS varchar(50),
	@apellido AS varchar(50),
	@dni AS int
			
AS
    BEGIN
	   SET NOCOUNT ON
	   SELECT ClienteID,
			  Cliente_Nombre,
			  Cliente_Apellido,
			  Cliente_DNI,
			  Cliente_Direccion,
			  Cliente_Telefono,
			  Cliente_Mail,
			  Cliente_FechaNac
	   FROM THE_BTREES.Cliente
	   WHERE Cliente_DNI = @dni AND Cliente_Apellido = @apellido AND Cliente_Nombre = @nombre
	END
GO

USE [GD2C2015]
GO

/***** GetTiposTarjeta *****/
IF  object_id(N'[THE_BTREES].[GetTiposTarjeta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetTiposTarjeta]
GO

CREATE PROCEDURE [THE_BTREES].[GetTiposTarjeta]		
AS
BEGIN
	SELECT t.TipoTarjetaID AS 'TipoTarjetaID', t.TipoTarj_Descripcion AS 'Descripcion'
	FROM THE_BTREES.TiposTarjeta t
END
GO


USE [GD2C2015]
GO

/***** GetCantCuotas *****/
IF  object_id(N'[THE_BTREES].[GetCantCuotas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetCantCuotas]
GO

CREATE PROCEDURE [THE_BTREES].[GetCantCuotas]
	@TipoTarjetaID int,
	@CantCuotas int OUTPUT		
AS
BEGIN
	SELECT @CantCuotas = t.TipoTarj_CuotasMax
	FROM THE_BTREES.TiposTarjeta t
	WHERE t.TipoTarjetaID = @TipoTarjetaID
END
GO

/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LOS CLIENTES*/

USE [GD2C2015]
GO

/***** AddCliente *****/
IF OBJECT_ID(N'[THE_BTREES].[AddCliente]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCliente]
GO

CREATE PROCEDURE [THE_BTREES].[AddCliente]
	@Cliente_DNI varchar(15),
	@Cliente_Nombre varchar(50),
	@Cliente_Apellido varchar(50),
	@Cliente_Direccion varchar(100),
	@Cliente_Telefono int,
	@Cliente_Mail varchar(100),
	@Cliente_FechaNac DateTime,
	@ClienteRef int OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO THE_BTREES.Cliente(
			Cliente_DNI,
			Cliente_Nombre,
			Cliente_Apellido,
			Cliente_Direccion,
			Cliente_Telefono,
			Cliente_Mail,
			Cliente_FechaNac
		)
		VALUES (
 			 @Cliente_DNI,
 			 @Cliente_Nombre,
			 @Cliente_Apellido,
			 @Cliente_Direccion,
			 @Cliente_Telefono,
			 @Cliente_Mail,
			 @Cliente_FechaNac
		)	
		
		SET @ClienteRef = SCOPE_IDENTITY()
END		
GO

USE [GD2C2015]
GO

/***** UpdateCliente *****/
IF OBJECT_ID(N'[THE_BTREES].[UpdateCliente]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[UpdateCliente]
GO

CREATE PROCEDURE [THE_BTREES].[UpdateCliente]
	@ClienteID int,
	@Cliente_DNI varchar(15),
	@Cliente_Nombre varchar(50),
	@Cliente_Apellido varchar(50),
	@Cliente_Direccion varchar(100),
	@Cliente_Telefono int,
	@Cliente_Mail varchar(100),
	@Cliente_FechaNac DateTime	
AS
BEGIN
	SET NOCOUNT ON
	UPDATE THE_BTREES.Cliente 
	SET Cliente_DNI = @Cliente_DNI,
		Cliente_Nombre = @Cliente_Nombre,
		Cliente_Apellido = @Cliente_Apellido,
		Cliente_Direccion = @Cliente_Direccion,
		Cliente_Telefono = @Cliente_Telefono,
		Cliente_Mail = @Cliente_Mail,
		Cliente_FechaNac = @Cliente_FechaNac
	WHERE ClienteID = @ClienteID
END		
GO

/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LAS CANCELACIONES*/

USE [GD2C2015]
GO

/***** GetPasajesDeCompraList *****/
IF  object_id(N'[THE_BTREES].[GetPasajesDeCompraList]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetPasajesDeCompraList]
GO

CREATE PROCEDURE [THE_BTREES].[GetPasajesDeCompraList]		
    @CompraID AS INT,
	@Fecha AS DATETIME
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   SELECT P.PasajeID AS 'Codigo de Pasaje',
			  (SELECT Cliente_Nombre FROM THE_BTREES.Cliente WHERE ClienteID=P.Pasaje_ClienteRef) AS Cliente,
			  (SELECT Butaca_Numero FROM THE_BTREES.Butaca WHERE ButacaID=P.Pasaje_ButacaRef) AS 'Numero de Butaca',
			  P.Pasaje_Precio AS Precio
	   FROM THE_BTREES.Pasaje P
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = P.Pasaje_ViajeRef 
	   WHERE P.Pasaje_CompraRef=@CompraID AND P.Pasaje_CancelacionRef IS NULL AND V.Viaje_FechaSalida>@Fecha
	   ORDER BY P.PasajeID
	   END
GO

USE [GD2C2015]
GO

/***** GetEncomiendaKGCompra *****/
IF  object_id(N'[THE_BTREES].[GetEncomiendaKGCompra]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetEncomiendaKGCompra]
GO

CREATE PROCEDURE [THE_BTREES].[GetEncomiendaKGCompra]		
    @CompraID AS INT,
	@Fecha AS DATETIME,
	@CantKg AS SMALLINT OUTPUT
	
AS
    BEGIN
	   SET NOCOUNT ON	
	   
	   DECLARE @kg SMALLINT
	   SELECT @kg=E.Enco_KG
	   FROM THE_BTREES.Encomienda E
	   INNER JOIN THE_BTREES.Viaje V ON V.ViajeID = E.Enco_ViajeRef 
	   WHERE E.Enco_CompraRef=@CompraID AND Enco_CancelacionRef IS NULL AND V.Viaje_FechaSalida>@Fecha

	   SELECT @CantKg=ISNULL(@kg,0)
	   
	   END
GO

/***** AddCancelacion *****/
IF  object_id(N'[THE_BTREES].[AddCancelacion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCancelacion]
GO

CREATE PROCEDURE [THE_BTREES].[AddCancelacion]		
    @CancelID AS INT OUTPUT,
	@CompraID AS INT,
	@Motivo AS VARCHAR(50),
	@Fecha AS DATETIME,
	@CancelEco bit
	
AS
    BEGIN
	   SET NOCOUNT ON	

	   INSERT INTO THE_BTREES.Cancelacion
	           ( Cance_CompraRef ,
	             Cance_Fecha ,
	             Motivo
	           )
	   VALUES  ( @CompraID,
	             @Fecha,
	             @Motivo
	           )
	   
	   SET @CancelID=SCOPE_IDENTITY()

	   IF @CancelEco=1
		 BEGIN
			UPDATE THE_BTREES.Encomienda
			SET Enco_CancelacionRef=@CancelID
			WHERE Enco_CompraRef=@CompraID
		 RETURN
		 END		   
	   END
GO

/***** CancelarPasaje *****/
IF  object_id(N'[THE_BTREES].[CancelarPasaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[CancelarPasaje]
GO

CREATE PROCEDURE [THE_BTREES].[CancelarPasaje]		
    @CancelID AS INT,
	@PasajeID AS INT
	
AS
    BEGIN
	   SET NOCOUNT ON	

    	UPDATE THE_BTREES.Pasaje
	    SET Pasaje_CancelacionRef=@CancelID
	    WHERE PasajeID=@PasajeID
  
	   END
GO

/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LOS ROLES Y SUS FUNCIONALIDADES*/


IF  object_id(N'[THE_BTREES].[TraerRolConFuncionalidades]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerRolConFuncionalidades]
GO

CREATE PROCEDURE THE_BTREES.TraerRolConFuncionalidades
	@RolID INT
AS
	SELECT r.Rol_Nombre, fr.FuncionalidadRef as FuncionalidadRef, r.Rol_Activo FROM THE_BTREES.Roles r 
	JOIN THE_BTREES.FuncionalidadesXRoles fr ON r.RolID = fr.RolRef
	WHERE @RolID = r.RolID
GO

USE GD2C2015
GO

/***** TraerFuncionalidadesDeUsuario *****/
IF  object_id(N'[THE_BTREES].[TraerFuncionalidadesDeUsuario]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerFuncionalidadesDeUsuario]
GO

CREATE PROCEDURE [THE_BTREES].[TraerFuncionalidadesDeUsuario]		
	@usuarioID int
AS
BEGIN
	SELECT f.Funcionalidad_Nombre AS 'Funcionalidad'
	FROM THE_BTREES.RolesXUsuarios ru
	INNER JOIN THE_BTREES.FuncionalidadesXRoles fr ON ru.RolRef = fr.RolRef
	INNER JOIN THE_BTREES.Funcionalidades f ON fr.FuncionalidadRef = f.FuncionalidadID
	WHERE ru.UsuarioRef = @usuarioID
END
GO

/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LAS COMPRAS*/

USE [GD2C2015]
GO

CREATE TYPE [THE_BTREES].[ClienteDT] AS TABLE
(
    ClienteID int,
    Cliente_DNI varchar(15),
    Cliente_Nombre varchar(50),
	Cliente_Apellido varchar(50),
    Cliente_Direccion varchar(100),
    Cliente_Telefono int,
    Cliente_Mail varchar(100),
    Cliente_FechaNac DateTime
)

CREATE TYPE [THE_BTREES].[PasajeroDT] AS TABLE
(
    ClienteID int,
    Cliente_DNI varchar(15),
    Cliente_Nombre varchar(50),
	Cliente_Apellido varchar(50),
    Cliente_Direccion varchar(100),
    Cliente_Telefono int,
    Cliente_Mail varchar(100),
    Cliente_FechaNac DateTime,
	ButacaRef int
)

/***** AddCompra *****/
IF OBJECT_ID(N'[THE_BTREES].[AddCompra]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCompra]
GO

CREATE PROCEDURE [THE_BTREES].[AddCompra]
	@efectivo AS bit,
	@cantCuotas AS tinyint = NULL,
	@tipoTarjeta AS int = NULL,
	@numTarjeta AS varchar(20) = NULL,
	@codSeg AS int = NULL,
	@fechaVenc AS datetime = NULL,
	@fechaActual AS datetime,
	@dtComprador THE_BTREES.ClienteDT READONLY,
	@compraID int OUTPUT

AS
	BEGIN
		SET NOCOUNT ON
		DECLARE @ClienteID int,
				@Cliente_DNI varchar(15),
				@Cliente_Nombre varchar(50),
				@Cliente_Apellido varchar(50),
				@Cliente_Direccion varchar(100),
				@Cliente_Telefono int,
				@Cliente_Mail varchar(100),
				@Cliente_FechaNac DateTime

		SET @ClienteID = (SELECT ClienteID FROM @dtComprador)
		SET	@Cliente_DNI = (SELECT Cliente_DNI FROM @dtComprador)
		SET	@Cliente_Nombre = (SELECT Cliente_Nombre FROM @dtComprador)
		SET	@Cliente_Apellido = (SELECT Cliente_Apellido FROM @dtComprador)
		SET	@Cliente_Direccion = (SELECT Cliente_Direccion FROM @dtComprador)
		SET	@Cliente_Telefono = (SELECT Cliente_Telefono FROM @dtComprador)
		SET	@Cliente_Mail = (SELECT Cliente_Mail FROM @dtComprador)
		SET	@Cliente_FechaNac = (SELECT Cliente_FechaNac FROM @dtComprador)

		IF @ClienteID = 0
			EXEC THE_BTREES.AddCliente
				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac,
				@ClienteRef = @ClienteID OUTPUT
		ELSE
			EXEC THE_BTREES.UpdateCliente
				@ClienteID,
 				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac

		INSERT INTO THE_BTREES.Compra (
			Compra_Fecha,
			Compra_AbonaEnEfectivo,
			Compra_CantCuotas,
			Compra_TipoTarjetaRef,
			Compra_NumTarjeta,
			Compra_CodSeg,
			Compra_FechaVencimiento,
			Compra_CompradorRef
		)
		VALUES (
			CAST(@fechaActual AS date),
			@efectivo,
			@cantCuotas,
			@tipoTarjeta,
			@numTarjeta,
			@codSeg,
			@fechaVenc,
			@ClienteID
		)	
		
		SET @compraID = SCOPE_IDENTITY()

	END
GO

USE [GD2C2015]
GO

/***** AddEncomienda *****/
IF OBJECT_ID(N'[THE_BTREES].[AddEncomienda]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddEncomienda]
GO

CREATE PROCEDURE [THE_BTREES].[AddEncomienda]
	@kg AS smallint,
	@precio AS numeric(18,2),
	@compraRef AS int,
	@viajeRef AS int,
	@dtResponsable AS THE_BTREES.ClienteDT READONLY
AS 
	SET NOCOUNT ON
	BEGIN
		DECLARE @ClienteID int,
				@Cliente_DNI varchar(15),
				@Cliente_Nombre varchar(50),
				@Cliente_Apellido varchar(50),
				@Cliente_Direccion varchar(100),
				@Cliente_Telefono int,
				@Cliente_Mail varchar(100),
				@Cliente_FechaNac DateTime

		SET @ClienteID = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_DNI = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Nombre = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Apellido = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Direccion = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Telefono = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_Mail = (SELECT ClienteID FROM @dtResponsable)
		SET	@Cliente_FechaNac = (SELECT ClienteID FROM @dtResponsable)

		IF @ClienteID = 0
			EXEC THE_BTREES.AddCliente
				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac,
				@ClienteRef = @ClienteID OUTPUT
		ELSE
			EXEC THE_BTREES.UpdateCliente
				@ClienteID,
 				@Cliente_DNI,
 				@Cliente_Nombre,
				@Cliente_Apellido,
				@Cliente_Direccion,
				@Cliente_Telefono,
				@Cliente_Mail,
				@Cliente_FechaNac

		INSERT INTO THE_BTREES.Encomienda (
			Enco_KG,
			Enco_Precio,
			Enco_CompraRef,
			Enco_ClienteRespRef,
			Enco_ViajeRef
		)
		VALUES (
			@kg,
			@precio,
			@compraRef,
			@ClienteID,
			@viajeRef
		)
	END
GO

USE [GD2C2015]
GO

/***** AddPasaje *****/
IF OBJECT_ID(N'[THE_BTREES].[AddPasaje]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddPasaje]
GO

CREATE PROCEDURE [THE_BTREES].[AddPasaje]
	@precio AS numeric(18,2),
	@compraRef AS int,
	@viajeRef AS int,
	@dtPasajeros AS THE_BTREES.PasajeroDT READONLY
AS 
	SET NOCOUNT ON
	BEGIN
		DECLARE @ClienteID int,
				@Cliente_DNI varchar(15),
				@Cliente_Nombre varchar(50),
				@Cliente_Apellido varchar(50),
				@Cliente_Direccion varchar(100),
				@Cliente_Telefono int,
				@Cliente_Mail varchar(100),
				@Cliente_FechaNac DateTime,
				@ButacaRef int
		DECLARE psj_cursor CURSOR FOR SELECT * FROM @dtPasajeros
		OPEN psj_cursor

		FETCH NEXT FROM psj_cursor 
		INTO @ClienteID,
 			 @Cliente_DNI,
 			 @Cliente_Nombre,
			 @Cliente_Apellido,
			 @Cliente_Direccion,
			 @Cliente_Telefono,
			 @Cliente_Mail,
			 @Cliente_FechaNac,
			 @ButacaRef

		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF @ClienteID = 0
				EXEC THE_BTREES.AddCliente
					@Cliente_DNI,
 					@Cliente_Nombre,
					@Cliente_Apellido,
					@Cliente_Direccion,
					@Cliente_Telefono,
					@Cliente_Mail,
					@Cliente_FechaNac,
					@ClienteRef = @ClienteID OUTPUT
			ELSE
				EXEC THE_BTREES.UpdateCliente
					@ClienteID,
 					@Cliente_DNI,
 					@Cliente_Nombre,
					@Cliente_Apellido,
					@Cliente_Direccion,
					@Cliente_Telefono,
					@Cliente_Mail,
					@Cliente_FechaNac

			INSERT INTO THE_BTREES.Pasaje (
				Pasaje_ButacaRef,
				Pasaje_Precio,
				Pasaje_CompraRef,
				Pasaje_ClienteRef,
				Pasaje_ViajeRef
			)
			VALUES (
				@ButacaRef,
				@precio,
				@compraRef,
				@ClienteID,
				@viajeRef
			)

			FETCH NEXT FROM psj_cursor 
			INTO @ClienteID,
 				 @Cliente_DNI,
 				 @Cliente_Nombre,
				 @Cliente_Apellido,
				 @Cliente_Direccion,
				 @Cliente_Telefono,
				 @Cliente_Mail,
				 @Cliente_FechaNac,
				 @ButacaRef
		END
		
		CLOSE psj_cursor;
		DEALLOCATE psj_cursor;	
	END
GO


/****************************************************************************************************************************/
/*CREACION DE LOS PROCEDURE PARA EL MANEJO DE LOS ROLES*/

USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[Deshabilitar_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Deshabilitar_Rol]
GO

IF  object_id(N'[THE_BTREES].[Modificar_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Modificar_Rol]
GO

IF  object_id(N'[THE_BTREES].[Crear_Rol]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Crear_Rol]
GO

IF TYPE_ID(N'[THE_BTREES].[IntList]') IS NOT NULL
	DROP TYPE [THE_BTREES].[IntList]
GO



CREATE TYPE [THE_BTREES].[IntList] AS TABLE(
    [Item] [INT] NOT NULL
)
GO

CREATE PROCEDURE THE_BTREES.Crear_Rol
	@Rol_Nombre VARCHAR(60),
	@Rol_Activo BIT,
	@funcionalidadesSeleccionadas [THE_BTREES].[IntList] READONLY
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.Roles (Rol_Nombre, Rol_Activo) VALUES (@Rol_Nombre, @Rol_Activo)
	DECLARE @RolRef tinyint

	SET  @RolRef = SCOPE_IDENTITY()

	INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, funcionalidadRef) 
	SELECT @RolRef, Item FROM @funcionalidadesSeleccionadas
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Modificar_Rol
	@RolID INT,
	@Rol_Nombre VARCHAR(60),
	@funcionalidadesSeleccionadas [THE_BTREES].[IntList] READONLY,
	@Rol_Activo BIT
AS
	BEGIN TRAN
	UPDATE THE_BTREES.Roles SET 
		Rol_Activo = @Rol_Activo, 
		Rol_Nombre = @Rol_Nombre
	 WHERE @RolID = RolID

	 DELETE FROM THE_BTREES.FuncionalidadesXRoles WHERE @RolID = RolRef

	 INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, FuncionalidadRef)
		SELECT @RolID, Item FROM @funcionalidadesSeleccionadas
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Deshabilitar_Rol
	@RolID INT
AS
	UPDATE THE_BTREES.Roles SET Rol_Activo = 0 WHERE @RolID = RolID
GO

IF  object_id(N'[THE_BTREES].[Listar_Roles]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Listar_Roles]
GO

create PROCEDURE [THE_BTREES].[Listar_Roles]
	( @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='SELECT DISTINCT r.RolID, r.Rol_Nombre, r.Rol_Activo FROM THE_BTREES.Roles r, THE_BTREES.FuncionalidadesXRoles fr WHERE r.RolID = fr.RolRef ' + @WhereClause
	execute (@sentencia)

GO

/****************************************************************************************************************************/
/*CREACION DE FUNCIONES GENERICAS UTILIZADAS*/



IF  object_id(N'[THE_BTREES].[ExistsNameWithOtherID]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].[ExistsNameWithOtherID]
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



IF  object_id(N'[THE_BTREES].[codigoRutaYaExistente]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].codigoRutaYaExistente
GO

CREATE FUNCTION THE_BTREES.codigoRutaYaExistente 
	(@CodigoRuta INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.RutaAerea 
	WHERE @CodigoRuta = Ruta_Codigo;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[tieneViajeProgramado]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].tieneViajeProgramado
GO

CREATE FUNCTION THE_BTREES.tieneViajeProgramado 
	(@RutaID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.Viaje 
	WHERE @RutaID = Viaje_RutaAereaRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[tienePasajesVendidos]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].tienePasajesVendidos
GO

CREATE FUNCTION THE_BTREES.tienePasajesVendidos 
	(@RutaID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) 
		FROM THE_BTREES.Pasaje p JOIN
			THE_BTREES.Viaje v ON p.Pasaje_ViajeRef = v.ViajeID			 
	WHERE @RutaID = v.Viaje_RutaAereaRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[tieneEncomiendasVendidas]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].tieneEncomiendasVendidas
GO

CREATE FUNCTION THE_BTREES.tieneEncomiendasVendidas 
	(@RutaID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) 
		FROM THE_BTREES.Encomienda e JOIN
			THE_BTREES.Viaje v ON e.Enco_ViajeRef = v.ViajeID			 
	WHERE @RutaID = v.Viaje_RutaAereaRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[aeronaveTieneViajesAsignados]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].aeronaveTieneViajesAsignados
GO

CREATE FUNCTION THE_BTREES.aeronaveTieneViajesAsignados 
	(@AvionID INT)
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) 
		FROM THE_BTREES.Viaje v 
		WHERE @AvionID = v.Viaje_AvionRef;

	IF(@Cantidad > 0)
		RETURN 1;

	RETURN 0;
END
GO

IF  object_id(N'[THE_BTREES].[matriculaYaExistente]','FN') IS NOT NULL
	DROP FUNCTION [THE_BTREES].matriculaYaExistente
GO

CREATE FUNCTION THE_BTREES.matriculaYaExistente 
	(@Matricula NVARCHAR(255))
	RETURNS BIT
AS
BEGIN
	DECLARE @Cantidad INT;

	SELECT @Cantidad = COUNT(*) FROM THE_BTREES.Avion 
	WHERE Avion_Matricula = @Matricula;

	IF @Cantidad > 0
		RETURN 1;

	RETURN 0;
END
GO


/****************************************************************************************************************************/
/*CREACION DE PROCEDURES PARA EL REGISTRO DE LLEGADA*/


/***** RegistrarLlegadaViaje *****/
IF  object_id(N'[THE_BTREES].[RegistrarLlegadaViaje]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[RegistrarLlegadaViaje]
GO

CREATE PROCEDURE [THE_BTREES].[RegistrarLlegadaViaje]		
	@AvionID int,
	@CiudadOrigen SMALLINT,
	@CiudadDestino SMALLINT,
	@FechaLlegada DATETIME,
	@FechaActual DATETIME,
	@Resultado VARCHAR(100) OUTPUT	
AS
    BEGIN
	   SET NOCOUNT ON

	   DECLARE @RutaAerea SMALLINT
	   DECLARE @DestinoReal SMALLINT
	   DECLARE @ViajeID INT
	   DECLARE @FechaLlegadatab DATETIME
	  
	   SELECT @DestinoReal=R.Ruta_CiudadDestinoRef, @RutaAerea=RutaAereaID, @ViajeID=V.ViajeID, @FechaLlegadatab=v.Viaje_FechaLlegada 
	   FROM THE_BTREES.Viaje V
	   INNER JOIN THE_BTREES.RutaAerea R ON R.RutaAereaID = V.Viaje_RutaAereaRef
	   WHERE V.Viaje_AvionRef=@AvionID AND V.Viaje_FechaSalida BETWEEN DATEADD(HOUR,-24,@FechaLlegada) AND @FechaLlegada 
			 AND R.Ruta_CiudadOrigenRef=@CiudadOrigen
	   
	   IF @DestinoReal IS NULL OR @RutaAerea IS NULL
			 BEGIN
			 SET @Resultado='No existe un viaje con los parametros ingresados'
			 RETURN
			 END

	   IF @FechaLlegadatab IS NOT NULL
		BEGIN
		SET @Resultado='La llegada del viaje ya se encontraba registrada'
		RETURN
		END
	   
	   UPDATE THE_BTREES.Viaje
	   SET Viaje_FechaLlegada=@FechaLlegada
	   WHERE ViajeID=@ViajeID

	   INSERT INTO THE_BTREES.TransaccionesMillas
	   ( Tran_CanjeRef ,Tran_ClienteRef ,Tran_EncomiendaRef ,Tran_PasajeRef ,Tran_CantidadMillas ,Tran_Fecha)
	   SELECT NULL, Pasaje_ClienteRef,NULL,PasajeID,CAST(CAST(Pasaje_Precio AS FLOAT)/10 AS INT),@FechaActual 
	   FROM THE_BTREES.Pasaje P
	   WHERE P.Pasaje_ViajeRef=@ViajeID

	   INSERT INTO THE_BTREES.TransaccionesMillas
	   ( Tran_CanjeRef ,Tran_ClienteRef ,Tran_EncomiendaRef ,Tran_PasajeRef ,Tran_CantidadMillas ,Tran_Fecha)
	   SELECT NULL, E.Enco_ClienteRespRef,E.EncomiendaID,NULL,CAST(CAST(Enco_Precio AS FLOAT)/10 AS INT),@FechaActual 
	   FROM THE_BTREES.Encomienda E
	   WHERE E.Enco_ViajeRef=@ViajeID
	   
	   IF @CiudadDestino=@DestinoReal
			BEGIN
			SET @Resultado='El avion arribo a la ciudad que le correspondía'
			END
		ELSE
			BEGIN
			SET @Resultado= 'El avión arribo a una ciudad erronea. Debia llegar a ' + (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad WHERE CiudadID=@DestinoReal)
			END
		
	   END
GO

/****************************************************************************************************************************/
/*CREACION DE TRIGGER PARA REMOVER ROLES INHABILITADOS*/


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


/****************************************************************************************************************************/
/*CREACION DE PROCEDURE PARA EL MANEJO DE MILLAS Y SU CANJE */

USE GD2C2015
GO

/***** GetCantMillasDisponibles *****/
IF OBJECT_ID(N'[THE_BTREES].[GetCantMillasDisponibles]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetCantMillasDisponibles]
GO

CREATE PROCEDURE [THE_BTREES].[GetCantMillasDisponibles]
	@Apellido varchar(50), 
	@DNI varchar(15),
	@Fecha datetime,
	@ClienteRef int OUTPUT,
	@CantMillasDisponibles int OUTPUT
AS
BEGIN
	SELECT @ClienteRef=ClienteID FROM THE_BTREES.Cliente 
	WHERE Cliente_Apellido=@Apellido AND Cliente_DNI=@DNI
	
	DECLARE 
		@Tran_CanjeRef int,
		@CantidadMillas int,
		@Tran_Fecha datetime
	SET @CantMillasDisponibles=0		

	SET @CantMillasDisponibles = 0
	
	DECLARE cursorTrans CURSOR FOR  SELECT M.Tran_CanjeRef, M.Tran_CantidadMillas, M.Tran_Fecha
									FROM THE_BTREES.TransaccionesMillas M
									WHERE M.Tran_ClienteRef = @ClienteRef
	OPEN cursorTrans

	FETCH NEXT FROM cursorTrans
	INTO 
		@Tran_CanjeRef,
		@CantidadMillas,
		@Tran_Fecha

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF DATEDIFF(day,@Tran_Fecha,@Fecha) < 365
		BEGIN
			IF @Tran_CanjeRef IS NULL
			BEGIN
				SET @CantMillasDisponibles = @CantMillasDisponibles + @CantidadMillas
			END
			ELSE
			BEGIN
				SET @CantMillasDisponibles = @CantMillasDisponibles - @CantidadMillas
			END
		END

		FETCH NEXT FROM cursorTrans
		INTO 
			@Tran_CanjeRef,
			@CantidadMillas,
			@Tran_Fecha
	END

END
GO

USE GD2C2015
GO

/***** GetListadoTransaccionesMillas *****/
IF OBJECT_ID(N'[THE_BTREES].[GetListadoTransaccionesMillas]','p') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetListadoTransaccionesMillas]
GO

CREATE PROCEDURE [THE_BTREES].[GetListadoTransaccionesMillas]
	@ClienteRef int,
	@Fecha datetime
AS
BEGIN
	SELECT CASE WHEN T.Tran_PasajeRef IS NOT NULL THEN 'Pasaje' 
				WHEN T.Tran_EncomiendaRef IS NOT NULL THEN 'Ecomienda'
				WHEN T.Tran_CanjeRef IS NOT NULL THEN 'Canje'
		   END AS 'Transaccion',
		   CASE WHEN T.Tran_PasajeRef IS NOT NULL THEN T.Tran_PasajeRef 
				WHEN T.Tran_EncomiendaRef IS NOT NULL THEN T.Tran_EncomiendaRef
				WHEN T.Tran_CanjeRef IS NOT NULL THEN T.Tran_CanjeRef
		   END AS 'Codigo',
		   T.Tran_Fecha AS 'Fecha',
		   T.Tran_CantidadMillas AS 'Cantidad de millas'
	FROM TransaccionesMillas T
	WHERE DATEDIFF(day,T.Tran_Fecha,@Fecha)<365
END
GO

/***** GetProductosDisponibles *****/
IF  object_id(N'[THE_BTREES].[GetProductosDisponibles]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[GetProductosDisponibles]
GO

CREATE PROCEDURE [THE_BTREES].[GetProductosDisponibles]		
	@CantMillas int
AS
    BEGIN
	   SET NOCOUNT ON

	   SELECT ProductoID,
			  Producto_Descripcion,
		      Producto_Stock,
			  Producto_Millas			   
	   FROM THE_BTREES.Producto
	   WHERE Producto_Millas<=@CantMillas AND Producto_Stock>0
	
	   END
GO

/***** AddCanjeProducto *****/
IF  object_id(N'[THE_BTREES].[AddCanjeProducto]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[AddCanjeProducto]
GO

CREATE PROCEDURE [THE_BTREES].[AddCanjeProducto]
	@ClienteID INT,
	@ProductoID INT,
	@MillasCanje INT,
	@CantProducto INT,
	@Fecha DATETIME 		
AS
    BEGIN
	   SET NOCOUNT ON

	   INSERT INTO THE_BTREES.Canje
	           ( Canje_ClienteRef ,
	             Canje_ProductoRef ,
	             Canje_CantidadProducto ,
	             Canje_Fecha
	           )
	   VALUES  ( @ClienteID,
	             @ProductoID , 
	             @CantProducto , 
	             @Fecha
	           )
	   
		DECLARE @CanjeID INT
		SET @CanjeID=SCOPE_IDENTITY()

		UPDATE THE_BTREES.Producto
		SET Producto_Stock=Producto_Stock-@CantProducto
		WHERE ProductoID=@ProductoID

		INSERT INTO THE_BTREES.TransaccionesMillas
		        ( Tran_CanjeRef ,
		          Tran_ClienteRef ,
		          Tran_EncomiendaRef ,
		          Tran_PasajeRef ,
		          Tran_CantidadMillas ,
		          Tran_Fecha
		        )
		VALUES  ( @CanjeID , 
		          @ClienteID , 
		          NULL , 
		          NULL , 
		          @MillasCanje ,
				  @Fecha
		        )	
	   END
GO

/****************************************************************************************************************************/
/*CREACION DE PROCEDURE PARA EL MANEJO DE LAS RUTAS */


USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[Deshabilitar_Ruta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Deshabilitar_Ruta]
GO

IF  object_id(N'[THE_BTREES].[Modificar_Ruta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Modificar_Ruta]
GO

IF  object_id(N'[THE_BTREES].[Crear_Ruta]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Crear_Ruta]
GO


CREATE PROCEDURE THE_BTREES.Crear_Ruta
	@Ruta_Codigo numeric(18, 0),
	@Ruta_CiudadOrigenRef SMALLINT,
	@Ruta_CiudadDestinoRef SMALLINT,
	@Ruta_PrecioBaseKg numeric(18, 2),
	@Ruta_PrecioBasePasaje numeric(18, 2),
	@Ruta_Activo BIT,
	@ServiciosSeleccionados [THE_BTREES].[IntList] READONLY
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.RutaAerea(Ruta_Codigo, Ruta_CiudadOrigenRef, Ruta_CiudadDestinoRef, Ruta_PrecioBaseKg, Ruta_PrecioBasePasaje, Ruta_Activo) VALUES
	 (@Ruta_Codigo, @Ruta_CiudadOrigenRef, @Ruta_CiudadDestinoRef, @Ruta_PrecioBaseKg, @Ruta_PrecioBasePasaje, @Ruta_Activo)

	DECLARE @RutaRef tinyint

	SET  @RutaRef = SCOPE_IDENTITY()

	INSERT INTO THE_BTREES.TipoServicioXRutaAerea (RutaAereaRef, TipoServicioRef) 
	SELECT @RutaRef, Item FROM @ServiciosSeleccionados
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Modificar_Ruta
	@RutaAereaID INT,
	@Ruta_Codigo numeric(18, 0),
	@Ruta_CiudadOrigenRef SMALLINT,
	@Ruta_CiudadDestinoRef SMALLINT,
	@Ruta_PrecioBaseKg numeric(18, 2),
	@Ruta_PrecioBasePasaje numeric(18, 2),
	@Ruta_Activo BIT,
	@ServiciosSeleccionados [THE_BTREES].[IntList] READONLY
AS
	BEGIN TRAN
	UPDATE THE_BTREES.RutaAerea SET 
		Ruta_CiudadOrigenRef = @Ruta_CiudadOrigenRef, Ruta_CiudadDestinoRef = @Ruta_CiudadDestinoRef, 
		Ruta_PrecioBaseKg = @Ruta_PrecioBaseKg, Ruta_PrecioBasePasaje = @Ruta_PrecioBasePasaje, Ruta_Activo = @Ruta_Activo
	 WHERE @RutaAereaID = RutaAereaID

	 DELETE FROM THE_BTREES.TipoServicioXRutaAerea WHERE @RutaAereaID = RutaAereaRef

	 INSERT INTO THE_BTREES.TipoServicioXRutaAerea (RutaAereaRef, TipoServicioRef)
		SELECT @RutaAereaID, Item FROM @ServiciosSeleccionados
	COMMIT TRAN
GO

CREATE PROCEDURE THE_BTREES.Deshabilitar_Ruta
	@RutaID INT,
	@FechaActual DATE
AS
BEGIN
	DECLARE @CompraID int,
			@CancelacionRef int

	DECLARE cursorCancelacion CURSOR FOR SELECT DISTINCT c.CompraID 
										 FROM THE_BTREES.Compra c 
										 INNER JOIN (
													 SELECT p.Pasaje_CompraRef AS CompreRef
													 FROM THE_BTREES.Pasaje p INNER JOIN THE_BTREES.Viaje v ON p.Pasaje_ViajeRef=v.ViajeID
									   				 WHERE v.Viaje_RutaAereaRef=@RutaID AND v.Viaje_FechaSalida>@FechaActual
													 UNION
													 SELECT e.Enco_CompraRef AS ComprRef  
													 FROM THE_BTREES.Encomienda e INNER JOIN THE_BTREES.Viaje v ON e.Enco_ViajeRef=v.ViajeID
									   				 WHERE v.Viaje_RutaAereaRef=@RutaID AND v.Viaje_FechaSalida>@FechaActual
													 ) r
									     ON c.CompraID = r.CompreRef

	BEGIN TRAN
	OPEN cursorCancelacion
	FETCH NEXT FROM cursorCancelacion INTO @CompraID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO THE_BTREES.Cancelacion 
		(
			Cance_CompraRef,Cance_Fecha,Motivo
		)
		VALUES
		(
			@CompraID,@FechaActual,'Baja de la Ruta Aerea asignada.'
		)
		SET @CancelacionRef = SCOPE_IDENTITY()
		
		UPDATE THE_BTREES.Pasaje
		SET Pasaje_CancelacionRef=@CancelacionRef
		WHERE Pasaje_CompraRef=@CompraID

		UPDATE THE_BTREES.Encomienda
		SET Enco_CancelacionRef=@CancelacionRef
		WHERE Enco_CompraRef=@CompraID

		FETCH NEXT FROM cursorCancelacion INTO @CompraID
	END
	UPDATE THE_BTREES.RutaAerea SET Ruta_Activo = 0 WHERE @RutaID = RutaAereaID

	COMMIT TRAN
END
GO

IF  object_id(N'[THE_BTREES].[Listar_Rutas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[Listar_Rutas]
GO

create PROCEDURE [THE_BTREES].[Listar_Rutas]
	( @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia='SELECT DISTINCT r.RutaAereaID, r.Ruta_Codigo, co.Ciudad_Nombre, cd.Ciudad_Nombre, r.Ruta_PrecioBasePasaje, r.Ruta_PrecioBaseKg, r.Ruta_Activo '
	+ 'FROM THE_BTREES.RutaAerea r, THE_BTREES.Ciudad co, THE_BTREES.Ciudad cd, THE_BTREES.TipoServicioXRutaAerea ts ' 
	+ 'WHERE r.Ruta_CiudadOrigenRef = co.CiudadID AND r.Ruta_CiudadDestinoRef = cd.CiudadID AND ts.RutaAereaRef = r.RutaAereaID'
	+ @WhereClause
	+ 'ORDER BY r.RutaAereaID'
	execute (@sentencia)
GO


IF  object_id(N'[THE_BTREES].[TraerRutaConServicios]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[TraerRutaConServicios]
GO

CREATE PROCEDURE THE_BTREES.TraerRutaConServicios
	@RutaID INT
AS
	SELECT r.Ruta_Codigo, r.Ruta_CiudadOrigenRef, r.Ruta_CiudadDestinoRef, r.Ruta_PrecioBasePasaje, r.Ruta_PrecioBaseKg, r.Ruta_Activo, ts.TipoServicioRef 
	FROM THE_BTREES.RutaAerea r, THE_BTREES.Ciudad co, THE_BTREES.Ciudad cd, THE_BTREES.TipoServicioXRutaAerea ts 
	WHERE r.Ruta_CiudadOrigenRef = co.CiudadID AND r.Ruta_CiudadDestinoRef = cd.CiudadID AND ts.RutaAereaRef = r.RutaAereaID AND @RutaID = RutaAereaID
GO

/****************************************************************************************************************************/
/*CREACION DE PROCEDURE PARA EL MANEJO DE LAS AERONAVES */

USE [GD2C2015]
GO

IF  object_id(N'[THE_BTREES].[AutoCrear_Butacas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].AutoCrear_Butacas
GO

CREATE PROCEDURE THE_BTREES.AutoCrear_Butacas
	@AvionID INT,
	@Butacas_Pasillo INT,
	@Butacas_Ventana INT
AS
	BEGIN TRAN
	DECLARE @Butaca_nro INT
	SET @Butaca_nro = 1
	DECLARE @VALUES1 NVARCHAR(MAX)
	
	SET @VALUES1 = '(' + CAST(@AvionID AS NVARCHAR) + ',0,0)'
	WHILE @Butacas_Pasillo > @Butaca_nro
	BEGIN
		SET @VALUES1 = @VALUES1 + ',(' + CAST(@AvionID AS NVARCHAR) + ',' + CAST(@Butaca_nro AS NVARCHAR) + ',0)'
		SET @Butaca_nro = @Butaca_nro + 1;
	END;

	DECLARE @LastPasillo INT
	SET @LastPasillo = @Butaca_nro
	SET @Butaca_nro = 0
	DECLARE @VALUES2 NVARCHAR(MAX)
	SET @VALUES2 = ''
	WHILE @Butacas_Ventana > @Butaca_nro
	BEGIN
		SET @VALUES2 = @VALUES2 + ',(' + CAST(@AvionID AS NVARCHAR) + ',' + CAST(@Butaca_nro + @LastPasillo AS NVARCHAR) + ',1)'
		SET @Butaca_nro = @Butaca_nro + 1;
	END;

	EXEC ('INSERT INTO THE_BTREES.Butaca (Butaca_AvionRef, Butaca_Numero, Butaca_EsVentanilla) VALUES ' + @VALUES1 + @VALUES2)
	COMMIT TRAN
GO


IF  object_id(N'[THE_BTREES].[Listar_Aviones]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].Listar_Aviones
GO

create PROCEDURE [THE_BTREES].Listar_Aviones
	( @WhereClause VARCHAR(MAX) )
as
	declare @sentencia nvarchar(MAX)
	set @sentencia=
	'SELECT DISTINCT a.AvionID, a.Avion_Matricula, a.Avion_Fabricante, a.Avion_Modelo, s.TipoSer_Nombre, COUNT(*) Butacas, a.Avion_CantidadKgsDisponibles,
				a.Avion_FechaDeAlta, a.Avion_BajaPorFueraDeServicio, a.Avion_BajaPorVidaUtil, a.Avion_FechaDeBajaDefinitiva
	FROM THE_BTREES.Avion a
		JOIN THE_BTREES.Butaca b ON a.AvionID = b.Butaca_AvionRef 
		JOIN THE_BTREES.TipoServicio s ON a.Avion_TipoDeServicioRef = s.TipoServicioID '  + @WhereClause + 
	'GROUP BY a.AvionID, a.Avion_Matricula, a.Avion_Modelo, a.Avion_Fabricante, s.TipoSer_Nombre, a.Avion_CantidadKgsDisponibles,
			a.Avion_FechaDeAlta, a.Avion_BajaPorFueraDeServicio, a.Avion_BajaPorVidaUtil, a.Avion_FechaDeBajaDefinitiva'
	execute (@sentencia)
GO


IF  object_id(N'[THE_BTREES].[Crear_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].Crear_Avion
GO

CREATE PROCEDURE THE_BTREES.Crear_Avion
	@Avion_FechaDeAlta DATE, 
	@Avion_Modelo NVARCHAR(255), 
	@Avion_Matricula NVARCHAR(255), 
	@Avion_Fabricante NVARCHAR(255), 
	@Avion_TipoDeServicioRef TINYINT, 
	@Avion_CantidadKgsDisponibles NUMERIC(18,0),
	@Butacas_Pasillo INT,
	@Butacas_Ventana INT
AS

	BEGIN TRAN
	INSERT INTO THE_BTREES.Avion (Avion_FechaDeAlta, Avion_Modelo, Avion_Matricula, Avion_Fabricante, Avion_TipoDeServicioRef, Avion_BajaPorFueraDeServicio,
								Avion_BajaPorVidaUtil, Avion_FechaDeBajaDefinitiva, Avion_CantidadKgsDisponibles) VALUES 
		(@Avion_FechaDeAlta, @Avion_Modelo, @Avion_Matricula, @Avion_Fabricante, @Avion_TipoDeServicioRef, 0, 0, NULL, @Avion_CantidadKgsDisponibles)
	
	DECLARE @AvionID INT
	SET @AvionID = SCOPE_IDENTITY()

	EXEC THE_BTREES.AutoCrear_Butacas @AvionID, @Butacas_Pasillo, @Butacas_Ventana;
	COMMIT TRAN
GO

IF  object_id(N'[THE_BTREES].[NotInBetween24h]','fn') IS NOT NULL
	DROP FUNCTION [THE_BTREES].[NotInBetween24h]
GO

CREATE FUNCTION [THE_BTREES].[NotInBetween24h]
	(@fecha datetime, @AvionID int)
	RETURNS BIT
AS
BEGIN
	DECLARE @Fecha24 datetime
	DECLARE cursorFechas CURSOR FOR SELECT v.Viaje_FechaSalida FROM THE_BTREES.Viaje v WHERE v.Viaje_AvionRef = @AvionID
	OPEN cursorFechas
	FETCH NEXT FROM cursorFEchas INTO @Fecha24	

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF @fecha BETWEEN @Fecha24-24 AND @Fecha24+24 RETURN 0
		FETCH NEXT FROM cursorFEchas 
		INTO @Fecha24
	END
	RETURN 1
END
GO


IF  object_id(N'[THE_BTREES].[VerificarSiHayAvionParaReemplazar]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].[VerificarSiHayAvionParaReemplazar]
GO

CREATE PROCEDURE [THE_BTREES].[VerificarSiHayAvionParaReemplazar]
	@AvionAReemplazarID int,
	@FechaActual datetime,
	@AvionCandidatoID int OUTPUT
AS
BEGIN
	SET @AvionCandidatoID = 0
	SELECT TOP 1 @AvionCandidatoID = a.AvionID
	FROM THE_BTREES.Avion a 
	WHERE a.AvionID != @AvionAReemplazarID
	  AND a.Avion_Modelo=(SELECT r.Avion_Modelo FROM THE_BTREES.Avion r WHERE r.AvionID=@AvionAReemplazarID) 
	  AND a.Avion_Fabricante=(SELECT r.Avion_Fabricante FROM THE_BTREES.Avion r WHERE r.AvionID=@AvionAReemplazarID)
	  AND a.Avion_TipoDeServicioRef=(SELECT r.Avion_TipoDeServicioRef FROM THE_BTREES.Avion r WHERE r.AvionID=@AvionAReemplazarID)  
	  AND (SELECT COUNT(*) FROM THE_BTREES.Viaje v WHERE v.Viaje_AvionRef=@AvionAReemplazarID AND v.Viaje_FechaSalida>@FechaActual) = 
		  (SELECT COUNT(*)
		   FROM THE_BTREES.Viaje v2 
		   WHERE v2.Viaje_AvionRef=@AvionAReemplazarID
			 AND v2.Viaje_FechaSalida>@FechaActual
	         AND THE_BTREES.NotInBetween24h(v2.Viaje_FechaSalida, a.AvionID) = 1)
END
GO

IF  object_id(N'[THE_BTREES].[DarDeBaja_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarDeBaja_Avion
GO

CREATE PROCEDURE THE_BTREES.DarDeBaja_Avion
	@AvionID INT,
	@Avion_FechaDeBajaDefinitiva DATE,
	@AvionATranspasar INT
AS
BEGIN	
	DECLARE @CompraID int,
			@CancelacionRef int

	DECLARE cursorCancelacion CURSOR FOR SELECT DISTINCT c.CompraID 
										 FROM THE_BTREES.Compra c 
										 INNER JOIN (
													 SELECT p.Pasaje_CompraRef AS CompreRef
													 FROM THE_BTREES.Pasaje p INNER JOIN THE_BTREES.Viaje v ON p.Pasaje_ViajeRef=v.ViajeID
									   				 WHERE v.Viaje_AvionRef=@AvionID AND v.Viaje_FechaSalida>@Avion_FechaDeBajaDefinitiva
													 UNION
													 SELECT e.Enco_CompraRef AS ComprRef  
													 FROM THE_BTREES.Encomienda e INNER JOIN THE_BTREES.Viaje v ON e.Enco_ViajeRef=v.ViajeID
									   				 WHERE v.Viaje_AvionRef=@AvionID AND v.Viaje_FechaSalida>@Avion_FechaDeBajaDefinitiva
													 ) r
									     ON c.CompraID = r.CompreRef

	BEGIN TRAN
	OPEN cursorCancelacion
	FETCH NEXT FROM cursorCancelacion INTO @CompraID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO THE_BTREES.Cancelacion 
		(
			Cance_CompraRef,Cance_Fecha,Motivo
		)
		VALUES
		(
			@CompraID,@Avion_FechaDeBajaDefinitiva,'Baja de la Ruta Aerea asignada.'
		)
		SET @CancelacionRef = SCOPE_IDENTITY()
		
		UPDATE THE_BTREES.Pasaje
		SET Pasaje_CancelacionRef=@CancelacionRef 
		WHERE Pasaje_CompraRef=@CompraID

		UPDATE THE_BTREES.Encomienda
		SET Enco_CancelacionRef=@CancelacionRef
		WHERE Enco_CompraRef=@CompraID

		FETCH NEXT FROM cursorCancelacion INTO @CompraID
	END

	IF @AvionATranspasar IS NOT NULL
	BEGIN
		UPDATE THE_BTREES.Viaje 
		SET Viaje_AvionRef=@AvionATranspasar
		WHERE Viaje_AvionRef=@AvionID AND Viaje_FechaSalida>@Avion_FechaDeBajaDefinitiva
	END

	UPDATE THE_BTREES.Avion SET Avion_BajaPorVidaUtil = 1, @Avion_FechaDeBajaDefinitiva = Avion_FechaDeBajaDefinitiva WHERE @AvionID = AvionID

	COMMIT TRAN
END
GO


IF  object_id(N'[THE_BTREES].[Modificar_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].Modificar_Avion
GO

CREATE PROCEDURE THE_BTREES.Modificar_Avion
	@AvionID INT,
	@Avion_FechaDeAlta DATE, 
	@Avion_Modelo NVARCHAR(255), 
	@Avion_Matricula NVARCHAR(255), 
	@Avion_Fabricante NVARCHAR(255), 
	@Avion_TipoDeServicioRef TINYINT, 
	@Avion_CantidadKgsDisponibles NUMERIC(18,0),
	@Butacas_Pasillo INT,
	@Butacas_Ventana INT,
	@ModificaButaca BIT
AS

	BEGIN TRAN
	UPDATE THE_BTREES.Avion SET Avion_FechaDeAlta = @Avion_FechaDeAlta , Avion_Modelo = @Avion_Modelo, Avion_Matricula = @Avion_Matricula, Avion_Fabricante = @Avion_Fabricante,
								Avion_TipoDeServicioRef = @Avion_TipoDeServicioRef,
								Avion_CantidadKgsDisponibles = @Avion_CantidadKgsDisponibles
	WHERE @AvionID = AvionID

	IF @ModificaButaca = 1
	BEGIN
		DELETE FROM THE_BTREES.Butaca WHERE @AvionID = Butaca_AvionRef
		EXEC THE_BTREES.AutoCrear_Butacas @AvionID, @Butacas_Pasillo, @Butacas_Ventana;
	END
	
	COMMIT TRAN
GO



IF  object_id(N'[THE_BTREES].[TraerAvionConServicioYButacas]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].TraerAvionConServicioYButacas
GO

CREATE PROCEDURE THE_BTREES.TraerAvionConServicioYButacas
	@AvionID INT
AS
	SELECT TOP 1 AvionID, Avion_Matricula, Avion_Fabricante, Avion_Modelo, Avion_TipoDeServicioRef, Avion_FechaDeAlta, 
				(SELECT COUNT(*) FROM THE_BTREES.Butaca WHERE @AvionID = Butaca_AvionRef AND Butaca_EsVentanilla = 0) Butacas_Pasillo, 
				(SELECT COUNT(*) FROM THE_BTREES.Butaca WHERE @AvionID = Butaca_AvionRef AND Butaca_EsVentanilla = 1) Butacas_Ventanilla, 
				Avion_CantidadKgsDisponibles, Avion_BajaPorVidaUtil, Avion_BajaPorFueraDeServicio
	FROM THE_BTREES.Avion WHERE @AvionID = AvionID
GO

IF  object_id(N'[THE_BTREES].[TraerUltimoFueraDeServicioAvion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].TraerUltimoFueraDeServicioAvion
GO

CREATE PROCEDURE THE_BTREES.TraerUltimoFueraDeServicioAvion
	@AvionID INT
AS
	SELECT TOP 1 Fuera_FechaFuera, FueraDeServicioId
	FROM THE_BTREES.FueraDeServicio WHERE @AvionID = Fuera_AvionRef
	ORDER BY Fuera_FechaFuera DESC
GO


IF  object_id(N'[THE_BTREES].[DarFueraServicio_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarFueraServicio_Avion
GO

CREATE PROCEDURE THE_BTREES.DarFueraServicio_Avion
	@AvionID INT,
	@Avion_FechaFueraServicio DATE
AS
	BEGIN TRAN
		UPDATE THE_BTREES.Avion SET Avion_BajaPorFueraDeServicio = 1 WHERE @AvionID = AvionID
		INSERT INTO THE_BTREES.FueraDeServicio (Fuera_AvionRef, Fuera_FechaFuera) VALUES (@AvionID, @Avion_FechaFueraServicio)
	COMMIT TRAN
GO


IF  object_id(N'[THE_BTREES].[DarReinicioServicio_Avion]','P') IS NOT NULL
	DROP PROCEDURE [THE_BTREES].DarReinicioServicio_Avion
GO

CREATE PROCEDURE THE_BTREES.DarReinicioServicio_Avion
	@AvionID INT,
	@Avion_FechaReinicioServicio DATE,
	@FueraDeServicioId INT
AS
	BEGIN TRAN
		UPDATE THE_BTREES.Avion SET Avion_BajaPorFueraDeServicio = 0 WHERE @AvionID = AvionID
		UPDATE THE_BTREES.FueraDeServicio SET Fuera_FechaVuelta = @Avion_FechaReinicioServicio WHERE FueraDeServicioId = @FueraDeServicioId
	COMMIT TRAN
GO




/****************************************************************************************************************************/
/*IMPORTACION DESDE LA TABLA MAESTRA*/

USE [GD2C2015]
GO

/************ INSERT PRODUCTOS **************/
INSERT INTO THE_BTREES.Producto
        ( Producto_Stock ,
          Producto_Descripcion ,
          Producto_Millas
        )
VALUES  ( 5,'Pava electriva' , 3000),
		( 6,'Horno' , 15000),
		( 1,'LED TV' , 150000),
		( 8,'Maso de cartas' , 60),
		( 10,'Reloj' , 500),
		( 50,'Vaso de vidrio' , 70),
		( 7,'Juego de te' , 1000),
		(4,'TEG' , 2000)

GO

/************ INSERT CIUDADES *********35 CIUDADES*****/

INSERT INTO THE_BTREES.Ciudad
        ( Ciudad_Nombre, Ciudad_Activo )
SELECT DISTINCT m.Ruta_Ciudad_Destino,
		1
FROM gd_esquema.Maestra M

INSERT INTO THE_BTREES.Ciudad
        ( Ciudad_Nombre, Ciudad_Activo )
SELECT DISTINCT m.Ruta_Ciudad_Origen,
		1
FROM gd_esquema.Maestra M
WHERE M.Ruta_Ciudad_Origen NOT IN (SELECT Ciudad_Nombre FROM THE_BTREES.Ciudad)

GO

/************ INSERT CLIENTES ***** 2594 CLIENTES *********/

INSERT INTO THE_BTREES.Cliente
        ( Cliente_Nombre ,
          Cliente_Apellido ,
          Cliente_DNI ,
          Cliente_Direccion ,
          Cliente_Telefono ,
          Cliente_Mail ,
          Cliente_FechaNac
        )
SELECT DISTINCT M.Cli_Nombre,
		M.Cli_Apellido,
		M.Cli_Dni,
		M.Cli_Dir,
		M.Cli_Telefono,
		M.Cli_Mail,
		M.Cli_Fecha_Nac
FROM gd_esquema.Maestra M
GO

/************ INSERT TIPO DE SERVICIOS ****** 3 TIPOS ********/

INSERT INTO THE_BTREES.TipoServicio
        ( TipoSer_Nombre ,
          TipoSer_PorcentajeAdicional
        )
SELECT DISTINCT m.Tipo_Servicio,
		1
FROM gd_esquema.Maestra m
GO

UPDATE THE_BTREES.TipoServicio
SET TipoSer_PorcentajeAdicional=1.2
WHERE TipoSer_Nombre='Turista'
UPDATE THE_BTREES.TipoServicio
SET TipoSer_PorcentajeAdicional=2
WHERE TipoSer_Nombre='Primera Clase'
UPDATE THE_BTREES.TipoServicio
SET TipoSer_PorcentajeAdicional=1.5
WHERE TipoSer_Nombre='Ejecutivo'



/************ INSERT AVION ***** 30 AVIONES ********/

INSERT INTO THE_BTREES.Avion
        ( Avion_FechaDeAlta ,
          Avion_Modelo ,
          Avion_Matricula ,
          Avion_Fabricante ,
          Avion_TipoDeServicioRef ,
          Avion_BajaPorFueraDeServicio ,
          Avion_BajaPorVidaUtil ,
          Avion_CantidadKgsDisponibles
        )
SELECT DISTINCT GETDATE(),
		m.Aeronave_Modelo,
		m.Aeronave_Matricula,
		m.Aeronave_Fabricante,
		(SELECT t.TipoServicioID FROM THE_BTREES.TipoServicio T WHERE t.TipoSer_Nombre = m.Tipo_Servicio),
		0,
		0,
		m.Aeronave_KG_Disponibles				
FROM gd_esquema.Maestra M
GO

/************ INSERT BUTACAS ******** 1337 butacas ******/

INSERT INTO THE_BTREES.Butaca
        ( Butaca_AvionRef ,
          Butaca_Numero ,
          Butaca_EsVentanilla
        )
SELECT DISTINCT (SELECT AvionID FROM THE_BTREES.Avion WHERE Avion_Matricula=m.Aeronave_Matricula),
		m.Butaca_Nro,
		(CASE 
		WHEN  m.Butaca_Tipo='Ventanilla' THEN 1
		ELSE 0
		END) AS tipoButaca
FROM gd_esquema.Maestra m
WHERE m.Butaca_Piso=1
GO

/************ INSERT RUTAS AEREAS ****** 68 rutas ********/ ---> UN MISMO CODIGO DE RUTA TIENE DISTINTAS CIUDADES DE ORIGEN Y DESTINO... TURBIO
-- https://groups.google.com/forum/#!topic/gestiondedatos/Q1eg0vCooVE en este link explica que tenemos que guardar todo, y manejarlo nosotros bien con un codigo interno, asi que esto esta bien
-- existen en total 35 codigo de rutas diferentes nomas, pero con el tema de que estna mal las ciudades, se hacen 68

INSERT INTO THE_BTREES.RutaAerea
        ( Ruta_Codigo ,
          Ruta_CiudadOrigenRef ,
          Ruta_CiudadDestinoRef ,
          Ruta_PrecioBaseKg ,
          Ruta_PrecioBasePasaje ,
          Ruta_Activo
        )
SELECT DISTINCT M.Ruta_Codigo,
		(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen),
		(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Destino),
		0,
		0,
		1
FROM gd_esquema.Maestra m

UPDATE THE_BTREES.RutaAerea
SET Ruta_PrecioBaseKg = tabla2.precioBase
FROM THE_BTREES.RutaAerea t1, (SELECT m.Ruta_Precio_BaseKG AS precioBase,
						   m.Ruta_Codigo AS ruta 
					FROM gd_esquema.Maestra m 
					INNER JOIN THE_BTREES.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BaseKG<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BaseKG
					) tabla2
WHERE t1.Ruta_Codigo = tabla2.ruta

UPDATE THE_BTREES.RutaAerea
SET Ruta_PrecioBasePasaje = tabla2.precioBase
FROM THE_BTREES.RutaAerea t1, (SELECT Ruta_Precio_BasePasaje AS precioBase,m.Ruta_Codigo AS ruta FROM gd_esquema.Maestra m 
					INNER JOIN THE_BTREES.RutaAerea ON m.Ruta_Codigo=RutaAerea.Ruta_Codigo
					WHERE Ruta_Precio_BasePasaje<>0
					GROUP BY m.Ruta_Codigo,Ruta_Precio_BasePasaje
					)  tabla2
WHERE t1.Ruta_Codigo = tabla2.ruta
GO

/************ INSERT TIPO SERVICIO X RUTA AEREA ***** 68 RUTAS POR TIPO DE SERVICIO *********/

INSERT INTO THE_BTREES.TipoServicioXRutaAerea
        ( RutaAereaRef, TipoServicioRef )
SELECT	DISTINCT R.RutaAereaID,
		         T.TipoServicio
FROM THE_BTREES.RutaAerea R
INNER JOIN (SELECT DISTINCT M.Ruta_Codigo,
		                    (SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen) AS CiudadOrigenRef,
		                    (SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Destino) AS CiudadDestinoRef,
							(SELECT TipoServicioID FROM THE_BTREES.TipoServicio WHERE TipoSer_Nombre=M.Tipo_Servicio) AS TipoServicio
            FROM gd_esquema.Maestra m ) AS T ON T.Ruta_Codigo=R.Ruta_Codigo 
												AND T.CiudadOrigenRef=R.Ruta_CiudadOrigenRef
												AND T.CiudadDestinoRef=R.Ruta_CiudadDestinoRef
GO

/************ INSERT TIPO TARJETA **************/

INSERT INTO THE_BTREES.TiposTarjeta
        ( TipoTarj_Descripcion ,
          TipoTarj_CuotasMax
        )
VALUES  ('MasterCard',2),
		('Visa',5),
		('American Express',4)
GO

/************ INSERT VIAJE ***** 8510 VIAJES *********/ 

INSERT INTO THE_BTREES.Viaje
        ( Viaje_FechaSalida,
          Viaje_FechaLlegada,
          Viaje_AvionRef,
          Viaje_RutaAereaRef,
          Viaje_FechaLlegadaEstimada
        )

SELECT DISTINCT v.FechaSalida,
				v.FechaLLegada,
				v.AvionRef,
				r.RutaAereaID,
				v.Fecha_LLegada_Estimada
FROM THE_BTREES.viajes_con_ref v 
INNER JOIN THE_BTREES.RutaAerea r ON r.Ruta_Codigo = v.Ruta_Codigo 
							  AND r.Ruta_CiudadDestinoRef=v.CiudadDestinoRef 
							  AND r.Ruta_CiudadOrigenRef=v.CiudadOrigenRef
GO

/************ INSERT COMPRAS **************/
-- EN IMPORTACION HAY RELACION DE UNO A UNO CON COMPRAS Y PASAJES Y PAQUETES (TIENE EL MISMO CODIGO)
-- CUANDO SE IMPLEMENTE UNA COMPRA PUEDE TENER MAS 
-- DE UN PASAJE O ENCOMIENDA 
SET IDENTITY_INSERT THE_BTREES.Compra ON
INSERT INTO THE_BTREES.Compra
        ( CompraID ,
		  Compra_Fecha ,
          Compra_AbonaEnEfectivo ,
          Compra_CompradorRef
        )
SELECT DISTINCT C.CodigoCompra ,
				C.fechaCompra,
				1, --TODOS ABONAN EN EFECTIVO
				C.CompradorRef
FROM THE_BTREES.compra_con_ref C
SET IDENTITY_INSERT THE_BTREES.Compra OFF
GO


/************ INSERT PASAJES ****** 265646 PASAJES ********/
INSERT INTO THE_BTREES.Pasaje
        ( Pasaje_ClienteRef ,
          Pasaje_CompraRef ,
          Pasaje_Precio ,
          Pasaje_ButacaRef ,
          Pasaje_ViajeRef
        )  
SELECT DISTINCT (SELECT ClienteID FROM THE_BTREES.Cliente WHERE Cliente_DNI=M.Cli_Dni AND Cliente_Apellido=M.Cli_Apellido),
				M.Pasaje_Codigo,
				M.Pasaje_Precio,
				(SELECT ButacaID FROM THE_BTREES.Butaca WHERE Butaca_AvionRef=A.AvionID AND Butaca_Numero=M.Butaca_Nro), 
				V.ViajeID
FROM gd_esquema.Maestra M
INNER JOIN THE_BTREES.TipoServicio T ON T.TipoSer_Nombre=M.Tipo_Servicio
INNER JOIN THE_BTREES.Avion A ON M.Aeronave_Matricula=A.Avion_Matricula 
INNER JOIN (SELECT R.RutaAereaID,
				   R.Ruta_Codigo,
				   W.TipoServicioRef,
				   R.Ruta_CiudadOrigenRef
			FROM THE_BTREES.RutaAerea R
			INNER JOIN THE_BTREES.TipoServicioXRutaAerea W ON W.RutaAereaRef = R.RutaAereaID
			) B ON B.Ruta_Codigo=M.Ruta_Codigo AND B.TipoServicioRef=T.TipoServicioID 
			AND B.Ruta_CiudadOrigenRef=(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen)
INNER JOIN THE_BTREES.Viaje V ON V.Viaje_AvionRef=A.AvionID AND V.Viaje_FechaLlegada=M.FechaLLegada 
						  AND V.Viaje_RutaAereaRef=B.RutaAereaID
WHERE Pasaje_Codigo<>0 

/************ INSERT ENCOMIENDA ******* 135658 ENCOMIEDAS*******/

INSERT INTO THE_BTREES.Encomienda 
	(
		Enco_KG,
		Enco_Precio,
		Enco_CompraRef,
		Enco_ClienteRespRef,
		Enco_ViajeRef
	)
SELECT DISTINCT m.Paquete_KG,
				m.Paquete_Precio,
				M.Paquete_Codigo,
				(SELECT ClienteID FROM THE_BTREES.Cliente WHERE Cliente_DNI=M.Cli_Dni AND Cliente_Apellido=M.Cli_Apellido),
				V.ViajeID
FROM gd_esquema.Maestra M
INNER JOIN THE_BTREES.TipoServicio T ON T.TipoSer_Nombre=M.Tipo_Servicio
INNER JOIN THE_BTREES.Avion A ON M.Aeronave_Matricula=A.Avion_Matricula 
INNER JOIN (SELECT R.RutaAereaID,
				   R.Ruta_Codigo,
				   W.TipoServicioRef,
				   R.Ruta_CiudadOrigenRef
			FROM THE_BTREES.RutaAerea R
			INNER JOIN THE_BTREES.TipoServicioXRutaAerea W ON W.RutaAereaRef = R.RutaAereaID
			) B ON B.Ruta_Codigo=M.Ruta_Codigo AND B.TipoServicioRef=T.TipoServicioID 
			AND B.Ruta_CiudadOrigenRef=(SELECT CiudadID FROM THE_BTREES.Ciudad WHERE Ciudad_Nombre=M.Ruta_Ciudad_Origen)
INNER JOIN THE_BTREES.Viaje V ON V.Viaje_AvionRef=A.AvionID AND V.Viaje_FechaLlegada=M.FechaLLegada 
						 	  AND V.Viaje_RutaAereaRef=B.RutaAereaID
WHERE Paquete_Codigo<>0 

/************ INSERT Usuarios ******* *******/
BEGIN TRAN
INSERT INTO THE_BTREES.Funcionalidades (Funcionalidad_Nombre) VALUES 
	('ABM Rol'),
	('Login y seguridad'),
	('Reg Usuarios'),
	('ABM Ciudad'),
	('ABM Ruta Aerea'),
	('ABM Aeronave'),
	('Generar Viaje'),
	('Reg Llegada Destino'),
	('Comprar'),
	('Cancelacion'),
	('Canje de Millas'),
	('Consulta de Millas'),
	('Estadisticas')

INSERT INTO THE_BTREES.Roles (Rol_Nombre, Rol_Activo) VALUES 
	('Administrador General', 1),
	('Cliente', 1)

INSERT INTO THE_BTREES.Usuarios (Usuario_Nombre, Usuario_Password, Usuario_Intentos_Fallidos, Usuario_Activo) VALUES 
	('admin',  HASHBYTES('SHA2_256', N'w23e'), 0, 1)

INSERT INTO THE_BTREES.RolesXUsuarios (UsuarioRef, RolRef) VALUES 
	(1, 1)

INSERT INTO THE_BTREES.FuncionalidadesXRoles (RolRef, FuncionalidadRef) VALUES 
	(1, 1),
	(1, 2),
	(1, 3),
	(1, 4),
	(1, 5),
	(1, 6),
	(1, 7),
	(1, 8),
	(1, 9),
	(1, 10),
	(1, 11),
	(1, 12),
	(1, 13),
	(2, 1)
COMMIT TRAN
GO

