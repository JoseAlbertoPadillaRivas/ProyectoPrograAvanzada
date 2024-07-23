CREATE DATABASE proyecto;
USE proyecto;

CREATE TABLE tUsuario(
id int not null primary key IDENTITY(1,1),
Cedula varchar(20) not null,
Nombre varchar(20) not null,
Correo varchar(100) not null,
Contrasenna varchar(100) not null,
Estado bit not null,
idRol  int not null
);

SELECT * FROM tUsuario

CREATE TABLE tProducto(
id int not null primary key IDENTITY(1,1),
Nombre varchar(100) not null,
Precio int not null,
Cantidad int not null,
idCategoria int not null
);

CREATE TABLE tCategoria(
idCategoria int not null primary key IDENTITY(1,1),
Nombre varchar(100) not null
);

CREATE TABLE tRol(
idRol int not null primary key IDENTITY(1,1),
Nombre varchar(100) not null
);

ALTER TABLE tProducto
ADD CONSTRAINT fk_idCategoria
FOREIGN KEY (idCategoria) REFERENCES tCategoria(idCategoria);

ALTER TABLE tUsuario
ADD CONSTRAINT fk_idRol
FOREIGN KEY (idRol) REFERENCES tRol(idRol);

INSERT INTO tRol (Nombre) VALUES('administrador');
INSERT INTO tRol (Nombre) VALUES('usuario');


CREATE PROCEDURE RegistrarUsuario
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

CREATE PROCEDURE IniciarSesion
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

CREATE PROCEDURE ActualizarUsuario
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

CREATE PROCEDURE CambiarEstadoUsuario
	@id INT
AS
BEGIN
	
	--borrado lógico
	UPDATE	tUsuario
	SET		Estado = CASE WHEN Estado = 1 THEN 0 ELSE 1 END
	WHERE	id = @id

	--borrado físico
	--DELETE FROM tUsuario 
	--WHERE	Consecutivo = @Consecutivo

END
GO

	INSERT INTO dbo.tUsuario(Cedula,Nombre,Correo,Contrasenna,Estado,IdRol)
    VALUES(160,'Jose','josepr@gmail.com','1',1,2)



