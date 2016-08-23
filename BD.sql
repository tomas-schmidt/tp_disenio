CREATE TABLE Usuarios
(
Nombre VARCHAR(50) PRIMARY KEY ,
Contraseña VARCHAR(50),
Tipo_Admin INT,
Mail VARCHAR(50),
TiempoMaxBusqueda INT  
)
GO

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


