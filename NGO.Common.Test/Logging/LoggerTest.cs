using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NGO.Common.Logging;
using NGO.Common.Logging.LogWriters;

namespace Codm.Litebridge.Logging.Test
{
    [TestClass]
    public class LoggerTest
    {
        private static LogInformation _logInformation = null;
        private Mock<ILogWriter> logWriter = new Mock<ILogWriter>(MockBehavior.Strict);
        private ILogger _logger;
        private Func<LogInformation, bool> _handle = (l) =>
        {
            _logInformation = l;
            return true;
        };

        public ILogger Log
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger(logWriter.Object);
                    logWriter.Setup(s => s.WriteLog(It.Is<LogInformation>(h => _handle(h))));
                }

                return _logger;
            }
        }

        [TestMethod]
        public void Current_WhenCalledTwice_ShouldReturnSameInstances()
        {
            // Act
            var loggerInstance1 = Logger.Current;
            var loggerInstance2 = Logger.Current;

            // Assert
            Assert.AreSame(loggerInstance1, loggerInstance2, "Both instances of logger should be same.");
        }

        [TestMethod]
        public void LogException_WithOnlyException_AddsLogEntryOfErrorType()
        {
            // Arrange
            InvalidOperationException invalidOperationException =
                new InvalidOperationException("This operation is not allowed");
         
            // Act
            Log.LogException(invalidOperationException);

            // Assert
            LogEventType eventType = GetEventType(_logInformation.Category);

            Assert.IsNotNull(_logInformation, "The event type should not be empty.");
            Assert.AreEqual<LogEventType>(LogEventType.Error, eventType, "The event type should be error.");
            Assert.IsFalse(string.IsNullOrEmpty(_logInformation.Message), "The messaage should not be empty.");
            Assert.IsTrue(_logInformation.Message.Contains("This operation is not allowed"));
            Assert.IsFalse(string.IsNullOrEmpty(_logInformation.ClassName), "The location should not be empty.");
        }

        [TestMethod]
        public void LogWarning_WithException_AddsLogEntryAsWarning()
        {
            // Arrange

            // Act
            Log.LogWarning(new InvalidOperationException("This operation is not valid."));

            // Assert
            LogEventType eventType = GetEventType(_logInformation.Category);

            Assert.IsNotNull(_logInformation, "The event type should not be empty.");
            Assert.AreEqual<LogEventType>(LogEventType.Warning, eventType, "The event type should be warning.");
        }

        [TestMethod]
        public void LogInfo_WithMessage_AddsLogEntryAsInfo()
        {
            // Act
            Log.LogInfo("A info log message.");

            // Assert
            LogEventType eventType = GetEventType(_logInformation.Category);
            Assert.IsNotNull(eventType, "The event type should not be empty.");
            Assert.AreEqual<LogEventType>(LogEventType.Information, eventType, "The event type should be information.");
        }

        [TestMethod]
        public void LogVerbose_WithMessage_AddsLogEntryAsVerbose()
        {
            // Act
            Log.LogVerbose("A info log message.");

            // Assert
            LogEventType eventType = GetEventType(_logInformation.Category);
            Assert.IsNotNull(eventType, "The event type should not be empty.");
            Assert.AreEqual<LogEventType>(LogEventType.Verbose, eventType, "The event type should be Verbose.");
        }

        private LogEventType GetEventType(string category)
        {
            return (LogEventType)Enum.Parse(typeof(LogEventType), category);
        }
    }
}
