-- Inserções na tabela Atleta
INSERT INTO Atleta (nome, altura, peso) VALUES
('Pedro Souza', 1.80, 85),
('Luana Pereira', 1.68, 60),
('Ricardo Lima', 1.90, 92),
('Fernanda Gomes', 1.72, 70),
('Marcelo Alves', 1.76, 78),
('Juliana Rocha', 1.64, 55),
('Gabriel Costa', 1.82, 88),
('Isabela Martins', 1.75, 62),
('Roberto Silva', 1.88, 95),
('Carla Santos', 1.66, 58);


-- Inserções na tabela Equipe
INSERT INTO Equipe (nome, qtd_Pessoas) VALUES
('Falcões Negros', 9),
('Cobras Verdes', 6),
('Gaviões do Sul', 10),
('Guardiões Azuis', 7),
('Leões Clube', 12),
('Cavalos de Prata', 8),
('Dragões Vermelhos', 6),
('Cheetahs', 5),
('Tubarões Azuis', 11),
('Panteras', 10);



-- Inserções na tabela Modalidade
INSERT INTO Modalidade (nome) VALUES
('Futebol'),
('Basquete'),
('Vôlei'),
('Tênis');

-- Inserções na tabela Chaveamento
INSERT INTO Chaveamento (Chave) VALUES
('Final'),
('Oitavas'),
('Quartas'),
('Semi'),
('Final'),
('Oitavas'),
('Quartas'),
('Semi'),
('Final'),
('Oitavas');


-- Inserções na tabela Competicao
INSERT INTO Competicao (data_inicio, data_fim, modalidade_ID) VALUES
('2024-01-15 10:00:00', '2024-01-30 18:00:00', 1),
('2024-02-01 09:00:00', '2024-02-20 17:00:00', 2),
('2024-03-05 08:00:00', '2024-03-15 19:00:00', 3),
('2024-04-01 10:00:00', '2024-04-10 16:00:00', 4),
('2024-05-10 11:00:00', '2024-05-25 20:00:00', 1),
('2024-06-01 08:00:00', '2024-06-15 18:00:00', 2),
('2024-07-05 09:00:00', '2024-07-20 19:00:00', 3),
('2024-08-01 10:00:00', '2024-08-15 16:00:00', 4),
('2024-09-10 12:00:00', '2024-09-30 17:00:00', 1),
('2024-10-05 08:00:00', '2024-10-20 19:00:00', 2);


-- Inserções na tabela Equipe_Atleta
INSERT INTO Equipe_Atleta (atleta_ID, equipe_ID) VALUES
(1, 1),
(2, 4),
(3, 3),
(4, 2),
(5, 1),
(6, 2),
(7, 3),
(8, 4),
(9, 1),
(10, 2);


-- Inserções na tabela Equipe_Competicao
INSERT INTO Equipe_Competicao (competicao_ID, equipe_ID, pontos_Equipe_Torneio) VALUES
(1, 2, 3), 
(3, 1, 6),
(2, 3, 0),
(4, 4, 9),
(5, 5, 2),
(6, 6, 5),
(7, 7, 7),
(8, 8, 1),
(9, 9, 4),
(10, 10, 8);


-- Inserções na tabela Partidas
INSERT INTO Partidas (local, pontos_Partida, competicao_ID, chaveamento_ID, equipe_ID) VALUES
('Estádio Nacional', 2, 1, 2, 3),
('Arena Central', 3, 2, 3, 4),
('Ginásio Olímpico', 1, 4, 1, 2),
('Quadra Municipal', 0, 2, 3, 1),
('Estádio da Luz', 3, 1, 4, 5),
('Arena do Sol', 1, 3, 2, 6),
('Ginásio da Praça', 2, 5, 3, 7),
('Estádio Imperial', 3, 4, 1, 8),
('Arena Verde', 0, 6, 2, 9),
('Estádio do Povo', 1, 7, 4, 10);

