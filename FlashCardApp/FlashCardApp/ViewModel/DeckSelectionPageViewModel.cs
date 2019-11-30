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

        public string NextPage { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public DeckSelectionPageViewModel()
        {
            DeckNames = Deck.GetListOfDeckNames();
        }
    }
}
