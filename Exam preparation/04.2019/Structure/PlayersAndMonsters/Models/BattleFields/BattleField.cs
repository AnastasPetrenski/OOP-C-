using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.Health <= 0 || enemyPlayer.Health <= 0)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            while (true)
            {

                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                    throw new ArgumentException("Player is dead!");
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (attackPlayer.IsDead)
                {
                    break;
                    throw new ArgumentException("Player is dead!");
                }
            }
        }
    }
}
