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
        public Card Card { get; set; }
        public string Meaning => Card.Meaning;
        public string Word => Card.Word;

        public EditCardPageViewModel(Card card)
        {
            Card = card;
        }

        private void Save()
        {
            
        }
    }
}
