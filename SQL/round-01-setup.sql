-- Infomil SQL Round 1 — MySQL Workbench setup
--
-- IF YOU GET "Access denied" ON DROP DATABASE:
--   1. In Workbench left sidebar, double-click a database YOU own (e.g. your username schema)
--   2. Run ONLY this file (no CREATE/DROP DATABASE needed)
--
-- STEP 1: Uncomment and set your database, OR select it in the sidebar first:
-- USE your_database_name;

-- ============ RESET TABLES (safe — no DROP DATABASE) ============

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS OrderLines;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Stock;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Stores;
DROP TABLE IF EXISTS Customers;

SET FOREIGN_KEY_CHECKS = 1;

-- ============ TABLES ============

CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
    Name       VARCHAR(100) NOT NULL,
    City       VARCHAR(100) NOT NULL
);

CREATE TABLE Stores (
    StoreId INT PRIMARY KEY,
    Name    VARCHAR(100) NOT NULL,
    City    VARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductId  INT PRIMARY KEY,
    Name       VARCHAR(100) NOT NULL,
    Category   VARCHAR(100) NOT NULL,
    UnitPrice  DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Stock (
    StoreId           INT NOT NULL,
    ProductId         INT NOT NULL,
    QuantityAvailable INT NOT NULL,
    PRIMARY KEY (StoreId, ProductId),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

CREATE TABLE Orders (
    OrderId    INT PRIMARY KEY,
    CustomerId INT NOT NULL,
    StoreId    INT NOT NULL,
    OrderDate  DATE NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (StoreId) REFERENCES Stores(StoreId)
);

CREATE TABLE OrderLines (
    OrderLineId INT PRIMARY KEY,
    OrderId     INT NOT NULL,
    ProductId   INT NOT NULL,
    Quantity    INT NOT NULL,
    UnitPrice   DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- ============ SAMPLE DATA ============

INSERT INTO Customers (CustomerId, Name, City) VALUES
(1, 'Alice', 'Port Louis'),
(2, 'Bob',   'Curepipe');

INSERT INTO Stores (StoreId, Name, City) VALUES
(1, 'Store Port Louis', 'Port Louis'),
(2, 'Store Curepipe',   'Curepipe');

INSERT INTO Products (ProductId, Name, Category, UnitPrice) VALUES
(101, 'Pencil',   'Stationery', 5.00),
(102, 'ClearBag', 'Bags',       20.00),
(103, 'Eraser',   'Stationery', 2.00),
(104, 'Notebook', 'Stationery', 8.00);

INSERT INTO Stock (StoreId, ProductId, QuantityAvailable) VALUES
(1, 101, 100),
(1, 102, 15),
(1, 103, 0),
(2, 101, 3),
(2, 102, 50),
(2, 103, 10);

INSERT INTO Orders (OrderId, CustomerId, StoreId, OrderDate) VALUES
(1, 1, 1, '2026-06-15'),
(2, 1, 1, '2026-03-10'),
(3, 2, 2, '2026-06-01'),
(4, 2, 2, '2026-01-20'),
(5, 2, 1, '2025-12-01');

INSERT INTO OrderLines (OrderLineId, OrderId, ProductId, Quantity, UnitPrice) VALUES
(1, 1, 101, 10, 5.00),
(2, 1, 102, 5,  20.00),
(3, 2, 101, 5,  5.00),
(4, 3, 101, 2,  5.00),
(5, 3, 102, 3,  20.00),
(6, 4, 102, 10, 20.00),
(7, 5, 103, 5,  2.00);

-- ============ VERIFY ============
SELECT 'Setup OK' AS Status;
SELECT COUNT(*) AS OrderLineCount FROM OrderLines;
