using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        {
            get => this.name;
            set => this.name = value; 
        }
        public virtual int Age 
        {
            get 
            {
                return this.age;
            } 
            set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Can not be negative number");
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
