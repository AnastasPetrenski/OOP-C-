namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using cardsAndMonsters.Repositories;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;
        private readonly IBattleField battleField;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = CreatePlayer(type, username);

            playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = CreateCard(type, name);

            cardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var card = cardRepository.Cards.FirstOrDefault(c => c.Name == cardName);

            var user = playerRepository.Players.FirstOrDefault(p => p.Username == username);

            user.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attaker = playerRepository.Players.FirstOrDefault(p => p.Username == attackUser);
            var enemy = playerRepository.Players.FirstOrDefault(p => p.Username == enemyUser);

            battleField.Fight(attaker, enemy);

            return String.Format(ConstantMessages.FightInfo, attaker.Health, enemy.Health);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Cards.Count));
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }

        private ICard CreateCard(string type, string name)
        {
            ICard card = type switch
            {
                "Magic" => new MagicCard(name),
                "Trap" => new TrapCard(name),
                _ => throw new ArgumentException()
            };

            return card;
        }

        private IPlayer CreatePlayer(string type, string username)
        {
            CardRepository cardRepository = new CardRepository();

            IPlayer player = type switch
            {
                "Beginner" => new Beginner(cardRepository, username),
                "Advanced" => new Advanced(cardRepository, username),
                _=> throw new ArgumentException()
            };

            return player;
        }
    }
}
