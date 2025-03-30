CREATE TABLE Inventory_Query (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Description VARCHAR(255),
    Quantity INT,
    Price DECIMAL(10,2),
    Category VARCHAR(50)
);

-- Optional: Insert some sample data
INSERT INTO Inventory (ProductName, Description, Quantity, Price, Category)
VALUES 
    ('Microwave Oven', 'Samsung 20L', 10, 199.99, 'Appliances'),
    ('Coffee Maker', 'Delonghi Automatic', 15, 299.99, 'Appliances'),
    ('Blender', 'Ninja Professional', 20, 89.99, 'Appliances');