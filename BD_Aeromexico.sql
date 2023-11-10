CREATE DATABASE IvBetoAeroMexico

USE IvBetoAeroMexico


DECLARE @fecha DATE = GetDate()
SELECT CONVERT(VARCHAR,@fecha,111)

CREATE TABLE Vuelo(
NumeroVuelo VARCHAR(4) PRIMARY KEY,
Origen VARCHAR(2),
Destino VARCHAR(2),
FechaInicio DATE,
FechaSalida DATE
)


INSERT INTO Vuelo VALUES('AM01','MX','FR','2023-11-09','2023-11-11')
INSERT INTO Vuelo VALUES('AM02','MX','PM','2023-11-10','2023-11-11')
INSERT INTO Vuelo VALUES('AM03','MX','EU','2023-11-09','2023-11-11')
INSERT INTO Vuelo VALUES('AM04','SP','MX','2023-11-11','2023-11-12')
INSERT INTO Vuelo VALUES('AM05','EU','MX','2023-11-10','2023-11-11')
INSERT INTO Vuelo VALUES('AM06','GR','MX','2023-11-10','2023-11-11')
INSERT INTO Vuelo VALUES('AM07','MX','SP','2023-11-12','2023-11-14')


CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(40),
Password VARCHAR(40) NOT NULL
)



CREATE TABLE Pasajero(
IdPasajero INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
Apellidos VARCHAR(80) NOT NULL,
NumeroVuelo VARCHAR(4) FOREIGN KEY REFERENCES Vuelo(NumeroVuelo)
)


INSERT INTO Usuario VALUES('ivanbeto16','contraseña')
INSERT INTO Usuario VALUES('vkryp','contraseña')
INSERT INTO Usuario VALUES('kristinichu','contraseña')
INSERT INTO Usuario VALUES('inquisidorxzx','contraseña')
INSERT INTO Usuario VALUES('elrobertos','contraseña')
INSERT INTO Usuario VALUES('renrize','contraseña')

SELECT * FROM Usuario

CREATE PROCEDURE UsuarioGetByUsername
@Username VARCHAR(40)
AS
	SELECT Usuario.IdUsuario,
	Usuario.Username,
	Usuario.Password
	FROM Usuario
	WHERE Usuario.Username = @Username


SELECT * FROM Vuelo
SELECT * FROM Pasajero