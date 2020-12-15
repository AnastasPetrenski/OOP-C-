using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_PARTICIPANTS = 3;
        private IRepository<ICar> carRepository;
        private IRepository<IDriver> driverRepository;
        private IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var car = this.carRepository.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var driver = this.driverRepository.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return String.Format(OutputMessages.DriverAdded, driverName, raceName);

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var car = this.carRepository.GetByName(model);
            if (car != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }

            ICar carModel = type switch
            {
                "Muscle" => new MuscleCar(model, horsePower),
                "Sports" => new SportsCar(model, horsePower),
            };

            this.carRepository.Add(carModel);

            return String.Format(OutputMessages.CarCreated, carModel.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            var driver = this.driverRepository.GetByName(driverName);
            if (driver != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }

            var model = new Driver(driverName);

            this.driverRepository.Add(model);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.raceRepository.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            var model = new Race(name, laps);

            this.raceRepository.Add(model);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MIN_PARTICIPANTS)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));
            }

            var winners = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            var sb = new StringBuilder();

            int counter = 1;
            foreach (var driver in winners)
            {
                if (counter == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driver.Name, raceName));
                }
                else if (counter == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driver.Name, raceName));
                }
                else if (counter == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, driver.Name, raceName));
                }
                counter++;

            }

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
