namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;
    using System;

    public abstract class Car : ICar
    {
        private const int MIN_NAME_LENGTH = 4;
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower)
        {
            this.minHorsePower = GetMinHorsePower();
            this.maxHorsePower = GetMaxHorsePower();
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_NAME_LENGTH)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MIN_NAME_LENGTH));
                }

                this.model = value;
            }
        }


        public int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < this.minHorsePower || this.maxHorsePower < value)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public abstract double CubicCentimeters { get; }

        protected virtual int GetMinHorsePower()
        {
            return this.minHorsePower;
        }

        protected virtual int GetMaxHorsePower()
        {
            return this.maxHorsePower;
        }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
