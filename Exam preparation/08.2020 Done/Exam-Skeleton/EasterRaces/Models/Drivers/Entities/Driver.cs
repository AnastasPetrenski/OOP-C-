namespace EasterRaces.Models.Drivers.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public class Driver : IDriver
    {
        private const int MIN_NAME_LENGTH = 5;
        private string name;
        private bool canParticipate = false;

        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = canParticipate;
        }

        public string Name 
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < MIN_NAME_LENGTH)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_NAME_LENGTH));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => this.canParticipate;
            private set
            {
                if (this.Car != null)
                {
                    this.canParticipate = true;
                }

                this.canParticipate = false;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.CarInvalid));
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
