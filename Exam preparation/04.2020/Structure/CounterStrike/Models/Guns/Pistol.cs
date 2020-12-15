namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int StrikedBullets = 1;

        public Pistol(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount - StrikedBullets >= 0)
            {
                this.BulletsCount -= StrikedBullets;
                return StrikedBullets;
            }
            else
            {
                return 0;
            }
        }
    }
}
