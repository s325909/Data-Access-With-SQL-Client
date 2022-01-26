USE [SuperheroesDb]

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
SET IDENTITY_INSERT [dbo].[Power] ON 

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
