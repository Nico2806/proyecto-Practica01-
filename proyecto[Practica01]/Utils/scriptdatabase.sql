USE [FacturacionTPI]
GO
/****** Object:  UserDefinedTableType [dbo].[TipoDetalleFactura]    Script Date: 09/09/2024 18:58:51 ******/
CREATE TYPE [dbo].[TipoDetalleFactura] AS TABLE(
	[ArticuloId] [int] NULL,
	[Cantidad] [int] NULL
)
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 09/09/2024 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 09/09/2024 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacturaNroFactura] [int] NULL,
	[ArticuloId] [int] NULL,
	[Cantidad] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 09/09/2024 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[NroFactura] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FormaPagoId] [int] NULL,
	[Cliente] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NroFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormaPago]    Script Date: 09/09/2024 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormaPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulo] ([Id])
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD FOREIGN KEY([FacturaNroFactura])
REFERENCES [dbo].[Factura] ([NroFactura])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([FormaPagoId])
REFERENCES [dbo].[FormaPago] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[InsertarFactura]    Script Date: 09/09/2024 18:58:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarFactura]
    @Fecha DATETIME,
    @FormaPagoId INT,
    @Cliente VARCHAR(50),
    @DetallesDetalleFactura AS TipoDetalleFactura READONLY
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Insertar en Factura
        INSERT INTO Factura (Fecha, FormaPagoId, Cliente)
        VALUES (@Fecha, @FormaPagoId, @Cliente);
        DECLARE @NroFactura INT = SCOPE_IDENTITY();

        -- Insertar en DetalleFactura
        INSERT INTO DetalleFactura (FacturaNroFactura, ArticuloId, Cantidad)
        SELECT @NroFactura, ArticuloId, Cantidad FROM @DetallesDetalleFactura;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
