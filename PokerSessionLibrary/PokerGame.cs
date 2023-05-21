using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents the poker game.
    /// </summary>
    public class PokerGame
    {
        public PokerTable Table { get; private set; }

        /// <summary>
        /// Constructs a poker game with the given players and dealer.
        /// </summary>
        /// <param name="players">The players of the game.</param>
        /// <param name="dealer">The dealer of the game.</param>
        public PokerGame(List<IPlayer> players, IDealer dealer)
        {
            Table = new PokerTable(players, dealer);
        }

        /// <summary>
        /// Starts the poker game.
        /// </summary>
        public void Start()
        {
            IPlayer humanPlayer = Table.Players.First(player => player.GetType() == typeof(Player));

            while (true)
            {
                Table.Dealer.Setup();
                Table.Dealer.CollectAnte();
                Table.Dealer.DealHands();
                Table.Dealer.CollectBets();
                Table.Dealer.CollectTrades();
                Table.Dealer.CollectBets();
                Table.Dealer.AnnounceShowdown();

                Console.WriteLine($"You have {humanPlayer.Stack:C2} left");
                Console.WriteLine("[Y] Player another hand.");
                Console.WriteLine("[N] Cash out.");

                if (Console.ReadKey(true).Key.Equals(ConsoleKey.N))
                    break;

                else
                    Console.Clear();
            }

            End();
        }

        /// <summary>
        /// Ends the poker game.
        /// </summary>
        public void End()
        {
            Console.Clear();
            ShowStatistics();
            Console.WriteLine("[ESC] Return to main menu.");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey(true).Key.Equals(ConsoleKey.Escape))
                        return;
                }
            }
            

        }

        /// <summary>
        /// Shows the statistics for the game.
        /// </summary>
        private void ShowStatistics()
        {
            int totalHands = Table.Players.Sum(player => player.Wins);

            foreach (IPlayer player in Table.Players)
            {
                Console.WriteLine($"{player} won {player.Wins} hand(s) out of {totalHands} hand(s).");
                Console.WriteLine($"Their total winnings this game were {player.Stack:C2}.\n\n");
            }
        }
    }
}
