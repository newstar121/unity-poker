using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents the dealer.
    /// </summary>
    public class Dealer : IDealer
    {
        Deck _deck;
        int _topCardIndex;
        static Random _random = new Random();

        /// <summary>
        /// The dealer's table.
        /// </summary>
        public PokerTable Table { get; set; }

        /// <summary>
        /// Constructs a dealer. 
        /// </summary>
        public Dealer()
        {
            _deck = new Deck();
            _topCardIndex = _deck.Size - 1;
        }

        /// <summary>
        /// Prepare for the session.
        /// </summary>
        public void Setup()
        {
            GraphicsHelper.TypeLine("Dealer: Setting up...\n");
            Table.Setup();
            _topCardIndex = _deck.Size - 1;
            ShuffleDeck();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Shuffles the deck. 
        /// </summary>
        /// <remarks>Employs Fisher-Yates shuffle.</remarks>
        private void ShuffleDeck()
        {
            for (int i = _deck.Size - 1; i > 0; i--)
            {
                int secondCardIndex = _random.Next(0, 52);
                Card temp = _deck[i];
                _deck[i] = _deck[secondCardIndex];
                _deck[secondCardIndex] = temp;
            }
        }

        /// <summary>
        /// Burns the top card from the deck. 
        /// </summary>
        private void BurnCard()
        {
            Table.Muck(_deck[_topCardIndex--]);
        }

        /// <summary>
        /// Deal a card from the deck.
        /// </summary>
        /// <returns>The top card from the deck.</returns>
        public Card DealCard()
        {
            return _deck[_topCardIndex--];
        }

        /// <summary>
        /// Collects the ante from the players.
        /// </summary>
        public void CollectAnte()
        {
            GraphicsHelper.TypeLine("Dealer: Please ante up...\n");
            decimal totalAntes = 0;
            Thread.Sleep(3000);

            foreach (IPlayer player in Table)
            {
                decimal currentAnte = player.Ante();
                totalAntes += currentAnte;
                GraphicsHelper.TypeLine($"Dealer: {player} anteed {currentAnte:C2}.");
            }

            IncreasePot(totalAntes);

        }

        /// <summary>
        /// Collects the player's bets.
        /// </summary>
        public void CollectBets()
        {
            GraphicsHelper.TypeLine("Dealer: Place your bets...\n");

            decimal totalBets = 0;
            Thread.Sleep(3000);

            foreach (IPlayer player in Table)
            {
                decimal currentBet = player.Bet();
                totalBets += currentBet;
                GraphicsHelper.TypeLine($"Dealer: {player} bet {currentBet:C2}.");
            }

            IncreasePot(totalBets);
        }

        /// <summary>
        /// Increases the pot.
        /// </summary>
        /// <param name="amount">The amount to be added to the pot.</param>
        private void IncreasePot(decimal amount)
        {
            Table.IncreasePot(amount);
            GraphicsHelper.TypeLine($"\nDealer: The pot is currently {Table.Pot:C2}.\n");
        }

        /// <summary>
        /// Deal the hands to the players.
        /// </summary>
        /// <remarks>A card is dealt to one player at a time until each player has a full hand.</remarks>
        public void DealHands()
        {
            GraphicsHelper.TypeLine("Dealer: Dealing cards....\n");

            int currentHandIndex = 0;
            int maxHandIndex = House.MaxHandSize - 1;
            BurnCard();

            while (currentHandIndex <= maxHandIndex)
            {
                for (int playerIndex = 0; playerIndex < Table.Players.Count; playerIndex++)
                    Table.Players[playerIndex].Hand[currentHandIndex] = DealCard();

                currentHandIndex++;
            }

            Thread.Sleep(2000);

        }

        /// <summary>
        /// Collects the player's trade-ins.
        /// </summary>
        public void CollectTrades()
        {
            GraphicsHelper.TypeLine("Dealer: Trade in your cards....\n");

            Thread.Sleep(2000);

            List<Card> trades = new List<Card>();

            foreach (IPlayer player in Table)
            {
                if (IsHumanPlayer(player))
                {
                    Console.CursorVisible = true;
                    GraphicsHelper.TypeLine("Dealer: Please enter the positions of the cards you wish to discard (1 - 5):\n");
                }

                List<Card> currentTrades = player.Discard();

                if (!(currentTrades.Count == 0))
                    trades.AddRange(currentTrades);

                GraphicsHelper.TypeLine($"Dealer: {player} traded in {currentTrades.Count} card(s).\n");
            }

            Console.CursorVisible = false;
            Table.Muck(trades);
        }

        private static bool IsHumanPlayer(IPlayer player)
        {
            return player.GetType() == typeof(Player);
        }

        /// <summary>
        /// Players reveal their hands to determine a winner.
        /// </summary>
        public void AnnounceShowdown()
        {
            GraphicsHelper.TypeLine("Dealer: It's time to showdown...\n");
            Showdown();

            IPlayer winner = CompareHands();
            string winningHand = winner.Hand.Rank.GetLowerCaseString();
            winner.Wins++;

            if (IsHumanPlayer(winner))
                GraphicsHelper.TypeLine($"Dealer: You win with a {winningHand}, and are awarded {DistributePot(winner):C2}\n");

            else
                GraphicsHelper.TypeLine($"Dealer: {winner} wins with a {winningHand}, and is awarded {DistributePot(winner):C2}\n");

        }

        /// <summary>
        /// Reveal every player's hand.
        /// </summary>
        private void Showdown()
        {
            foreach (IPlayer player in Table)
            {
                player.RevealHand();
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Determines the winner.
        /// </summary>
        /// <returns>The player who had the better hand.</returns>
        public IPlayer CompareHands()
        {
            return Table.Players.OrderByDescending(player => player.Hand).First();
        }

        /// <summary>
        /// Distributes the pot to the winner.
        /// </summary>
        /// <param name="player">The player who won the hand.</param>
        /// <returns>Returns the amount that was distributed.</returns>
        private decimal DistributePot(IPlayer player)
        {
            return player.Collect(Table.ClearPot());
        }

    }
}
