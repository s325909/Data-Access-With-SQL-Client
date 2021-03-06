USE [SuperheroesDb]
GO
/****** Object:  Table [dbo].[Assistant]    Script Date: 1/27/2022 12:07:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assistant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SuperHeroId] [int] NULL,
 CONSTRAINT [PK_Assistant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Power]    Script Date: 1/27/2022 12:07:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Power](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[SuperHeroId] [int] NULL,
 CONSTRAINT [PK_Power] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Superhero]    Script Date: 1/27/2022 12:07:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Superhero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [nvarchar](50) NULL,
	[Origin] [nvarchar](50) NOT NULL,
	[PowerId] [int] NULL,
 CONSTRAINT [PK_Superhero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuperHeroPower]    Script Date: 1/27/2022 12:07:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuperHeroPower](
	[SuperheroId] [int] NOT NULL,
	[PowerId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SuperHeroPower] PRIMARY KEY CLUSTERED 
(
	[SuperheroId] ASC,
	[PowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assistant] ON 

INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (1, N'Robin', 2)
INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (2, N'MyAssistant', 1)
INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (3, N'TeacherAssistant', 3)
SET IDENTITY_INSERT [dbo].[Assistant] OFF
GO
SET IDENTITY_INSERT [dbo].[Power] ON 

INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (1, N'Invisibility', N'You become invisible', 2)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (2, N'Super strength', N'You get 1000x your own strength', 1)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (3, N'Heat ray', N'Shoots lasers from eyes', 1)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (4, N'Infinite stamina', N'Never gets tired', 3)
SET IDENTITY_INSERT [dbo].[Power] OFF
GO
SET IDENTITY_INSERT [dbo].[Superhero] ON 

INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (1, N'Jasotharan', N'Jaso', N'Sri Lanka', NULL)
INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (2, N'Ammar', N'Ammo', N'Pakistan', NULL)
INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (3, N'Dewald', N'Chad', N'South Africa', NULL)
SET IDENTITY_INSERT [dbo].[Superhero] OFF
GO
ALTER TABLE [dbo].[Assistant]  WITH CHECK ADD  CONSTRAINT [FK_Assistant_Superhero] FOREIGN KEY([SuperHeroId])
REFERENCES [dbo].[Superhero] ([Id])
GO
ALTER TABLE [dbo].[Assistant] CHECK CONSTRAINT [FK_Assistant_Superhero]
GO
ALTER TABLE [dbo].[SuperHeroPower]  WITH CHECK ADD  CONSTRAINT [FK_SuperHeroPower_Power] FOREIGN KEY([PowerId])
REFERENCES [dbo].[Power] ([Id])
GO
ALTER TABLE [dbo].[SuperHeroPower] CHECK CONSTRAINT [FK_SuperHeroPower_Power]
GO
ALTER TABLE [dbo].[SuperHeroPower]  WITH CHECK ADD  CONSTRAINT [FK_SuperHeroPower_Superhero1] FOREIGN KEY([SuperheroId])
REFERENCES [dbo].[Superhero] ([Id])
GO
ALTER TABLE [dbo].[SuperHeroPower] CHECK CONSTRAINT [FK_SuperHeroPower_Superhero1]
GO
