
using System;
using FlashCardApp.Model.Cards;
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
    }
}
