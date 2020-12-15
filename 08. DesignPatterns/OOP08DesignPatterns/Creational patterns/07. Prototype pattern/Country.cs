using System;

namespace OOP08DesignPatterns.Creational_patterns._07._Prototype_pattern
{
    [Serializable]
    public class Country : ICloneable
    {
        public Country(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public object Clone()
        {
            return new Country(Name = Name);
        }
    }
}