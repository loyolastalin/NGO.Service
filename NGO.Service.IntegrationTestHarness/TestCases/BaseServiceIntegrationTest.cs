using System;
using System.Net;
using System.Text;

namespace NGO.Service.IntegrationTestHarness.TestCases
{
    internal class BaseServiceIntegrationTest
    {
        protected static readonly string Unknown_Exception_Message = "Test Failed for {0}";

        protected void AddResult(Tuple<bool, string> result, string testCaseId, string methodName)
        {
            TestResult testResult = default(TestResult);

            if (result != null)
            {
                if (result.Item1)
                {
                    testResult = new TestResult(testCaseId, methodName, result.Item2, ResultStatus.Pass);
                }
                else
                {
                    testResult = new TestResult(testCaseId, methodName, result.Item2, ResultStatus.Fail);
                }
            }

            IntegrationTestContext.Current.Add(testResult);
        }

        protected string GetInput(string header, params string[] items)
        {
            var data = new StringBuilder();
            data.AppendFormat("<{0}>", header);
            foreach (var item in items)
            {
                data.Append(item);
            }

            data.AppendFormat("</{0}>", header);

            return data.ToString();
        }

        protected string GetErrorMessage(WebException webException)
        {
            var errorMessage = string.Empty;

            if (webException.Response != null)
            {
                try
                {
                    errorMessage = ((HttpWebResponse)webException.Response).StatusCode.ToString();
                }
                catch (Exception exception)
                {
                    errorMessage = exception.ToString();
                }
            }

            return errorMessage;
        }
    }
}
