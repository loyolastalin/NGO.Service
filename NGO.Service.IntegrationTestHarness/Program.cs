using System;
using NGO.Service.IntegrationTestHarness.TestCases;

namespace NGO.Service.IntegrationTestHarness
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Executes the tests
            TestCaseExecuter.Execute();

            // Publish the result
            ConsoleResultPublisher.Publish();

            // Waits for the user input to close the result 
            ConsoleWriter.WriteInfoLine("Press Enter to Exit");
            Console.ReadLine();
        }

        private static void EventsTest()
        {
            EventTest eventTest = new EventTest();
            eventTest.AllEvents_WhenCalled_ShouldReturnEvents();
        }
    }
}
