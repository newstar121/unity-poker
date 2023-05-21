using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    public static class PokerGameFactory
    {
        public static PokerGame CreateGame(List<IPlayer> players, IDealer dealer)
        {
            return new PokerGame(players, dealer);
        }
    }
}
 