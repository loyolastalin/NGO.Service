PRINT 'Loading config master data' 			
		
INSERT INTO [dbo].[ConfigSetting]
           ([LastUpdateDateTime]
           ,[ConfigKey]
           ,[ConfigValue])
     VALUES
          (getdate()
           ,'LogLevel'
           ,'4')