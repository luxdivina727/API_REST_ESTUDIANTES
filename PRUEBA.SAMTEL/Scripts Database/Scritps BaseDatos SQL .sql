
IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'PRUEBA_SAMTEL')) 
BEGIN
	CREATE DATABASE PRUEBA_SAMTEL
END
-------------------- CREACIÓN TABLAS -----------------------------------------------------------
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TipoIdentificacion')
BEGIN
	CREATE TABLE [dbo].[TipoIdentificacion] (
		[TipoIdentificacionId]                              TINYINT          IDENTITY (1, 1) NOT NULL,
		[TipoIdentificacionNombre]							VARCHAR (MAX)					NOT NULL,
		CONSTRAINT [PK_TipoIdentificacion] PRIMARY KEY CLUSTERED ([TipoIdentificacionId] ASC)
	);
END

IF  EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TipoIdentificacion')
BEGIN
	INSERT INTO [dbo].[TipoIdentificacion] (TipoIdentificacionNombre) VALUES ('Cédula Ciudadania')
	INSERT INTO [dbo].[TipoIdentificacion] (TipoIdentificacionNombre) VALUES ('Tarjeta Identidad')
	INSERT INTO [dbo].[TipoIdentificacion] (TipoIdentificacionNombre) VALUES ('Cédula Extranjería')

END

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Alumno')
BEGIN
	CREATE TABLE [dbo].[Alumno] (
		[AlumnoId]                              BIGINT          IDENTITY (1, 1) NOT NULL,
		[AlumnoNombre]							VARCHAR (MAX)					NOT NULL,
		[AlumnoApellido]                        VARCHAR (MAX)					NOT NULL,
		[AlumnoDireccion]                       VARCHAR (250)					NOT NULL,
		[AlumnoTelefono]                        BIGINT 							NOT NULL,
		[AlumnoFechaNacimiento]                 DATETIME						NOT NULL,
		[TipoIdentificacionId]					TINYINT							NOT NULL,
		[AlumnoIdentificacion]                  BIGINT							NOT NULL,
		CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED ([AlumnoId] ASC)
	);
END
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Alumno')
BEGIN
	ALTER TABLE [dbo].[Alumno]
	ADD CONSTRAINT [FK_Alumno_TipoIdentificacion] FOREIGN KEY ([TipoIdentificacionId]) REFERENCES [dbo].[TipoIdentificacion] ([TipoIdentificacionId]);

END

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Materia')
BEGIN
	CREATE TABLE [dbo].[Materia] (
		[MateriaId]                             BIGINT          IDENTITY (1, 1) NOT NULL,
		[MateriaNombre]							VARCHAR (MAX)					NOT NULL,
		[MateriaNumeroHoras]                    INT								NOT NULL,
		CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED ([MateriaId] ASC)
	);
END

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AlumnoMateria')
BEGIN
	CREATE TABLE [dbo].[AlumnoMateria] (
		[AlumnoMateriaId]								BIGINT          IDENTITY (1, 1) NOT NULL,
		[AlumnoId]										BIGINT							NOT NULL,
		[MateriaId]										BIGINT							NOT NULL,
		[AlumnoMateriaNota]								BIGINT							NOT NULL,
		CONSTRAINT [PK_AlumnoMateria] PRIMARY KEY CLUSTERED ([AlumnoMateriaId] ASC)
	);
END
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AlumnoMateria')
BEGIN
	ALTER TABLE [dbo].[AlumnoMateria]
	ADD CONSTRAINT [FK_AlumnoMateria_Alumno] FOREIGN KEY ([AlumnoId]) REFERENCES [dbo].[Alumno] ([AlumnoId]),
		CONSTRAINT [FK_AlumnoMateria_Materia] FOREIGN KEY ([MateriaId]) REFERENCES [dbo].[Materia] ([MateriaId]);

END

---------------------------------------------- PROCEDIMIENTOS ALMACENADOS --------------------------------------------


IF OBJECT_ID('dbo.InsertarAlumno' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.InsertarAlumno
GO

CREATE PROCEDURE [dbo].[InsertarAlumno]
(
	@alumnoNombre VARCHAR(MAX),
	@alumnoApellido VARCHAR(MAX),
	@alumnoDireccion VARCHAR(250),
	@alumnoTelefono BIGINT,	
	@alumnoFechaNacimiento DATETIME,
	@tipoIdentificacionId TINYINT,
	@alumnoIdentificacion BIGINT
)
AS
BEGIN
	
	INSERT INTO [dbo].[Alumno]
	(
		AlumnoNombre,
		AlumnoApellido,
		AlumnoDireccion,
		AlumnoTelefono,
		AlumnoFechaNacimiento,
		TipoIdentificacionId,
		AlumnoIdentificacion
	)
	VALUES 
	(	
		@alumnoNombre,
		@alumnoApellido,
		@alumnoDireccion,
		@alumnoTelefono,
		@alumnoFechaNacimiento,
		@tipoIdentificacionId,	
		@alumnoIdentificacion
	)

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

IF OBJECT_ID('dbo.InsertarMateria' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.InsertarMateria
GO

CREATE PROCEDURE [dbo].[InsertarMateria]
(
	@materiaNombre VARCHAR(MAX),
	@materiaNumeroHoras INT
)
AS
BEGIN
	
	INSERT INTO [dbo].[Materia]
	(
		MateriaNombre,
		MateriaNumeroHoras
	)
	VALUES 
	(	
		@materiaNombre,
		@materiaNumeroHoras
	)

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

IF OBJECT_ID('dbo.InsertarAlumnoMateria' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.InsertarAlumnoMateria
GO

CREATE PROCEDURE [dbo].[InsertarAlumnoMateria]
(
	@alumnoId BIGINT,
	@materiaId BIGINT
)
AS
BEGIN
	
	INSERT INTO [dbo].[AlumnoMateria]
	(
		AlumnoId,
		MateriaId
	)
	VALUES 
	(	
		@alumnoId,
		@materiaId
	)

	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO


IF OBJECT_ID('dbo.ListarTipoIdentificacion' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ListarTipoIdentificacion
GO

CREATE PROCEDURE [dbo].[ListarTipoIdentificacion]
AS

BEGIN
     
	SELECT
		*
	FROM
		[dbo].[TipoIdentificacion]

END
GO


IF OBJECT_ID('dbo.ListarAlumno' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ListarAlumno
GO

CREATE PROCEDURE [dbo].[ListarAlumno]
AS

BEGIN
     
	SELECT
		*
	FROM
		[dbo].[Alumno]

END
GO


IF OBJECT_ID('dbo.ListarMateria' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ListarMateria
GO

CREATE PROCEDURE [dbo].[ListarMateria]
AS

BEGIN
     
	SELECT
		*
	FROM
		[dbo].[Materia]

END
GO


IF OBJECT_ID('dbo.ListarAlumnoMateria' , 'P') IS NOT NULL
	DROP PROCEDURE dbo.ListarAlumnoMateria
GO

CREATE PROCEDURE [dbo].[ListarAlumnoMateria]
(
@alumnoId BIGINT
)
AS

BEGIN
     
	SELECT
		*
	FROM
		[dbo].[AlumnoMateria] where AlumnoId=@alumnoId

END
GO