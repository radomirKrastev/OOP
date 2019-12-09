namespace ViceCity.Models.Guns
{
    using System.Linq;

    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int BulletsShooting = 1;

        public Pistol(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            this.TotalBullets = this.Barrels.Sum();
            
            for (int i = 0; i < this.Barrels.Length; i++)
            {
                if (this.Barrels[i] > 0)
                {
                    this.Barrels[i] -= BulletsShooting;
                    break;
                }
            }

            this.TotalBullets = this.Barrels.Sum();
            return BulletsShooting;
        }
    }
}
