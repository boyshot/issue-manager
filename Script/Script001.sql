IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    [Email] varchar(200) NOT NULL,
    [Password] varchar(100) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Issues] (
    [Id] int NOT NULL IDENTITY,
    [DataBase] varchar(20) NULL,
    [Server] varchar(30) NULL,
    [UrlIssue] varchar(200) NULL,
    [DateBegin] datetime2 NOT NULL,
    [DateEnd] datetime2 NOT NULL,
    [Text] varchar(max) NULL,
    [Abstract] varchar(100) NULL,
    [IdUser] int NOT NULL,
    CONSTRAINT [PK_Issues] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Issues_Users_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [Email], [Name], [Password])
VALUES (1, 'admin@admin.com', 'admin', 'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Name', N'Password') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_Issues_IdUser] ON [Issues] ([IdUser]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210607175004_InitialMigration', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Attachments] (
    [Id] int NOT NULL IDENTITY,
    [IdIssue] int NOT NULL,
    [FileName] varchar(100) NULL,
    [Content] varbinary(max) NULL,
    CONSTRAINT [PK_Attachments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Attachments_Issues_IdIssue] FOREIGN KEY ([IdIssue]) REFERENCES [Issues] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Attachments_IdIssue] ON [Attachments] ([IdIssue]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210616203740_AddAttachmentScript', N'5.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Attachments] ADD [ContentType] varchar(150) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210621114732_AddTableAttach', N'5.0.6');
GO

COMMIT;
GO

