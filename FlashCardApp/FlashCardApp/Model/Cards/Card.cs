using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Cards
{
    public class Card
    {
        #region static properties of the card
        public int ID { get; private set; }
        public string WordToLearn { get; private set; }
        public string Meaning { get; private set; }
        /* Találatok száma */
        #endregion
        #region dynamic properties of the card
        public int Hits { get; private set; }
        /* Ha eltalálta egymásután háromszor, akkor már tudja eléggé ahhoz, hogy tovább mehessen (de még nem tanulta meg) */
        public bool AmountOfHitsIsGoodEnough { get; private set; }
        /* Ha eltalálta ötször egymásután, akkor már megtanulta a szót. */
        public bool IsLearned { get; private set; }
        /* A kártya "színe" */
        public string ColourOfTheCard { get; private set; }
        #endregion

        public Card(int id, string wordToLearn, string meaning, int hit)
        {
            ID = id;
            WordToLearn = wordToLearn;
            Meaning = meaning;
            Hits = hit;
        }
        public Card(int id, string wordToLearn, string meaning)
        {
            ID = id;
            WordToLearn = wordToLearn;
            Meaning = meaning;
            ColourOfTheCard = "red";
        }

        #region interactions
        /*  A felhasználó által adott válasz kezelése */
        public void DealWithAnswer(bool isCorrect)
        {
            if (isCorrect && Hits < 5)
            {
                Hits++;
                CalculateAmountOfHits();
            }
            else
            {
                Hits = 0;
                ColourOfTheCard = "red";
            }
        }

        /* Eldönti, hogy megtanulta-e már a szót */
        private void CalculateAmountOfHits()
        {
            if (Hits >= 5)
            {
                IsLearned = true;
                ColourOfTheCard = "green";
            }
            else if (Hits >= 3 && Hits < 5)
            {
                AmountOfHitsIsGoodEnough = true;
                ColourOfTheCard = "yellow";
            }
        }
        #endregion
    }
}
