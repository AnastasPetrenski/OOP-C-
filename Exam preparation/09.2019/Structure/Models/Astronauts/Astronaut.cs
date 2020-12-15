using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            }
        }
        public double Oxygen
        {
            get { return oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                oxygen = value;
            }
        }
        public bool CanBreath => this.Oxygen > 0;
        public IBag Bag { get; }

        public virtual void Breath()
        {

            if (this.Oxygen - 10 >= 0)
            {
                this.Oxygen -= 10;
            }
            if (this.Oxygen - 10 < 0)
            {
                this.Oxygen = 0;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");
            var items = Bag.Items.Count > 0 ? string.Join(", ", Bag.Items) : "none";
            sb.Append($"Bag items: " );
            sb.AppendLine(items);

            return sb.ToString();
        }
    }
}
