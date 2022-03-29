using System;
using System.Collections.Generic;

namespace WarCardGame
{
    public readonly struct Card
    {
        public readonly Rank Rank;
        public readonly Suit Suit;
        
        private Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public static Card Create(Rank rank, Suit suit)
        {
            return new Card(rank, suit);
        }
        
        public override string ToString()
        {
            return $"[{Rank}; {Suit}]";
        }
    }

    public class CardComparer : IComparer<Card>
    {
        private readonly Suit _trump;
        public CardComparer(Suit trump)
        {
            _trump = trump;
        }
        
        public int Compare(Card x, Card y)
        {
            if ((x.Suit == _trump) == (y.Suit == _trump)) return x.Rank.CompareTo(y.Rank);

            return x.Suit == _trump ? 1 : -1;
        }
    }
}