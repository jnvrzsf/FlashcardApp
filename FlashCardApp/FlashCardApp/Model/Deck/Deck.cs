using FlashCardApp.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Deck
{
    /* Absztrakt osztály, a paklik közös funkciói vannak itt */
    public abstract class Deck
    {
        protected Dictionary<int, Card> cardsInDictionary = new Dictionary<int, Card>();

        #region Adding and Removing
        /* Paklihoz hozzáad */
        public void Add(Card card)
        {
            if (cardsInDictionary.ContainsKey(card.ID)) return;
            cardsInDictionary.Add(card.ID, card);
        }

        /* Elvesz a pakliból */
        public void Remove(Card card)
        {
            cardsInDictionary.Remove(card.ID);
        }
        public void Clear()
        {
            cardsInDictionary.Clear();
        }
        #endregion

        /* Kilistázás */
        public List<Card> ListAll()
        {
            return cardsInDictionary.Values.ToList();
        }
    }
}
