WITH AllCustomerOrdersTotals([Year], [Id], [Total]) AS (
SELECT
    YEAR(O.OrderDate),
    O.Customerid,
    SUM(OL.Count * P.Price) * (1 - ISNULL(O.Discount, 0))
FROM [Order] AS O

JOIN [orderline] AS OL
    ON OL.OrderId = O.Id
JOIN [Product] AS P
    ON OL.ProductId = P.Id

 GROUP BY YEAR(O.OrderDate), O.CustomerId, O.Discount
),

TotalCustomerSumPerYear([Year], [Id], [Name], [TotalSum]) AS (
SELECT
    OT.[Year],
    OT.Id,
    C.Name,
    SUM(OT.Total)
FROM AllCustomerOrdersTotals AS OT

JOIN [Customer] AS C
    ON OT.Id = C.Id

GROUP BY OT.[Year], OT.Id, C.Name
)

SELECT
    TS.[Year],
    TS.Id,
    TS.Name
FROM (
    SELECT
        [Year],
        MAX(TotalSum) AS MaxSum
    FROM TotalCustomerSumPerYear

    GROUP BY [Year]
) AS G
INNER JOIN TotalCustomerSumPerYear AS TS
    ON G.[Year] = TS.[Year] AND TS.TotalSum = G.MaxSum

ORDER BY G.[Year]
