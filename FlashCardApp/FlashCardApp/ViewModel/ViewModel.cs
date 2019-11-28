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
    static class ViewModel
    {
        static public List<string> GetExistingDecks()
        {
            List<string> existingDecks = new List<string>();
            DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Files\\");
            FileInfo[] Files = d.GetFiles("*.csv");
            foreach (FileInfo file in Files)
            {
                string[] fileName = file.Name.Split(".");
                existingDecks.Add(fileName[0]);
            }
            return existingDecks;
        }
    }
}
