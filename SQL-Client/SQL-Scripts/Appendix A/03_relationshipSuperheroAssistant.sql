USE [SuperheroesDb]
GO



ALTER TABLE [dbo].[Assistant] DROP CONSTRAINT [FK_Assistant_Superhero]
GO



/****** Object: Table [dbo].[Superhero] Script Date: 1/26/2022 10:50:59 PM ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Superhero]') AND type in (N'U'))
DROP TABLE [dbo].[Superhero]
GO



/****** Object: Table [dbo].[Assistant] Script Date: 1/26/2022 10:50:59 PM ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Assistant]') AND type in (N'U'))
DROP TABLE [dbo].[Assistant]
GO



/****** Object: Table [dbo].[Assistant] Script Date: 1/26/2022 10:50:59 PM ******/
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



/****** Object: Table [dbo].[Superhero] Script Date: 1/26/2022 10:50:59 PM ******/
SET ANSI_NULLS ON
GO



SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[Superhero](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] [nvarchar](50) NULL,
[Alias] [nvarchar](50) NULL,
[Origin] [nvarchar](50) NOT NULL,
CONSTRAINT [PK_Superhero] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[Assistant] WITH CHECK ADD CONSTRAINT [FK_Assistant_Superhero] FOREIGN KEY([SuperHeroId])
REFERENCES [dbo].[Superhero] ([Id])
GO



ALTER TABLE [dbo].[Assistant] CHECK CONSTRAINT [FK_Assistant_Superhero]
GO