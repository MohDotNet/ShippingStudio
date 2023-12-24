CREATE TABLE [dbo].[Currency] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CurrencyName] NVARCHAR (100) NOT NULL,
    [CurrencyCode] NVARCHAR (5)   NOT NULL,
    [IsDisabled]   BIT            NOT NULL,
    CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED ([Id] ASC)
);

