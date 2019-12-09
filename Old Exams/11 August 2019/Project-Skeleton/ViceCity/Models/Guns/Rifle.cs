namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BarrelCapacity = InitialBulletsPerBarrel;
        private const int BulletsShooting = 5;

        public Rifle(string name)
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

            var bulletsShot = 0;

            if(this.BulletsPerBarrel < BulletsShooting)
            {
                bulletsShot = this.BulletsPerBarrel;
                this.BulletsPerBarrel = 0;                 
            }
            else
            {
                bulletsShot = BulletsShooting;
                this.BulletsPerBarrel -= BulletsShooting;
            }
            
            return bulletsShot;
        }
    }
}
