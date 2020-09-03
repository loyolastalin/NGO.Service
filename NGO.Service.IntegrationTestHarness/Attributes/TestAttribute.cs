using System;

namespace NGO.Service.IntegrationTestHarness.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        private int _testCaseSequence;

        public TestAttribute()
        {
        }

        public TestAttribute(int number)
        {
            _testCaseSequence = number;
        }
    }
}
