USE [SuperheroesDb]
GO
/****** Object:  Table [dbo].[Power]    Script Date: 1/22/2022 3:07:06 PM ******/
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
SET IDENTITY_INSERT [dbo].[Power] ON 

INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (1, N'Invisibility', N'You become invisible', 2)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (2, N'Super strength', N'You get 1000x your own strength', 1)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (3, N'Heat ray', N'Shoots lasers from eyes', 1)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (4, N'Infinite stamina', N'Never gets tired', 3)
SET IDENTITY_INSERT [dbo].[Power] OFF
GO
