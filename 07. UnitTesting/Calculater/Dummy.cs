using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class Dummy
    {
        private int attack;
        private int health;
        private const int EXPERIENCE = 30;

        public Dummy(int attack, int health)
        {
            this.attack = attack;
            this.health = health;
        }

        public int Health => this.health;
        public int Experience => EXPERIENCE;

        public void TakeAttack(int attack)
        {
            if (IsDead())
            {
                throw new InvalidOperationException("Dummy is dead.");
            }

            this.health -= attack;

        }

        public int GiveExperience()
        {
            if (!IsDead())
            {
                throw new InvalidOperationException("Dummy is not dead.");
            }

            return this.Experience;
        }

        public bool IsDead()
        {
            return this.health <= 0;
        }
    }
}
