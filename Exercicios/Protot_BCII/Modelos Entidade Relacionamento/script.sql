CREATE DATABASE CAMPEONATO;
USE CAMPEONATO;

-- Tabelas sem chaves estrangeiras
CREATE TABLE Atleta (
    atleta_ID INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    altura FLOAT,
    peso INT
);

CREATE TABLE Equipe (
    equipe_ID INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    qtd_Pessoas INT
);

CREATE TABLE Modalidade (
    modalidade_ID INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL
);

CREATE TABLE Chaveamento (
    chaveamento_ID INT AUTO_INCREMENT PRIMARY KEY,
    Chave ENUM('Oitavas', 'Quartas', 'Semi', 'Final') NOT NULL
);

-- Tabelas que possuem chaves estrangeiras
CREATE TABLE Competicao (
    competicao_ID INT AUTO_INCREMENT PRIMARY KEY,
    data_inicio DATETIME NOT NULL,
    data_fim DATETIME NOT NULL,
    modalidade_ID INT NOT NULL,
    CONSTRAINT fk_competicao_modalidade FOREIGN KEY (modalidade_ID) REFERENCES Modalidade(modalidade_ID)
);

CREATE TABLE Equipe_Atleta (
    equipe_Atleta_ID INT AUTO_INCREMENT PRIMARY KEY,
    atleta_ID INT NOT NULL,
    equipe_ID INT NOT NULL,
    CONSTRAINT fk_equipe_atleta_atleta FOREIGN KEY (atleta_ID) REFERENCES Atleta(atleta_ID),
    CONSTRAINT fk_equipe_atleta_equipe FOREIGN KEY (equipe_ID) REFERENCES Equipe(equipe_ID)
);

CREATE TABLE Equipe_Competicao (
    equipe_Competicao_ID INT AUTO_INCREMENT PRIMARY KEY,
    competicao_ID INT NOT NULL,
    equipe_ID INT NOT NULL,
    pontos_Equipe_Torneio INT,
    CONSTRAINT fk_equipe_competicao_competicao FOREIGN KEY (competicao_ID) REFERENCES Competicao(competicao_ID),
    CONSTRAINT fk_equipe_competicao_equipe FOREIGN KEY (equipe_ID) REFERENCES Equipe(equipe_ID)
);

CREATE TABLE Partidas (
    partida_ID INT AUTO_INCREMENT PRIMARY KEY,
    local VARCHAR(50) NOT NULL,
    pontos_Partida INT,
    competicao_ID INT NOT NULL,
    chaveamento_ID INT,
    equipe_ID INT,
    CONSTRAINT fk_partidas_competicao FOREIGN KEY (competicao_ID) REFERENCES Competicao(competicao_ID),
    CONSTRAINT fk_partidas_chaveamento FOREIGN KEY (chaveamento_ID) REFERENCES Chaveamento(chaveamento_ID),
    CONSTRAINT fk_partidas_equipe FOREIGN KEY (equipe_ID) REFERENCES Equipe(equipe_ID)
);



