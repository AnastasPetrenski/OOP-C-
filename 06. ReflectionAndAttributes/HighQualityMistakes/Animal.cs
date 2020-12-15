using HighQualityMistakes.Constracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighQualityMistakes
{
    public class Animal : IAnimal
    {
        private string name;
        private int age;

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }
    }
}
