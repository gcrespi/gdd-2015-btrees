USE [GD2C2015]
GO
/****** Object:  User [gd]    Script Date: 27/09/2015 20:46:45 ******/
CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [gd_esquema]    Script Date: 27/09/2015 20:46:45 ******/
CREATE SCHEMA [gd_esquema]
GO
/****** Object:  Table [dbo].[Avion]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avion](
	[AvionID] [int] IDENTITY(1,1) NOT NULL,
	[Avion_FechaDeAlta] [date] NOT NULL,
	[Avion_Numero] [int] NOT NULL,
	[Avion_Modelo] [nvarchar](255) NOT NULL,
	[Avion_Matricula] [nvarchar](255) NOT NULL,
	[Avion_Fabricante] [nvarchar](255) NOT NULL,
	[Avion_TipoDeServicioRef] [tinyint] NOT NULL,
	[Avion_BajaPorFueraDeServicio] [bit] NOT NULL,
	[Avion_BajaPorVidaUtil] [bit] NOT NULL,
	[Avion_FechaFueraDeServicio] [date] NULL,
	[Avion_FechaReinicioDeServicio] [date] NULL,
	[Avion_FechaDeBajaDefinitiva] [date] NULL,
	[Avion_CantidadButacas] [int] NOT NULL,
	[Avion_CantidadKgsDisponibles] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Avion] PRIMARY KEY CLUSTERED 
(
	[AvionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Butaca]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Butaca](
	[ButacaID] [int] IDENTITY(1,1) NOT NULL,
	[Butaca_AvionRef] [int] NOT NULL,
	[Butaca_Numero] [int] NOT NULL,
	[Butaca_EsVentanilla] [bit] NOT NULL,
	[Butaca_Piso] [tinyint] NOT NULL,
	[Butaca_estaOcupada] [bit] NOT NULL,
 CONSTRAINT [PK_Butaca] PRIMARY KEY CLUSTERED 
(
	[ButacaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Canje]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canje](
	[CanjeID] [int] IDENTITY(1,1) NOT NULL,
	[Canje_ClienteRef] [int] NOT NULL,
	[Canje_ProductoRef] [int] NOT NULL,
	[Canje_CantidadProducto] [int] NOT NULL,
	[Canje_Fecha] [date] NOT NULL,
 CONSTRAINT [PK_Canje] PRIMARY KEY CLUSTERED 
(
	[CanjeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CiudadID] [smallint] IDENTITY(1,1) NOT NULL,
	[Ciudad_Nombre] [nvarchar](255) NOT NULL,
	[Ciudad_Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED 
(
	[CiudadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_Nombre] [varchar](50) NOT NULL,
	[Cliente_Apellido] [varchar](50) NOT NULL,
	[Cliente_DNI] [varchar](15) NOT NULL,
	[Cliente_Direccion] [varchar](100) NOT NULL,
	[Cliente_Telefono] [int] NOT NULL,
	[Cliente_Mail] [varchar](100) NULL,
	[Cliente_FechaNac] [datetime] NOT NULL,
	[Cliente_MillasAcumuladas] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[CompraID] [int] IDENTITY(1,1) NOT NULL,
	[Compra_ViajeRef] [int] NOT NULL,
	[Compra_Fecha] [datetime] NOT NULL,
	[Compra_Codigo] [uniqueidentifier] NOT NULL,
	[Compra_AbonaEnEfectivo] [bit] NOT NULL,
	[Compra_ClienteAbonaRef] [int] NOT NULL,
	[Compra_CantCuotas] [tinyint] NULL,
	[Compra_TipoTarjetaRef] [tinyint] NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Devolucion]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Devolucion](
	[DevolucionID] [int] IDENTITY(1,1) NOT NULL,
	[Dev_Fecha] [date] NOT NULL,
	[Dev_CompraRef] [int] NOT NULL,
	[Dev_PasajeRef] [int] NOT NULL,
	[Dev_Motivo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[DevolucionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paquete]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paquete](
	[PaqueteID] [int] IDENTITY(1,1) NOT NULL,
	[Paquete_Codigo] [numeric](18, 0) NOT NULL,
	[Paquete_KG] [smallint] NOT NULL,
	[Paquete_Precio] [numeric](18, 2) NOT NULL,
	[Paquete_CompraRef] [int] NOT NULL,
	[Paquete_ClienteRef] [int] NOT NULL,
 CONSTRAINT [PK_Paquete] PRIMARY KEY CLUSTERED 
(
	[PaqueteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pasaje]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasaje](
	[PasajeID] [int] IDENTITY(1,1) NOT NULL,
	[Pasaje_ClienteRef] [int] NOT NULL,
	[Pasaje_CompraRef] [int] NOT NULL,
	[Pasaje_Codigo] [uniqueidentifier] NOT NULL,
	[Pasaje_Precio] [nchar](10) NULL,
	[Pasaje_ButacaRef] [int] NOT NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[PasajeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoID] [int] IDENTITY(1,1) NOT NULL,
	[Producto_Cantidad] [int] NOT NULL,
	[Producto_Nombre] [varchar](50) NOT NULL,
	[Producto_hayDisponibles] [bit] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistroMilla]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroMilla](
	[MillaRegistroID] [int] NOT NULL,
	[Milla_ClienteRef] [int] NOT NULL,
	[Milla_CantidadMillas] [int] NOT NULL,
	[Milla_Fecha] [int] NOT NULL,
	[Milla_esValida] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RutaAerea]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RutaAerea](
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
/****** Object:  Table [dbo].[TipoServicio]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoServicio](
	[TipoServicioID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TipoSer_Nombre] [nvarchar](255) NOT NULL,
	[TipoSer_PorcentajeAdicional] [int] NOT NULL,
 CONSTRAINT [PK_TipoServicio] PRIMARY KEY CLUSTERED 
(
	[TipoServicioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoServicioXRutaAerea]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoServicioXRutaAerea](
	[RutaAereaRef] [int] NOT NULL,
	[TipoServicioRef] [tinyint] NOT NULL,
 CONSTRAINT [PK_TipoServicioXRutaAerea] PRIMARY KEY CLUSTERED 
(
	[RutaAereaRef] ASC,
	[TipoServicioRef] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoTarjetaDeCredito]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoTarjetaDeCredito](
	[TipoTarjetaID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TipoTC_CantCuotas] [tinyint] NOT NULL,
	[TipoTC_Nombre] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TipoTarjetaDeCredito] PRIMARY KEY CLUSTERED 
(
	[TipoTarjetaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viaje](
	[ViajeID] [int] IDENTITY(1,1) NOT NULL,
	[Viaje_FechaSalida] [datetime] NOT NULL,
	[Viaje_FechaLlegada] [datetime] NOT NULL,
	[Viaje_AvionRef] [int] NOT NULL,
	[Viaje_RutaAereaRef] [int] NOT NULL,
	[Viaje_Activo] [bit] NOT NULL,
	[Viaje_FechaLlegadaEstimada] [datetime] NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[ViajeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[compra_con_ref]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[compra_con_ref]
AS
SELECT DISTINCT (SELECT AvionID FROM dbo.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
	   (CASE 
	   WHEN M.Pasaje_Codigo<>0 THEN M.Pasaje_FechaCompra
	   ELSE M.Paquete_FechaCompra
	   END) AS fechaCompra,
	   (CASE 
	   WHEN M.Pasaje_Codigo<>0 THEN M.Pasaje_Codigo
	   ELSE M.Paquete_Codigo
	   END) AS CodigoCompra,
	   (SELECT ClienteID FROM dbo.Cliente WHERE Cliente_DNI=M.Cli_Dni) AS ClienteRef,
	   m.FechaLLegada,
	   m.FechaSalida,
	   m.Fecha_LLegada_Estimada,
	   m.Ruta_Codigo	
FROM gd_esquema.Maestra m

GO
/****** Object:  View [dbo].[viajes_con_ref]    Script Date: 27/09/2015 20:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viajes_con_ref]
AS
SELECT DISTINCT m.FechaSalida,
				m.FechaLLegada,
				(SELECT AvionID FROM dbo.Avion WHERE Avion_Matricula=m.Aeronave_Matricula) AS AvionRef,
				m.Ruta_Codigo,
				(SELECT TipoServicioID FROM dbo.TipoServicio WHERE TipoSer_Nombre=m.Tipo_Servicio) AS TipoServicioRef,
				m.Fecha_LLegada_Estimada,
				(SELECT CiudadID FROM dbo.Ciudad WHERE m.Ruta_Ciudad_Destino=Ciudad_Nombre) AS CiudadDestinoRef,
				(SELECT CiudadID FROM dbo.Ciudad WHERE m.Ruta_Ciudad_Origen=Ciudad_Nombre) AS CiudadOrigenRef
FROM gd_esquema.Maestra m
GO
ALTER TABLE [dbo].[Avion]  WITH CHECK ADD  CONSTRAINT [FK_Avion_TipoServicio] FOREIGN KEY([Avion_TipoDeServicioRef])
REFERENCES [dbo].[TipoServicio] ([TipoServicioID])
GO
ALTER TABLE [dbo].[Avion] CHECK CONSTRAINT [FK_Avion_TipoServicio]
GO
ALTER TABLE [dbo].[Butaca]  WITH CHECK ADD  CONSTRAINT [FK_Butaca_Avion] FOREIGN KEY([Butaca_AvionRef])
REFERENCES [dbo].[Avion] ([AvionID])
GO
ALTER TABLE [dbo].[Butaca] CHECK CONSTRAINT [FK_Butaca_Avion]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Canje] FOREIGN KEY([Canje_ClienteRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Canje]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cliente] FOREIGN KEY([Compra_ClienteAbonaRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Cliente]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_TipoTarjetaDeCredito] FOREIGN KEY([Compra_TipoTarjetaRef])
REFERENCES [dbo].[TipoTarjetaDeCredito] ([TipoTarjetaID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_TipoTarjetaDeCredito]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Viaje] FOREIGN KEY([Compra_ViajeRef])
REFERENCES [dbo].[Viaje] ([ViajeID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Viaje]
GO
ALTER TABLE [dbo].[Devolucion]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Compra] FOREIGN KEY([Dev_CompraRef])
REFERENCES [dbo].[Compra] ([CompraID])
GO
ALTER TABLE [dbo].[Devolucion] CHECK CONSTRAINT [FK_Devolucion_Compra]
GO
ALTER TABLE [dbo].[Devolucion]  WITH CHECK ADD  CONSTRAINT [FK_Devolucion_Devolucion] FOREIGN KEY([Dev_PasajeRef])
REFERENCES [dbo].[Pasaje] ([PasajeID])
GO
ALTER TABLE [dbo].[Devolucion] CHECK CONSTRAINT [FK_Devolucion_Devolucion]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Cliente] FOREIGN KEY([Pasaje_ClienteRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Cliente]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Compra] FOREIGN KEY([Pasaje_CompraRef])
REFERENCES [dbo].[Compra] ([CompraID])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Compra]
GO
ALTER TABLE [dbo].[RegistroMilla]  WITH CHECK ADD  CONSTRAINT [FK_RegistroMilla_Cliente] FOREIGN KEY([Milla_ClienteRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[RegistroMilla] CHECK CONSTRAINT [FK_RegistroMilla_Cliente]
GO
ALTER TABLE [dbo].[RutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_RutaAerea_CiudadDestino] FOREIGN KEY([Ruta_CiudadDestinoRef])
REFERENCES [dbo].[Ciudad] ([CiudadID])
GO
ALTER TABLE [dbo].[RutaAerea] CHECK CONSTRAINT [FK_RutaAerea_CiudadDestino]
GO
ALTER TABLE [dbo].[RutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_RutaAerea_CiudadOrigen] FOREIGN KEY([Ruta_CiudadOrigenRef])
REFERENCES [dbo].[Ciudad] ([CiudadID])
GO
ALTER TABLE [dbo].[RutaAerea] CHECK CONSTRAINT [FK_RutaAerea_CiudadOrigen]
GO
ALTER TABLE [dbo].[TipoServicioXRutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_TipoServicioXRutaAerea_RutaAerea] FOREIGN KEY([RutaAereaRef])
REFERENCES [dbo].[RutaAerea] ([RutaAereaID])
GO
ALTER TABLE [dbo].[TipoServicioXRutaAerea] CHECK CONSTRAINT [FK_TipoServicioXRutaAerea_RutaAerea]
GO
ALTER TABLE [dbo].[TipoServicioXRutaAerea]  WITH CHECK ADD  CONSTRAINT [FK_TipoServicioXRutaAerea_TipoServicio] FOREIGN KEY([TipoServicioRef])
REFERENCES [dbo].[TipoServicio] ([TipoServicioID])
GO
ALTER TABLE [dbo].[TipoServicioXRutaAerea] CHECK CONSTRAINT [FK_TipoServicioXRutaAerea_TipoServicio]
GO
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_Avion] FOREIGN KEY([Viaje_AvionRef])
REFERENCES [dbo].[Avion] ([AvionID])
GO
ALTER TABLE [dbo].[Viaje] CHECK CONSTRAINT [FK_Viaje_Avion]
GO
ALTER TABLE [dbo].[Viaje]  WITH CHECK ADD  CONSTRAINT [FK_Viaje_RutaAerea] FOREIGN KEY([Viaje_RutaAereaRef])
REFERENCES [dbo].[RutaAerea] ([RutaAereaID])
GO
ALTER TABLE [dbo].[Viaje] CHECK CONSTRAINT [FK_Viaje_RutaAerea]
GO
