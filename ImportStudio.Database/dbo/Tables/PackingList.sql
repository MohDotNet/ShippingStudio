CREATE TABLE [dbo].[PackingList] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [SupplierId]        INT             NOT NULL,
    [OrderId]           INT             NOT NULL,
    [ShipQuantity]      DECIMAL (18, 2) NOT NULL,
    [QuantityCheckedIn] DECIMAL (18, 2) NOT NULL,
    [WaybillNumber]     NVARCHAR (150)  NOT NULL,
    [ContainerNumber]   NVARCHAR (150)  NOT NULL,
    [ContainerType]     INT             NOT NULL,
    [PackedDated]       DateTime   NULL,
    [ShippedDate]       DateTime   NULL,
    [HasDeparted]       BIT             NOT NULL,
    [HasArrived]        BIT             NOT NULL,
    [ArrivedDate]       DateTime   NULL,
    [HasDelivered]      BIT             NOT NULL,
    [DeliveredDate]     DateTime   NULL,
    [CostingDone]       BIT             NOT NULL,
    [CostingDate]       DateTime   NULL,
    [OrderLinesId]      INT             NULL,
    CONSTRAINT [PK_PackingList] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PackingList_OrderLines_OrderLinesId] FOREIGN KEY ([OrderLinesId]) REFERENCES [dbo].[OrderLines] ([Id]),
    CONSTRAINT [FK_PackingList_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_PackingList_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PackingList_OrderId]
    ON [dbo].[PackingList]([OrderId] ASC);


GO



GO
CREATE NONCLUSTERED INDEX [IX_PackingList_SupplierId]
    ON [dbo].[PackingList]([SupplierId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PackingList_OrderLinesId]
    ON [dbo].[PackingList]([OrderLinesId] ASC);

