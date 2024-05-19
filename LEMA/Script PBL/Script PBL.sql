CREATE DATABASE PBL
USE PBL

DROP TABLE UsuarioDispositivo
DROP TABLE Dispositivo
DROP TABLE Usuario

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    senha VARCHAR(50) NOT NULL
); 
GO 

CREATE TABLE Dispositivo (
    IdDispositivo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descricao VARCHAR(50) NOT NULL
); 
GO

CREATE TABLE UsuarioDispositivo (
    IdUsuarioDispositivo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdDispositivo INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdDispositivo) REFERENCES Dispositivo(IdDispositivo)
);
GO

-------------------------------------------------------------------------------------------------------

CREATE or ALTER PROCEDURE spInserirUsuario
(
 @username VARCHAR(50),
 @senha VARCHAR(50)
)
AS
BEGIN
 INSERT INTO Usuario
 (username, senha)
 VALUES
 (@username, @senha)
END
GO

CREATE or ALTER PROCEDURE spAlterarUsuario
(
 @id INT,
 @username VARCHAR(50),
 @senha VARCHAR(50)
)
AS
BEGIN
 UPDATE Usuario SET
 username = @username,
 senha = @senha
 WHERE IdUsuario = @id
END
GO

CREATE or ALTER PROCEDURE spExcluirUsuario
(
 @id INT
)
AS
BEGIN
 DELETE FROM Usuario WHERE IdUsuario = @id
END
GO

CREATE or ALTER PROCEDURE spValidarUsuario
(
 @username VARCHAR(50),
 @senha VARCHAR(50)
)
AS
BEGIN
 SELECT * FROM Usuario WHERE username = @username AND senha = @senha
END
GO

CREATE or ALTER PROCEDURE spConsultarUsuario
(
 @username VARCHAR(50)
)
AS
BEGIN
 SELECT * FROM Usuario WHERE username = @username;
END
GO


CREATE or ALTER PROCEDURE spListagemUsuarios
AS
BEGIN
 SELECT * FROM Usuario
END
GO

-------------------------------------------------------------------------------------------------------

CREATE or ALTER PROCEDURE spInserirDispositivo
(
 @descricao VARCHAR(50)
)
AS
BEGIN
 INSERT INTO Dispositivo
 (descricao)
 VALUES
 (@descricao)
END
GO

CREATE or ALTER PROCEDURE spAlterarDispositivo
(
 @id INT,
 @descricao VARCHAR(50)
)
AS
BEGIN
 UPDATE Dispositivo SET
 descricao = @descricao
 WHERE IdDispositivo = @id
END
GO

CREATE or ALTER PROCEDURE spExcluirDispositivo
(
 @id INT
)
AS
BEGIN
 DELETE FROM Dispositivo WHERE IdDispositivo = @id
END
GO

CREATE or ALTER PROCEDURE spConsultarDispositivo
(
 @id INT
)
AS
BEGIN
 SELECT * FROM Dispositivo WHERE IdDispositivo = @id
END
GO

CREATE or ALTER PROCEDURE spListagemDispositivos
AS
BEGIN
 SELECT * FROM Dispositivo
END
GO
