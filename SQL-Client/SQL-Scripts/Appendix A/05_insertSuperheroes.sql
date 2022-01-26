USE [SuperheroesDb]
GO
/****** Object:  Table [dbo].[Superhero]    Script Date: 1/22/2022 2:55:33 PM ******/
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
SET IDENTITY_INSERT [dbo].[Superhero] ON 

INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (1, N'Jasotharan', N'Jaso', N'Sri Lanka', NULL)
INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (2, N'Ammar', N'Ammo', N'Pakistan', NULL)
INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (3, N'Nicholas', N'Chad', N'South Africa', NULL)
SET IDENTITY_INSERT [dbo].[Superhero] OFF
GO
ALTER TABLE [dbo].[Superhero]  WITH CHECK ADD  CONSTRAINT [FK_Superhero_Power] FOREIGN KEY([PowerId])
REFERENCES [dbo].[Power] ([Id])
GO
ALTER TABLE [dbo].[Superhero] CHECK CONSTRAINT [FK_Superhero_Power]
GO
