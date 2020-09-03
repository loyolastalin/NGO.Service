namespace NGO.Service.IntegrationTestHarness
{
    public sealed class TestResult
    {
        private readonly string _testId;
        private readonly string _methodName;
        private readonly ResultStatus _resultStatus;
        private readonly string _description;

        public TestResult(string id, string methodName, string description, ResultStatus resultStatus)
        {
            _testId = id;
            _methodName = methodName;
            _resultStatus = resultStatus;
            _description = description;
        }

        public string Id 
        { 
            get { return _testId; } 
        }

        public string MethodName 
        {
            get { return _methodName; } 
        }

        public ResultStatus Status 
        { 
            get { return _resultStatus; } 
        }

        public string Description 
        {
            get { return _description; } 
        }
    }  
}
