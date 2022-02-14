using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using LanguageExt;

namespace WarCardGame
{
    static class Program
    {
        static void Main(string[] args)
        {
            int totalGames = 1000;

            PlayMultipleGames(totalGames);
        }

        private static Arr<Card> CreateDeck()
        {
            var rankCount = Enum.GetNames(typeof(Rank)).Length;
            var trumpCount = Enum.GetNames(typeof(Suit)).Length;
            return Enumerable.Range(0, rankCount * trumpCount)
                .Select(Card.FromInt)
                .ToArr();
        }
        private static void PlayMultipleGames(int count)
        {
            Dictionary<GameResult, int> results = new Dictionary<GameResult, int>()
            {
                { GameResult.Player1, 0 },
                { GameResult.Tie, 0 },
                { GameResult.Player2, 0 }
            };
            var deck = CreateDeck();

            for (int i = 0; i < count; i++)
            {
                var warGameResult = WarGame.Play(deck);
                results[warGameResult]++;
            }
            Console.WriteLine($"Pl1: " + results[GameResult.Player1]);
            Console.WriteLine($"Tie: " + results[GameResult.Tie]);
            Console.WriteLine($"Pl2: " + results[GameResult.Player2]);
        }
    }
}