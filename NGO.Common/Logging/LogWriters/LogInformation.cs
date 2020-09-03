using System;

namespace NGO.Common.Logging.LogWriters
{
    /// <summary>
    /// Holds log information, which would be stored in the common data repository. 
    /// </summary>
    public class LogInformation
    {
        /// <summary>
        /// Gets/Sets an activity identification of the log
        /// </summary>
        public string ActivityId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets class name of the log
        /// </summary>
        public string ClassName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the message of the log
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the trace level of the log
        /// </summary>
        public string Category
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the logged date and time of the log
        /// </summary>
        public long SourceID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the SourceType
        /// </summary>
        public string SourceType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets/Sets the logged date and time of the log
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
    }
}
