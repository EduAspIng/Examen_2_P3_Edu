CREATE DATABASE DB_EDU_EX2
/*Tablas*/
GO
USE DB_EDU_EX2

GO
CREATE TABLE usuarios
(
id INT IDENTITY, 
nombre VARCHAR(50) NOT NULL, 
correo VARCHAR(50),
numero VARCHAR(50) UNIQUE,
CONSTRAINT pk_idusuario PRIMARY KEY(id)
) 

GO
CREATE TABLE equipos
(
id INT IDENTITY, 
tipo VARCHAR(50) NOT NULL, 
modelo VARCHAR(50),
idusuario INT,
CONSTRAINT pk_idequipo PRIMARY KEY(id),
CONSTRAINT fk_idusuario FOREIGN KEY (idusuario) REFERENCES usuarios(id)
)

GO
CREATE TABLE tecnicos
(
id INT IDENTITY, 
nombre VARCHAR(50), 
especialidad VARCHAR(50),
CONSTRAINT pk_idtecnico PRIMARY KEY(id)
)

GO
CREATE TABLE reparaciones
(
id INT IDENTITY, 
idequipo INT,
fecha_solicitud DATETIME CONSTRAINT df_fecha_solicitud DEFAULT GETDATE(), 
estado VARCHAR(50),
CONSTRAINT pk_idreparacion PRIMARY KEY(id),
CONSTRAINT fk_idequipo FOREIGN KEY (idequipo) REFERENCES equipos(id)
)

GO
CREATE TABLE asignaciones
(
id INT IDENTITY, 
idreparacion INT,
idtecnico INT,
fecha_asignacion DATETIME CONSTRAINT df_fecha_asignacion DEFAULT GETDATE(), 
CONSTRAINT pk_idasignacion PRIMARY KEY(id),
CONSTRAINT fk_idreparacion FOREIGN KEY (idreparacion) REFERENCES reparaciones(id),
CONSTRAINT fk_idtecnico FOREIGN KEY (idtecnico) REFERENCES tecnicos(id)
)

GO
CREATE TABLE detalles_reparaciones
(
id INT IDENTITY, 
idreparacion INT,
descripcion VARCHAR(50),
fecha_inicio DATETIME CONSTRAINT df_fecha_inicio DEFAULT GETDATE(),
fecha_final DATETIME CONSTRAINT df_fecha_final DEFAULT GETDATE(),
CONSTRAINT pk_iddetalle_reparacion PRIMARY KEY(id),
CONSTRAINT fk_idreparacion2 FOREIGN KEY (idreparacion) REFERENCES reparaciones(id)
)

/*Procedimientos usuario*/
GO
CREATE PROCEDURE agregar_usuario
@nombre VARCHAR(50), 
@correo VARCHAR(50),
@numero VARCHAR(50) 
 AS 
   BEGIN 
     INSERT INTO  usuarios (nombre, correo, numero) VALUES (@nombre,@correo,@numero)
   END
GO

   CREATE PROCEDURE borrar_usuario
   @cedula INT 
 AS 
   BEGIN 
      DELETE usuarios WHERE id = @cedula
   END
GO

   CREATE PROCEDURE consultar_filtro_usuario
   @cedula INT  
 AS 
   BEGIN 
      SELECT * FROM usuarios WHERE id = @cedula
   END
GO

   CREATE PROCEDURE modificar_usuario
   @cedula INT, 
   @nombre VARCHAR(50), 
@correo VARCHAR(50),
@numero VARCHAR(50) 
 AS 
   BEGIN 
     UPDATE usuarios SET nombre = @nombre, correo=@correo, numero=@numero WHERE id = @cedula
   END
GO

/*Procedimientos tecnico*/
GO
CREATE PROCEDURE agregar_tecnico
@nombre VARCHAR(50), 
@especialidad VARCHAR(50)
 AS 
   BEGIN 
     INSERT INTO  tecnicos(nombre, especialidad) VALUES (@nombre,@especialidad)
   END
GO

   CREATE PROCEDURE borrar_tecnico
   @cedula INT 
 AS 
   BEGIN 
      DELETE tecnicos WHERE id = @cedula
   END
GO

   CREATE PROCEDURE consultar_filtro_tecnico
   @cedula INT  
 AS 
   BEGIN 
      SELECT * FROM tecnicos WHERE id = @cedula
   END
GO

   CREATE PROCEDURE modificar_tecnico
   @cedula INT, 
@nombre VARCHAR(50), 
@especialidad VARCHAR(50)
 AS 
   BEGIN 
     UPDATE tecnicos SET nombre = @nombre, especialidad=@especialidad WHERE id = @cedula
   END
GO

/*Procedimientos equipo*/
GO
CREATE PROCEDURE agregar_equipo
@tipo VARCHAR(50), 
@modelo VARCHAR(50),
@idusuario INT
 AS 
   BEGIN 
     INSERT INTO  equipos (tipo, modelo, idusuario) VALUES (@tipo,@modelo,@idusuario)
   END
GO

   CREATE PROCEDURE borrar_equipo
   @serie INT 
 AS 
   BEGIN 
      DELETE equipos WHERE id = @serie
   END
GO

   CREATE PROCEDURE consultar_filtro_equipo
   @serie INT  
 AS 
   BEGIN 
      SELECT * FROM equipos WHERE id = @serie
   END
GO

   CREATE PROCEDURE modificar_equipo
   @serie INT, 
@tipo VARCHAR(50), 
@modelo VARCHAR(50),
@idusuario INT
 AS 
   BEGIN 
     UPDATE equipos SET tipo = @tipo, modelo=@modelo, idusuario=@idusuario WHERE id = @serie
   END
GO
