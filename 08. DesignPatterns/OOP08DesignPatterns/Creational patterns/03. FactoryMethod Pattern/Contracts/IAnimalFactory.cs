using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts
{
    public interface IAnimalFactory
    {
        public IAnimal GetCarnivor();
    }
}
