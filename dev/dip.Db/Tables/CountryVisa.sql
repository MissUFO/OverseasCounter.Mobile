CREATE TABLE [dict].[CountryVisa] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [CountryId]     INT             NOT NULL,
    [Name]          NVARCHAR (255)  NOT NULL,
    [Code]          NVARCHAR (50)   NOT NULL,
    [Description]   NVARCHAR (1024) NULL,
    [DateStart]     DATETIME        CONSTRAINT [DF_CountryVisaType_DateStart] DEFAULT (getdate()) NOT NULL,
    [DateEnd]       DATETIME        CONSTRAINT [DF_CountryVisaType_DateEnd] DEFAULT (getdate()) NOT NULL,
    [CountFirstDay] BIT             NULL,
    [CountLastDay]  BIT             NULL,
    [TargetDays]    INT             CONSTRAINT [DF_CountryVisaType_TargetDays] DEFAULT ((30)) NOT NULL,
    [SpecialTime]   NVARCHAR (10)   NULL,
    CONSTRAINT [PK_CountryVisaType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CountryVisaType_Country] FOREIGN KEY ([CountryId]) REFERENCES [dict].[Country] ([Id]) ON DELETE CASCADE NOT FOR REPLICATION
);


GO
ALTER TABLE [dict].[CountryVisa] NOCHECK CONSTRAINT [FK_CountryVisaType_Country];

