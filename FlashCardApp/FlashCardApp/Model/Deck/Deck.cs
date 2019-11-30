using FlashCardApp.Model.Cards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using CsvHelper;

namespace FlashCardApp.Model.Deck
{
    /* Absztrakt osztály, a paklik közös funkciói vannak itt */
    public class Deck
    {
        /// <summary>
        /// Kártyák a pakliban
        /// </summary>
        protected Dictionary<int, Card> Cards = new Dictionary<int, Card>();

        /// <summary>
        /// Pakli neve
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A paklik alapértelmezett helye a fájlrendszerben
        /// </summary>
        private static string RootDirectory => Path.Combine(ApplicationData.Current.RoamingFolder.Path, "Decks");

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name"></param>
        public Deck(string name)
        {
            Name = name;
        }

        public Deck()
        {

        }

        #region Adding and Removing
        /* Paklihoz hozzáad */
        public void Add(Card card)
        {
            if (Cards.ContainsKey(card.ID)) return;
            Cards.Add(card.ID, card);
        }

        /* Elvesz a pakliból */
        public void Remove(Card card)
        {
            Cards.Remove(card.ID);
        }
        public void Clear()
        {
            Cards.Clear();
        }
        #endregion

        /* Kilistázás */
        public List<Card> ListAll()
        {
            return Cards.Values.ToList();
        }

        /// <summary>
        /// Kislistázza az elérhető paklikat
        /// </summary>
        /// <returns>Paklik nevei</returns>
        public static List<string> GetListOfDeckNames()
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

        /// <summary>
        /// Pakli betöltése fájlból
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Deck Load(string name)
        {
            throw new NotImplementedException();
        }
    }
}
