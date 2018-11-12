CREATE TABLE [map].[UserCountry] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [UserId]     INT      NOT NULL,
    [CountryId]  INT      NOT NULL,
    [IsDefault]  BIT      CONSTRAINT [DF_UserCountry_IsDefault] DEFAULT ((0)) NOT NULL,
    [CreatedOn]  DATETIME CONSTRAINT [DF_UserCountry_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn] DATETIME CONSTRAINT [DF_UserCountry_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_UserCountry_1] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserCountry_Country] FOREIGN KEY ([CountryId]) REFERENCES [dict].[Country] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserCountry_User] FOREIGN KEY ([UserId]) REFERENCES [auth].[User] ([Id]) ON DELETE CASCADE
);

