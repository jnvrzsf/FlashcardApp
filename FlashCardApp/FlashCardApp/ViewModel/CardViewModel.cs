using FlashCardApp.Model;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace FlashCardApp.ViewModel
{
    class CardViewModel
    {
        public Card Card { get; set; }
        public string Word => Card.Word;
        public string Meaning => Card.Meaning;
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
