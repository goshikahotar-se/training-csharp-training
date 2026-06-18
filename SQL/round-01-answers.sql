-- Infomil SQL Round 1 — YOUR ANSWERS GO HERE
-- Run setup first: round-01-setup.sql (in the same database you selected in Workbench)
-- USE issuing;

-- ============ Question 1 ============
-- 2026 order lines: customer name, product name, quantity, line total
-- Sort by order date, newest first

SELECT * FROM issuing.Customers c
                  INNER JOIN issuing.Orders o
                             ON c.CustomerId = o.CustomerId

                  INNER JOIN issuing.OrderLines ol
                             ON o.OrderId = ol.OrderId

                  INNER JOIN issuing.Products p
                             ON ol.ProductId = p.ProductId
WHERE o.OrderDate > '2026-01-01';


-- ============ Question 2 ============
-- Total quantity sold per product name, highest first

select p.Name, SUM(ol.Quantity) AS QuantityProducts from issuing.Products p
                                                             inner join issuing.OrderLines ol
                                                                        on p.ProductId = ol.ProductId
group by ol.ProductId;


-- ============ Question 3 ============
-- Customers who spent more than €100 total (name + total spend)

select C.Name, SUM(OL.Quantity * OL.UnitPrice) as TotalSpent from issuing.Customers C
                                                                      inner join issuing.Orders O
                                                                                 ON C.CustomerId = O.CustomerId

                                                                      inner join issuing.OrderLines OL
                                                                                 on O.OrderId = OL.OrderId

group by C.Name

having TotalSpent > 100

order by TotalSpent DESC;
