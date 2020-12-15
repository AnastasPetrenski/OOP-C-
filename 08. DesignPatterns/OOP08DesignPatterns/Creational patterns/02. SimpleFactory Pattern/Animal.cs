using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns.SimpleFactory_Pattern
{
    public abstract class Animal : IAnimal
    {
        private string name;

        public Animal(string name)
        {
            this.Name = name;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid type!"); 
                }
                name = value;
            }
        }
    }
}
