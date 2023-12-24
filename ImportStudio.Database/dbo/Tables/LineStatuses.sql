CREATE TABLE [dbo].[LineStatuses] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_LineStatuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

