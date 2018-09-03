CREATE TABLE [logs].[Error] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [UserId]       INT             NULL,
    [ErrorCode]    BIGINT          NULL,
    [ErrorMessage] NVARCHAR (1024) NULL,
    [StackTrace]   NVARCHAR (MAX)  NULL,
    [CreatedOn]    DATETIME        CONSTRAINT [DF_Error_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ModifiedOn]   DATETIME        CONSTRAINT [DF_Error_ModifiedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Error_User] FOREIGN KEY ([UserId]) REFERENCES [auth].[User] ([Id]) ON DELETE CASCADE
);

