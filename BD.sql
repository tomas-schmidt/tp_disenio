/********TABLAS***********/

/****************************************************************
 *							poi
 ****************************************************************/
create table poi
(
	id_poi INT IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(50),
	longitud numeric(18,2),
	latitud numeric(18,2),
	direccion varchar(255),
	es_banco bit,
	habilitado bit
)
GO

/****************************************************************
 *						  parada
 ****************************************************************/
create table parada
(
	id_parada INT IDENTITY(1,1) PRIMARY KEY,
	id_poi int FOREIGN KEY REFERENCES poi,
	numero int
)
GO


/****************************************************************
 *							cgp
 ****************************************************************/
create table cgp
(
	id_cgp INT IDENTITY(1,1) PRIMARY KEY,
	id_poi int FOREIGN KEY REFERENCES poi,
	comuna int
)
GO

/****************************************************************
 *							servicio
 ****************************************************************/
create table servicio
(
	id_servicio INT IDENTITY(1,1) PRIMARY KEY,
	descripcion nvarchar(255)
)
GO


/****************************************************************
 *							servicios_cgp
 ****************************************************************/
create table servicios_cgp
(
	id_cgp int foreign key references cgp,
	id_servicio int foreign key references servicio,
	constraint pk_servicios_cgp primary key clustered (id_cgp, id_servicio)
)
GO

/****************************************************************
 *							local
 ****************************************************************/
create table local
(
	id_local INT IDENTITY(1,1) PRIMARY KEY,
	id_poi int FOREIGN KEY REFERENCES poi,
	radio_cercania int
)
GO

/****************************************************************
 *							rubro
 ****************************************************************/
create table rubro
(
	id_rubro INT IDENTITY(1,1) PRIMARY KEY,
	descripcion nvarchar(255)
)
GO

/****************************************************************
 *							rubro_local
 ****************************************************************/
create table rubros_local
(
	id_local int foreign key references local,
	id_rubro int foreign key references rubro,
	constraint pk_rubros_local primary key clustered (id_local, id_rubro)
)
GO

/****************************************************************
 *							horario
 ****************************************************************/
create table horario
(
	id_poi int foreign key references poi,
	dia int CHECK(dia < 8),
	hora_inicial numeric(18,2),
	hora_final numeric(18,2),
	constraint pk_horario primary key clustered (id_poi, dia)
)
GO

/****************************************************************
 *							Usuarios
 ****************************************************************/
CREATE TABLE Usuarios
(
Nombre VARCHAR(50) PRIMARY KEY ,
Contraseņa VARCHAR(50),
Tipo_Admin INT,
Mail VARCHAR(50),
TiempoMaxBusqueda INT  
)
GO

/********PROCEDURES***********/


/****************************************************************
 *							ObtenerParadas
 ****************************************************************/
create procedure obtenerParadas
as
begin
	select nombre, longitud, latitud, direccion, numero, po.id_poi
	from poi po join parada pa 
	on po.id_poi = pa.id_poi
	where po.habilitado = 1
end
go

/****************************************************************
 *							ObtenerBancos
 ****************************************************************/
create procedure obtenerBancos
as
begin
	select nombre, longitud, latitud, direccion, id_poi
	from poi 
	where es_banco like 1 and habilitado = 1
	

end
go

/****************************************************************
 *							ObtenerLocales
 ****************************************************************/
create procedure obtenerLocales
as
begin
	select id_local, nombre, longitud, latitud, direccion, radio_cercania, po.id_poi
	from poi po join local lo 
	on po.id_poi = lo.id_poi
	where po.habilitado = 1
end
go

/****************************************************************
 *							ObtenerCgps
 ****************************************************************/
create procedure obtenerCgps
as
begin
	select id_cgp, nombre, longitud, latitud, direccion, comuna, po.id_poi
	from poi po join cgp c
	on po.id_poi = c.id_poi
	where po.habilitado = 1
end
go

/****************************************************************
 *							ObtenerServiciosDeCgp
 ****************************************************************/
