using OOP08DesignPatterns.Creational_patterns._05._Builder_Pattern.Contracts;

namespace OOP08DesignPatterns.Creational_patterns._05._Builder_Pattern
{
    public class CarBuilder : ICarBuilder
    {
        public void BuildEngine(Car car)
        {
            car.Engine = "Engine";
        }

        public void BuildGear(Car car)
        {
            car.Gear = "Gear";
        }

        public void BuildTyres(Car car)
        {
            car.Tyres = "Tyres";
        }
    }
}
