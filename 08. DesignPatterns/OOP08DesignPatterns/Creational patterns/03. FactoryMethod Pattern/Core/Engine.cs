using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Contracts;
using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Factories;
using OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._03._FactoryMethod_Pattern.Core
{
    public class Engine
    {
        public void Run()
        {
            string factoryType = Console.ReadLine();
            IAnimalFactory factory = factoryType switch
            {
                "Africa" => new AfricaFactory(),
                "Europe" => new EuropeFactory(),
                _=> null
            };

            var animal = factory.GetCarnivor();

        }
    }
}
