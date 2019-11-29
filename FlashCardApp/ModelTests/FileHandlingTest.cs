using FlashCardApp.Model.Cards;
using FlashCardApp.Model.Deck;
using FlashCardApp.Model.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTests
{
    [TestClass]
    public class FileHandlingTest
    {
        ManageWholeDeck mwd = new ManageWholeDeck();

        [TestMethod]
        public void ReadAnimalsDeckFromFile()
        {
            
            mwd.Create();
            mwd.Create("Animals");
            Assert.AreEqual(30, WholeDeck.Instance().ListAll().Count);
            Assert.AreEqual("cock", WholeDeck.Instance().ListAll()[2].WordToLearn);
            Assert.AreEqual("kakas", WholeDeck.Instance().ListAll()[2].Meaning);
        }
        [TestMethod]
        public void ReadFoodsDeckFromFile()
        {
            mwd.Create();
            Assert.AreEqual(20, WholeDeck.Instance().ListAll().Count);
            Assert.AreEqual("coffee", WholeDeck.Instance().ListAll()[3].WordToLearn);
            Assert.AreEqual("kávé", WholeDeck.Instance().ListAll()[3].Meaning);
        }
        [TestMethod]
        public void ReadAdjectivesFromFile()
        {
            mwd.Create();
            Assert.AreEqual(30, WholeDeck.Instance().ListAll().Count);
            Assert.AreEqual("handsome", WholeDeck.Instance().ListAll()[10].WordToLearn);
            Assert.AreEqual("jóképű", WholeDeck.Instance().ListAll()[10].Meaning);
        }
        [TestMethod]
        public void WriteToFile()
        {
            mwd.Create();
            Assert.AreEqual(30, WholeDeck.Instance().ListAll().Count);
            WholeDeck.Instance().Add(new Card(30, "zebra", "zebra", 0));
            mwd.WriteToFile("Animals");
            Assert.AreEqual(31, WholeDeck.Instance().ListAll().Count);
        }
    }
}
