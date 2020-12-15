using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Models
{
    public class Swordsman : Unit
    {
        private const int health = 5;
        private const int attack = 25;

        public Swordsman()
        {
            this.Health = health;
            this.Attack = attack;
        }
    }
}
