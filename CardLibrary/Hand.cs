using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    public class Hand : IComparable<Hand>, IEnumerable<Card>, IEquatable<Hand>
    {
        private const int MaxHandSize = 5;
        private Card[] _hand;

        /// <summary>
        /// The size of the hand.
        /// </summary>
        public int Size => _hand.Length;

        /// <summary>
        /// The rank of the hand.
        /// </summary>
        public PokerHand Rank => PokerHandEvaluator.EvaluatePokerHand(_hand);

        /// <summary>
        /// The hand's high card.
        /// </summary>
        public Card HighCard => _hand[_hand.Length - 1];

        /// <summary>
        /// Constructs a hand of maximum size.
        /// </summary>
        public Hand()
        {
            _hand = new Card[MaxHandSize];
        }

        /// <summary>
        /// Constructs a hand with the given cards.
        /// </summary>
        /// <param name="cards">The cards to be placed in the hand.</param>
        public Hand(Card[] cards) : this()
        {
            for (int i = 0; i < _hand.Length; i++)
                _hand[i] = cards[i];
        }

        public Card this[int index]
        {
            get
            {
                if (index < 0 || index > _hand.Length - 1)
                    throw new IndexOutOfRangeException("Index out of range");

                return _hand[index];
            }
            set
            {
                if (index < 0 || index > _hand.Length - 1)
                    throw new IndexOutOfRangeException("Index out of range");

                _hand[index] = value;
            }
        }

        /// <summary>
        /// Displays the hand.
        /// </summary>
        public void Display()
        {
            foreach (Card card in _hand)
                card.Display();
        }

        /// <summary>
        /// Sorts the hand.
        /// </summary>
        public void Sort()
        {
            _hand = _hand.OrderBy(card => (int)card.Rank).ToArray();
        }

        /// <summary>
        /// Checks a hand object and another object for equality.
        /// </summary>
        /// <param name="other">The other object to be compared.</param>
        /// <returns>Returns true if the instances are equal; returns false otherwise.</returns>
        public override bool Equals(object other)
        {
            return this.Equals(other as Hand);
        }

        /// <summary>
        /// Checks two hand objects for equality.
        /// </summary>
        /// <param name="other">The other hand object to be compared.
        /// <returns>Returns true if the hand instances are equal or if the hand rankings are the same; returns false otherwise.</returns>
        public bool Equals(Hand other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Rank.Equals(other.Rank);
        }

        /// <summary>
        /// Returns a hash code for this hand object.
        /// </summary>
        /// <returns>Returns a hash code for this object.</returns>
        public override int GetHashCode()
        {
            var hashCode = -162346762;
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + HighCard.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Compares two hand objects.
        /// </summary>
        /// <remarks>Compares the hand by their rank, and in the event of a tie, their high card..</remarks>
        /// <param name="other">The other hand object to be compared.</param>
        /// <returns>
        /// Returns an indication of their relative values.
        /// </returns>
        public int CompareTo(Hand other)
        {
            if (this.Equals(other))
                return this.HighCard.CompareTo(other.HighCard);

            return this.Rank.CompareTo(other.Rank);
        }

        // <summary>
        /// Returns a enumerator that iterates through the hand.
        /// </summary>
        /// <returns>An enumerator that iterates through the hand.</returns>
        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)_hand).GetEnumerator();
        }

        // <summary>
        /// Returns a enumerator that iterates through the hand.
        /// </summary>
        /// <returns>An enumerator that iterates through the hand.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)_hand).GetEnumerator();
        }

    }
}
