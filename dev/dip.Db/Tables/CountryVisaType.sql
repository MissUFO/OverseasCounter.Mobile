CREATE TABLE [dict].[CountryVisaType] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [CountryId]     INT             NOT NULL,
    [Name]          NVARCHAR (255)  NOT NULL,
    [Code]          NVARCHAR (50)   NOT NULL,
    [Description]   NVARCHAR (1024) NULL,
    [CountFirstDay] BIT             NULL,
    [CountLastDay]  BIT             NULL,
    [TargetDays]    INT             CONSTRAINT [DF_CountryVisaType_TargetDays] DEFAULT ((190)) NOT NULL,
    [SpecialTime]   NVARCHAR (10)   NULL,
    CONSTRAINT [PK_CountryVisaType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CountryVisaType_Country] FOREIGN KEY ([CountryId]) REFERENCES [dict].[Country] ([Id]) NOT FOR REPLICATION
);


GO
ALTER TABLE [dict].[CountryVisaType] NOCHECK CONSTRAINT [FK_CountryVisaType_Country];




GO
ALTER TABLE [dict].[CountryVisaType] NOCHECK CONSTRAINT [FK_CountryVisaType_Country];

