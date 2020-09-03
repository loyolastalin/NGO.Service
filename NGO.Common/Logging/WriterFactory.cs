using NGO.Common.Logging.LogWriters;

namespace NGO.Common.Logging
{
    /// <summary>
    /// Creates an instance of log writer for specified writer type provided by the caller.
    /// </summary>
    internal static class WriterFactory
    {
        internal static ILogWriter CreateLogWriter(WriterType logWriterType)
        {
            ILogWriter logWriter;
            switch (logWriterType)
            {
                default:
                    logWriter = new DatabaseLogWriter();
                    break;
            }

            return logWriter;
        }
    }
}
