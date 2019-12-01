using FlashCardApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FlashCardApp.ViewModel
{
    class BrowsePageViewModel
    {
        public Deck Deck;
        public string DeckName => Deck.Name;
        public ObservableCollection<CardViewModel> Cards = new ObservableCollection<CardViewModel>();
        public BrowsePageViewModel(Deck deck)
        {
            Deck = deck;
            foreach (Card card in Deck.Cards)
            {
                Cards.Add(new CardViewModel(card));
            }
        }
    }
}
