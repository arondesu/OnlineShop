-- Create database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'appliance_db')
BEGIN
    CREATE DATABASE appliance_db;
END
GO

USE appliance_db;
GO

-- Create Login table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Login')
BEGIN
    CREATE TABLE Login (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Username VARCHAR(50) NOT NULL,
        Password VARCHAR(50) NOT NULL
    );
END
GO

-- Insert a test user (username: admin, password: admin123)
IF NOT EXISTS (SELECT * FROM Login WHERE Username = 'admin')
BEGIN
    INSERT INTO Login (Username, Password)
    VALUES ('admin', 'admin123');
END
GO