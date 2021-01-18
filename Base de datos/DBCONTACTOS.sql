USE master
GO

--DROP DATABASE DBCONTACTOS

CREATE DATABASE DBCONTACTOS
GO

USE DBCONTACTOS
GO

CREATE TABLE [dbo].[Estatus](
	IdEstatus    INT IDENTITY (1,1) NOT NULL,
	Descripcion  VARCHAR (50)       NOT NULL

	CONSTRAINT PK_Estatus_IdEstatus PRIMARY KEY (IdEstatus)
)

CREATE TABLE [dbo].[Genero](
	IdGenero    INT IDENTITY (1,1) NOT NULL,
	Descripcion  VARCHAR (50)       NOT NULL

	CONSTRAINT PK_Genero_IdGenero PRIMARY KEY (IdGenero)
)

CREATE TABLE [dbo].[Estado_Civil](
	IdEstado_Civil  INT IDENTITY (1,1) NOT NULL,
	Descripcion     VARCHAR (50)       NOT NULL

	CONSTRAINT PK_Estado_Civil_IdEstado_Civil PRIMARY KEY (IdEstado_Civil)
)

CREATE TABLE [dbo].[Rol](
	IdRol        INT IDENTITY (1,1) NOT NULL,
	Descripcion  VARCHAR (50)       NOT NULL

	CONSTRAINT PK_Rol_IdRol PRIMARY KEY (IdRol)
)


CREATE TABLE [dbo].[Tipo_Telefono](
	IdTipoTelefono  INT IDENTITY (1,1) NOT NULL,
	Descripcion     VARCHAR (50)       NOT NULL

	CONSTRAINT PK_Tipo_Telefono_IdTelefono PRIMARY KEY (IdTipoTelefono)
)

CREATE TABLE [dbo].[Tipo_Correo](
	IdTipoCorreo  INT IDENTITY (1,1) NOT NULL,
	Descripcion     VARCHAR (50)       NOT NULL

	CONSTRAINT PK_Tipo_Correo_IdCorreo PRIMARY KEY (IdTipoCorreo)
)

CREATE TABLE [dbo].[Usuario](
	IdUsuario   INT IDENTITY NOT NULL,
	Nombre      VARCHAR (50) NOT NULL,
	Apellidos   VARCHAR (50) NOT NULL,
	Correo      VARCHAR (50) NOT NULL,
	Contrasenia VARCHAR (50) NOT NULL,
	IdRol       INT          NOT NULL,

	IdEstatus         INT  NOT NULL,
	FechaRegistro     DATE NOT NULL,
	FechaModificacion DATE NULL,
	FeechaBaja        DATE NULL,

	CONSTRAINT PK_Usuario_IdUsuario PRIMARY KEY (IdUsuario),
	CONSTRAINT FK_Usuario_IdEstatus FOREIGN KEY (IdEstatus) REFERENCES [Estatus] (IdEstatus),
	CONSTRAINT FK_Usuario_IdRol     FOREIGN KEY (IdRol) REFERENCES [Rol] (IdRol)
)


CREATE TABLE [dbo].[Contacto](
	IdContacto     INT IDENTITY (1,1) NOT NULL,
	IdUsuario      INT                NOT NULL,
	IdEstado_Civil INT                NOT NULL,
	Nombre         VARCHAR (50)       NOT NULL,
	Apellidos      VARCHAR (20)       NOT NULL,
	Calle          VARCHAR (50)       NOT NULL,
	Colonia        VARCHAR (50)       NOT NULL,
	CodigoP        VARCHAR (50)       NOT NULL,
	NumExt         VARCHAR (50)       NOT NULL,
	Provicnia      VARCHAR (50)       NOT NULL,
	Edad		   VARCHAR (50)       NOT NULL,
	IdGenero	   INT				  NOT NULL,

	IdEstatus         INT  NOT NULL,
	FechaRegistro     DATE NOT NULL,
	FechaModificacion DATE NULL,
	FeechaBaja        DATE NULL,

	CONSTRAINT PK_Contacto_IdContacto PRIMARY KEY (IdContacto),
	CONSTRAINT FK_Contacto_IdEstatus FOREIGN KEY (IdEstatus) REFERENCES [Estatus] (IdEstatus),
	CONSTRAINT FK_Contacto_IdEstado_Civil FOREIGN KEY (IdEstado_Civil) REFERENCES [Estado_Civil] (IdEstado_Civil),
	CONSTRAINT FK_Contacto_IdGenero FOREIGN KEY (IdEstado_Civil) REFERENCES [Genero] (IdGenero),
	CONSTRAINT FK_Contacto_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES [Usuario] (IdUsuario)
)

