CREATE DATABASE PBL
USE PBL

DROP TABLE Usuario
DROP TABLE Empresa
DROP TABLE Temperatura
DROP TABLE Dispositivo

CREATE TABLE Empresa(
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
	telefone VARCHAR(50) NOT NULL,
	imagem VARBINARY(MAX)
); 
GO

CREATE TABLE Dispositivo (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nome VARCHAR(50) NOT NULL,
    descricao VARCHAR(50),
	dataCriacao DATETIME,
	IdDispositivoApi varchar(50)
); 
GO

CREATE TABLE Usuario (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    senha VARCHAR(50) NOT NULL,
	perfil VARCHAR(50) NOT NULL,
	imagem VARBINARY(MAX),
	idEmpresa INT NULL,
	idDispositivo INT NULL,
	FOREIGN KEY (idEmpresa) REFERENCES Empresa(id),
	FOREIGN KEY (idDispositivo) REFERENCES Dispositivo(id)
); 
GO

CREATE TABLE Temperatura(
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    valorTemperatura DECIMAL(18,2) NOT NULL,
	dataLeitura DATETIME,
	idDispositivo INT NOT NULL,
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

--==========================================USUARIO==========================================
CREATE or ALTER PROCEDURE spInserirUsuario
(
 @id INT,
 @username VARCHAR(50),
 @senha VARCHAR(50),
 @perfil VARCHAR(50),
 @imagem VARBINARY(MAX),
 @idEmpresa INT = null,
 @idDispositivo INT = null
)
AS
BEGIN
 INSERT INTO Usuario
 (username, senha, perfil, imagem, idEmpresa, idDispositivo)
 VALUES
 (@username, @senha, @perfil, @imagem, @idEmpresa, @idDispositivo)
END
GO

CREATE or ALTER PROCEDURE spAlterarUsuario
(
 @id INT,
 @username VARCHAR(50),
 @senha VARCHAR(50),
 @perfil VARCHAR(50),
 @imagem VARBINARY(MAX),
 @idEmpresa INT,
 @idDispositivo INT
)
AS
BEGIN
 UPDATE Usuario SET
 username = @username,
 senha = @senha,
 perfil = @perfil,
 imagem = @imagem,
 idEmpresa = @idEmpresa,
 idDispositivo = @idDispositivo
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
  
CREATE or ALTER PROCEDURE spListagemUsuarios
(
 @tabela VARCHAR(MAX),
 @ordem VARCHAR(MAX))
AS
BEGIN
    SELECT Usuario.*, empresa.Nome as 'Empresa', dispositivo.Nome as 'Dispositivo' FROM Usuario
	left join Empresa on empresa.id  = Usuario.IdEmpresa
	left join Dispositivo on dispositivo.id = Usuario.idDispositivo
END
GO

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

--==========================================DISPOSITIVO==========================================

CREATE or ALTER PROCEDURE spInserirDispositivo
(
 @id INT,
 @nome VARCHAR(50),
 @descricao VARCHAR(50),
 @idDispositivoApi VARCHAR(50),
 @dataCriacao DATETIME
)
AS
BEGIN
 INSERT INTO Dispositivo
 (descricao, nome, dataCriacao, idDispositivoApi)
 VALUES
 (@descricao, @nome, @dataCriacao,@idDispositivoApi)
END
GO

CREATE or ALTER PROCEDURE spAlterarDispositivo
(
 @id INT,
 @nome VARCHAR(50),
 @descricao VARCHAR(50),
 @idDispositivoApi VARCHAR(50),
 @dataCriacao DATETIME
)
AS
BEGIN
 UPDATE Dispositivo SET
 nome = @nome,
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
 @nome VARCHAR(50)
)
AS
BEGIN
 SELECT * FROM Dispositivo WHERE nome = @nome
END
GO

CREATE or ALTER PROCEDURE spListagemDispositivos
(
 @tabela VARCHAR(MAX),
 @ordem VARCHAR(MAX)
 )
