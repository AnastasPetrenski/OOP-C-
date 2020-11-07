using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, string age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }
        public string Name { get; private set; }

        public string Country { get; private set; }

        public string Age { get; private set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name} ";
        }

        string IPerson.GetName()
        {
            return Name;
        }
    }
}
