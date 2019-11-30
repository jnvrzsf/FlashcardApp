using FlashCardApp.Model;
using System.Collections.Generic;

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
