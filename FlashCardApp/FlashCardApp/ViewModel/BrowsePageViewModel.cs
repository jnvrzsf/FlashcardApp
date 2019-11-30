using FlashCardApp.Model;
using System.Collections.Generic;

namespace FlashCardApp.ViewModel
{
    class BrowsePageViewModel
    {
        public Deck Deck;
        public List<Card> Cards => Deck.Cards;
        public BrowsePageViewModel(Deck deck)
        {
            Deck = deck;
        }
    }
}
