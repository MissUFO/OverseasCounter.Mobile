CREATE TABLE [logs].[Log] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NULL,
    [ActionType] INT            CONSTRAINT [DF_Log_ActionType] DEFAULT ((0)) NOT NULL,
    [PageUrl]    NVARCHAR (255) NOT NULL,
    [OccurredOn] DATETIME       CONSTRAINT [DF_Log_OccurredOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Log_LogActionType] FOREIGN KEY ([ActionType]) REFERENCES [enum].[LogActionType] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Log_User] FOREIGN KEY ([UserId]) REFERENCES [auth].[User] ([Id]) ON DELETE CASCADE
);

