using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints) 
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NullMachineName);
                }

                this.name = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.NullPilot);
                }

                this.pilot = value;
            }
        }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullTarget);
            }

            //TODO MathAbs
            target.HealthPoints -= Math.Max(0, this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            string result = this.Targets.Count > 0 ? string.Join(",", this.Targets) : "None";
            var sb = new StringBuilder();
            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints}")
                .AppendLine($" *Attack: {this.AttackPoints}")
                .AppendLine($" *Defense: {this.DefensePoints}")
                .AppendLine($" *Targets: " + result);

            return sb.ToString().TrimEnd();
        }
    }
}
