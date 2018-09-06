CREATE TABLE [dbo].[Usuario]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Usuario] NVARCHAR(19),
	[Senha] NVARCHAR(14),
	constraint [pk_MinosDB] primary key ([Id])
);