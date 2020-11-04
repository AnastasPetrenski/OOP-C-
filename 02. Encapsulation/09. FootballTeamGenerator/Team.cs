using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        private double rating;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
            League.AddTeam(this);
        }

        public int NumberOfPlayers => players.Count;
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

        public double Rating => Math.Round(this.players.Average(p => p.Level));
        //public double Rating => GetRating();

        //internal double GetRating()
        //{

        //    if (this.players.Count > 0)
        //    {
        //        var totalRating = this.players.Sum(p => p.Level);
        //        var totalPlayers = this.players.Count;
        //        var average = Math.Round(totalRating / totalPlayers);
        //        return average;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string teamName, string playerName)
        {

            if (!players.Any(t => t.Name == playerName))
            {
                throw new ArgumentException(message:String.Format(GlobalConstants.MissingPlayerExcMsg, playerName, teamName));
            }

            players.RemoveAll(p => p.Name == playerName);
        }
    }
}
