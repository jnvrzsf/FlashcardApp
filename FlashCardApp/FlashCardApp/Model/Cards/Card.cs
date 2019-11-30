using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.Model.Cards
{
    public class Card
    {
        public string WordToLearn { get; set; }
        public string Meaning { get; set; }
        
        /* Találatok száma */
        public int HitCount { get; set; }

        public Card(int id, string wordToLearn, string meaning, int hit)
        {
            WordToLearn = wordToLearn;
            Meaning = meaning;
            HitCount = hit;
        }
    }
}
