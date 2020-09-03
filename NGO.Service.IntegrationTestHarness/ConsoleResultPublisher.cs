using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGO.Service.IntegrationTestHarness.Extensions;

namespace NGO.Service.IntegrationTestHarness
{
    internal static class ConsoleResultPublisher
    {
        private static readonly StringBuilder TestResultContent = new StringBuilder();
        
        public static void Publish()
        {
            TestResultContent.AppendLine("Test Results");
            TestResultContent.AppendLine();

            var displayHeader = new string('*', 30);

            ConsoleWriter.WriteInfoLine(string.Empty);
            ConsoleWriter.WriteInfoLine("{0} Summary Report {1}".FormatInvariant(displayHeader, displayHeader));

            IList<TestResult> testResults = (from results in IntegrationTestContext.Current.TestResults
                                             orderby results.Id
                                             select results).ToList();

            foreach (TestResult testResult in testResults)
            {
                var message = "Test ID : {0}  - Result : {1}".FormatInvariant(testResult.Id, testResult.Status.ToString());

                TestResultContent.AppendLine(
                    "Test ID: {0} - Result :{1} - Method Name : {2} - Description: {3}".FormatInvariant(
                    testResult.Id,
                    testResult.Status.ToString(),
                    testResult.MethodName,
                    testResult.Description));

                if (testResult.Status == ResultStatus.Pass)
                {
                    ConsoleWriter.WriteSuccess(message);
                }
                else
                {
                    ConsoleWriter.WriteFailure(message);
                }
            }

            ConsoleWriter.WriteInfoLine(new string('*', 75));
            ConsoleWriter.WriteInfoLine(string.Empty);
        }
    }
}
