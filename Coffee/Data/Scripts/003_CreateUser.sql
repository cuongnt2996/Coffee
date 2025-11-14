CREATE TABLE [User] (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NULL, -- mapping tới nhân viên, nhưng KHÔNG bắt buộc
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(500) NOT NULL,
    PasswordSalt NVARCHAR(500) NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    LastLogin DATETIME NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL
);

ALTER TABLE [User]
ADD CONSTRAINT FK_User_Employee
FOREIGN KEY (EmployeeId) REFERENCES Employee(Id);
