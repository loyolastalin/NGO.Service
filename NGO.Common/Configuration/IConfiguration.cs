using System.Collections.Generic;

namespace NGO.Common.Configuration
{
    /// <summary>
    /// An interface to the configuration service.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Retrieves the single configuration item requested
        /// </summary>
        /// <typeparam name="T">The expected type of the data</typeparam>
        /// <param name="key">The key for the data</param>
        /// <returns>The configuration item requested, converted to the required type</returns>
        T GetValue<T>(string key);

        /// <summary>
        /// Retrieves the list of configuration items requested
        /// </summary>
        /// <typeparam name="T">The expected type of the data</typeparam>
        /// <param name="key">The key for the data</param>
        /// <returns>The list of configuration items requested, converted to the required type</returns>
        IEnumerable<T> GetValues<T>(string key);
    }
}
