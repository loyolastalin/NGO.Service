using System.Globalization;

namespace NGO.Service.IntegrationTestHarness.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="System.String"/>
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Performs a String.Format using the invariant culture.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatInvariant(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }
    }
}
