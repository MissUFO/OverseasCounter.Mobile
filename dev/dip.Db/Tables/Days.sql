CREATE TABLE [dbo].[Days] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [UserCountryVisaId] INT      NOT NULL,
    [Days]              INT      NOT NULL,
    [DateStart]         DATETIME NULL,
    [DateEnd]           DATETIME NULL,
    CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Days_UserCountryVisa] FOREIGN KEY ([UserCountryVisaId]) REFERENCES [map].[UserCountryVisa] ([Id]) ON DELETE CASCADE
);

