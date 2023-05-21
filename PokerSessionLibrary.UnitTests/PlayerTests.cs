using CardLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary.UnitTests
{
    [TestFixture]
    class PlayerTests
    {
        private PokerTable table;

        [SetUp]
        public void TestSetup()
        {
            table = new PokerTable(GetTestPlayers(), GetTestDealer());
        }

        private IDealer GetTestDealer()
        {
            return DealerFactory.CreateDealer();
        }

        private List<IPlayer> GetTestPlayers()
        {
            IPlayer humanPlayer = PlayerFactory.CreatePlayer(PlayerType.Human);
            return new List<IPlayer>() { humanPlayer };
        }

        [Test]
        public void Ante_ResetsStackWhenNegative_ReturnsTrue()
        {
            table.Players[0].Stack = 0;

            decimal expected = 1;
            decimal actual = table.Players[0].Ante();

            Assert.That(actual == expected);

        }

        [Test]
        public void Bet_ResetsStackWhenNegative_ReturnsTrue()
        {
            table.Players[0].Stack = 0;

            decimal expected = 1;
            decimal actual = table.Players[0].Bet();

            Assert.That(actual == expected);

        }

        [TestCase("10 ", 0)]
        [TestCase("1", 1)]
        [TestCase("2 1", 2)]
        [TestCase("1 a b c 2 3", 3)]
        public void Discard_ValidIndices_ReturnsTrue(string testInput, int expectedCount)
        {
            List<Card> discards;
          
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                table.Dealer.DealHands();

                using (StringReader sr = new StringReader(testInput))
                {
                    Console.SetIn(sr);
                    discards = table.Players[0].Discard();               
                }
            }

            Assert.That(discards.Count == expectedCount);

        }
    }
}
