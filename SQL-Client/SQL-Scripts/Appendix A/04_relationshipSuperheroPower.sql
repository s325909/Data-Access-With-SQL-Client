USE [SuperheroesDb]
GO



ALTER TABLE [dbo].[SuperHeroPower] DROP CONSTRAINT [FK_SuperHeroPower_Superhero1]
GO



ALTER TABLE [dbo].[SuperHeroPower] DROP CONSTRAINT [FK_SuperHeroPower_Power]
GO



/****** Object: Table [dbo].[SuperHeroPower] Script Date: 1/26/2022 11:57:23 PM ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuperHeroPower]') AND type in (N'U'))
DROP TABLE [dbo].[SuperHeroPower]
GO



/****** Object: Table [dbo].[Superhero] Script Date: 1/26/2022 11:57:23 PM ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Superhero]') AND type in (N'U'))
DROP TABLE [dbo].[Superhero]
GO



/****** Object: Table [dbo].[Power] Script Date: 1/26/2022 11:57:23 PM ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Power]') AND type in (N'U'))
DROP TABLE [dbo].[Power]
GO



/****** Object: Table [dbo].[Power] Script Date: 1/26/2022 11:57:23 PM ******/
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



/****** Object: Table [dbo].[Superhero] Script Date: 1/26/2022 11:57:23 PM ******/
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



/****** Object: Table [dbo].[SuperHeroPower] Script Date: 1/26/2022 11:57:23 PM ******/
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



ALTER TABLE [dbo].[SuperHeroPower] WITH CHECK ADD CONSTRAINT [FK_SuperHeroPower_Power] FOREIGN KEY([PowerId])
REFERENCES [dbo].[Power] ([Id])
GO



ALTER TABLE [dbo].[SuperHeroPower] CHECK CONSTRAINT [FK_SuperHeroPower_Power]
GO



ALTER TABLE [dbo].[SuperHeroPower] WITH CHECK ADD CONSTRAINT [FK_SuperHeroPower_Superhero1] FOREIGN KEY([SuperheroId])
REFERENCES [dbo].[Superhero] ([Id])
GO



ALTER TABLE [dbo].[SuperHeroPower] CHECK CONSTRAINT [FK_SuperHeroPower_Superhero1]
GO