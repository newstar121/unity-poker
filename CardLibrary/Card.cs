using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Represents a playing card.
    /// </summary>
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        /// <summary>
        /// Constructs a playing card based on the given suit and rank.
        /// </summary>
        /// <param name="suit">The suit of the playing card.</param>
        /// <param name="rank">The rank of the playing card.</param>
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Displays the cards.
        /// </summary>
        public void Display()
        {
            SetDisplayColor();
            Console.WriteLine(this);
            Console.ResetColor();
        }

        /// <summary>
        /// Sets the foreground and background color of the displayed cards.
        /// </summary>
        private void SetDisplayColor()
        {
            switch (this.Suit)
            {
                case Suit.Club:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Suit.Diamond:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Suit.Heart:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.Spade:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid suit, could not change display color.");
            }
        }

        /// <summary>
        /// Compares two card objects.
        /// </summary>
        /// <remarks>Compares the cards by their rank.</remarks>
        /// <param name="other">The other card object to be compared.</param>
        /// <returns>
        /// Returns an indication of their relative values.
        /// </returns>
        public int CompareTo(Card other)
        {
            return this.Rank.CompareTo(other.Rank);
        }

        /// <summary>
        /// Returns a string representation of the card.
        /// </summary>
        /// <returns>Returns a readable string which contains the rank, suit and symbol of the card.</returns>
        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}s".PadRight(18) + $"{this.Suit.GetSymbol()}";
        }

        /// <summary>
        /// Checks two card objects for equality.
        /// </summary>
        /// <param name="other">The other card object to be compared.
        /// <returns>Returns true if the card instances are equal; returns false otherwise.</returns>
        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Suit.Equals(other.Suit) &&
                this.Rank.Equals(other.Rank);

        }

        /// <summary>
        /// Checks a card object and another object for equality.
        /// </summary>
        /// <param name="other">The other object to be compared.</param>
        /// <returns>Returns true if the instances are equal; returns false otherwise.</returns>
        public override bool Equals(object other)
        {
            return this.Equals(other as Card);
        }

        /// <summary>
        /// Returns a hash code for this card object.
        /// </summary>
        /// <returns>Returns a hash code for this object.</returns>
        public override int GetHashCode()
        {
            var hashCode = 393341827;
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + Suit.GetHashCode();
            return hashCode;
        }
    }
}
