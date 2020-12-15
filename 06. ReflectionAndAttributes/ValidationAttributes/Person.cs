using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Age = age;
            this.FullName = name;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }
    }
}
