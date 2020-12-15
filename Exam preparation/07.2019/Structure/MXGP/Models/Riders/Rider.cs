using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private IMotorcycle motorcycle;
        private int numberOfWins;
        private bool canParticipate = false;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, 5));
                }
                name = value;
            }
        }

        public IMotorcycle Motorcycle => this.motorcycle;

        public int NumberOfWins => this.numberOfWins;

        public bool CanParticipate => this.canParticipate;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.MotorcycleInvalid));
            }

            this.motorcycle = motorcycle;
            this.canParticipate = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
