using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary.UnitTests
{
    [TestFixture]
    class HandTests
    {
        [TestCase(-1)]
        [TestCase(5)]
        public void Hand_WhenIndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
        {
            Hand testHand = new Hand();
            Card testCard;
            Assert.Throws<IndexOutOfRangeException>(() => testCard = testHand[index]);
        }

        [Test]
        public void CompareTo_WhenHandRankIsLow_ReturnsTrue()
        {
            Hand hand1 = new Hand(
                    new Card[]
                    {
                        new Card(Suit.Club, Rank.Ace),
                        new Card(Suit.Heart, Rank.Five),
                        new Card(Suit.Spade, Rank.Jack),
                        new Card(Suit.Diamond, Rank.Six),
                        new Card(Suit.Heart, Rank.Deuce)
                    }
                );

            Hand hand2 = new Hand(
                    new Card[]
                    {
                        new Card(Suit.Club, Rank.Six),
                        new Card(Suit.Spade, Rank.Five),
                        new Card(Suit.Spade, Rank.Jack),
                        new Card(Suit.Diamond, Rank.Six),
                        new Card(Suit.Heart, Rank.Deuce)
                    }
                );

            Assert.That(hand1.CompareTo(hand2) < 0);
        }

        [Test]
        public void CompareTo_WhenHandRankIsHigh_ReturnsTrue()
        {
            Hand hand1 = new Hand(
                    new Card[]
                    {
                        new Card(Suit.Club, Rank.Six),
                        new Card(Suit.Spade, Rank.Five),
                        new Card(Suit.Spade, Rank.Jack),
                        new Card(Suit.Diamond, Rank.Six),
                        new Card(Suit.Heart, Rank.Deuce)
                    }
                );

            Hand hand2 = new Hand(
                    new Card[]
                    {
                        new Card(Suit.Club, Rank.Ace),
                        new Card(Suit.Heart, Rank.Five),
                        new Card(Suit.Spade, Rank.Jack),
                        new Card(Suit.Diamond, Rank.Six),
                        new Card(Suit.Heart, Rank.Deuce)
                    }
                );

            Assert.That(hand1.CompareTo(hand2) > 0);
        }

        [Test]
        public void CompareTo_WhenHandRanksAreEqual_ReturnsTrue()
        {
            Hand hand1 = new Hand(
                    new Card[]
                    {
                        new Card(Suit.Club, Rank.Six),
                        new Card(Suit.Spade, Rank.Five),
                        new Card(Suit.Spade, Rank.Jack),
                        new Card(Suit.Diamond, Rank.Six),
                        new Card(Suit.Heart, Rank.Three)
                    }
                );

            Hand hand2 = new Hand(
                    new Card[]
                    {
                        new Card(Suit.Club, Rank.Six),
                        new Card(Suit.Spade, Rank.Five),
                        new Card(Suit.Spade, Rank.Jack),
                        new Card(Suit.Diamond, Rank.Six),
                        new Card(Suit.Heart, Rank.Deuce)
                    }
                );

            Assert.That(hand1.CompareTo(hand2) > 0);
        }
    }
}
