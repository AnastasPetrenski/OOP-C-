using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        
        public Player(string name, string[] stats)
        {
            this.Name = name;
            this.Stats = new Stat(stats);
        }

        public Stat Stats;

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(message:GlobalConstants.InvalidNameExcMsg);
                }

                this.name = value;
            }
        }

        public double Level => this.Stats.Average();
    }
}