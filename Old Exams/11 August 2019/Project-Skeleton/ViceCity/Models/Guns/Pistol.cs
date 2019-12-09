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
                if (this.TotalBullets >= BarrelCapacity - this.BulletsPerBarrel)
                {
                    this.BulletsPerBarrel += BarrelCapacity - this.BulletsPerBarrel;
                    this.TotalBullets -= BarrelCapacity - this.BulletsPerBarrel;
                }
                else
                {
                    this.BulletsPerBarrel += this.TotalBullets;
                    this.TotalBullets = 0;
                }
            }

            this.BulletsPerBarrel -= BulletsShooting;
            return BulletsShooting;
        }
    }
}
