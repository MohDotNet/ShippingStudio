CREATE TABLE [dbo].[ShippingPorts] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Port]       NVARCHAR (100) NOT NULL,
    [Country]    NVARCHAR (100) NOT NULL,
    [IsDisabled] BIT            NOT NULL,
    CONSTRAINT [PK_ShippingPorts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

