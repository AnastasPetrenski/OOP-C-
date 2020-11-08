using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;

        public Vehicle(double quantity, double consumption, double capacity)
        {
            this.Capacity = capacity;
            this.FuelQuantity = quantity;
            this.FuelConsumption = consumption;
        }


        public double Capacity { get; protected set; }
        public double FuelQuantity 
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > Capacity)
                {
                    this.fuelQuantity = default;
                }
                else
                {
                    this.fuelQuantity = value;
                }
                
            }
        }
        public double FuelConsumption { get; protected set; }
        public abstract double AirconditionConsumption { get; }

        public string Drive(double distance, bool isEmpty)
        {
            double fuelNeeded = 0;

            if (isEmpty)
            {
                fuelNeeded = FuelConsumption * distance;
            }
            else
            {
                fuelNeeded = (FuelConsumption + AirconditionConsumption) * distance;
            }
            
            if (FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                return String.Format(GlobalConstants.DrivedDistanceMsg, this.GetType().Name, distance);
            }
            
            return String.Format(GlobalConstants.NeedRefuelingMsg, this.GetType().Name);
        }

        public abstract void Refuel(double fuel);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }

    }
}
