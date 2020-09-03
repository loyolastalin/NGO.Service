using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NGO.Common.Configuration;

namespace NGO.Common.Test.Configuration
{
    [TestClass]
    public class ConfigurationManagerTest
    {
        /// <summary>
        /// Tests that the constructor, given a null repository throws an ArgumentNullException
        /// </summary>
        [TestMethod]
        public void Constructor_NullRepository_ThrowsException()
        {
            try
            {
                ConfigurationManager manager = new ConfigurationManager(null);
                Assert.Fail("Should have thrown exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("ConfigurationRepository cannot be null", ex.ParamName);
            }
        }

        /// <summary>
        /// Tests that GetValue with string correctly retrieves the single value from the repository
        /// </summary>
        [TestMethod]
        public void GetValueString_ValueFound_ReturnsValue()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "likes cats" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            string value = manager.GetValue<string>("key");
            Assert.AreEqual("likes cats", value);

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValue with int correctly retrieves the single value from the repository where
        /// the value can be successfully converted.
        /// </summary>
        [TestMethod]
        public void GetValueInt_ValueFound_ReturnsValue()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "123" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            int value = manager.GetValue<int>("key");
            Assert.AreEqual(123, value);

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValue with int where the actual value is not compatible throws a suitable
        /// exception.
        /// </summary>
        [TestMethod]
        public void GetValueInt_ValueNotCompatible_ThrowsException()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "likes cats" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            try
            {
                manager.GetValue<int>("key");
                Assert.Fail("Should have thrown exception");
            }
            catch (FormatException)
            {
            }

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValue with string throws an exception if the key is not found
        /// </summary>
        [TestMethod]
        public void GetValueString_ValueNotFound_ThrowsException()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Throws(new KeyNotFoundException("AAA"));

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            try
            {
                string value = manager.GetValue<string>("key");
                Assert.Fail("Should have thrown exception");
            }
            catch (KeyNotFoundException)
            {
            }

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValue with string throws an exception if multiple values are found
        /// </summary>
        [TestMethod]
        public void GetValueString_TwoManyValues_ThrowsException()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "likes cats", "and dogs" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            try
            {
                string value = manager.GetValue<string>("key");
                Assert.Fail("Should have thrown exception");
            }
            catch (ConfigurationException)
            {
            }

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValue with string throws an exception if the key is valid, but has no
        /// values associated. (empty list).
        /// </summary>
        [TestMethod]
        public void GetValueString_NoValues_ThrowsException()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            try
            {
                string value = manager.GetValue<string>("key");
                Assert.Fail("Should have thrown exception");
            }
            catch (ConfigurationException)
            {
            }

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValues with string correctly retrieves the multiple values from the repository
        /// </summary>
        [TestMethod]
        public void GetValuesString_ValuesFound_ReturnsValues()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "likes cats", "and dogs" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            var values = manager.GetValues<string>("key");
            Assert.AreEqual(2, values.Count());
            Assert.AreEqual("likes cats", values.ElementAt(0));
            Assert.AreEqual("and dogs", values.ElementAt(1));

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValues with int correctly retrieves the multiple values from the repository, converting
        /// to the requested type.
        /// </summary>
        [TestMethod]
        public void GetValuesInt_ValuesFound_ConvertsValues()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "123", "234" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            var values = manager.GetValues<int>("key");
            Assert.AreEqual(2, values.Count());
            Assert.AreEqual(123, values.ElementAt(0));
            Assert.AreEqual(234, values.ElementAt(1));

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValues with int throws an exception if the values are not compatible.
        /// </summary>
        [TestMethod]
        public void GetValuesInt_NotCompatible_ThrowsException()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { "123", "bernard" });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            try
            {
                manager.GetValues<int>("key");
                Assert.Fail("Should have thrown exception");
            }
            catch (FormatException)
            {
            }

            repository.VerifyAll();
        }

        /// <summary>
        /// Tests that GetValues with key not found throws an exception
        /// </summary>
        [TestMethod]
        public void GetValuesString_KeyNotFound_ReturnsValues()
        {
            Mock<IConfigurationRepository> repository = new Mock<IConfigurationRepository>(MockBehavior.Strict);
            repository.Setup(s => s.GetValues("key")).Returns(new string[] { });

            ConfigurationManager manager = new ConfigurationManager(repository.Object);

            try
            {
                manager.GetValues<string>("key");
                Assert.Fail("Should have thrown exception");
            }
            catch (ConfigurationException)
            {
            }

            repository.VerifyAll();
        }
    }
}
