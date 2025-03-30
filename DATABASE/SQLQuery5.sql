USE [appliance_db]
GO

-- Check if table exists and create if it doesn't
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Inventory](
        [ProductID] INT IDENTITY(1,1) PRIMARY KEY,
        [ProductName] NVARCHAR(100),
        [Description] NVARCHAR(255),
        [Quantity] INT,
        [Price] DECIMAL(10,2),
        [Category] NVARCHAR(50)
    )

    -- Insert sample data
    INSERT INTO [dbo].[Inventory] ([ProductName], [Description], [Quantity], [Price], [Category])
    VALUES 
        ('Refrigerator', 'Double Door Frost Free', 5, 899.99, 'Kitchen Appliances'),
        ('Dishwasher', 'Energy Efficient Model', 3, 599.99, 'Kitchen Appliances'),
        ('Microwave', 'Digital Control Panel', 8, 149.99, 'Kitchen Appliances'),
        ('Coffee Maker', 'Programmable Timer', 12, 79.99, 'Small Appliances'),
        ('Food Processor', 'Multi-function', 6, 129.99, 'Small Appliances')
END