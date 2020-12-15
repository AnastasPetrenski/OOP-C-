using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Factories
{
    public abstract class AnimalFactory : IAnimalFactory
    {
        public abstract IAnimal GetCarnivor();
    }
}
