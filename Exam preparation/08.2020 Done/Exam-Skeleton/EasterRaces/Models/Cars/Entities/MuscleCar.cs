namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Cubic_Centimeters = 5000;
        private const int MIN_HORSE = 400;
        private const int MAX_HORSE = 600;

        public MuscleCar(string model, int horsePower) : base(model, horsePower)
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
