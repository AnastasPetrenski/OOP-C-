﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialOxygen = 70;

        public Biologist(string name) 
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 >= 0)
            {
                this.Oxygen -= 5;
            }
            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
