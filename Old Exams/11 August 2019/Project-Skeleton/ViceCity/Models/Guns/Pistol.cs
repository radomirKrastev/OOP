using System.Collections.Generic;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BarrelCapacity = InitialBulletsPerBarrel;
        private const int BulletsShooting = 1;

        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel == 0)
            {
                if (this.Loads >= BarrelCapacity - this.BulletsPerBarrel)
                {
                    this.Loads -= BarrelCapacity - this.BulletsPerBarrel;
                    this.BulletsPerBarrel += BarrelCapacity - this.BulletsPerBarrel;                    
                }
                else
                {
                    this.BulletsPerBarrel += this.Loads;
                    this.Loads = 0;
                }
            }

            this.BulletsPerBarrel -= BulletsShooting;
            this.TotalBullets = this.Loads + this.BulletsPerBarrel;
            return BulletsShooting;
        }
    }
}
