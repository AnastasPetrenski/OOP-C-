using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo
{
    public class Person
    {
        [Range(18,100)]
        public int Age { get; set; }
    }
}
