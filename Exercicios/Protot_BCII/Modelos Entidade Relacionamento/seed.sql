-- Inserindo dados na tabela ATLETA
INSERT INTO `ATLETA` (`NOME`, `ALTURA`, `PESO`)
VALUES ('Carlos Silva', 1.85, 80),
       ('Ana Souza', 1.70, 65);
SELECT * FROM trab_campeonato.atleta;

-- Inserindo dados na tabela MODALIDADE
INSERT INTO `MODALIDADE` (`NOME`)
VALUES ('Futebol'),
       ('Vôlei');
SELECT * FROM trab_campeonato.modalidade;

-- Inserindo dados na tabela CHAVEAMENTO
INSERT INTO `CHAVEAMENTO` (`CHAVE`, `QTD_PONTOS`, `TIPO`)
VALUES ('Oitavas', 0, 'Eliminatório'),
       ('Quartas', 0, 'Eliminatório');
SELECT * FROM trab_campeonato.chaveamento;

-- Inserindo dados na tabela CLASSIFICACAO
INSERT INTO `CLASSIFICACAO` (`QTD_PONTOS`, `CHAVEAMENTO_ID`)
VALUES (9, 1),
       (7, 2);
SELECT * FROM trab_campeonato.classificacao;

-- Inserindo dados na tabela PARTIDAS
INSERT INTO `PARTIDAS` (`LOCAL`, `DATA`, `CLASSIFICACAO_ID`)
VALUES ('Estádio Principal', '2024-10-15 14:00:00', 1),
       ('Ginásio Central', '2024-10-16 16:00:00', 2);
SELECT * FROM trab_campeonato.partidas;

-- Inserindo dados na tabela EQUIPE
INSERT INTO `EQUIPE` (`NOME`, `QTD_PESSOAS`, `MODALIDADE_ID`, `ATLETA_ID`)
VALUES ('Equipe A', 11, 1, 1),
       ('Equipe B', 6, 2, 2);
SELECT * FROM trab_campeonato.equipe;

-- Inserindo dados na tabela COMPETICAO
INSERT INTO `COMPETICAO` (`NOME`, `FASE`, `TIPO_COMP`, `EQUIPE_ID`, `PARTIDA_ID`)
VALUES ('Torneio de Futebol', 1, 'Eliminatório', 1, 1),
       ('Torneio de Vôlei', 2, 'Pontuação Corrida', 2, 2);
SELECT * FROM trab_campeonato.competicao;

-- Inserindo dados na tabela RESULTADO
INSERT INTO `RESULTADO` (`EQUIPE_ID`, `PARTIDA_ID`)
VALUES (1, 1),
       (2, 2);
SELECT * FROM trab_campeonato.resultado;

