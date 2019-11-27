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
        [TestMethod]
        public void ReadDeckFromFile()
        {
            ManageWholeDeck mwd = new ManageWholeDeck();
            mwd.Create("Animals");
            Assert.AreEqual(4, WholeDeck.Instance().ListAll().Count);
            Assert.AreEqual("cat", WholeDeck.Instance().ListAll()[1].WordToLearn);
        }
    }
}
