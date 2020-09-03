using System;
using System.Collections.Generic;
using System.Linq;
using NGO.Common.Core;
using NGO.EntityFramework;

namespace NGO.Common.Configuration.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public ICollection<string> GetValues(string key)
        {
            Guard.ArgumentNotNullOrEmpty(key, "key");

            using (var entities = new NGODBEntities())
            {
                var item = entities.ConfigSettings.ToList().Where(setting => string.Equals(setting.ConfigKey.Trim(), key, StringComparison.CurrentCultureIgnoreCase));

                var configSettings = item as IList<ConfigSetting> ?? item.ToList();
                if (!configSettings.Any())
                {
                    throw new KeyNotFoundException(
                        "Configuration value not found for service for the and key '" + key);
                }

                ICollection<string> values = configSettings.Where(s => s.ConfigValue != null).Select(s => s.ConfigValue).ToList();
                return values;
            }
        }
    }
}
