using System;
using NGO.Service.IntegrationTestHarness.Attributes;

namespace NGO.Service.IntegrationTestHarness.TestCases
{
    [TestInstance]
    internal class UserRegistrationTest : BaseServiceIntegrationTest
    {
        private static readonly string Successful_Message = "Successfully get the events.";
        private static readonly string Error_Message = "Error occurred.";

        [Test]
        public void Create_WhenCalled_ShouldAddEntryInDatabase()
        {
            var result = true;
            var resultMessage = result ? Successful_Message : Error_Message;

            AddResult(new Tuple<bool, string>(result, resultMessage), "ADD002_101", "Create_WhenCalled_ShouldAddEntryInDatabase");
        }
    }
}
