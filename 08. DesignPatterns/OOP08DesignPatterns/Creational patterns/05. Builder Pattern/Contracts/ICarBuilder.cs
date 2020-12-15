using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._05._Builder_Pattern.Contracts
{
    public interface ICarBuilder
    {
        void BuildTyres(Car car);

        void BuildEngine(Car car);

        void BuildGear(Car car);
    }
}
