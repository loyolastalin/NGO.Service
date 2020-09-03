using System;
using System.Collections.Generic;
using System.Linq;

namespace NGO.Service.IntegrationTestHarness
{
    public class IntegrationTestContext
    {
        private static readonly IntegrationTestContext Instance = new IntegrationTestContext();
        private readonly IList<TestResult> _results;

        private IntegrationTestContext()
        {
            _results = new List<TestResult>();
        }

        public static IntegrationTestContext Current
        {
            get
            {
                return Instance;
            }
        }

        public IList<TestResult> TestResults
        {
            get { return _results; }
        }

        public void Add(TestResult testResult)
        {
            var testItem = _results.Where((t) => t.Id.Equals(testResult.Id, StringComparison.OrdinalIgnoreCase));

            if (testItem.FirstOrDefault() != null)
            {
                _results.Remove(testItem.FirstOrDefault());
            }

            _results.Add(testResult);
        }
    }
}
