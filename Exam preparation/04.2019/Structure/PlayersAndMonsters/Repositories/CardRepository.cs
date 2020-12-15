using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cardsAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            if (cards.Any(p => p.Name == card.Name))
            {
                throw new ArgumentException(String.Format(ConstantMessages.CardNameExist, card.Name));
            }

            cards.Add(card);
        }

        public ICard Find(string username)
        {
            return cards.FirstOrDefault(p => p.Name == username);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            return cards.Remove(card);
        }
    }
}
