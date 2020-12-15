using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = type switch
            {
                "Pistol" => new Pistol(name, bulletsCount),
                "Rifle" => new Rifle(name, bulletsCount),
                _ => throw new ArgumentException(ExceptionMessages.InvalidGunType)
            };

            //if (gun == null)
            //{
            //    //TODO •	"Invalid gun type." - with ".", not "!"
            //}

            this.guns.Add(gun);

            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = type switch
            {
                "Terrorist" => new Terrorist(username, health, armor, gun),
                "CounterTerrorist" => new CounterTerrorist(username, health, armor, gun),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPlayerType)
            };

            this.players.Add(player);

            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            List<IPlayer> allPlayers = new List<IPlayer>(this.players.Models);
            var sb = new StringBuilder();

            foreach (var player in allPlayers.OrderBy(p => p.GetType().Name).ThenByDescending(p => p.Health).ThenBy(p => p.Username))
            {
                sb
                    .AppendLine(player.ToString())
                    .AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            return this.map.Start(this.players.Models.ToList());
        }
    }
}
