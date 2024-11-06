-- Usar o banco de dados
USE CompeticaoDb;
GO

-- Dropar as restrições de chave estrangeira
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Equipes_Competicoes')
    ALTER TABLE Equipes DROP CONSTRAINT FK_Equipes_Competicoes;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Resultados_Competicoes')
    ALTER TABLE Resultados DROP CONSTRAINT FK_Resultados_Competicoes;

IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Resultados_Equipes')
    ALTER TABLE Resultados DROP CONSTRAINT FK_Resultados_Equipes;
GO

-- Dropar tabelas se existirem
IF OBJECT_ID('Resultados', 'U') IS NOT NULL DROP TABLE Resultados;
IF OBJECT_ID('Equipes', 'U') IS NOT NULL DROP TABLE Equipes;
IF OBJECT_ID('Competicoes', 'U') IS NOT NULL DROP TABLE Competicoes;
IF OBJECT_ID('Modalidades', 'U') IS NOT NULL DROP TABLE Modalidades;
GO

-- Criar tabela para Modalidades
CREATE TABLE Modalidades (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255) NULL
);
GO

-- Criar tabela para Competicoes
CREATE TABLE Competicoes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    DataInicio DATETIME NOT NULL,
    DataFim DATETIME NOT NULL,
    ModalidadeId INT NOT NULL,
    FOREIGN KEY (ModalidadeId) REFERENCES Modalidades(Id) ON DELETE CASCADE
);
GO

-- Criar tabela para Equipes
CREATE TABLE Equipes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    CompeticaoId INT,
    FOREIGN KEY (CompeticaoId) REFERENCES Competicoes(Id) ON DELETE NO ACTION
);
GO

-- Criar tabela para Resultados
CREATE TABLE Resultados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CompeticaoId INT,
    EquipeId INT,
    Pontos INT NOT NULL,
    FOREIGN KEY (CompeticaoId) REFERENCES Competicoes(Id) ON DELETE NO ACTION,
    FOREIGN KEY (EquipeId) REFERENCES Equipes(Id) ON DELETE NO ACTION
);
GO
