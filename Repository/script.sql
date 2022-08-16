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
INSERT Areas (CityName,Province) VALUES(N'廣東',N'廣州');
INSERT Areas (CityName,Province) VALUES(N'廣東',N'深圳');
INSERT Areas (CityName,Province) VALUES(N'廣東',N'珠海');
INSERT Areas (CityName,Province) VALUES(N'福建',N'福州');
INSERT Areas (CityName,Province) VALUES(N'福建',N'廈門');
INSERT Areas (CityName,Province) VALUES(N'廣西',N'南寧');
INSERT Areas (CityName,Province) VALUES(N'廣西',N'桂林');
INSERT Areas (CityName,Province) VALUES(N'上海',N'上海');
INSERT Areas (CityName,Province) VALUES(N'北京',N'北京');

GO