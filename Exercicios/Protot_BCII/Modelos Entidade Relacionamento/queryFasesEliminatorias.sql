-- Gerando as fases eliminatórias a partir da classificação
WITH Classificacao AS (
    SELECT 
        c.Chave AS grupo,
        e.equipe_ID,
        e.nome AS nome_equipe,
        SUM(CASE 
            WHEN p.pontos_Partida = 3 THEN 3
            WHEN p.pontos_Partida = 1 THEN 1
            ELSE 0
        END) AS pontos_totais,
        RANK() OVER (PARTITION BY c.Chave ORDER BY 
            SUM(CASE 
                WHEN p.pontos_Partida = 3 THEN 3
                WHEN p.pontos_Partida = 1 THEN 1
                ELSE 0
            END) DESC, 
            COUNT(CASE WHEN p.pontos_Partida = 3 THEN 1 END) DESC) AS posicao
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