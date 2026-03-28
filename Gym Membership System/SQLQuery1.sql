USE GymDB;
GO

-- Drop tables if they exist (order matters due to foreign keys)
DROP TABLE IF EXISTS LoginAttempts;
DROP TABLE IF EXISTS Admins;
GO

-- Create Admins table with no initial data
CREATE TABLE Admins (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'Admin',
    IsActive BIT NOT NULL DEFAULT 1,
    LastLogin DATETIME NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Create LoginAttempts table
CREATE TABLE LoginAttempts (
    AttemptID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(100) NOT NULL,
    AttemptTime DATETIME NOT NULL DEFAULT GETDATE(),
    WasSuccessful BIT NOT NULL DEFAULT 0,
    IPAddress NVARCHAR(50) NULL
);
GO

-- Create indexes for performance
CREATE INDEX IX_Admins_Email ON Admins(Email);
CREATE INDEX IX_Admins_Username ON Admins(Username);
CREATE INDEX IX_LoginAttempts_Email ON LoginAttempts(Email);
CREATE INDEX IX_LoginAttempts_AttemptTime ON LoginAttempts(AttemptTime);
GO

-- Verify no accounts exist
SELECT COUNT(*) AS TotalAdmins FROM Admins;
GO