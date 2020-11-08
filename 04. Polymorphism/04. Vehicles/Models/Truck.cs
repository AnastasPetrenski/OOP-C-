using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double aircondition = 1.6;
        private const double refuelLeak = 0.95;

        public Truck(double quantity, double consumption) : base(quantity, consumption)
        {
        }

        public override double AirconditionConsumption => aircondition;

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += (fuel * refuelLeak);
        }
    }
}
