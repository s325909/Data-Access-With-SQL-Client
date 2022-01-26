USE [SuperheroesDb]
GO
/****** Object:  Table [dbo].[Assistant]    Script Date: 1/22/2022 3:01:31 PM ******/
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
SET IDENTITY_INSERT [dbo].[Assistant] ON 

INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (1, N'Robin', 2)
INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (2, N'MyAssistant', 1)
INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (3, N'TeacherAssistant', 3)
SET IDENTITY_INSERT [dbo].[Assistant] OFF
GO
ALTER TABLE [dbo].[Assistant]  WITH CHECK ADD  CONSTRAINT [FK_Assistant_Superhero] FOREIGN KEY([SuperHeroId])
REFERENCES [dbo].[Superhero] ([Id])
GO
ALTER TABLE [dbo].[Assistant] CHECK CONSTRAINT [FK_Assistant_Superhero]
GO