CREATE TABLE [dbo].[Telefono](
	IdTelefono      INT IDENTITY (1,1) NOT NULL,
	IdContacto      INT				   NOT NULL,
	Numero          VARCHAR (50)       NOT NULL,
	IdTipoTelefono  INT                NOT NULL,

	IdEstatus         INT  NOT NULL,
	FechaRegistro     DATE NOT NULL,
	FechaModificacion DATE NULL,
	FechaBaja         DATE NULL,

	CONSTRAINT PK_Telefono_IdTelefono PRIMARY KEY (IdTelefono),
	CONSTRAINT PK_Telefono_IdContacto FOREIGN KEY (IdContacto) REFERENCES [Contacto] (IdContacto),
	CONSTRAINT PK_Telefono_IdTipoTelefono FOREIGN KEY (IdTipoTelefono) REFERENCES [Tipo_Telefono] (IdTipoTelefono),
	CONSTRAINT FK_Telefono_IdEstatus FOREIGN KEY (IdEstatus) REFERENCES [Estatus] (IdEstatus)
)

CREATE TABLE [dbo].[Correo](
	IdCorreo        INT IDENTITY (1,1) NOT NULL,
	IdContacto      INT				   NOT NULL,
	Email           VARCHAR (50)       NOT NULL,
	IdTipoCorreo    INT                NOT NULL,

	IdEstatus         INT  NOT NULL,
	FechaRegistro     DATE NOT NULL,
	FechaModificacion DATE NULL,
	FechaBaja         DATE NULL,

	CONSTRAINT PK_Correo_IdTelefono PRIMARY KEY (IdCorreo),
	CONSTRAINT PK_Correo_IdContacto FOREIGN KEY (IdContacto) REFERENCES [Contacto] (IdContacto),
	CONSTRAINT PK_Correo_IdTipoTelefono FOREIGN KEY (IdTipoCorreo) REFERENCES [Tipo_Correo] (IdTipoCorreo),
	CONSTRAINT FK_Correo_IdEstatus FOREIGN KEY (IdEstatus) REFERENCES [Estatus] (IdEstatus)
)

INSERT INTO Estado_Civil
VALUES('Soltero'),
	  ('Casado'),
	  ('Viudo'),
	  ('Union Libre')

INSERT INTO Tipo_Correo
VALUES('Personal'),
	  ('Institucional')

INSERT INTO Tipo_Telefono
VALUES('Oficina'),
	  ('Casa')

INSERT INTO Rol
VALUES('Administrador'),
	  ('Capturista')

INSERT INTO Estatus
VALUES('Activo'),
	  ('Inactivo')

INSERT INTO Genero
VALUES('Masculino'),
	  ('Femenino')


INSERT INTO Usuario (Nombre, Apellidos, Correo, Contrasenia, IdRol, IdEstatus, FechaRegistro)
VALUES ( 'Carlos Eduardo', 'Rodriguez Perales', 'carlos.ed702@gamil.com', 'carlos.rp', 1, 1, GETDATE() )

INSERT INTO Usuario (Nombre, Apellidos, Correo, Contrasenia, IdRol, IdEstatus, FechaRegistro)
VALUES ( 'Nuevo Usuario', 'Nuevo Usuario', 'carlos@gamil.com', 'carlos.rp', 1, 1, GETDATE() )

INSERT INTO Contacto 
		(IdUsuario,IdEstado_Civil, 
	     Nombre, Apellidos,
		 Calle, Colonia, CodigoP, NumExt,Provicnia, 
		 Edad, IdGenero, IdEstatus, FechaRegistro )
VALUES ( 1, 1, 'Un Wey', 'Sus apellidos', 'su calle', 'su colonia', 'su codigo postal', '22331', 'Apodaca', '25', '1', 1, GETDATE())


INSERT INTO  Telefono( IdContacto, Numero, IdTipoTelefono, IdEstatus, FechaRegistro)
VALUES( 1, '8110471160', 1, 1, GETDATE() )


INSERT INTO  Correo( IdContacto, Email, IdTipoCorreo, IdEstatus, FechaRegistro)
VALUES( 1, 'carlos124@correo.com', 1, 1, GETDATE() )


SELECT * FROM [Tipo_Correo]
SELECT * FROM [Tipo_Telefono]
SELECT * FROM [Rol]
SELECT * FROM [Estatus]

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spCatalogos')
BEGIN
	DROP PROC spCatalogo
