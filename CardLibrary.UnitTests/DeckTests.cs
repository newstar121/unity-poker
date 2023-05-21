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
