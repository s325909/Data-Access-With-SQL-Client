USE [SuperheroesDb]
GO
SET IDENTITY_INSERT [dbo].[Superhero] ON



INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (1, N'Jasotharan', N'Jaso', N'Sri Lanka', NULL)
INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (2, N'Ammar', N'Ammo', N'Pakistan', NULL)
INSERT [dbo].[Superhero] ([Id], [Name], [Alias], [Origin], [PowerId]) VALUES (3, N'Dewald', N'Chad', N'South Africa', NULL)
SET IDENTITY_INSERT [dbo].[Superhero] OFF
GO