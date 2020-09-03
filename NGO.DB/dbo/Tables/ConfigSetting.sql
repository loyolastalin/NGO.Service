CREATE TABLE [dbo].[ConfigSetting]
(
	[ConfigSettingId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LastUpdateDateTime] DATETIME NOT NULL, 
    [ConfigKey] NCHAR(100) NOT NULL, 
    [ConfigValue] NCHAR(100) NOT NULL
)
