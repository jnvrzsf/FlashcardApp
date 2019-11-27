using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Logic
{
    /* Az aktuálisan tanulandó kártyák kezelése */
    public class ManageDeckInProgress
    {
        private double green = 0.9; //biztosan tudja
        private double yellow = 0.6; //még nem biztos a tudás
        private double red = 0.0; //abszolút nem tudja
        Random random = new Random();

        public ManageDeckInProgress()
        {
        }

        /* Ellenőrzi az aktuálisan a tanulni valók között lévő kártyákat,
         * és amennyiben azt az illető már tudja (legalább ötször egymás után eltalálja),
         akkor azt a kártyát kitörli onnan, és a helyébe egy újat tesz be. */
        public void CheckDeckInProgress()
        {
            foreach (Card card in DeckInProgress.Instance().ListAll())
            {
                if (card.AmountOfHitsIsGoodEnough)
                {
                    DeckInProgress.Instance().Remove(card);
                    PickCardsToLearn();
                }
            }
        }

        /* Kártyát helyez az aktuálisan tanulandó szavak listájába (max 10) */
        public void PickCardsToLearn()
        {
            foreach (Card card in WholeDeck.Instance().ListAll())
            {
                if (ShouldWeAddCardToDeckInProgress(card) && DeckInProgress.Instance().ListAll().Count < 10)
                {
                    DeckInProgress.Instance().Add(card);
                }
            }
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
