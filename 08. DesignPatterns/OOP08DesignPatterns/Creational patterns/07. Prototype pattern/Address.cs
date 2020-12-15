using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._07._Prototype_pattern
{
    [Serializable]
    public class Address : ICloneable
    {
        public Address(Country country, City city)
        {
            this.Country = country;
            this.City = city;
        }

        public City City { get; set; }

        public Country Country { get; set; }

        public string Street { get; set; }

        public object Clone(object someItem)
        {
            return this.MemberwiseClone();  //<---- return shallow copy
            //same like return new Address() {City = this.City, Country = this.Country, Street = this.Street}
        }

        public object Clone()
        {
            //All classes must have [Serializable] atribute for deep clone
            return DeepClone(this);
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public override string ToString()
        {
            return $"Country - {Country.Name}, City - {City.Name}, Street - {Street}";
        }
    }
}
