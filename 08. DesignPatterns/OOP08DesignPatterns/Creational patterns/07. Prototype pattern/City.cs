using System;

namespace OOP08DesignPatterns.Creational_patterns._07._Prototype_pattern
{
    [Serializable]
    public class City : ICloneable
    {
        public City(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public object Clone()
        {
            return new City(Name = Name); 
        }
    }
}