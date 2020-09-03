CREATE TABLE [dbo].[Organization] (
    [OrgaizationID] INT           NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Description]   NVARCHAR (50) NOT NULL,
    [URL]           NVARCHAR (50) NULL,
    CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED ([OrgaizationID] ASC)
);

