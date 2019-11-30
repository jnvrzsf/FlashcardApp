using FlashCardApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.ViewModel
{
    class EditCardPageViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private Deck Deck { get; set; }
        public Card Card { get; set; }
        public string Meaning => Card.Meaning;
        public string Word => Card.Word;

        public EditCardPageViewModel(Card card, Deck deck)
        {
            Card = card;
            Deck = deck;
        }

        private void Save()
        {
            //TODO for Zsófi
            Deck.Save();
        }
    }
}
