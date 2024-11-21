-- Montando a classificação por grupos
SELECT 
    c.Chave AS grupo,
    e.equipe_ID,
    e.nome AS nome_equipe,
    SUM(p.pontos_Partida) AS pontos_totais
FROM 
    Equipe e
JOIN 
    Partidas p ON e.equipe_ID = p.equipe_ID
JOIN 
    Chaveamento c ON p.chaveamento_ID = c.chaveamento_ID
GROUP BY 
    c.Chave, e.equipe_ID
ORDER BY 
    c.Chave, pontos_totais DESC;

-- Gerando as fases eliminatórias
WITH Classificacao AS (
    SELECT 
        c.Chave AS grupo,
        e.equipe_ID,
        e.nome AS nome_equipe,
        SUM(p.pontos_Partida) AS pontos_totais,
        RANK() OVER (PARTITION BY c.Chave ORDER BY SUM(p.pontos_Partida) DESC) AS posicao
    FROM 
        Equipe e
    JOIN 
        Partidas p ON e.equipe_ID = p.equipe_ID
    JOIN 
        Chaveamento c ON p.chaveamento_ID = c.chaveamento_ID
    GROUP BY 
        c.Chave, e.equipe_ID
)
SELECT 
    grupo, 
    equipe_ID, 
    nome_equipe, 
    pontos_totais
FROM 
    Classificacao
WHERE 
    posicao <= 2
ORDER BY 
    grupo, posicao;
