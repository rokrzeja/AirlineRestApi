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

IF SCHEMA_ID(N'c') IS NULL EXEC(N'CREATE SCHEMA [c];');
GO

CREATE TABLE [c].[Airplane] (
    [airplane_id] int NOT NULL IDENTITY,
    [code] nvarchar(30) NOT NULL,
    [shortcut] nvarchar(30) NOT NULL,
    [full_name] nvarchar(150) NOT NULL,
    [economy_class_capacity] int NOT NULL,
    [business_class_capacity] int NOT NULL,
    [first_class_capacity] int NOT NULL,
    [range] int NOT NULL,
    [production_year] int NOT NULL,
    [manufacturer] nvarchar(150) NOT NULL,
    [hours_flown] float NOT NULL,
    [date_of_last_service] datetime2 NOT NULL,
    CONSTRAINT [PK_Airplane] PRIMARY KEY ([airplane_id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210510133012_AddedAirplaneTable', N'5.0.5');
GO

COMMIT;
GO

