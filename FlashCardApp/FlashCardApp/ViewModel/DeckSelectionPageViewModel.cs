using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.ViewModel
{
    class DeckSelectionPageViewModel
    {
        /// <summary>
        /// Elérhető paklik
        /// </summary>
        public List<string> DeckNames { get; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public DeckSelectionPageViewModel()
        {
            DeckNames = Deck.GetListOfDeckNames();
        }
    }
}
