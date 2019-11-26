
using System;
using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void CardCreating()
        {
            Card card = new Card(1, "dog", "kutya");
            Assert.AreEqual("dog", card.WordToLearn);
        }

        [TestMethod]
        public void CreateWholeDeck()
        {
            WholeDeck.Instance().Add(new Card(1, "dog", "kutya"));
            WholeDeck.Instance().Add(new Card(2, "cat", "macska"));
            WholeDeck.Instance().Add(new Card(3, "fish", "hal"));
            WholeDeck.Instance().Add(new Card(4, "lion", "oroszlán"));

            Assert.AreEqual(4, WholeDeck.Instance().ListAll().Count);
            Assert.AreEqual("macska", WholeDeck.Instance().ListAll()[1].Meaning);
        }
    }
}
