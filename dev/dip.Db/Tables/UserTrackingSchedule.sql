CREATE TABLE [dbo].[UserTrackingSchedule] (
    [Id]                      INT             IDENTITY (1, 1) NOT NULL,
    [UserId]                  INT             NOT NULL,
    [ScheduledHours]          INT             CONSTRAINT [DF_UserTrackingSchedule_PeriodHours] DEFAULT ((1)) NOT NULL,
    [ScheduledDays]           INT             CONSTRAINT [DF_UserTrackingSchedule_PeriodDays] DEFAULT ((1)) NOT NULL,
    [ScheduledNotificationId] NVARCHAR (1024) NULL,
    [Enabled]                 BIT             CONSTRAINT [DF_UserTrackingSchedule_Enabled] DEFAULT ((1)) NULL,
    [LastRun]                 DATETIME        NULL,
    [CreatedOn]               DATETIME        CONSTRAINT [DF_UserTrackingSchedule_CreatedOn] DEFAULT (getdate()) NULL,
    [ModifiedOn]              DATETIME        CONSTRAINT [DF_UserTrackingSchedule_ModifiedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_UserTrackingSchedule] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserTrackingSchedule_User] FOREIGN KEY ([UserId]) REFERENCES [auth].[User] ([Id]) ON DELETE CASCADE
);



