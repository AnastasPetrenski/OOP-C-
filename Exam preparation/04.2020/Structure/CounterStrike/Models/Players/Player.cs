using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }
        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }
        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }
        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }
        public bool IsAlive => this.health > 0;

        public void TakeDamage(int points)
        {
            if (this.armor - points >= 0)
            {
                this.armor -= points;
                return;
            }
            else if (this.armor > 0)
            {
                points -= this.armor;
                this.armor = 0;
            }

            this.health -= points;

            if (this.health < 0)
            {
                this.health = 0;
            }
            //int convertedPointsToReduceHealth = 0;

            //if (this.armor > 0)
            //{
            //    this.armor -= points;
            //    if (this.armor < 0)
            //    {
            //        convertedPointsToReduceHealth = Math.Abs(this.armor);
            //        this.armor = 0;
            //    }

            //    if (convertedPointsToReduceHealth > 0)
            //    {
            //        this.health -= convertedPointsToReduceHealth;
            //    }
            //}
            //else
            //{
            //    this.health -= points;
            //}
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armor: {this.Armor}")
                .AppendLine($"--Gun: {this.gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}