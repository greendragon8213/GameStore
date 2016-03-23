CREATE TABLE [dbo].[Games](
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Key] VARCHAR (32) UNIQUE NOT NULL,
	[Name] VARCHAR (128) NOT NULL,
	[Description] VARCHAR (128) NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC)
)
CREATE TABLE [dbo].[Comments](
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR (128) NOT NULL,
	[Body] VARCHAR (128) NULL,
	[CreationDate] SMALLDATETIME NOT NULL,
	[GameId] INT NOT NULL,
	[ParentCommentId] INT NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
	FOREIGN KEY ([ParentCommentId]) REFERENCES [dbo].[Comments] ([Id])
)
CREATE TABLE [dbo].[Genres](
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR (32) UNIQUE NOT NULL,
	[ParentGenreId] INT NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([ParentGenreId]) REFERENCES [dbo].[Genres] ([Id])
)
CREATE TABLE [dbo].[PlatformTypes](
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[Name] VARCHAR (32) UNIQUE NOT NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC)
)
CREATE TABLE [dbo].[GameToGanre](
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[GameId] INT NULL,
	[GenreId] INT NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
	FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id])
)
CREATE TABLE [dbo].[GameToPlatformType](
	[Id] INT IDENTITY(1, 1) NOT NULL,
	[GameId] INT NULL,
	[PlatformTypeId] INT NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
	FOREIGN KEY ([PlatformTypeId]) REFERENCES [dbo].[PlatformTypes] ([Id])
)