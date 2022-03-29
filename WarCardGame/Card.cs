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

        public static Card Create(Rank rank, Suit suit)
        {
            return new Card(rank, suit);
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