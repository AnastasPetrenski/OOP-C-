using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class Axe
    {
        private int attackPoints;
        private int durabilityPoints;
        public Axe(int attack, int durability)
        {
            this.attackPoints = attack;
            this.durabilityPoints = durability;
        }

        public int AttackPoints => this.attackPoints;
        public int DurabilityPoints => this.durabilityPoints;

        public void Attack(Dummy target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }
    }
}
