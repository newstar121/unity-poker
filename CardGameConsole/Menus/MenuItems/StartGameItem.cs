using PokerSessionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameConsole.Menus.MenuItems
{
    public class StartGameItem : IMenuItem
    {
        public int X { get; set; }
        public int Y { get; set; }

        public StartGameItem(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Select()
        {
            Console.Clear();

            IDealer dealer = DealerFactory.CreateDealer();
            IPlayer player1 = PlayerFactory.CreatePlayer(PlayerType.Human);
            IPlayer player2 = PlayerFactory.CreatePlayer(PlayerType.Computer);
            IPlayer player3 = PlayerFactory.CreatePlayer(PlayerType.Computer);
            IPlayer player4 = PlayerFactory.CreatePlayer(PlayerType.Computer);
            List<IPlayer> players = new List<IPlayer>() { player1, player2, player3, player4 };

            PokerGameFactory.CreateGame(players, dealer).Start();
        }
    }
}
