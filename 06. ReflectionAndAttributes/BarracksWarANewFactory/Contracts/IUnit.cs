using System;
using System.Collections.Generic;
using System.Text;

namespace BarracksWarANewFactory.Contracts
{
    public interface IUnit
    {
        public int Health { get; set; }
        public int Attack { get; set; }
    }
}
