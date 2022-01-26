USE [SuperheroesDb]
GO
SET IDENTITY_INSERT [dbo].[Power] ON 

INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (1, N'Invisibility', N'You become invisible', 2)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (2, N'Super strength', N'You get 1000x your own strength', 1)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (3, N'Heat ray', N'Shoots lasers from eyes', 1)
INSERT [dbo].[Power] ([Id], [Name], [Description], [SuperHeroId]) VALUES (4, N'Infinite stamina', N'Never gets tired', 3)
SET IDENTITY_INSERT [dbo].[Power] OFF
GO
