using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace WarCardGame
{
    public static class WarGame
    {
        public static GameResult Play(IEnumerable<Card> deck)
        {
            var trump = (Suit)Enumerable
                .Range(0, Enum.GetNames(typeof(Suit)).Length)
                .Shuffle()
                .First();
            
            return deck
                .Shuffle()
                .ToImmutableArray()
                .Split()
                .AsGameRounds()
                .Sum(x => x.GetRoundResult(trump))
                .AsGameResult();
        }

        private static (ImmutableArray<Card> deck1, ImmutableArray<Card> deck2) Split(this ImmutableArray<Card> deck)
        {
            var totalCards = deck.Length;
            var deck1 = deck
                .Take(totalCards / 2)
                .ToImmutableArray();
            var deck2 = deck
                .RemoveRange(deck1);

            return (deck1, deck2);
        }

        private static ImmutableArray<GameRound> AsGameRounds(this (ImmutableArray<Card>, ImmutableArray<Card>) decks)
        {
            return decks.Item1
                .Zip(decks.Item2)
                .Select(x => new GameRound(x.Item1, x.Item2))
                .ToImmutableArray();
        }

        private static GameResult AsGameResult(this int score)
        {
            if (score == 0) return GameResult.Tie;
            if (score > 0) return GameResult.Player1;
            return GameResult.Player2;
        }

        private readonly struct GameRound
        {
            private readonly Card _card1;
            private readonly Card _card2;

            public GameRound(Card card1, Card card2)
            {
                _card1 = card1;
                _card2 = card2;
            }
            public int GetRoundResult(Suit trump) => _card1.CompareTo(_card2, trump);
        }
    }
}