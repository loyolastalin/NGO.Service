using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NGO.Common.Logging;

namespace NGO.Common.Test.Logging
{
    /// <summary>
    /// Unit test class for Activity class.
    /// </summary>
    [TestClass]
    public class ActivityTest
    {
        [TestMethod]
        public void ActivityId_RequestedTwiceFromSameThread_ReturnsSame()
        {
            var dictionary = new Dictionary<object, object>();
            Activity.HttpContextItemsGetter = () => dictionary;

            Assert.AreEqual(Activity.ActivityId, Activity.ActivityId);
        }

        [TestMethod]
        public void ActivityId_RequestedTwiceFromDifferentThread_ReturnsDifferent()
        {
            var dictionary1 = new Dictionary<object, object>();
            var dictionary2 = new Dictionary<object, object>();

            Activity.HttpContextItemsGetter = () => dictionary1;
            var activitId1 = Activity.ActivityId;

            Activity.HttpContextItemsGetter = () => dictionary2;
            var activityId2 = Activity.ActivityId;

            Assert.AreNotEqual(activitId1, activityId2);
        }
    }
}
