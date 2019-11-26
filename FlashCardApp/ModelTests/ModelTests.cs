
using System;
using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using FlashCardApp.Model.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTests
{
    [TestClass]
    public class ModelTests
    {
        public object ManageDeckInProgess { get; private set; }

        [TestInitialize]
        public void WholeDeckInitialize()
        {
            WholeDeck.Instance().Add(new Card(1, "dog", "kutya"));
            WholeDeck.Instance().Add(new Card(2, "cat", "macska"));
            WholeDeck.Instance().Add(new Card(3, "fish", "hal"));
            WholeDeck.Instance().Add(new Card(4, "lion", "oroszlán"));
            WholeDeck.Instance().Add(new Card(5, "parrot", "papagáj"));
            WholeDeck.Instance().Add(new Card(6, "giant panda", "panda"));
            WholeDeck.Instance().Add(new Card(7, "red panda", "vörös panda"));
            WholeDeck.Instance().Add(new Card(8, "tiger", "tigris"));
            WholeDeck.Instance().Add(new Card(9, "hipoppotamus", "viziló"));
            WholeDeck.Instance().Add(new Card(10, "pig", "disznó"));
            WholeDeck.Instance().Add(new Card(11, "cow", "tehén"));
            WholeDeck.Instance().Add(new Card(12, "bull", "bika"));
            WholeDeck.Instance().Add(new Card(13, "sheep", "bárány"));
            WholeDeck.Instance().Add(new Card(14, "eagle", "sas"));
            WholeDeck.Instance().Add(new Card(15, "falcon", "sólyom"));

        }
        [TestMethod]
        public void CardCreating()
        {
            Card card = new Card(1, "dog", "kutya");
            Assert.AreEqual("dog", card.WordToLearn);
        }

        [TestMethod]
        public void CreateWholeDeck()
        {
            Assert.AreEqual(15, WholeDeck.Instance().ListAll().Count);
            Assert.AreEqual("macska", WholeDeck.Instance().ListAll()[1].Meaning);
        }

        [TestMethod]
        public void CreateDeckInProgress()
        {
            ManageDeckInProgress deckManager = new ManageDeckInProgress();
            deckManager.PickCardsToLearn();

            Assert.AreEqual(10, DeckInProgress.Instance().ListAll().Count);
        }

        [TestMethod]
        public void TestManageDeckInProgress()
        {
            ManageDeckInProgress deckManager = new ManageDeckInProgress();
            deckManager.PickCardsToLearn();
            var testedCard = DeckInProgress.Instance().ListAll()[0];

            for (int i = 0; i < 6; i++)
            {
                testedCard.DealWithAnswer(true);
            }
            deckManager.CheckDeckInProgress();
            Assert.IsFalse(DeckInProgress.Instance().ListAll().Contains(testedCard));

        }
    }
}
