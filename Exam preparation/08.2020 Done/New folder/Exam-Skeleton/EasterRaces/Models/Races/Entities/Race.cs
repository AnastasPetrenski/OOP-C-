using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinLaps = 1;
        private const int MinLength = 5;
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < MinLength)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MinLength));
                }
                name = value;
            }
        }

        public int Laps
        {
            get { return laps; }
            private set
            {
                if (value < MinLaps)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.Car == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.Drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
