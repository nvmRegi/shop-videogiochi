SELECT Videogiochi.Nome
FROM Videogiochi
INNER JOIN Ordini
ON Ordini.VideogiocoId = Videogiochi.Id
GROUP BY Videogiochi.Id, VIdeogiochi.Nome
ORDER BY SUM(Quantità) Desc
