using System;
using System.Text;

namespace NGO.Common.Core.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="Exception"/> type.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Convert Exception object into a string representation for Logging purpose.
        /// </summary>
        /// <param name="exception">Input Exception object.</param>
        /// <returns>A string representation of Exception object.</returns>
        public static string ToLoggableString(this Exception exception)
        {
            var sb = new StringBuilder();

            while (exception != null)
            {
                string message = exception.Message;
                if (string.IsNullOrEmpty(message))
                {
                    sb.Append(exception.GetType().ToString());
                }
                else
                {
                    sb.Append(exception.GetType().ToString());
                    sb.Append(": ");
                    sb.Append(message);
                }

                if (exception.StackTrace != null)
                {
                    sb.AppendLine();
                    sb.Append(exception.StackTrace);
                }

                sb.AppendLine();

                exception = exception.InnerException;
            }

            return sb.Replace(Environment.NewLine, " ").ToString();
        }
    }
}