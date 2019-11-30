using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.Storage;
using CsvHelper;
using System.Reflection;

namespace FlashCardApp.Model
{
    /* Absztrakt osztály, a paklik közös funkciói vannak itt */
    public class Deck
    {
        /// <summary>
        /// Kártyák a pakliban
        /// </summary>
        public List<Card> Cards = new List<Card>();

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
            if (Cards.Contains(card)) return;
            Cards.Add(card);
        }

        /* Elvesz a pakliból */
        public void Remove(Card card)
        {
            Cards.Remove(card);
        }
        public void Clear()
        {
            Cards.Clear();
        }
        #endregion

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
            var deck = new Deck(name);
            using (var textReader = new StreamReader(PathForName(name), Encoding.UTF8))
            using (var csvReader = new CsvReader(textReader))
            {
                csvReader.Configuration.Delimiter = ",";
                deck.Cards.AddRange(csvReader.GetRecords<Card>());
            }
            return deck;
        }

        /// <summary>
        /// Pakli mentése a fájlrendszerbe
        /// </summary>
        public void Save()
        {
            using (var textWriter = new StreamWriter(PathForName(Name), false, Encoding.UTF8))
            using (var cvsWriter = new CsvWriter(textWriter))
            {
                cvsWriter.Configuration.Delimiter = ",";
                cvsWriter.WriteRecords(Cards);
            }
        }

        /// <summary>
        /// Visszaadja adott nevű pakli elérési útját.
        /// </summary>
        /// <param name="name">Pakli neve</param>
        /// <returns>Pakli elérési útja</returns>
        private static string PathForName(string name)
        {
            return Path.Combine(RootDirectory, $"{name}.csv");
        }

        /// <summary>
        /// Átmásolja a beágyazott paklikat első indításkor
        /// </summary>
        public static void CopyEmbeddedDecksOnFirstLaunch()
        {
            // Ha még nem létezik a mappánk, akkor feltételezzük, hogy először futunk
            if (!Directory.Exists(RootDirectory))
            {
                // Létrehozzuk a mappánk
                Directory.CreateDirectory(RootDirectory);

                // Végigmegyünk az alkalmazásba ágyazott erőforrásokon
                foreach (var name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    // Ha a Decks almappából volt beágyazva, akkor pakli
                    if (name.StartsWith(EmbeddedDeckPrefix))
                    {
                        // Levágjuk a prefixet, hogy megkapjuk a fájl nevét
                        var targetFileName = name.Substring(EmbeddedDeckPrefix.Length + 1);

                        // Kimásoljuk a tartalmát egy, a mappánkban lévő fájlba
                        using (var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                        using (var outputStream = File.OpenWrite(Path.Combine(RootDirectory, targetFileName)))
                        {
                            inputStream.CopyTo(outputStream);
                        }
                    }
                }
            }
        }
    }
}
