
CREATE SCHEMA [Security]
GO

CREATE TABLE [Security].[User](
	Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	FirstName VARCHAR(50) NOT NULL DEFAULT '', 
	LastName VARCHAR(50) NOT NULL DEFAULT '', 
	UserName VARCHAR(20) NOT NULL DEFAULT '', 
	Password VARCHAR(20) NOT NULL DEFAULT '', 
)
GO