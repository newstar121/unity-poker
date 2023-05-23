using System;
using System.Linq;
using NUnit.Framework;

namespace CardLibrary.UnitTests
{
    /// <summary>
    /// Contains tests for the Deck class.
    /// </summary>
    [TestFixture]
    class DeckTests
    {
        private Deck testDeck;
        
        [SetUp]
        public void TestSetup()
        {
            testDeck = GetTestDeck();
        }

        private Deck GetTestDeck()
        {
            return new Deck();
        }

        [Test]
        public void Deck_ContainsValidCards_ReturnsTrue()
        {
            int cardCount = 13;
            int totalClubCards = testDeck.Count(card => card.Suit == Suit.Club);
            int totalDiamondCards = testDeck.Count(card => card.Suit == Suit.Diamond);
            int totalHeartCards = testDeck.Count(card => card.Suit == Suit.Heart);
            int totalSpadeCards = testDeck.Count(card => card.Suit == Suit.Spade);

            bool isValidDeck = totalClubCards == cardCount && 
                          totalDiamondCards == cardCount && 
                          totalHeartCards == cardCount && 
                          totalSpadeCards == cardCount;

            Assert.That(isValidDeck);
        }

        [Test]
        public void Deck_IsValidSize_ReturnsTrue()
        {
            Assert.That(testDeck.Size == 52);
        }

        [TestCase(-1)]
        [TestCase(52)]
        public void Deck_WhenIndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
        {
            Card testCard;
            Assert.Throws<IndexOutOfRangeException>(() => testCard = testDeck[index]);
        }

    }
}
