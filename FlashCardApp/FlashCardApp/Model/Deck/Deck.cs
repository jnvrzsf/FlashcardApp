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
        /// A beágyazott paklik nevének közös előtagja
        /// </summary>
        private const string EmbeddedDeckPrefix = "FlashCardApp.Decks";

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="name"></param>
        public Deck(string name)
        {
            Name = name;
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
            if (Directory.Exists(RootDirectory))
            {
                return Directory
                .EnumerateFiles(RootDirectory, "*.csv", SearchOption.TopDirectoryOnly)
                .Select(e => Path.GetFileNameWithoutExtension(e)).ToList();
            }
            else
            {
                return Enumerable.Empty<string>().ToList();
            }
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
