namespace ViceCity.Models.Guns
{
    using System.Linq;

    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BulletsShooting = 5;
        
        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            this.TotalBullets = this.Barrels.Sum();
            var barrel = this.Barrels.First(x => x > 0);

            var bulletsShot = 0;

            for (int i = 0; i < this.Barrels.Length; i++)
            {
                if (this.Barrels[i] > 0)
                {
                    if (this.Barrels[i] < BulletsShooting)
                    {
                        bulletsShot = this.Barrels[i];
                        this.Barrels[i] = 0;
                    }
                    else
                    {
                        bulletsShot = BulletsShooting;
                        this.Barrels[i] -= BulletsShooting;
                    }

                    break;
                }
            }

            this.TotalBullets = this.Barrels.Sum();
            return bulletsShot;
        }
    }
}
