using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Deck
{
    /* Aktuális pakli */
    public class DeckInProgress : Deck
    {
        private static DeckInProgress instance = new DeckInProgress();
        public static DeckInProgress Instance() { return instance; }
        private DeckInProgress()
        {
        }
    }
}
