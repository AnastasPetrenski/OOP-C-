using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                while (gun.CanFire && civilPlayers.Any(c => c.IsAlive))
                {
                    var civil = civilPlayers.FirstOrDefault(c => c.IsAlive);

                    while (civil.IsAlive && gun.CanFire)
                    {
                        civil.TakeLifePoints(gun.Fire());
                    }

                }
            }

            while (true)
            {
                IPlayer player = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (player == null)
                {
                    break;
                }

                IGun gun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }

    }
}

