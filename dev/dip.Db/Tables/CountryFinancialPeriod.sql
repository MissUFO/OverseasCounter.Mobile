CREATE TABLE [dict].[CountryFinancialPeriod] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [CountryId] INT      NOT NULL,
    [DateStart] DATETIME NULL,
    [DateEnd]   DATETIME NULL,
    CONSTRAINT [PK_CountryFinancialPeriod] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CountryFinancialPeriod_Country] FOREIGN KEY ([CountryId]) REFERENCES [dict].[Country] ([Id]) ON DELETE CASCADE NOT FOR REPLICATION
);


GO
ALTER TABLE [dict].[CountryFinancialPeriod] NOCHECK CONSTRAINT [FK_CountryFinancialPeriod_Country];




GO


