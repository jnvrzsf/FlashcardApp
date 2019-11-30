using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Cards
{
    public class Card
    {
        public int ID { get; private set; }
        public string WordToLearn { get; private set; }
        public string Meaning { get; private set; }
        
        /* Találatok száma */
        public int HitCount { get; private set; }

        public Card(int id, string wordToLearn, string meaning, int hit)
        {
            ID = id;
            WordToLearn = wordToLearn;
            Meaning = meaning;
            HitCount = hit;
        }
    }
}
