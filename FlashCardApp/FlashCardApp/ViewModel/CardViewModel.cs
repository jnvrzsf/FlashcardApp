using FlashCardApp.Model;
using System.ComponentModel;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FlashCardApp.ViewModel
{
    class CardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Card Card { get; set; }

        public string Word
        {
            get => Card.Word;
            set
            {
                if (Card.Word != value)
                {
                    Card.Word = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Word)));
                }
            }
        }
        
        public string Meaning
        {
            get => Card.Meaning;
            set
            {
                if (Card.Meaning != value)
                {
                    Card.Meaning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Meaning)));
                }
            }
        }

        public Color BackgroundColor
        {
            get
            {
                if (Card.HitCount < 3)
                {
                    return Colors.Red;
                }
                else if (Card.HitCount >= 3 && Card.HitCount < 5)
                {
                    return Colors.Yellow;
                }
                else
                {
                    return Colors.Green;
                }
            }
        }

        public CardViewModel(Card card)
        {
            Card = card;
        }
    }
}
