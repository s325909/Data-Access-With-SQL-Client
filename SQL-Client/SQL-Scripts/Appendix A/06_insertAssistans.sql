USE [SuperheroesDb]
GO
SET IDENTITY_INSERT [dbo].[Assistant] ON 

INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (1, N'Robin', 2)
INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (2, N'MyAssistant', 1)
INSERT [dbo].[Assistant] ([Id], [Name], [SuperHeroId]) VALUES (3, N'TeacherAssistant', 3)
SET IDENTITY_INSERT [dbo].[Assistant] OFF
GO
