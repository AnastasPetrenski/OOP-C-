using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BulletsPerBarrelCapacity = 50;
        private const int TotalBulletsCount = 500;


        public Rifle(string name)
            : base(name, BulletsPerBarrelCapacity, TotalBulletsCount)
        {
        }

        public override bool CanFire => this.BulletsPerBarrel >= 5;

        public override int Fire()
        {
            if (BulletsPerBarrel - 5 > 0)
            {
                BulletsPerBarrel -= 5;

                return 5;
            }
            else if (TotalBullets >= 50 && BulletsPerBarrel - 5 == 0)
            {
                TotalBullets -= 50;
                BulletsPerBarrel = 50;
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
