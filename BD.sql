CREATE TABLE Usuarios
(
Nombre VARCHAR(50) ,
Contraseña VARCHAR(50),
Tipo_Admin INT,
NroUsuario INT IDENTITY (1,1) PRIMARY KEY
)
GO

--AGREGO USUARIO ADMINISTRADOR

INSERT INTO Usuarios 
(Nombre,Contraseña,Tipo_Admin)
values('usuario1','123',1)


Create table Consultas
(
id INT IDENTITY(1,1) PRIMARY KEY,
texto varchar(50),
cantidadResultados INT,
tiempoConsulta INT,
usuario varchar(50),
fecha datetime DEFAULT GETDATE()
)
go

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
	select @usuario=u.Nombre from Usuarios u where u.NroUsuario = (SELECT MAX(NroUsuario) from Usuarios u2) 	 
	INSERT INTO Consultas (texto,cantidadResultados,tiempoConsulta,usuario) VALUES (@texto,@cantidadResultados,@tiempoConsulta,@usuario)	
GO


CREATE PROCEDURE GuardarUsuario
	@usuario varchar(50)
AS
	INSERT INTO Usuarios (Nombre,Tipo_Admin) values (@usuario,0)
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


 