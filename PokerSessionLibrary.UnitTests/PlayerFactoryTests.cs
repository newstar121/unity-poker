using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary.UnitTests
{
    [TestFixture]
    class PlayerFactoryTests
    {
        [Test]
        public void CreatePlayer_CreatesHumanPlayer_ReturnsTrue()
        {
            IPlayer player = PlayerFactory.CreatePlayer(PlayerType.Human);

            Assert.That(player.GetType() == typeof(Player));

        }

        [Test]
        public void CreatePlayer_CreatesComputerPlayer_ReturnsTrue()
        {
            IPlayer computer = PlayerFactory.CreatePlayer(PlayerType.Computer);

            Assert.That(computer.GetType() == typeof(Computer));

        }
    }
}
