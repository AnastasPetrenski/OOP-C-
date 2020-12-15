namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int StrikedBullets = 10;

        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
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
                int leftBullets = this.BulletsCount;
                this.BulletsCount = 0;
                return leftBullets;
            }
        }
    }
}
