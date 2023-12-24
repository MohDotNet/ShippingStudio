CREATE TABLE [dbo].[FileStatuses] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_FileStatuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

