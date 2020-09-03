using System;

namespace NGO.Service.IntegrationTestHarness.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TestInstanceAttribute : Attribute
    {
        private int _testCaseSequence;

        public TestInstanceAttribute()
        {
        }

        public TestInstanceAttribute(int number)
        {
            _testCaseSequence = number;
        }
    }
}
