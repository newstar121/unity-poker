using CardLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents a human player.
    /// </summary>
    public class Player : IPlayer
    { 
        public string Name { get; set; }
        public decimal Stack { get; set; }
        public int Wins { get; set; }
        public Hand Hand { get; set; }
        public PokerTable Table { get; set; }

        /// <summary>
        /// Constructs a new player.
        /// </summary>
        private Player()
        {
            Wins = 0;
            Hand = new Hand();
        }

        /// <summary>
        /// Constructs a new player with a given name and initial stack.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="stack">The starting stack for the player.</param>
        public Player(string name, decimal stack) : this()
        {
            Name = name;
            Stack = stack;
        }

        /// <summary>
        /// Reveals the player's hand.
        /// </summary>
        public void RevealHand()
        {
            Console.WriteLine("Your Hand");
            Hand.Sort();
            Hand.Display();
            GraphicsHelper.ResetConsoleColor();
        }

        /// <summary>
        /// Antees the minimum amount.
        /// </summary>
        /// <returns>The amount that was anteed</returns>
        public decimal Ante()
        {
            if (!IsValidAnte())
                this.Stack = House.InitialStack;

            this.Stack -= House.MinAnte;
            return House.MinAnte;
        }

        /// <summary>
        /// Bets the maximum.
        /// </summary>
        /// <returns>Returns the amount that was bet.</returns>
        public decimal Bet()
        {
            if (!IsValidBet())
                this.Stack = House.InitialStack;

            this.Stack -= House.MaxBet;
            return House.MaxBet;
        }

        /// <summary>
        /// Checks if the stack after the antee is valid.
        /// </summary>
        /// <returns>Returns true if the stack is positive; returns false otherwise.</returns>
        private bool IsValidAnte()
        {
            return this.Stack - House.MinAnte > 0;
        }

        /// <summary>
        /// Checks if the stack after the bet is valid.
        /// </summary>
        /// <returns>Returns true if the stack is positive; returns false otherwise.</returns>
        private bool IsValidBet()
        {
            return this.Stack - House.MaxBet > 0;
        }

        /// <summary>
        /// Collect prize money.
        /// </summary>
        /// <param name="amount">The amount to be collected.</param>
        /// <returns>Returns the amount that was collected.</returns>
        /// <exception cref="ArgumentException">When the amount to be collected is negative or 0.</exception>
        public decimal Collect(decimal amount)
        {
            if (amount < 1)
                throw new ArgumentException("Stack increase cannot be negative.");

            this.Stack += amount;

            return amount;
        }

        /// <summary>
        /// Discards cards from the hand.
        /// </summary>
        /// <returns>The cards that were discarded.</returns>
        public List<Card> Discard()
        {
            List<Card> discards = new List<Card>();
            Card discarded;

            RevealHand();
            int[] discardIndices = GetDiscardIndices();

            for (int i = 0; i < discardIndices.Length; i++)
            {
                int currentIndex = discardIndices[i];

                if (IsValidIndex(currentIndex))
                {
                    discarded = Hand[currentIndex];
                    Hand[currentIndex] = Table.Dealer.DealCard();
                    discards.Add(discarded);
                }

            }

            return discards;
        }

        /// <summary>
        /// Gets discard indices from the user.
        /// </summary>
        /// <returns>An array containing the discard indices.</returns>
        private int[] GetDiscardIndices()
        {
            string[] desiredIndices = Console.ReadLine().Split(new char[0]);
            Console.WriteLine();

            int[] indices = desiredIndices
                .Select(
                    (input) => {
                        Int32.TryParse(input, out int validIndex);

                        if (validIndex >= 1 && validIndex <= House.MaxHandSize)
                            return validIndex - 1;

                        else
                            return -1;
                    }
                ).Where(index => index != -1).Take(House.MaxDiscards).ToArray();

            return indices;
        }

        /// <summary>
        /// Checks whether the given index is valid. 
        /// </summary>
        /// <param name="index">The index to be checked.</param>
        /// <returns>Returns true if the argument is a valid index; returns false otherwise.</returns>
        private bool IsValidIndex(int index)
        {
            return index >= 0 && index <= House.MaxHandSize - 1;
        }

        /// <summary>
        /// Returns a string representation of the player.
        /// </summary>
        /// <returns>Returns a string containing the player's name.</returns>
        public override string ToString()
        {
            return $"{this.Name}";
        }

        /// <summary>
        /// Compares two players.
        /// </summary>
        /// <param name="other">The other player to be compared.</param>
        /// <returns>Returns an indication of the relative values of the player's hands.</returns>
        public int CompareTo(IPlayer other)
        {
            return this.Hand.CompareTo(other.Hand);
        }
    }
}
