using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeedRefactoring
{
    public class SportCar : Car
    {
        private double defaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = defaultFuelConsumption;
        }

    }
}
