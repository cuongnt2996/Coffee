IF OBJECT_ID('Employee', 'U') IS NOT NULL
DROP TABLE Employee;
GO

CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeCode NVARCHAR(20) NOT NULL UNIQUE,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    JoinDate DATE NOT NULL,
    Department NVARCHAR(50) NULL,
    Position NVARCHAR(50) NULL,
    Salary DECIMAL(18,2) NOT NULL,
    StatusId int,
    TerminationDate DATE NULL
);

