/********TABLAS***********/

create table poi
(
	id_poi INT IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(50),
	longitud int,
	latitud int,
	direccion varchar(255),
	es_banco bit
)
GO


create table parada
(
	id_parada INT IDENTITY(1,1) PRIMARY KEY,
	id_poi int FOREIGN KEY REFERENCES poi,
	numero int
)
GO

create table cgp
(
	id_cgp INT IDENTITY(1,1) PRIMARY KEY,
	id_poi int FOREIGN KEY REFERENCES poi,
	comuna int
)
GO

create table servicio
(
	id_servicio INT IDENTITY(1,1) PRIMARY KEY,
	descripcion nvarchar(255)
)
GO

create table servicios_cgp
(
	id_cgp int foreign key references cgp,
	id_servicio int foreign key references servicio,
	constraint pk_servicios_cgp primary key clustered (id_cgp, id_servicio)
)
GO

create table local
(
	id_local INT IDENTITY(1,1) PRIMARY KEY,
	id_poi int FOREIGN KEY REFERENCES poi,
	radio_cercania int
)
GO

create table rubro
(
	id_rubro INT IDENTITY(1,1) PRIMARY KEY,
	descripcion nvarchar(255)
)
GO

create table rubros_local
(
	id_local int foreign key references local,
	id_rubro int foreign key references rubro,
	constraint pk_rubros_local primary key clustered (id_local, id_rubro)
)
GO


CREATE TABLE Usuarios
(
Nombre VARCHAR(50) PRIMARY KEY ,
Contraseña VARCHAR(50),
Tipo_Admin INT,
Mail VARCHAR(50),
TiempoMaxBusqueda INT  
)
GO

/********PROCEDURES***********/

create procedure obtenerParadas
as
begin
	select nombre, longitud, latitud, direccion, numero
	from poi po join parada pa 
	on po.id_poi = pa.id_poi
end
go

create procedure obtenerBancos
as
begin
	select nombre, longitud, latitud, direccion
	from poi 
	where es_banco like 1
end
go


create procedure obtenerLocales
as
begin
	select id_local, nombre, longitud, latitud, direccion, radio_cercania
	from poi po join local lo 
on po.id_poi = lo.id_poi
end
go

create procedure obtenerCgps
as
begin
	select id_cgp, nombre, longitud, latitud, direccion, comuna
	from poi po join cgp c
	on po.id_poi = c.id_poi
end
go

create procedure obtenerServiciosDeCgp (@id_cgp int)
as
begin
	select descripcion
	from servicio s join servicios_cgp sc
	on s.id_servicio = sc.id_servicio
	join cgp c
	on c.id_cgp = sc.id_cgp
end
go

create procedure obtenerRubrosDeLocal (@id_cgp int)
as
begin
	select descripcion
	from rubro r join rubros_local rl
	on r.id_rubro = rl.id_rubro
	join local l
	on l.id_local = rl.id_local
end
go



--AGREGO USUARIO ADMINISTRADOR

INSERT INTO Usuarios 
(Nombre,Contraseña,Tipo_Admin,Mail,TiempoMaxBusqueda)
values('usuario1','123',1,'gaby_filipe@hotmail.com',5)

CREATE TABLE UsuarioSesionActual
(
Nombre VARCHAR(50)
)
GO

Create table Consultas
(
id INT IDENTITY(1,1) PRIMARY KEY,
texto varchar(50),
cantidadResultados INT,
tiempoConsulta INT,
usuario varchar(50),
fecha datetime DEFAULT GETDATE()
)
GO

CREATE procedure [dbo].[loguear](
	@usuario varchar(50),
	@contraseña varchar(50),
	@logueado int output,
	@mensaje varchar(40) output,
	@tipo_admin int output
)
as
begin
Select @logueado=COUNT(u.Nombre) from Usuarios u
where Nombre=@usuario and Contraseña=@contraseña

if (@logueado>0)begin
select @mensaje='Bienvenido usuario: '+ UPPER(u.Nombre),@tipo_admin=u.Tipo_Admin from Usuarios u
where Nombre=@usuario and Contraseña=@contraseña
end
end
GO


CREATE PROCEDURE agregarConsulta
	@texto varchar(50),
	@cantidadResultados INT,
	@tiempoConsulta INT	
AS
	DECLARE @usuario varchar(50)
	select @usuario=Nombre from UsuarioSesionActual 	 
	INSERT INTO Consultas (texto,cantidadResultados,tiempoConsulta,usuario) VALUES (@texto,@cantidadResultados,@tiempoConsulta,@usuario)	
GO


CREATE PROCEDURE GuardarUsuarioSesionActual
	@usuario varchar(50)
AS
	DELETE UsuarioSesionActual 
	INSERT INTO UsuarioSesionActual (Nombre) values (@usuario)
GO

CREATE PROCEDURE cantidadDeBusquedasPorFecha
AS
SELECT CAST( fecha AS VARCHAR(12)) 'Fecha', COUNT(id) 'Cantidad busquedas' from Consultas
GROUP BY CAST( fecha AS VARCHAR(12))
ORDER BY CAST( fecha AS VARCHAR(12))   
GO 

CREATE PROCEDURE resultadosParciales
AS
SELECT usuario, cantidadResultados 'Cantidad Resultados Parciales' from Consultas
ORDER BY usuario
GO

CREATE PROCEDURE resultadosTotales
AS
SELECT usuario, SUM(cantidadResultados) 'Cantidad Resultados Totales' from Consultas
GROUP BY usuario 
ORDER BY usuario;
GO 

CREATE PROCEDURE guardarParametrosBusqueda
	@mail varchar(50),
	@tiempoMaxBusqueda INT
AS
DECLARE @usuario varchar(50)
SELECT @usuario=Nombre from UsuarioSesionActual 
UPDATE Usuarios
set Mail = @mail,
TiempoMaxBusqueda=@tiempoMaxBusqueda
WHERE Nombre=@usuario 
GO 

CREATE PROCEDURE obtenerParametrosBusqueda
AS
SELECT u2.Mail,u2.TiempoMaxBusqueda from Usuarios u2 where u2.Nombre=(SELECT u.Nombre from UsuarioSesionActual u) 
GO   

/************************AGREGO POIS*************************/

/*AGREGO PARADA DEL 114*/
INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco)
values(6,8,'parada del 114' ,'avellaneda 367', 0)

INSERT INTO parada
(id_poi, numero)
values(1, 114)
 
/*AGREGO BANCO SANTANDER*/
 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco)
values(6,9,'banco santander' ,'lavalle 1502', 1)


/*AGREGO CGP "COMUNA 2"*/
INSERT INTO servicio
(descripcion)
values('un servicio')

 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco)
values(5,3,'comuna numero 2' ,'av cordoba 1000', 0)

INSERT INTO cgp
(comuna)
values(2)

INSERT INTO servicios_cgp
(id_cgp, id_servicio)
values(1,1)

/*AGREGO LOCAL LIBRERIA*/
 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco)
values(5,3,'libreria escolar' ,'medrano 1200', 0)

INSERT INTO local
(radio_cercania)
values(500)

INSERT INTO rubro
(descripcion)
values('libreria')

INSERT INTO rubros_local
(id_local, id_rubro)
values(1,1)