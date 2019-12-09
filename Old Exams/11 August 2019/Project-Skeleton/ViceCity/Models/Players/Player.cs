namespace ViceCity.Models.Players
{
    using Contracts;
    using System;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        public Player(string name, int lifePoints)
        {
            this.GunRepository = new GunRepository();
            this.Name = name;
            this.LifePoints = lifePoints;
        }

        public string Name 
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }
        
        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => this.lifePoints;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints - points >= 0)
            {
                this.LifePoints -= points;
            }
            else
            {
                this.LifePoints = 0;
            }
        }
    }
}
