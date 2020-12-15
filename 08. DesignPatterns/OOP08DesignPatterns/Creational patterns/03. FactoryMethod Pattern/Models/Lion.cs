using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Models
{
    public class Lion : IAnimal
    {
        public Lion()
        {
            this.Name = "Lion";
        }

        public string Name { get; }

    }
}