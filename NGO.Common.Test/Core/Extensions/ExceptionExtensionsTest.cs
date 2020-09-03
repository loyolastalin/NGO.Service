using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGO.Common.Core.Extensions;

namespace NGO.Common.Test.Core.Extensions
{
    [TestClass]
    public class ExceptionExtensionsTest
    {
        [TestMethod]
        public void ToLoggableString_WhenCalledWithSingleException_CreateCorrectString()
        {
            // Arrange
            var expectedMessage = "This is test message.";
            var exception = new Exception(expectedMessage);

            // Act
            var actualMessage = exception.ToLoggableString();

            // Assert
            Assert.AreEqual(actualMessage.Contains(expectedMessage), true);
        }

        [TestMethod]
        public void ToLoggableString_WhenCalledWithEmptyMessage_CreateCorrectString()
        {
            // Arrange
            var expectedMessage = string.Empty;
            var exception = new Exception(expectedMessage);

            // Act
            var actualMessage = exception.ToLoggableString();

            // Assert
            Assert.AreEqual(actualMessage.Trim(), exception.GetType().ToString());
        }

        [TestMethod]
        public void ToLoggableString_WhenCalledWithStackTrace_CreateCorrectString()
        {
            // Arrange
            DivideByZeroException originalException = null;
            try
            {
                throw new DivideByZeroException();
            }
            catch (DivideByZeroException exception)
            {
                originalException = exception;
            }

            // Act
            var actualMessage = originalException.ToLoggableString();

            // Assert
            Assert.AreEqual(actualMessage.Contains(GetType().ToString()), true);
        }
    }
}
