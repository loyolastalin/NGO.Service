namespace NGO.Common.Logging.LogWriters
{
    /// <summary>
    /// Specification for the log writer.
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Writes the log message for the given tracing level.
        /// </summary>
        /// <param name="logInformation"></param>
        void WriteLog(LogInformation logInformation);   
    }
}
