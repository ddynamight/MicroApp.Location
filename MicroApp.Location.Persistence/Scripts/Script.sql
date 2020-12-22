IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201125173854_InitialCreate')
BEGIN
    CREATE TABLE [Bicycles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [Latitude] decimal(9,6) NOT NULL,
        [Longitude] decimal(12,9) NOT NULL,
        [RowVersion] rowversion NULL,
        CONSTRAINT [PK_Bicycles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201125173854_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201125173854_InitialCreate', N'3.1.10');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201129184303_AddedVehicle')
BEGIN
    CREATE TABLE [Vehicles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [RegNo] nvarchar(max) NULL,
        [Latitude] decimal(9,6) NOT NULL,
        [Longitude] decimal(12,9) NOT NULL,
        [RowVersion] rowversion NULL,
        CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201129184303_AddedVehicle')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201129184303_AddedVehicle', N'3.1.10');
END;

GO

