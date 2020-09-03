using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCompany("NGO")]
[assembly: AssemblyProduct("NGOAPP")]
[assembly: AssemblyCopyright("Copyright © NGO 2015")]
[assembly: AssemblyTrademark("")]

// Make it easy to distinguish Debug and Release builds;
// for example, through the file properties window.
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyDescription("Configuration=Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Configuration=Release")] 
#endif

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

[assembly: AssemblyInformationalVersion("1.0.0.0")]
