using System;

namespace NGO.Common.Core
{
    /// <summary>
    /// Guard classes for object null checking.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Checks an argument to ensure it isn't null
        /// </summary>
        /// <param name="argumentValue">The argument value to check.</param>
        /// <param name="argumentName">The name of the argument.</param>
        public static void ArgumentNotNullOrEmpty(object argumentValue, string argumentName)
        {
            if (IsNull(argumentValue))
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        private static bool IsNull(object value)
        {
            var stringValue = value as string;
            if (stringValue == null)
            {
                return value == null;
            }

            return string.IsNullOrEmpty(stringValue) || stringValue.Trim().Length == 0;
        }
    }
}
