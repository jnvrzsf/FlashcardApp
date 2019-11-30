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
        LearningLogic logic = new LearningLogic();
        public int NumberOfCardsWeWantToLearn { get; private set; }

        #region constructors
        /* Megadhatjuk, hogy hány kártyát akarunk a DeckInProgressbe rakni (tetszőleges szám) */
        public ManageDeckInProgress(int numberOfCardsWeWantToLearn)
        {
            NumberOfCardsWeWantToLearn = numberOfCardsWeWantToLearn;
        }
        /* Default beállításokkal készítjük el a DeckInProgresst (5 kártya kerül bele)*/
        public ManageDeckInProgress()
        {
            NumberOfCardsWeWantToLearn = 5;
        }
        #endregion

        //#region Handling DeckInProgress
        ///* Ellenőrzi az aktuálisan a tanulni valók között lévő kártyákat,
        // * és amennyiben azt az illető már tudja (legalább ötször egymás után eltalálja),
        // akkor azt a kártyát kitörli onnan, és a helyébe egy újat tesz be. */
        //public void CheckDeckInProgress()
        //{
        //    foreach (Card card in DeckInProgress.Instance().ListAll())
        //    {
        //        if (card.AmountOfHitsIsGoodEnough)
        //        {
        //            DeckInProgress.Instance().Remove(card);
        //            PickCardsToLearn();
        //        }
        //    }
        //}

        ///* Kártyát helyez az aktuálisan tanulandó szavak listájába (max 10) */
        //public void PickCardsToLearn()
        //{
        //    foreach (Card card in WholeDeck.Instance().ListAll())
        //    {
        //        if (logic.ShouldWeAddCardToDeckInProgress(card) && DeckInProgress.Instance().ListAll().Count < NumberOfCardsWeWantToLearn)
        //        {
        //            DeckInProgress.Instance().Add(card);
        //        }
        //    }
        //}
        //#endregion
    }
}
