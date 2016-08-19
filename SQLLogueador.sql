USE [ProyectoEscuela]
GO
/****** Object:  StoredProcedure [dbo].[loguear]    Script Date: 17/8/2016 3:23:32 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE Usuarios
(
Nombre VARCHAR(50) PRIMARY KEY,
Contraseña VARCHAR(50),
Tipo_Admin INT,
NroUsuario INT IDENTITY (1,1)
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

INSERT INTO Usuarios 
(Nombre,Contraseña,Tipo_Admin)
values('usuario1','123',1)
