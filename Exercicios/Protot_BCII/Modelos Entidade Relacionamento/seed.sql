USE CAMPEONATO;
GO

-- Insere dados na tabela Atleta
INSERT INTO [dbo].[Atletas] (nome, altura, peso) VALUES ('Carlos Silva', 1.85, 80);
INSERT INTO [dbo].[Atletas] (nome, altura, peso) VALUES ('Ana Souza', 1.72, 65);
INSERT INTO [dbo].[Atletas] (nome, altura, peso) VALUES ('Pedro Lima', 1.78, 70);
INSERT INTO [dbo].[Atletas] (nome, altura, peso) VALUES ('Juliana Costa', 1.66, 55);
INSERT INTO [dbo].[Atletas] (nome, altura, peso) VALUES ('Rafael Alves', 1.90, 85);
SELECT * FROM [dbo].[Atletas];

INSERT INTO [dbo].[Equipes] (nome, qtd_Pessoas) VALUES ('Equipe A', 10);
INSERT INTO [dbo].[Equipes] (nome, qtd_Pessoas) VALUES ('Equipe B', 8);
INSERT INTO [dbo].[Equipes] (nome, qtd_Pessoas) VALUES ('Equipe C', 12);
INSERT INTO [dbo].[Equipes] (nome, qtd_Pessoas) VALUES ('Equipe D', 5);
INSERT INTO [dbo].[Equipes] (nome, qtd_Pessoas) VALUES ('Equipe E', 7);
SELECT * FROM [dbo].[Equipes];

INSERT INTO [dbo].[Equipe_Atleta] (atleta_ID, Equipe_Id) VALUES (1, 1);
INSERT INTO [dbo].[Equipe_Atleta] (atleta_ID, Equipe_ID) VALUES (2, 2);
INSERT INTO [dbo].[Equipe_Atleta] (atleta_ID, equipe_ID) VALUES (3, 3);
INSERT INTO [dbo].[Equipe_Atleta] (atleta_ID, equipe_ID) VALUES (4, 4);
INSERT INTO [dbo].[Equipe_Atleta] (atleta_ID, equipe_ID) VALUES (5, 5);

-- Insere dados na tabela Modalidade
INSERT INTO [dbo].[Modalidades] (nome) VALUES ('Futebol');
INSERT INTO [dbo].[Modalidades] (nome) VALUES ('Vôlei');
INSERT INTO [dbo].[Modalidades] (nome) VALUES ('Basquete');
INSERT INTO [dbo].[Modalidades] (nome) VALUES ('Handebol');
INSERT INTO [dbo].[Modalidades] (nome) VALUES ('Natação');

-- Insere dados na tabela Competicao
INSERT INTO [dbo].[Competicao] (data_Inicio, data_Fim, modalidade_ID) VALUES ('2024-01-10', '2024-01-20', 1);
INSERT INTO [dbo].[Competicao] (data_Inicio, data_Fim, modalidade_ID) VALUES ('2024-02-15', '2024-02-25', 2);
INSERT INTO [dbo].[Competicao] (data_Inicio, data_Fim, modalidade_ID) VALUES ('2024-03-01', '2024-03-10', 3);
INSERT INTO [dbo].[Competicao] (data_Inicio, data_Fim, modalidade_ID) VALUES ('2024-04-05', '2024-04-15', 4);
INSERT INTO [dbo].[Competicao] (data_Inicio, data_Fim, modalidade_ID) VALUES ('2024-05-01', '2024-05-10', 5);

-- Insere dados na tabela Equipe_Competicao (associação entre Equipe e Competicao)
INSERT INTO [dbo].[Equipe_Competicao] (pontos_Equipe_Torneio, competicao_ID, equipe_ID) VALUES (30, 1, 1);
INSERT INTO [dbo].[Equipe_Competicao] (pontos_Equipe_Torneio, competicao_ID, equipe_ID) VALUES (25, 2, 2);
INSERT INTO [dbo].[Equipe_Competicao] (pontos_Equipe_Torneio, competicao_ID, equipe_ID) VALUES (20, 3, 3);
INSERT INTO [dbo].[Equipe_Competicao] (pontos_Equipe_Torneio, competicao_ID, equipe_ID) VALUES (15, 4, 4);
INSERT INTO [dbo].[Equipe_Competicao] (pontos_Equipe_Torneio, competicao_ID, equipe_ID) VALUES (10, 5, 5);

-- Insere dados na tabela Chaveamento
INSERT INTO [dbo].[Chaveamentos] (chave) VALUES ('Oitavas');
INSERT INTO [dbo].[Chaveamentos] (chave) VALUES ('Quartas');
INSERT INTO [dbo].[Chaveamentos] (chave) VALUES ('Semi');
INSERT INTO [dbo].[Chaveamentos] (chave) VALUES ('Finais');
SELECT * FROM [dbo].[Chaveamentos];

-- Insere dados na tabela Partidas
INSERT INTO [dbo].[Partidas] (local, pontos_Partida, competicao_ID, chaveamento_ID, equipe_ID) VALUES ('Estádio A', 3, 1, 1, 1);
INSERT INTO [dbo].[Partidas] (local, pontos_Partida, competicao_ID, chaveamento_ID, equipe_ID) VALUES ('Arena B', 5, 2, 2, 2);
INSERT INTO [dbo].[Partidas] (local, pontos_Partida, competicao_ID, chaveamento_ID, equipe_ID) VALUES ('Quadra C', 2, 3, 3, 3);
INSERT INTO [dbo].[Partidas] (local, pontos_Partida, competicao_ID, chaveamento_ID, equipe_ID) VALUES ('Ginásio D', 4, 4, 4, 4);
INSERT INTO [dbo].[Partidas] (local, pontos_Partida, competicao_ID, chaveamento_ID, equipe_ID) VALUES ('Piscina E', 6, 5, 5, 5);