AS
BEGIN
 EXEC('SELECT * FROM ' + @tabela +
 ' ORDER BY ' + @ordem)
END
GO

--==========================================EMPRESA==========================================

CREATE or ALTER PROCEDURE spInserirEmpresa
(
 @id INT,
 @nome VARCHAR(50),
 @telefone VARCHAR(50),
 @imagem VARBINARY(MAX)
)
AS
BEGIN
 INSERT INTO Empresa
 (nome, telefone, imagem)
 VALUES
 (@nome, @telefone, @imagem)
END
GO

CREATE or ALTER PROCEDURE spAlterarEmpresa
(
 @id INT,
 @nome VARCHAR(50),
 @telefone VARCHAR(50),
 @imagem VARBINARY(MAX)
)
AS
BEGIN
 UPDATE Empresa SET
 nome = @nome,
 telefone = @telefone,
 imagem = @imagem
 WHERE id = @id
END
GO

CREATE or ALTER PROCEDURE spListagemEmpresas
(
 @tabela VARCHAR(MAX),
 @ordem VARCHAR(MAX))
AS
BEGIN
 EXEC('SELECT * FROM ' + @tabela +
 ' ORDER BY ' + @ordem)
END
GO

CREATE or ALTER PROCEDURE spConsultarEmpresa
(
 @nome VARCHAR(50)
)
AS
BEGIN
 SELECT * FROM Empresa WHERE nome = @nome
END
GO

--==========================================TEMPERATURA==========================================
CREATE or ALTER PROCEDURE spInserirTemperatura
(
 @id INT,
 @valorTemperatura decimal(18,2),
 @dataLeitura datetime,
 @idDispositivo int
)
AS
BEGIN
 INSERT INTO Temperatura
 (valorTemperatura, dataLeitura, idDispositivo)
 VALUES
 (@valorTemperatura, @dataLeitura, @idDispositivo)
END
GO

CREATE or ALTER PROCEDURE spAlterarTemperatura
(
 @id INT,
 @valorTemperatura decimal(18,2),
 @dataLeitura datetime,
 @idDispositivo int
)
AS
BEGIN
 UPDATE Temperatura SET
 valorTemperatura = @valorTemperatura,
 dataLeitura = @dataLeitura,
 idDispositivo = @idDispositivo
 WHERE id = @id
END
GO

CREATE or ALTER PROCEDURE spListagemTemperatura
(
 @tabela VARCHAR(MAX),
 @ordem VARCHAR(MAX))
AS
BEGIN
 EXEC('SELECT * FROM ' + @tabela +
 ' ORDER BY ' + @ordem)
END
GO

--==========================================INSERT==========================================

INSERT INTO Empresa (nome, telefone, imagem) VALUES ('Empresa 1', '(99) 9999-9999', null)
INSERT INTO Empresa (nome, telefone, imagem) VALUES ('Empresa 2', '(99) 9999-9999', null)
INSERT INTO Empresa (nome, telefone, imagem) VALUES ('Empresa 3', '(99) 9999-9999', null)

INSERT INTO Dispositivo (nome, descricao, dataCriacao, idDispositivoApi) VALUES ('Dispositivo 1', 'Dispositivo 1', GETDATE(), 'temp001')

INSERT INTO Usuario (username, senha, perfil, imagem, idEmpresa) VALUES ('admin', '1234', 'Administrador', null, null)
INSERT INTO Usuario (username, senha, perfil, imagem, idEmpresa) VALUES ('admin 2', '1234', 'Administrador', null, null)
INSERT INTO Usuario (username, senha, perfil, imagem, idEmpresa) VALUES ('user', '1234', 'Padrão', null, null)
INSERT INTO Usuario (username, senha, perfil, imagem, idEmpresa) VALUES ('user 2', '1234', 'Padrão', null, null)
INSERT INTO Usuario (username, senha, perfil, imagem, idEmpresa) VALUES ('user 3', '1234', 'Padrão', null, null)


