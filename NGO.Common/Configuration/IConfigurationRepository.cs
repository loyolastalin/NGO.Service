using System.Collections.Generic;

namespace NGO.Common.Configuration
{
    /// <summary>
    /// A repository for retrieving configuration information
    /// </summary>
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Returns a list of strings indicating the requested configuration values.
        /// </summary>
        /// <param name="key">The configuration key</param>
        /// <returns>A list of string values associated with the key for the specified service</returns>
        ICollection<string> GetValues(string key);
    }
}
