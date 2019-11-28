using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApp.ViewModel
{
    class ViewModel
    {
        public List<string> GetExistingDecks()
        {
            List<string> existingDecks = new List<string>();
            DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Files\\");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.csv"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                existingDecks.Add(file.Name);
            }
            return existingDecks;
        }
    }
}
