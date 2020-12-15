using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<IPlayer> players;
        private Queue<IGun> guns;
        private IPlayer mainPlayer;
        private INeighbourhood neighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.mainPlayer = new MainPlayer();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = type switch
            {
                "Pistol" => new Pistol(name),
                "Rifle" => new Rifle(name),
                _ => null
            };

            if (gun == null)
            {
                return "Invalid gun type!";
            }

            guns.Enqueue(gun);

            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            

            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                var gun = guns.Dequeue();
                this.mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var player = players.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return $"Civil player with that name doesn't exists!";
            }

            var gunCivil = guns.Dequeue();
            player.GunRepository.Add(gunCivil);

            return $"Successfully added {gunCivil.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);

            players.Add(player);

            return $"Successfully added civil player: {player.Name}!";
        }

        public string Fight()
        {
            this.neighbourhood.Action(mainPlayer, players);
            if (mainPlayer.LifePoints == 100 && players.All(p => p.LifePoints == 50))
            {
                return "Everything is okay!";
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine($"A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {players.Where(p => p.IsAlive == false).Count()} players!");
                sb.AppendLine($"Left Civil Players: {players.Where(p => p.IsAlive == true).Count()}!");

                return sb.ToString().TrimEnd();
            }

        }
    }
}
