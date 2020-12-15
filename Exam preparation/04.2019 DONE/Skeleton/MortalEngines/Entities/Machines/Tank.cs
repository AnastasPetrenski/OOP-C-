using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double HealthPoints = 100;
        private const double DefenseModeAttackPoints = 40;
        private const double DefenceModeDefencePoints = 30;

        private bool defenceMode = true;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints - DefenseModeAttackPoints, defensePoints + DefenceModeDefencePoints, HealthPoints)
        {
            this.DefenseMode = defenceMode;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (!DefenseMode)
            {
                this.DefenseMode = true;
                this.AttackPoints -= DefenseModeAttackPoints;
                this.DefensePoints += DefenceModeDefencePoints;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += DefenseModeAttackPoints;
                this.DefensePoints -= DefenceModeDefencePoints;
            }
        }

        public override string ToString()
        {
            string isActive = this.DefenseMode ? "ON" : "OFF";

            return base.ToString() + $" *Defense: {isActive}";
        }
    }
}
