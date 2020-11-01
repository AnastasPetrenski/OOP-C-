using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeedRefactoring
{
    public class RaceMotorcycle : Motorcycle
    {
        private double defaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = defaultFuelConsumption;
        }

        
    }
}
