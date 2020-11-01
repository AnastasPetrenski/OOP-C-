using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeedRefactoring
{
    public class Car : Vehicle
    {
        private double defaultFuelConsumption = 3;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = defaultFuelConsumption;
        }

    }
}
