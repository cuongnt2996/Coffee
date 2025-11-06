-- Create a new table called 'EmployeeStatus' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.EmployeeStatus', 'U') IS NOT NULL
DROP TABLE dbo.EmployeeStatus
GO
-- Create the table in the specified schema
CREATE TABLE dbo.EmployeeStatus
(
    StatusId INT NOT NULL PRIMARY KEY, -- primary key column
    StatusCode [VARCHAR](50) NOT NULL,
    [StatusName] [NVARCHAR](50) NOT NULL,
    [Description] [NVARCHAR](255) NULL,
    OrderNo INT NOT NULL DEFAULT(0),
    IsActive BIT NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NULL

    -- specify more columns here
);
GO