using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grp_C_C_Activity
{
    internal class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"Suit: {Suit}; Rank: {Rank}";
        }
    }
}
