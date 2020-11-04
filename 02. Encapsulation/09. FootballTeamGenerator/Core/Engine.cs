using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly ICollection<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = string.Empty;
            
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commands = command.Split(';');
                    if (commands[0] == "Team")
                    {
                        this.CreateTeam(commands.Skip(1).ToList());
                    }
                    else if (commands[0] == "Add")
                    {
                        this.AddPlayerToTeam(commands.Skip(1).ToList());
                    }
                    else if (commands[0] == "Remove")
                    {
                        this.RemovePlayerTeam(commands[1], commands[2]);
                    }
                    else if (commands[0] == "Rating")
                    {
                        Console.WriteLine(this.GetRating(commands[1])); 
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }   
        }

        private void CreateTeam(IList<string> commands)
        {
            Team team = new Team(commands[0]);
            this.teams.Add(team);
        }

        private void AddPlayerToTeam(IList<string> commands)
        {
            this.ValidateTeamExists(commands[0]);

            Player player = CreatePlayer(commands.Skip(1).ToList());

            this.teams.FirstOrDefault(t => t.Name == commands[0]).AddPlayer(player);
        }

        private Player CreatePlayer(IList<string> stats)
        {
            Player player = new Player(stats[0], stats.Skip(1).ToArray());
            return player;
        }

        private void ValidateTeamExists(string teamName)
        {
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(message: String.Format(GlobalConstants.MissingTeamExcMsg, teamName));
            }
        }

        private void RemovePlayerTeam(string teamName, string playerName)
        {
            this.ValidateTeamExists(teamName);
            this.teams.FirstOrDefault(t => t.Name == teamName).RemovePlayer(teamName, playerName);
        }

        private double GetRating(string teamName)
        {
            var raiting = this.teams.FirstOrDefault(t => t.Name == teamName).Rating;
            return raiting;
        }
    }
}
