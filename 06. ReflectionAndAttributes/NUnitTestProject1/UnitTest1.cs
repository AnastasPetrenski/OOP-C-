using NUnit.Framework;
using Stealer;
using System;
using System.Linq;
using System.Reflection;

namespace NUnitTestProject1
{
    public class Tests
    {
        private static Assembly ProjectAssembly = typeof(StartUp).Assembly; 

        [Test]
        public void ValidateTypesExist()
        {
            var typesExist = new[]
            {
                "Hacker",
                "Spy"

            };

            foreach (string typeName in typesExist)
            {
                Assert.That(GetType(typeName), Is.Not.Null, $"{typeName} type doesn't exist!");
            }
            
        }

        private static Type GetType(string name) 
        {
            var type = ProjectAssembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == name);

            return type;
        }
    }
}