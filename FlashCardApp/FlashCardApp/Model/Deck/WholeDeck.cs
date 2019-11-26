using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Deck
{
    /* Az egész pakli
     * Lényege, hogy a fájlban tárolt összes szó párt elérhetővé tegye*/
    public class WholeDeck : Deck
    {
        private static WholeDeck instance = new WholeDeck();
        public static WholeDeck Instance() { return instance; }
        private WholeDeck() : base()
        {
        }
    }
}
