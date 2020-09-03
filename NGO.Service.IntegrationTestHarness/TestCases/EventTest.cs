using System;
using System.Collections.Generic;
using NGO.Service.IntegrationTestHarness.Attributes;
using NGO.Service.IntegrationTestHarness.Model;

namespace NGO.Service.IntegrationTestHarness.TestCases
{
    [TestInstance]
    internal class EventTest : BaseServiceIntegrationTest
    {
        private static readonly string Successful_Message = "Successfully get the events.";
        private static readonly string Error_Message = "Error occurred.";

        [Test]
        public void AllEvents_WhenCalled_ShouldReturnEvents()
        {
            int expectedresult;
            try
            {
                var responses = RestServiceClient.GetFeeds<List<Event>>(
                    "http://localhost:15416/Events/Allevents", string.Empty);

                expectedresult = responses.Result.Count;
            }
            catch (Exception)
            {
                expectedresult = 0;
            }

            // TODO: Get the value from the database coout and match 
            var resultMessage = expectedresult > 0 ? Successful_Message : Error_Message;

            AddResult(
                new Tuple<bool, string>(expectedresult > 0, resultMessage),
                "ADD001_101",
                "AllEvents_WhenCalled_ShouldReturnEvents");
        }
    }
}
