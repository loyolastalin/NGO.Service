CREATE TABLE [dbo].[Event] (
    [EventID]       INT           NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Description]   NVARCHAR (50) NOT NULL,
    [CreatedBy]     NVARCHAR (50) NOT NULL,
    [CreatedOn]     DATETIME      NOT NULL,
    [ModifiedBy]    DATETIME      NOT NULL,
    [OccursOn]      DATETIME      NOT NULL,
    [OragizationID] INT           NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventID] ASC),
    CONSTRAINT [FK_Event_Organization] FOREIGN KEY ([OragizationID]) REFERENCES [dbo].[Organization] ([OrgaizationID])
);

