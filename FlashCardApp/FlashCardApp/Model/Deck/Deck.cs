using FlashCardApp.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Deck
{
    public abstract class Deck
    {
        protected Dictionary<int, Card> cardsInDictionary = new Dictionary<int, Card>();

        public void Add(Card card)
        {
            if (cardsInDictionary.ContainsKey(card.ID)) return;
            cardsInDictionary.Add(card.ID, card);
        }

        public void Remove(Card card)
        {
            cardsInDictionary.Remove(card.ID);
        }

        public List<Card> ListAll()
        {
            return cardsInDictionary.Values.ToList();
        }

    }
}
