// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "NGO.Common.Logging.Logger.#.ctor(NGO.Common.Logging.LogWriters.ILogWriter)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "NGO.Common.Logging.Logger.#WriteLog(NGO.Common.Logging.LogEventType,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "logWriterType", Scope = "member", Target = "NGO.Common.Logging.WriterFactory.#CreateLogWriter(NGO.Common.Logging.WriterType)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "eventType", Scope = "member", Target = "NGO.Common.Logging.Logger.#IsLogRequired(NGO.Common.Logging.LogEventType)")]