create procedure obtenerServiciosDeCgp @id_cgp int
as
begin
	select descripcion
	from servicio s join servicios_cgp sc
	on s.id_servicio = sc.id_servicio and sc.id_cgp = @id_cgp
	join cgp c
	on c.id_cgp = sc.id_cgp and c.id_cgp = @id_cgp
end
go

/****************************************************************
 *							ObtenerRubroaDeLocal
 ****************************************************************/
create procedure obtenerRubrosDeLocal @id_local int
as
begin
	select descripcion
	from rubro r join rubros_local rl
	on r.id_rubro = rl.id_rubro and rl.id_local = @id_local
	join local l
	on l.id_local = rl.id_local and l.id_local = @id_local
end
go

/****************************************************************
 *							ObtenerHorariosPoi
 ****************************************************************/
create procedure obtenerHorariosPoi (@id_poi int)
as
begin
	select dia, hora_inicial, hora_final
	from horario 
	where id_poi = @id_poi
	order by 1 asc
end
go

/****************************************************************
 *							crearPoi
 ****************************************************************/
create procedure crearPoi 
	@latitud numeric(18,2), @longitud numeric(18,2), @direccion nvarchar(50), @nombre nvarchar(255),
	@horaInicio1 numeric(18,2), @horaFin1 numeric(18,2), @horaInicio2 numeric(18,2), @horaFin2 numeric(18,2),
	@horaInicio3 numeric(18,2), @horaFin3 numeric(18,2), @horaInicio4 numeric(18,2), @horaFin4 numeric(18,2),
	@horaInicio5 numeric(18,2), @horaFin5 numeric(18,2), @horaInicio6 numeric(18,2), @horaFin6 numeric(18,2),
	@horaInicio7 numeric(18,2), @horaFin7 numeric(18,2)
as
begin
	declare @id_poi int

	insert into poi (nombre, longitud, latitud, direccion, es_banco, habilitado)
	values (@nombre, @longitud, @latitud, @direccion, 0, 1)

	set @id_poi = (select top 1 id_poi from poi order by id_poi desc)
	/*INSERTO HORARIO DE ATENCION*/
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 1, @horaInicio1, @horaFin1)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 2, @horaInicio2, @horaFin2)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 3, @horaInicio3, @horaFin3)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 4, @horaInicio4, @horaFin4)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 5, @horaInicio5, @horaFin5)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 6, @horaInicio6, @horaFin6)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 7, @horaInicio7, @horaFin7)
end
go

/****************************************************************
 *							crearParada
 ****************************************************************/
create procedure crearParada
	@latitud numeric(18,2), @longitud numeric(18,2), @direccion nvarchar(50), @nombre nvarchar(255),@numeroParada int
as 
begin

	declare @id_poi int

	exec crearPoi @latitud, @longitud, @direccion, @nombre,
				  0, 24, 0, 24, 0, 24, 0, 24, 0, 24, 0, 24, 0, 24
				  

	set @id_poi  = (select top 1 id_poi from poi order by id_poi desc)

insert into parada (numero, id_poi) values (@numeroParada, @id_poi)
end
go


create procedure crearLocal
	@latitud numeric(18,2), @longitud numeric(18,2), @direccion nvarchar(50), @nombre nvarchar(255),
	@horaInicio1 numeric(18,2), @horaFin1 numeric(18,2), @horaInicio2 numeric(18,2), @horaFin2 numeric(18,2),
	@horaInicio3 numeric(18,2), @horaFin3 numeric(18,2), @horaInicio4 numeric(18,2), @horaFin4 numeric(18,2),
	@horaInicio5 numeric(18,2), @horaFin5 numeric(18,2), @horaInicio6 numeric(18,2), @horaFin6 numeric(18,2),
	@horaInicio7 numeric(18,2), @horaFin7 numeric(18,2), @radioCercania int
as
begin
	declare @id_poi int

	exec crearPoi @latitud, @longitud, @direccion, @nombre,
				  @horaInicio1, @horaFin1, @horaInicio2, @horaFin2,
				  @horaInicio3, @horaFin3, @horaInicio4, @horaFin4,
				  @horaInicio5, @horaFin5, @horaInicio6, @horaFin6,
				  @horaInicio7, @horaFin7

	set @id_poi  = (select top 1 id_poi from poi order by id_poi desc)

	insert into local (radio_cercania, id_poi) values (@radioCercania, @id_poi)

	select top 1 id_local from local order by id_local desc
