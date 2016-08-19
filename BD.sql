
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

CREATE PROCEDURE agregarConsulta
	@texto varchar(50),
	@cantidadResultados INT,
	@tiempoConsulta INT,
	@usuario varchar(50)
AS
	INSERT INTO Consultas (texto,cantidadResultados,tiempoConsulta,usuario) VALUES (@texto,@cantidadResultados,@tiempoConsulta,@usuario)	
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


