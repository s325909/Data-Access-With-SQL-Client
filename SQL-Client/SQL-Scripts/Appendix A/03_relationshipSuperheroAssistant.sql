USE [SuperheroesDb]

ALTER TABLE [dbo].[Assistant]  WITH CHECK ADD  CONSTRAINT [FK_Assistant_Superhero] FOREIGN KEY([SuperHeroId])
REFERENCES [dbo].[Superhero] ([Id])
GO
ALTER TABLE [dbo].[Assistant] CHECK CONSTRAINT [FK_Assistant_Superhero]
GO
