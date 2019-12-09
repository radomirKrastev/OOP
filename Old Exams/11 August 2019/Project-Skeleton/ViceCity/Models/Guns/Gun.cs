namespace ViceCity.Models.Guns
{
    using System;
    using Contracts;    

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private int barrelsCount;

        public Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
            this.barrelsCount = this.TotalBullets / this.bulletsPerBarrel;
            this.Barrels = new int[this.barrelsCount];

            for (int i = 0; i < this.barrelsCount; i++)
            {
                this.Barrels[i] = this.bulletsPerBarrel;
            }
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                this.bulletsPerBarrel = value;
            }
        }
        
        public int TotalBullets
        {
            get => this.totalBullets;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.totalBullets > 0;

        protected int[] Barrels { get; set; }

        public abstract int Fire();
    }
}
