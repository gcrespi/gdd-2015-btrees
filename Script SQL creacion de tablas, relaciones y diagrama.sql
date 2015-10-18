USE [GD2C2015]
GO
/****** Object:  Schema [gd_esquema]    Script Date: 18/10/2015 18:22:31 ******/
CREATE SCHEMA [gd_esquema]
GO
/****** Object:  Table [dbo].[Avion]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avion](
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
/****** Object:  Table [dbo].[Butaca]    Script Date: 18/10/2015 18:22:31 ******/
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
/****** Object:  Table [dbo].[Cancelacion]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cancelacion](
	[CancelacionID] [int] IDENTITY(1,1) NOT NULL,
	[Cance_EncomiendaRef] [int] NULL,
	[Cance_PasajeRef] [int] NULL,
	[Motivo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cancelacion] PRIMARY KEY CLUSTERED 
(
	[CancelacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Canje]    Script Date: 18/10/2015 18:22:31 ******/
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
/****** Object:  Table [dbo].[Ciudad]    Script Date: 18/10/2015 18:22:31 ******/
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 18/10/2015 18:22:31 ******/
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
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Compra](
	[CompraID] [int] IDENTITY(1,1) NOT NULL,
	[Compra_Fecha] [datetime] NOT NULL,
	[Compra_AbonaEnEfectivo] [bit] NOT NULL,
	[Compra_CantCuotas] [tinyint] NULL,
	[Compra_TipoTarjetaRef] [int] NULL,
	[Compra_DNIComprador] [int] NOT NULL,
	[Compra_Nombre] [varchar](50) NOT NULL,
	[Compra_Apellido] [varchar](50) NOT NULL,
	[Compra_Direccion] [varchar](100) NOT NULL,
	[Compra_Telefeno] [varchar](50) NOT NULL,
	[Compra_Mail] [varchar](100) NOT NULL,
	[Compra_FechaNac] [date] NOT NULL,
	[Compra_NumTarjeta] [varchar](20) NOT NULL,
	[Compra_CodSeg] [int] NOT NULL,
	[Compra_FechaVencimiento] [date] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[CompraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Encomienda]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomienda](
	[EncomiendaID] [int] IDENTITY(1,1) NOT NULL,
	[Enco_KG] [smallint] NOT NULL,
	[Enco_Precio] [numeric](18, 2) NOT NULL,
	[Enco_CompraRef] [int] NOT NULL,
	[Enco_ClienteRespRef] [int] NOT NULL,
	[Enco_ViajeRef] [int] NOT NULL,
 CONSTRAINT [PK_Paquete] PRIMARY KEY CLUSTERED 
(
	[EncomiendaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FueraDeServicio]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FueraDeServicio](
	[FueraDeServicioId] [int] IDENTITY(1,1) NOT NULL,
	[Fuera_AvionRef] [int] NOT NULL,
	[Fuera_FechaFuera] [date] NOT NULL,
	[Fuera_FechaVuelta] [date] NOT NULL,
 CONSTRAINT [PK_FueraDeServicio] PRIMARY KEY CLUSTERED 
(
	[FueraDeServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pasaje]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasaje](
	[PasajeID] [int] IDENTITY(1,1) NOT NULL,
	[Pasaje_ClienteRef] [int] NOT NULL,
	[Pasaje_CompraRef] [int] NOT NULL,
	[Pasaje_Precio] [nchar](10) NOT NULL,
	[Pasaje_ButacaRef] [int] NOT NULL,
	[Pasaje_ViajeRef] [int] NOT NULL,
 CONSTRAINT [PK_Pasaje] PRIMARY KEY CLUSTERED 
(
	[PasajeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
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
/****** Object:  Table [dbo].[RutaAerea]    Script Date: 18/10/2015 18:22:31 ******/
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
/****** Object:  Table [dbo].[TipoServicio]    Script Date: 18/10/2015 18:22:31 ******/
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
/****** Object:  Table [dbo].[TipoServicioXRutaAerea]    Script Date: 18/10/2015 18:22:31 ******/
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
/****** Object:  Table [dbo].[TiposTarjeta]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposTarjeta](
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
/****** Object:  Table [dbo].[TransaccionesMillas]    Script Date: 18/10/2015 18:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransaccionesMillas](
	[TransaccionId] [int] IDENTITY(1,1) NOT NULL,
	[Tran_CanjeRef] [int] NOT NULL,
	[Tran_ClienteRef] [int] NOT NULL,
	[Tran_EncomiendaRef] [int] NOT NULL,
	[Tran_PasajeRef] [int] NOT NULL,
	[CantidadMillas] [int] NOT NULL,
	[MillasDisponibles] [int] NOT NULL,
 CONSTRAINT [PK_TransaccionesMillas] PRIMARY KEY CLUSTERED 
(
	[TransaccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Viaje]    Script Date: 18/10/2015 18:22:31 ******/
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
	[Viaje_FechaLlegadaEstimada] [datetime] NOT NULL,
 CONSTRAINT [PK_Viaje] PRIMARY KEY CLUSTERED 
(
	[ViajeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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
ALTER TABLE [dbo].[Cancelacion]  WITH CHECK ADD  CONSTRAINT [FK_Cancelacion_Encomienda] FOREIGN KEY([Cance_EncomiendaRef])
REFERENCES [dbo].[Encomienda] ([EncomiendaID])
GO
ALTER TABLE [dbo].[Cancelacion] CHECK CONSTRAINT [FK_Cancelacion_Encomienda]
GO
ALTER TABLE [dbo].[Cancelacion]  WITH CHECK ADD  CONSTRAINT [FK_Cancelacion_Pasaje] FOREIGN KEY([Cance_PasajeRef])
REFERENCES [dbo].[Pasaje] ([PasajeID])
GO
ALTER TABLE [dbo].[Cancelacion] CHECK CONSTRAINT [FK_Cancelacion_Pasaje]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Cliente] FOREIGN KEY([Canje_ClienteRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Cliente]
GO
ALTER TABLE [dbo].[Canje]  WITH CHECK ADD  CONSTRAINT [FK_Canje_Producto] FOREIGN KEY([Canje_ProductoRef])
REFERENCES [dbo].[Producto] ([ProductoID])
GO
ALTER TABLE [dbo].[Canje] CHECK CONSTRAINT [FK_Canje_Producto]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_TipoTarjetaDeCredito] FOREIGN KEY([Compra_TipoTarjetaRef])
REFERENCES [dbo].[TiposTarjeta] ([TipoTarjetaID])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_TipoTarjetaDeCredito]
GO
ALTER TABLE [dbo].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Cliente] FOREIGN KEY([Enco_ClienteRespRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Cliente]
GO
ALTER TABLE [dbo].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Compra] FOREIGN KEY([Enco_CompraRef])
REFERENCES [dbo].[Compra] ([CompraID])
GO
ALTER TABLE [dbo].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Compra]
GO
ALTER TABLE [dbo].[Encomienda]  WITH CHECK ADD  CONSTRAINT [FK_Encomienda_Viaje] FOREIGN KEY([Enco_ViajeRef])
REFERENCES [dbo].[Viaje] ([ViajeID])
GO
ALTER TABLE [dbo].[Encomienda] CHECK CONSTRAINT [FK_Encomienda_Viaje]
GO
ALTER TABLE [dbo].[FueraDeServicio]  WITH CHECK ADD  CONSTRAINT [FK_FueraDeServicio_Avion] FOREIGN KEY([Fuera_AvionRef])
REFERENCES [dbo].[Avion] ([AvionID])
GO
ALTER TABLE [dbo].[FueraDeServicio] CHECK CONSTRAINT [FK_FueraDeServicio_Avion]
GO
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Butaca] FOREIGN KEY([Pasaje_ButacaRef])
REFERENCES [dbo].[Butaca] ([ButacaID])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Butaca]
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
ALTER TABLE [dbo].[Pasaje]  WITH CHECK ADD  CONSTRAINT [FK_Pasaje_Viaje] FOREIGN KEY([Pasaje_ViajeRef])
REFERENCES [dbo].[Viaje] ([ViajeID])
GO
ALTER TABLE [dbo].[Pasaje] CHECK CONSTRAINT [FK_Pasaje_Viaje]
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
ALTER TABLE [dbo].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Canje] FOREIGN KEY([Tran_CanjeRef])
REFERENCES [dbo].[Canje] ([CanjeID])
GO
ALTER TABLE [dbo].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Canje]
GO
ALTER TABLE [dbo].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Cliente] FOREIGN KEY([Tran_ClienteRef])
REFERENCES [dbo].[Cliente] ([ClienteID])
GO
ALTER TABLE [dbo].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Cliente]
GO
ALTER TABLE [dbo].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Encomienda] FOREIGN KEY([Tran_EncomiendaRef])
REFERENCES [dbo].[Encomienda] ([EncomiendaID])
GO
ALTER TABLE [dbo].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Encomienda]
GO
ALTER TABLE [dbo].[TransaccionesMillas]  WITH CHECK ADD  CONSTRAINT [FK_TransaccionesMillas_Pasaje] FOREIGN KEY([Tran_PasajeRef])
REFERENCES [dbo].[Pasaje] ([PasajeID])
GO
ALTER TABLE [dbo].[TransaccionesMillas] CHECK CONSTRAINT [FK_TransaccionesMillas_Pasaje]
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
