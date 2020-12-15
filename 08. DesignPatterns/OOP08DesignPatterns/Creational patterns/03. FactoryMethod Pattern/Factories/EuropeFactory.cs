using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts;
using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Models;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Factories
{
    public class EuropeFactory : AnimalFactory
    {
        public override IAnimal GetCarnivor()
        {
            return new Bear();
        }
    }
}
