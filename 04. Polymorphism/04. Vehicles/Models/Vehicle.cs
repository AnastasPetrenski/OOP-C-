using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        public Vehicle(double quantity, double consumption)
        {
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public abstract double AirconditionConsumption { get; }

        public string Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + AirconditionConsumption) * distance;
            if (FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
        public abstract void Refuel(double fuel);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }

    }
}
