using FlashCardApp.Model;
using System.Collections.Generic;

namespace FlashCardApp.ViewModel
{
    class BrowsePageViewModel
    {
        public List<Card> Cards;
        public BrowsePageViewModel(Deck deck)
        {
            Cards = deck.Cards; // Cards egy List legyen
        }
    }
}
