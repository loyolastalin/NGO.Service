using System;

namespace NGO.Common.Logging
{
    /// <summary>
    /// This interface defines set of methods for log an entry
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs <paramref name="exception"/> as an error
        /// </summary>
        /// <param name="exception"></param>
        void LogException(Exception exception);

        /// <summary>
        /// Logs <paramref name="exception"/> as a warning
        /// </summary>
        /// <param name="exception">An instance of exception which occurred.</param>
        void LogWarning(Exception exception);

        /// <summary>
        /// Logs <paramref name="message"/> as a warning
        /// </summary>
        /// <param name="message">A description of the log message as string.</param>
        void LogWarning(string message);

        /// <summary>
        /// Logs <paramref name="message"/> as information
        /// </summary>
        /// <param name="message">A description of the log message as string.</param>
        void LogInfo(string message);

        /// <summary>
        /// Logs <paramref name="message"/> as verbose (debug)
        /// </summary>
        /// <param name="message">A description of the log message as string.</param>
        void LogVerbose(string message);
    }
}
