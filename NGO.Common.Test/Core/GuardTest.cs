using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGO.Common.Core;

namespace NGO.Common.Test.Core
{
    [TestClass]
    public class GuardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNullOrEmpty_WhenCalledWithNullArgument_ThrowsException()
        {
            Guard.ArgumentNotNullOrEmpty(null, "argument");
        }

        [TestMethod]
        public void ArgumentNotNullOrEmpty_WhenCalledWithNonNullArgument_DoesNotThrowException()
        {
            // Arrange
            var argument = new object();

            // Act
            Guard.ArgumentNotNullOrEmpty(argument, "argument");
        }

        [TestMethod]
        public void ArgumentNotNullOrEmpty_WhenCalledWithNonNullString_DoesNotThrowException()
        {
            // Arrange
            var argument = "test string";

            // Act
            Guard.ArgumentNotNullOrEmpty(argument, "argument");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNullOrEmpty_WhenCalledWithEmptyString_ThrowsException()
        {
            Guard.ArgumentNotNullOrEmpty(string.Empty, "argument");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNullOrEmpty_WhenCalledWithWhitespaceString_ThrowsException()
        {
            Guard.ArgumentNotNullOrEmpty(" ", "argument");
        }

        [TestMethod]
        public void ArgumentNotNull_WhenCalledWithNotNullArgument_DoesNotThrowException()
        {
            // act
            Guard.ArgumentNotNull(string.Empty, "arg1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNotNull_WhenCalledWithNullArgument_ThrowsException()
        {
            Guard.ArgumentNotNull(null, "argument");
        }
    }
}
