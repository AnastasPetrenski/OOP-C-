using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();


            //try
            //{
              

            //    string model = "BMW7";
            //    int horsePower = 300;

            //    Car car = new SportsCar(model, horsePower);

            //    System.Console.WriteLine(car.HorsePower);
            //    System.Console.WriteLine(car.CubicCentimeters);
            //    System.Console.WriteLine(car.CalculateRacePoints(1));
            //}
            //catch (System.Exception e)
            //{
            //    System.Console.WriteLine(e.Message);
            //}

            //Car newcar = new MuscleCar("asd22", 500);
            //System.Console.WriteLine(newcar.HorsePower);
            //System.Console.WriteLine(newcar.CubicCentimeters);
            //System.Console.WriteLine(newcar.CalculateRacePoints(1));

            //IDriver driver = new Driver("Nasko");
            //IRace race = new Race("Dytona", 100);

            //System.Console.WriteLine(driver.CanParticipate);
            //driver.AddCar(newcar);

            //race.AddDriver(driver);
        }
    }
}
