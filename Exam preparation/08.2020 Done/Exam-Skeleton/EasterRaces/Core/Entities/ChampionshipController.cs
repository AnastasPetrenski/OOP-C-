using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
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
        private CarRepository carRepository;
        private DriverRepository driverRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var car = this.carRepository.GetAll().FirstOrDefault(c => c.Model == carModel);
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.raceRepository.GetAll().FirstOrDefault(x => x.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var driver = this.driverRepository.GetAll().FirstOrDefault(x => x.Name == driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            var existedCar = this.carRepository.GetByName(model);
            if (existedCar != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);

        }

        public string CreateDriver(string driverName)
        {
            //TODO Change the logic first check repository

            if (this.driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetAll().Any(x => x.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            
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
