-- Query Desempenho Atletas

SELECT 
    a.nome AS atleta,
    e.nome AS equipe,
    COUNT(p.partida_ID) AS partidas_disputadas,
    SUM(CASE WHEN p.pontos_Partida = 3 THEN 1 ELSE 0 END) AS vitorias,
    SUM(CASE WHEN p.pontos_Partida = 1 THEN 1 ELSE 0 END) AS empates
FROM 
    Atleta a
JOIN 
    Equipe_Atleta ea ON a.atleta_ID = ea.atleta_ID
JOIN 
    Equipe e ON ea.equipe_ID = e.equipe_ID
JOIN 
    Partidas p ON e.equipe_ID = p.equipe_ID
GROUP BY 
    a.nome, e.nome
ORDER BY 
    vitorias DESC, partidas_disputadas DESC;
    
-- Query Desempenho equipes

SELECT 
    e.equipe_ID,
    e.nome AS nome_equipe,
    SUM(CASE 
        WHEN p.pontos_Partida = 3 THEN 3
        WHEN p.pontos_Partida = 1 THEN 1
        ELSE 0
    END) AS pontos_totais,
    COUNT(CASE WHEN p.pontos_Partida = 3 THEN 1 END) AS vitorias,
    COUNT(CASE WHEN p.pontos_Partida = 1 THEN 1 END) AS empates,
    COUNT(CASE WHEN p.pontos_Partida = 0 THEN 1 END) AS derrotas
FROM 
    Equipe e
LEFT JOIN 
    Partidas p ON e.equipe_ID = p.equipe_ID
GROUP BY 
    e.equipe_ID
ORDER BY 
    pontos_totais DESC, vitorias DESC, empates DESC;