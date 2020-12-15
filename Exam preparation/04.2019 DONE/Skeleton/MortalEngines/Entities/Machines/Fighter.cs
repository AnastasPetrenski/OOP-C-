using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double AggresiveModeAttackPoints = 50;
        private const double AggresiveModeDefensivePoints = 25;
        private const double HealthPoints = 200;
        private bool aggresiveMode = true;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints + AggresiveModeAttackPoints, defensePoints - AggresiveModeDefensivePoints, HealthPoints)
        {
            this.AggressiveMode = aggresiveMode;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (!this.AggressiveMode)
            {
                this.AggressiveMode = true;
                this.AttackPoints += AggresiveModeAttackPoints;
                this.DefensePoints -= AggresiveModeDefensivePoints;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= AggresiveModeAttackPoints;
                this.DefensePoints += AggresiveModeDefensivePoints;
            }
        }

        public override string ToString()
        {
            string isActive = this.AggressiveMode ? "ON" : "OFF";

            return base.ToString() + $" *Aggressive: {isActive}";
        }
    }
}
