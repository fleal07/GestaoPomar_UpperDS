IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621005352_InitialMigration')
BEGIN
    CREATE TABLE [Arvores] (
        [IdArvore] int NOT NULL IDENTITY,
        [IdEspecie] int NOT NULL,
        [CodigoArvore] nvarchar(10) NOT NULL,
        [Descricao] nvarchar(250) NOT NULL,
        [Idade] int NOT NULL,
        CONSTRAINT [PK_Arvores] PRIMARY KEY ([IdArvore])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621005352_InitialMigration')
BEGIN
    CREATE TABLE [Colheita] (
        [IdColheita] int NOT NULL IDENTITY,
        [IdArvore] int NOT NULL,
        [Info] nvarchar(250) NOT NULL,
        [DataColheita] datetime2 NOT NULL,
        [PesoBruto] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Colheita] PRIMARY KEY ([IdColheita])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621005352_InitialMigration')
BEGIN
    CREATE TABLE [Commands] (
        [Id] int NOT NULL IDENTITY,
        [Howto] nvarchar(250) NOT NULL,
        [Line] nvarchar(max) NOT NULL,
        [Plataform] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Commands] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621005352_InitialMigration')
BEGIN
    CREATE TABLE [Especies] (
        [IdEspecie] int NOT NULL IDENTITY,
        [CodigoEspecie] nvarchar(10) NOT NULL,
        [Descricao] nvarchar(250) NOT NULL,
        CONSTRAINT [PK_Especies] PRIMARY KEY ([IdEspecie])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621005352_InitialMigration')
BEGIN
    CREATE TABLE [GrupoArvores] (
        [IdGrupoArvore] int NOT NULL IDENTITY,
        [IdArvore] int NOT NULL,
        [CodigoGrupoArvore] nvarchar(10) NOT NULL,
        [Nome] nvarchar(100) NOT NULL,
        [Descricao] nvarchar(250) NOT NULL,
        CONSTRAINT [PK_GrupoArvores] PRIMARY KEY ([IdGrupoArvore])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200621005352_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200621005352_InitialMigration', N'3.1.5');
END;

GO

