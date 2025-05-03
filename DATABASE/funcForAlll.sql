SELECT * FROM Login

SELECT * FROM inventory

CREATE TABLE items
(
	id INT PRIMARY KEY IDENTITY(1,1),
	item_id VARCHAR(MAX) NOT NULL,
	item_name VARCHAR(MAX) NOT NULL,
	item_type VARCHAR(MAX) NOT NULL,
	item_stock INT NULL,
	item_price FLOAT NULL,
	item_status VARCHAR(MAX) NULL,
	item_image VARCHAR(MAX) NULL,
	date_insert DATE NULL,
	date_update DATE NULL,
	date_delete DATE NULL,
);

SELECT * FROM items;

SELECT * FROM items WHERE date_delete IS NULL





