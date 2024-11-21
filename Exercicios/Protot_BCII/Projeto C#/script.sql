CREATE DATABASE CAMPEONATO;

USE CAMPEONATO;
GO

-- Cria a tabela Atletas 
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Atletas')
BEGIN
	CREATE TABLE [dbo].[Atletas](
		[Atleta_Id] INT IDENTITY (1, 1) NOT NULL,
		[Nome] NVARCHAR (200) NULL,
		[Altura] FLOAT NOT NULL,
		[Peso] INT NOT NULL,
		CONSTRAINT [PK_dbo.Atletas] PRIMARY KEY CLUSTERED ([Atleta_Id] ASC)
	);
END
GO

-- Cria a tabela Equipes
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Equipes')
BEGIN
	CREATE TABLE [dbo].[Equipes](
		[Equipe_Id] INT IDENTITY (1, 1) NOT NULL,
		[Nome] NVARCHAR (200) NULL,
		[Qtd_Pessoas] INT NOT NULL,
		CONSTRAINT [PK_dbo.Equipes] PRIMARY KEY CLUSTERED ([Equipe_Id] ASC)
	);
END
GO

-- Cria a tabela Modalidades
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Modalidades')
BEGIN
	CREATE TABLE [dbo].[Modalidades](
		[Modalidade_Id] INT IDENTITY (1, 1) NOT NULL,
		[Nome] NVARCHAR (200) NULL,
		CONSTRAINT [PK_dbo.Modalidades] PRIMARY KEY CLUSTERED ([Modalidade_Id] ASC)
	);
END
GO

-- Cria a tabela Chaveamentos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Chaveamentos')
BEGIN
	CREATE TABLE [dbo].[Chaveamentos](
		[Chaveamento_Id] INT IDENTITY (1, 1) NOT NULL,
		[Chave] NVARCHAR (200) NULL,
		CONSTRAINT [PK_dbo.Chaveamentos] PRIMARY KEY CLUSTERED ([Chaveamento_Id] ASC)
	);
END
GO

-- Cria a tabela Equipe_Atleta
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Equipe_Atleta')
BEGIN
    CREATE TABLE [dbo].[Equipe_Atleta] 
    (
        [Equipe_Atleta_Id] INT IDENTITY (1, 1) NOT NULL,
        [Atleta_Id] INT NOT NULL,
        CONSTRAINT [PK_dbo.Equipe_Atleta] PRIMARY KEY CLUSTERED ([Equipe_Atleta_Id] ASC),
        CONSTRAINT [FK_dbo.Equipe_Atleta_dbo.Atleta_Atleta_Id] 
            FOREIGN KEY ([Atleta_Id]) 
            REFERENCES [dbo].[Atletas] ([Atleta_Id])
            ON DELETE CASCADE
    );
END
GO

-- Cria a tabela Competicao
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Competicao')
BEGIN
    CREATE TABLE [dbo].[Competicao](
        [Competicao_ID] INT IDENTITY (1, 1) NOT NULL,
        [Data_Inicio] DATETIME NOT NULL,
        [Data_Fim] DATETIME NOT NULL,
        [Modalidade_ID] INT NOT NULL,
        CONSTRAINT [PK_Competicao] PRIMARY KEY CLUSTERED ([competicao_ID] ASC),
			CONSTRAINT [FK_Competicao_Modalidade] 
			FOREIGN KEY ([modalidade_ID]) 
			REFERENCES [Modalidades]([modalidade_ID]) 
			ON DELETE CASCADE
    );
END
GO

-- Cria a tabela Equipe_Competicao
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Equipe_Competicao')
BEGIN
    CREATE TABLE [dbo].[Equipe_Competicao](
        [equipe_Competicao_ID] INT IDENTITY (1, 1) NOT NULL,
        [pontos_Equipe_Torneio] INT NOT NULL,
        [competicao_ID] INT NOT NULL,
        [equipe_ID] INT NOT NULL,
        CONSTRAINT [PK_Equipe_Competicao] PRIMARY KEY CLUSTERED ([equipe_Competicao_ID] ASC),
        CONSTRAINT [FK_Equipe_Competicao_Competicao] 
			FOREIGN KEY ([competicao_ID]) 
			REFERENCES [Competicao]([competicao_ID]) 
			ON DELETE CASCADE,
        CONSTRAINT [FK_Equipe_Competicao_Equipe] 
			FOREIGN KEY ([equipe_ID]) 
			REFERENCES [Equipes]([equipe_ID]) 
			ON DELETE CASCADE
    );
END
GO

-- Cria a tabela Partidas
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Partidas')
BEGIN
    CREATE TABLE [dbo].[Partidas](
        [partida_ID] INT IDENTITY (1, 1) NOT NULL,
        [local] VARCHAR(50) NOT NULL,
        [pontos_Partida] INT NOT NULL,
        [competicao_ID] INT NOT NULL,
        [chaveamento_ID] INT NOT NULL,
        [equipe_ID] INT NOT NULL,
        CONSTRAINT [PK_Partidas] PRIMARY KEY CLUSTERED ([partida_ID] ASC),
        CONSTRAINT [FK_Partidas_Competicao] 
			FOREIGN KEY ([competicao_ID]) 
			REFERENCES [Competicao]([competicao_ID]) 
			ON DELETE CASCADE,
        CONSTRAINT [FK_Partidas_Chaveamento] 
			FOREIGN KEY ([chaveamento_ID]) 
			REFERENCES [Chaveamentos]([chaveamento_ID]) 
			ON DELETE CASCADE,
        CONSTRAINT [FK_Partidas_Equipe] 
			FOREIGN KEY ([equipe_ID]) 
			REFERENCES [Equipes]([equipe_ID]) 
			ON DELETE CASCADE
    );
END
GO