using FlashCardApp.Model.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Cards
{
    public class CardBuilder
    {
        private ManageWholeDeck deckManager = new ManageWholeDeck();

        public CardBuilder(string deckName)
        {
            deckManager.Create(deckName);
        }
    }
}
