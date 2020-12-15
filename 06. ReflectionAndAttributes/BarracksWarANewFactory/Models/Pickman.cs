using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Models
{
    public class Pickman : Unit
    {
        private const int health = 30;
        private const int attack = 10;

        public Pickman()
        {
            this.Health = health;
            this.Attack = attack;
        }
    }
}
