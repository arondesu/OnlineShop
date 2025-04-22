-- SELECT (Read) - Query all items
SELECT * FROM Inventory;

-- INSERT (Create) - Add new items to inventory
INSERT INTO Inventory (ProductName, Description, Price, InStock, Category)
VALUES 
    ('Glass Food Storage', 'High-quality glass container for food storage', 275.00, 50, 'Storage'),
    ('Steel Mug Rack', 'Stainless steel rack for mugs', 50.45, 30, 'Organization'),
    ('Mitts Potholders', 'Heat-resistant kitchen mitts', 65.00, 40, 'Safety'),
    ('Steel Brazier Pot', 'Durable steel cooking pot', 150.50, 25, 'Cookware'),
    ('Descascador', 'Multipurpose peeler tool', 79.00, 35, 'Utensils'),
    ('Cleaning Sponge', 'Heavy-duty kitchen cleaning sponge', 35.50, 100, 'Cleaning'),
    ('Silverware Set', 'Complete set of silverware', 175.50, 20, 'Dining'),
    ('Kitchen Scale', 'Digital kitchen scale with high precision', 499.00, 15, 'Measurement'),
    ('Table Cloth', 'Elegant table cloth for dining', 55.50, 45, 'Dining');

-- SELECT (Read) - Query specific item by ID
SELECT * FROM Inventory WHERE ProductID = 1;

-- SELECT (Read) - Query items by category
SELECT * FROM Inventory WHERE Category = 'Dining';

-- SELECT (Read) - Query items with low stock (less than 20)
SELECT * FROM Inventory WHERE InStock < 20;

-- UPDATE - Update price of an item
UPDATE Inventory 
SET Price = 280.00
WHERE ProductName = 'Glass Food Storage';

-- UPDATE - Increase stock quantity
UPDATE Inventory 
SET InStock = InStock + 50
WHERE ProductName = 'Glass Food Storage';

-- UPDATE - Update multiple fields
UPDATE Inventory 
SET Description = 'Premium quality glass container for food storage',
    Category = 'Kitchen Storage',
    Price = 285.00
WHERE ProductName = 'Glass Food Storage';

-- DELETE - Remove an item from inventory
DELETE FROM Inventory 
WHERE ProductName = 'Sample Item To Delete';

-- SELECT with ORDER BY - Get items sorted by price (highest to lowest)
SELECT * FROM Inventory ORDER BY Price DESC;

-- SELECT with GROUP BY - Count items by category
SELECT Category, COUNT(*) AS ItemCount, SUM(InStock) AS TotalStock
FROM Inventory
GROUP BY Category;

-- Check if specific product exists
IF EXISTS (SELECT 1 FROM Inventory WHERE ProductName = 'Glass Food Storage')
BEGIN
    PRINT 'Product exists in inventory';
END
ELSE
BEGIN
    PRINT 'Product not found';
END