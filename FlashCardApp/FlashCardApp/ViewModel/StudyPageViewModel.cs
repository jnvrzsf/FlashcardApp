using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.ViewModel
{
    class StudyPageViewModel : INotifyPropertyChanged
    {
        Deck Deck { get; }
        private List<CardViewModel> SubDeck { get; }
        public CardViewModel CurrentCard => SubDeck.First();
        /// <summary>
        /// Fel van-e fedve a jelenlegi kártya - háttérváltozó
        /// </summary>
        private bool _isRevealed;

        /// <summary>
        /// Fel van-e fedve a jelenlegi kártya
        /// </summary>
        public bool IsRevealed
        {
            get => _isRevealed;
            set
            {
                if (_isRevealed != value)
                {
                    _isRevealed = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRevealed)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public StudyPageViewModel(Deck deck)
        {
            Deck = deck;
        }
    }
}
