CREATE TABLE [dbo].[Suppliers] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Company]         NVARCHAR (100) NOT NULL,
    [ContactPerson]   NVARCHAR (100) NOT NULL,
    [Email]           NVARCHAR (250) NOT NULL,
    [TelephoneNumebr] NVARCHAR (20)  NOT NULL,
    [CurrencyId]      INT            NOT NULL,
    [ShippingPortId]  INT            NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Suppliers_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Suppliers_ShippingPorts_ShippingPortId] FOREIGN KEY ([ShippingPortId]) REFERENCES [dbo].[ShippingPorts] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Suppliers_CurrencyId]
    ON [dbo].[Suppliers]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Suppliers_ShippingPortId]
    ON [dbo].[Suppliers]([ShippingPortId] ASC);

