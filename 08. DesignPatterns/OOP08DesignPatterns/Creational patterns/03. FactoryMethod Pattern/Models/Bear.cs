using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Models
{
    public class Bear : IAnimal
    {
        public Bear()
        {
            this.Name = "Bear";
        }

        public string Name { get; }
    }
}