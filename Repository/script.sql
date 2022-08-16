CREATE TABLE [Areas] (
    [Id] int NOT NULL IDENTITY,
    [Province] nvarchar(max) NOT NULL,
    [CityName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Areas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] bigint NOT NULL IDENTITY,
    [Email] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Age] int NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    [Password] varbinary(max) NOT NULL,
    [AreaId] int NOT NULL,
    [Gender] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Users_Areas_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [Areas] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Users_AreaId] ON [Users] ([AreaId]);
GO

CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);
GO


COMMIT;
INSERT Areas (CityName,Province) VALUES(N'�s�F',N'�s�{');
INSERT Areas (CityName,Province) VALUES(N'�s�F',N'�`�`');
INSERT Areas (CityName,Province) VALUES(N'�s�F',N'�]��');
INSERT Areas (CityName,Province) VALUES(N'�֫�',N'�֦{');
INSERT Areas (CityName,Province) VALUES(N'�֫�',N'�H��');
INSERT Areas (CityName,Province) VALUES(N'�s��',N'�n��');
INSERT Areas (CityName,Province) VALUES(N'�s��',N'�۪L');
INSERT Areas (CityName,Province) VALUES(N'�W��',N'�W��');
INSERT Areas (CityName,Province) VALUES(N'�_��',N'�_��');

GO