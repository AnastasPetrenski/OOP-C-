using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            ICollection<IPlayer> terrorists = players.Where(p => p.GetType() == typeof(Terrorist)).ToList();
            ICollection<IPlayer> counterTerrorists = players.Where(p => p.GetType() == typeof(CounterTerrorist)).ToList();

            while (IsTeamAlive(terrorists) && IsTeamAlive(counterTerrorists))
            {
                AttackTeam(terrorists, counterTerrorists);
                AttackTeam(counterTerrorists, terrorists);
            }

            return IsTeamAlive(terrorists) ? "Terrorist wins!" : "Counter Terrorist wins!";
        }

        private bool IsTeamAlive(ICollection<IPlayer> team)
        {
            return team.Any(t => t.IsAlive);
        }

        private void AttackTeam(ICollection<IPlayer> attackers, ICollection<IPlayer> defenders)
        {
            foreach (var attaker in attackers)
            {
                //if (attaker.IsAlive)
                {
                    foreach (var defender in defenders)
                    {
                        if (defender.IsAlive)
                        {
                            var dmg = attaker.Gun.Fire();
                            defender.TakeDamage(dmg);
                        }
                    }
                }
            }
        }
    }
}
