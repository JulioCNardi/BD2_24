-- Montando a classificação por grupos, calculando pontos dinamicamente
SELECT 
    c.Chave AS grupo,
    e.equipe_ID,
    e.nome AS nome_equipe,
    COUNT(CASE WHEN p.pontos_Partida = 3 THEN 1 END) AS vitorias,
    COUNT(CASE WHEN p.pontos_Partida = 1 THEN 1 END) AS empates,
    COUNT(CASE WHEN p.pontos_Partida = 0 THEN 1 END) AS derrotas,
    SUM(CASE 
        WHEN p.pontos_Partida = 3 THEN 3
        WHEN p.pontos_Partida = 1 THEN 1
        ELSE 0
    END) AS pontos_totais
FROM 
    Equipe e
JOIN 
    Partidas p ON e.equipe_ID = p.equipe_ID
JOIN 
    Chaveamento c ON p.chaveamento_ID = c.chaveamento_ID
GROUP BY 
    c.Chave, e.equipe_ID
ORDER BY 
    c.Chave, pontos_totais DESC, vitorias DESC;
    


