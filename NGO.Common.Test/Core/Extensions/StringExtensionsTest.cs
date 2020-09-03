using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGO.Common.Core.Extensions;

namespace NGO.Common.Test.Core.Extensions
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void FormatInvariant_Formats_String_In_Specified_Format()
        {
            // Arrange
            string format = "{0}.{1}";
            string param1 = "Test1";
            string param2 = "Test2";

            // Act
            string actual = format.FormatInvariant(param1, param2);

            // Assert
            string expected = string.Format(CultureInfo.InvariantCulture, format, param1, param2);
            Assert.AreEqual<string>(expected, actual, "FormatInvariant should return string in specified format");
        }
    }
}
