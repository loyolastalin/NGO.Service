using System;
using System.Runtime.Serialization;

namespace NGO.Common.Configuration
{
    /// <summary>
    ///  This class is derived from System.Exception class.
    ///  Represents an errors that is occurred during application execution.
    /// </summary>
    [Serializable]
    public class ConfigurationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ConfigurationException class
        /// </summary>
        public ConfigurationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigurationException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error as a string.</param>
        public ConfigurationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigurationException class with a specified 
        /// error message and a reference to the inner exception that is the cause of the exception.
        /// </summary>
        /// <param name="message">The message that describes the error as a string.</param>
        /// <param name="exception">inner exception<see cref="T:System.Diagnostics.TraceLevel"/></param>
        public ConfigurationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigurationException class with serialized data
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination</param>
        protected ConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}