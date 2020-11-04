using FootballTeamGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
            //Team team1 = new Team("Arsenal");
            //Team team2 = new Team("ManCity");
            //Player player = new Player("Pesho", new string[] { "10", "10", "10","10", "10" });
            //Player player1 = null;
            //try
            //{
            //    player1 = new Player("Sasho", new string[] { "20", "20", "20", "20", "20" });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            
            //team1.AddPlayer(player);
            //team1.AddPlayer(player1);
            //Console.WriteLine(team1.NumberOfPlayers); 
            //var x = team1.Rating;
            //Console.WriteLine(x);

            //string command = string.Empty;
            //League league = new League();
            //while ((command = Console.ReadLine()) != "END")
            //{
            //    try
            //    {
            //        var commands = command.Split(';');
            //        if (commands[0] == "Team")
            //        {
            //            Team team = new Team(commands[1]);
            //        }
            //        else if (commands[0] == "Add")
            //        {
            //            league.AddPlayerTeam(commands[1], commands.Skip(2).ToArray());
            //        }
            //        else if (commands[0] == "Remove")
            //        {
            //            league.RemovePlayerTeam(commands[1], commands[2]);
            //        }
            //        else if (commands[0] == "Rating")
            //        {
            //            league.Rating(commands[1]);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
                
            //}

        }
    }
}