end
go

/****************************************************************
 *							crearCgp
 ****************************************************************/
create procedure crearCgp
	@latitud numeric(18,2), @longitud numeric(18,2), @direccion nvarchar(50), @nombre nvarchar(255),
	@horaInicio1 numeric(18,2), @horaFin1 numeric(18,2), @horaInicio2 numeric(18,2), @horaFin2 numeric(18,2),
	@horaInicio3 numeric(18,2), @horaFin3 numeric(18,2), @horaInicio4 numeric(18,2), @horaFin4 numeric(18,2),
	@horaInicio5 numeric(18,2), @horaFin5 numeric(18,2), @horaInicio6 numeric(18,2), @horaFin6 numeric(18,2),
	@horaInicio7 numeric(18,2), @horaFin7 numeric(18,2), @comuna int
as
begin

	declare @id_poi int

	exec crearPoi @latitud, @longitud, @direccion, @nombre,
				  @horaInicio1, @horaFin1, @horaInicio2, @horaFin2,
				  @horaInicio3, @horaFin3, @horaInicio4, @horaFin4,
				  @horaInicio5, @horaFin5, @horaInicio6, @horaFin6,
				  @horaInicio7, @horaFin7

	set @id_poi  = (select top 1 id_poi from poi order by id_poi desc)

	insert into cgp (comuna, id_poi) values (@comuna, @id_poi)

	select top 1 id_cgp from cgp order by id_cgp desc
end
go

create procedure crearBanco
	@latitud numeric(18,2), @longitud numeric(18,2), @direccion nvarchar(50), @nombre nvarchar(255),
	@horaInicio1 numeric(18,2), @horaFin1 numeric(18,2), @horaInicio2 numeric(18,2), @horaFin2 numeric(18,2),
	@horaInicio3 numeric(18,2), @horaFin3 numeric(18,2), @horaInicio4 numeric(18,2), @horaFin4 numeric(18,2),
	@horaInicio5 numeric(18,2), @horaFin5 numeric(18,2), @horaInicio6 numeric(18,2), @horaFin6 numeric(18,2),
	@horaInicio7 numeric(18,2), @horaFin7 numeric(18,2)
as
begin
	declare @id_poi int

	insert into poi (nombre, longitud, latitud, direccion, es_banco)
	values (@nombre, @longitud, @latitud, @direccion, 1)

	set @id_poi = (select top 1 id_poi from poi order by id_poi desc)
	/*INSERTO HORARIO DE ATENCION*/
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 1, @horaInicio1, @horaFin1)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 2, @horaInicio2, @horaFin2)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 3, @horaInicio3, @horaFin3)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 4, @horaInicio4, @horaFin4)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 5, @horaInicio5, @horaFin5)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 6, @horaInicio6, @horaFin6)
	insert into horario (id_poi, dia, hora_inicial, hora_final) values (@id_poi, 7, @horaInicio7, @horaFin7)
end
go

/****************************************************************
 *							ObtenerServicios
 ****************************************************************/
create procedure obtenerServicios
as
begin
	select descripcion, id_servicio
	from servicio
end
go

/****************************************************************
 *							ObtenerRubros
 ****************************************************************/
create procedure obtenerRubros
as
begin
	select descripcion, id_rubro
	from rubro
end
go

/****************************************************************
 *							agregarServicioACgp
 ****************************************************************/
create procedure agregarServicioACgp @id_cgp int, @id_servicio int
as
begin
	insert into servicios_cgp(id_cgp, id_servicio)
	values(@id_cgp, @id_servicio)
end
go

/****************************************************************
 *							agregarRubroALocal
 ****************************************************************/
create procedure agregarRubroALocal @id_local int, @id_rubro int
as
begin
	insert into rubros_local(id_local, id_rubro)
	values(@id_local, @id_rubro)
end
go

/****************************************************************
 *							ObtenerPois
 ****************************************************************/
