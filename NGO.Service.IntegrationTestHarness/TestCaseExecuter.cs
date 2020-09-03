using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NGO.Service.IntegrationTestHarness.Attributes;
using NGO.Service.IntegrationTestHarness.Model;

namespace NGO.Service.IntegrationTestHarness
{
    internal class TestCaseExecuter
    {
        public static void Execute()
        {
            GetTestClass().ForEach(item => { ExecutecuteMethod(item.Type); });
        }

        private static List<TestClass> GetTestClass()
        {
            var testClasses = from t in Assembly.GetExecutingAssembly().GetTypes()
                          let attributes = t.GetCustomAttributes(typeof(TestInstanceAttribute), true)
                          where attributes != null && attributes.Length > 0
                          select new TestClass { Type = t };
            return testClasses.ToList();
        }

        private static void ExecutecuteMethod(Type typeClass)
        {
            object classInstance = Activator.CreateInstance(typeClass, null);

            foreach (MethodInfo method in typeClass.GetMethods())
            {
                var attribute = method.GetCustomAttributes<TestAttribute>(true);

                if (attribute.FirstOrDefault() != null)
                {
                    method.Invoke(classInstance, null);
                }
            }
        }
    }
}
