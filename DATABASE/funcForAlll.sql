SELECT * FROM Login

SELECT * FROM inventory

CREATE TABLE items
(
	id INT PRIMARY KEY IDENTITY(1,1),
	item_id VARCHAR(MAX) NOT NULL,
	item_name VARCHAR(MAX) NOT NULL,
	item_type VARCHAR(MAX) NOT NULL,
	Description VARCHAR (MAX) NULL,
	item_stock INT NULL,
	item_price FLOAT NULL,
	item_image VARCHAR(MAX) NULL,
	date_insert DATE NULL,
	date_update DATE NULL,
	date_delete DATE NULL,
);

-- Check if there are any items in the table
SELECT COUNT(*) as TotalItems FROM items;

-- Then, use this query to view the data with proper formatting
SELECT 
    id,
    item_id,
    item_name,
    item_type,
    Description,
    item_stock,
    item_price,
    CONVERT(varchar, date_insert, 120) as date_insert,
    CONVERT(varchar, date_update, 120) as date_update
FROM items 
WHERE date_delete IS NULL 
ORDER BY id DESC;





