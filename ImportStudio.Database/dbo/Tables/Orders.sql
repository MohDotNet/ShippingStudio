CREATE TABLE [dbo].[Orders] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [SupplierId]             INT            NOT NULL,
    [OrderDate]              DateTime       NULL,
    [IndentNumber]           NVARCHAR (50)  NULL,
    [InternalOrderReference] NVARCHAR (50)  NOT NULL,
    [SupplierOrderReference] NVARCHAR (50)  NULL,
    [PortOfOrigin]           NVARCHAR (100) NOT NULL,
    [PortDestination]        NVARCHAR (100) NOT NULL,
    [CurrencyId]             INT            NOT NULL,
    [IncotermId]             INT            NOT NULL,
    [OrderStatusId]          INT            NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Incoterms_IncotermId] FOREIGN KEY ([IncotermId]) REFERENCES [dbo].[Incoterms] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_OrderStatuses_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Orders_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_CurrencyId]
    ON [dbo].[Orders]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_IncotermId]
    ON [dbo].[Orders]([IncotermId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_OrderStatusId]
    ON [dbo].[Orders]([OrderStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_SupplierId]
    ON [dbo].[Orders]([SupplierId] ASC);

