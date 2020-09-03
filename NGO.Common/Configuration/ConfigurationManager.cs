using System;
using System.Collections.Generic;
using System.Linq;
using NGO.Common.Configuration.Repository;
using NGO.Common.Core;
using NGO.Common.Core.Extensions;

namespace NGO.Common.Configuration
{
    /// <summary>
    /// A class that uses a repository to retrieve configuration values
    /// </summary>
    public class ConfigurationManager : IConfiguration
    {
        private const string InputKeyValidationException = "Key value can not be null or empty.";
        private const string KeyNotFound = "Configuration item found did not have exactly one entry for key '{0}'.";
        private static readonly object Padlock = new object();
        private static IConfiguration _configurationManager;
        
        /// <summary>
        /// Initializes a new instance of the ConfigurationManager class.
        /// </summary>
        /// <param name="repository">The repository interface to the configuration data layer</param>
        public ConfigurationManager(IConfigurationRepository repository)
        {
            Guard.ArgumentNotNull(repository, "ConfigurationRepository cannot be null");
            
            Repository = repository;
        }

        /// <summary>
        /// Returns singleton instance of ConfigurationManager
        /// </summary>
        public static IConfiguration Current
        {
            get
            {
                lock (Padlock)
                {
                    if (_configurationManager == null)
                    {
                        _configurationManager = new ConfigurationManager(new ConfigurationRepository());
                    }
                }

                return _configurationManager;
            }

            internal set
            {
                _configurationManager = value;
            }
        }

        /// <summary>
        /// Gets the repository
        /// </summary>
        private IConfigurationRepository Repository { get; set; }

        /// <summary>
        /// Retrieves the single configuration item requested
        /// </summary>
        /// <typeparam name="T">The expected type of the data</typeparam>
        /// <param name="key">The key for the data</param>
        /// <returns>The configuration item requested, converted to the required type</returns>
        public T GetValue<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ConfigurationException(InputKeyValidationException);
            }

            ICollection<string> values = GetStringValues(key);

            if (values.Count != 1)
            {
                throw new ConfigurationException(KeyNotFound.FormatInvariant(key));
            }

            return (T)Convert.ChangeType(values.First(), typeof(T));
        }

        /// <summary>
        /// Retrieves the list of configuration items requested
        /// </summary>
        /// <typeparam name="T">The expected type of the data</typeparam>
        /// <param name="key">The key for the data</param>
        /// <returns>The list of configuration items requested, converted to the required type</returns>
        public IEnumerable<T> GetValues<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ConfigurationException(InputKeyValidationException);
            }

            ICollection<string> values = GetStringValues(key);
            if (values.Count <= 0)
            {
                throw new ConfigurationException(KeyNotFound.FormatInvariant(key));
            }

            return values.Select(value => (T)Convert.ChangeType(value, typeof(T))).ToList();
        }

        /// <summary>
        /// Retrieves the requested configuration in string form.
        /// </summary>
        /// <param name="key">The key for the data</param>
        /// <returns>The list of configuration items requested, as strings</returns>
        private ICollection<string> GetStringValues(string key)
        {
            return Repository.GetValues(key);
        }
    }
}
