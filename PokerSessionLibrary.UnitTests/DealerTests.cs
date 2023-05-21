using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary.UnitTests
{
    /// <summary>
    /// Contains tests for the Dealer class.
    /// </summary>
    [TestFixture]
    class DealerTests
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
            IPlayer player1 = PlayerFactory.CreatePlayer(PlayerType.Computer);
            IPlayer player2 = PlayerFactory.CreatePlayer(PlayerType.Computer);

            return new List<IPlayer>() { player1, player2 };
        }

        [Test]
        public void DealHands_DealsValidHand_ReturnsTrue()
        {
            table.Dealer.DealHands();
            bool dealtValidHand = true;

            foreach (IPlayer player in table.Players)
            {
                if (player.Hand.Size != House.MaxHandSize)
                {
                    dealtValidHand = false;
                    break;
                }
            }

            Assert.That(dealtValidHand);
        }

        [Test]
        public void CollectAnte_AddsCollectionToPot_ReturnsTrue()
        {
            table.Dealer.CollectAnte();
            decimal expected = House.MinAnte * table.Players.Count;
            decimal actual = table.Pot;

            Assert.That(actual == expected);

        }

        [Test]
        public void CollectBets_AddsCollectionToPot_ReturnsTrue()
        {
            table.Dealer.CollectBets();
            decimal expected = House.MaxBet * table.Players.Count;
            decimal actual = table.Pot;

            Assert.That(actual == expected);

        }

    }
}
