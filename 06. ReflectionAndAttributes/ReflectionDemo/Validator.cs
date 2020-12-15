using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class Validator
    {
        public static bool Validate(Person person)
        {
            var atribute = person.GetType().GetProperty("Age", BindingFlags.Public | BindingFlags.Instance);
            var attribute = person.GetType().GetProperty("Age").GetValue(person);
            var allAtributes = person.GetType().GetProperties();
            foreach (var item in allAtributes)
            {
                var rangeAttributes = item.GetCustomAttributes(typeof(RangeAttribute), true);
                
                var currentPropertyValue = item.GetValue(person);
                foreach (RangeAttribute rangeAttr in rangeAttributes)
                {
                    var ssss = rangeAttr.Max;
                    var isValid = rangeAttr.IsValid((int)currentPropertyValue);

                    if (isValid)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
