CREATE TABLE [auth].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Email]       NVARCHAR (255) NOT NULL,
    [Password]    NVARCHAR (255) NOT NULL,
    [FirstName]   NVARCHAR (255) NULL,
    [LastName]    NVARCHAR (255) NULL,
    [MiddleName]  NVARCHAR (255) NULL,
    [Photo]       IMAGE          NULL,
    [PhoneNumber] NVARCHAR (50)  NULL,
    [Status]      BIT            CONSTRAINT [DF_User_Status] DEFAULT ((1)) NOT NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_User_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]  DATETIME       CONSTRAINT [DF_User_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    [LastLoginOn] DATETIME       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);





