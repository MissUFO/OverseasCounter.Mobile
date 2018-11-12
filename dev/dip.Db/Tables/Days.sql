CREATE TABLE [dbo].[Days] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [UserId]        INT      NOT NULL,
    [CountryId]     INT      NOT NULL,
    [CountryVisaId] INT      NULL,
    [Days]          INT      NOT NULL,
    [CreatedOn]     DATETIME CONSTRAINT [DF_Days_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn]    DATETIME NULL,
    CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Days_Country] FOREIGN KEY ([CountryId]) REFERENCES [dict].[Country] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Days_User] FOREIGN KEY ([UserId]) REFERENCES [auth].[User] ([Id]) ON DELETE CASCADE
);



