using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Cubic_Centimeters = 3000;
        private const int MIN_HORSE = 250;
        private const int MAX_HORSE = 450;

        public SportsCar(string model, int horsePower) : base(model, horsePower)
        {
        }

        protected override int GetMinHorsePower()
        {
            return MIN_HORSE;
        }

        protected override int GetMaxHorsePower()
        {
            return MAX_HORSE;
        }

        public override double CubicCentimeters => Cubic_Centimeters;
    }
}
