CREATE TABLE [dbo].[Incoterms] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [InctermName]    NVARCHAR (100) NOT NULL,
    [IncotermSymbol] NVARCHAR (10)  NOT NULL,
    CONSTRAINT [PK_Incoterms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

