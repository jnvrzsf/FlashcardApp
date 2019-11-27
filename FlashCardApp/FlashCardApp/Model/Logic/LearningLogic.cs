using FlashCardApp.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Logic
{
    public class LearningLogic
    {
        private double green = 0.9; //biztosan tudja
        private double yellow = 0.6; //még nem biztos a tudás
        private double red = 0.0; //abszolút nem tudja
        Random random = new Random();

        public LearningLogic()
        {
        }

        /* Egy adott prioritás és egy véletlenszerűen generált szám alapján eldöntjük, hogy
         * az adott kártyát behelyezzük-e a DeckInProgress-be. */
        public bool ShouldWeAddCardToDeckInProgress(Card card)
        {
            double randomNumber = random.NextDouble();

            if (card.ColourOfTheCard == "red" && randomNumber < yellow)
            {
                return true;
            }
            else if (card.ColourOfTheCard == "yellow" && (randomNumber >= yellow && randomNumber < green))
            {
                return true;
            }
            else if (card.ColourOfTheCard == "green" && randomNumber >= green)
            {
                return true;
            }
            return false;
        }
    }
}
