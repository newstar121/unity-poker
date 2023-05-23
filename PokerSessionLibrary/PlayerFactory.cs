using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Factory for player objects.
    /// </summary>
    public static class PlayerFactory
    {
        private static int playersCreated = 1;

        /// <summary>
        /// Creates a player of the given type.
        /// </summary>
        /// <param name="playerType">The type of player to be created.</param>
        /// <returns>Returns a player of the argument's type.</returns>
        public static IPlayer CreatePlayer(PlayerType playerType)
        {
            string playerName = $"Player {playersCreated++}";

            switch (playerType)
            {
                case PlayerType.Human:
                    return new Player(playerName, House.InitialStack);
                case PlayerType.Computer:
                    return new Computer(playerName, House.InitialStack);
                default:
                    throw new InvalidEnumArgumentException("Invalid player type, could not construct player.");
            }
        }
    }
}
