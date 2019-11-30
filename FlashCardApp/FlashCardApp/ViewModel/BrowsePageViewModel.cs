using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
