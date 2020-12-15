using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Models
{
    public class Archer : Unit
    {
        private const int health = 10;
        private const int attack = 30;

        public Archer()
        {
            this.Health = health;
            this.Attack = attack;
        }
    }
}
