CREATE TABLE [dbo].[Usuarios] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Login] NVARCHAR (19) NOT NULL,
    [Senha] NVARCHAR (14) NOT NULL,
    [Admin] CHAR (1)      NULL,
    CONSTRAINT [PK_Servicos] PRIMARY KEY CLUSTERED ([Id] ASC)
);