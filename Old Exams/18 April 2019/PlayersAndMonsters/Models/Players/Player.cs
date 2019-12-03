﻿namespace PlayersAndMonsters.Models.Players
{
    using System;
    using Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username 
        {
            get => this.username;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                this.username = value;
            }
        }
        
        public int Health 
        {
            get => this.health;

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                this.health = value;
            }                
        }

        public bool IsDead => this.Health == 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            this.Health -= damagePoints;

            if (this.Health < 0)
            {
                this.Health = 0;
            }
        }
    }
}
