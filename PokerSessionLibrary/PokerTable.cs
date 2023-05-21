using CardLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Represents the poker table.
    /// </summary>
    public class PokerTable : IEnumerable<IPlayer>
    {
        /// <summary>
        /// The discard pile.
        /// </summary>
        private List<Card> muck;

        /// <summary>
        /// The player's at the table.
        /// </summary>
        public List<IPlayer> Players { get; set; }

        /// <summary>
        /// The dealer.
        /// </summary>
        public IDealer Dealer { get; set; }

        /// <summary>
        /// The total pot.
        /// </summary>
        public decimal Pot { get; set; }

        /// <summary>
        /// Constructs a poker table.
        /// </summary>
        private PokerTable()
        {
            Players = new List<IPlayer>();
            muck = new List<Card>();
        }

        /// <summary>
        /// Constructs a poker table with the given players and dealers.
        /// </summary>
        /// <param name="players">The players to be seated.</param>
        /// <param name="dealer">The dealer to be seated.</param>
        /// <remarks>
        /// If the number of players exceeds the maximum allowed, only the maximum number of players
        /// will be seated.
        /// </remarks>
        public PokerTable(List<IPlayer> players, IDealer dealer) : this()
        {
            SeatDealer(dealer);
            SeatPlayers(players.Take(House.MaxPlayers).ToList());
        }

        /// <summary>
        /// Seats the dealer at the table.
        /// </summary>
        /// <param name="dealer">The dealer to be seated.</param>
        public void SeatDealer(IDealer dealer)
        {
            Dealer = dealer;
            Dealer.Table = this;
        }
        
        /// <summary>
        /// Seats the players at the table.
        /// </summary>
        /// <param name="players">The players to be seated.</param>
        public void SeatPlayers(List<IPlayer> players)
        {
            Players.AddRange(players);

            foreach (IPlayer player in this)
                player.Table = this;
        }

        /// <summary>
        /// Sets up the table for play.
        /// </summary>
        public void Setup()
        {
            this.ClearPot();
            this.ClearMuck();

        }

        /// <summary>
        /// Adds a card to the muck.
        /// </summary>
        /// <param name="card">The card to be discarded.</param>
        public void Muck(Card card)
        {
            muck.Add(card);
        }

        /// <summary>
        /// Adds cards to the muck.
        /// </summary>
        /// <param name="cards">The cards to be added.</param>
        public void Muck(List<Card> cards)
        {
            muck.AddRange(cards);
        }

        /// <summary>
        /// Increases the current pot.
        /// </summary>
        /// <param name="amount">The amount to be added to the pot.</param>
        public void IncreasePot(decimal amount)
        {
            if (amount < 1)
                throw new ArgumentException("Pot increase cannot be negative.");

            this.Pot += amount;

        }

        /// <summary>
        /// Clears the current pot.
        /// </summary>
        /// <returns>The amount that was cleared.</returns>
        public decimal ClearPot()
        {
            decimal currentPot = this.Pot;
            this.Pot = 0;
            return currentPot;
        }

        /// <summary>
        /// Clears the muck.
        /// </summary>
        public void ClearMuck()
        {
            muck.Clear();
        }

        /// <summary>
        /// Returns a enumerator that iterates through the players at the table.
        /// </summary>
        /// <returns>An enumerator that iterates through players at the table.</returns>
        public IEnumerator<IPlayer> GetEnumerator()
        {
            return ((IEnumerable<IPlayer>)Players).GetEnumerator();
        }

        /// <summary>
        /// Returns a enumerator that iterates through the players at the table.
        /// </summary>
        /// <returns>An enumerator that iterates through players at the table.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IPlayer>)Players).GetEnumerator();
        }
    }
}
