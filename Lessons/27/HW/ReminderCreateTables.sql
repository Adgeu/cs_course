CREATE TABLE [ReminderStatus](
    [Id] INT NOT NULL,
    [Name] VARCHAR(32) NOT NULL,

    CONSTRAINT PK_ReminderStatusId PRIMARY KEY ([Id]),
    CONSTRAINT UQ_ReminderStatusName UNIQUE ([Name])
);
GO;

CREATE TABLE [ReminderContact](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [ChatId] VARCHAR(32) NOT NULL,

    CONSTRAINT PK_ReminderContactId PRIMARY KEY ([Id]),
    CONSTRAINT UQ_ReminderContactChatId UNIQUE ([ChatId])
);
GO;

CREATE TABLE [ReminderItem](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [DateTime] DATETIMEOFFSET NOT NULL,
    [StatusId] INT NOT NULL,
    [Message] NVARCHAR(512) NOT NULL,
    [ContactId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedDateTime] DATETIMEOFFSET NOT NULL CONSTRAINT DF_ReminderItemCreatedDateTime DEFAULT GETUTCDATE(),
    [ModifiedDateTime] DATETIMEOFFSET NOT NULL CONSTRAINT DF_ReminderItemModifiedDateTime DEFAULT GETUTCDATE(),

    CONSTRAINT PK_ReminderItemId PRIMARY KEY ([Id]),
    CONSTRAINT FK_ReminderItemStatusId FOREIGN KEY ([StatusId])
        REFERENCES [ReminderStatus]([Id])
            ON UPDATE CASCADE
            ON DELETE CASCADE,
    CONSTRAINT FK_ReminderItemContactId FOREIGN KEY ([ContactId])
        REFERENCES [ReminderContact]([Id])
            ON UPDATE CASCADE
            ON DELETE CASCADE,
);
GO;