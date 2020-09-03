CREATE TABLE [dbo].[Log]
(
	[LogId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedDateTime] DATETIME NOT NULL, 
    [Message] NVARCHAR(MAX) NOT NULL, 
    [ClassName] NCHAR(500) NOT NULL, 
    [ActivityId] NCHAR(50) NOT NULL, 
    [SourceId] INT NOT NULL, 
    [SourceType] NCHAR(50) NOT NULL, 
    [Category] NCHAR(50) NOT NULL
)
