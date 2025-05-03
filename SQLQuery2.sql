-- First, update any NULL values to a default value (like 0)
UPDATE [dbo].[Reports]
SET [QuantityReturned] = 0
WHERE [QuantityReturned] IS NULL;

-- Then alter the column to NOT NULL
ALTER TABLE [dbo].[Reports]
ALTER COLUMN [QuantityReturned] INT NOT NULL;
