CREATE TABLE [Business].[Restaurant] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]         VARCHAR (50)     DEFAULT ('') NOT NULL,
    [Description]  VARCHAR (50)     DEFAULT ('') NOT NULL,
    [MainImageUrl] VARCHAR (50)     DEFAULT ('') NOT NULL
);

