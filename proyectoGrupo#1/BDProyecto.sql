USE [master]
GO
/****** Object:  Database [proyecto]    Script Date: 8/16/2024 6:23:19 PM ******/
CREATE DATABASE [proyecto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'proyecto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyecto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'proyecto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyecto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [proyecto] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [proyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [proyecto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [proyecto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [proyecto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [proyecto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [proyecto] SET ARITHABORT OFF 
GO
ALTER DATABASE [proyecto] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [proyecto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [proyecto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [proyecto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [proyecto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [proyecto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [proyecto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [proyecto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [proyecto] SET  ENABLE_BROKER 
GO
ALTER DATABASE [proyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [proyecto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [proyecto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [proyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [proyecto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [proyecto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [proyecto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [proyecto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [proyecto] SET  MULTI_USER 
GO
ALTER DATABASE [proyecto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [proyecto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [proyecto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [proyecto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [proyecto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [proyecto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [proyecto] SET QUERY_STORE = ON
GO
ALTER DATABASE [proyecto] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [proyecto]
GO
/****** Object:  Table [dbo].[tCarrito]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCarrito](
	[idCarrito] [int] IDENTITY(1,1) NOT NULL,
	[id] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[Cantidades] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_tCarrito] PRIMARY KEY CLUSTERED 
(
	[idCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tCategoria]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tCategoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProducto]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProducto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Precio] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[idCategoria] [int] NOT NULL,
	[Imagen] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRol]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRol](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tUsuario]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](20) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Contrasenna] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[idRol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tCarrito]  WITH CHECK ADD  CONSTRAINT [FK_tCarrito_tProducto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[tProducto] ([idProducto])
GO
ALTER TABLE [dbo].[tCarrito] CHECK CONSTRAINT [FK_tCarrito_tProducto]
GO
ALTER TABLE [dbo].[tCarrito]  WITH CHECK ADD  CONSTRAINT [FK_tCarrito_tUsuario] FOREIGN KEY([id])
REFERENCES [dbo].[tUsuario] ([id])
GO
ALTER TABLE [dbo].[tCarrito] CHECK CONSTRAINT [FK_tCarrito_tUsuario]
GO
ALTER TABLE [dbo].[tProducto]  WITH CHECK ADD  CONSTRAINT [fk_idCategoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[tCategoria] ([idCategoria])
GO
ALTER TABLE [dbo].[tProducto] CHECK CONSTRAINT [fk_idCategoria]
GO
ALTER TABLE [dbo].[tUsuario]  WITH CHECK ADD  CONSTRAINT [fk_idRol] FOREIGN KEY([idRol])
REFERENCES [dbo].[tRol] ([idRol])
GO
ALTER TABLE [dbo].[tUsuario] CHECK CONSTRAINT [fk_idRol]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarUsuario]
	@Cedula VARCHAR(20),
	@Nombre VARCHAR(20),
	@Correo VARCHAR(100),
	@idRol INT,
	@id INT
AS
BEGIN

	UPDATE	tUsuario
	   SET	Cedula = @Cedula,
			Nombre = @Nombre,
			Correo = @Correo,
			idRol = CASE WHEN @idRol = 0 THEN idRol ELSE @idRol END
	 WHERE	id = @id

END
GO
/****** Object:  StoredProcedure [dbo].[CambiarEstadoUsuario]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarEstadoUsuario]
	@id INT
AS
BEGIN
	
	UPDATE	tUsuario
	SET		Estado = CASE WHEN Estado = 1 THEN 0 ELSE 1 END
	WHERE	id = @id

END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCarrrito]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarCarrrito]
		@id INT
AS
BEGIN

SELECT idCarrito
      ,C.id
	  ,U.Nombre
      ,C.idProducto
	  ,P.Descripcion
	  ,P.Precio
	  ,(P.Precio * Cantidades) SubTotal
	  ,(P.Precio * Cantidades) * 0.13 Impuesto
	  ,(P.Precio * Cantidades) + (P.Precio * Cantidades) * 0.13 Total
      ,Cantidades
      ,Fecha
  FROM dbo.tCarrito C
  INNER JOIN dbo.tUsuario U ON C.id = U.id
  INNER JOIN dbo.tProducto P ON C.idProducto = P.idProducto
  WHERE C.id = @id


END
GO
/****** Object:  StoredProcedure [dbo].[EditarCategoria]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarCategoria]
	@idCategoria int,
	@Nombre varchar(100)

AS
BEGIN

	UPDATE tCategoria
	   SET Nombre = @Nombre
 	 WHERE idCategoria = @idCategoria 

END
GO
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProducto]
	@idProducto int,
	@Descripcion varchar(100),
	@Precio int,
	@Cantidad int,
	@Categoria int,
	@Imagen varchar(500)
AS
BEGIN

	UPDATE [dbo].[tProducto]
	   SET [Descripcion] = @Descripcion
		  ,[Precio] = @Precio
		  ,[Cantidad] = @Cantidad
		  ,[idCategoria] = @Categoria
		  ,[Imagen] = @Imagen
 	 WHERE idProducto = @idProducto 

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCategoria]
@idCategoria int
AS
BEGIN	

DELETE FROM tCategoria
      WHERE idCategoria = @idCategoria

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[EliminarProducto]
	@idProducto int
AS
BEGIN	

DELETE FROM [dbo].[tProducto]
      WHERE idProducto = @idProducto

END
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
	@Correo			varchar(100),
	@Contrasenna	varchar(100)
AS
BEGIN

	SELECT	id,Cedula,Nombre,Correo,Estado,IdRol
	FROM	dbo.tUsuario
	WHERE	Correo = @Correo
		AND Contrasenna = @Contrasenna
		AND Estado = 1

END
GO
/****** Object:  StoredProcedure [dbo].[NuevaCategoria]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NuevaCategoria] 
	@Nombre varchar(100)
AS
BEGIN

	INSERT INTO [dbo].[tCategoria] ([Nombre])
     VALUES(@Nombre)
END
GO
/****** Object:  StoredProcedure [dbo].[PagarCarrito]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PagarCarrito]
	@id INT
AS
BEGIN
	SELECT ''
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCarrito]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarCarrito]
	@id INT,
	@idProducto INT,
	@Cantidades INT
AS
BEGIN

	IF NOT EXISTS(SELECT 1 FROM tCarrito WHERE id = @id
											AND idProducto = @idProducto)
	BEGIN 

			INSERT INTO tCarrito(id,idProducto,Cantidades,Fecha)
			VALUES(@id,@idProducto,@Cantidades,GETDATE())

	END
	ELSE
	BEGIN

		UPDATE tCarrito
		SET Cantidades = @Cantidades
		WHERE id = @id
			AND idProducto = @idProducto
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarProducto] 
	@Descripcion varchar(100),
	@Precio int,
	@Cantidad int,
	@Categoria int,
	@Imagen varchar(500)

AS
BEGIN

	INSERT INTO [dbo].[tProducto] ([Descripcion],[Precio],[Cantidad],[idCategoria],[Imagen])
     VALUES(@Descripcion,@Precio,@Cantidad,@Categoria,@Imagen)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 8/16/2024 6:23:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarUsuario]
	@Cedula	varchar(20),
	@Nombre			varchar(20),
	@Correo			varchar(100),
	@Contrasenna	varchar(100)
AS
BEGIN

	INSERT INTO dbo.tUsuario(Cedula,Nombre,Correo,Contrasenna,Estado,IdRol)
    VALUES(@Cedula,@Nombre,@Correo,@Contrasenna,1,1)

END

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidarUsuarioIdentificacion]
	@Cedula VARCHAR(20)
AS
BEGIN

	SELECT	id, Cedula, Nombre, Correo
	FROM	tUsuario
	WHERE	Cedula = @Cedula

END
GO

-- Crear RolesINSERTINTO [dbo].[tRol] (Nombre) VALUES ('Usuario');
INSERT INTO [dbo].[tRol] (Nombre) VALUES ('Usuario');
INSERT INTO [dbo].[tRol] (Nombre) VALUES ('Admin');

INSERT INTO [dbo].[tUsuario] (Cedula, Nombre, Correo, Contrasenna, Estado, idRol)
VALUES ('987654321', 'Mario Perez', 'mario@gmail.com', '1', 1, 1),
('123456789', 'Zhijian Chen', 'zchen80597@ufide.com', '1', 1, 2);


ALTER TABLE [dbo].[tUsuario]
ADD EsClaveTemporal BIT NULL,
    ClaveVencimiento DATETIME NULL;

GO
USE [master]
GO
ALTER DATABASE [proyecto] SET  READ_WRITE 
GO
