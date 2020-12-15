using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.username = username;
            this.health = health;
        }

        public ICardRepository CardRepository { get; }
        public string Username
        {
            get { return username; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                username = value;
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }
                health = value;
            }
        }
        public bool IsDead => this.health <= 0; 

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (this.health - damagePoints < 0)
            {
                this.health = 0;
            }
            else
            {
                this.health -= damagePoints;
            }
        }
    }
}
