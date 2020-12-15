using System;
using System.Collections.Generic;
using System.Text;

namespace OOP08DesignPatterns.Creational_patterns._06._FluentInterface_Pattern.Contracts
{
    public interface ICarBuilderFluent
    {
        ICarBuilderFluent BuildTyres(CarFluent car);

        ICarBuilderFluent BuildEngine(CarFluent car);

        ICarBuilderFluent BuildGear(CarFluent car);
    }
}
