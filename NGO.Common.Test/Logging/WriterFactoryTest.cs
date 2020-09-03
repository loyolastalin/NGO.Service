using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGO.Common.Logging;
using NGO.Common.Logging.LogWriters;

namespace NGO.Common.Test.Logging
{
    [TestClass]
    public class WriterFactoryTest
    {
        [TestMethod]
        public void CreateLogWriter_WithDatabaseType_ReturnDatabaseLogWriter()
        {
            // Arrange
            WriterType writerType = WriterType.Database;

            // Act
            ILogWriter expectedWriter = WriterFactory.CreateLogWriter(writerType);

            // Assert
            Assert.IsNotNull(expectedWriter, "Database writer instance should not be null.");
        }

        [TestMethod]
        public void CreateLogWriter_WithDefaultType_ReturnDatabaseLogWriter()
        {
            // Arrange
            WriterType writerType = WriterType.Everviewer;
            
            // Act
            ILogWriter expectedWriter = WriterFactory.CreateLogWriter(writerType);

            // Assert
            Assert.IsNotNull(expectedWriter, "Default LogWritter instance should not be null.");
        }
    }
}
