using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts;
using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Models;
using System;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Factories
{
    public class AfricaFactory : AnimalFactory
    {
        public override IAnimal GetCarnivor()
        {
            return new Lion();
        }
    }
}
