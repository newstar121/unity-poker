using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace CardLibrary.UnitTests
{
    /// <summary>
    /// Contains tests for the PokerHandEvaluator class.
    /// </summary>
    [TestFixture]
    public class PokerHandEvaluatorTests
    {
        /// <summary>
        /// Retrieves test hand(s) based on the poker hand type.
        /// </summary>
        /// <param name="pokerHand">The type of poker hand.</param>
        /// <returns>Poker hand(s) corresponding to the argument.</returns>
        static IEnumerable<Card[]> GetTestHand(PokerHand pokerHand)
        {
            if (pokerHand == PokerHand.Flush)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Nine)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Diamond, Rank.Four),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Diamond, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Spade, Rank.Three),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Spade, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Heart, Rank.Four),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Heart, Rank.Six)
                };
            }

            if (pokerHand == PokerHand.Straight)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Diamond, Rank.Four),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Heart, Rank.Six),
                    new Card(Suit.Club, Rank.Seven)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Spade, Rank.Six),
                    new Card(Suit.Heart, Rank.Seven),
                    new Card(Suit.Club, Rank.Eight)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Diamond, Rank.Six),
                    new Card(Suit.Spade, Rank.Seven),
                    new Card(Suit.Heart, Rank.Eight),
                    new Card(Suit.Club, Rank.Nine)
                };
            }

            if (pokerHand == PokerHand.StraightFlush)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Diamond, Rank.Four),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Diamond, Rank.Six),
                    new Card(Suit.Diamond, Rank.Seven)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Spade, Rank.Six),
                    new Card(Suit.Spade, Rank.Seven),
                    new Card(Suit.Spade, Rank.Eight)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Heart, Rank.Six),
                    new Card(Suit.Heart, Rank.Seven),
                    new Card(Suit.Heart, Rank.Eight),
                    new Card(Suit.Heart, Rank.Nine)
                };
            }

            if (pokerHand == PokerHand.RoyalFlush)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Queen),
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Diamond,Rank.Ten),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Diamond, Rank.Queen),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Diamond, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Heart, Rank.Ten),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Heart, Rank.Queen),
                    new Card(Suit.Heart, Rank.King),
                    new Card(Suit.Heart, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Spade, Rank.Ten),
                    new Card(Suit.Spade, Rank.Jack),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Spade, Rank.King),
                    new Card(Suit.Spade, Rank.Ace)
                };
            }

            if (pokerHand == PokerHand.FullHouse)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Spade, Rank.King),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Deuce),
                    new Card(Suit.Diamond, Rank.Deuce),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Diamond, Rank.Ten),
                    new Card(Suit.Heart, Rank.Ten),
                    new Card(Suit.Club, Rank.Ten)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Five),
                    new Card(Suit.Diamond, Rank.Seven),
                    new Card(Suit.Heart, Rank.Seven),
                    new Card(Suit.Club, Rank.Seven)
                };
            }

            if (pokerHand == PokerHand.FourOfAKind)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Spade, Rank.Jack),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Deuce)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Spade, Rank.Ten),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Heart, Rank.Ten),
                    new Card(Suit.Club, Rank.Ten)
                };

                yield return new Card[]
               {
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Diamond, Rank.Queen),
                    new Card(Suit.Heart, Rank.Queen),
                    new Card(Suit.Club, Rank.Queen)
               };
            }

            if (pokerHand == PokerHand.ThreeOfAKind)
            {
                yield return new Card[]
                {          
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Deuce),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Jack)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Ten),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Eight),
                    new Card(Suit.Heart, Rank.Nine),
                    new Card(Suit.Club, Rank.Ace)
                };
            }

            if (pokerHand == PokerHand.TwoPair)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Club, Rank.Eight)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Nine),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Five)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Queen),
                    new Card(Suit.Heart, Rank.King),
                    new Card(Suit.Club, Rank.King)
                };
            }

            if (pokerHand == PokerHand.OnePair)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Six),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Three)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Spade, Rank.Deuce),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Ace)
                };
            }

            if (pokerHand == PokerHand.HighCard)
            {
                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Eight),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Spade, Rank.Eight),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                };

                yield return new Card[]
                {
                    new Card(Suit.Club, Rank.Deuce),
                    new Card(Suit.Spade, Rank.Queen),
                    new Card(Suit.Diamond, Rank.Jack),
                    new Card(Suit.Heart, Rank.King),
                    new Card(Suit.Club, Rank.Four)
                };
            }
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void Flush_IsFlush_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsFlush(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void Straight_IsStraight_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsStraight(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void StraightFlush_IsStraightFlush_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsStraightFlush(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void RoyalFlush_IsRoyalFlush_ReturnsTrue(Card[] testHand)
        {
            bool result = PokerHandEvaluator.IsRoyalFlush(testHand);
            Assert.That(result == true);
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void FullHouse_IsFullHouse_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsFullHouse(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void FourOfAKind_IsFourOfAKind_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsFourOfAKind(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void ThreeOfAKind_IsThreeOfAKind_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsThreeOfAKind(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void ThreeOfAKind_IsBetterThan_ReturnsTrue(Card[] testHand)
        {
            Assert.That(!PokerHandEvaluator.IsThreeOfAKind(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void TwoPair_IsTwoPair_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsTwoPair(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void TwoPair_IsBetterThan_ReturnsTrue(Card[] testHand)
        {
            Assert.That(!PokerHandEvaluator.IsTwoPair(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.OnePair })]
        public void OnePair_IsOnePair_ReturnsTrue(Card[] testHand)
        {
            Assert.That(PokerHandEvaluator.IsOnePair(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void OnePair_IsBetterThan_ReturnsTrue(Card[] testHand)
        {
            Assert.That(!PokerHandEvaluator.IsOnePair(testHand));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Flush })]
        public void EvaluatePokerHand_AssignsFlush_ReturnsTrue(Card[] testHand)
        {
            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.Flush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.Straight })]
        public void EvaluatePokerHand_AssignsStraight_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.Straight);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.StraightFlush })]
        public void EvaluatePokerHand_AssignsStraightFlush_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.StraightFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.RoyalFlush })]
        public void EvaluatePokerHand_AssignsRoyalFlush_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.RoyalFlush);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FullHouse })]
        public void EvaluatePokerHand_AssignsFullHouse_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.FullHouse);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.FourOfAKind })]
        public void EvaluatePokerHand_AssignsFourOfAKind_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.FourOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.ThreeOfAKind })]
        public void EvaluatePokerHand_AssignsThreeOfAKind_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.ThreeOfAKind);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.TwoPair })]
        public void EvaluatePokerHand_AssignsTwoPair_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.TwoPair);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.OnePair })]
        public void EvaluatePokerHand_AssignsOnePair_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.OnePair);

        }

        [TestCaseSource(nameof(GetTestHand), new object[] { PokerHand.HighCard })]
        public void EvaluatePokerHand_AssignsHighCard_ReturnsTrue(Card[] testHand)
        {

            PokerHand result = PokerHandEvaluator.EvaluatePokerHand(testHand);

            Assert.That(result == PokerHand.HighCard);

        }
    }
}
