using FlashCardApp.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (Card.HitCount == 0)
                {
                    return Colors.Red;
                }
                else if (Card.HitCount < 5)
                {
                    return Colors.Yellow;
                }
                else
                {
                    return Colors.Green;
                }
            }
        }
        public SolidColorBrush BackgroundBrush => new SolidColorBrush(BackgroundColor);

        public CardViewModel(Card card)
        {
            Card = card;
        }

    }
}
