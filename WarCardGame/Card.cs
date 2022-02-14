using System;

namespace WarCardGame
{
    public readonly struct Card
    {
        private readonly Rank _rank;
        private readonly Suit _suit;
        
        private Card(Rank rank, Suit suit)
        {
            _rank = rank;
            _suit = suit;
        }

        public static Card FromInt(int value)
        {
            var totalRanks = Enum.GetNames(typeof(Rank)).Length;
            Suit t = (Suit) (value / totalRanks);
            Rank r = (Rank) (value - (int)t * totalRanks);
            return new Card(r, t);
        }

        public int CompareTo(Card card2, Suit trump)
        {
            if ((_suit == trump) == (card2._suit == trump)) return _rank.CompareTo(card2._rank);

            return _suit == trump ? 1 : -1;
        }
        
        public override string ToString()
        {
            return $"[{_rank}; {_suit}]";
        }
    }
}