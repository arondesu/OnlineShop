SELECT * FROM inventory;

-- UPDATE - Update price of an item
UPDATE Inventory 
SET InStock = InStock + 1
WHERE ProductName = 'Glass Food Storage';