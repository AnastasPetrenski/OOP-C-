using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {

        public override bool IsValid(Person person)
        {
            var curr = person.GetType().GetProperty("FullName");
            var attr = curr.GetCustomAttributes(typeof(MyRequiredAttribute),true);

            if (attr != null)
            {
                return true;
            }

            return false;
        }
    }
}
