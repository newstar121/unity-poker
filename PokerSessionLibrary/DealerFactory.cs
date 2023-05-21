using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerSessionLibrary
{
    /// <summary>
    /// Factory for dealer objects.
    /// </summary>
    public static class DealerFactory
    {
        /// <summary>
        /// Creates a new dealer.
        /// </summary>
        /// <returns>Returns a new dealer.</returns>
        public static IDealer CreateDealer()
        {
            return new Dealer();
        }
    }
}
