using System;

namespace NeedForSpeedRefactoring
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vehicle");
            Vehicle vehicle = new Vehicle(115, 100.00);
            var consumption = vehicle.FuelConsumption;
            Console.WriteLine(consumption);
            vehicle.Drive(100);
            Console.WriteLine(vehicle.Fuel);

            Console.WriteLine("Race motorcycle");
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(500, 100.00);
            consumption = raceMotorcycle.FuelConsumption;
            Console.WriteLine(consumption);
            raceMotorcycle.Drive(100);
            Console.WriteLine(raceMotorcycle.Fuel);

            Console.WriteLine("Cross motorcycleq");
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(500, 100.00);
            consumption = crossMotorcycle.FuelConsumption;
            Console.WriteLine(consumption);
            crossMotorcycle.Drive(100);
            Console.WriteLine(crossMotorcycle.Fuel);

            Console.WriteLine("Family Car");
            FamilyCar familyCar = new FamilyCar(500, 100.00);
            consumption = familyCar.FuelConsumption;
            Console.WriteLine(consumption);
            familyCar.Drive(100);
            Console.WriteLine(familyCar.Fuel);

            Console.WriteLine("Sport Car");
            SportCar sportCar = new SportCar(500, 100.00);
            consumption = sportCar.FuelConsumption;
            Console.WriteLine(consumption);
            sportCar.Drive(100);
            Console.WriteLine(sportCar.Fuel);

            Console.WriteLine("Car");
            Car car = new Car(500, 100.00);
            consumption = car.FuelConsumption;
            Console.WriteLine(consumption);
            car.Drive(100);
            Console.WriteLine(car.Fuel);
        }
    }
}
