CREATE TABLE [dict].[Country] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (255) NOT NULL,
    [Code]       NVARCHAR (5)   NOT NULL,
    [CreatedOn]  DATETIME       CONSTRAINT [DF_Country_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn] DATETIME       CONSTRAINT [DF_Country_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([Id] ASC)
);

