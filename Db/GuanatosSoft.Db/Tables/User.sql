CREATE TABLE [Security].[User] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FirstName] VARCHAR (50)     DEFAULT ('') NOT NULL,
    [LastName]  VARCHAR (50)     DEFAULT ('') NOT NULL,
    [UserName]  VARCHAR (20)     DEFAULT ('') NOT NULL,
    [Password]  VARCHAR (20)     DEFAULT ('') NOT NULL
);

