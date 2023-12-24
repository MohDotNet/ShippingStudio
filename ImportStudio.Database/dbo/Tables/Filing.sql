CREATE TABLE [dbo].[Filing] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Filename]       NVARCHAR (100) NOT NULL,
    [FileCode]       NVARCHAR (50)  NOT NULL,
    [SupplierId]     INT            NOT NULL,
    [FileStatus]     INT            DEFAULT ((0)) NOT NULL,
    [FileStatusesId] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Filing] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Filing_FileStatuses_FileStatusesId] FOREIGN KEY ([FileStatusesId]) REFERENCES [dbo].[FileStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Filing_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Filing_SupplierId]
    ON [dbo].[Filing]([SupplierId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Filing_FileStatusesId]
    ON [dbo].[Filing]([FileStatusesId] ASC);

