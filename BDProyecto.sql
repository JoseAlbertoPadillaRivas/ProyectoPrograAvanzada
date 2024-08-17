create database [proyecto]
go

USE [proyecto]
GO
/****** Object:  Table [dbo].[tCategoria]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  Table [dbo].[tProducto]    Script Date: 30/7/2024 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProducto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[tRol]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  Table [dbo].[tUsuario]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[CambiarEstadoUsuario]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[EditarCategoria]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[EditarProducto]    Script Date: 30/7/2024 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarProducto]
	@idProducto int,
	@Nombre varchar(100),
	@Precio int,
	@Cantidad int,
	@Categoria int,
	@Imagen varchar(500)
AS
BEGIN

	UPDATE [dbo].[tProducto]
	   SET [Nombre] = @Nombre
		  ,[Precio] = @Precio
		  ,[Cantidad] = @Cantidad
		  ,[idCategoria] = @Categoria
		  ,[Imagen] = @Imagen
 	 WHERE idProducto = @idProducto 

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCategoria]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[EliminarProducto]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[NuevaCategoria]    Script Date: 30/7/2024 16:01:39 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarProducto]    Script Date: 30/7/2024 16:01:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarProducto] 
	@Nombre varchar(100),
	@Precio int,
	@Cantidad int,
	@Categoria int,
	@Imagen varchar(500)

AS
BEGIN

	INSERT INTO [dbo].[tProducto] ([Nombre],[Precio],[Cantidad],[idCategoria],[Imagen])
     VALUES(@Nombre,@Precio,@Cantidad,@Categoria,@Imagen)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 30/7/2024 16:01:39 ******/
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
