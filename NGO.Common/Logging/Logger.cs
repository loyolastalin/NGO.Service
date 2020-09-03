using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using NGO.Common.Core.Extensions;
using NGO.Common.Logging.LogWriters;

namespace NGO.Common.Logging
{
    /// <summary>
    /// Represents to write an entry of log into underlying log writer.
    /// </summary>
    public sealed class Logger : ILogger
    {
        private static readonly Func<DateTime> DefaultDateGetter = () => DateTime.UtcNow;
        private static readonly ILogger _logger = new Logger();
        private static readonly string SourceType = "DATA_SERVICE_PROVIDER";
        private readonly ILogWriter _logWriter;

        internal Logger(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        private Logger()
        {
            _logWriter = WriterFactory.CreateLogWriter(WriterType.Database);
        }

        public static ILogger Current
        {
            get
            {
                return _logger;
            }
        }

        /// <summary>
        /// Adds a log entry as an error for the given exception.
        /// </summary>
        /// <param name="exception">An instance of exception which occurred.</param>
        public void LogException(Exception exception)
        {
            WriteLog(LogEventType.Error, exception.ToLoggableString());
        }

        /// <summary>
        /// Adds a log entry as a warning for the given exception.
        /// </summary>
        /// <param name="exception">An instance of exception which occurred.</param>
        public void LogWarning(Exception exception)
        {
            WriteLog(LogEventType.Warning, exception.ToLoggableString());
        }

        /// <summary>
        /// Adds a log entry as a warning.
        /// </summary>
        /// <param name="message">A warning message string.</param>
        public void LogWarning(string message)
        {
            WriteLog(LogEventType.Warning, message);
        }

        /// <summary>
        /// Adds a log entry as a information.
        /// </summary>
        /// <param name="message">An information message string.</param>
        public void LogInfo(string message)
        {
            WriteLog(LogEventType.Information, message);
        }

        /// <summary>
        /// Adds a log entry as a verbose.
        /// </summary>
        /// <param name="message">A verbose message string.</param>
        public void LogVerbose(string message)
        {
            WriteLog(LogEventType.Verbose, message);
        }

        private void WriteLog(LogEventType eventType, string message)
        {
            if (IsLogRequired(eventType))
            {
                var logInformation = new LogInformation()
                {
                    Message = "Thread Id: {0}, Message: {1}".FormatInvariant(Thread.CurrentThread.ManagedThreadId, message),
                    ClassName = RetrieveClassName(),
                    Category = eventType.ToString(),
                    SourceID = 100, // TODO: Source ID should passed here
                    SourceType = SourceType,
                    ActivityId = Activity.ActivityId,
                    CreatedDateTime = DefaultDateGetter()
                };

                // Any error occurred in the logger, should be suppressed.
                try
                {
                    _logWriter.WriteLog(logInformation);
                }
                catch
                {
                }
            }
        }

        private bool IsLogRequired(LogEventType eventType)
        {
            int logLevel = Configuration.ConfigurationManager.Current.GetValue<int>("LogLevel");
            return (int)eventType != 0 && logLevel >= (int)eventType;
        }

        /// <summary>
        /// Retrieve the location i.e. class name from the stack using reflection
        /// </summary>
        /// <returns>
        /// </returns>
        private string RetrieveClassName()
        {
            var stackTrace = new StackTrace();
            MethodBase stackFrameMethod;
            string typeName = null;
            string assemblyFileVersion = null;
            var frameCount = 0;

            // loop until non-System/Microsoft/Logger (i.e. this) class
            do
            {
                frameCount++;
                var stackFrame = stackTrace.GetFrame(frameCount);
                stackFrameMethod = stackFrame.GetMethod();
                if (stackFrameMethod.ReflectedType == null)
                {
                    continue;
                }

                typeName = stackFrameMethod.ReflectedType.FullName;
                var assemblyFileVersions =
                    (AssemblyFileVersionAttribute[])
                        stackFrameMethod.ReflectedType.Assembly.GetCustomAttributes(
                            typeof(AssemblyFileVersionAttribute), false);
                if (assemblyFileVersions.FirstOrDefault() == null)
                {
                    continue;
                }

                var assemblyFileVersionAttribute = assemblyFileVersions.FirstOrDefault();
                if (assemblyFileVersionAttribute != null)
                {
                    assemblyFileVersion = assemblyFileVersionAttribute.Version;
                }
            } 
            while (
                typeName != null && (typeName.StartsWith("System") ||
                                          typeName.StartsWith("Microsoft") ||
                                          typeName.EndsWith("Logger")));

            return assemblyFileVersion + typeName + " " + stackFrameMethod.Name;
        }
    }
}  
