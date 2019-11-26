using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Logic
{
    public class ManageDeckInProgress
    {
        public ManageDeckInProgress()
        {
        }

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

        public void PickCardsToLearn()
        {
            foreach (Card card in WholeDeck.Instance().ListAll())
            {
                if (IsHitRateLow(card) && DeckInProgress.Instance().ListAll().Count < 10)
                {
                    DeckInProgress.Instance().Add(card);
                }
            }
        }

        public bool IsHitRateLow(Card card)
        {
            return !card.AmountOfHitsIsGoodEnough;
        }
    }
}