create procedure obtenerPois
as
begin
	select id_poi, nombre, latitud, longitud, direccion, habilitado
	from poi
end
go

/****************************************************************
 *							altaYBajaPoi
 ****************************************************************/
create procedure altaYBajaPoi @id_poi int
as
begin

	update poi set habilitado = ~ habilitado 
	where id_poi = @id_poi
end
go
	
	
	
--AGREGO USUARIO ADMINISTRADOR

INSERT INTO Usuarios 
(Nombre,Contraseņa,Tipo_Admin,Mail,TiempoMaxBusqueda)
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
	@contraseņa varchar(50),
	@logueado int output,
	@mensaje varchar(40) output,
	@tipo_admin int output
)
as
begin
Select @logueado=COUNT(u.Nombre) from Usuarios u
where Nombre=@usuario and Contraseņa=@contraseņa

if (@logueado>0)begin
select @mensaje='Bienvenido usuario: '+ UPPER(u.Nombre),@tipo_admin=u.Tipo_Admin from Usuarios u
where Nombre=@usuario and Contraseņa=@contraseņa
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

CREATE PROCEDURE resultadosPorUsuario
AS
SELECT texto from Consultas c JOIN UsuarioSesionActual u ON (c.usuario=u.Nombre)
group by texto
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
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(6,8,'parada del 114' ,'avellaneda 367', 0, 1)

INSERT INTO parada
(id_poi, numero)
values(1, 114)

INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(5,5,'parada del 109' ,'nazarre 4500', 0, 1)

INSERT INTO parada
(id_poi, numero)
values(2, 109)

INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(12,11,'parada del 107' ,'beiro 3545', 0, 1)

INSERT INTO parada
(id_poi, numero)
values(3, 107)
 
/*AGREGO BANCO SANTANDER*/
 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(6,9,'banco santander' ,'lavalle 1502', 1, 1)

 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(14,20,'banco galicia' ,'Raul Scalabrini Ortiz 945', 1, 1)

 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(12,15,'banco frances' ,'Corrientes 4694', 1, 1)

 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(25,30,'banco santander' ,'Cordoba 5030', 1, 1)

 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(18,17,'banco BBVA' ,'Corrientes 4626', 1, 1)

/*AGREGO CGP "COMUNA 2"*/
INSERT INTO servicio
(descripcion)
values('un servicio')

 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(5,3,'comuna numero 2' ,'av cordoba 1000', 0, 1)

INSERT INTO cgp
(comuna, id_poi)
values(2, 3)

INSERT INTO servicios_cgp
(id_cgp, id_servicio)
values(1,1)

/*AGREGO LOCAL LIBRERIA*/
 INSERT INTO poi
(latitud, longitud, nombre, direccion, es_banco, habilitado)
values(5,3,'libreria escolar' ,'medrano 1200', 0, 1)

INSERT INTO local
(radio_cercania, id_poi)
values(500, 4)

INSERT INTO rubro
(descripcion)
values('libreria')

INSERT INTO rubros_local
(id_local, id_rubro)
values(1,1)

/*INSERTO RUBROS*/

INSERT INTO rubro
(descripcion)
values('Limpieza')

INSERT INTO rubro
(descripcion)
values('comidas')

INSERT INTO rubro
(descripcion)
values('Tecnologia')

INSERT INTO rubro
(descripcion)
values('Computacion')

/*INSERTO SERVICIOS*/

INSERT INTO servicio
(descripcion)
values('Electricidad')

INSERT INTO servicio
(descripcion)
values('Salud')

INSERT INTO servicio
(descripcion)
values('Transporte publico')

INSERT INTO servicio
(descripcion)
values('Vestimenta')


/**************INSERTO HORARIOS A TODOS LOS POIS DE 9 A 18**************/
INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 1, 9, 18
	from poi)

INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 2, 9, 18
	from poi)

INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 3, 9, 18
	from poi)

INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 4, 9, 18
	from poi)

INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 5, 9, 18
	from poi)

INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 6, 9, 18
	from poi)

INSERT INTO horario
(id_poi, dia, hora_inicial, hora_final)
	(select id_poi, 7, 9, 18
	from poi)