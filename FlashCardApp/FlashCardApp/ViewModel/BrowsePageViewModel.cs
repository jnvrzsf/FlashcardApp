using FlashCardApp.Model;
using System.Collections.Generic;

namespace FlashCardApp.ViewModel
{
    class BrowsePageViewModel
    {
        public Deck Deck;
        public string DeckName => Deck.Name;
        public List<Card> Cards => Deck.Cards;
        public BrowsePageViewModel(Deck deck)
        {
            Deck = deck;
        }
    }
}
