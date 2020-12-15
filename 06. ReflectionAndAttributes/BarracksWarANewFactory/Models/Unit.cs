using BarracksWarANewFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Models
{
    public abstract class Unit : IUnit
    {
        public int Health { get; set; }
        public int Attack { get; set; }
    }
}
