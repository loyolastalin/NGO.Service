CREATE TABLE [dbo].[Audit]
(
	[AuditId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDateTime] DATETIME NOT NULL, 
    [SourceId] NCHAR(100) NOT NULL, 
    [AuditType] NCHAR(100) NOT NULL, 
    [AuditMessage] NVARCHAR(MAX) NOT NULL, 
    [ParticipantId] NCHAR(100) NOT NULL, 
    [ParticipantType] NCHAR(100) NOT NULL
)
