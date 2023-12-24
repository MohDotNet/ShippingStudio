CREATE TABLE [dbo].[OrderLines] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [OrderId]      INT        NOT NULL,
    [ProductId]    INT        NOT NULL,
    [Quantity]     INT        NOT NULL,
    [Price]        FLOAT (53) NOT NULL,
    [LineTotal]    FLOAT (53) NOT NULL,
    [TotalShipped] INT        NOT NULL,
    [LineStatusId] INT        NOT NULL,
    CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderLines_LineStatuses_LineStatusId] FOREIGN KEY ([LineStatusId]) REFERENCES [dbo].[LineStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderLines_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderLines_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderLines_LineStatusId]
    ON [dbo].[OrderLines]([LineStatusId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderLines_OrderId]
    ON [dbo].[OrderLines]([OrderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderLines_ProductId]
    ON [dbo].[OrderLines]([ProductId] ASC);

