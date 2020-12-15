using OOP08DesignPatterns.Creational_patterns._06._FluentInterface_Pattern.Contracts;

namespace OOP08DesignPatterns.Creational_patterns._06._FluentInterface_Pattern
{
    public class CarBuilderFluent : ICarBuilderFluent
    {
        public ICarBuilderFluent BuildEngine(CarFluent car)
        {
            car.Engine = "FluentEngine";
            return this;
        }

        public ICarBuilderFluent BuildGear(CarFluent car)
        {
            car.Gear = "FluentGear";
            return this;
        }

        public ICarBuilderFluent BuildTyres(CarFluent car)
        {
            car.Tyres = "FluentTyres";
            return this;
        }
    }
}
