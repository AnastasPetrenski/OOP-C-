using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double aircondition = 1.4;

        public Bus(double quantity, double consumption, double capacity) : base(quantity, consumption, capacity)
        {
        }

        public override double AirconditionConsumption => aircondition;

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException(message: String.Format(GlobalConstants.NegativeFuelQuantityMsg, fuel));
            }
            else if (fuel > Capacity - FuelQuantity)
            {
                throw new ArgumentException(message: String.Format(GlobalConstants.FuelNoFitingMsg, fuel));
            }

            this.FuelQuantity += fuel;
        }

    }
}
