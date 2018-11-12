CREATE TABLE [map].[UserCountryVisa] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [UserId]            INT      NOT NULL,
    [VisaId]            INT      NOT NULL,
    [CountryId]         INT      NOT NULL,
    [AllowNotification] BIT      NULL,
    [CreatedOn]         DATETIME NULL,
    [ModifiedOn]        DATETIME NULL,
    CONSTRAINT [PK_UserCountry] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserCountryVisa_Country] FOREIGN KEY ([CountryId]) REFERENCES [dict].[Country] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserCountryVisa_CountryVisaType] FOREIGN KEY ([VisaId]) REFERENCES [dict].[CountryVisa] ([Id]) NOT FOR REPLICATION,
    CONSTRAINT [FK_UserCountryVisa_User] FOREIGN KEY ([UserId]) REFERENCES [auth].[User] ([Id]) ON DELETE CASCADE
);


GO
ALTER TABLE [map].[UserCountryVisa] NOCHECK CONSTRAINT [FK_UserCountryVisa_CountryVisaType];




GO


