using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace FlashCardApp.Model.Logic
{
    public class ManageWholeDeck
    {
        public ManageWholeDeck()
        {
        }
        
        public void Create(string FileName)
        {
            WholeDeck.Instance().Clear();
            var Path = AppDomain.CurrentDomain.BaseDirectory + "/Files/"+FileName+".csv";
            StreamReader f = new StreamReader(Path);
            while (!f.EndOfStream)
            {
                var line = f.ReadLine();
                var values = line.Split(',');
                WholeDeck.Instance().Add(new Cards.Card(Convert.ToInt32(values[0]), values[1], values[2], Convert.ToInt32(values[3])));
            }
        }
    }
}
