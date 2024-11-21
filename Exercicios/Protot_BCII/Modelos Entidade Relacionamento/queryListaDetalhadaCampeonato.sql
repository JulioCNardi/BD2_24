SELECT 
    p.partida_ID,
    p.local,
    p.competicao_ID,
    m.nome AS modalidade,
    c.Chave AS chave,
    e.nome AS equipe,
    p.pontos_Partida AS pontos
FROM 
    Partidas p
JOIN 
    Competicao comp ON p.competicao_ID = comp.competicao_ID
JOIN 
    Modalidade m ON comp.modalidade_ID = m.modalidade_ID
JOIN 
    Chaveamento c ON p.chaveamento_ID = c.chaveamento_ID
JOIN 
    Equipe e ON p.equipe_ID = e.equipe_ID
ORDER BY 
    p.competicao_ID, c.Chave, p.partida_ID;
    
-- Estatisticas com base os resultados das partidas em cada modalidade

SELECT 
    comp.competicao_ID,
    m.nome AS modalidade,
    COUNT(p.partida_ID) AS total_partidas,
    SUM(p.pontos_Partida) AS total_pontos,
    AVG(p.pontos_Partida) AS media_pontos
FROM 
    Competicao comp
JOIN 
    Modalidade m ON comp.modalidade_ID = m.modalidade_ID
JOIN 
    Partidas p ON comp.competicao_ID = p.competicao_ID
GROUP BY 
    comp.competicao_ID, m.nome
ORDER BY 
    comp.competicao_ID;