END
GO
CREATE PROCEDURE [dbo].[spCatalogo](
	@Accion INT
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT * FROM Tipo_Correo
	END

	IF @Accion = 2
	BEGIN
		SELECT * FROM Tipo_Telefono
	END

	IF @Accion = 3
	BEGIN
		SELECT * FROM Rol
	END
	
	IF @Accion = 4
	BEGIN
		SELECT * FROM Estatus
	END
END

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spUsuario')
BEGIN
	DROP PROC spUsuario
END
GO
CREATE PROCEDURE [dbo].[spUsuario](
	@Accion      INT,
	@IdUsuario   INT          = NULL,
	@Nombre      VARCHAR (50) = NULL,
	@Apellidos   VARCHAR (50) = NULL,
	@Correo      VARCHAR (50) = NULL,
	@Contrasenia VARCHAR (50) = NULL,
	@IdRol        INT         = NULL,

	@IdEstatus         INT  = NULL,
	@FechaRegistro     DATE = NULL,
	@FechaModificacion DATE = NULL,
	@FeechaBaja        DATE = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT U.Nombre, U.Apellidos, U.Correo, U.IdRol, U.IdEstatus
		FROM Usuario U
		WHERE Correo = @Correo AND Contrasenia = @Contrasenia
	END

	IF @Accion = 2
	BEGIN
		SELECT U.Nombre, U.Apellidos, U.Correo, U.IdRol, U.IdEstatus
		FROM Usuario U
		WHERE IdUsuario = @IdUsuario
	END

	IF @Accion = 3
	BEGIN
		SELECT U.Nombre, U.Apellidos, U.Correo, R.Descripcion AS 'Rol', ES.Descripcion AS 'Estatus'
		FROM Usuario U
		INNER JOIN Rol R ON U.IdRol = r.IdRol
		INNER JOIN Estatus ES ON U.IdEstatus = ES.IdEstatus
		WHERE ( U.Nombre LIKE '%' + @Nombre + '%' OR @Nombre IS NULL ) AND
			  ( U.Apellidos LIKE '%' + @Apellidos + '%' OR @Apellidos IS NULL ) AND
			  ( U.IdRol = @IdRol OR @IdRol IS NULL ) AND 
			  ( U.Correo = @Correo OR @Correo IS NULL )
	END

	IF @Accion = 4
	BEGIN
		INSERT INTO Usuario (Nombre, Apellidos, Correo, Contrasenia, IdRol, IdEstatus, FechaRegistro)
		VALUES ( @Nombre, @Apellidos, @Correo, @Contrasenia, @IdRol, 1, GETDATE() )
	END

	IF @Accion = 5
	BEGIN
		UPDATE Usuario
		SET Nombre = @Nombre,
			Apellidos = @Apellidos
		WHERE IdUsuario = @IdUsuario
	END

	IF @Accion = 6
	BEGIN
		UPDATE Usuario
		SET IdEstatus = 2
		WHERE IdUsuario = @IdUsuario
	END
END


IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spContactos')
BEGIN
	DROP PROC spContactos
END
GO
CREATE PROCEDURE [dbo].[spContactos](
	@Accion      INT,
	@IdContacto  INT          = NULL,
	@IdUsuario   INT          = NULL,
	@IdEstado_Civil INT       = NULL,
	@Nombre      VARCHAR (50) = NULL,
	@Apellidos   VARCHAR (20) = NULL,
	@Calle       VARCHAR (50) = NULL,
	@Colonia     VARCHAR (50) = NULL,
	@CodigoP     VARCHAR (50) = NULL,
	@NumExt      VARCHAR (50) = NULL,
	@Provicnia   VARCHAR (50) = NULL,
	@Edad		 VARCHAR (50) = NULL,
	@IdGenero    INT		  = NULL,

	@IdEstatus         INT  = NULL,
	@FechaRegistro     DATE = NULL,
	@FechaModificacion DATE = NULL,
	@FeechaBaja        DATE = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT C.IdContacto, c.IdEstado_Civil, C.Nombre, C.Apellidos, ESC.Descripcion AS 'Estado Civil', c.Edad
		FROM Contacto C
		INNER JOIN Estado_Civil ESC ON C.IdEstado_Civil = ESC.IdEstado_Civil
		WHERE  ( C.Nombre LIKE '%' + @Nombre + '%' OR @Nombre IS NULL ) AND
			   ( C.Apellidos LIKE '%' + @Apellidos + '%' OR @Apellidos IS NULL ) AND
			   ( C.IdGenero = @IdGenero OR @IdGenero IS NULL ) AND
			   ( C.IdEstatus = @IdEstatus OR @IdEstatus IS NULL )
	END

	IF @Accion = 2
	BEGIN
		SELECT *
		FROM Contacto
		WHERE  IdContacto = @IdContacto
	END

	IF @Accion = 3
	BEGIN
		UPDATE Contacto
		SET Nombre = @Nombre,
			Apellidos = @Apellidos,
			Calle = @Calle,
			Colonia = @Colonia,
			CodigoP = @CodigoP,   
			NumExt = @NumExt,    
			Provicnia = @Provicnia,
			FechaModificacion = GETDATE()
		WHERE IdContacto = @IdContacto
	END

	IF @Accion = 4
	BEGIN
		UPDATE Contacto
		SET IdEstatus = 2
		WHERE IdContacto = @IdContacto
	END

	IF @Accion = 5
	BEGIN
		INSERT INTO Contacto 
		(IdUsuario,IdEstado_Civil, 
	     Nombre, Apellidos,
		 Calle, Colonia, CodigoP, NumExt,Provicnia, 
		 Edad, IdGenero, IdEstatus, FechaRegistro )
		 VALUES ( @IdUsuario, @IdEstado_Civil, @Nombre, @Apellidos, @Calle, @Colonia, @CodigoP, @NumExt, @Provicnia, @Edad, @IdGenero, 1, GETDATE())
	END
END

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spTelefono')
BEGIN
	DROP PROC spTelefono
END
GO
CREATE PROCEDURE [dbo].[spTelefono](
	@Accion          INT         = NULL,
	@IdTelefono      INT         = NULL,
	@IdContacto      INT			= NULL,
	@Numero          VARCHAR (50)= NULL,
	@IdTipoTelefono  INT         = NULL,

	@IdEstatus         INT  = NULL,
	@FechaRegistro     DATE = NULL,
	@FechaModificacion DATE = NULL,
	@FechaBaja         DATE = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT * 
		FROM Telefono
		WHERE IdContacto = @IdContacto
	END

	IF @Accion = 2
	BEGIN
		SELECT * 
		FROM Telefono
		WHERE IdTelefono = @IdTelefono
	END

	IF @Accion = 3
	BEGIN
		INSERT INTO  Telefono( IdContacto, Numero, IdTelefono, IdEstatus, FechaRegistro)
		VALUES( @IdContacto, @Numero, @IdTipoTelefono, 1, GETDATE() )
	END

	IF @Accion = 4
	BEGIN
		UPDATE Telefono
		SET Numero = @Numero,
			FechaModificacion = @FechaModificacion
		WHERE IdTelefono = @IdTelefono
	END

	IF @Accion = 5
	BEGIN
		UPDATE Telefono
		SET IdEstatus = 2,
			FechaBaja = @FechaBaja
		WHERE IdTelefono = @IdTelefono
	END
END

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spCorreo')
BEGIN
	DROP PROC spCorreo
END
GO
CREATE PROCEDURE [dbo].[spCorreo](
	@Accion         INT           = NULL,
	@IdCorreo       INT           = NULL,
	@IdContacto     INT			  = NULL,
	@Email          VARCHAR (50)  = NULL,
	@IdTipoCorreo   INT           = NULL,

	@IdEstatus         INT  = NULL,
	@FechaRegistro     DATE = NULL,
	@FechaModificacion DATE = NULL,
	@FechaBaja         DATE = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN
		SELECT * 
		FROM Correo
		WHERE IdContacto = @IdContacto
	END

	IF @Accion = 2
	BEGIN
		SELECT * 
		FROM Correo
		WHERE IdCorreo = @IdCorreo
	END

	IF @Accion = 3
	BEGIN
		INSERT INTO  Correo( IdContacto, Email, IdTipoCorreo, IdEstatus, FechaRegistro)
		VALUES( @IdContacto, @Email, @IdTipoCorreo, 1, GETDATE() )
	END

	IF @Accion = 4
	BEGIN
		UPDATE Correo
		SET Email = @Email,
			FechaModificacion = @FechaModificacion
		WHERE IdCorreo = @IdCorreo
	END

	IF @Accion = 5
	BEGIN
		UPDATE Correo
		SET IdEstatus = 2,
			FechaBaja = @FechaBaja
		WHERE IdCorreo = @IdCorreo
	END
END

--DROP TABLE [Correo]
--DROP TABLE [Telefono]
--DROP TABLE [Contacto]
--DROP TABLE [Usuario]
--DROP TABLE [Tipo_Correo]
--DROP TABLE [Tipo_Telefono]
--DROP TABLE [Rol]
--DROP TABLE [Estatus]

--DROP PROC spCatalogo
--DROP PROC spContactos
--DROP PROC spCorreo
--DROP PROC spTelefono
--DROP PROC spUsuario


SELECT U.Nombre, U.Apellidos, U.Correo, R.Descripcion, R.IdRol, ES.IdEstatus, ES.IdEstatus
		FROM Usuario U
		INNER JOIN Rol R ON U.IdRol = r.IdRol
		INNER JOIN Estatus ES ON U.IdEstatus = ES.IdEstatus