using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double aircondition = 0.9;

        public Car(double quantity, double consumption) : base(quantity, consumption)
        {
        }

        public override double AirconditionConsumption => aircondition;

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
    }
}
