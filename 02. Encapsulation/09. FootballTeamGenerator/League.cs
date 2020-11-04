using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class League
    {
        private static List<Team> teams = new List<Team>();

        public static void AddTeam(Team team)
        {
            //if (teams.Any(t => t.Name == team.Name))
            //{
            //    throw new ArgumentException("Team already exist!");
            //}

            teams.Add(team);
        }

        public void AddPlayerTeam(string teamName, string[] playerArgs)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(message:String.Format(GlobalConstants.MissingTeamExcMsg, teamName));
            }

            Player player = new Player(playerArgs[0], playerArgs.Skip(1).ToArray());
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            team.AddPlayer(player);
        }

        public void RemovePlayerTeam(string teamName, string playerName)
        {
            var team = teams.FirstOrDefault(t => t.Name == teamName);
            team.RemovePlayer(teamName, playerName);
        }

        public void Rating(string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(message:String.Format(GlobalConstants.MissingTeamExcMsg, teamName));
            }

            var result = teams.FirstOrDefault(t => t.Name == teamName).Rating;
            Console.WriteLine($"{teamName} - {result}"); 
        }
    }
}
