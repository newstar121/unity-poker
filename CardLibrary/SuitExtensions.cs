using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Contains extensions for the Suit enum.
    /// </summary>
    public static class SuitExtensions
    {
        public static string GetSymbol(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Club:
                    return "\u2663";
                case Suit.Diamond:
                    return "\u2666";
                case Suit.Heart:
                    return "\u2665";
                case Suit.Spade:
                    return "\u2660";
                default:
                    throw new InvalidEnumArgumentException("Invalid enum");
            }
        }
    }
}
