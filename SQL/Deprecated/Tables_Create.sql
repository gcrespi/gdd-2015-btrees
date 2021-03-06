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