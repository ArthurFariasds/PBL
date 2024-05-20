CREATE DATABASE PBL
USE PBL

DROP TABLE UsuarioDispositivo
DROP TABLE Dispositivo
DROP TABLE Usuario

CREATE TABLE Usuario (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    senha VARCHAR(50) NOT NULL,
	perfil VARCHAR(50) NOT NULL,
	imagem VARBINARY(MAX)
); 
GO 
select * from Usuario
CREATE TABLE Dispositivo (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    descricao VARCHAR(50) NOT NULL
); 
GO

CREATE TABLE UsuarioDispositivo (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdDispositivo INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(id),
    FOREIGN KEY (IdDispositivo) REFERENCES Dispositivo(id)
);
GO
-------------------------------------------------------------------------------------------------------
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
 SELECT * FROM Usuario WHERE username = @username
END
GO


CREATE OR ALTER PROCEDURE spConsultaPerfil
(
 @id INT
)
AS
BEGIN
 SELECT perfil FROM Usuario WHERE id = @id
END
GO

-------------------------------------------------------------------------------------------------------
CREATE or ALTER PROCEDURE spInserirUsuario
(
 @id INT,
 @username VARCHAR(50),
 @senha VARCHAR(50),
 @perfil VARCHAR(50),
 @imagem VARBINARY(MAX)
)
AS
BEGIN
 INSERT INTO Usuario
 (username, senha, perfil, imagem)
 VALUES
 (@username, @senha, @perfil, @imagem)
END
GO

CREATE or ALTER PROCEDURE spAlterarUsuario
(
 @id INT,
 @username VARCHAR(50),
 @senha VARCHAR(50),
 @perfil VARCHAR(50),
 @imagem VARBINARY(MAX)
)
AS
BEGIN
 UPDATE Usuario SET
 username = @username,
 senha = @senha,
 perfil = @perfil,
 imagem = @imagem
 WHERE id = @id
END
GO

CREATE OR ALTER PROCEDURE spConsulta
(
 @id INT ,
 @tabela VARCHAR(MAX)
)
AS
BEGIN
 DECLARE @sql VARCHAR(MAX);
 SET @sql = 'SELECT * FROM ' + @tabela +
 ' WHERE id = ' + CAST(@id AS VARCHAR(MAX))
 EXEC(@sql)
END
GO

CREATE or ALTER PROCEDURE spExcluir
(
 @id INT ,
 @tabela VARCHAR(MAX)
)
AS
BEGIN
 DECLARE @sql VARCHAR(MAX);
 SET @sql = ' DELETE ' + @tabela +
 ' WHERE id = ' + CAST(@id AS VARCHAR(MAX))
 EXEC(@sql)
END
GO

CREATE or ALTER PROCEDURE spListagemUsuarios
(
 @tabela VARCHAR(MAX),
 @ordem VARCHAR(MAX))
AS
BEGIN
 EXEC('SELECT * FROM ' + @tabela +
 ' ORDER BY ' + @ordem)
END
GO

-------------------------------------------------------------------------------------------------------
CREATE or ALTER PROCEDURE spAlterarImagemUsuario
(
 @id INT,
 @imagem VARBINARY(MAX)
)
AS
BEGIN
 UPDATE Usuario SET
 imagem = @imagem
 WHERE id = @id
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
 WHERE id = @id
END
GO

CREATE or ALTER PROCEDURE spExcluirDispositivo
(
 @id INT
)
AS
BEGIN
 DELETE FROM Dispositivo WHERE id = @id
END
GO

CREATE or ALTER PROCEDURE spConsultarDispositivo
(
 @id INT
)
AS
BEGIN
 SELECT * FROM Dispositivo WHERE id = @id
END
GO

CREATE or ALTER PROCEDURE spListagemDispositivos
AS
BEGIN
 SELECT * FROM Dispositivo
END
GO

-------------------------------------------------------------------------------------------------------
CREATE or ALTER PROCEDURE spListagemTemperatura
AS
BEGIN
 SELECT * FROM Dispositivo
END
GO


