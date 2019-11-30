using CsvHelper.Configuration.Attributes;

namespace FlashCardApp.Model.Cards
{
    public class Card
    {
        /// <summary>
        /// Idegen nyelvű szó
        /// </summary>
        [Index(0)]
        [Name("Word")]
        public string Word { get; set; }
        /// <summary>
        /// Magyar megfelelője
        /// </summary>
        [Index(1)]
        [Name("Meaning")]
        public string Meaning { get; set; }
        /// <summary>
        /// Helyes válaszok száma
        /// </summary>
        [Index(2)]
        [Name("HitCount")]
        public int HitCount { get; set; }

        public Card(string Word, string Meaning, int HitCount)
        {
            this.Word = Word;
            this.Meaning = Meaning;
            this.HitCount = HitCount;
        }
    }
}
