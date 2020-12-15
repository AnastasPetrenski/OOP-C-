using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BulletsPerBarrelCapacity = 10;
        private const int TotalBulletsCount = 100;


        public Pistol(string name) 
            : base(name, BulletsPerBarrelCapacity, TotalBulletsCount)
        {
        }

        public override bool CanFire => this.BulletsPerBarrel > 0;

        public override int Fire()
        {
            if (BulletsPerBarrel - 1 > 0)
            {
                BulletsPerBarrel -= 1;
                return 1;
            }
            else if (TotalBullets >= 10 && BulletsPerBarrel - 1 == 0)
            {
                TotalBullets -= 10;
                BulletsPerBarrel = 10;
                return 1;
            }
            else
            {
                if (BulletsPerBarrel - 1 == 0)
                {
                    BulletsPerBarrel = 0;
                    return 1;
                }

                return 0;
            }
        }
    }
}
