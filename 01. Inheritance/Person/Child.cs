using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }

        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value < 16)
                {
                    base.Age = value;
                }
                else
                {
                    throw new ArgumentException("Can not be more than 15");
                }
            }
        }
    }
}
